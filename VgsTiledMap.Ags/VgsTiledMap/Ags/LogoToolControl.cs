namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.Framework;
    using ESRI.ArcGIS.SystemUI;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using VgsTiledMap.Ags.Properties;

    public sealed class LogoToolControl : IToolControl, ICommand
    {
        private Label logoLabel;
        private PictureBox logoPictureBox;
        private IApplication m_application;

        public void OnClick()
        {
        }

        public void OnCreate(object hook)
        {
            this.m_application = hook as IApplication;
            this.logoPictureBox = new PictureBox();
            this.logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.Image = Resources.logo;
            this.logoPictureBox.BackColor = Color.Transparent;
        }

        public bool OnDrop(esriCmdBarType barType)
        {
            return true;
        }

        public void OnFocus(ICompletionNotify complete)
        {
        }

        public int Bitmap
        {
            get
            {
                return 0;
            }
        }

        public string Caption
        {
            get
            {
                return "林地一张图数据管理";
            }
        }

        public string Category
        {
            get
            {
                return "";
            }
        }

        public bool Checked
        {
            get
            {
                return false;
            }
        }

        public bool Enabled
        {
            get
            {
                return true;
            }
        }

        public int HelpContextID
        {
            get
            {
                return 0;
            }
        }

        public string HelpFile
        {
            get
            {
                return "";
            }
        }

        public int hWnd
        {
            get
            {
                return this.logoPictureBox.Handle.ToInt32();
            }
        }

        public string Message
        {
            get
            {
                return "";
            }
        }

        public string Name
        {
            get
            {
                return "林地一张图数据管理";
            }
        }

        public string Tooltip
        {
            get
            {
                return "林地一张图数据管理";
            }
        }
    }
}

