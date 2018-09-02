namespace Cartography.Business
{
    using ESRI.ArcGIS.SystemUI;
    using System;

    internal class RenderMenu : IMenuDef
    {
        public void GetItemInfo(int pos, IItemDef itemDef)
        {
            switch (pos)
            {
                case 0:
                    itemDef.ID = "Cartography.Business.SimpleRender";
                    return;

                case 1:
                    itemDef.ID = "Cartography.Business.UniqueValueRenderMenu";
                    return;
            }
        }

        public string Caption
        {
            get
            {
                return "渲染";
            }
        }

        public int ItemCount
        {
            get
            {
                return 2;
            }
        }

        public string Name
        {
            get
            {
                return "渲染";
            }
        }
    }
}

