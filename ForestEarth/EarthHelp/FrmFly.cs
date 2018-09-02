namespace ForestEarth.EarthHelp
{
    using DevComponents.DotNetBar;
    using DevExpress.XtraEditors;
    using EvEarthDriverLib;
    using EviaEarthCommonLib;
    using EviaEarthLib;
    using ForestEarth;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml;

    public class FrmFly : Form
    {
        private Bar bar1;
        private ButtonItem btn_add;
        private ButtonItem btn_delete;
        private ButtonItem btn_fly;
        private ButtonItem btn_pause;
        private ButtonItem btn_set;
        private ButtonItem btn_stop;
        private IContainer components;
        private ListBoxControl listBoxControl1;
        private List<CameraInfo> m_ci;
        private IEviaEarthControl m_control;
        private FrmFlySet m_flySetForm;
        private List<PathClass> m_paths;
        private List<S_Vec3Geo> m_points;
        private SplitterControl splitterControl1;
        private Timer timer1;

        public FrmFly(IEviaEarthControl pEviaEarthControl)
        {
            this.InitializeComponent();
            this.m_ci = new List<CameraInfo>();
            this.m_points = new List<S_Vec3Geo>();
            this.m_paths = new List<PathClass>();
            this.m_control = pEviaEarthControl;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            IEvEarthApplication pluginsMgr = this.m_control.PluginsMgr as IEvEarthApplication;
            pluginsMgr.ToolMsg = "YT_AddPath";
            this.m_points.Clear();
            this.btn_add.Checked = true;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.listBoxControl1.SelectedIndex;
            if ((selectedIndex >= 0) && (selectedIndex < this.listBoxControl1.Items.Count))
            {
                this.listBoxControl1.Items.RemoveAt(selectedIndex);
                this.m_paths.RemoveAt(selectedIndex);
                this.SavePathConfig();
            }
        }

        private void btn_fly_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.listBoxControl1.SelectedIndex;
            if ((selectedIndex >= 0) && (selectedIndex < this.m_paths.Count))
            {
                try
                {
                    this.m_control.FlyerControl.FlyPath.AddPathPoints(ref this.m_paths[selectedIndex].Points.ToArray()[0], this.m_paths[selectedIndex].Points.Count);
                    this.m_control.FlyerControl.Start();
                    this.timer1.Enabled = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            this.m_control.FlyerControl.Pause();
        }

        private void btn_set_Click(object sender, EventArgs e)
        {
            if ((this.m_flySetForm == null) || !this.m_flySetForm.Visible)
            {
                this.m_flySetForm = new FrmFlySet(this.m_control);
                this.m_flySetForm.Show(this);
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            this.m_control.FlyerControl.Stop();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmFly_Load(object sender, EventArgs e)
        {
            string str = AppDomain.CurrentDomain.BaseDirectory + @"EarthData\flyPath.xml";
            if (!string.IsNullOrEmpty(str))
            {
                this.m_points.Clear();
                this.listBoxControl1.Items.Clear();
                XmlDocument document = new XmlDocument();
                try
                {
                    document.Load(str);
                    XmlNode node = document.SelectSingleNode("EviaSysInfo");
                    if (node != null)
                    {
                        XmlNodeList list = node.SelectNodes("Path");
                        for (int i = 0; i < list.Count; i++)
                        {
                            XmlNode node2 = list[i];
                            XmlNode node3 = node2.SelectSingleNode("Name");
                            PathClass item = new PathClass();
                            item.Name = node3.InnerText;
                            string innerText = node2.SelectSingleNode("Points").InnerText;
                            S_Vec3Geo geo = new S_Vec3Geo();
                            foreach (string str3 in innerText.Split(new char[] { ';' }))
                            {
                                string[] strArray2 = str3.Split(new char[] { ',' });
                                geo.x = Convert.ToDouble(strArray2[0]);
                                geo.z = Convert.ToDouble(strArray2[1]);
                                geo.y = Convert.ToDouble(strArray2[2]);
                                item.Points.Add(geo);
                            }
                            this.m_paths.Add(item);
                            this.listBoxControl1.Items.Add(item.Name);
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmFly));
            this.bar1 = new Bar();
            this.btn_add = new ButtonItem();
            this.btn_fly = new ButtonItem();
            this.btn_pause = new ButtonItem();
            this.btn_stop = new ButtonItem();
            this.btn_set = new ButtonItem();
            this.btn_delete = new ButtonItem();
            this.splitterControl1 = new SplitterControl();
            this.listBoxControl1 = new ListBoxControl();
            this.timer1 = new Timer(this.components);
            this.bar1.BeginInit();
            ((ISupportInitialize) this.listBoxControl1).BeginInit();
            base.SuspendLayout();
            this.bar1.Dock = DockStyle.Top;
            this.bar1.Items.AddRange(new BaseItem[] { this.btn_add, this.btn_fly, this.btn_pause, this.btn_stop, this.btn_set, this.btn_delete });
            this.bar1.Location = new Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new Size(0xeb, 0x2b);
            this.bar1.Stretch = true;
            this.bar1.Style = eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            this.btn_add.Image = (Image) manager.GetObject("btn_add.Image");
            this.btn_add.ImagePosition = eImagePosition.Top;
            this.btn_add.Name = "btn_add";
            this.btn_add.Text = "添加";
            this.btn_add.Click += new EventHandler(this.btn_add_Click);
            this.btn_fly.Image = (Image) manager.GetObject("btn_fly.Image");
            this.btn_fly.ImagePosition = eImagePosition.Top;
            this.btn_fly.Name = "btn_fly";
            this.btn_fly.Text = "飞行";
            this.btn_fly.Click += new EventHandler(this.btn_fly_Click);
            this.btn_pause.Image = (Image) manager.GetObject("btn_pause.Image");
            this.btn_pause.ImagePosition = eImagePosition.Top;
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Text = "暂定";
            this.btn_pause.Click += new EventHandler(this.btn_pause_Click);
            this.btn_stop.Image = (Image) manager.GetObject("btn_stop.Image");
            this.btn_stop.ImagePosition = eImagePosition.Top;
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Text = "停止";
            this.btn_stop.Click += new EventHandler(this.btn_stop_Click);
            this.btn_set.Image = (Image) manager.GetObject("btn_set.Image");
            this.btn_set.ImagePosition = eImagePosition.Top;
            this.btn_set.Name = "btn_set";
            this.btn_set.Text = "设置";
            this.btn_set.Click += new EventHandler(this.btn_set_Click);
            this.btn_delete.Image = (Image) manager.GetObject("btn_delete.Image");
            this.btn_delete.ImagePosition = eImagePosition.Top;
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Text = "删除";
            this.btn_delete.Click += new EventHandler(this.btn_delete_Click);
            this.splitterControl1.Dock = DockStyle.Top;
            this.splitterControl1.Location = new Point(0, 0x2b);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new Size(0xeb, 5);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            this.listBoxControl1.Dock = DockStyle.Fill;
            this.listBoxControl1.Location = new Point(0, 0x30);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new Size(0xeb, 0xd6);
            this.listBoxControl1.TabIndex = 2;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0xeb, 0x106);
            base.Controls.Add(this.listBoxControl1);
            base.Controls.Add(this.splitterControl1);
            base.Controls.Add(this.bar1);
            base.Name = "FrmFly";
            this.Text = "FrmFly";
            base.Load += new EventHandler(this.FrmFly_Load);
            this.bar1.EndInit();
            ((ISupportInitialize) this.listBoxControl1).EndInit();
            base.ResumeLayout(false);
        }

        public void OnMouseDown(int button, int shift, int x, int y)
        {
            IEvEarthApplication pluginsMgr = this.m_control.PluginsMgr as IEvEarthApplication;
            if (pluginsMgr.ToolMsg.Equals("YT_AddPath"))
            {
                switch (button)
                {
                    case 1:
                    {
                        S_Vec3Geo item = new S_Vec3Geo();
                        pluginsMgr.EvEarthControl.Scene.WinToBL(x, y, out item.x, out item.z, out item.y);
                        this.m_points.Add(item);
                        (pluginsMgr.EvEarthScene as IEvEarthScene).SetTempPolyline(ref this.m_points.ToArray()[0], this.m_points.Count, (uint) Color.Red.ToArgb(), (uint) Color.Red.ToArgb(), true);
                        return;
                    }
                    case 2:
                    {
                        pluginsMgr.ToolMsg = string.Empty;
                        FrmName name = new FrmName();
                        name.ShowDialog();
                        name.Dispose();
                        if (!string.IsNullOrEmpty(name.GetName()))
                        {
                            PathClass class2 = new PathClass();
                            class2.Name = name.GetName();
                            class2.Points = this.m_points;
                            this.listBoxControl1.Items.Add(class2.Name);
                            this.m_paths.Add(class2);
                            if (this.listBoxControl1.Items.Count > 0)
                            {
                                this.listBoxControl1.SelectedIndex = 0;
                            }
                            this.m_points.Clear();
                            IEvEarthScene evEarthScene = pluginsMgr.EvEarthScene as IEvEarthScene;
                            S_Vec3Geo[] geoArray = new S_Vec3Geo[1];
                            try
                            {
                                evEarthScene.SetTempPolyline(ref geoArray[0], 0, (uint) Color.Red.ToArgb(), 0, false);
                            }
                            catch
                            {
                            }
                            this.btn_add.Checked = false;
                            this.SavePathConfig();
                            break;
                        }
                        return;
                    }
                    default:
                        return;
                }
            }
        }

        private void SavePathConfig()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "EarthData";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filename = path + @"\flyPath.xml";
            XmlDocument document = new XmlDocument();
            try
            {
                document.LoadXml("<?xml version=\"1.0\" encoding=\"GBK\" ?><EviaSysInfo></EviaSysInfo>");
                XmlNode node = document.SelectSingleNode("EviaSysInfo");
                if (node != null)
                {
                    for (int i = 0; i < this.m_paths.Count; i++)
                    {
                        XmlNode newChild = document.CreateElement("Path");
                        node.AppendChild(newChild);
                        XmlNode node3 = document.CreateElement("Name");
                        node3.InnerText = this.m_paths[i].Name;
                        newChild.AppendChild(node3);
                        node3 = document.CreateElement("Points");
                        string str3 = "";
                        for (int j = 0; j < this.m_paths[i].Points.Count; j++)
                        {
                            S_Vec3Geo geo = this.m_paths[i].Points[j];
                            string str4 = str3;
                            str3 = str4 + geo.x.ToString() + "," + geo.z.ToString() + "," + geo.y.ToString();
                            if (j < (this.m_paths[i].Points.Count - 1))
                            {
                                str3 = str3 + ";";
                            }
                        }
                        node3.InnerText = str3;
                        newChild.AppendChild(node3);
                    }
                    document.Save(filename);
                }
            }
            catch
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.m_control.FlyerControl.Status)
            {
                case -1:
                    this.btn_pause.Enabled = false;
                    this.btn_fly.Enabled = true;
                    this.btn_stop.Enabled = true;
                    return;

                case 0:
                    this.m_control.FlyerControl.FlyPath.ClearPoint();
                    this.btn_pause.Enabled = false;
                    this.btn_fly.Enabled = true;
                    this.btn_stop.Enabled = false;
                    return;

                case 1:
                    this.btn_pause.Enabled = true;
                    this.btn_fly.Enabled = false;
                    this.btn_stop.Enabled = true;
                    return;
            }
        }
    }
}

