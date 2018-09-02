namespace VgsTiledMap.Ags.VgsTile.MenuDef
{
    using ESRI.ArcGIS.SystemUI;
    using System;

    public class TiandiTuMenuDef : IMenuDef
    {
        public void GetItemInfo(int pos, IItemDef itemDef)
        {
            switch (pos)
            {
                case 0:
                    itemDef.ID = "AddTiandTuEMapAnnoCommand";
                    itemDef.Group = false;
                    return;

                case 1:
                    itemDef.ID = "AddTiandTuEMapCommand";
                    itemDef.Group = true;
                    return;

                case 2:
                    itemDef.ID = "AddTiandTuImgAnnoCommand";
                    itemDef.Group = true;
                    return;

                case 3:
                    itemDef.ID = "AddTiandTuImgCommand";
                    itemDef.Group = true;
                    return;
            }
        }

        public string Caption
        {
            get
            {
                return "&天地图";
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
                return "TiandiTuMenuDef";
            }
        }
    }
}

