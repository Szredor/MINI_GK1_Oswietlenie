using Oswietlenie.Geometric;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wielokaty;

namespace Oswietlenie
{
    public partial class Form1 : Form
    {
        private PointMover mover;

        private void TestBitmap()
        {
            var test = new TriangleMesh(new Point(100, 100), 700, 500, 6, 9);
            /*ReferencePoint p1 = new ReferencePoint(200, 150);
            ReferencePoint p2 = new ReferencePoint(100, 200);
            ReferencePoint p3 = new ReferencePoint(150, 300);
            Triangle t = new Triangle(p3, p1, p2);
            ColourModel model = new ColourModel();
            model.ColourObject = Color.Red;

            BitmapOperator.Instance.bitmap.Clear(Color.Gray);
            t.Fill(BitmapOperator.Instance.bitmap, model);*/
        }

        public Form1()
        {
            InitializeComponent();

            pictureBoxSchemat.Image = BitmapOperator.Instance.NewBitmap(1280, 720);
            TestBitmap();
            UpdateBitmap();
        }

        private void UpdateBitmap()
        {
            BitmapOperator.Instance.DrawObjects();
            pictureBoxSchemat.Invalidate();
        }

        private void pictureBoxSchemat_MouseDown(object sender, MouseEventArgs e)
        {
            ReferencePoint p = BitmapOperator.Instance.GetClickedOnPoint(e.Location);
            if (p != null)
            {
                Point offset = ((Point)p).Substract(e.Location);
                mover = new PointMover(offset, p);
            }
        }

        private void pictureBoxSchemat_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover != null)
            {
                mover.MakeMove(e.Location);
                UpdateBitmap();
            }
        }

        private void pictureBoxSchemat_MouseUp(object sender, MouseEventArgs e)
        {
            mover = null;
        }
    }

    class PointMover
    {
        private Stopwatch waitMove;
        private Point moveOffset;
        private ReferencePoint clicked;

        public PointMover(Point offset, ReferencePoint clicked)
        {
            if (clicked != null)
            {
                this.clicked = clicked;
                this.moveOffset = offset;
                this.waitMove = Stopwatch.StartNew();
                Thread.Sleep(BitmapOperator.refreshTimeMs);
            }
            else
                clicked = null;
        }

        public void MakeMove(Point mousePos)
        {
            if (clicked == null)
                return;

            if (waitMove.ElapsedMilliseconds < BitmapOperator.refreshTimeMs)
                return;
            waitMove.Restart();

            Point newPos = mousePos.Add(moveOffset);
            clicked.Position = new Vector3(newPos.X, newPos.Y, 0);
        }
    }
}
