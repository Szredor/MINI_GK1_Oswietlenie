using Oswietlenie.Geometric;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
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

        protected GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void SetPixel(int x, int y, Color colour)
        {
            int index = x + (y * Width);
            int col = colour.ToArgb();

            int size = Width * Height;
            Bits[((index%size) + size) % size] = col;
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
            for (int i = 0; i < Width * Height; ++i)
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

    class BitmapOperator
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
        public const int refreshTimeMs = 50;

        public const double CollideMargin = 5;

        //double buffer?
        private DirectBitmap bitmap;
        private List<TriangleMesh> meshes = new List<TriangleMesh>();
        private Stopwatch lastRefresh;
        
        public Color BackgroundColor { get; private set; } = Color.White;
        public Bitmap Bitmap => bitmap.Bitmap;

        private BitmapOperator()
        {
            NewBitmap(defaultX, defaultY);
            lastRefresh = Stopwatch.StartNew();
            Thread.Sleep(refreshTimeMs);
            bitmap.Clear(BackgroundColor);
        }

        public void DrawObjects()
        {
            if (lastRefresh?.ElapsedMilliseconds < refreshTimeMs)
                return;
            lastRefresh.Restart();

            bitmap.Clear(BackgroundColor);
            foreach (TriangleMesh obj in meshes)
                    obj.Draw(bitmap);
        }

        public Bitmap NewBitmap(int x, int y)
        {
            bitmap = new DirectBitmap(x, y);
            return Bitmap;
        }

        public bool IsPointOutside(Point p)
        {
            if (p.X >= bitmap.Width)
                return true;

            if (p.Y >= bitmap.Height)
                return true;

            return false;
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
