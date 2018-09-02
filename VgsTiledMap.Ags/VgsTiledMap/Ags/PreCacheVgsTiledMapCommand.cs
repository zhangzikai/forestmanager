namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.ArcMapUI;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Framework;
    using ESRI.ArcGIS.Geometry;
    using log4net.Config;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using VgsMap.Tile;
    using VgsTiledMap.Ags.Properties;

    [Guid("5F460058-6C69-4f0b-ACD5-FE2B9A3B4EF3"), ProgId("PreCacheVgsTiledMapCommand"), ClassInterface(ClassInterfaceType.None)]
    public sealed class PreCacheVgsTiledMapCommand : BaseCommand
    {
        private IApplication m_application;

        public PreCacheVgsTiledMapCommand()
        {
            base.m_category = "VgsTiledMap";
            base.m_caption = "(&P)预缓存地图数据...";
            base.m_message = "预缓存地图数据...";
            base.m_toolTip = base.m_caption;
            base.m_name = "PreCacheArcTilerCommand";
            base.m_bitmap = Resources.download;
        }

        private static void ArcGISCategoryRegistration(System.Type registerType)
        {
            MxCommands.Register(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        private static void ArcGISCategoryUnregistration(System.Type registerType)
        {
            MxCommands.Unregister(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        private VgsArcTileLayer GetFirstOsmArcTilerLayer(IMap map)
        {
            for (int i = 0; i < map.LayerCount; i++)
            {
                ILayer layer = map.get_Layer(i);
                if (layer.GetType() == typeof(VgsArcTileLayer))
                {
                    VgsArcTileLayer layer2 = layer as VgsArcTileLayer;
                    if (layer2.EnumArcTilerLayer == EnumArcVgsTileLayer.OSM)
                    {
                        return layer2;
                    }
                }
            }
            return null;
        }

        private int GetNumberOfTiles(ITileSchema schema, IEnvelope env)
        {
            for (int i = 0; i < schema.Resolutions.Count; i++)
            {
            }
            return 0;
        }

        public override void OnClick()
        {
            try
            {
                int num;
                XmlConfigurator.Configure(new FileInfo(Assembly.GetExecutingAssembly().Location + ".config"));
                string s = ConfigurationHelper.GetConfig().AppSettings.Settings["precacheStartLevel"].Value;
                s = "6";
                if (!int.TryParse(s, out num))
                {
                    MessageBox.Show("There is no minimum precache level defined in the config file. Please enter a valid levelnumber in the config file.");
                }
                else
                {
                    EnumArcVgsTileLayer oSM = EnumArcVgsTileLayer.OSM;
                    IMxDocument document = (IMxDocument) this.m_application.Document;
                    IMap focusMap = document.FocusMap;
                    bool flag = false;
                    VgsArcTileLayer firstOsmArcTilerLayer = this.GetFirstOsmArcTilerLayer(focusMap);
                    if (firstOsmArcTilerLayer != null)
                    {
                        if (firstOsmArcTilerLayer.Visible)
                        {
                            flag = firstOsmArcTilerLayer.CurrentLevel >= num;
                            if (!flag)
                            {
                                MessageBox.Show(string.Format("Error: The current OpenStreetMap layer level ({0}) is smaller than the minimum precache level ({1}).", firstOsmArcTilerLayer.CurrentLevel, num));
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error: The OpenStreetMap layer is not visible.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: There is no OpenStreetMap layer loaded.");
                    }
                    if (flag)
                    {
                        ITileSchema schema = ConfigHelper.GetConfig(oSM).CreateTileSource().Schema;
                        this.GetNumberOfTiles(schema, ((IActiveView) focusMap).Extent);
                        FormPreCache cache = new FormPreCache(firstOsmArcTilerLayer.CurrentLevel, 0x10);
                        if (cache.ShowDialog().Equals(DialogResult.OK))
                        {
                            int[] preCacheLevels = cache.preCacheLevels;
                            string preCacheAreaName = cache.preCacheAreaName;
                            cache.Close();
                            string cacheDir = System.IO.Path.Combine(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"VgsTiledMap.Ags\PreCache"), preCacheAreaName);
                            new Precache(new IntPtr(this.m_application.hWnd), document.ActiveView, oSM, focusMap.SpatialReference, cacheDir).RunPrecacher();
                        }
                        else
                        {
                            cache.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public override void OnCreate(object hook)
        {
            if (hook != null)
            {
                this.m_application = hook as IApplication;
                if (hook is IMxApplication)
                {
                    base.m_enabled = true;
                }
                else
                {
                    base.m_enabled = false;
                }
            }
        }

        [ComVisible(false), ComRegisterFunction]
        private static void RegisterFunction(System.Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(System.Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }
    }
}

