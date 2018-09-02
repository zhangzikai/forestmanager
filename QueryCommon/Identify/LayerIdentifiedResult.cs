namespace Identify
{
    using ESRI.ArcGIS.Carto;
    using System;
    using System.Collections.Generic;

    public class LayerIdentifiedResult
    {
        private LayerFeatureType geometryType;
        private List<IFeatureIdentifyObj> identifiedFeatureObjList = new List<IFeatureIdentifyObj>();
        private ILayer identifyLayer;

        public LayerFeatureType GeometryType
        {
            get
            {
                return this.geometryType;
            }
            set
            {
                this.geometryType = value;
            }
        }

        public List<IFeatureIdentifyObj> IdentifiedFeatureObjList
        {
            get
            {
                return this.identifiedFeatureObjList;
            }
        }

        public ILayer IdentifyLayer
        {
            get
            {
                return this.identifyLayer;
            }
            set
            {
                this.identifyLayer = value;
            }
        }
    }
}

