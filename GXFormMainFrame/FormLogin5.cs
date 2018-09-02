namespace GXFormMainFrame
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using FormBase;
    using OperateLog;
    //using OperateLog;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;

    public class FormLogin5 : FormBase2
    {
        public bool CancelFlag = false;
        private int column = 0;
        private IContainer components = null;
        public string EditKind = "小班";
        public ImageList imageList1;
        public ImageList imageList2;
        public ImageList imageList3;
        public Label label1;
        public Label label2;
        public Label label3;
        protected Label LabelLoadInfo;
        protected Label LabelProgressBack;
        protected Label LabelProgressBar;
        public Timer m_Timer = null;
        private Panel panel1;
        private Panel panel2;
        public Panel panelLogin;
        public Panel panelProgress;
        private Panel panelSys;
        private RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private RepositoryItemImageEdit repositoryItemImageEdit2;
        private RepositoryItemImageEdit repositoryItemImageEdit3;
        private RepositoryItemImageEdit repositoryItemImageEdit33;
        private RepositoryItemPictureEdit repositoryItemPictureEdit1;
        public SimpleButton simpleButton1;
        public SimpleButton simpleButton2;
        public SimpleButton simpleButtonCancel;
        public SimpleButton simpleButtonOK;
        public TextEdit textEdit1;
        public TextEdit textEdit2;
        public TreeList tListKind;
        private TreeListColumn treeListColumn1;
        private TreeListColumn treeListColumn2;
        private TreeListColumn treeListColumn3;
        private TreeListColumn treeListColumn4;

        public FormLogin5()
        {
            this.m_Timer = new Timer();
            this.InitializeComponent();
            this.m_Timer.Tick += new EventHandler(this.m_Timer_Tick);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            string configValue = UtilFactory.GetConfigOpt().GetConfigValue("LoginUserID");
            if (configValue == "")
            {
                this.textEdit1.Text = "admin";
            }
            else
            {
                this.textEdit1.Text = configValue;
            }
            this.textEdit2.Text = "";
            this.label1.BringToFront();
            this.tListKind.BeginUnboundLoad();
            this.tListKind.AppendNode(new object[] { "信息管理系统" }, -1, 0, 0, 0);
            this.tListKind.Nodes[0].Tag = "信息管理系统";
            this.tListKind.AppendNode(new object[] { "三维电子沙盘" }, 0, 0, 0, 11);
            this.tListKind.Nodes[0].Nodes[0].Tag = "三维浏览";
            this.tListKind.AppendNode(new object[] { "二维数据浏览" }, 0, 0, 0, 12);
            this.tListKind.Nodes[0].Nodes[1].Tag = "二维浏览";
            this.tListKind.AppendNode(new object[] { "业务管理系统" }, -1, 0, 0, 1);
            this.tListKind.Nodes[1].Tag = "业务管理系统";
            this.tListKind.AppendNode(new object[] { "造林作业" }, 3, 0, 0, 3);
            this.tListKind.Nodes[1].Nodes[0].Tag = "造林";
            this.tListKind.AppendNode(new object[] { "采伐作业" }, 3, 0, 0, 4);
            this.tListKind.Nodes[1].Nodes[1].Tag = "采伐";
            this.tListKind.AppendNode(new object[] { "林地征占用" }, 3, 0, 0, 5);
            this.tListKind.Nodes[1].Nodes[2].Tag = "征占用";
            this.tListKind.AppendNode(new object[] { "森林火灾" }, 3, 0, 0, 6);
            this.tListKind.Nodes[1].Nodes[3].Tag = "火灾";
            this.tListKind.AppendNode(new object[] { "林业案件" }, 3, 0, 0, 7);
            this.tListKind.Nodes[1].Nodes[4].Tag = "林业案件";
            this.tListKind.AppendNode(new object[] { "自然灾害" }, 3, 0, 0, 8);
            this.tListKind.Nodes[1].Nodes[5].Tag = "自然灾害";
            this.tListKind.AppendNode(new object[] { "年度更新系统" }, -1, 0, 0, 13);
            this.tListKind.Nodes[2].Tag = "年度更新系统";
            this.tListKind.AppendNode(new object[] { "变更编辑" }, 10, 0, 0, 10);
            this.tListKind.Nodes[2].Nodes[0].Tag = "小班变更";
            this.tListKind.AppendNode(new object[] { "年度编辑" }, 10, 0, 0, 9);
            this.tListKind.Nodes[2].Nodes[1].Tag = "年度小班";
            this.tListKind.AppendNode(new object[] { "系统管理" }, -1, 0, 0, 2);
            this.tListKind.Nodes[3].Tag = "系统管理";
            this.tListKind.EndUnboundLoad();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin5));
            this.panelLogin = new System.Windows.Forms.Panel();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.panelSys = new System.Windows.Forms.Panel();
            this.tListKind = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemImageEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemImageEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemImageEdit33 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelProgress = new System.Windows.Forms.Panel();
            this.LabelLoadInfo = new System.Windows.Forms.Label();
            this.LabelProgressBar = new System.Windows.Forms.Label();
            this.LabelProgressBack = new System.Windows.Forms.Label();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            this.panelSys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tListKind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit33)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.Transparent;
            this.panelLogin.Controls.Add(this.simpleButtonCancel);
            this.panelLogin.Controls.Add(this.simpleButtonOK);
            this.panelLogin.Controls.Add(this.label1);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.textEdit1);
            this.panelLogin.Controls.Add(this.textEdit2);
            this.panelLogin.Location = new System.Drawing.Point(37, 130);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(299, 89);
            this.panelLogin.TabIndex = 57;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonCancel.ImageIndex = 3;
            this.simpleButtonCancel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonCancel.Location = new System.Drawing.Point(216, 52);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(73, 26);
            this.simpleButtonCancel.TabIndex = 10;
            this.simpleButtonCancel.Text = "退出";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonOK.ImageIndex = 0;
            this.simpleButtonOK.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonOK.Location = new System.Drawing.Point(215, 7);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(74, 26);
            this.simpleButtonOK.TabIndex = 9;
            this.simpleButtonOK.Text = "确定";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(34, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "用户名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(34, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "密码:";
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "xiaoyao";
            this.textEdit1.Location = new System.Drawing.Point(92, 12);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.textEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit1.Size = new System.Drawing.Size(117, 20);
            this.textEdit1.TabIndex = 0;
            // 
            // textEdit2
            // 
            this.textEdit2.EditValue = "1";
            this.textEdit2.Location = new System.Drawing.Point(92, 57);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.textEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit2.Properties.PasswordChar = '*';
            this.textEdit2.Size = new System.Drawing.Size(117, 20);
            this.textEdit2.TabIndex = 1;
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "sjcj_login_03.png");
            this.imageList3.Images.SetKeyName(1, "sjcj_login_03dowen.png");
            this.imageList3.Images.SetKeyName(2, "sjcj_login_03up.png");
            this.imageList3.Images.SetKeyName(3, "sjcj_login_04.png");
            this.imageList3.Images.SetKeyName(4, "sjcj_login_04dowen.png");
            this.imageList3.Images.SetKeyName(5, "sjcj_login_04up.png");
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 125);
            this.label3.TabIndex = 58;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "12.png");
            this.imageList1.Images.SetKeyName(1, "img-11.png");
            this.imageList1.Images.SetKeyName(2, "map6.png");
            this.imageList1.Images.SetKeyName(3, "Network-Service.png");
            this.imageList1.Images.SetKeyName(4, "preferences-other.png");
            this.imageList1.Images.SetKeyName(5, "internet11.png");
            this.imageList1.Images.SetKeyName(6, "Control-Panel2.png");
            this.imageList1.Images.SetKeyName(7, "My-Documents.png");
            this.imageList1.Images.SetKeyName(8, "Xcode.png");
            this.imageList1.Images.SetKeyName(9, "Text-Document.png");
            this.imageList1.Images.SetKeyName(10, "hot.png");
            this.imageList1.Images.SetKeyName(11, "abiword.png");
            this.imageList1.Images.SetKeyName(12, "green_wormhole.png");
            this.imageList1.Images.SetKeyName(13, "applix.png");
            this.imageList1.Images.SetKeyName(14, "edit-users.png");
            this.imageList1.Images.SetKeyName(15, "fire2.png");
            this.imageList1.Images.SetKeyName(16, "fire3.png");
            this.imageList1.Images.SetKeyName(17, "icontexto-green-01.png");
            this.imageList1.Images.SetKeyName(18, "tree2.png");
            this.imageList1.Images.SetKeyName(19, "tree_1.png");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.White;
            this.imageList2.Images.SetKeyName(0, "12.png");
            this.imageList2.Images.SetKeyName(1, "Network-Service.png");
            this.imageList2.Images.SetKeyName(2, "系统管理2.png");
            this.imageList2.Images.SetKeyName(3, "造林48.png");
            this.imageList2.Images.SetKeyName(4, "采伐48.png");
            this.imageList2.Images.SetKeyName(5, "征占用48.png");
            this.imageList2.Images.SetKeyName(6, "火灾48.png");
            this.imageList2.Images.SetKeyName(7, "案件48.png");
            this.imageList2.Images.SetKeyName(8, "灾害2.png");
            this.imageList2.Images.SetKeyName(9, "年度更新2.png");
            this.imageList2.Images.SetKeyName(10, "小班变更2.png");
            this.imageList2.Images.SetKeyName(11, "三维48.png");
            this.imageList2.Images.SetKeyName(12, "二维48.png");
            this.imageList2.Images.SetKeyName(13, "mb5u6_mb5ucom.png");
            this.imageList2.Images.SetKeyName(14, "20071127000628921.png");
            this.imageList2.Images.SetKeyName(15, "openofficeorg-draw.png");
            this.imageList2.Images.SetKeyName(16, "20071206144123734.png");
            this.imageList2.Images.SetKeyName(17, "sc0905281_6.png");
            this.imageList2.Images.SetKeyName(18, "sc0905281_2.png");
            this.imageList2.Images.SetKeyName(19, "20071127000610996.png");
            this.imageList2.Images.SetKeyName(20, "20071127000623617.png");
            // 
            // panelSys
            // 
            this.panelSys.BackColor = System.Drawing.Color.White;
            this.panelSys.Controls.Add(this.tListKind);
            this.panelSys.Controls.Add(this.panel1);
            this.panelSys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSys.Location = new System.Drawing.Point(0, 0);
            this.panelSys.Name = "panelSys";
            this.panelSys.Padding = new System.Windows.Forms.Padding(6);
            this.panelSys.Size = new System.Drawing.Size(372, 262);
            this.panelSys.TabIndex = 60;
            this.panelSys.Visible = false;
            // 
            // tListKind
            // 
            this.tListKind.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tListKind.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.White;
            this.tListKind.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Blue;
            this.tListKind.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tListKind.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tListKind.Appearance.FocusedRow.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tListKind.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.White;
            this.tListKind.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Blue;
            this.tListKind.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tListKind.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tListKind.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.White;
            this.tListKind.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.White;
            this.tListKind.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.tListKind.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tListKind.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tListKind.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4});
            this.tListKind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tListKind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tListKind.Location = new System.Drawing.Point(6, 6);
            this.tListKind.Name = "tListKind";
            this.tListKind.OptionsBehavior.Editable = false;
            this.tListKind.OptionsView.AutoWidth = false;
            this.tListKind.OptionsView.ShowColumns = false;
            this.tListKind.OptionsView.ShowHorzLines = false;
            this.tListKind.OptionsView.ShowIndicator = false;
            this.tListKind.OptionsView.ShowRoot = false;
            this.tListKind.OptionsView.ShowVertLines = false;
            this.tListKind.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit2,
            this.repositoryItemImageComboBox1,
            this.repositoryItemPictureEdit1,
            this.repositoryItemButtonEdit1,
            this.repositoryItemImageEdit3,
            this.repositoryItemImageEdit33});
            this.tListKind.RowHeight = 50;
            this.tListKind.Size = new System.Drawing.Size(360, 217);
            this.tListKind.StateImageList = this.imageList2;
            this.tListKind.TabIndex = 62;
            this.tListKind.TreeLevelWidth = 36;
            this.tListKind.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            this.tListKind.FocusedColumnChanged += new DevExpress.XtraTreeList.FocusedColumnChangedEventHandler(this.tListKind_FocusedColumnChanged);
            this.tListKind.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tListKind_MouseClick);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "专题";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.MinWidth = 140;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 140;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "treeListColumn2";
            this.treeListColumn2.FieldName = "treeListColumn2";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 60;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "treeListColumn3";
            this.treeListColumn3.FieldName = "treeListColumn3";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 60;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "treeListColumn4";
            this.treeListColumn4.FieldName = "treeListColumn4";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 3;
            this.treeListColumn4.Width = 60;
            // 
            // repositoryItemImageEdit2
            // 
            this.repositoryItemImageEdit2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemImageEdit2.Appearance.Image")));
            this.repositoryItemImageEdit2.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit2.AutoHeight = false;
            this.repositoryItemImageEdit2.Name = "repositoryItemImageEdit2";
            this.repositoryItemImageEdit2.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemImageComboBox1.Appearance.Image")));
            this.repositoryItemImageComboBox1.Appearance.Options.UseImage = true;
            this.repositoryItemImageComboBox1.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemImageComboBox1.AppearanceFocused.Image")));
            this.repositoryItemImageComboBox1.AppearanceFocused.Options.UseImage = true;
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemImageComboBox1.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemPictureEdit1.Appearance.Image")));
            this.repositoryItemPictureEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repositoryItemImageEdit3
            // 
            this.repositoryItemImageEdit3.AutoHeight = false;
            this.repositoryItemImageEdit3.Name = "repositoryItemImageEdit3";
            this.repositoryItemImageEdit3.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            // 
            // repositoryItemImageEdit33
            // 
            this.repositoryItemImageEdit33.AutoHeight = false;
            this.repositoryItemImageEdit33.Name = "repositoryItemImageEdit33";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.simpleButton2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(6, 223);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.panel1.Size = new System.Drawing.Size(360, 33);
            this.panel1.TabIndex = 63;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton2.ImageIndex = 0;
            this.simpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton2.Location = new System.Drawing.Point(207, 6);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(74, 27);
            this.simpleButton2.TabIndex = 60;
            this.simpleButton2.Text = "进入";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(281, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(6, 27);
            this.panel2.TabIndex = 62;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton1.ImageIndex = 3;
            this.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton1.Location = new System.Drawing.Point(287, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(73, 27);
            this.simpleButton1.TabIndex = 61;
            this.simpleButton1.Text = "退出";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // panelProgress
            // 
            this.panelProgress.BackColor = System.Drawing.Color.Transparent;
            this.panelProgress.Controls.Add(this.LabelLoadInfo);
            this.panelProgress.Controls.Add(this.LabelProgressBar);
            this.panelProgress.Controls.Add(this.LabelProgressBack);
            this.panelProgress.Location = new System.Drawing.Point(34, 163);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Size = new System.Drawing.Size(304, 32);
            this.panelProgress.TabIndex = 76;
            this.panelProgress.Visible = false;
            // 
            // LabelLoadInfo
            // 
            this.LabelLoadInfo.BackColor = System.Drawing.Color.Transparent;
            this.LabelLoadInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.LabelLoadInfo.Location = new System.Drawing.Point(30, 3);
            this.LabelLoadInfo.Name = "LabelLoadInfo";
            this.LabelLoadInfo.Size = new System.Drawing.Size(258, 19);
            this.LabelLoadInfo.TabIndex = 12;
            this.LabelLoadInfo.Text = "系统启动中, 请稍后...";
            this.LabelLoadInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelProgressBar
            // 
            this.LabelProgressBar.BackColor = System.Drawing.Color.Gold;
            this.LabelProgressBar.Location = new System.Drawing.Point(3, 27);
            this.LabelProgressBar.Name = "LabelProgressBar";
            this.LabelProgressBar.Size = new System.Drawing.Size(117, 2);
            this.LabelProgressBar.TabIndex = 13;
            // 
            // LabelProgressBack
            // 
            this.LabelProgressBack.BackColor = System.Drawing.Color.White;
            this.LabelProgressBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabelProgressBack.ForeColor = System.Drawing.Color.White;
            this.LabelProgressBack.Location = new System.Drawing.Point(2, 26);
            this.LabelProgressBack.Name = "LabelProgressBack";
            this.LabelProgressBack.Size = new System.Drawing.Size(300, 4);
            this.LabelProgressBack.TabIndex = 11;
            // 
            // FormLogin5
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(372, 262);
            this.ControlBox = false;
            this.Controls.Add(this.panelProgress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.panelSys);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Blue";
            this.Name = "FormLogin5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "森林资源管理信息平台 - 系统登录";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.Controls.SetChildIndex(this.panelSys, 0);
            this.Controls.SetChildIndex(this.panelLogin, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.sButOk, 0);
            this.Controls.SetChildIndex(this.panelProgress, 0);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            this.panelSys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tListKind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit33)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelProgress.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void m_Timer_Tick(object sender, EventArgs e)
        {
            this.LabelLoadInfo.Refresh();
            this.LabelProgressBack.Refresh();
            this.LabelProgressBar.Refresh();
        }

        public void SetLoadInfo(string sInfo, int iValue)
        {
            try
            {
                this.LabelLoadInfo.Text = sInfo;
                this.LabelProgressBar.Width = ((this.LabelProgressBack.Width - 2) * iValue) / 100;
                this.LabelProgressBar.BringToFront();
                this.Refresh();
            }
            catch (Exception)
            {
            }
        }

        private void SetTree(string str)
        {
            string[] strArray = str.Split(new char[] { ',' });
            TreeListNode node2 = null;
            TreeListNode node3 = null;
            this.tListKind.Columns[0].Width = this.tListKind.Width / 2;
            this.tListKind.Columns[1].Width = this.tListKind.Width / 6;
            this.tListKind.Columns[2].Width = this.tListKind.Width / 6;
            this.tListKind.Columns[3].Width = this.tListKind.Width / 6;
            for (int i = 0; i < (this.tListKind.Nodes.Count - 1); i++)
            {
                bool flag;
                int num3;
                node3 = this.tListKind.Nodes[i];
                node3.ExpandAll();
                if (node3.Nodes.Count > 0)
                {
                    flag = false;
                    for (int j = 0; j < node3.Nodes.Count; j++)
                    {
                        node2 = node3.Nodes[j];
                        node2.Visible = false;
                        num3 = 0;
                        while (num3 < strArray.Length)
                        {
                            if (node2.GetDisplayText(0).Contains(strArray[num3]) || node2.Tag.ToString().Contains(strArray[num3]))
                            {
                                node2.Visible = true;
                                node2.ExpandAll();
                                flag = true;
                                if (node2.ParentNode.GetDisplayText(0) == "业务管理系统")
                                {
                                    node2.SetValue(1, "数据编辑");
                                    node2.SetValue(2, "查询统计");
                                    node2.SetValue(3, "系统管理");
                                }
                            }
                            num3++;
                        }
                    }
                    if (!flag)
                    {
                        node3.Visible = false;
                    }
                }
                else
                {
                    flag = false;
                    for (num3 = 0; num3 < strArray.Length; num3++)
                    {
                        if (node3.GetDisplayText(0).Contains(strArray[num3]) || node3.Tag.ToString().Contains(strArray[num3]))
                        {
                            node3.Visible = true;
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        node3.Visible = false;
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.panelSys.Visible = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            TreeListNode node = this.tListKind.Selection[0];
            string sKind = node.Tag.ToString();
            string text = this.textEdit1.Text;
            string sPasswrd = this.textEdit2.Text;
          
            Tuple<bool, string> res = td.logic.sys.UserManager.Single.Login(text, sPasswrd, sKind);
            if (res.Item1)
            {
                MessageBox.Show(this, res.Item2, "系统登录", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                UtilFactory.GetConfigOpt().SetConfigValue("LoginUserID", text);
                if (sKind == "系统管理")
                {
                    new FormSystemManage().ShowDialog();
                    this.panelLogin.Visible = false;
                }
                else
                {
                    this.panelSys.Visible = false;
                    this.panelLogin.Visible = false;
                    this.panelLogin.Visible = true;
                    base.Hide();
                }
            }
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.CancelFlag = true;
            base.Close();
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            string text = this.textEdit1.Text;
            string sPasswrd = this.textEdit2.Text;
         
            Tuple<bool,string> res= td.logic.sys.UserManager.Single.Login2(text, sPasswrd);
            if (!res.Item1)
            {
                MessageBox.Show(this, res.Item2, "系统登录", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.panelSys.Visible = true;
                this.panelSys.BringToFront();
                this.SetTree(res.Item2);
            }
        }

        private void tListKind_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            if (e.Column != null)
            {
                this.column = e.Column.AbsoluteIndex;
            }
        }

        private void tListKind_MouseClick(object sender, MouseEventArgs e)
        {
            if ((this.tListKind.Selection.Count != 0) && !this.tListKind.Selection[0].HasChildren)
            {
                if (this.column == -1)
                {
                    this.column = 0;
                }
                this.EditKind = this.tListKind.Selection[0].Tag.ToString();
                if ((this.column > 0) && (this.tListKind.Selection[0].GetDisplayText(this.column) != ""))
                {
                    this.EditKind = this.tListKind.Selection[0].Tag.ToString() + "-" + this.tListKind.Selection[0].GetDisplayText(this.column);
                }
                if (this.EditKind == "二维浏览")
                {
                    this.EditKind = "年度小班-查询统计";
                }
                else if (this.EditKind == "三维浏览")
                {
                    this.EditKind = "年度小班-三维系统";
                }
            }
        }
    }
}

