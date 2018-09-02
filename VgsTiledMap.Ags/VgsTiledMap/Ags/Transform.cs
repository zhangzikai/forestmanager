namespace VgsTiledMap.Ags
{
    using System;
    using System.Drawing;
    using VgsMap.Tile;

    public class Transform
    {
        private PointF center;
        private VgsMap.Tile.Extent extent;
        private float height;
        private float resolution;
        private float width;

        public Transform(PointF center, float resolution, float width, float height)
        {
            this.center = center;
            this.resolution = resolution;
            this.width = width;
            this.height = height;
            this.UpdateExtent();
        }

        public PointF MapToWorld(double x, double y)
        {
            return new PointF(((float) (this.extent.MinX + x)) * this.resolution, ((float) (this.extent.MaxY - y)) * this.resolution);
        }

        private void UpdateExtent()
        {
            float num = 1f;
            float num2 = (this.width * this.resolution) * num;
            float num3 = (this.height * this.resolution) * num;
            this.extent = new VgsMap.Tile.Extent((double) (this.center.X - (num2 * 0.5f)), (double) (this.center.Y - (num3 * 0.5f)), (double) (this.center.X + (num2 * 0.5f)), (double) (this.center.Y + (num3 * 0.5f)));
        }

        public PointF WorldToMap(double x, double y)
        {
            return new PointF(((float) (x - this.extent.MinX)) / this.resolution, ((float) (this.extent.MaxY - y)) / this.resolution);
        }

        public RectangleF WorldToMap(double x1, double y1, double x2, double y2)
        {
            PointF tf = this.WorldToMap(x1, y1);
            PointF tf2 = this.WorldToMap(x2, y2);
            return new RectangleF(tf.X, tf2.Y, tf2.X - tf.X, tf.Y - tf2.Y);
        }

        public PointF Center
        {
            set
            {
                this.center = value;
                this.UpdateExtent();
            }
        }

        public VgsMap.Tile.Extent Extent
        {
            get
            {
                return this.extent;
            }
        }

        public float Height
        {
            set
            {
                this.height = value;
                this.UpdateExtent();
            }
        }

        public float Resolution
        {
            get
            {
                return this.resolution;
            }
            set
            {
                this.resolution = value;
                this.UpdateExtent();
            }
        }

        public float Width
        {
            set
            {
                this.width = value;
                this.UpdateExtent();
            }
        }
    }
}

