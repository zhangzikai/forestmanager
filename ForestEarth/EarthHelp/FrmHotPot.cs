namespace ForestEarth.EarthHelp
{
    using EviaEarthLib;
    using ForestEarth;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml;

    public class FrmHotPot : Form
    {
        private IContainer components;
        private ContextMenuStrip contextMenuStrip1;
        private ImageList imageList1;
        private ListView listView1;
        private List<CameraInfo> m_ci;
        private IEviaEarthControl m_control;
        private ToolStripMenuItem menu_add;
        private ToolStripMenuItem menu_delete;

        public FrmHotPot(IEviaEarthControl pEviaEarthControl)
        {
            this.InitializeComponent();
            this.m_control = pEviaEarthControl;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmHotPot_Load(object sender, EventArgs e)
        {
            this.m_ci = new List<CameraInfo>();
            this.ReadNavigateConfig();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.listView1 = new ListView();
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.menu_add = new ToolStripMenuItem();
            this.menu_delete = new ToolStripMenuItem();
            this.imageList1 = new ImageList(this.components);
            this.contextMenuStrip1.SuspendLayout();
            base.SuspendLayout();
            this.listView1.Dock = DockStyle.Fill;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new Size(0x11c, 0x106);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseDoubleClick += new MouseEventHandler(this.listView1_MouseDoubleClick);
            this.listView1.DrawItem += new DrawListViewItemEventHandler(this.listView1_DrawItem);
            this.listView1.MouseDown += new MouseEventHandler(this.listView1_MouseDown);
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[] { this.menu_add, this.menu_delete });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(0x7d, 0x30);
            this.menu_add.Name = "menu_add";
            this.menu_add.Size = new Size(0x7c, 0x16);
            this.menu_add.Text = "添加热点";
            this.menu_add.Click += new EventHandler(this.menu_add_Click);
            this.menu_delete.Name = "menu_delete";
            this.menu_delete.Size = new Size(0x7c, 0x16);
            this.menu_delete.Text = "删除热点";
            this.menu_delete.Click += new EventHandler(this.menu_delete_Click);
            this.imageList1.ColorDepth = ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new Size(90, 80);
            this.imageList1.TransparentColor = Color.Transparent;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x11c, 0x106);
            base.Controls.Add(this.listView1);
            base.Name = "FrmHotPot";
            this.Text = "FrmHotPot";
            base.Load += new EventHandler(this.FrmHotPot_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (((e.State & ListViewItemStates.Selected) == ListViewItemStates.Selected) || ((e.State & ListViewItemStates.Focused) == ListViewItemStates.Focused))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Silver), e.Bounds);
            }
            Rectangle rect = new Rectangle(e.Bounds.X + 5, e.Bounds.Y + 5, e.Bounds.Width - 10, e.Bounds.Height - 10);
            if (e.Item.ImageIndex > -1)
            {
                e.Graphics.DrawImage(e.Item.ListView.LargeImageList.Images[e.Item.ImageIndex], rect);
            }
            Rectangle layoutRectangle = new Rectangle(e.Bounds.X, (e.Bounds.Y + e.Bounds.Height) + 1, e.Bounds.Width, 20);
            StringFormat format = new StringFormat();
            format.FormatFlags = StringFormatFlags.LineLimit;
            format.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(e.Item.Text, e.Item.ListView.Font, new SolidBrush(Color.Black), layoutRectangle, format);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                int index = this.listView1.SelectedItems[0].Index;
                if ((index >= 0) && (index < this.m_ci.Count))
                {
                    this.m_control.CameraControl.FlyTo(this.m_ci[index].m_lon, this.m_ci[index].m_lat, this.m_ci[index].m_alt, this.m_ci[index].m_tilt, this.m_ci[index].m_heading, 5.0);
                }
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.menu_delete.Visible = this.listView1.SelectedItems.Count > 0;
                Point p = new Point(e.X, e.Y);
                p = this.listView1.PointToScreen(p);
                this.contextMenuStrip1.Show(p);
            }
        }

        private void menu_add_Click(object sender, EventArgs e)
        {
            FrmName name = new FrmName();
            name.ShowDialog();
            name.Dispose();
            if (!string.IsNullOrEmpty(name.GetName()))
            {
                CameraInfo info = new CameraInfo();
                info.m_lon = this.m_control.CameraControl.GetLongitude();
                info.m_lat = this.m_control.CameraControl.GetLatitude();
                info.m_alt = this.m_control.CameraControl.GetAltitude();
                info.m_heading = this.m_control.CameraControl.GetHeading();
                info.m_tilt = this.m_control.CameraControl.GetTilt();
                ListViewItem item = this.listView1.Items.Add(name.GetName());
                this.m_ci.Add(info);
                string path = AppDomain.CurrentDomain.BaseDirectory + @"EarthData\HotImages";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string saveFileName = path + @"\" + name.GetName() + ".bmp";
                this.m_control.Scene.OutputGraphic(0, 0, saveFileName);
                if (File.Exists(saveFileName))
                {
                    string savePath = AppDomain.CurrentDomain.BaseDirectory + @"EarthData\HotImages\" + name.GetName() + ".jpg";
                    StreamReader postedFile = new StreamReader(saveFileName);
                    PTImage.ZoomAuto(postedFile, savePath, 90.0, 80.0, "", "");
                    postedFile.Dispose();
                    Image image = Image.FromFile(savePath);
                    this.imageList1.Images.Add(image);
                    item.ImageIndex = this.imageList1.Images.Count - 1;
                    image.Dispose();
                }
                this.SaveNavigateConfig();
            }
        }

        private void menu_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.listView1.SelectedItems.Count >= 1) && (MessageBox.Show("确定要删除该热点吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    for (int i = this.listView1.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        int index = this.listView1.SelectedItems[i].Index;
                        string text = this.listView1.SelectedItems[i].Text;
                        this.listView1.Items.RemoveAt(index);
                        this.imageList1.Images.RemoveAt(index);
                        this.m_ci.RemoveAt(index);
                        string path = AppDomain.CurrentDomain.BaseDirectory + @"EarthData\HotImages\" + text + ".jpg";
                        string str3 = AppDomain.CurrentDomain.BaseDirectory + @"EarthData\HotImages\" + text + ".bmp";
                        if (File.Exists(str3))
                        {
                            File.Delete(str3);
                        }
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                    }
                    this.SaveNavigateConfig();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("删除热点出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void ReadNavigateConfig()
        {
            this.listView1.Items.Clear();
            this.imageList1.Images.Clear();
            string str = AppDomain.CurrentDomain.BaseDirectory + "EarthData";
            string filename = str + @"\hotpot.xml";
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(filename);
                XmlNode node = document.SelectSingleNode("EviaSysInfo");
                if (node != null)
                {
                    XmlNodeList list = node.SelectNodes("EyeInfo");
                    for (int i = 0; i < list.Count; i++)
                    {
                        XmlNode node2 = list[i];
                        XmlNode node3 = node2.SelectSingleNode("Name");
                        ListViewItem item = this.listView1.Items.Add(node3.InnerText);
                        string path = str + @"\HotImages\" + node3.InnerText + ".jpg";
                        if (File.Exists(path))
                        {
                            Image image = Image.FromFile(path);
                            this.imageList1.Images.Add(image);
                            item.ImageIndex = this.imageList1.Images.Count - 1;
                            image.Dispose();
                        }
                        CameraInfo info = new CameraInfo();
                        node3 = node2.SelectSingleNode("Longitude");
                        info.m_lon = Convert.ToDouble(node3.InnerText);
                        node3 = node2.SelectSingleNode("Latitude");
                        info.m_lat = Convert.ToDouble(node3.InnerText);
                        node3 = node2.SelectSingleNode("Elevation");
                        info.m_alt = Convert.ToDouble(node3.InnerText);
                        node3 = node2.SelectSingleNode("Tilt");
                        info.m_tilt = Convert.ToDouble(node3.InnerText);
                        node3 = node2.SelectSingleNode("Heading");
                        info.m_heading = Convert.ToDouble(node3.InnerText);
                        this.m_ci.Add(info);
                    }
                }
            }
            catch
            {
            }
        }

        private void SaveNavigateConfig()
        {
            string filename = AppDomain.CurrentDomain.BaseDirectory + "EarthData" + @"\hotpot.xml";
            XmlDocument document = new XmlDocument();
            try
            {
                document.LoadXml("<?xml version=\"1.0\" encoding=\"GBK\" ?><EviaSysInfo></EviaSysInfo>");
                XmlNode node = document.SelectSingleNode("EviaSysInfo");
                if (node != null)
                {
                    for (int i = 0; i < this.listView1.Items.Count; i++)
                    {
                        XmlNode newChild = document.CreateElement("EyeInfo");
                        node.AppendChild(newChild);
                        XmlNode node3 = document.CreateElement("Name");
                        node3.InnerText = this.listView1.Items[i].Text;
                        newChild.AppendChild(node3);
                        node3 = document.CreateElement("Longitude");
                        node3.InnerText = this.m_ci[i].m_lon.ToString();
                        newChild.AppendChild(node3);
                        node3 = document.CreateElement("Latitude");
                        node3.InnerText = this.m_ci[i].m_lat.ToString();
                        newChild.AppendChild(node3);
                        node3 = document.CreateElement("Elevation");
                        node3.InnerText = this.m_ci[i].m_alt.ToString();
                        newChild.AppendChild(node3);
                        node3 = document.CreateElement("Tilt");
                        node3.InnerText = this.m_ci[i].m_tilt.ToString();
                        newChild.AppendChild(node3);
                        node3 = document.CreateElement("Heading");
                        node3.InnerText = this.m_ci[i].m_heading.ToString();
                        newChild.AppendChild(node3);
                    }
                    document.Save(filename);
                }
            }
            catch
            {
            }
        }
    }
}

