namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.SystemUI;
    using System;

    public class OsmMenuDef : IMenuDef
    {
        public void GetItemInfo(int pos, IItemDef itemDef)
        {
            switch (pos)
            {
                case 0:
                    itemDef.ID = "AddOsmLayerCommand";
                    itemDef.Group = false;
                    return;

                case 1:
                    itemDef.ID = "AddOsmTilesAtHomeLayerCommand";
                    itemDef.Group = false;
                    return;

                case 2:
                    itemDef.ID = "AddOsmCycleLayerCommand";
                    itemDef.Group = false;
                    return;
            }
        }

        public string Caption
        {
            get
            {
                return "&OpenStreetMap";
            }
        }

        public int ItemCount
        {
            get
            {
                return 3;
            }
        }

        public string Name
        {
            get
            {
                return "林地一张图数据管理";
            }
        }
    }
}

