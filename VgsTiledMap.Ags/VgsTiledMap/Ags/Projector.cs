namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.Geometry;
    using System;

    public class Projector
    {
        public static IEnvelope ProjectEnvelope(IEnvelope envelope, string srs)
        {
            ISpatialReference spatialReference = new SpatialReferences().GetSpatialReference(srs);
            envelope.Project(spatialReference);
            return envelope;
        }
    }
}

