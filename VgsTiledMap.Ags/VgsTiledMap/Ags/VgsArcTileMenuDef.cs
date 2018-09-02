namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.SystemUI;
    using System;

    public class VgsArcTileMenuDef : IMenuDef
    {
        public void GetItemInfo(int pos, IItemDef itemDef)
        {
            switch (pos)
            {
                case 0:
                    itemDef.ID = "CheckUpdateCommand";
                    itemDef.Group = false;
                    return;

                case 1:
                    itemDef.ID = "AboutVgsTiledMapCommand";
                    itemDef.Group = true;
                    return;
            }
        }

        public string Caption
        {
            get
            {
                return "&帮助";
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
                return "VgsArcTileMenuDef";
            }
        }
    }
}

