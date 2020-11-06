using Oswietlenie.ColourConfiguration;
using Oswietlenie.Geometric;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wielokaty;

namespace Oswietlenie
{
    public partial class Form1 : Form
    {
        private PointMover mover;
        private CancellationTokenSource TokenSrcLight = new CancellationTokenSource();
        private object UpdateLock = new object();

        private void TestBitmap()
        {
            var test = new TriangleMesh(new Point(100, 100), 700, 500, 6, 9);

            BitmapOperator.Instance.ApproxColour = false;
            BitmapOperator.Instance.colourModel.kd = 0.5f;
            BitmapOperator.Instance.colourModel.ks = 0.5f;
            BitmapOperator.Instance.colourModel.m = 5;
            BitmapOperator.Instance.colourModel.LightVector = new StaticLightVector(new Vector3(0, 0, 1));
            BitmapOperator.Instance.colourModel.LigthColor = new LightColour(Color.White);
            BitmapOperator.Instance.colourModel.NormalMap = new StaticNormalMap(new Vector3(0, 0, 1));
            BitmapOperator.Instance.colourModel.ColourObject = new SolidColor(Color.Red);
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
            Monitor.Enter(UpdateLock);
            try
            {
                BitmapOperator.Instance.DrawObjects();
                pictureBoxSchemat.Invalidate();
            }
            finally
            {
                Monitor.Exit(UpdateLock);
            }
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

        //Ustalenie stałego koloru obiektu
        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialogObject.ShowDialog() == DialogResult.OK)
            {
                button1.ForeColor = colorDialogObject.Color;
                BitmapOperator.Instance.colourModel.ColourObject = new SolidColor(colorDialogObject.Color);
                UpdateBitmap();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialogLight.ShowDialog() == DialogResult.OK)
            {
                button4.ForeColor = colorDialogLight.Color;
                BitmapOperator.Instance.colourModel.LigthColor = new LightColour(colorDialogLight.Color);
                UpdateBitmap();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PNG files(*.png)| *.png|BMP files(*.bmp)| *.bmp|GIF files(*.gif)| *.gif|JPEG files(*.jpeg)| *.jpeg|TIFF files(*.tiff)| *.tiff";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BitmapOperator.Instance.colourModel.ColourObject = new TextureColor(openFileDialog1.FileName);
                UpdateBitmap();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = openFileDialog1.Filter = "PNG files(*.png)| *.png|BMP files(*.bmp)| *.bmp|GIF files(*.gif)| *.gif|JPEG files(*.jpeg)| *.jpeg|TIFF files(*.tiff)| *.tiff";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BitmapOperator.Instance.colourModel.NormalMap = new TextureNormalMap(openFileDialog1.FileName);
                UpdateBitmap();
            }
        }

        private void radioButtonNMStatic_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButtonNMStatic.Checked)
            { 
                BitmapOperator.Instance.colourModel.NormalMap = new StaticNormalMap(new Vector3(0, 0, 1));
                button3.Enabled = false;
                UpdateBitmap();
            }
        }

        private void radioButtonNMFile_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNMFile.Checked)
            {
                button3.Enabled = true;
                UpdateBitmap();
            }
        }

        private void radioButtonLightStatic_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLightStatic.Checked)
            {
                TokenSrcLight.Cancel();

                BitmapOperator.Instance.colourModel.LightVector = new StaticLightVector(new Vector3(0, 0, 1));
                UpdateBitmap();
            }

        }

        private void radioButtonLightMove_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLightMove.Checked)
            {
                BitmapOperator.Instance.colourModel.LightVector = new MovingLightSource(BitmapOperator.Instance.Bitmap.Width, BitmapOperator.Instance.Bitmap.Height);
                UpdateBitmap();

                //wystartuj asynca
                TokenSrcLight = new CancellationTokenSource();
                Task t = Task.Run(UpdateLightAsync, TokenSrcLight.Token);
            }
        }

        async private Task UpdateLightAsync()
        {
            while (true)
            {
                await Task.Delay(MovingLightSource.updateInterval);
                if (TokenSrcLight.Token.IsCancellationRequested)
                    break;

                BitmapOperator.Instance.colourModel.LightVector.UpdateLight();

                if (Monitor.TryEnter(UpdateLock))
                {
                    BitmapOperator.Instance.DrawObjects();
                    pictureBoxSchemat.Invalidate();
                    Monitor.Exit(UpdateLock);
                }
            }
        }

        private void radioButtonLightAcurate_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLightAcurate.Checked)
            {
                BitmapOperator.Instance.ApproxColour = false;
                UpdateBitmap();
            }
        }

        private void radioButtonLightApprox_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLightApprox.Checked)
            {
                BitmapOperator.Instance.ApproxColour = true;
                UpdateBitmap();
            }
        }

        private void numericKD_ValueChanged(object sender, EventArgs e)
        {
            BitmapOperator.Instance.colourModel.kd = (float)numericKD.Value;
        }

        private void numericKS_ValueChanged(object sender, EventArgs e)
        {
            BitmapOperator.Instance.colourModel.ks = (float)numericKS.Value;
        }

        private void numericM_ValueChanged(object sender, EventArgs e)
        {
            BitmapOperator.Instance.colourModel.m = (int)numericM.Value;
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
