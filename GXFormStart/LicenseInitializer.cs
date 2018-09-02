namespace td.gis.fun
{
    using ESRI.ArcGIS;
    using ESRI.ArcGIS.esriSystem;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class LicenseInitializer
    {
        private bool bool_0 = false;
        private bool bool_1 = false;
        private bool bool_2 = true;
        private Dictionary<ESRI.ArcGIS.esriSystem.esriLicenseProductCode, ESRI.ArcGIS.esriSystem.esriLicenseStatus> dictionary_0 = new Dictionary<ESRI.ArcGIS.esriSystem.esriLicenseProductCode, ESRI.ArcGIS.esriSystem.esriLicenseStatus>();
        private Dictionary<esriLicenseExtensionCode, ESRI.ArcGIS.esriSystem.esriLicenseStatus> dictionary_1 = new Dictionary<esriLicenseExtensionCode, ESRI.ArcGIS.esriSystem.esriLicenseStatus>();
        private IAoInitialize iaoInitialize_0 = null;
        private List<int> list_0;
        private List<esriLicenseExtensionCode> list_1;
        private const string string_0 = "Invalid ArcGIS runtime binding.";
        private const string string_1 = "ArcObjects initialization failed.";
        private const string string_2 = "Product: No licenses were requested";
        private const string string_3 = "Product: {0}: Available";
        private const string string_4 = "Product: {0}: Not Licensed";
        private const string string_5 = " Extension: {0}: Available";
        private const string string_6 = " Extension: {0}: Not Licensed";
        private const string string_7 = " Extension: {0}: Failed";
        private const string string_8 = " Extension: {0}: Unavailable";

        public event EventHandler ResolveBindingEvent;
        private EventHandler eventHandler_0;

        public LicenseInitializer()
        {
            this.eventHandler_0 = (EventHandler) Delegate.Combine(this.eventHandler_0, new EventHandler(this.method_0));
        }

        public bool AddExtensions(params esriLicenseExtensionCode[] requestCodes)
        {
            if (this.list_1 == null)
            {
                this.list_1 = new List<esriLicenseExtensionCode>();
            }
            foreach (esriLicenseExtensionCode code in requestCodes)
            {
                if (!this.list_1.Contains(code))
                {
                    this.list_1.Add(code);
                }
            }
            if (!this.bool_1)
            {
                return false;
            }
            return this.method_2(this.InitializedProduct);
        }

        public bool InitializeApplication(ESRI.ArcGIS.esriSystem.esriLicenseProductCode[] productCodes, esriLicenseExtensionCode[] extensionLics)
        {
            this.list_0 = new List<int>();
            foreach (ESRI.ArcGIS.esriSystem.esriLicenseProductCode code in productCodes)
            {
                int item = Convert.ToInt32(code);
                if (!this.list_0.Contains(item))
                {
                    this.list_0.Add(item);
                }
            }
            this.AddExtensions(extensionLics);
            if (RuntimeManager.ActiveRuntime == null)
            {
                EventHandler handler = this.eventHandler_0;
                if (handler != null)
                {
                    handler(this, new EventArgs());
                }
            }
            return this.method_1();
        }

        public bool IsExtensionCheckedOut(esriLicenseExtensionCode code)
        {
            return ((this.iaoInitialize_0 != null) && this.iaoInitialize_0.IsExtensionCheckedOut(code));
        }

        public string LicenseMessage()
        {
            if (RuntimeManager.ActiveRuntime == null)
            {
                return "Invalid ArcGIS runtime binding.";
            }
            if (this.iaoInitialize_0 == null)
            {
                return "ArcObjects initialization failed.";
            }
            string str = string.Empty;
            string str2 = string.Empty;
            if (!((this.dictionary_0 != null) ? (this.dictionary_0.Count != 0) : false))
            {
                str = "Product: No licenses were requested" + Environment.NewLine;
            }
            else if (!this.dictionary_0.ContainsValue(ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseAlreadyInitialized) ? !this.dictionary_0.ContainsValue(ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseCheckedOut) : false)
            {
                foreach (KeyValuePair<ESRI.ArcGIS.esriSystem.esriLicenseProductCode, ESRI.ArcGIS.esriSystem.esriLicenseStatus> pair in this.dictionary_0)
                {
                    str = str + this.method_3(this.iaoInitialize_0 as ILicenseInformation, pair.Key, pair.Value) + Environment.NewLine;
                }
            }
            else
            {
                str = this.method_3(this.iaoInitialize_0 as ILicenseInformation, this.iaoInitialize_0.InitializedProduct(), ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseCheckedOut) + Environment.NewLine;
            }
            foreach (KeyValuePair<esriLicenseExtensionCode, ESRI.ArcGIS.esriSystem.esriLicenseStatus> pair2 in this.dictionary_1)
            {
                string str4 = this.method_4(this.iaoInitialize_0 as ILicenseInformation, pair2.Key, pair2.Value);
                if (!string.IsNullOrEmpty(str4))
                {
                    str2 = str2 + str4 + Environment.NewLine;
                }
            }
            return (str + str2).Trim();
        }

        private void method_0(object sender, EventArgs e)
        {
            if (!RuntimeManager.Bind(ProductCode.Engine))
            {
                MessageBox.Show("Invalid ArcGIS runtime binding. Application will shut down.");
                Environment.Exit(0);
            }
        }

        private bool method_1()
        {
            if (RuntimeManager.ActiveRuntime == null)
            {
                return false;
            }
            if (!((this.list_0 != null) ? (this.list_0.Count != 0) : false))
            {
                return false;
            }
            bool flag2 = false;
            this.list_0.Sort();
            if (!this.InitializeLowerProductFirst)
            {
                this.list_0.Reverse();
            }
            this.iaoInitialize_0 = new AoInitializeClass();
            ESRI.ArcGIS.esriSystem.esriLicenseProductCode code = (ESRI.ArcGIS.esriSystem.esriLicenseProductCode) 0;
            foreach (int num in this.list_0)
            {
                ESRI.ArcGIS.esriSystem.esriLicenseProductCode productCode = (ESRI.ArcGIS.esriSystem.esriLicenseProductCode) Enum.ToObject(typeof(ESRI.ArcGIS.esriSystem.esriLicenseProductCode), num);
                ESRI.ArcGIS.esriSystem.esriLicenseStatus status = this.iaoInitialize_0.IsProductCodeAvailable(productCode);
                if (status == ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseAvailable)
                {
                    status = this.iaoInitialize_0.Initialize(productCode);
                    if (!((status != ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseAlreadyInitialized) ? (status != ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseCheckedOut) : false))
                    {
                        flag2 = true;
                        code = this.iaoInitialize_0.InitializedProduct();
                    }
                }
                this.dictionary_0.Add(productCode, status);
                if (flag2)
                {
                    break;
                }
            }
            this.bool_1 = flag2;
            this.list_0.Clear();
            return (flag2 && this.method_2(code));
        }

        private bool method_2(ESRI.ArcGIS.esriSystem.esriLicenseProductCode esriLicenseProductCode_0)
        {
            bool flag = true;
            if (!((this.list_1 != null) ? (esriLicenseProductCode_0 == ((ESRI.ArcGIS.esriSystem.esriLicenseProductCode) 0)) : true))
            {
                foreach (esriLicenseExtensionCode code in this.list_1)
                {
                    ESRI.ArcGIS.esriSystem.esriLicenseStatus status = this.iaoInitialize_0.IsExtensionCodeAvailable(esriLicenseProductCode_0, code);
                    if (status == ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseAvailable)
                    {
                        status = this.iaoInitialize_0.CheckOutExtension(code);
                    }
                    flag = flag ? (status == ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseCheckedOut) : false;
                    if (this.dictionary_1.ContainsKey(code))
                    {
                        this.dictionary_1[code] = status;
                    }
                    else
                    {
                        this.dictionary_1.Add(code, status);
                    }
                }
                this.list_1.Clear();
            }
            return flag;
        }

        private string method_3(ILicenseInformation ilicenseInformation_0, ESRI.ArcGIS.esriSystem.esriLicenseProductCode esriLicenseProductCode_0, ESRI.ArcGIS.esriSystem.esriLicenseStatus esriLicenseStatus_0)
        {
            string licenseProductName = string.Empty;
            try
            {
                licenseProductName = ilicenseInformation_0.GetLicenseProductName(esriLicenseProductCode_0);
            }
            catch
            {
                licenseProductName = esriLicenseProductCode_0.ToString();
            }
            ESRI.ArcGIS.esriSystem.esriLicenseStatus status = esriLicenseStatus_0;
            if ((status != ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseAlreadyInitialized) && (status != ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseCheckedOut))
            {
                return string.Format("Product: {0}: Not Licensed", licenseProductName);
            }
            return string.Format("Product: {0}: Available", licenseProductName);
        }

        private string method_4(ILicenseInformation ilicenseInformation_0, esriLicenseExtensionCode esriLicenseExtensionCode_0, ESRI.ArcGIS.esriSystem.esriLicenseStatus esriLicenseStatus_0)
        {
            string licenseExtensionName = string.Empty;
            try
            {
                licenseExtensionName = ilicenseInformation_0.GetLicenseExtensionName(esriLicenseExtensionCode_0);
            }
            catch
            {
                licenseExtensionName = esriLicenseExtensionCode_0.ToString();
            }
            string str2 = string.Empty;
            ESRI.ArcGIS.esriSystem.esriLicenseStatus status = esriLicenseStatus_0;
            if (status > ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseFailure)
            {
                if ((status == ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseAlreadyInitialized) || (status == ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseCheckedOut))
                {
                    return string.Format(" Extension: {0}: Available", licenseExtensionName);
                }
                if (status == ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseCheckedIn)
                {
                    return str2;
                }
            }
            else
            {
                switch (status)
                {
                    case ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseUnavailable:
                        return string.Format(" Extension: {0}: Unavailable", licenseExtensionName);

                    case ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseFailure:
                        return string.Format(" Extension: {0}: Failed", licenseExtensionName);
                }
            }
            return string.Format(" Extension: {0}: Not Licensed", licenseExtensionName);
        }

        public void RemoveExtensions(params esriLicenseExtensionCode[] requestCodes)
        {
            if ((this.dictionary_1 != null) && (this.dictionary_1.Count != 0))
            {
                foreach (esriLicenseExtensionCode code in requestCodes)
                {
                    if (this.dictionary_1.ContainsKey(code) && (this.iaoInitialize_0.CheckInExtension(code) == ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseCheckedIn))
                    {
                        this.dictionary_1[code] = ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseCheckedIn;
                    }
                }
            }
        }

        public void ShutdownApplication()
        {
            if (!this.bool_0)
            {
                if (this.iaoInitialize_0 != null)
                {
                    foreach (KeyValuePair<esriLicenseExtensionCode, ESRI.ArcGIS.esriSystem.esriLicenseStatus> pair in this.dictionary_1)
                    {
                        if (((ESRI.ArcGIS.esriSystem.esriLicenseStatus) pair.Value) == ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseCheckedOut)
                        {
                            this.iaoInitialize_0.CheckInExtension(pair.Key);
                        }
                    }
                    this.iaoInitialize_0.Shutdown();
                }
                this.list_0 = null;
                this.list_1 = null;
                this.dictionary_1 = null;
                this.dictionary_0 = null;
                this.bool_0 = true;
            }
        }

        public ESRI.ArcGIS.esriSystem.esriLicenseProductCode InitializedProduct
        {
            get
            {
                if (this.iaoInitialize_0 != null)
                {
                    try
                    {
                        return this.iaoInitialize_0.InitializedProduct();
                    }
                    catch
                    {
                        return (ESRI.ArcGIS.esriSystem.esriLicenseProductCode) 0;
                    }
                }
                return (ESRI.ArcGIS.esriSystem.esriLicenseProductCode) 0;
            }
        }

        public bool InitializeLowerProductFirst
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                this.bool_2 = value;
            }
        }
    }
}

