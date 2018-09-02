namespace Cartography.Business
{
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.SystemUI;
    using System;

    public class TocMenu
    {
        private ToolbarMenu _menu = new ToolbarMenuClass();

        public TocMenu(ITOCControl2 pToc)
        {
            this._menu.SetHook(pToc);
            this._menu.AddItem(new SimpleRenderMenu(), 0, -1, false, esriCommandStyles.esriCommandStyleTextOnly);
            this._menu.AddItem(new UniqueValueRenderMenu(), 0, -1, false, esriCommandStyles.esriCommandStyleTextOnly);
            this._menu.AddItem(new UniqueValueMutliFieldRenderMenu(), 0, -1, false, esriCommandStyles.esriCommandStyleTextOnly);
            this._menu.AddItem(new QueryDefinitionMenu(), 0, -1, false, esriCommandStyles.esriCommandStyleTextOnly);
            this._menu.AddItem(new LayerRenderMenu(), 0, -1, false, esriCommandStyles.esriCommandStyleTextOnly);
            this._menu.AddItem(new LayerTransparent(), 0, -1, false, esriCommandStyles.esriCommandStyleTextOnly);
            this._menu.AddItem(new LabelRenderMenu(), 0, -1, false, esriCommandStyles.esriCommandStyleTextOnly);
            this._menu.AddItem(new ZoomToLayerMenu(), 0, -1, false, esriCommandStyles.esriCommandStyleTextOnly);
            this._menu.AddItem(new RemoveLayerMenu(), 0, -1, false, esriCommandStyles.esriCommandStyleTextOnly);
        }

        public void ShowMenu(int pX, int pY, int pHwnd)
        {
            this._menu.PopupMenu(pX, pY, pHwnd);
        }
    }
}

