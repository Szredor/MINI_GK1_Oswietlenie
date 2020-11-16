using Oswietlenie;
using Oswietlenie.Geometric;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace Wielokaty
{
    //Źródło: https://stackoverflow.com/a/34801225
    public class DirectBitmap : IDisposable
    {
        private const byte Swap = 1;
        private const byte NegativeX = 2;
        private const byte NegativeY = 4;

        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        private int size;

        protected GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            size = Width * Height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        

        public void SetPixel(int x, int y, Color colour)
        {
            int index = x + (y * Width);
            int col = colour.ToArgb();
            Bits[index] = col;
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);

            return result;
        }

        public void Clear(Color background)
        {
            int col = background.ToArgb();
            for (int i = 0; i < size; ++i)
                Bits[i] = col;
        }

        public void DrawLine(Point A, Point B)
        {
            DrawLine(A, B, Color.Black);
        }
        public void DrawLine(Point A, Point B, Color color)
        {
            Point diff = new Point(B.X - A.X, B.Y - A.Y);

            byte state = 0;
            if (Math.Abs(diff.Y) > Math.Abs(diff.X))
            {
                state |= Swap;
                diff = new Point(diff.Y, diff.X);
            }
            if (diff.X < 0)
            {
                state |= NegativeX;
                diff.X = -diff.X;
            }
            if (diff.Y < 0)
            {
                state |= NegativeY;
                diff.Y = -diff.Y;
            }

            //bresenham
            BresenhamAlgorithm(A, diff, state, color);
        }
        public void DrawPoint(Point A, int size = 1)
        {
            DrawPoint(A, size, Color.Black);
        }
        public void DrawPoint(Point A, int size, Color color)
        {
            for (int y = A.Y - size; y <= A.Y + size; ++y)
                for (int x = A.X - size; x <= A.X + size; ++x)
                    SetPixel(x, y, color);
        }
        private void BresenhamAlgorithm(Point zero, Point diff, byte state, Color color)
        {
            int dx = diff.X;
            int dy = diff.Y;
            int d = 2 * dy - dx;
            int incrE = 2 * dy;
            int incrNE = 2 * (dy - dx);
            int y = 0;

            PutPixel(zero, 0, y, state, color);
            for (int x = 0; x < diff.X; ++x)
            {
                if (d < 0)//choose E
                    d += incrE;
                else//chose NE
                {
                    d += incrNE;
                    ++y;
                }
                PutPixel(zero, x, y, state, color);
            }
        }
        private void PutPixel(Point zero, int x, int y, byte state, Color color)
        {

            if ((state & NegativeX) != 0)
                x = -x;
            if ((state & NegativeY) != 0)
                y = -y;
            if ((state & Swap) != 0)
            {
                int temp = x;
                x = y;
                y = temp;
            }


            SetPixel(zero.X + x, zero.Y + y, color);
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
    }

    class ActiveLineList
    {

        private List<ActiveLine> AET;
        private int nowMinYmax;
        public int MinYMax => AET.Count() == 0 ? int.MinValue : AET.Min(aet => aet.ymax);
        private int[] pointIds;
        private ReferencePoint[] points;
        private int y;
        private int pointIdx;

        public ActiveLineList(IEnumerable<ReferencePoint> points)
        {
            this.points = points.ToArray();
            (int, ReferencePoint)[] tempArr = new (int, ReferencePoint)[this.points.Length];
            for (int i = 0; i < this.points.Length; ++i)
                tempArr[i] = (i, this.points[i]);
            Array.Sort(tempArr, (p1, p2) => (int)(p1.Item2.Position.Y - p2.Item2.Position.Y));
            this.pointIds = tempArr.Select(p => p.Item1).ToArray();
            AET = new List<ActiveLine>();

            InitializeAET();
        }

        private void Insert(ActiveLine line)
        {
            int greater = AET.FindIndex(l => l.X > line.X);
            if (greater < 0)
            {
                greater = AET.FindIndex(l => l.X == line.X && l.dx > line.dx);
                if (greater >= 0)
                    AET.Insert(greater, line);
                else
                    AET.Add(line);
            }
            else
                AET.Insert(greater, line);
        }

        private void ValidatePoint()
        {
            //Usunięcię punktów o końcach poniżej aktualnego y
            List<ActiveLine> toDelete = new List<ActiveLine>();
            foreach (ActiveLine l in AET)
                if (l.ymax <= y)
                    toDelete.Add(l);
            foreach (ActiveLine del in toDelete)
                AET.Remove(del);

            //Do czasu gdy punkty są na aktualnej scanlinii probuj od nich dodawac krawędzie
            for (; pointIdx < points.Length && points[pointIds[pointIdx]].Position.Y == y; pointIdx++)
            {
                int pointId = pointIds[pointIdx];
                int prevId = pointIdx == 0 ? pointIds[points.Length - 1] : pointIds[pointIdx - 1];
                int nextId = pointIdx == points.Length - 1 ? pointIds[0] : pointIds[pointIdx + 1];

                ReferencePoint prev = points[prevId];
                ReferencePoint next = points[nextId];
                ReferencePoint point = points[pointId];

                //jezeli drugi koniec linii będzie powyżej scanlinii, to dodaj do aktywnych linii
                if (prev.Position.Y > y)
                    Insert(new ActiveLine(point, prev));
                if (next.Position.Y > y)
                    Insert(new ActiveLine(point, next));
            }

            nowMinYmax = MinYMax;
        }

        private void InitializeAET()
        {
            y = (int)points[pointIds[0]].Position.Y;
            pointIdx = 0;
            ValidatePoint();
        }

        public bool Increment()
        {
            if (AET.Count() == 0)
                return false;

            if (nowMinYmax == y)
            {
                ValidatePoint();
                return true;
            }
            foreach (ActiveLine line in AET)
                line.Increment();
            ++y;
            return true;
        }

        public List<Point> GetPointsOnScanLine()
        {
            return AET.Select(aet => new Point(aet.X, y)).ToList();
        }
    }
    class ActiveLine
    {
        public readonly int ymax;
        private double x;
        public int X => (int)Math.Floor(x);
        public double dx;

        public void Increment()
        {
            x = x + dx;
        }

        public ActiveLine(ReferencePoint one, ReferencePoint two)
        {
            ymax = (int)two.Position.Y;
            x = one.Position.X;
            if (Math.Floor(one.Position.X) == Math.Floor(two.Position.X))
                dx = 0;
            else
                dx = (two.Position.X - one.Position.X) / (two.Position.Y - one.Position.Y);
        }
    }

    public class BitmapOperator
    {
        private static BitmapOperator instance = null;
        public static BitmapOperator Instance 
        {
            get
            {
                if (instance == null)
                {
                    instance = new BitmapOperator();
                }
                return instance;
            }
            private set { instance = value; }
        }

        private const int defaultX = 500;
        private const int defaultY = 500;
        public const int refreshTimeMs = 80;

        public const double CollideMargin = 5;

        //double buffer?
        public DirectBitmap bitmap;
        private List<TriangleMesh> meshes = new List<TriangleMesh>();
        private Stopwatch lastRefresh;
        
        public Color BackgroundColor { get; private set; } = Color.White;
        public Bitmap Bitmap => bitmap.Bitmap;

        private bool approxColour = false;
        public bool ApproxColour
        {
            get => approxColour;
            set
            {
                approxColour = value;
                if (approxColour)
                {
                    var model = new ColourModelApprox();
                    model.Clone(colourModel);
                    colourModel = model;
                }
                else
                {
                    var model = new ColourModelAcurate();
                    model.Clone(colourModel);
                    colourModel = model;
                }
            }
        }
        public IColourModel colourModel;

        private BitmapOperator()
        {
            NewBitmap(defaultX, defaultY);
            lastRefresh = Stopwatch.StartNew();
            Thread.Sleep(refreshTimeMs);
            bitmap.Clear(BackgroundColor);
        }

        public void SetColourModel()
        {
            foreach (TriangleMesh mesh in meshes)
                mesh.SetColourModel(colourModel);
        }

        public void DrawObjects(bool parallel = false)
        {
            if (lastRefresh?.ElapsedMilliseconds < refreshTimeMs)
                return;
            lastRefresh.Restart();

            bitmap.Clear(BackgroundColor);
            foreach (TriangleMesh obj in meshes)
            {
                obj.FillParalell(bitmap, colourModel);
                obj.Draw(bitmap);
            }
        }

        public Bitmap NewBitmap(int x, int y)
        {
            bitmap = new DirectBitmap(x, y);
            return Bitmap;
        }

        public double Distance(Point A, Point B)
        {
            return Math.Sqrt((B.X - A.X) * (B.X - A.X) + (B.Y - A.Y) * (B.Y - A.Y));
        }

        private Point SegmentClamp(Point d, Point x1, Point x2, double eps)
        {
            if (Distance(d, x1) + Distance(d, x2) - Distance(x1, x2) > eps)
                return Distance(d, x1) > Distance(d, x2) ? x2 : x1;
            return d;
        }

        public Point GetClosestPointToLine(Point A, Point B, Point P)
        {
            Point d;
            if (A.X == B.X)
            #region Przypadek pionowej prostej
            {
                d = new Point() { X = A.X, Y = P.Y };
                d = SegmentClamp(d, A, B, 0.1);
            }
            #endregion
            else if (A.Y == B.Y)
            #region Przypadek poziomej prostej
            {
                d = new Point() { X = P.X, Y = P.Y };
                d = SegmentClamp(d, A, B, 0.1);
            }
            #endregion
            else
            #region Przypadek ogólny
            {
                double a = (double)(A.Y - B.Y) / (A.X - B.X);
                double b = A.Y - a * A.X;
                double c = P.Y + P.X / a;
                d = new Point();
                double exactX = a * (c - b) / (a * a + 1);
                d.Y = (int)Math.Floor(a * exactX + b);
                d.X = (int)Math.Floor(exactX);
                d = SegmentClamp(d, A, B, 0.1);
            }
            #endregion

            return d;
        }

        public bool PointCollidesWithSegment(Point A, Point B, Point P)
        {
            Point seg = GetClosestPointToLine(A, B, P);
            double dist = Distance(seg, P);
            if (dist < CollideMargin)
                return true;
            return false;
        }


        #region Drawable queries
        public bool RegisterTriangleMesh(TriangleMesh obj)
        {
            if (meshes.Contains(obj))
                return false;
            meshes.Add(obj);
            return true;
        }
        public bool UnregisterTriangleMesh(TriangleMesh obj)
        {
            return meshes.Remove(obj);
        }

        public ReferencePoint GetClickedOnPoint(Point p)
        {
            foreach (TriangleMesh mesh in meshes)
                if (mesh.Collides(p, out ReferencePoint point))
                    return point;
            return null;
        }
        #endregion
    }
}
