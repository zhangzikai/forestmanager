namespace ESRI.ArcGIS.Solutions.TileService
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Collections;

    public abstract class VgsTiledCustomLayerBase : ILayer, IGeoDataset, IPersistVariant, ILayerGeneralProperties, IDisposable
    {
        protected bool m_bValid = true;
        protected ArrayList m_extensions;
        protected IEnvelope m_extent = new EnvelopeClass();
        protected bool m_IsCached;
        protected double m_MaximumScale;
        protected double m_MinimumScale;
        protected bool m_ShowTips;
        protected string m_sName = string.Empty;
        protected ISpatialReference m_spatialRef;
        protected UID m_uid;
        protected bool m_visible = true;

        public VgsTiledCustomLayerBase()
        {
            this.m_extent.SetEmpty();
            this.m_uid = new UIDClass();
            this.m_extensions = new ArrayList();
        }

        public virtual void AddExtension(object ext)
        {
            if (ext != null)
            {
                this.m_extensions.Add(ext);
            }
        }

        public void Dispose()
        {
            this.m_extent = null;
            this.m_spatialRef = null;
        }

        public abstract void Draw(esriDrawPhase drawPhase, IDisplay Display, ITrackCancel trackCancel);
        public virtual object get_Extension(int Index)
        {
            if ((Index >= 0) && (Index <= (this.m_extensions.Count - 1)))
            {
                return this.m_extensions[Index];
            }
            return null;
        }

        public virtual string get_TipText(double X, double Y, double Tolerance)
        {
            return null;
        }

        public virtual void Load(IVariantStream Stream)
        {
            this.m_extensions = (ArrayList) Stream.Read();
        }

        public virtual void RemoveExtension(int Index)
        {
            if ((Index >= 0) && (Index <= (this.m_extensions.Count - 1)))
            {
                this.m_extensions.RemoveAt(Index);
            }
        }

        public virtual void Save(IVariantStream Stream)
        {
            Stream.Write(this.m_extensions);
        }

        public virtual IEnvelope AreaOfInterest
        {
            get
            {
                return this.m_extent;
            }
        }

        public virtual bool Cached
        {
            get
            {
                return this.m_IsCached;
            }
            set
            {
                this.m_IsCached = value;
            }
        }

        ISpatialReference ILayer.SpatialReference
        {
            set
            {
                this.m_spatialRef = value;
            }
        }

        public virtual int ExtensionCount
        {
            get
            {
                return this.m_extensions.Count;
            }
        }

        public virtual IEnvelope Extent
        {
            get
            {
                return this.m_extent;
            }
        }

        public virtual UID ID
        {
            get
            {
                return null;
            }
        }

        public virtual double LastMaximumScale
        {
            get
            {
                return 0.0;
            }
        }

        public virtual double LastMinimumScale
        {
            get
            {
                return 0.0;
            }
        }

        public virtual string LayerDescription
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        public virtual double MaximumScale
        {
            get
            {
                return this.m_MaximumScale;
            }
            set
            {
                this.m_MaximumScale = value;
            }
        }

        public virtual double MinimumScale
        {
            get
            {
                return this.m_MinimumScale;
            }
            set
            {
                this.m_MinimumScale = value;
            }
        }

        public virtual string Name
        {
            get
            {
                return this.m_sName;
            }
            set
            {
                this.m_sName = value;
            }
        }

        public virtual bool ShowTips
        {
            get
            {
                return this.m_ShowTips;
            }
            set
            {
                this.m_ShowTips = value;
            }
        }

        public virtual ISpatialReference SpatialReference
        {
            get
            {
                return this.m_spatialRef;
            }
        }

        public int SupportedDrawPhases
        {
            get
            {
                return 1;
            }
        }

        public virtual bool Valid
        {
            get
            {
                return this.m_bValid;
            }
        }

        public virtual bool Visible
        {
            get
            {
                return this.m_visible;
            }
            set
            {
                this.m_visible = value;
            }
        }
    }
}

