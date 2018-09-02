namespace td.gis.fun
{
    using ESRI.ArcGIS;
    using ESRI.ArcGIS.esriSystem;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    /// <summary>
    /// 初始化监听类
    /// </summary>
    public class LicenseInitializer
    {
        private bool bool_0 = false;
        private bool bool_1 = false;
        private bool bool_2 = true;
        /// <summary>
        /// 字典键值对（Esri许可证产品代码，Esri许可证状态代码）
        /// </summary>
        private Dictionary<ESRI.ArcGIS.esriSystem.esriLicenseProductCode, ESRI.ArcGIS.esriSystem.esriLicenseStatus> dictionary_0 = new Dictionary<ESRI.ArcGIS.esriSystem.esriLicenseProductCode, ESRI.ArcGIS.esriSystem.esriLicenseStatus>();
        /// <summary>
        /// 字典键值对（Esri许可证扩展代码，Esri许可证状态代码）
        /// </summary>
        private Dictionary<esriLicenseExtensionCode, ESRI.ArcGIS.esriSystem.esriLicenseStatus> dictionary_1 = new Dictionary<esriLicenseExtensionCode, ESRI.ArcGIS.esriSystem.esriLicenseStatus>();
        /// <summary>
        /// IAoInitialize:提供对初始化ArcGIS Desktop，Engine和Server许可的成员的访问。
        /// IAoInitialize接口是开发人员使用适当的许可证初始化每个应用程序的起点，以便其在部署到的任何计算机上成功运行。
        /// 许可证配置必须在应用程序开始时间进行，然后才能访问任何ArcObjects。否则将导致应用程序错误。
        /// </summary>
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
        /// <summary>
        /// 解决捆绑事件。
        /// 
        /// EventHandler委托是一个预定义的委托，专门用于表示不生成数据的事件的事件处理程序方法。
        /// 如果事件确实生成数据，则必须使用通用的EventHandler <TEventArgs>委托类。
        /// </summary>
        public event EventHandler ResolveBindingEvent;
        /// <summary>
        /// 定义将处理不包含事件数据的事件方法
        /// </summary>
        private EventHandler eventHandler_0;

        /// <summary>
        /// 初始化监听:构造器（启动捆绑事件）
        /// </summary>
        public LicenseInitializer()
        {
            this.eventHandler_0 = (EventHandler) Delegate.Combine(this.eventHandler_0, new EventHandler(this.method_0));
        }

        /// <summary>
        /// 添加许可证扩展代码，封装进List。
        /// esriLicenseExtensionCode常量Esri许可证扩展代码。
        /// </summary>
        /// <param name="requestCodes"></param>
        /// <returns></returns>
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

        /// <summary>
        ///初始化APP：遍历监听产品代码至List
        /// </summary>
        /// <param name="productCodes"></param>
        /// <param name="extensionLics"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 监听消息
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 判断是否将ESRI许可的相关代码添加进字典键值对。（字典键值对（ESRI许可证产品代码，ESRI许可证状态代码））
        /// </summary>
        /// <returns></returns>
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
            //AoInitializeClass类初始化ArcObject组件运行时环境。 这个类必须是第一个创建的ArcObject。 构造函数没有输入参数。
            this.iaoInitialize_0 = new AoInitializeClass();
            //esriLicenseProductCode常量Esri许可证产品代码。
            ESRI.ArcGIS.esriSystem.esriLicenseProductCode code = (ESRI.ArcGIS.esriSystem.esriLicenseProductCode) 0;
            foreach (int num in this.list_0)
            {
                ESRI.ArcGIS.esriSystem.esriLicenseProductCode productCode = (ESRI.ArcGIS.esriSystem.esriLicenseProductCode) Enum.ToObject(typeof(ESRI.ArcGIS.esriSystem.esriLicenseProductCode), num);
                //esriLicenseStatus:Esri许可证状态代码。IsProductCodeAvailable方法返回指定的许可证是否可用。如果许可证可用，则可用于初始化应用程序。
                ESRI.ArcGIS.esriSystem.esriLicenseStatus status = this.iaoInitialize_0.IsProductCodeAvailable(productCode);
                //产品/扩展程序已获得许可并可用。
                if (status == ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseAvailable)
                {
                    status = this.iaoInitialize_0.Initialize(productCode);
                    //esriLicenseAlreadyInitialized:产品许可证已经初始化。 初始化只能执行一次。；esriLicenseCheckedOut:产品/扩展程序已成功检出。
                    if (!((status != ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseAlreadyInitialized) ? (status != ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseCheckedOut) : false))
                    {
                        flag2 = true;
                        //IAoInitialize.InitializedProduct方法:返回传递给Initialize方法的产品许可证。
                        //检查应用程序初始化的产品许可证对于设置应用程序功能的已启用状态很有用。
                        //例如，如果包含一些企业地理数据库编辑的应用程序已使用地理数据库编辑引擎单一使用或ArcGIS for Desktop Standard或ArcGIS for Desktop Advanced许可证进行初始化，则可以启用编辑功能。
                        //但是，如果应用程序已使用“引擎单一使用”或“ArcGIS for Desktop Basic”许可证进行初始化，则必须禁用编辑功能
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

        /// <summary>
        /// 判断是否将ESRI许可的相关代码添加进字典键值对。（字典键值对（ESRI许可证扩展代码，ESRI许可证状态代码））
        /// esriLicenseProductCode常量Esri许可证产品代码。
        /// </summary>
        /// <param name="esriLicenseProductCode_0"></param>
        /// <returns></returns>
        private bool method_2(ESRI.ArcGIS.esriSystem.esriLicenseProductCode esriLicenseProductCode_0)
        {
            bool flag = true;
            if (!((this.list_1 != null) ? (esriLicenseProductCode_0 == ((ESRI.ArcGIS.esriSystem.esriLicenseProductCode) 0)) : true))
            {//esriLicenseProductCode常量Esri许可证产品代码。
                foreach (esriLicenseExtensionCode code in this.list_1)
                {//esriLicenseStatus常量Esri许可证状态代码。
                    //IAoInitialize.IsExtensionCodeAvailable方法检查产品代码是否可用，然后检查该产品的扩展代码。
                    //IsExtensionCodeAvailable方法返回指定的扩展许可证是否可用于将用于初始化应用程序的指定产品许可证（不是每个扩展许可证都可用于每个产品许可证）。
                    //该方法首先检查产品许可证的可用性，然后再次使用产品许可证检查扩展许可证的可用性。
                    ESRI.ArcGIS.esriSystem.esriLicenseStatus status = this.iaoInitialize_0.IsExtensionCodeAvailable(esriLicenseProductCode_0, code);
                    //esriLicenseAvailable:产品/扩展程序已获得许可并可用。
                    if (status == ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseAvailable)
                    {//IAoInitialize.CheckOutExtension方法查看一个分机。
                        //检查指定的分机许可证。扩展可以在应用程序需要扩展功能时被检出，并在应用程序完成功能后一次检查;
                        //或者在应用程序初始化之后可以直接检出分机，并在关机前重新检查。使用CheckInExtension方法检查扩展。扩展检入和取出的方式将取决于传递给Initialize方法的产品许可证的类型。
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

        /// <summary>
        /// 是否初始化第一个低档产品（注释有误）
        /// </summary>
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

