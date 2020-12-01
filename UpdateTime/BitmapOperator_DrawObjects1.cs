using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oswietlenie.ColourConfiguration;
using Oswietlenie.Geometric;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;

namespace Wielokaty
{
    [TestClass]
    public class BitmapOperator_DrawObjects1
    {
        const int framerate = 15;
        const int repeat = 3;
        private float refreshLimit;

        [TestInitialize]
        public void InitBitmap()
        {
            BitmapOperator.Instance.NewBitmap(1280, 720);
            var test = new TriangleMesh(new Point(100, 100), 700, 500, 6, 9);

            BitmapOperator.Instance.ApproxColour = false;
            BitmapOperator.Instance.colourModel.kd = 0.5f;
            BitmapOperator.Instance.colourModel.ks = 0.5f;
            BitmapOperator.Instance.colourModel.m = 5;
            BitmapOperator.Instance.colourModel.LightVector = new StaticLightVector(new Vector3(0, 0, 1));
            BitmapOperator.Instance.colourModel.LigthColor = new LightColour(Color.White);
            BitmapOperator.Instance.colourModel.NormalMap = new StaticNormalMap(new Vector3(0, 0, 1));
            BitmapOperator.Instance.colourModel.ColourObject = new SolidColor(Color.Red);
            BitmapOperator.Instance.SetColourModel();

            refreshLimit = 1000.0f / framerate;
        }

        [TestMethod("Draw All")]
        public void DrawAll()
        {
            Stopwatch time = Stopwatch.StartNew();
            for (int i = 0; i < repeat; ++i)
                BitmapOperator.Instance.DrawObjects(false);
            time.Stop();

            Assert.IsTrue(time.ElapsedMilliseconds / repeat <= refreshLimit, "Elapsed time {0} > {1}", time.ElapsedMilliseconds / repeat, refreshLimit);
        }

        [TestMethod("Draw All Parallel")]
        public void DrawAllParallel()
        {
            Stopwatch time = Stopwatch.StartNew();
            for (int i = 0; i < repeat; ++i)
                BitmapOperator.Instance.DrawObjects();
            time.Stop();

            Assert.IsTrue(time.ElapsedMilliseconds/repeat <= refreshLimit, "Elapsed time {0} > {1}", time.ElapsedMilliseconds/repeat, refreshLimit);
        }
    }
}
