namespace VgsTiledMap.Ags.VgsTile.Forms
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Framework;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using VgsTiledMap.Ags;
    using VgsTiledMap.Ags.VgsTile.Configs;

    public class AddLindiServiceForm : Form
    {

        private System.Windows.Forms.Button cancel_bnt;
        private IContainer components;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox lyr_alias;
        private TextBox lyr_name;
        private NumericUpDown lyr_year;
        private System.Windows.Forms.Button ok_bnt;

        public AddLindiServiceForm()
        {
            this.InitializeComponent();
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
            this.ok_bnt = new System.Windows.Forms.Button();
            this.cancel_bnt = new System.Windows.Forms.Button();
            this.groupBox1 = new GroupBox();
            this.lyr_year = new NumericUpDown();
            this.lyr_name = new TextBox();
            this.lyr_alias = new TextBox();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.groupBox1.SuspendLayout();
            this.lyr_year.BeginInit();
            base.SuspendLayout();
//            this.ok_bnt.DialogResult = DialogResult.OK;
            this.ok_bnt.Location = new Point(0x62, 0xc2);
            this.ok_bnt.Name = "ok_bnt";
            this.ok_bnt.Size = new Size(0x4b, 0x17);
            this.ok_bnt.TabIndex = 0;
            this.ok_bnt.Text = "确定";
            this.ok_bnt.UseVisualStyleBackColor = true;
            this.ok_bnt.Click += new EventHandler(this.ok_bnt_Click);
//            this.cancel_bnt.DialogResult = DialogResult.Cancel;
            this.cancel_bnt.Location = new Point(0xe3, 0xc2);
            this.cancel_bnt.Name = "cancel_bnt";
            this.cancel_bnt.Size = new Size(0x4b, 0x17);
            this.cancel_bnt.TabIndex = 0;
            this.cancel_bnt.Text = "取消";
            this.cancel_bnt.UseVisualStyleBackColor = true;
            this.groupBox1.Controls.Add(this.lyr_year);
            this.groupBox1.Controls.Add(this.lyr_name);
            this.groupBox1.Controls.Add(this.lyr_alias);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x16b, 0xa2);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "一张图调用参数";
            this.lyr_year.Location = new Point(0x6c, 0x53);
            int[] bits = new int[4];
            bits[0] = 0x270f;
            this.lyr_year.Maximum = new decimal(bits);
            this.lyr_year.Name = "lyr_year";
            this.lyr_year.Size = new Size(210, 0x15);
            this.lyr_year.TabIndex = 2;
            this.lyr_name.Location = new Point(0x6c, 0x11);
            this.lyr_name.Name = "lyr_name";
            this.lyr_name.Size = new Size(210, 0x15);
            this.lyr_name.TabIndex = 1;
            this.lyr_alias.Location = new Point(0x6c, 0x31);
            this.lyr_alias.Name = "lyr_alias";
            this.lyr_alias.Size = new Size(210, 0x15);
            this.lyr_alias.TabIndex = 1;
            this.label3.AutoSize = true;
            this.label3.ForeColor = Color.Red;
            this.label3.Location = new Point(15, 0x76);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x13d, 0x24);
            this.label3.TabIndex = 0;
            this.label3.Text = "调用林地一张图数据服务时，如果只指定图层名则系统\r\n将按单一图层模式加载数据如果需要按专题模式则指定年度\r\n默认年度值为0时认为没有设置年度信息\r\n";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x29, 0x18);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "名称：";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x29, 0x58);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "年度：";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x29, 0x38);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "别名：";
            base.AcceptButton = this.ok_bnt;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.cancel_bnt;
            base.ClientSize = new Size(0x183, 0xe3);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.cancel_bnt);
            base.Controls.Add(this.ok_bnt);
//            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "AddLindiServiceForm";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "添加林地一张图服务";
            base.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.lyr_year.EndInit();
            base.ResumeLayout(false);
        }

        private void ok_bnt_Click(object sender, EventArgs e)
        {
            if ((this.ArcApplication == null) || (this.ArcMap == null))
            {
                MessageBox.Show("地图参数或程序窗口为空!");
            }
            else
            {
                string text = this.lyr_alias.Text;
                string str2 = this.lyr_name.Text;
                if (string.IsNullOrEmpty(str2))
                {
                    MessageBox.Show("请设置需要添加的图层名称!");
                }
                else
                {
                    if (string.IsNullOrEmpty(text))
                    {
                        text = str2;
                    }
                    int num = (int) this.lyr_year.Value;
                    string lyrYear = string.Empty;
                    if (num >= 0x7d9)
                    {
                        lyrYear = num.ToString();
                    }
                    else if (num == 0)
                    {
                        if (this.LayerType == EnumArcVgsTileLayer.EviaTiledSatellite)
                        {
                            lyrYear = "0000";
                        }
                        else
                        {
                            lyrYear = string.Empty;
                        }
                    }
                    IConfig config = null;
                    switch (this.LayerType)
                    {
                        case EnumArcVgsTileLayer.VgsTiled:
                            config = new ConfigLindi(string.Empty, str2, lyrYear, "png");
                            break;

                        case EnumArcVgsTileLayer.VgsSatellite:
                        case EnumArcVgsTileLayer.EviaTiledSatellite:
                            config = new ConfigLindi(string.Empty, str2, lyrYear, "etd");
                            break;

                        default:
                            config = new ConfigLindi(string.Empty, str2, lyrYear, "png");
                            break;
                    }
                    if (config != null)
                    {
                        VgsArcTileLayer layer2 = new VgsArcTileLayer(this.ArcApplication, config);
                        layer2.Name = text;
                        layer2.Visible = true;
                        VgsArcTileLayer layer = layer2;
                        this.ArcMap.AddLayer(layer);
                        VgsTiledMap.Ags.Util.SetVgsTiledMapPropertyPage(this.ArcApplication, layer);
                        base.Close();
                    }
                }
            }
        }

        public IApplication ArcApplication
        {
            get;
            set;
        }

        public IMap ArcMap
        {
            get;
            set;
        }

        [DefaultValue(20)]
        public EnumArcVgsTileLayer LayerType
        {
            get;
            set;
        }
    }
}

