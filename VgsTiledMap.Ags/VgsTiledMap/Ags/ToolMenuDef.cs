namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.SystemUI;
    using System;

    public class ToolMenuDef : IMenuDef
    {
        public void GetItemInfo(int pos, IItemDef itemDef)
        {
            switch (pos)
            {
                case 0:
                    itemDef.ID = "DownloadCommand";
                    itemDef.Group = false;
                    return;

                case 1:
                    itemDef.ID = "ExportCommand";
                    itemDef.Group = false;
                    return;
            }
        }

        public string Caption
        {
            get
            {
                return "&工具";
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
                return "Tool";
            }
        }
    }
}

