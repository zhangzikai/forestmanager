namespace StatisChart
{
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraCharts;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using FormBase;
    using QueryCommon;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;

    public class UserControlChart : UserControlBase1
    {
        private ChartControl chartControl1;
        private IContainer components;
        private const string mClassName = "StatisChart.UserControlChart";
        private DockPanel mDockPanel;
        private IFeatureLayer mEditLayer;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private ArrayList mFeatureList;
        private IHookHelper mHookHelper;
        private IMap mMap;
        private ArrayList mNameList;
        private ArrayList mQueryList;
        private UserControlQueryResult mQueryResult;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public UserControlChart()
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
            XYDiagram3D diagramd = new XYDiagram3D();
            Series series = new Series();
            StackedBar3DSeriesLabel label = new StackedBar3DSeriesLabel();
            SideBySideStackedBar3DSeriesView view = new SideBySideStackedBar3DSeriesView();
            Series series2 = new Series();
            StackedBar3DSeriesLabel label2 = new StackedBar3DSeriesLabel();
            SideBySideStackedBar3DSeriesView view2 = new SideBySideStackedBar3DSeriesView();
            Series series3 = new Series();
            StackedBar3DSeriesLabel label3 = new StackedBar3DSeriesLabel();
            SideBySideStackedBar3DSeriesView view3 = new SideBySideStackedBar3DSeriesView();
            Series series4 = new Series();
            StackedBar3DSeriesLabel label4 = new StackedBar3DSeriesLabel();
            SideBySideStackedBar3DSeriesView view4 = new SideBySideStackedBar3DSeriesView();
            StackedBar3DSeriesLabel label5 = new StackedBar3DSeriesLabel();
            SideBySideStackedBar3DSeriesView view5 = new SideBySideStackedBar3DSeriesView();
            this.chartControl1 = new ChartControl();
            this.chartControl1.BeginInit();
            ((ISupportInitialize) diagramd).BeginInit();
            ((ISupportInitialize) series).BeginInit();
            ((ISupportInitialize) label).BeginInit();
            ((ISupportInitialize) view).BeginInit();
            ((ISupportInitialize) series2).BeginInit();
            ((ISupportInitialize) label2).BeginInit();
            ((ISupportInitialize) view2).BeginInit();
            ((ISupportInitialize) series3).BeginInit();
            ((ISupportInitialize) label3).BeginInit();
            ((ISupportInitialize) view3).BeginInit();
            ((ISupportInitialize) series4).BeginInit();
            ((ISupportInitialize) label4).BeginInit();
            ((ISupportInitialize) view4).BeginInit();
            ((ISupportInitialize) label5).BeginInit();
            ((ISupportInitialize) view5).BeginInit();
            base.SuspendLayout();
            diagramd.AxisX.Range.ScrollingRange.SideMarginsEnabled = true;
            diagramd.AxisX.Range.SideMarginsEnabled = true;
            diagramd.AxisY.Range.ScrollingRange.SideMarginsEnabled = true;
            diagramd.AxisY.Range.SideMarginsEnabled = true;
            diagramd.RotationMatrixSerializable = "0.766044443118978;-0.219846310392954;0.604022773555054;0;0;0.939692620785908;0.342020143325669;0;-0.642787609686539;-0.262002630229385;0.719846310392954;0;0;0;0;1";
            this.chartControl1.Diagram = diagramd;
            this.chartControl1.Location = new Point(0x15, 0x36);
            this.chartControl1.Name = "chartControl1";
            label.Visible = false;
            series.Label = label;
            series.Name = "Series 1";
            view.StackedGroupSerializable = "Group 1";
            series.View = view;
            label2.Visible = false;
            series2.Label = label2;
            series2.Name = "Series 2";
            view2.StackedGroupSerializable = "Group 1";
            series2.View = view2;
            label3.Visible = false;
            series3.Label = label3;
            series3.Name = "Series 3";
            view3.StackedGroupSerializable = "Group 2";
            series3.View = view3;
            label4.Visible = false;
            series4.Label = label4;
            series4.Name = "Series 4";
            view4.StackedGroupSerializable = "Group 2";
            series4.View = view4;
            this.chartControl1.SeriesSerializable = new Series[] { series, series2, series3, series4 };
            label5.Visible = true;
            this.chartControl1.SeriesTemplate.Label = label5;
            this.chartControl1.SeriesTemplate.View = view5;
            this.chartControl1.Size = new Size(300, 200);
            this.chartControl1.TabIndex = 0;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.chartControl1);
            base.Name = "UserControlChart";
            base.Size = new Size(0x187, 0x167);
            ((ISupportInitialize) diagramd).EndInit();
            ((ISupportInitialize) label).EndInit();
            ((ISupportInitialize) view).EndInit();
            ((ISupportInitialize) series).EndInit();
            ((ISupportInitialize) label2).EndInit();
            ((ISupportInitialize) view2).EndInit();
            ((ISupportInitialize) series2).EndInit();
            ((ISupportInitialize) label3).EndInit();
            ((ISupportInitialize) view3).EndInit();
            ((ISupportInitialize) series3).EndInit();
            ((ISupportInitialize) label4).EndInit();
            ((ISupportInitialize) view4).EndInit();
            ((ISupportInitialize) series4).EndInit();
            ((ISupportInitialize) label5).EndInit();
            ((ISupportInitialize) view5).EndInit();
            this.chartControl1.EndInit();
            base.ResumeLayout(false);
        }
    }
}

