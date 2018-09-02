namespace VgsTiledMap.Ags.VgsTile.Configs
{
    using System;
    using System.Runtime.CompilerServices;
    using VgsMap.Tile;
    using VgsMap.Tile.Web;
    using VgsTiledMap.Ags;
    using VgsTiledMap.Ags.VgsTile.TileSources.TiandiTu;

    public class ConfigTiandiTu : IConfig
    {
    

        public ConfigTiandiTu(EnumArcVgsTileLayer lyrType)
        {
            this.LayerType = lyrType;
        }

        public ITileSource CreateTileSource()
        {
            IRequest request = null;
            switch (this.LayerType)
            {
                case EnumArcVgsTileLayer.TiandiTuAnno:
                    request = new VgsTiandiTuAnnoRequest();
                    break;

                case EnumArcVgsTileLayer.TiandiTu:
                    request = new VgsTiandiTuRequest();
                    break;

                case EnumArcVgsTileLayer.TiandiTuSatellite:
                    request = new VgsTiandituImgRequest();
                    break;

                case EnumArcVgsTileLayer.TiandiTuImgAnno:
                    request = new VgsTiandiTuImgAnnoRequest();
                    break;

                default:
                    request = null;
                    break;
            }
            if (request == null)
            {
                return null;
            }
            return new VgsTiandiTuTileSource(request);
        }

        public EnumArcVgsTileLayer LayerType
        {
            get;
            set;
        }
    }
}

