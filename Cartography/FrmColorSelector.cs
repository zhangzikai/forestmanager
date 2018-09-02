namespace Cartography
{
    using ESRI.ArcGIS.ADF.COMSupport;
    using ESRI.ArcGIS.Display;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class FrmColorSelector : Form
    {
        private Rectangle[] allRec;
        private ColorDialog colorDialog;
        private static string[] colorList = new string[] { 
            "#FFFFFF", "#FFFFCC", "#FFFF99", "#FFFF66", "#FFFF33", "#FFFF00", "#FFCCFF", "#FFCCCC", "#FFCC99", "#FFCC66", "#FFCC33", "#FFCC00", "#FF99FF", "#FF99CC", "#FF9999", "#FF9966",
            "#FF9933", "#FF9900", "#FF66FF", "#FF66CC   ", "#FF6699   ", "#FF6666", "#FF6633", "#FF6600", "#FF33FF", "#FF33CC", "#FF3399", "#FF3366", "#FF3333", "#FF3300", "#FF00FF   ", "#FF00CC   ",
            "#FF0099", "#FF0066", "#FF0033", "#FF0000", "#66FFFF", "#66FFCC", "#66FF99", "#66FF66", "#66FF33", "#66FF00   ", "#66CCFF   ", "#66CCCC", "#66CC99", "#66CC66", "#66CC33", "#66CC00",
            "#6699FF", "#6699CC", "#669999", "#669966", "#669933   ", "#669900   ", "#6666FF", "#6666CC", "#666699", "#666666", "#666633", "#666600", "#6633FF", "#6633CC", "#663399", "#663366   ",
            "#663333   ", "#663300", "#6600FF", "#6600CC", "#660099", "#660066", "#660033", "#660000", "#CCFFFF", "#CCFFCC", "#CCFF99   ", "#CCFF66   ", "#CCFF33   ", "#CCFF00", "#CCCCFF", "#CCCCCC",
            "#CCCC99", "#CCCC66", "#CCCC33", "#CCCC00", "#CC99FF", "#CC99CC", "#CC9999   ", "#CC9966   ", "#CC9933   ", "#CC9900", "#CC66FF", "#CC66CC", "#CC6699", "#CC6666", "#CC6633", "#CC6600",
            "#CC33FF", "#CC33CC", "#CC3399   ", "#CC3366   ", "#CC3333   ", "#CC3300", "#CC00FF", "#CC00CC", "#CC0099", "#CC0066", "#CC0033", "#CC0000", "#33FFFF", "#33FFCC", "#33FF99   ", "#33FF66   ",
            "#33FF33   ", "#33FF00   ", "#33CCFF", "#33CCCC", "#33CC99", "#33CC66", "#33CC33", "#33CC00", "#3399FF", "#3399CC", "#339999", "#339966   ", "#339933   ", "#339900   ", "#3366FF   ", "#3366CC",
            "#336699", "#336666", "#336633", "#336600", "#3333FF", "#3333CC", "#333399", "#333366", "#333333   ", "#333300   ", "#3300FF   ", "#3300CC   ", "#330099", "#330066", "#330033", "#330000",
            "#99FFFF", "#99FFCC", "#99FF99", "#99FF66", "#99FF33", "#99FF00   ", "#99CCFF   ", "#99CCCC   ", "#99CC99   ", "#99CC66", "#99CC33", "#99CC00", "#9999FF", "#9999CC", "#999999", "#999966",
            "#999933", "#999900", "#9966FF   ", "#9966CC   ", "#996699   ", "#996666   ", "#996633", "#996600", "#9933FF", "#9933CC", "#993399", "#993366", "#993333", "#993300", "#9900FF", "#9900CC   ",
            "#990099   ", "#990066   ", "#990033   ", "#990000", "#00FFFF", "#00FFCC", "#00FF99", "#00FF66", "#00FF33", "#00FF00", "#00CCFF", "#00CCCC", "#00CC99   ", "#00CC66   ", "#00CC33   ", "#00CC00",
            "#0099FF", "#0099CC", "#009999", "#009966", "#009933", "#009900", "#0066FF", "#0066CC", "#006699   ", "#006666   ", "#006633   ", "#006600   ", "#0033FF", "#0033CC", "#003399", "#003366",
            "#003333", "#003300", "#0000FF", "#0000CC", "#000099", "#000066   ", "#000033   ", "#000000 "
        };
        private IContainer components;
        private Control ctl;
        private bool notClose;
        private PictureBox pictureBox;
        private Rectangle preRect;
        private int rectIndex = -1;
        public IColor SelectColor;

        public event ColorSelecthandler OnColorSelect;

        public FrmColorSelector()
        {
            this.InitializeComponent();
            this.allRec = new Rectangle[colorList.Length + 2];
        }

        protected override void Dispose(bool disposing)
        {
            AOUninitialize.Shutdown();
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmColorSelector_Deactivate(object sender, EventArgs e)
        {
            if (!this.notClose)
            {
                base.Close();
                base.Dispose();
            }
            else
            {
                base.Hide();
            }
        }

        private void InitializeComponent()
        {
            this.pictureBox = new PictureBox();
            this.colorDialog = new ColorDialog();
            ((ISupportInitialize) this.pictureBox).BeginInit();
            base.SuspendLayout();
            this.pictureBox.Dock = DockStyle.Fill;
            this.pictureBox.Location = new Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new Size(210, 0x17a);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseUp += new MouseEventHandler(this.pictureBox_MouseUp);
            this.pictureBox.MouseMove += new MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.Paint += new PaintEventHandler(this.pictureBox_Paint);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(210, 0x17a);
            base.Controls.Add(this.pictureBox);
//            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "FrmColorSelector";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.Manual;
            this.Text = "FrmColorSelector";
            base.Deactivate += new EventHandler(this.FrmColorSelector_Deactivate);
            ((ISupportInitialize) this.pictureBox).EndInit();
            base.ResumeLayout(false);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePosition = Control.MousePosition;
            if (((mousePosition.X <= base.Right) && (mousePosition.X >= base.Left)) && ((mousePosition.Y <= base.Bottom) && (mousePosition.Y >= base.Top)))
            {
                using (Graphics graphics = this.pictureBox.CreateGraphics())
                {
                    Point pt = new Point(e.X, e.Y);
                    if ((this.rectIndex != -1) && !this.preRect.Contains(pt))
                    {
                        SolidBrush brush = null;
                        if (this.rectIndex == (this.allRec.Length - 1))
                        {
                            graphics.DrawRectangle(new Pen(SystemColors.Control), this.preRect);
                        }
                        else if (this.rectIndex == (this.allRec.Length - 2))
                        {
                            graphics.DrawRectangle(new Pen(Color.Black), this.preRect);
                        }
                        else
                        {
                            brush = new SolidBrush(ColorTranslator.FromHtml(colorList[this.rectIndex].ToString()));
                            graphics.FillRectangle(brush, this.preRect);
                        }
                    }
                    int index = 0;
                    while (index < this.allRec.Length)
                    {
                        if (this.allRec[index].Contains(pt))
                        {
                            goto Label_0134;
                        }
                        index++;
                    }
                    return;
                Label_0134:
                    this.preRect = this.allRec[index];
                    this.rectIndex = index;
                    this.pictureBox.Cursor = Cursors.Arrow;
                    graphics.DrawRectangle(new Pen(Color.FromArgb(0xac, 0xa8, 0x99)), this.allRec[index]);
                }
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Point mousePosition = Control.MousePosition;
            if (((mousePosition.X <= base.Right) && (mousePosition.X >= base.Left)) && ((mousePosition.Y <= base.Bottom) && (mousePosition.Y >= base.Top)))
            {
                Point pt = new Point(e.X, e.Y);
                Rectangle rectangle = this.pictureBox.RectangleToScreen(new Rectangle(0, 0, this.pictureBox.Width, this.pictureBox.Height));
                if (((mousePosition.X <= rectangle.Right) && (mousePosition.X >= rectangle.X)) && ((mousePosition.Y <= rectangle.Bottom) && (mousePosition.Y >= rectangle.Y)))
                {
                    if (this.Cursor == Cursors.Arrow)
                    {
                        for (int i = 0; i < this.allRec.Length; i++)
                        {
                            if (this.allRec[i].Contains(pt))
                            {
                                if (i >= colorList.Length)
                                {
                                    if (i == (this.allRec.Length - 1))
                                    {
                                        this.notClose = true;
                                        if ((this.colorDialog.ShowDialog() == DialogResult.OK) && (this.SelectColor != null))
                                        {
                                            ColorService.NetColorToEsriColor(this.colorDialog.Color, this.SelectColor);
                                        }
                                    }
                                    else
                                    {
                                        this.SelectColor.NullColor = true;
                                    }
                                }
                                else if (this.SelectColor != null)
                                {
                                    this.SelectColor.NullColor = false;
                                    ColorService.NetColorToEsriColor(ColorTranslator.FromHtml(colorList[i]), this.SelectColor);
                                }
                                break;
                            }
                        }
                    }
                    this.OnColorSelect(this.SelectColor);
                    base.Close();
                }
            }
            this.ctl.Parent.Focus();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            int x = 5;
            int y = 10;
            int num3 = 1;
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                int width = 200;
                int height = 20;
                Rectangle rectangle = new Rectangle(x, y, 200, 20);
                e.Graphics.DrawRectangle(new Pen(Color.Black), x, y, 200, 20);
                Point point = new Point(x + 90, y + 4);
                Font font = new Font("Arial", 8f);
                e.Graphics.DrawString("无色", font, brush, (PointF) point);
                y += 20 + 8;
                for (int i = 0; i < colorList.Length; i++)
                {
                    if (num3 < 12)
                    {
                        SolidBrush brush2 = new SolidBrush(ColorTranslator.FromHtml(colorList[i].ToString()));
                        e.Graphics.DrawRectangle(new Pen(Color.FromArgb(0xac, 0xa8, 0x99)), x, y, 12, 12);
                        e.Graphics.FillRectangle(brush2, x, y, 12, 12);
                        Rectangle rectangle2 = new Rectangle(x, y, 12, 12);
                        num3 = i + 1;
                        this.allRec.SetValue(rectangle2, i);
                        x += 0x11;
                    }
                    else
                    {
                        if ((num3 % 12) == 0)
                        {
                            x = 5;
                            y += 0x11;
                        }
                        SolidBrush brush3 = new SolidBrush(ColorTranslator.FromHtml(colorList[i].ToString()));
                        e.Graphics.FillRectangle(brush3, x, y, 12, 12);
                        Rectangle rectangle3 = new Rectangle(x, y, 12, 12);
                        num3 = i + 1;
                        this.allRec.SetValue(rectangle3, i);
                        x += 0x11;
                    }
                }
                x = 5;
                int num7 = 5 + width;
                y += 0x11;
                Point point2 = new Point(5, y);
                Point point3 = new Point(num7, y);
                e.Graphics.DrawLine(new Pen(Color.Black), point2, point3);
                y += 8;
                Point point4 = new Point(5 + 70, y + 4);
                e.Graphics.DrawString("更多颜色...", font, brush, (PointF) point4);
                Rectangle rectangle4 = new Rectangle(5, y, width, height);
                this.allRec.SetValue(rectangle, colorList.Length);
                this.allRec.SetValue(rectangle4, (int) (colorList.Length + 1));
            }
        }

        public virtual void Show(Control Ctl)
        {
            this.ctl = Ctl;
            Rectangle rectangle = Ctl.RectangleToScreen(new Rectangle(0, 0, Ctl.Width, Ctl.Height));
            Ctl.Parent.RectangleToScreen(new Rectangle(0, 0, Ctl.Parent.Width, Ctl.Parent.Height));
            base.Left = rectangle.Left;
            base.Top = rectangle.Top + Ctl.Height;
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            if ((base.Left + base.Width) > workingArea.Width)
            {
                base.Left = workingArea.Width - base.Width;
            }
            if ((base.Top + base.Height) > workingArea.Height)
            {
                base.Top = rectangle.Top - base.Height;
            }
            if (base.Top < workingArea.Top)
            {
                base.Top = rectangle.Top + Ctl.Height;
            }
            if (base.Left < workingArea.Left)
            {
                base.Left = workingArea.Left;
            }
            base.Show();
        }

        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == 0x1c) && (m.WParam == IntPtr.Zero))
            {
                base.Hide();
            }
            base.WndProc(ref m);
        }

        public delegate void ColorSelecthandler(IColor pColor);
    }
}

