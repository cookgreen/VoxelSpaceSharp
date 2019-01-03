﻿using System;
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
        //private byte[] heightMap;
        //private Color[] diffuseMap;
        private int[,] heightMap;
        private Color[,] diffuseMap;
        private Point p = new Point(100, 100);
        private bool isIncreasing = false;
        private double degrees = 0;
        public frmMain()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 5000;
            timer.Start();
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
                Render(p, degrees, 78, 120, 120, 300, canvas.Width, canvas.Height, e.Graphics);
                if (!isIncreasing && degrees != 0)
                {
                    degrees -= 10;
                }
                else if (degrees == 0)
                {
                    isIncreasing = true;
                    degrees += 10;
                }
                else if (isIncreasing && degrees != 360)
                {
                    degrees += 10;
                }
                else if (degrees == 360)
                {
                    isIncreasing = false;
                }
            }
        }

        private void btnDiffuseOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image File|*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtDiffuseMap.Text = dialog.FileName;
            }
        }

        private void btnHeightOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image File|*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtHeightMap.Text = dialog.FileName;
            }
        }
        private void Render(Point p, double degrees, int height, int horizon, int scale_height, int distance, int screen_width, int screen_height, Graphics g)
        {
            #region Solution 1
            g.Clear(Color.FromArgb(102, 163, 225));

            double sinphi = Math.Sin(GetAnge(degrees));
            double cosphi = Math.Cos(GetAnge(degrees));

            for (int z = distance; z > 1; z--)
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
                    DrawVerticalLine(i, (int)height_on_screen, screen_height, color, g);
                    pLeft.X += dx;
                    pLeft.Y += dy;
                }
            }
            #endregion

            #region Solution 2
            /*var mapWidthPeriod = BITMAP_WIDTH - 1;
            var mapHeightPeriod = BITMAP_HEIGHT - 1;

            g.Clear(Color.FromArgb(102, 163, 225));
            float ratio = (float)screen_width / (float)BITMAP_WIDTH;
            float deltaZ = 1;
            for (float z = 1; z < distance; z+=deltaZ)
            {
                PointF pLeft = new PointF(-z + p.X, -z + p.Y);
                PointF pRight = new PointF(z + p.X, -z + p.Y);

                float dxf = (float)(pRight.X - pLeft.X) / (float)screen_width;
                int dx = (int)CustomRound(dxf * ratio, 0);
                float dyf = (float)(pRight.Y - pLeft.Y) / (float)screen_height;
                int dy = (int)CustomRound(dyf * ratio, 0);

                float invz = (float)1 / (float)z * 240;

                for (int i = 0; i < screen_width; i++)
                {
                    int mapOffset = (((int)pLeft.Y & mapWidthPeriod) << 10) + ((int)pLeft.X & mapHeightPeriod);
                    float heightOfHeightMap = heightMap[mapOffset];
                    float height_on_screen = (float)(height - heightOfHeightMap) * (float)invz + (float)horizon;
                    if (height_on_screen > 0 && height_on_screen < screen_height)
                    {
                        Color color = diffuseMap[mapOffset];
                        DrawVerticalLine(i, (int)height_on_screen, screen_height, color, g);
                        pLeft.X += dx;
                        pLeft.Y += dy;
                    }
                }
                deltaZ += 0.005f;
            }*/
            #endregion
        }

        private double GetAnge(double degrees)
        {
            return Math.PI * degrees / 180;
        }

        private void DrawVerticalLine(int x, int ytop, int ybottom, Color col, Graphics g)
        {
            #region Solution 1
            //float startY = ytop;
            //float endY = ybottom;

            //g.DrawLine(new Pen(col), x, startY, x, endY);
            #endregion

            #region Solution 2
            if (ytop > ybottom)
            {
                return;
            }
            g.DrawLine(new Pen(new SolidBrush(col)), x, ytop, x, ybottom);
            #endregion
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
            if(string.IsNullOrEmpty(txtDiffuseMap.Text))
            {
                MessageBox.Show("Diffuse map can't be empty!");
                return;
            }

            if (string.IsNullOrEmpty(txtHeightMap.Text))
            {
                MessageBox.Show("Height map can't be empty!");
                return;
            }

            diffuseBitmap = new Bitmap(txtDiffuseMap.Text);
            heightBitmap = new Bitmap(txtHeightMap.Text);
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
                #region Solution 1
                heightMap = new int[bitmap.Width, bitmap.Height];
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        heightMap[i, j] = bitmap.GetPixel(i, j).R;
                    }
                }
                #endregion

                #region Solution 2
                //heightMap = new byte[bitmap.Width * bitmap.Height];

                //Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                //BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                //System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, heightMap, 0, bitmapData.Width * bitmap.Height);

                //bitmap.UnlockBits(bitmapData);
                #endregion
            }
        }

        private void ProcessDiffuseMap(Bitmap bitmap)
        {
            if (bitmap != null)
            {
                #region Solution 1
                diffuseMap = new Color[bitmap.Width, bitmap.Height];
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        diffuseMap[i, j] = bitmap.GetPixel(i, j);
                    }
                }
                #endregion

                #region Solution 2
                //diffuseMap = new Color[bitmap.Width*bitmap.Height];
                //for (int i = 0; i < bitmap.Width; i++)
                //{
                //    for (int j = 0; j < bitmap.Height; j++)
                //    {
                //        diffuseMap[1024 * i + j] = bitmap.GetPixel(i, j);
                //    }
                //}
                #endregion
            }
        }
    }
}
