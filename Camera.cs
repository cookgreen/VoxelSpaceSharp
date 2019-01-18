using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace VoxelSpaceSharp
{
    public class Camera
    {
        private const int FOV = 90;
        private PointF position;
        private int horizon;
        private int angle;
        private int height;

        public PointF Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public int Horizon
        {
            get
            {
                return horizon;
            }
            set
            {
                horizon = value;
            }
        }

        public int Angle
        {
            get
            {
                return angle;
            }
            set
            {
                angle = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        public void MovePositionX(int xMovement)
        {
            position.X += xMovement;
        }

        public void MovePositionY(int yMovement)
        {
            position.Y += yMovement;
        }

        public void ChangeHorizon(int offset)
        {
            horizon += offset;
        }

        public void ChangeDegree(int offset)
        {
            angle += offset;
        }

        public void ChangeHeight(int offset)
        {
            height += offset;
        }

        public Camera(int horizon, PointF position, int angle)
        {
            this.horizon = horizon;
            this.position = position;
            this.angle = angle;
        }
    }
}
