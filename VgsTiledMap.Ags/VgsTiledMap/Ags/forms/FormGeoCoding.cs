namespace VgsTiledMap.Ags.forms
{
    using ESRI.ArcGIS.ArcMapUI;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Framework;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Web;
    using System.Windows.Forms;
    using System.Xml.Linq;
    using VgsTiledMap.Ags.Properties;

    public class FormGeoCoding : Form
    {
        private IApplication _application;
        private System.Windows.Forms.Button BtnGeoCoding;
        private ComboBox cboCity;
        private ComboBox combo;
        private IContainer components;
        private string szLat;
        private string szLng;
        private string szXML;
        private WebBrowser wb = new WebBrowser();

        public FormGeoCoding(IApplication app)
        {
            this.InitializeComponent();
            this._application = app;
            string str = Resources.soso_search_html;
            this.wb.DocumentText = str;
            this.wb.ObjectForScripting = this;
        }

        private void BtnGeoCoding_Click(object sender, EventArgs e)
        {
            IMxDocument document = (IMxDocument) this._application.Document;
            if (document.FocusMap.LayerCount == 0)
            {
                MessageBox.Show("请先至少添加一个图层！", "地名搜索提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (this.combo.Text.Length > 0)
            {
                string text = this.combo.Text;
                if (this.cboCity.Text.Length > 0)
                {
                    text = this.cboCity.Text + "," + text;
                }
                this.wb.Document.InvokeScript("codeAddress", new string[] { text });
            }
            else
            {
                MessageBox.Show("请输入查询关键字", "地名搜索提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void FlashPoint(IScreenDisplay pDisplay, IGeometry pGeometry)
        {
            SimpleMarkerSymbolClass class2 = new SimpleMarkerSymbolClass();
            class2.Style = esriSimpleMarkerStyle.esriSMSCircle;
            ISimpleMarkerSymbol symbol = class2;
            ISymbol sym = symbol as ISymbol;
            sym.ROP2 = esriRasterOpCode.esriROPNotXOrPen;
            Thread.Sleep(0x3e8);
            pDisplay.SetSymbol(sym);
            pDisplay.DrawPoint(pGeometry);
            Thread.Sleep(300);
            pDisplay.DrawPoint(pGeometry);
        }

        private void FormGeoCoding_Load(object sender, EventArgs e)
        {
            this.cboCity.Items.AddRange(new string[] { 
                "", "北京市", "上海市", "天津市", "重庆市", "成都市", "济南市", "杭州市", "广州市", "桂林市", "哈尔滨市", "沈阳市", "大连市", "青岛市", "武汉市", "长沙市",
                "石家庄市", "秦皇岛市", "温江市", "义务市", "深圳市", "乌鲁木齐市", "呼和浩特市"
            });
            this.cboCity.SelectedIndex = 0;
        }

        private void GetLatLng(out string szLat, out string szLng)
        {
            string uri = string.Format("http://api.map.baidu.com/geocoder?address={0}&output=xml&key={1}", HttpUtility.UrlEncode(this.combo.Text), "ef81f93020fa272ee8f7fa9abb92eecb");
            if (this.cboCity.Text.Length > 0)
            {
                uri = uri + "&city=" + HttpUtility.UrlEncode(this.cboCity.Text);
            }
            szLat = "";
            szLng = "";
            XElement element = XElement.Load(uri);
            foreach (XElement element2 in Enumerable.Select<XElement, XElement>(Extensions.Descendants<XElement>(Extensions.Descendants<XElement>(element.Elements("result"), "location"), "lat"), delegate (XElement ele) {
                return ele;
            }))
            {
                szLat = element2.Value;
            }
            foreach (XElement element3 in Enumerable.Select<XElement, XElement>(Extensions.Descendants<XElement>(Extensions.Descendants<XElement>(element.Elements("result"), "location"), "lng"), delegate (XElement ele) {
                return ele;
            }))
            {
                szLng = element3.Value;
            }
        }

        private void InitializeComponent()
        {
            this.wb = new WebBrowser();
            this.combo = new ComboBox();
            this.BtnGeoCoding = new System.Windows.Forms.Button();
            this.cboCity = new ComboBox();
            base.SuspendLayout();
            this.wb.Location = new System.Drawing.Point(0x5b, 0x20);
            this.wb.MinimumSize = new Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new Size(0xf6, 0x9d);
            this.wb.TabIndex = 3;
            this.wb.Visible = false;
            this.combo.AutoCompleteSource = AutoCompleteSource.HistoryList;
            this.combo.FormattingEnabled = true;
            this.combo.Location = new System.Drawing.Point(0x5b, 11);
            this.combo.Name = "combo";
            this.combo.Size = new Size(0xf6, 20);
            this.combo.TabIndex = 5;
            this.combo.Text = "天安门广场";
            this.BtnGeoCoding.Location = new System.Drawing.Point(0x157, 10);
            this.BtnGeoCoding.Name = "BtnGeoCoding";
            this.BtnGeoCoding.Size = new Size(80, 0x17);
            this.BtnGeoCoding.TabIndex = 4;
            this.BtnGeoCoding.Text = "地图定位";
            this.BtnGeoCoding.UseVisualStyleBackColor = true;
            this.BtnGeoCoding.Click += new EventHandler(this.BtnGeoCoding_Click);
            this.cboCity.AutoCompleteSource = AutoCompleteSource.HistoryList;
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(12, 11);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new Size(0x49, 20);
            this.cboCity.TabIndex = 5;
            base.ClientSize = new Size(0x1b3, 0x27);
            base.Controls.Add(this.cboCity);
            base.Controls.Add(this.combo);
            base.Controls.Add(this.BtnGeoCoding);
            base.Controls.Add(this.wb);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormGeoCoding";
            this.Text = "查找地址";
            base.Load += new EventHandler(this.FormGeoCoding_Load);
            base.ResumeLayout(false);
        }

        public void NoResult()
        {
            MessageBox.Show("您输入的内容没有找到！\n\n请扩大搜索范围（比如不设置行政区划，或者减少关键字），再执行搜索。", "地名搜索提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void SetLatLng(string strLng, string strLat)
        {
            this.szLat = strLat;
            this.szLng = strLng;
            try
            {
                IMxDocument document = (IMxDocument) this._application.Document;
                IMap focusMap = document.FocusMap;
                IActiveView view = (IActiveView) focusMap;
                PointClass class2 = new PointClass();
                class2.X = Convert.ToDouble(this.szLat);
                class2.Y = Convert.ToDouble(this.szLng);
                IPoint p = class2;
                ISpatialReferenceFactory factory = new SpatialReferenceEnvironmentClass();
                IGeographicCoordinateSystem system = factory.CreateGeographicCoordinateSystem(0x10e6);
                IGeometry geometry = p;
                geometry.SpatialReference = system;
                geometry.Project(focusMap.SpatialReference);
                IEnvelope extent = view.Extent;
                extent.CenterAt(p);
                view.Extent = extent;
                focusMap.MapScale = 5000.0;
                view.Refresh();
            }
            catch (Exception)
            {
            }
        }

        public IApplication application
        {
            get
            {
                return this._application;
            }
            set
            {
                this._application = value;
            }
        }
    }
}

