using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoxelSpaceSharp
{
    public partial class frmMain : Form
    {
        private int DIFFUSE_BITMAP_HEIGHT = 1024;
        private int DIFFUSE_BITMAP_WIDTH = 1024;
        private int HEIGHT_BITMAP_WIDTH = 1024;
        private int HEIGHT_BITMAP_HEIGT = 1024;
        private System.Windows.Forms.Timer timer;
        private Bitmap diffuseBitmap;
        private Bitmap heightBitmap;
        private bool rendering;
        private int[,] heightMap;
        private Color[,] diffuseMap;
        private float[] yBuffer;

        private PointF p = new PointF(100, 100);
        private double degrees = 0;
        private int horizon = 120;
        private int distance = 300;
        public frmMain()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 100;
            timer.Start();
            this.MouseWheel += FrmMain_MouseWheel;
            mapList.Items.Clear();
            foreach(var key in ResourceRegister.Instance.GetDiffuseMaps())
            {
                mapList.Items.Add(key);
            }


        }

        private void FrmMain_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!rendering)
                return;
            if (e.Delta > 0)//Wheel Forward
                distance -= 10;
            else if (e.Delta < 0)//Wheel Backward
                distance += 10;
        }

        private void RenderThread()
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            canvas.Invalidate();
        }

        private void canvas_paint(object sender, PaintEventArgs e)
        {
            if (rendering)
            {
                Render(p, degrees, 100, horizon, 120, distance, canvas.Width, canvas.Height, e.Graphics);
            }
        }
        private void Render(PointF p, double degrees, int height, int horizon, int scale_height, int distance, int screen_width, int screen_height, Graphics g)
        {
            g.Clear(Color.FromArgb(102, 163, 225));

            yBuffer = new float[screen_width];
            for (int i = 0; i < yBuffer.Length; i++)
            {
                yBuffer[i] = screen_height;
            }

            double sinphi = Math.Sin(GetRadian(degrees));
            double cosphi = Math.Cos(GetRadian(degrees));

            float z = 1;
            float dz = 1;
            while (z < distance)
            {
                PointF pLeft = new PointF(
                    (float)(-cosphi * z - sinphi * z) + p.X,
                    (float)(sinphi * z - cosphi * z) + p.Y);
                PointF pRight = new PointF(
                    (float)(cosphi * z - sinphi * z) + p.X,
                    (float)(-sinphi * z - cosphi * z) + p.Y);

                float dx = (float)(pRight.X - pLeft.X) / (float)screen_width;
                float dy = (float)(pRight.Y - pLeft.Y) / (float)screen_width;
                for (int i = 0; i < screen_width; i++)
                {
                    int diffuseX = (int)pLeft.X & (DIFFUSE_BITMAP_WIDTH - 1);
                    int diffuseY = (int)pLeft.Y & (DIFFUSE_BITMAP_HEIGHT - 1);
                    int heightX = (int)pLeft.X & (HEIGHT_BITMAP_WIDTH - 1);
                    int heightY = (int)pLeft.Y & (HEIGHT_BITMAP_HEIGT - 1);

                    float heightOfHeightMap = heightMap[heightX & (HEIGHT_BITMAP_WIDTH - 1), heightY & (HEIGHT_BITMAP_HEIGT - 1)];
                    float height_on_screen = (float)(height - heightOfHeightMap) / (float)z * (float)scale_height + (float)horizon;
                    Color color = diffuseMap[diffuseX & (DIFFUSE_BITMAP_WIDTH - 1), diffuseY & (DIFFUSE_BITMAP_HEIGHT - 1)];
                    DrawVerticalLine(i, (int)height_on_screen, yBuffer[i], color, g);
                    if (height_on_screen < yBuffer[i])
                    {
                        yBuffer[i] = height_on_screen;
                    }
                    pLeft.X += dx;
                    pLeft.Y += dy;
                }
                z += dz;
                dz += 0.005f;
            }
        }

        private double GetRadian(double degrees)
        {
            return Math.PI * degrees / 180;
        }

        private void DrawVerticalLine(int x, int ytop, float ybottom, Color col, Graphics g)
        {
            if (ytop > ybottom)
            {
                return;
            }
            g.DrawLine(new Pen(new SolidBrush(col)), x, ytop, x, ybottom);
        }

        double CustomRound(double value, int decimals)
        {
            if (value < 0.5)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private void btnStartRender_Click(object sender, EventArgs e)
        {
        }

        private void LoadMapAndRender()
        {
            string selectedMap = mapList.SelectedItem.ToString();

            diffuseBitmap = new Bitmap(ResourceRegister.Instance.GetDiffuseMap(selectedMap));
            heightBitmap = new Bitmap(ResourceRegister.Instance.GetHeightMap(selectedMap));
            DIFFUSE_BITMAP_WIDTH = diffuseBitmap.Width;
            DIFFUSE_BITMAP_HEIGHT = diffuseBitmap.Height;
            HEIGHT_BITMAP_HEIGT = heightBitmap.Height;
            HEIGHT_BITMAP_WIDTH = heightBitmap.Width;
            ProcessHeightMap(heightBitmap);
            ProcessDiffuseMap(diffuseBitmap);

            rendering = true;
        }

        private void ProcessHeightMap(Bitmap bitmap)
        {
            if (bitmap != null)
            {
                heightMap = new int[bitmap.Width, bitmap.Height];
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        heightMap[i, j] = bitmap.GetPixel(i, j).R;
                    }
                }
            }
        }

        private void ProcessDiffuseMap(Bitmap bitmap)
        {
            if (bitmap != null)
            {
                diffuseMap = new Color[bitmap.Width, bitmap.Height];
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        diffuseMap[i, j] = bitmap.GetPixel(i, j);
                    }
                }
            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (!rendering)
                return;
            Keys k = e.KeyCode;
            switch(k)
            {
                case Keys.W://Forward
                    p.X -= (float)(10 * Math.Sin(GetRadian(degrees)));
                    p.Y -= (float)(10 * Math.Cos(GetRadian(degrees)));
                    break;
                case Keys.S://Backward
                    p.X += (float)(10 * Math.Sin(GetRadian(degrees)));
                    p.Y += (float)(10 * Math.Cos(GetRadian(degrees)));
                    break;
                case Keys.A://Turn Left
                    degrees += 10;
                    break;
                case Keys.D://Turn Right
                    degrees -= 10;
                    break;
                case Keys.O://Look up
                    horizon += 10;
                    break;
                case Keys.P://Look down
                    horizon -= 10;
                    break;
            }
        }

        private void mapList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMapAndRender();
        }
    }
}
