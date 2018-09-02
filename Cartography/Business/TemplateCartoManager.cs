namespace Cartography.Business
{
    using Cartography.Template;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using stdole;
    using System;
    using Utilities;

    public class TemplateCartoManager
    {
        private const string mClassName = "QueryAnalysic.Business.TemplateCartoManager";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        private IObject GetEcertSQB(IWorkspace pWorkspace, IFeature feature)
        {
            try
            {
                ConfigOpt configOpt = UtilFactory.GetConfigOpt();
                string name = configOpt.GetConfigValue2("Ecert", "SQBTable");
                IWorkspace workspace = pWorkspace;
                if (workspace == null)
                {
                    return null;
                }
                ITable table = ((IFeatureWorkspace) workspace).OpenTable(name);
                if (table == null)
                {
                    return null;
                }
                string str2 = configOpt.GetConfigValue2("Ecert", "SubField");
                int index = feature.Fields.FindField(str2);
                string str3 = feature.get_Value(index).ToString();
                string str4 = configOpt.GetConfigValue2("Ecert", "RelateField");
                IQueryFilter queryFilter = new QueryFilterClass();
                queryFilter.WhereClause = str4 + "='" + str3 + "'";
                return (IObject) table.Search(queryFilter, false).NextRow();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.Business.TemplateCartoManager", "GetEcertSQB", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        public void NormalCarto(IPageLayoutControl3 pPageLayoutControl)
        {
            new Cartography.Template.TemplateCarto().NormalCarto(pPageLayoutControl);
        }

        public void SetLQExtent(IPageLayoutControl3 pPageLayoutControl, IFeatureLayer pLayer)
        {
            try
            {
                IFeatureSelection selection = pLayer as IFeatureSelection;
                if (selection.SelectionSet.Count == 1)
                {
                    IEnumIDs iDs = selection.SelectionSet.IDs;
                    iDs.Reset();
                    int iD = iDs.Next();
                    if (iD != -1)
                    {
                        IFeature feature = pLayer.FeatureClass.GetFeature(iD);
                        if (feature != null)
                        {
                            IActiveView focusMap = (IActiveView) pPageLayoutControl.ActiveView.FocusMap;
                            IEnvelope envelope = feature.ShapeCopy.Envelope;
                            envelope.Expand(1.5, 1.5, true);
                            focusMap.Extent = envelope;
                            IObject ecertSQB = this.GetEcertSQB(pLayer.FeatureClass.FeatureDataset.Workspace, feature);
                            ITextSymbol symbology = new TextSymbolClass();
                            IFontDisp font = symbology.Font;
                            font.Name = "宋体";
                            symbology.Font = font;
                            IEnvelope extent = pPageLayoutControl.ActiveView.Extent;
                            IElement element2 = pPageLayoutControl.FindElementByName("west", 1);
                            if (element2 == null)
                            {
                                IEnvelope geometry = new EnvelopeClass();
                                double xMin = extent.XMin;
                                double yMin = extent.YMin + (extent.Height / 2.0);
                                double xMax = xMin + 1.0;
                                double yMax = yMin + 1.0;
                                geometry.PutCoords(xMin, yMin, xMax, yMax);
                                pPageLayoutControl.AddElement(new TextElementClass(), geometry, symbology, "west", 0);
                                element2 = pPageLayoutControl.FindElementByName("west", 1);
                            }
                            ITextElement element = element2 as ITextElement;
                            int index = ecertSQB.Fields.FindField("WEST");
                            element.Text = "西：" + ecertSQB.get_Value(index);
                            element2 = pPageLayoutControl.FindElementByName("east", 1);
                            if (element2 == null)
                            {
                                IEnvelope envelope4 = new EnvelopeClass();
                                double num7 = extent.XMax;
                                double num8 = extent.YMin + (extent.Height / 2.0);
                                double num9 = num7 + 1.0;
                                double num10 = num8 + 1.0;
                                envelope4.PutCoords(num7, num8, num9, num10);
                                pPageLayoutControl.AddElement(new TextElementClass(), envelope4, symbology, "east", 0);
                                element2 = pPageLayoutControl.FindElementByName("east", 1);
                            }
                            element = element2 as ITextElement;
                            index = ecertSQB.Fields.FindField("EAST");
                            element.Text = "东：" + ecertSQB.get_Value(index);
                            element2 = pPageLayoutControl.FindElementByName("south", 1);
                            if (element2 == null)
                            {
                                IEnvelope envelope5 = new EnvelopeClass();
                                double num11 = extent.XMin + (extent.Width / 2.0);
                                double num12 = extent.YMin;
                                double num13 = num11 + 1.0;
                                double num14 = num12 + 1.0;
                                envelope5.PutCoords(num11, num12, num13, num14);
                                pPageLayoutControl.AddElement(new TextElementClass(), envelope5, symbology, "south", 0);
                                element2 = pPageLayoutControl.FindElementByName("south", 1);
                            }
                            element = element2 as ITextElement;
                            index = ecertSQB.Fields.FindField("SOUTH");
                            element.Text = "南：" + ecertSQB.get_Value(index);
                            element2 = pPageLayoutControl.FindElementByName("north", 1);
                            if (element2 == null)
                            {
                                IEnvelope envelope6 = new EnvelopeClass();
                                double num15 = extent.XMin + (extent.Width / 2.0);
                                double num16 = extent.YMax;
                                double num17 = num15 + 1.0;
                                double num18 = num16 + 1.0;
                                envelope6.PutCoords(num15, num16, num17, num18);
                                pPageLayoutControl.AddElement(new TextElementClass(), envelope6, symbology, "north", 0);
                                element2 = pPageLayoutControl.FindElementByName("north", 1);
                            }
                            element = element2 as ITextElement;
                            index = ecertSQB.Fields.FindField("NORTH");
                            element.Text = "北：" + ecertSQB.get_Value(index);
                            pPageLayoutControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, envelope);
                            pPageLayoutControl.ZoomToWholePage();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.Business.TemplateCartoManager", "SetLQExtent", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void TemplateCarto(IPageLayoutControl3 pPageLayoutControl, Cartography.Template.TemplateInfo pInfo)
        {
            string fullName = pInfo.GetFullName();
            new Cartography.Template.TemplateCarto().Carto(pPageLayoutControl, fullName);
        }
    }
}

