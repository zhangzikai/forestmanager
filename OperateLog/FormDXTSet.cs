namespace OperateLog
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Utilities;

    public class FormDXTSet : FormBase2
    {
        private ButtonEdit buttonEdit1;
        private CheckEdit checkEditAll;
        private IContainer components;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private Label labelText;
        private string m_Path = "";
        private Panel panel1;
        private RadioGroup radioGroup1;
        private SimpleButton simpleButton1;

        public FormDXTSet()
        {
            this.InitializeComponent();
        }

        private void buttonEdit1_Click(object sender, EventArgs e)
        {
            if (this.m_Path == "")
            {
                this.m_Path = "C:";
            }
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = this.m_Path;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.m_Path = dialog.SelectedPath;
                this.buttonEdit1.Text = this.m_Path;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FormDXTSet_Load(object sender, EventArgs e)
        {
            this.labelText.Text = "说明：支持的文件格式包括IMG,BMP,GIF,TIF,TIFF,PNG,JPG,JPEG。\n默认加载当前视图范围内的地形图，如想一次加载所有地形图，请选中【加载路径下的所有地形图】";
            string str = UtilFactory.GetConfigOpt().GetConfigValue2("DXT", "DXTPath");
            this.m_Path = str;
            this.buttonEdit1.Text = str;
            if (UtilFactory.GetConfigOpt().GetConfigValue2("DXT", "DXTType") == "1")
            {
                this.checkEditAll.Checked = true;
            }
            else
            {
                this.checkEditAll.Checked = false;
            }
        }

        private void InitializeComponent()
        {
            this.panel1 = new Panel();
            this.labelText = new Label();
            this.checkEditAll = new CheckEdit();
            this.radioGroup1 = new RadioGroup();
            this.simpleButton1 = new SimpleButton();
            this.buttonEdit1 = new ButtonEdit();
            this.labelControl2 = new LabelControl();
            this.labelControl1 = new LabelControl();
            this.panel1.SuspendLayout();
            this.checkEditAll.Properties.BeginInit();
            this.radioGroup1.Properties.BeginInit();
            this.buttonEdit1.Properties.BeginInit();
            base.SuspendLayout();
            this.panel1.Controls.Add(this.labelText);
            this.panel1.Controls.Add(this.checkEditAll);
            this.panel1.Controls.Add(this.radioGroup1);
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Controls.Add(this.buttonEdit1);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x14b, 0x100);
            this.panel1.TabIndex = 1;
            this.labelText.Location = new Point(12, 0x41);
            this.labelText.Name = "labelText";
            this.labelText.Size = new Size(0x133, 0x42);
            this.labelText.TabIndex = 7;
            this.checkEditAll.Location = new Point(0x1d, 0x86);
            this.checkEditAll.Name = "checkEditAll";
            this.checkEditAll.Properties.Caption = "加载路径下的所有地形图";
            this.checkEditAll.Size = new Size(0xa4, 0x13);
            this.checkEditAll.TabIndex = 6;
            this.radioGroup1.Location = new Point(0x89, 0x9f);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem("旧图幅号", "旧图幅号"), new RadioGroupItem("新图幅号", "新图幅号") });
            this.radioGroup1.Size = new Size(0xb6, 30);
            this.radioGroup1.TabIndex = 5;
            this.radioGroup1.Visible = false;
            this.simpleButton1.Location = new Point(0xcb, 0xd4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x4b, 0x17);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.buttonEdit1.Location = new Point(0x72, 0x15);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.buttonEdit1.Size = new Size(0xcd, 0x15);
            this.buttonEdit1.TabIndex = 2;
            this.buttonEdit1.Click += new EventHandler(this.buttonEdit1_Click);
            this.labelControl2.Location = new Point(11, 0xa6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(120, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "地形图文件命名方式：";
            this.labelControl2.Visible = false;
            this.labelControl1.Location = new Point(12, 0x18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "地形图存放路径：";
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x14b, 0x100);
            base.Controls.Add(this.panel1);
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormDXTSet";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "地形图加载设置";
            base.Load += new EventHandler(this.FormDXTSet_Load);
            base.Controls.SetChildIndex(this.panel1, 0);
            base.Controls.SetChildIndex(base.sButOk, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.checkEditAll.Properties.EndInit();
            this.radioGroup1.Properties.EndInit();
            this.buttonEdit1.Properties.EndInit();
            base.ResumeLayout(false);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.m_Path == "")
                {
                    MessageBox.Show("请选择文件存放路径！", "地形图加载设置");
                }
                else
                {
                    DirectoryInfo info = new DirectoryInfo(this.m_Path);
                    if (!info.Exists)
                    {
                        MessageBox.Show("地形图存放路径不存在！", "地形图加载设置");
                    }
                    else
                    {
                        UtilFactory.GetConfigOpt().SetConfigValue2("DXT", "DXTPath", this.m_Path);
                        string str = "";
                        if (this.checkEditAll.Checked)
                        {
                            str = "1";
                        }
                        else
                        {
                            str = "0";
                        }
                        UtilFactory.GetConfigOpt().SetConfigValue2("DXT", "DXTType", str);
                        base.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch
            {
                MessageBox.Show("修改地形图加载设置出错！", "地形图加载设置");
            }
        }
    }
}

