namespace ESRI.ArcGIS.Solutions.TileService
{
    using ESRI.ArcGIS.Geometry;
    using Microsoft.Win32;
    using System;
    using System.IO;
    using System.Net;
    using System.Runtime.InteropServices;

    [ClassInterface(ClassInterfaceType.None), ProgId("ESRI.ArcGIS.Solutions.TileService.GoogleMapTiledLayer"), Guid("F9A48C2A-1F98-40d4-AEE7-DE848FD7B7C9")]
    public class VgsGoogleTiledLayer : VgsTiledMapServiceLayer
    {
        private string _language = "en_US";
        private GoogleType _mapType = GoogleType.GoogleMap;
        public bool CorrectGoogleVersions = true;
        public string GoogleMapsAPIKey = "ABQIAAAAWaQgWiEBF3lW97ifKnAczhRAzBk5Igf8Z5n2W3hNnMT0j2TikxTLtVIGU7hCLLHMAuAMt-BO5UrEWA";
        private bool isCorrectedGoogleVersions;
        public string SecGoogleWord = "Galileo";
        public string VersionGoogleLabels = "h@179000000";
        public string VersionGoogleLabelsChina = "h@179000000";
        public string VersionGoogleLabelsKorea = "kr1t.12";
        public string VersionGoogleMap = "m@123";
        public string VersionGoogleMapChina = "m@123";
        public string VersionGoogleMapKorea = "kr1.12";
        public string VersionGoogleSatellite = "59";
        public string VersionGoogleSatelliteChina = "s@59";
        public string VersionGoogleSatelliteKorea = "59";
        public string VersionGoogleTerrain = "t@108,r@123";
        public string VersionGoogleTerrainChina = "t@108,r@123";

        public VgsGoogleTiledLayer()
        {
            base._tileInfo = this.createTileInfo();
        }

        private IEnvelope createExtent()
        {
            IEnvelope envelope = new EnvelopeClass();
            envelope.PutCoords(-20037508.342787, -20037508.342787, 20037508.342787, 20037508.342787);
            return envelope;
        }

        private TileInfo createTileInfo()
        {
            TileInfo info2 = new TileInfo();
            info2.Height = 0x100;
            info2.Width = 0x100;
            info2.Origin = new PointClass();
            TileInfo info = info2;
            info.Origin.PutCoords(-20037508.342787, 20037508.342787);
            info.SpatialReference = this.createWebMecatorProjection();
            info.Lods = new Lod[] { 
                new Lod(0, 156543.033928, 591657527.591555), new Lod(1, 78271.5169639999, 295828763.795777), new Lod(2, 39135.7584820001, 147914381.897889), new Lod(3, 19567.8792409999, 73957190.948944), new Lod(4, 9783.93962049996, 36978595.474472), new Lod(5, 4891.96981024998, 18489297.737236), new Lod(6, 2445.98490512499, 9244648.868618), new Lod(7, 1222.99245256249, 4622324.434309), new Lod(8, 611.49622628138, 2311162.217155), new Lod(9, 305.748113140558, 1155581.108577), new Lod(10, 152.874056570411, 577790.554289), new Lod(11, 76.4370282850732, 288895.277144), new Lod(12, 38.2185141425366, 144447.638572), new Lod(13, 19.1092570712683, 72223.819286), new Lod(14, 9.55462853563415, 36111.909643), new Lod(15, 4.77731426794937, 18055.954822),
                new Lod(0x10, 2.38865713397468, 9027.977411), new Lod(0x11, 1.19432856685505, 4513.988705), new Lod(0x12, 0.597164283559817, 2256.994353), new Lod(0x13, 0.298582141647617, 1128.497176)
            };
            return info;
        }

        private ISpatialReference createWebMecatorProjection()
        {
            ISpatialReferenceFactory factory = new SpatialReferenceEnvironmentClass();
            return factory.CreateProjectedCoordinateSystem(0x18ee1);
        }

        private string GetArcGISInstallPath()
        {
            if (!string.IsNullOrEmpty(this.ReadRegistry(@"SOFTWARE\Wow6432Node")))
            {
                return this.ReadRegistryValue(@"SOFTWARE\Wow6432Node\ESRI\CoreRuntime");
            }
            return this.ReadRegistryValue(@"SOFTWARE\ESRI\CoreRuntime");
        }

        private void GetSecGoogleWords(int row, int col, out string sec1, out string sec2)
        {
            sec1 = "";
            sec2 = "";
            int length = ((col * 3) + row) % 8;
            sec2 = this.SecGoogleWord.Substring(0, length);
            if ((row >= 0x2710) && (row < 0x186a0))
            {
                sec1 = "&s=";
            }
        }

        internal int GetServerNum(int row, int col, int max)
        {
            return ((col + (2 * row)) % max);
        }

        public override string GetTileUrl(int level, int row, int col)
        {
            return this.MakeImageUrl(this._mapType, row, col, level, this._language);
        }

        private string MakeImageUrl(GoogleType type, int row, int col, int zoom, string language)
        {
            switch (type)
            {
                case GoogleType.GoogleMap:
                {
                    string str = "mt";
                    string str2 = "vt";
                    string str3 = "";
                    string str4 = "";
                    this.GetSecGoogleWords(row, col, out str3, out str4);
                    this.TryCorrectGoogleVersions();
                    return string.Format("http://{0}{1}.google.com/{2}/lyrs={3}&hl={4}&x={5}{6}&y={7}&z={8}&s={9}", new object[] { str, this.GetServerNum(row, col, 4), str2, this.VersionGoogleMap, language, col, str3, row, zoom, str4 });
                }
                case GoogleType.GoogleSatellite:
                {
                    string str5 = "khm";
                    string str6 = "kh";
                    string str7 = "";
                    string str8 = "";
                    this.GetSecGoogleWords(row, col, out str7, out str8);
                    this.TryCorrectGoogleVersions();
                    return string.Format("http://{0}{1}.google.com/{2}/v={3}&hl={4}&x={5}{6}&y={7}&z={8}&s={9}", new object[] { str5, this.GetServerNum(row, col, 4), str6, this.VersionGoogleSatellite, language, col, str7, row, zoom, str8 });
                }
                case GoogleType.GoogleLabels:
                {
                    string str9 = "mt";
                    string str10 = "vt";
                    string str11 = "";
                    string str12 = "";
                    this.GetSecGoogleWords(row, col, out str11, out str12);
                    this.TryCorrectGoogleVersions();
                    return string.Format("http://{0}{1}.google.com/{2}/lyrs={3}&hl={4}&x={5}{6}&y={7}&z={8}&s={9}", new object[] { str9, this.GetServerNum(row, col, 4), str10, this.VersionGoogleLabels, language, col, str11, row, zoom, str12 });
                }
                case GoogleType.GoogleMapChina:
                {
                    string str13 = "mt";
                    string str14 = "vt";
                    string str15 = "";
                    string str16 = "";
                    this.GetSecGoogleWords(row, col, out str15, out str16);
                    this.TryCorrectGoogleVersions();
                    return string.Format("http://{0}{1}.google.cn/{2}/lyrs={3}&hl={4}&gl=cn&x={5}{6}&y={7}&z={8}&s={9}", new object[] { str13, this.GetServerNum(row, col, 4), str14, this.VersionGoogleMapChina, "zh-CN", col, str15, row, zoom, str16 });
                }
                case GoogleType.GoogleSatelliteChina:
                {
                    string str17 = "mt";
                    string str18 = "vt";
                    string str19 = "";
                    string str20 = "";
                    this.GetSecGoogleWords(row, col, out str19, out str20);
                    return string.Format("http://{0}{1}.google.cn/{2}/lyrs={3}&gl=cn&x={4}{5}&y={6}&z={7}&s={8}", new object[] { str17, this.GetServerNum(row, col, 4), str18, this.VersionGoogleSatelliteChina, col, str19, row, zoom, str20 });
                }
                case GoogleType.GoogleLabelsChina:
                {
                    string str21 = "mt";
                    string str22 = "vt";
                    string str23 = "";
                    string str24 = "";
                    this.GetSecGoogleWords(row, col, out str23, out str24);
                    this.TryCorrectGoogleVersions();
                    return string.Format("http://{0}{1}.google.cn/{2}/imgtp=png32&lyrs={3}&hl={4}&gl=cn&x={5}{6}&y={7}&z={8}&s={9}", new object[] { str21, this.GetServerNum(row, col, 4), str22, this.VersionGoogleLabelsChina, "zh-CN", col, str23, row, zoom, str24 });
                }
                case GoogleType.GoogleTerrainChina:
                {
                    string str25 = "mt";
                    string str26 = "vt";
                    string str27 = "";
                    string str28 = "";
                    this.GetSecGoogleWords(row, col, out str27, out str28);
                    this.TryCorrectGoogleVersions();
                    return string.Format("http://{0}{1}.google.com/{2}/lyrs={3}&hl={4}&gl=cn&x={5}{6}&y={7}&z={8}&s={9}", new object[] { str25, this.GetServerNum(row, col, 4), str26, this.VersionGoogleTerrainChina, "zh-CN", col, str27, row, zoom, str28 });
                }
                case GoogleType.GoogleTerrain:
                {
                    string str29 = "mt";
                    string str30 = "vt";
                    string str31 = "";
                    string str32 = "";
                    this.GetSecGoogleWords(row, col, out str31, out str32);
                    this.TryCorrectGoogleVersions();
                    return string.Format("http://{0}{1}.google.com/{2}/v={3}&hl={4}&x={5}{6}&y={7}&z={8}&s={9}", new object[] { str29, this.GetServerNum(row, col, 4), str30, this.VersionGoogleTerrain, language, col, str31, row, zoom, str32 });
                }
                case GoogleType.GoogleMapKorea:
                {
                    string str33 = "mt";
                    string str34 = "mt";
                    string str35 = "";
                    string str36 = "";
                    this.GetSecGoogleWords(row, col, out str35, out str36);
                    return string.Format("http://{0}{1}.gmaptiles.co.kr/{2}/v={3}&hl={4}&x={5}{6}&y={7}&z={8}&s={9}", new object[] { str33, this.GetServerNum(row, col, 4), str34, this.VersionGoogleMapKorea, language, col, str35, row, zoom, str36 });
                }
                case GoogleType.GoogleSatelliteKorea:
                {
                    string str37 = "khm";
                    string str38 = "kh";
                    string str39 = "";
                    string str40 = "";
                    this.GetSecGoogleWords(row, col, out str39, out str40);
                    return string.Format("http://{0}{1}.google.co.kr/{2}/v={3}&x={4}{5}&y={6}&z={7}&s={8}", new object[] { str37, this.GetServerNum(row, col, 4), str38, this.VersionGoogleSatelliteKorea, col, str39, row, zoom, str40 });
                }
                case GoogleType.GoogleLabelsKorea:
                {
                    string str41 = "mt";
                    string str42 = "mt";
                    string str43 = "";
                    string str44 = "";
                    this.GetSecGoogleWords(row, col, out str43, out str44);
                    return string.Format("http://{0}{1}.gmaptiles.co.kr/{2}/v={3}&hl={4}&x={5}{6}&y={7}&z={8}&s={9}", new object[] { str41, this.GetServerNum(row, col, 4), str42, this.VersionGoogleLabelsKorea, language, col, str43, row, zoom, str44 });
                }
            }
            return null;
        }

        private string ReadRegistry(string p)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(p, false);
            if (key != null)
            {
                return key.Name;
            }
            return string.Empty;
        }

        private string ReadRegistryValue(string p)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(p, false);
            if (key == null)
            {
                return "";
            }
            return (string) key.GetValue("InstallDir");
        }

        private void TryCorrectGoogleVersions()
        {
            if (this.CorrectGoogleVersions && !this.IsCorrectedGoogleVersions)
            {
                this.IsCorrectedGoogleVersions = true;
                string requestUriString = "http://maps.google.com";
                try
                {
                    HttpWebRequest request = (HttpWebRequest) WebRequest.Create(requestUriString);
                    if (base.Proxy != null)
                    {
                        request.Proxy = base.Proxy;
                        request.PreAuthenticate = true;
                    }
                    else
                    {
                        request.Proxy = WebRequest.DefaultWebProxy;
                    }
                    request.UserAgent = base.UserAgent;
                    request.Timeout = base.Timeout;
                    request.ReadWriteTimeout = base.Timeout * 6;
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                string str2 = reader.ReadToEnd();
                                int startIndex = str2.LastIndexOf("apiCallback([");
                                if (startIndex > 0)
                                {
                                    int index = str2.IndexOf("jslinker,pageArgs", startIndex);
                                    if (index > startIndex)
                                    {
                                        string str3 = str2.Substring(startIndex, index - startIndex);
                                        if (!string.IsNullOrEmpty(str3))
                                        {
                                            int num3 = 0;
                                            foreach (string str4 in str3.Split(new char[] { '[' }))
                                            {
                                                if (!str4.Contains("http://"))
                                                {
                                                    continue;
                                                }
                                                int num4 = str4.IndexOf("x3d");
                                                if (num4 > 0)
                                                {
                                                    int num5 = str4.IndexOf(@"\x26", num4);
                                                    if (num5 > num4)
                                                    {
                                                        num4 += 3;
                                                        string str5 = str4.Substring(num4, num5 - num4);
                                                        switch (num3)
                                                        {
                                                            case 0:
                                                                if (str5.StartsWith("m@"))
                                                                {
                                                                    this.VersionGoogleMap = str5;
                                                                }
                                                                break;

                                                            case 1:
                                                                if (char.IsDigit(str5[0]))
                                                                {
                                                                    this.VersionGoogleSatellite = str5;
                                                                }
                                                                break;

                                                            case 2:
                                                                if (str5.StartsWith("h@"))
                                                                {
                                                                    this.VersionGoogleLabels = str5;
                                                                }
                                                                break;

                                                            case 3:
                                                                if (str5.StartsWith("t@"))
                                                                {
                                                                    this.VersionGoogleTerrain = str5;
                                                                    this.VersionGoogleTerrainChina = str5;
                                                                }
                                                                return;
                                                        }
                                                        num3++;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public GoogleType GType
        {
            get
            {
                return this._mapType;
            }
            set
            {
                this._mapType = value;
            }
        }

        internal bool IsCorrectedGoogleVersions
        {
            get
            {
                return this.isCorrectedGoogleVersions;
            }
            set
            {
                this.isCorrectedGoogleVersions = value;
            }
        }

        public string Language
        {
            get
            {
                return this._language;
            }
            set
            {
                this._language = value;
            }
        }

        public enum GoogleType
        {
            GoogleHybrid = 20,
            GoogleHybridChina = 0x1d,
            GoogleHybridKorea = 0xfa5,
            GoogleLabels = 8,
            GoogleLabelsChina = 0x1a,
            GoogleLabelsKorea = 0xfa3,
            GoogleMap = 1,
            GoogleMapChina = 0x16,
            GoogleMapKorea = 0xfa1,
            GoogleSatellite = 4,
            GoogleSatelliteChina = 0x18,
            GoogleSatelliteKorea = 0xfa2,
            GoogleTerrain = 0x10,
            GoogleTerrainChina = 0x1c
        }
    }
}

