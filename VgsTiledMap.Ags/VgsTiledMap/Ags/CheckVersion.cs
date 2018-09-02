namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.ArcMapUI;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Framework;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Runtime.InteropServices;

    [ProgId("MapOperate.CheckVersion"), Guid("99507C10-91AB-4f15-8D4A-4AFF36DD69EE"), ClassInterface(ClassInterfaceType.None)]
    public sealed class CheckVersion : BaseCommand
    {
        private IApplication application;

        public CheckVersion()
        {
            base.m_category = "VgsTiledMap";
            base.m_caption = "检查版本";
            base.m_message = "检查并更新最新版本";
            base.m_toolTip = base.m_message;
            base.m_name = "MapOperate.CheckVersion";
        }

        private static void ArcGISCategoryRegistration(Type registerType)
        {
            MxCommands.Register(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            MxCommands.Unregister(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        public void DrawRectangle(IActiveView activeView)
        {
            if (activeView != null)
            {
                IScreenDisplay screenDisplay = activeView.ScreenDisplay;
                screenDisplay.StartDrawing(screenDisplay.hDC, -1);
                RgbColorClass class2 = new RgbColorClass();
                class2.Green = 0xff;
                IRgbColor color = class2;
                IColor color2 = color;
                SimpleFillSymbolClass class3 = new SimpleFillSymbolClass();
                class3.Color = color2;
                ISimpleFillSymbol symbol = class3;
                ISymbol symbol2 = symbol as ISymbol;
                IRubberBand band = new RubberEnvelopeClass();
                IGeometry geometry = band.TrackNew(screenDisplay, symbol2);
                screenDisplay.SetSymbol(symbol2);
                screenDisplay.DrawRectangle(geometry as IEnvelope);
                screenDisplay.FinishDrawing();
            }
        }

        public override void OnClick()
        {
            IMxDocument document = (IMxDocument) this.application.Document;
            IActiveView focusMap = (IActiveView) document.FocusMap;
        }

        public override void OnCreate(object hook)
        {
            if (hook != null)
            {
                this.application = hook as IApplication;
                if (hook is IMxApplication)
                {
                    base.m_enabled = true;
                }
                else
                {
                    base.m_enabled = false;
                }
            }
        }

        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        [ComVisible(false), ComUnregisterFunction]
        private static void UnregisterFunction(Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }
    }
}

