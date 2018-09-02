namespace StatisChart
{
    using DevExpress.XtraCharts;
    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public static class ChartService
    {
        public static void DrawChart(ChartControl control, string seriesName, ViewType type, DataTable dt, int column1, int column2, ref double dMin, ref double dMax)
        {
            try
            {
                Series series = new Series(seriesName, type);
                SeriesPoint point = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double num2 = 0.0;
                    if (dt.Rows[i][column2] == DBNull.Value)
                    {
                        num2 = 0.0;
                    }
                    else
                    {
                        num2 = Convert.ToDouble(dt.Rows[i][column2].ToString());
                    }
                    point = new SeriesPoint(dt.Rows[i][column1], new object[] { num2 });
                    series.Points.Add(point);
                    if (dMin < 0.0)
                    {
                        dMin = num2;
                    }
                    if (num2 < dMin)
                    {
                        dMin = num2;
                    }
                    if (dMax < 0.0)
                    {
                        dMax = num2;
                    }
                    if (num2 > dMax)
                    {
                        dMax = num2;
                    }
                }
                control.Series.Add(series);
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法DrawChart出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public static void SetAxisX(ChartControl control, bool visible, ViewType type, StringAlignment aligment, string text, Color color, bool isAntialiasing, Font font, bool bStag)
        {
            Diagram diagram = control.Diagram;
            if (diagram is XYDiagram)
            {
                XYDiagram diagram2 = (XYDiagram) diagram;
                diagram2.AxisX.Title.Visible = visible;
                diagram2.AxisX.Title.Alignment = aligment;
                diagram2.AxisX.Title.Text = text;
                diagram2.AxisX.Title.TextColor = color;
                diagram2.AxisX.Title.Antialiasing = isAntialiasing;
                diagram2.AxisX.Title.Font = font;
                diagram2.AxisX.Label.Staggered = bStag;
                if (type == ViewType.Bar)
                {
                    int num = 0;
                    for (int i = 0; i < control.Series.Count; i++)
                    {
                        num += control.Series[i].Points.Count;
                    }
                    double num3 = num / control.Series.Count;
                    if ((num3 < 6.0) && (control.Series.Count < 6))
                    {
                        for (int j = 0; j < control.Series.Count; j++)
                        {
                            BarSeriesView view = (BarSeriesView) control.Series[j].View;
                            view.BarWidth = 0.1 * ((int) num3);
                        }
                    }
                }
            }
            else if (diagram is XYDiagram3D)
            {
                XYDiagram3D diagramd = (XYDiagram3D) diagram;
                diagramd.AxisX.Label.Visible = true;
                diagramd.AxisX.Label.Staggered = bStag;
                if (type == ViewType.Bar3D)
                {
                    int num5 = 0;
                    for (int k = 0; k < control.Series.Count; k++)
                    {
                        num5 += control.Series[k].Points.Count;
                    }
                    double num7 = num5 / control.Series.Count;
                    if ((num7 < 6.0) && (control.Series.Count < 6))
                    {
                        for (int m = 0; m < control.Series.Count; m++)
                        {
                            Bar3DSeriesView view2 = (Bar3DSeriesView) control.Series[m].View;
                            view2.BarWidth = 0.1 * ((int) num7);
                        }
                    }
                }
            }
        }

        public static void SetAxisY(ChartControl control, bool visible, StringAlignment alignment, string text, Color color, bool isAntialiasing, Font font, double dMinValue, double dMaxValue)
        {
            Diagram diagram = control.Diagram;
            if (diagram is XYDiagram)
            {
                XYDiagram diagram2 = (XYDiagram) diagram;
                diagram2.AxisY.Title.Visible = visible;
                diagram2.AxisY.Title.Alignment = alignment;
                diagram2.AxisY.Title.Text = text;
                diagram2.AxisY.Title.TextColor = color;
                diagram2.AxisY.Title.Antialiasing = isAntialiasing;
                diagram2.AxisY.Title.Font = font;
                diagram2.AxisY.Range.Auto = true;
                if (dMinValue < dMaxValue)
                {
                    diagram2.AxisY.Range.MinValue = dMinValue;
                    diagram2.AxisY.Range.MaxValue = dMaxValue;
                }
            }
            else if (diagram is XYDiagram3D)
            {
                XYDiagram3D diagramd = (XYDiagram3D) diagram;
                diagramd.AxisY.Interlaced = true;
                diagramd.AxisY.Label.Visible = true;
                diagramd.AxisY.Range.Auto = true;
                if (dMinValue < dMaxValue)
                {
                    diagramd.AxisY.Range.MinValue = dMinValue;
                    diagramd.AxisY.Range.MaxValue = dMaxValue;
                    diagramd.RuntimeRotation = true;
                    diagramd.AxisY.Range.SideMarginsEnabled = true;
                    diagramd.AxisX.Range.SideMarginsEnabled = true;
                    diagramd.ZoomPercent = 180;
                    diagramd.VerticalScrollPercent = 6.0;
                    diagramd.PerspectiveAngle = 20;
                    diagramd.RuntimeScrolling = true;
                    diagramd.RuntimeZooming = true;
                }
            }
        }

        public static void SetChartTitle(ChartControl control, bool visible, string text, bool isWorkWrop, int maxLineCount, StringAlignment alignment, ChartTitleDockStyle dock, bool isAntialiasing, Font font, Color textColor, int indent)
        {
            ChartTitle title = new ChartTitle();
            title.Visible = visible;
            title.Text = text;
            title.WordWrap = isWorkWrop;
            title.MaximumLinesCount = maxLineCount;
            title.Alignment = alignment;
            title.Dock = dock;
            title.Antialiasing = isAntialiasing;
            title.Font = font;
            title.TextColor = textColor;
            title.Indent = indent;
            control.Titles.Add(title);
        }
    }
}

