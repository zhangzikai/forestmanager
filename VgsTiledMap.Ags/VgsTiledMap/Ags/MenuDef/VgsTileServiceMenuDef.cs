namespace VgsTiledMap.Ags.MenuDef
{
    using ESRI.ArcGIS.SystemUI;
    using System;

    public class VgsTileServiceMenuDef : IMenuDef
    {
        public void GetItemInfo(int pos, IItemDef itemDef)
        {
            switch (pos)
            {
                case 0:
                    itemDef.ID = "AddVgsTileServiceCommand";
                    itemDef.Group = false;
                    return;

                case 1:
                    itemDef.ID = "AddVgsSatelliteCommand";
                    itemDef.Group = false;
                    return;
            }
        }

        public string Caption
        {
            get
            {
                return "(&L)林地一张图";
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
                return "VgsTileServiceMenuDef";
            }
        }
    }
}

