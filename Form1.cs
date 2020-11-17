using Oswietlenie.ColourConfiguration;
using Oswietlenie.Geometric;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        private int cols = 10;
        private int rows = 10;
        TriangleMesh triangleMesh;

        private void CreateBitmap()
        {
            triangleMesh?.Dispose();
            triangleMesh = new TriangleMesh(new Point(50, 50), 1180, 620, rows, cols);
            
        }

        private void TestBitmap()
        {
            CreateBitmap();

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
            BitmapOperator.Instance.SetColourModel();
            UpdateBitmap();
        }

        private void UpdateBitmap()
        {
            Monitor.Enter(UpdateLock);
            try
            {
                if (BitmapOperator.Instance.IsReadyToUpdate)
                {
                    BitmapOperator.Instance.DrawObjects();
                    pictureBoxSchemat.Invalidate();
                }
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
                BitmapOperator.Instance.SetColourModel();
                UpdateBitmap();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialogLight.ShowDialog() == DialogResult.OK)
            {
                button4.ForeColor = colorDialogLight.Color;
                BitmapOperator.Instance.colourModel.LigthColor = new LightColour(colorDialogLight.Color);
                BitmapOperator.Instance.SetColourModel();
                UpdateBitmap();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Images\\Textures";
            openFileDialog1.InitialDirectory = path;
            openFileDialog1.Filter = "PNG files(*.png)| *.png|BMP files(*.bmp)| *.bmp|GIF files(*.gif)| *.gif|JPEG files(*.jpeg)| *.jpeg|TIFF files(*.tiff)| *.tiff";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BitmapOperator.Instance.colourModel.ColourObject = new TextureColor(openFileDialog1.FileName);
                BitmapOperator.Instance.SetColourModel();
                UpdateBitmap();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Images\\NormalMaps";
            if (Directory.Exists(path))
                openFileDialog2.InitialDirectory = path;
            openFileDialog2.Filter = openFileDialog2.Filter = "PNG files(*.png)| *.png|BMP files(*.bmp)| *.bmp|GIF files(*.gif)| *.gif|JPEG files(*.jpeg)| *.jpeg|TIFF files(*.tiff)| *.tiff";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                BitmapOperator.Instance.colourModel.NormalMap = new TextureNormalMap(openFileDialog2.FileName);
                BitmapOperator.Instance.SetColourModel();
                UpdateBitmap();
            }
        }

        private void radioButtonNMStatic_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButtonNMStatic.Checked)
            { 
                BitmapOperator.Instance.colourModel.NormalMap = new StaticNormalMap(new Vector3(0, 0, 1));
                BitmapOperator.Instance.SetColourModel();
                button3.Enabled = false;
                UpdateBitmap();
            }
        }

        private void radioButtonNMFile_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNMFile.Checked)
            {
                button3.Enabled = true;
            }
        }

        private void radioButtonLightStatic_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLightStatic.Checked)
            {
                TokenSrcLight.Cancel();

                BitmapOperator.Instance.colourModel.LightVector = new StaticLightVector(new Vector3(0, 0, 1));
                BitmapOperator.Instance.SetColourModel();
                UpdateBitmap();
            }

        }

        private void radioButtonLightMove_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLightMove.Checked)
            {
                BitmapOperator.Instance.colourModel.LightVector = new MovingLightSource(BitmapOperator.Instance.Bitmap.Width, BitmapOperator.Instance.Bitmap.Height);
                BitmapOperator.Instance.SetColourModel();
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
                //Z jakiegos powodu przy kopiowaniu przyblizonego sposobu rysowania zle wykonuje sie kopia ILightVector i trzeba ciagle rozsylac nowe wersje po odswiezeniu.
                BitmapOperator.Instance.SetColourModel();

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
                BitmapOperator.Instance.SetColourModel();
                UpdateBitmap();
            }
        }

        private void radioButtonLightApprox_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLightApprox.Checked)
            {
                BitmapOperator.Instance.ApproxColour = true;
                BitmapOperator.Instance.SetColourModel();
                UpdateBitmap();
            }
        }

        private void numericKD_ValueChanged(object sender, EventArgs e)
        {
            BitmapOperator.Instance.colourModel.kd = (float)numericKD.Value;
            BitmapOperator.Instance.SetColourModel();
            UpdateBitmap();
        }

        private void numericKS_ValueChanged(object sender, EventArgs e)
        {
            BitmapOperator.Instance.colourModel.ks = (float)numericKS.Value;
            BitmapOperator.Instance.SetColourModel();
            UpdateBitmap();
        }

        private void numericM_ValueChanged(object sender, EventArgs e)
        {
            BitmapOperator.Instance.colourModel.m = (int)numericM.Value;
            BitmapOperator.Instance.SetColourModel();
            UpdateBitmap();
        }

        private void numericUpDownCols_ValueChanged(object sender, EventArgs e)
        {
            cols = (int)numericUpDownCols.Value;
            CreateBitmap();
            BitmapOperator.Instance.SetColourModel();
            UpdateBitmap();
        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            rows = (int)numericUpDownRows.Value;
            CreateBitmap();
            BitmapOperator.Instance.SetColourModel();
            UpdateBitmap();
        }

        private void numericUpDownWave_ValueChanged(object sender, EventArgs e)
        {
            BitmapOperator.Instance.WaveDistance = (float)numericUpDownWave.Value;
            UpdateBitmap();
        }

        private void radioWaveNM_CheckedChanged(object sender, EventArgs e)
        {
            if (radioWaveNM.Checked)
            {
                BitmapOperator.Instance.colourModel.NormalMap = new WaveNormalMap(BitmapOperator.Instance.bitmap.Width, BitmapOperator.Instance.bitmap.Height);
                BitmapOperator.Instance.SetColourModel();
                button3.Enabled = false;
                UpdateBitmap();
            }
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
