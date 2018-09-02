namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.SystemUI;
    using System;

    public class SOSOMenuDef : IMenuDef
    {
        public void GetItemInfo(int pos, IItemDef itemDef)
        {
            switch (pos)
            {
                case 0:
                    itemDef.ID = "AddSOSOMapCommand";
                    itemDef.Group = false;
                    return;

                case 1:
                    itemDef.ID = "AddSOSOSatelliteCommand";
                    itemDef.Group = false;
                    return;

                case 2:
                    itemDef.ID = "AddSOSOLabelsCommand";
                    itemDef.Group = false;
                    return;

                case 3:
                    itemDef.ID = "AddSOSOHybridCommand";
                    itemDef.Group = true;
                    return;
            }
        }

        public string Caption
        {
            get
            {
                return "腾讯地图(&Q)";
            }
        }

        public int ItemCount
        {
            get
            {
                return 4;
            }
        }

        public string Name
        {
            get
            {
                return "SOSOMap";
            }
        }
    }
}

