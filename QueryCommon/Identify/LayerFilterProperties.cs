namespace Identify
{
    using ESRI.ArcGIS.Carto;
    using System;

    public class LayerFilterProperties
    {
        private string layerCategory;
        private Identify.LayerFeatureType layerFeatureType;
        private int layerFilterIndex;
        private string layerFilterName;
        private ILayer targetLayer;

        public string LayerCategory
        {
            get
            {
                return this.layerCategory;
            }
            set
            {
                this.layerCategory = value;
            }
        }

        public Identify.LayerFeatureType LayerFeatureType
        {
            get
            {
                return this.layerFeatureType;
            }
            set
            {
                this.layerFeatureType = value;
            }
        }

        public int LayerFilterIndex
        {
            get
            {
                return this.layerFilterIndex;
            }
            set
            {
                this.layerFilterIndex = value;
            }
        }

        public string LayerFilterName
        {
            get
            {
                return this.layerFilterName;
            }
            set
            {
                this.layerFilterName = value;
            }
        }

        public ILayer TargetLayer
        {
            get
            {
                return this.targetLayer;
            }
            set
            {
                this.targetLayer = value;
            }
        }
    }
}

