namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.SystemUI;
    using System;

    public class BingMenuDef : IMenuDef
    {
        public void GetItemInfo(int pos, IItemDef itemDef)
        {
            switch (pos)
            {
                case 0:
                    itemDef.ID = "AddBingRoadLayerCommand";
                    itemDef.Group = false;
                    return;

                case 1:
                    itemDef.ID = "AddBingAerialLayerCommand";
                    itemDef.Group = false;
                    return;
            }
        }

        public string Caption
        {
            get
            {
                return "(&B)Bing地图";
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
                return "BingMenuDef";
            }
        }
    }
}

