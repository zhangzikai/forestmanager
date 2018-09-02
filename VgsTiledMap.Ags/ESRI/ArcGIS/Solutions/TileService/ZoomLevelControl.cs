namespace ESRI.ArcGIS.Solutions.TileService
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class ZoomLevelControl : UserControl
    {
        private Button btnZoomIn;
        private Button btnZoomOut;
        private IContainer components;
        private TrackBar trackBar1 = new TrackBar();

        public event ZoomLevelChangedEventHandler ZoomLevelChanged;

        public ZoomLevelControl()
        {
            this.InitializeComponent();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            this.ZoomIn();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            this.ZoomOut();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.trackBar1 = new TrackBar();
            this.btnZoomIn = new Button();
            this.btnZoomOut = new Button();
            this.trackBar1.BeginInit();
            base.SuspendLayout();
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new Point(3, 30);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = Orientation.Vertical;
            this.trackBar1.Size = new Size(0x35, 0x134);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 5;
            this.trackBar1.ValueChanged += new EventHandler(this.trackBar1_ValueChanged);
            this.btnZoomIn.Location = new Point(3, 3);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new Size(0x22, 0x1f);
            this.btnZoomIn.TabIndex = 2;
            this.btnZoomIn.Text = "+";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new EventHandler(this.btnZoomIn_Click);
            this.btnZoomOut.Location = new Point(3, 0x14d);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new Size(0x22, 0x1f);
            this.btnZoomOut.TabIndex = 3;
            this.btnZoomOut.Text = "-";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new EventHandler(this.btnZoomOut_Click);
            base.AutoScaleDimensions = new SizeF(8f, 15f);
            base.Controls.Add(this.btnZoomOut);
            base.Controls.Add(this.btnZoomIn);
            base.Controls.Add(this.trackBar1);
            base.Name = "ZoomLevelControl";
            base.Size = new Size(40, 370);
            this.trackBar1.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public void initializeZoomLevel(int maxLevel)
        {
            this.trackBar1.Maximum = maxLevel;
            this.trackBar1.Minimum = 0;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (this.ZoomLevelChanged != null)
            {
                this.ZoomLevelChanged(this.trackBar1.Value);
            }
        }

        public void ZoomIn()
        {
            if (this.trackBar1.Value < this.trackBar1.Maximum)
            {
                this.trackBar1.Value++;
            }
            if (this.ZoomLevelChanged != null)
            {
                this.ZoomLevelChanged(this.trackBar1.Value);
            }
        }

        public void ZoomOut()
        {
            if (this.trackBar1.Value > this.trackBar1.Minimum)
            {
                this.trackBar1.Value--;
            }
            if (this.ZoomLevelChanged != null)
            {
                this.ZoomLevelChanged(this.trackBar1.Value);
            }
        }

        public int ZoomLevel
        {
            get
            {
                return this.trackBar1.Value;
            }
            set
            {
                if ((value <= this.trackBar1.Maximum) || (value >= this.trackBar1.Minimum))
                {
                    this.trackBar1.Value = value;
                    if (this.ZoomLevelChanged != null)
                    {
                        this.ZoomLevelChanged(this.trackBar1.Value);
                    }
                }
            }
        }

        public delegate void ZoomLevelChangedEventHandler(int level);
    }
}

