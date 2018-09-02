namespace VgsTiledMap.Ags
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class FormPreCache : Form
    {
        private int _MaxZoom;
        private int _NowZoom;
  
        private Button btnFolder;
        private Button ButtonCancel;
        private Button ButtonStart;
        private IContainer components;
        private FolderBrowserDialog folderDialog;
        private Label label1 = new Label();
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private CheckedListBox lstZoomList;
        private TextBox TextBoxPreCacheAreaName;
        private TextBox txtMapType;
        private TextBox txtSavedFolder;

        public FormPreCache(int iNowZoom, int iMaxZoom)
        {
            this.InitializeComponent();
            this._NowZoom = iNowZoom;
            this._MaxZoom = iMaxZoom;
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            this.folderDialog.ShowNewFolderButton = true;
            if (this.txtSavedFolder.Text.Length > 0)
            {
                this.folderDialog.SelectedPath = this.txtSavedFolder.Text;
            }
            if (this.folderDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.txtSavedFolder.Text = this.folderDialog.SelectedPath;
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            this.preCacheAreaName = this.TextBoxPreCacheAreaName.Text.Trim();
            if (string.IsNullOrEmpty(this.preCacheAreaName))
            {
                MessageBox.Show("Please enter a valid name (will be used to create a folder).");
            }
            else if (!this.CheckName(this.preCacheAreaName))
            {
                MessageBox.Show("Please enter a valid name (will be used to create a folder).\nOnly alfa-numeric characters, a space and a underscore are allowed. The name cannot start with a number or a space.");
            }
            else
            {
                base.DialogResult = DialogResult.OK;
            }
        }

        private bool CheckName(string name)
        {
            string str = "abcdefghijklmnopqrstuvwxyz0123456789_ ";
            for (int i = 0; i < name.Length; i++)
            {
                bool flag = false;
                for (int j = 0; j < str.Length; j++)
                {
                    char ch = name[i];
                    char ch2 = str[j];
                    if (flag = ch.ToString().ToLower().Equals(ch2.ToString()))
                    {
                        break;
                    }
                }
                if (!flag)
                {
                    return false;
                }
            }
            char ch3 = name[0];
            if (!ch3.Equals('0'))
            {
                char ch4 = name[0];
                if (!ch4.Equals('1'))
                {
                    char ch5 = name[0];
                    if (!ch5.Equals('2'))
                    {
                        char ch6 = name[0];
                        if (!ch6.Equals('3'))
                        {
                            char ch7 = name[0];
                            if (!ch7.Equals('4'))
                            {
                                char ch8 = name[0];
                                if (!ch8.Equals('5'))
                                {
                                    char ch9 = name[0];
                                    if (!ch9.Equals('6'))
                                    {
                                        char ch10 = name[0];
                                        if (!ch10.Equals('7'))
                                        {
                                            char ch11 = name[0];
                                            if (!ch11.Equals('8'))
                                            {
                                                char ch12 = name[0];
                                                if (!ch12.Equals('9'))
                                                {
                                                    char ch13 = name[0];
                                                    if (!ch13.Equals(' '))
                                                    {
                                                        return true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FormPreCache_Load(object sender, EventArgs e)
        {
            this.lstZoomList.Items.Clear();
            for (int i = this._NowZoom; i <= this._MaxZoom; i++)
            {
                this.lstZoomList.Items.Add(i.ToString());
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.TextBoxPreCacheAreaName = new TextBox();
            this.ButtonStart = new Button();
            this.ButtonCancel = new Button();
            this.label2 = new Label();
            this.txtMapType = new TextBox();
            this.label3 = new Label();
            this.label4 = new Label();
            this.txtSavedFolder = new TextBox();
            this.btnFolder = new Button();
            this.label5 = new Label();
            this.folderDialog = new FolderBrowserDialog();
            this.label6 = new Label();
            this.lstZoomList = new CheckedListBox();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xad, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter name of PreCache area:";
            this.TextBoxPreCacheAreaName.Location = new Point(15, 0x17);
            this.TextBoxPreCacheAreaName.Name = "TextBoxPreCacheAreaName";
            this.TextBoxPreCacheAreaName.Size = new Size(0x166, 0x15);
            this.TextBoxPreCacheAreaName.TabIndex = 1;
            this.ButtonStart.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            this.ButtonStart.Location = new Point(0x6d, 0xf1);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new Size(0x4b, 0x15);
            this.ButtonStart.TabIndex = 3;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new EventHandler(this.ButtonStart_Click);
            this.ButtonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            this.ButtonCancel.Location = new Point(190, 0xf1);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new Size(0x4b, 0x15);
            this.ButtonCancel.TabIndex = 4;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new EventHandler(this.ButtonCancel_Click);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(13, 0x40);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "地图类型：";
            this.txtMapType.Location = new Point(0x54, 0x3d);
            this.txtMapType.Name = "txtMapType";
            this.txtMapType.ReadOnly = true;
            this.txtMapType.Size = new Size(0x52, 0x15);
            this.txtMapType.TabIndex = 1;
            this.label3.AutoSize = true;
            this.label3.Font = new Font("SimSun", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label3.ForeColor = Color.Red;
            this.label3.Location = new Point(0xb0, 0x40);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0xc5, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "请将需要下载的类型拖到图层最上方";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "存放路径：";
            this.txtSavedFolder.Location = new Point(0x53, 0x61);
            this.txtSavedFolder.Name = "txtSavedFolder";
            this.txtSavedFolder.ReadOnly = true;
            this.txtSavedFolder.Size = new Size(0x7a, 0x15);
            this.txtSavedFolder.TabIndex = 1;
            this.btnFolder.Location = new Point(0xd3, 0x61);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new Size(0x2b, 0x17);
            this.btnFolder.TabIndex = 5;
            this.btnFolder.Text = "浏览";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new EventHandler(this.btnFolder_Click);
            this.label5.AutoSize = true;
            this.label5.Font = new Font("SimSun", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label5.ForeColor = Color.Red;
            this.label5.Location = new Point(260, 0x66);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x71, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "请确认剩余空间足够";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(12, 0x8f);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "下载级别：";
            this.lstZoomList.FormattingEnabled = true;
            this.lstZoomList.Location = new Point(0x53, 0x8f);
            this.lstZoomList.Name = "lstZoomList";
            this.lstZoomList.Size = new Size(290, 0x44);
            this.lstZoomList.TabIndex = 7;
            base.ClientSize = new Size(0x181, 0x112);
            base.Controls.Add(this.lstZoomList);
            base.Controls.Add(this.btnFolder);
            base.Controls.Add(this.ButtonCancel);
            base.Controls.Add(this.ButtonStart);
            base.Controls.Add(this.txtSavedFolder);
            base.Controls.Add(this.txtMapType);
            base.Controls.Add(this.TextBoxPreCacheAreaName);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "FormPreCache";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "地图下载";
            base.Load += new EventHandler(this.FormPreCache_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public string preCacheAreaName
        {
            get;
            set;
        }

        public int[] preCacheLevels
        {
            get;
            set;
        }
    }
}

