namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using log4net;
    using System;
    using System.Collections;
    using System.Data;
    using System.Reflection;
    using System.Windows.Forms;

    public class VgsCustomLayerBase : Control, ILayer, ILegendInfo, IGeoDataset, IPersistVariant, ILayerGeneralProperties, ILayerExtensions, IDisposable
    {
        protected ArrayList extensions;
        protected IEnvelope extent;
        protected bool isCached;
        protected bool isCompiledDirty;
        protected bool isImmediateDirty;
        protected static readonly log4net.ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected ISpatialReference mapSpatialRef;
        protected double maximumScale;
        protected double minimumScale;
        protected string name = string.Empty;
        protected int recompileRate = -1;
        protected bool showTips;
        protected ISpatialReference spatialRef;
        protected DataTable table = new DataTable("RECORDS");
        protected UID uid;
        protected bool valid = true;
        protected bool visible = true;

        public VgsCustomLayerBase()
        {
            this.table.Columns.Add("ID", typeof(long));
            this.extent = new EnvelopeClass();
            this.extent.SetEmpty();
            this.uid = new UIDClass();
            this.extensions = new ArrayList();
            this.CreateHandle();
            base.CreateControl();
        }

        public virtual void AddExtension(object ext)
        {
            if (ext != null)
            {
                this.extensions.Add(ext);
            }
        }

        public virtual void AddItem(object[] values)
        {
            this.table.Rows.Add(values);
        }

        public virtual void AddItem(DataRow row)
        {
            this.table.Rows.Add(row);
        }

        public virtual void Clear()
        {
            this.table.Rows.Clear();
        }

        public void Dispose()
        {
            this.extent = null;
            this.spatialRef = null;
            base.Dispose();
        }

        public virtual void Draw(esriDrawPhase drawPhase, IDisplay Display, ITrackCancel trackCancel)
        {
        }

        public virtual object get_Extension(int Index)
        {
            if ((Index >= 0) && (Index <= (this.extensions.Count - 1)))
            {
                return this.extensions[Index];
            }
            return null;
        }

        public virtual ILegendGroup get_LegendGroup(int Index)
        {
            return null;
        }

        public virtual string get_TipText(double X, double Y, double Tolerance)
        {
            return null;
        }

        public IEnumerator GetEnumerator()
        {
            return this.table.Rows.GetEnumerator();
        }

        public virtual void Load(IVariantStream Stream)
        {
            this.extensions = (ArrayList) Stream.Read();
        }

        public virtual DataRow NewItem()
        {
            return this.table.NewRow();
        }

        public virtual void RemoveExtension(int Index)
        {
            if ((Index >= 0) && (Index <= (this.extensions.Count - 1)))
            {
                this.extensions.RemoveAt(Index);
            }
        }

        public virtual void RemoveItem(DataRow row)
        {
            this.table.Rows.Remove(row);
        }

        public virtual void Save(IVariantStream Stream)
        {
            Stream.Write(this.extensions);
        }

        public virtual DataRow[] Select(string queryFilter)
        {
            return this.table.Select(queryFilter);
        }

        public virtual IEnvelope AreaOfInterest
        {
            get
            {
                return this.extent;
            }
        }

        public virtual bool Cached
        {
            get
            {
                return this.isCached;
            }
            set
            {
                this.isCached = value;
            }
        }

        ISpatialReference ILayer.SpatialReference
        {
            set
            {
                this.mapSpatialRef = value;
            }
        }

        public virtual int ExtensionCount
        {
            get
            {
                return this.extensions.Count;
            }
        }

        public virtual IEnvelope Extent
        {
            get
            {
                return this.extent;
            }
        }

        public virtual UID ID
        {
            get
            {
                return null;
            }
        }

        public DataRow this[int index]
        {
            get
            {
                return this.table.Rows[index];
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

        public virtual int LegendGroupCount
        {
            get
            {
                return 0;
            }
        }

        public virtual ILegendItem LegendItem
        {
            get
            {
                return null;
            }
        }

        public virtual double MaximumScale
        {
            get
            {
                return this.maximumScale;
            }
            set
            {
                this.maximumScale = value;
            }
        }

        public virtual double MinimumScale
        {
            get
            {
                return this.minimumScale;
            }
            set
            {
                this.minimumScale = value;
            }
        }

        public virtual string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int NumOfRecords
        {
            get
            {
                return this.table.Rows.Count;
            }
        }

        public virtual bool ShowTips
        {
            get
            {
                return this.showTips;
            }
            set
            {
                this.showTips = value;
            }
        }

        public virtual ISpatialReference SpatialReference
        {
            get
            {
                return this.spatialRef;
            }
        }

        public int SupportedDrawPhases
        {
            get
            {
                return 1;
            }
        }

        public virtual bool SymbolsAreGraduated
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        public virtual bool Valid
        {
            get
            {
                return this.valid;
            }
        }

        public virtual bool Visible
        {
            get
            {
                return this.visible;
            }
            set
            {
                this.visible = value;
            }
        }
    }
}

