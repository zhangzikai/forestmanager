namespace EarthBusiness
{
    using DevExpress.XtraCharts;
    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class ChartService
    {
        public void DrawChart(ChartControl control, ViewType type, DataTable dt)
        {
            try
            {
                for (int i = 1; i < (dt.Columns.Count - 2); i++)
                {
                    Series series = new Series(dt.Columns[i].Caption, type);
                    series.DataSource = dt;
                    series.ArgumentScaleType = ScaleType.Qualitative;
                    series.ArgumentDataMember = dt.Columns[0].Caption;
                    series.ValueScaleType = ScaleType.Numerical;
                    series.ValueDataMembers.AddRange(new string[] { dt.Columns[i].Caption });
                    control.Series.Add(series);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法DrawChart出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void SetAxisX(ChartControl control, bool visible, StringAlignment aligment, string text, Color color, bool isAntialiasing, Font font)
        {
            XYDiagram diagram = (XYDiagram) control.Diagram;
            diagram.AxisX.Title.Visible = visible;
            diagram.AxisX.Title.Alignment = aligment;
            diagram.AxisX.Title.Text = text;
            diagram.AxisX.Title.TextColor = color;
            diagram.AxisX.Title.Antialiasing = isAntialiasing;
            diagram.AxisX.Title.Font = font;
        }

        public void SetAxisY(ChartControl control, bool visible, StringAlignment alignment, string text, Color color, bool isAntialiasing, Font font)
        {
            XYDiagram diagram = (XYDiagram) control.Diagram;
            diagram.AxisY.Title.Visible = visible;
            diagram.AxisY.Title.Alignment = alignment;
            diagram.AxisY.Title.Text = text;
            diagram.AxisY.Title.TextColor = color;
            diagram.AxisY.Title.Antialiasing = isAntialiasing;
            diagram.AxisY.Title.Font = font;
        }

        public void SetChartTitle(ChartControl control, bool visible, string text, bool isWorkWrop, int maxLineCount, StringAlignment alignment, ChartTitleDockStyle dock, bool isAntialiasing, Font font, Color textColor, int indent)
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

