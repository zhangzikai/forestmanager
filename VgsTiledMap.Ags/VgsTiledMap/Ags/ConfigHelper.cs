namespace VgsTiledMap.Ags
{
    using System;
    using VgsMap.Tile.Web;

    public class ConfigHelper
    {
        public static IConfig GetConfig(EnumArcVgsTileLayer enumArcTilerLayer)
        {
            IConfig config = new ConfigOsm(OsmMapType.Default);
            if (enumArcTilerLayer == EnumArcVgsTileLayer.OSM)
            {
                return new ConfigOsm(OsmMapType.Default);
            }
            if (enumArcTilerLayer == EnumArcVgsTileLayer.OSMMapnik)
            {
                return new ConfigOsm(OsmMapType.Mapnik);
            }
            if (enumArcTilerLayer == EnumArcVgsTileLayer.OSMCycle)
            {
                return new ConfigOsm(OsmMapType.Cycle);
            }
            if (enumArcTilerLayer == EnumArcVgsTileLayer.BingRoad)
            {
                return new ConfigBing(BingMapType.Roads);
            }
            if (enumArcTilerLayer == EnumArcVgsTileLayer.BingHybrid)
            {
                return new ConfigBing(BingMapType.Hybrid);
            }
            if (enumArcTilerLayer == EnumArcVgsTileLayer.BingAerial)
            {
                return new ConfigBing(BingMapType.Aerial);
            }
            if (enumArcTilerLayer == EnumArcVgsTileLayer.ESRI)
            {
                return new ConfigEsri();
            }
            if (enumArcTilerLayer == EnumArcVgsTileLayer.TMS)
            {
                return new ConfigGeoserver();
            }
            if (enumArcTilerLayer == EnumArcVgsTileLayer.GeoserverWms)
            {
                return new ConfigGeodanGeoserver();
            }
            if (enumArcTilerLayer == EnumArcVgsTileLayer.SpatialCloud)
            {
                return new ConfigSpatialCloud();
            }
            if (enumArcTilerLayer == EnumArcVgsTileLayer.GoogleMaps)
            {
                return new ConfigGoogle(GoogleMapType.GoogleMap);
            }
            if (enumArcTilerLayer == EnumArcVgsTileLayer.GoogleSatellite)
            {
                return new ConfigGoogle(GoogleMapType.GoogleSatellite);
            }
            if (enumArcTilerLayer == EnumArcVgsTileLayer.GoogleChinaSatellite)
            {
                return new ConfigGoogle(GoogleMapType.GoogleChinaSatellite);
            }
            if (enumArcTilerLayer == EnumArcVgsTileLayer.GoogleLabels)
            {
                return new ConfigGoogle(GoogleMapType.GoogleLabels);
            }
            if (enumArcTilerLayer == EnumArcVgsTileLayer.GoogleTerrain)
            {
                return new ConfigGoogle(GoogleMapType.GoogleTerrain);
            }
            if (enumArcTilerLayer == EnumArcVgsTileLayer.SOSOSatellite)
            {
                return new ConfigSOSO(SOSOMapType.SOSOSatellite);
            }
            if (enumArcTilerLayer == EnumArcVgsTileLayer.SOSOMaps)
            {
                return new ConfigSOSO(SOSOMapType.SOSOMap);
            }
            if (enumArcTilerLayer == EnumArcVgsTileLayer.SOSOLabels)
            {
                config = new ConfigSOSO(SOSOMapType.SOSOLabels);
            }
            return config;
        }

        public static IConfig GetConfig(EnumArcVgsTileLayer enumArcTilerLayer, string Url, bool overwriteUrls)
        {
            if (enumArcTilerLayer == EnumArcVgsTileLayer.TMS)
            {
                return new ConfigTms(Url, overwriteUrls);
            }
            if (enumArcTilerLayer == EnumArcVgsTileLayer.InvertedTMS)
            {
                return new ConfigInvertedTMS(Url);
            }
            return new ConfigOsm(OsmMapType.Default);
        }

        public static IConfig GetTmsConfig(string url, bool overwriteUrls)
        {
            return new ConfigTms(url, overwriteUrls);
        }
    }
}

