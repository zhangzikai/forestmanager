namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.SystemUI;
    using System;

    public class GoogleMenuDef : IMenuDef
    {
        public void GetItemInfo(int pos, IItemDef itemDef)
        {
            switch (pos)
            {
                case 0:
                    itemDef.ID = "AddGoogleMapCommand";
                    itemDef.Group = false;
                    return;

                case 1:
                    itemDef.ID = "AddGoogleChinaSatelliteCommand";
                    itemDef.Group = false;
                    return;

                case 2:
                    itemDef.ID = "AddGoogleLabelsCommand";
                    itemDef.Group = false;
                    return;

                case 3:
                    itemDef.ID = "AddGoogleTerrainCommand";
                    itemDef.Group = false;
                    return;

                case 4:
                    itemDef.ID = "AddGoogleChinaHybridCommand";
                    itemDef.Group = false;
                    return;

                case 5:
                    itemDef.ID = "AddGoogleSatelliteCommand";
                    itemDef.Group = true;
                    return;
            }
        }

        public string Caption
        {
            get
            {
                return "谷歌地图(&Z)";
            }
        }

        public int ItemCount
        {
            get
            {
                return 6;
            }
        }

        public string Name
        {
            get
            {
                return "Google";
            }
        }
    }
}

