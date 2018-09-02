namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.Geometry;
    using System;

    public class SpatialReferences
    {
        private ISpatialReference GetGeographicSpatialReference(int gcsType)
        {
            ISpatialReferenceFactory factory = new SpatialReferenceEnvironmentClass();
            return factory.CreateGeographicCoordinateSystem(gcsType);
        }

        private ISpatialReference GetProjectedSpatialReference(int pcsType)
        {
            ISpatialReferenceFactory factory = new SpatialReferenceEnvironmentClass();
            return factory.CreateProjectedCoordinateSystem(pcsType);
        }

        public static string GetRDNew()
        {
            return "PROJCS[&quot;RD_New&quot;,GEOGCS[&quot;GCS_Amersfoort&quot;,DATUM[&quot;D_Amersfoort&quot;,SPHEROID[&quot;Bessel_1841&quot;,6377397.155,299.1528128]],PRIMEM[&quot;Greenwich&quot;,0.0],UNIT[&quot;Degree&quot;,0.0174532925199433]],PROJECTION[&quot;Double_Stereographic&quot;],PARAMETER[&quot;False_Easting&quot;,155000.0],PARAMETER[&quot;False_Northing&quot;,463000.0],PARAMETER[&quot;Central_Meridian&quot;,5.38763888888889],PARAMETER[&quot;Scale_Factor&quot;,0.9999079],PARAMETER[&quot;Latitude_Of_Origin&quot;,52.15616055555555],UNIT[&quot;Meter&quot;,1.0]]";
        }

        public ISpatialReference GetSpatialReference(string epsgCode)
        {
            ISpatialReference geographicSpatialReference = null;
            int startIndex = epsgCode.IndexOf(":") + 1;
            int length = epsgCode.Length;
            int pcsType = int.Parse(epsgCode.Substring(startIndex, length - startIndex));
            if ((pcsType == 0xdbf31) | (pcsType == 0xa029))
            {
                pcsType = 0x18ee1;
            }
            if (this.isProjectedSpatialReference(pcsType))
            {
                return this.GetProjectedSpatialReference(pcsType);
            }
            if (this.isGeographicSpatialReference(pcsType))
            {
                geographicSpatialReference = this.GetGeographicSpatialReference(pcsType);
            }
            return geographicSpatialReference;
        }

        public static string GetWebMercator()
        {
            return "PROJCS[&quot;WGS_1984_Web_Mercator&quot;,GEOGCS[&quot;GCS_WGS_1984_Major_Auxiliary_Sphere&quot;,DATUM[&quot;WGS_1984_Major_Auxiliary_Sphere&quot;,SPHEROID[&quot;WGS_1984_Major_Auxiliary_Sphere&quot;,6378137.0,0.0]],PRIMEM[&quot;Greenwich&quot;,0.0],UNIT[&quot;Degree&quot;,0.0174532925199433]],PROJECTION[&quot;Mercator_1SP&quot;],PARAMETER[&quot;False_Easting&quot;,0.0],PARAMETER[&quot;False_Northing&quot;,0.0],PARAMETER[&quot;Central_Meridian&quot;,0.0],PARAMETER[&quot;latitude_of_origin&quot;,0.0],UNIT[&quot;Meter&quot;,1.0]]";
        }

        public static string GetWGS84()
        {
            return "GEOGCS[&quot;GCS_WGS_1984&quot;,DATUM[&quot;WGS_1984&quot;,SPHEROID[&quot;WGS_1984&quot;,6378137.0,298.257223563]],PRIMEM[&quot;Greenwich&quot;,0.0],UNIT[&quot;Degree&quot;,0.0174532925199433]]";
        }

        private bool isGeographicSpatialReference(int gcsType)
        {
            try
            {
                ISpatialReferenceFactory factory = new SpatialReferenceEnvironmentClass();
                factory.CreateGeographicCoordinateSystem(gcsType);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool isProjectedSpatialReference(int pcsType)
        {
            try
            {
                ISpatialReferenceFactory factory = new SpatialReferenceEnvironmentClass();
                factory.CreateProjectedCoordinateSystem(pcsType);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

