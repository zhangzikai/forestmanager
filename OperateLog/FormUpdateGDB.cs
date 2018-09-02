namespace OperateLog
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.DataSourcesGDB;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using OperateLog.Properties;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;
    using td.logic.sys;
    using td.db.orm;
    using System.Collections.Generic;

    public class FormUpdateGDB : FormBase2
    {
        private IContainer components;
        private GroupBox groupBox1;
        internal Label LabelLoadInfo;
        private Label labelVersion;
        private ListBoxControl listBoxControl1;
        private int m_CurrentVersion;
        private string[] m_DateList = new string[] { 
            "", "", "", "", "", "", "", "", "20140605", "20140815", "20140827", "20140916", "20141016", "20141105", "20141109", "20141116",
            "20141118", "20141124"
        };
        private string[] m_VersionDesList = new string[] { 
            "小班添加字段", "添加遥感判断班块编辑权限", "修改数据精度", "代码调整", "小班添加字段2", "遥感图层添加字段", "征占用图层添加字段、修改采伐报表、更新区划代码", "更新检尺树种对照表", "更新检尺树种对照表2", "更新采伐数据结构", "更新遥感数据结构", "判读图斑编号的数据类型修改", "年度图层添加前期林地保护等级字段；数据来源代码修改", "采伐统计报表更新", "字段别名修改", "数据精度修改",
            "添加二类变化图层", "删除经营类型代码域"
        };
        private int[] m_VersionList = new int[] { 
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0x10,
            0x11, 0x12
        };
        private IWorkspace m_Workspace;
        private const string mClassName = "OperateLog.FormUpdateGDB";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
        private PanelControl panelBar;
        private Panel panelOK;
        private Panel panelUpdate;
        public SimpleButton simpleButtonCancel;
        public SimpleButton simpleButtonCheck;
        public SimpleButton simpleButtonDIY;
        public SimpleButton simpleButtonOK;

        public FormUpdateGDB()
        {
            this.InitializeComponent();
        }

        private bool AddELFeatureClass()
        {
            IWorkspace editWorkspace = null;
            if (EditTask.EditWorkspace != null)
            {
                editWorkspace = (IWorkspace) EditTask.EditWorkspace;
            }
            else
            {
                if (this.m_Workspace == null)
                {
                    this.m_Workspace = this.GetSDEworkspace();
                }
                if (this.m_Workspace == null)
                {
                    MessageBox.Show("数据库连接失败，无法升级！", "数据库升级");
                    return false;
                }
                editWorkspace = this.m_Workspace;
            }
            string str = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
            string str2 = str.Substring(str.Length - 4);
            IFeatureWorkspace pFWs = (IFeatureWorkspace) editWorkspace;
            IFeatureClass class2 = null;
            try
            {
                class2 = pFWs.OpenFeatureClass("FOR_XBBH_" + str2);
            }
            catch
            {
            }
            if (class2 == null)
            {
                MessageBox.Show("小班变化图层找不到，没有模板无法升级！", "数据库升级");
                return false;
            }
            return this.AddFeatureClass("FOR_ELBH_" + str2, "FOREST", pFWs, class2.Fields);
        }

        private bool AddFeatureClass(string sFCName, string sDatasetName, IFeatureWorkspace pFWs, IFields pFields)
        {
            try
            {
                IFeatureClass class2 = null;
                try
                {
                    class2 = pFWs.OpenFeatureClass(sFCName);
                }
                catch
                {
                }
                if (class2 == null)
                {
                    IFeatureClassDescription description = new FeatureClassDescriptionClass();
                    IObjectClassDescription description2 = (IObjectClassDescription) description;
                    if (sDatasetName == "")
                    {
                        class2 = pFWs.CreateFeatureClass(sFCName, pFields, description2.InstanceCLSID, description2.ClassExtensionCLSID, esriFeatureType.esriFTSimple, "Shape", "");
                    }
                    else
                    {
                        class2 = pFWs.OpenFeatureDataset(sDatasetName).CreateFeatureClass(sFCName, pFields, description2.InstanceCLSID, description2.ClassExtensionCLSID, esriFeatureType.esriFTSimple, "Shape", "");
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool AddField(IFeatureClass pFClass, string sNames, string sAliass, string sDomains, string sTypes, string sLengths, string sScales, ref int num)
        {
            try
            {
                string[] strArray = sNames.Split(new char[] { ',' });
                string[] strArray2 = sAliass.Split(new char[] { ',' });
                string[] strArray3 = sDomains.Split(new char[] { ',' });
                string[] sTypeList = sTypes.Split(new char[] { ',' });
                esriFieldType[] newType = this.GetNewType(sTypeList);
                string[] strArray5 = sLengths.Split(new char[] { ',' });
                int[] numArray = new int[strArray5.Length];
                if (sLengths != "")
                {
                    for (int j = 0; j < strArray5.Length; j++)
                    {
                        numArray[j] = Convert.ToInt16(strArray5[j]);
                    }
                }
                string[] strArray6 = sScales.Split(new char[] { ',' });
                int[] numArray2 = new int[strArray6.Length];
                if (sScales != "")
                {
                    for (int k = 0; k < strArray6.Length; k++)
                    {
                        numArray2[k] = Convert.ToInt16(strArray6[k]);
                    }
                }
                IWorkspace pWs = ((IDataset) pFClass).Workspace;
                for (int i = 0; i < strArray.Length; i++)
                {
                    string name = strArray[i];
                    if (pFClass.FindField(name) < 0)
                    {
                        IField field = new FieldClass();
                        IFieldEdit edit = (IFieldEdit) field;
                        edit.Name_2 = name;
                        edit.AliasName_2 = strArray2[i];
                        edit.Type_2 = newType[i];
                        if (newType[i] == esriFieldType.esriFieldTypeString)
                        {
                            edit.Length_2 = numArray[i];
                        }
                        if (newType[i] == esriFieldType.esriFieldTypeDouble)
                        {
                            edit.Precision_2 = 0x26;
                            edit.Scale_2 = numArray2[i];
                        }
                        if (strArray3[i] != "")
                        {
                            edit.Domain_2 = this.GetDomain(pWs, strArray3[i]);
                        }
                        pFClass.AddField(field);
                        num++;
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "OperateLog.FormUpdateGDB", "AddField", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show(exception.Message, "升级数据库");
                return false;
            }
        }

        private bool AddFields(string sNames, string sAliass, string sTypes, string sLengths, string sDomains, string sScales, bool bUpdateBH)
        {
            IWorkspace editWorkspace = null;
            if (EditTask.EditWorkspace != null)
            {
                editWorkspace = (IWorkspace) EditTask.EditWorkspace;
            }
            else
            {
                if (this.m_Workspace == null)
                {
                    this.m_Workspace = this.GetSDEworkspace();
                }
                if (this.m_Workspace == null)
                {
                    MessageBox.Show("数据库连接失败，无法升级！", "数据库升级");
                    return false;
                }
                editWorkspace = this.m_Workspace;
            }
            bool flag = false;
            string str = UtilFactory.GetConfigOpt().GetConfigValue2("AddFields", "FClassName");
            string str2 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
            string str3 = str2.Substring(str2.Length - 4);
            string name = str + "_" + str3;
            IFeatureClass pFClass = null;
            IFeatureWorkspace workspace2 = (IFeatureWorkspace) editWorkspace;
            try
            {
                pFClass = workspace2.OpenFeatureClass(name);
            }
            catch
            {
                MessageBox.Show("数据库无法打开指定图层，无法升级！", "数据库升级");
                return false;
            }
            int num = 0;
            ISchemaLock @lock = (ISchemaLock) pFClass;
            try
            {
                @lock.ChangeSchemaLock(esriSchemaLock.esriExclusiveSchemaLock);
                if (this.AddField(pFClass, sNames, sAliass, sDomains, sTypes, sLengths, sScales, ref num))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("升级失败！请检查是否有其他应用程序或用户正在连接数据库。", "数据库升级");
                return false;
            }
            @lock.ChangeSchemaLock(esriSchemaLock.esriSharedSchemaLock);
            if (!flag)
            {
                return false;
            }
            int num2 = Convert.ToInt16(str3) - 1;
            name = str + "_" + num2;
            IFeatureClass class3 = null;
            try
            {
                class3 = workspace2.OpenFeatureClass(name);
            }
            catch
            {
                MessageBox.Show("数据库无法打开指定图层，无法升级！", "数据库升级");
                return false;
            }
            num = 0;
            ISchemaLock lock2 = (ISchemaLock) class3;
            try
            {
                lock2.ChangeSchemaLock(esriSchemaLock.esriExclusiveSchemaLock);
                if (this.AddField(class3, sNames, sAliass, sDomains, sTypes, sLengths, sScales, ref num))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("升级失败！请检查是否有其他应用程序或用户正在连接数据库。", "数据库升级");
                flag = false;
                return false;
            }
            lock2.ChangeSchemaLock(esriSchemaLock.esriSharedSchemaLock);
            if (!flag)
            {
                return false;
            }
            if (bUpdateBH)
            {
                string str5 = UtilFactory.GetConfigOpt().GetConfigValue2("AddFieldsBH", "FClassName") + "_" + str3;
                IFeatureClass class4 = null;
                try
                {
                    class4 = workspace2.OpenFeatureClass(str5);
                }
                catch
                {
                    MessageBox.Show("数据库无法打开指定变化图层，无法升级！", "数据库升级");
                    return false;
                }
                ISchemaLock lock3 = (ISchemaLock) class4;
                try
                {
                    lock3.ChangeSchemaLock(esriSchemaLock.esriExclusiveSchemaLock);
                    if (this.AddField(class4, sNames, sAliass, sDomains, sTypes, sLengths, sScales, ref num))
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("升级失败！请检查是否有其他应用程序或用户正在连接数据库。", "数据库升级");
                    return false;
                }
                lock3.ChangeSchemaLock(esriSchemaLock.esriSharedSchemaLock);
            }
            return flag;
        }

        private bool AddYGFields(string sNames, string sAliass, string sTypes, string sLengths, string sDomains, string sScales)
        {
            IWorkspace pWs = null;
            if (EditTask.EditWorkspace != null)
            {
                pWs = (IWorkspace) EditTask.EditWorkspace;
            }
            else
            {
                if (this.m_Workspace == null)
                {
                    this.m_Workspace = this.GetSDEworkspace();
                }
                if (this.m_Workspace == null)
                {
                    MessageBox.Show("数据库连接失败，无法升级！", "数据库升级");
                    return false;
                }
                pWs = this.m_Workspace;
            }
            bool flag = false;
            string configValue = UtilFactory.GetConfigOpt().GetConfigValue("YGLayer");
            string str2 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
            string str3 = str2.Substring(str2.Length - 4);
            string name = configValue + "_" + str3;
            IFeatureClass pFClass = null;
            IFeatureWorkspace workspace2 = (IFeatureWorkspace) pWs;
            try
            {
                pFClass = workspace2.OpenFeatureClass(name);
            }
            catch
            {
                MessageBox.Show("数据库无法打开指定图层，无法升级！", "数据库升级");
                return false;
            }
            int num = 0;
            ISchemaLock @lock = (ISchemaLock) pFClass;
            try
            {
                @lock.ChangeSchemaLock(esriSchemaLock.esriExclusiveSchemaLock);
                if (this.AddField(pFClass, sNames, sAliass, sDomains, sTypes, sLengths, sScales, ref num))
                {
                    IDomain domain = this.GetDomain(pWs, "LDGLLX");
                    ((IClassSchemaEdit) pFClass).AlterDomain("LDGLLX", domain);
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("升级失败！请检查是否有其他应用程序或用户正在连接数据库。", "数据库升级");
                return false;
            }
            @lock.ChangeSchemaLock(esriSchemaLock.esriSharedSchemaLock);
            if (!flag)
            {
                return false;
            }
            return true;
        }

        private bool AddZZFields(string sNames, string sAliass, string sTypes, string sLengths, string sDomains, string sScales)
        {
            IWorkspace editWorkspace = null;
            if (EditTask.EditWorkspace != null)
            {
                editWorkspace = (IWorkspace) EditTask.EditWorkspace;
            }
            else
            {
                if (this.m_Workspace == null)
                {
                    this.m_Workspace = this.GetSDEworkspace();
                }
                if (this.m_Workspace == null)
                {
                    MessageBox.Show("数据库连接失败，无法升级！", "数据库升级");
                    return false;
                }
                editWorkspace = this.m_Workspace;
            }
            bool flag = false;
            string configValue = UtilFactory.GetConfigOpt().GetConfigValue("ZZYLayerName3");
            string str2 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
            string str3 = str2.Substring(str2.Length - 4);
            string[] strArray = configValue.Split(new char[] { ',' });
            IFeatureWorkspace workspace2 = (IFeatureWorkspace) editWorkspace;
            for (int i = 0; i < strArray.Length; i++)
            {
                string name = strArray[i] + "_" + str3;
                if (!name.Contains("ZT_L_LDZZ"))
                {
                    IFeatureClass pFClass = null;
                    try
                    {
                        pFClass = workspace2.OpenFeatureClass(name);
                    }
                    catch
                    {
                        MessageBox.Show("数据库无法打开指定图层，无法升级！", "数据库升级");
                        return false;
                    }
                    int num = 0;
                    ISchemaLock @lock = (ISchemaLock) pFClass;
                    try
                    {
                        @lock.ChangeSchemaLock(esriSchemaLock.esriExclusiveSchemaLock);
                        if (this.AddField(pFClass, sNames, sAliass, sDomains, sTypes, sLengths, sScales, ref num))
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("升级失败！请检查是否有其他应用程序或用户正在连接数据库。", "数据库升级");
                        return false;
                    }
                    @lock.ChangeSchemaLock(esriSchemaLock.esriSharedSchemaLock);
                    if (!flag)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool DeleteDomain(string sDomainName, string[] sLayers, string sFieldName)
        {
            try
            {
                IWorkspace editWorkspace = null;
                if (EditTask.EditWorkspace != null)
                {
                    editWorkspace = (IWorkspace) EditTask.EditWorkspace;
                }
                else
                {
                    if (this.m_Workspace == null)
                    {
                        this.m_Workspace = this.GetSDEworkspace();
                    }
                    if (this.m_Workspace == null)
                    {
                        MessageBox.Show("数据库连接失败，无法升级！", "数据库升级");
                        return false;
                    }
                    editWorkspace = this.m_Workspace;
                }
                IFeatureWorkspace workspace2 = (IFeatureWorkspace) editWorkspace;
                for (int i = 0; i < sLayers.Length; i++)
                {
                    IFeatureClass class2 = null;
                    try
                    {
                        class2 = workspace2.OpenFeatureClass(sLayers[i]);
                    }
                    catch
                    {
                        continue;
                    }
                    int index = class2.Fields.FindField(sFieldName);
                    if ((index >= 0) && (class2.Fields.get_Field(index).Domain != null))
                    {
                        ((IClassSchemaEdit) class2).AlterDomain(sFieldName, null);
                    }
                }
                IWorkspaceDomains2 domains = (IWorkspaceDomains2) editWorkspace;
                if (domains.get_DomainByName(sDomainName) != null)
                {
                    domains.DeleteDomain(sDomainName);
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "OperateLog.FormUpdateGDB", "DeleteDomain", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("更新域失败！", "数据库升级");
                return false;
            }
        }

        private bool DeleteDomain1(string sDomainName, string sFieldName)
        {
            try
            {
                IWorkspace editWorkspace = null;
                if (EditTask.EditWorkspace != null)
                {
                    editWorkspace = (IWorkspace) EditTask.EditWorkspace;
                }
                else
                {
                    if (this.m_Workspace == null)
                    {
                        this.m_Workspace = this.GetSDEworkspace();
                    }
                    if (this.m_Workspace == null)
                    {
                        MessageBox.Show("数据库连接失败，无法升级！", "数据库升级");
                        return false;
                    }
                    editWorkspace = this.m_Workspace;
                }
                IFeatureWorkspace workspace1 = (IFeatureWorkspace) editWorkspace;
                IEnumDataset dataset = editWorkspace.get_Datasets(esriDatasetType.esriDTAny);
                if (dataset != null)
                {
                    dataset.Reset();
                    IDataset dataset2 = dataset.Next();
                    while (dataset2 != null)
                    {
                        if (dataset2 is IFeatureDataset)
                        {
                            IFeatureDataset dataset3 = (IFeatureDataset) dataset2;
                            IFeatureClassContainer container = (IFeatureClassContainer) dataset3;
                            IEnumFeatureClass classes = container.Classes;
                            IFeatureClass class3 = classes.Next();
                            while (class3 != null)
                            {
                                int index = class3.Fields.FindField(sFieldName);
                                if (index < 0)
                                {
                                    class3 = classes.Next();
                                }
                                else
                                {
                                    if (class3.Fields.get_Field(index).Domain == null)
                                    {
                                        class3 = classes.Next();
                                        continue;
                                    }
                                    ((IClassSchemaEdit) class3).AlterDomain(sFieldName, null);
                                    class3 = classes.Next();
                                }
                            }
                        }
                        else if (dataset2 is IFeatureClass)
                        {
                            IFeatureClass class4 = dataset2 as IFeatureClass;
                            int num2 = class4.Fields.FindField(sFieldName);
                            if (num2 < 0)
                            {
                                dataset2 = dataset.Next();
                                continue;
                            }
                            if (class4.Fields.get_Field(num2).Domain == null)
                            {
                                dataset2 = dataset.Next();
                                continue;
                            }
                            ((IClassSchemaEdit) class4).AlterDomain(sFieldName, null);
                        }
                        dataset2 = dataset.Next();
                    }
                }
                IWorkspaceDomains2 domains = (IWorkspaceDomains2) editWorkspace;
                if (domains.get_DomainByName(sDomainName) != null)
                {
                    domains.DeleteDomain(sDomainName);
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "OperateLog.FormUpdateGDB", "DeleteDomain1", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("更新域失败！", "数据库升级");
                return false;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FormUpdateGDB_Load(object sender, EventArgs e)
        {
            this.panelBar.Visible = false;
            this.panelUpdate.Visible = false;
            this.labelVersion.Text = "";
        }

        private IDomain GetDomain(IWorkspace pWs, string sDomainName)
        {
            if (pWs == null)
            {
                return null;
            }
            IWorkspaceDomains domains = (IWorkspaceDomains) pWs;
            return domains.get_DomainByName(sDomainName);
        }

        private string GetExcuteSql(string sSqlFilePath)
        {
            FileInfo info = new FileInfo(sSqlFilePath);
            if (info.Exists)
            {
                return File.OpenText(sSqlFilePath).ReadToEnd();
            }
            return "";
        }

        private esriFieldType[] GetNewType(string[] sTypeList)
        {
            esriFieldType[] typeArray = new esriFieldType[sTypeList.Length];
            for (int i = 0; i < sTypeList.Length; i++)
            {
                if (sTypeList[i] == "double")
                {
                    typeArray[i] = esriFieldType.esriFieldTypeDouble;
                }
                else if (sTypeList[i] == "text")
                {
                    typeArray[i] = esriFieldType.esriFieldTypeString;
                }
                else if (sTypeList[i] == "shortint")
                {
                    typeArray[i] = esriFieldType.esriFieldTypeSmallInteger;
                }
                else if (sTypeList[i] == "longint")
                {
                    typeArray[i] = esriFieldType.esriFieldTypeInteger;
                }
                else if (sTypeList[i] == "float")
                {
                    typeArray[i] = esriFieldType.esriFieldTypeSingle;
                }
            }
            return typeArray;
        }

        private IWorkspace GetSDEworkspace()
        {
            string str = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "DataSource");
            string str2 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Service");
            string str3 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
            string str4 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Version");
            string str5 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "UserID");
            string str6 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Password");
            IPropertySet connectionProperties = null;
            IWorkspaceFactory factory = null;
            try
            {
                connectionProperties = new PropertySetClass();
                connectionProperties.SetProperty("SERVER", str);
                connectionProperties.SetProperty("INSTANCE", str2);
                connectionProperties.SetProperty("DATABASE", str3);
                connectionProperties.SetProperty("USER", str5);
                connectionProperties.SetProperty("PASSWORD", str6);
                connectionProperties.SetProperty("VERSION", str4);
                factory = new SdeWorkspaceFactoryClass();
                return factory.Open(connectionProperties, 0);
            }
            catch
            {
                return null;
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormUpdateGDB));
            this.panel1 = new Panel();
            this.panelUpdate = new Panel();
            this.panelBar = new PanelControl();
            this.LabelLoadInfo = new Label();
            this.panelOK = new Panel();
            this.simpleButtonOK = new SimpleButton();
            this.panel4 = new Panel();
            this.simpleButtonCancel = new SimpleButton();
            this.groupBox1 = new GroupBox();
            this.listBoxControl1 = new ListBoxControl();
            this.panel2 = new Panel();
            this.simpleButtonDIY = new SimpleButton();
            this.labelVersion = new Label();
            this.simpleButtonCheck = new SimpleButton();
            this.panel1.SuspendLayout();
            this.panelUpdate.SuspendLayout();
            this.panelBar.BeginInit();
            this.panelBar.SuspendLayout();
            this.panelOK.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize) this.listBoxControl1).BeginInit();
            this.panel2.SuspendLayout();
            base.SuspendLayout();
            this.panel1.Controls.Add(this.panelUpdate);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new Padding(0, 15, 0, 0);
            this.panel1.Size = new Size(0x155, 0x13b);
            this.panel1.TabIndex = 1;
            this.panelUpdate.Controls.Add(this.panelBar);
            this.panelUpdate.Controls.Add(this.panelOK);
            this.panelUpdate.Controls.Add(this.groupBox1);
            this.panelUpdate.Dock = DockStyle.Fill;
            this.panelUpdate.Location = new Point(0, 0x57);
            this.panelUpdate.Name = "panelUpdate";
            this.panelUpdate.Padding = new Padding(0, 10, 0, 0);
            this.panelUpdate.Size = new Size(0x155, 0xe4);
            this.panelUpdate.TabIndex = 15;
            this.panelBar.BorderStyle = BorderStyles.NoBorder;
            this.panelBar.Controls.Add(this.LabelLoadInfo);
            this.panelBar.Dock = DockStyle.Top;
            this.panelBar.Location = new Point(0, 0xbc);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new Size(0x155, 0x30);
            this.panelBar.TabIndex = 14;
            this.panelBar.Visible = false;
            this.LabelLoadInfo.BackColor = Color.Transparent;
            this.LabelLoadInfo.ForeColor = Color.FromArgb(0xff, 0x80, 0);
            this.LabelLoadInfo.Image = (Image) resources.GetObject("LabelLoadInfo.Image");
            this.LabelLoadInfo.ImageAlign = ContentAlignment.MiddleLeft;
            this.LabelLoadInfo.Location = new Point(70, 0x12);
            this.LabelLoadInfo.Name = "LabelLoadInfo";
            this.LabelLoadInfo.Size = new Size(0xd7, 0x13);
            this.LabelLoadInfo.TabIndex = 13;
            this.LabelLoadInfo.Text = "      正在升级，请稍候...";
            this.LabelLoadInfo.TextAlign = ContentAlignment.MiddleLeft;
            this.panelOK.Controls.Add(this.simpleButtonOK);
            this.panelOK.Controls.Add(this.panel4);
            this.panelOK.Controls.Add(this.simpleButtonCancel);
            this.panelOK.Dock = DockStyle.Top;
            this.panelOK.Location = new Point(0, 0x8a);
            this.panelOK.Name = "panelOK";
            this.panelOK.Padding = new Padding(0, 15, 20, 5);
            this.panelOK.Size = new Size(0x155, 50);
            this.panelOK.TabIndex = 2;
            this.simpleButtonOK.Dock = DockStyle.Right;
            this.simpleButtonOK.ImageIndex = 0x2e;
            this.simpleButtonOK.Location = new Point(0x9f, 15);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new Size(0x47, 30);
            this.simpleButtonOK.TabIndex = 13;
            this.simpleButtonOK.Text = "升级";
            this.simpleButtonOK.Click += new EventHandler(this.simpleButtonOK_Click);
            this.panel4.Dock = DockStyle.Right;
            this.panel4.Location = new Point(230, 15);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(20, 30);
            this.panel4.TabIndex = 12;
            this.simpleButtonCancel.Dock = DockStyle.Right;
            this.simpleButtonCancel.ImageIndex = 0x34;
            this.simpleButtonCancel.Location = new Point(250, 15);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new Size(0x47, 30);
            this.simpleButtonCancel.TabIndex = 10;
            this.simpleButtonCancel.Text = "取消";
            this.simpleButtonCancel.Click += new EventHandler(this.simpleButtonCancel_Click);
            this.groupBox1.Controls.Add(this.listBoxControl1);
            this.groupBox1.Dock = DockStyle.Top;
            this.groupBox1.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.groupBox1.Location = new Point(0, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new Padding(7, 10, 7, 3);
            this.groupBox1.Size = new Size(0x155, 0x80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "待升级内容";
            this.listBoxControl1.Dock = DockStyle.Fill;
            this.listBoxControl1.Location = new Point(7, 0x19);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.SelectionMode = SelectionMode.None;
            this.listBoxControl1.Size = new Size(0x147, 100);
            this.listBoxControl1.TabIndex = 0;
            this.panel2.Controls.Add(this.simpleButtonDIY);
            this.panel2.Controls.Add(this.labelVersion);
            this.panel2.Controls.Add(this.simpleButtonCheck);
            this.panel2.Dock = DockStyle.Top;
            this.panel2.Location = new Point(0, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x155, 0x48);
            this.panel2.TabIndex = 14;
            this.simpleButtonDIY.ImageIndex = 0x2e;
            this.simpleButtonDIY.Location = new Point(230, 3);
            this.simpleButtonDIY.Name = "simpleButtonDIY";
            this.simpleButtonDIY.Size = new Size(0x47, 30);
            this.simpleButtonDIY.TabIndex = 0x10;
            this.simpleButtonDIY.Text = "自定义升级";
            this.simpleButtonDIY.Click += new EventHandler(this.simpleButtonDIY_Click);
            this.labelVersion.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.labelVersion.Location = new Point(0x23, 0x30);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new Size(160, 0x11);
            this.labelVersion.TabIndex = 15;
            this.labelVersion.Text = "label1";
            this.simpleButtonCheck.ImageIndex = 0x2e;
            this.simpleButtonCheck.Location = new Point(0x17, 3);
            this.simpleButtonCheck.Name = "simpleButtonCheck";
            this.simpleButtonCheck.Size = new Size(0x7a, 0x1c);
            this.simpleButtonCheck.TabIndex = 14;
            this.simpleButtonCheck.Text = "查看当前数据库版本";
            this.simpleButtonCheck.Click += new EventHandler(this.simpleButtonCheck_Click);
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x155, 0x13b);
            base.Controls.Add(this.panel1);
//            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormUpdateGDB";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "数据库升级";
            base.Load += new EventHandler(this.FormUpdateGDB_Load);
            base.Controls.SetChildIndex(this.panel1, 0);
            base.Controls.SetChildIndex(base.sButOk, 0);
            this.panel1.ResumeLayout(false);
            this.panelUpdate.ResumeLayout(false);
            this.panelBar.EndInit();
            this.panelBar.ResumeLayout(false);
            this.panelOK.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((ISupportInitialize) this.listBoxControl1).EndInit();
            this.panel2.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void RefreshVersion()
        {
            this.panelUpdate.Visible = false;
            this.labelVersion.Text = "";
            try
            {
              
              //  string sCmdText = "select V_VALUE from T_SYS_DB_INFO where V_ITEM='VERSION'";
              //  string str2 = dBAccess.ExecuteScalar(sCmdText).ToString();
                string str2 = DBServiceFactory<MetaDataManager>.Service.DBVersion;
                this.labelVersion.Text = "当前数据版本：" + str2;
                int num = Convert.ToInt16(str2);
                if (num == (this.m_VersionList[this.m_VersionList.Length - 1] + 1))
                {
                    MessageBox.Show("当前数据库已为最新版本！", "数据库升级");
                }
                else
                {
                    this.m_CurrentVersion = num;
                    this.listBoxControl1.Items.Clear();
                    for (int i = num - 1; i < this.m_VersionDesList.Length; i++)
                    {
                        this.listBoxControl1.Items.Add(this.m_VersionDesList[i]);
                    }
                    this.panelUpdate.Visible = true;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "OperateLog.FormUpdateGDB", "RefreshVersion", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("查看数据库版本失败！", "数据库升级");
            }
        }

        public void SetCloseVisible(bool bVisible)
        {
            this.simpleButtonCancel.Visible = bVisible;
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void simpleButtonCheck_Click(object sender, EventArgs e)
        {
            this.RefreshVersion();
        }

        private void simpleButtonDIY_Click(object sender, EventArgs e)
        {
            new FormSQL().ShowDialog();
        }
        public MetaDataManager MDM
        {
            get { return DBServiceFactory<MetaDataManager>.Service; }
        }
        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            this.panelOK.Enabled = false;
            bool flag = true;
            for (int i = this.m_CurrentVersion - 1; i < this.m_VersionList.Length; i++)
            {
                string str28;
                IWorkspace editWorkspace;
                string str29;            
                string str48;
                string str49;
                string str50;
                if (!flag)
                {
                    break;
                }
                switch (this.m_VersionList[i])
                {
                    case 1:
                    {
                        flag = false;
                        string sNames = UtilFactory.GetConfigOpt().GetConfigValue2("AddFields", "FieldNames");
                        string sAliass = UtilFactory.GetConfigOpt().GetConfigValue2("AddFields", "FieldAliass");
                        string sTypes = UtilFactory.GetConfigOpt().GetConfigValue2("AddFields", "FieldTypes");
                        string sLengths = UtilFactory.GetConfigOpt().GetConfigValue2("AddFields", "FieldLengths");
                        string sDomains = UtilFactory.GetConfigOpt().GetConfigValue2("AddFields", "FieldDomains");
                        string sScales = UtilFactory.GetConfigOpt().GetConfigValue2("AddFields", "FieldScales");
                        flag = this.AddFields(sNames, sAliass, sTypes, sLengths, sDomains, sScales, false);
                        if (flag)
                        {
                            this.UpdateVersion(2);
                        }
                        continue;
                    }
                    case 2:
                    {
                        flag = false;
                        flag = this.UpdateUser("遥感", "遥感", "13");
                        if (flag)
                        {
                            this.UpdateVersion(3);
                        }
                        continue;
                    }
                    case 3:
                    {
                        flag = false;
                        flag = this.UpdateScale();
                        if (flag)
                        {
                            this.UpdateVersion(4);
                        }
                        continue;
                    }
                    case 4:
                    {
                        flag = false;
                        flag = this.Update4();
                        if (flag)
                        {
                            this.UpdateVersion(5);
                        }
                        continue;
                    }
                    case 5:
                    {
                        flag = false;
                        string str7 = "KJD,GBHJZSL,JYGLLX,GLLX";
                        string str8 = "采运可及度,高保护价值森林,经营管理类型,林地管理类型";
                        string str9 = "text,text,text,text";
                        string str10 = "1,1,1,2";
                        string str11 = "KJD,GBHJZSL,JYGLLX,LDGLLX";
                        string str12 = "0,0,0,0";
                        flag = this.AddFields(str7, str8, str9, str10, str11, str12, true);
                        if (flag)
                        {
                            this.UpdateVersion(6);
                        }
                        continue;
                    }
                    case 6:
                    {
                        flag = false;
                        string str13 = "PINGJUN_SG,PINGJUN_DM,PINGJUN_NL";
                        string str14 = "平均树高,每公顷断面,平均年龄";
                        string str15 = "double,double,shortint";
                        string str16 = "0,0,0";
                        string str17 = ",,";
                        string str18 = "1,1,0";
                        flag = this.AddYGFields(str13, str14, str15, str16, str17, str18);
                        if (flag)
                        {
                            this.UpdateVersion(7);
                        }
                        continue;
                    }
                    case 7:
                    {
                        flag = false;
                        string str19 = "PZWH,JLSJ";
                        string str20 = "批准文号,记录时间";
                        string str21 = "text,text,text";
                        string str22 = "50,8";
                        string str23 = ",";
                        string str24 = "0,0";
                        flag = this.AddZZFields(str19, str20, str21, str22, str23, str24);
                        if (flag)
                        {
                            string str25 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
                            string newValue = str25.Substring(str25.Length - 4);
                       
                            string dropReport = Resources.DropReport;
                            dropReport.Replace("2013", newValue);
                           // dBAccess.ExecuteNonQuery(dropReport);
                            MDM.UpdateDB(dropReport);
                            dropReport = Resources.CreateReport;
                            dropReport.Replace("2013", newValue);
                            if (MDM.UpdateDB(dropReport))
                            {
                                flag = this.UpdateDist();
                                if (flag)
                                {
                                    this.UpdateVersion(8);
                                }
                            }
                        }
                        continue;
                    }
                    case 8:
                    {
                        flag = false;
                        flag = this.UpdateJCSZ();
                        if (flag)
                        {
                            this.UpdateVersion(9);
                        }
                        continue;
                    }
                    case 9:
                    {
                        flag = false;
                        flag = this.UpdateJCSZ();
                        if (flag)
                        {
                            flag = this.UpdateReport();
                            if (flag)
                            {
                                this.UpdateVersion(10);
                            }
                        }
                        continue;
                    }
                    case 10:
                    {
                        flag = false;
                        flag = this.UpdateCF();
                        if (flag)
                        {
                            this.UpdateVersion(11);
                        }
                        continue;
                    }
                    case 11:
                        flag = false;
                        str28 = "ZT_YGJC";
                        editWorkspace = null;
                        if (EditTask.EditWorkspace == null)
                        {
                            break;
                        }
                        editWorkspace = (IWorkspace) EditTask.EditWorkspace;
                        goto Label_03C5;

                    case 12:
                    {
                        flag = false;
                        string str39 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
                        string str40 = str39.Substring(str39.Length - 4);
                        string sTableName = "ZT_YGJC_" + str40;
                        flag = this.UpdateNOTB(sTableName);
                        if (flag)
                        {
                            sTableName = "FOR_XBBH_" + str40;
                            flag = this.UpdateNOTB(sTableName);
                            if (flag)
                            {
                                this.UpdateVersion(13);
                            }
                        }
                        continue;
                    }
                    case 13:
                    {
                        flag = false;
                        string str42 = "Q_BH_DJ";
                        string str43 = "前期林地保护等级";
                        string str44 = "text";
                        string str45 = "1";
                        string str46 = "BH_DJ";
                        string str47 = "0";
                        flag = this.AddFields(str42, str43, str44, str45, str46, str47, true);
                        if (flag)
                        {
                            string[] pCodes = new string[] { "01", "02", "03", "04", "05", "07", "88", "99" };
                            string[] pNames = new string[] { "造林", "采伐", "火灾", "征占用", "自然灾害", "案件", "公益林", "遥感" };
                            flag = this.UpdateDomain("SJLY", "数据来源", pCodes, pNames);
                            if (flag)
                            {
                                this.UpdateVersion(14);
                            }
                        }
                        continue;
                    }
                    case 14:
                    {
                        flag = false;
                        //access3 = UtilFactory.GetDBAccess("SqlServer");
                        str48 = "IF OBJECT_ID('SP_STAT_CF_LMXJCC')IS NOT NULL DROP PROC SP_STAT_CF_LMXJCC";
                        MDM.UpdateDB(str48);
                        str49 = UtilFactory.GetConfigOpt().RootPath + @"\Data\ReportDDL\";
                        str50 = this.GetExcuteSql(str49 + "CFTJ2_Proc.sql").Replace("'", "''").Replace("\"", "\"\"");
                        str48 = "update T_STAT_REPORT set StoredProcedureSql='" + str50 + "' where Theme='CF' and ReportID=2";
                        if (MDM.UpdateDB(str48))
                        {
                            goto Label_079E;
                        }
                        MessageBox.Show("升级【采伐统计报表更新】失败！", "数据库升级");
                        flag = false;
                        continue;
                    }
                    case 15:
                    {
                        flag = false;
                        flag = this.UpdateSubAlias();
                        if (flag)
                        {
                            this.UpdateVersion(0x10);
                        }
                        continue;
                    }
                    case 0x10:
                    {
                        flag = false;
                        flag = this.UpdateScale();
                        if (flag)
                        {
                            this.UpdateVersion(0x11);
                        }
                        continue;
                    }
                    case 0x11:
                    {
                        flag = false;
                        flag = this.AddELFeatureClass();
                        if (flag)
                        {
                            flag = this.UpdateUser("二类变化", "二类变化", "14");
                            if (flag)
                            {
                                this.UpdateVersion(0x12);
                            }
                        }
                        continue;
                    }
                    case 0x12:
                    {
                        flag = false;
                        flag = this.DeleteDomain1("JYLX", "JYLX");
                        if (flag)
                        {
                            this.UpdateVersion(0x13);
                        }
                        continue;
                    }
                    default:
                    {
                        continue;
                    }
                }
                if (this.m_Workspace == null)
                {
                    this.m_Workspace = this.GetSDEworkspace();
                }
                if (this.m_Workspace == null)
                {
                    MessageBox.Show("数据库连接失败，无法升级！", "数据库升级");
                    flag = false;
                    continue;
                }
                editWorkspace = this.m_Workspace;
            Label_03C5:
                str29 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
                string str30 = str29.Substring(str29.Length - 4);
                string name = str28 + "_" + str30;
                IFeatureClass pFClass = null;
                IFeatureWorkspace workspace2 = (IFeatureWorkspace) editWorkspace;
                try
                {
                    pFClass = workspace2.OpenFeatureClass(name);
                }
                catch
                {
                    MessageBox.Show("数据库无法打开指定图层，无法升级！", "数据库升级");
                    flag = false;
                    continue;
                }
                ISchemaLock @lock = (ISchemaLock) pFClass;
                try
                {
                    @lock.ChangeSchemaLock(esriSchemaLock.esriExclusiveSchemaLock);
                    string str32 = "LMSYQ,MEI_GQ_ZS";
                    string str33 = "林木权属,每公顷株数";
                    string str34 = "text,longint";
                    string str35 = "2,0";
                    string str36 = "LMSYQ,";
                    string str37 = "0,0";
                    int num = 0;
                    flag = this.AddField(pFClass, str32, str33, str36, str34, str35, str37, ref num);
                    if (flag)
                    {
                        flag = this.UpdateFieldAlias(pFClass, "BCLD", "林地范围变化类型");
                        if (flag)
                        {
                            string[] strArray = new string[] { "1", "2", "3" };
                            string[] strArray2 = new string[] { "现状林地", "补充林地", "减少林地" };
                            flag = this.UpdateDomain("BCLD", "是否为补充林地", strArray, strArray2);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("升级失败！请检查是否有其他应用程序或用户正在连接数据库。", "数据库升级");
                    flag = false;
                }
                @lock.ChangeSchemaLock(esriSchemaLock.esriSharedSchemaLock);
                if (flag)
                {
                    string sCmdText = "insert into T_SYS_META_CODE(CCODE,CNAME,CSNAME,CTYPE,CDOMAIN,CINDEX,CYEAR,CLEN) values('3','减少林地','减少林地','是否为补充林地','BCLD','224',0,1)";
                    if (MDM.UpdateDB(sCmdText))
                    {
                        MessageBox.Show("升级失败！更新代码表失败。", "数据库升级");
                        flag = false;
                    }
                    else
                    {
                        this.UpdateVersion(12);
                    }
                }
                continue;
            Label_079E:
                str50 = this.GetExcuteSql(str49 + "CFTJ2_Sel.sql").Replace("'", "''").Replace("\"", "\"\"");
                str48 = "update T_STAT_REPORT set StaticSQL='" + str50 + "' where Theme='CF' and ReportID=2";
                if (!MDM.UpdateDB(str48))
                {
                    MessageBox.Show("升级【采伐统计报表更新】失败！", "数据库升级");
                    flag = false;
                }
                else
                {
                    flag = true;
                    this.UpdateVersion(15);
                }
            }
            if (this.m_Workspace != null)
            {
                Marshal.ReleaseComObject(this.m_Workspace);
                this.m_Workspace = null;
            }
            this.panelOK.Enabled = true;
            this.RefreshVersion();
        }

        private bool Update4()
        {
            bool flag = false;
            string sName = "XZWZL";
            string sCtype = "线状物类型";
            string[] pOldCodes = new string[] { "12", "13", "14", "15", "16", "17", "18", "19" };
            string[] pNewCodes = new string[] { "13", "14", "22", "23", "31", "32", "41", "42" };
            string[] pCodes = new string[] { "10", "11", "12", "13", "14", "20", "21", "22", "23", "30", "31", "32", "40", "41", "42" };
            string[] pNames = new string[] { "道路", "林区公路", "大林道", "国家及地方公路", "铁路", "江河", "溪河", "溪流", "水渠", "线路", "输电线路", "通讯线路", "防火线（林带）", "防火线", "防火林带" };
            flag = this.UpdateCode(sName, sCtype, "249", 2, pCodes, pNames, pOldCodes, pNewCodes);
            if (flag)
            {
                flag = this.UpdateDomain(sName, sCtype, pCodes, pNames);
                if (!flag)
                {
                    return flag;
                }
                sName = "SJLY";
                sCtype = "数据来源";
                string[] strArray5 = new string[] { "01", "02", "03", "04", "05", "07", "99" };
                string[] strArray6 = new string[] { "造林", "采伐", "火灾", "征占用", "自然灾害", "案件", "遥感" };
                flag = this.UpdateCode(sName, sCtype, "277", 2, strArray5, strArray6, null, null);
                if (!flag)
                {
                    return flag;
                }
                sName = "QI_YUAN";
                sCtype = "起源";
                string[] strArray7 = new string[] { "11", "12", "13", "21", "22", "23", "25", "26", "31", "32", "33", "34" };
                string[] strArray8 = new string[] { "天然", "人工促进天然更新", "萌芽", "植苗", "直播", "飞播林", "分植", "扦插", "人工林萌生1代", "人工林萌生2代", "人工林萌生3代", "人工林萌生4代及以上" };
                string[] strArray9 = new string[] { "24" };
                string[] strArray10 = new string[] { "31" };
                flag = this.UpdateCode(sName, sCtype, "213", 2, strArray7, strArray8, strArray9, strArray10);
                if (!flag)
                {
                    return flag;
                }
                flag = this.UpdateDomain(sName, sCtype, strArray7, strArray8);
                if (!flag)
                {
                    return flag;
                }
                sName = "JYCSLX";
                sCtype = "经营措施类型";
                string[] strArray11 = new string[] { 
                    "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16",
                    "17"
                };
                string[] strArray12 = new string[] { 
                    "幼林抚育", "定株抚育", "透光伐", "卫生伐", "生长伐", "生态疏伐", "景观疏伐", "主伐", "更新伐", "改造", "换冠", "修枝", "水肥管理", "人工造林", "封山育林", "补植",
                    "保留"
                };
                string[] strArray13 = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" };
                string[] strArray14 = new string[] { "3", "4", "5", "17", "8", "10", "14", "14", "16", "15" };
                flag = this.UpdateCode(sName, sCtype, "234", 2, strArray11, strArray12, strArray13, strArray14);
                if (!flag)
                {
                    return flag;
                }
                flag = this.UpdateDomain(sName, sCtype, strArray11, strArray12);
                if (!flag)
                {
                    return flag;
                }
                sName = "KJD";
                sCtype = "采运可及度";
                string[] strArray15 = new string[] { "1", "2", "3" };
                string[] strArray16 = new string[] { "即可及", "将可及", "不可及" };
                flag = this.UpdateCode(sName, sCtype, "278", 2, strArray15, strArray16, null, null);
                if (!flag)
                {
                    return flag;
                }
                flag = this.UpdateDomain(sName, sCtype, strArray15, strArray16);
                if (!flag)
                {
                    return flag;
                }
                sName = "GBHJZSL";
                sCtype = "高保护价值森林";
                string[] strArray17 = new string[] { "1", "2", "3", "4", "5", "6" };
                string[] strArray18 = new string[] { "生物多样性森林", "景观森林", "珍稀等生态系统森林", "生态服务型能森林", "基本需求型森林", "传统文化性森林" };
                flag = this.UpdateCode(sName, sCtype, "279", 2, strArray17, strArray18, null, null);
                if (!flag)
                {
                    return flag;
                }
                flag = this.UpdateDomain(sName, sCtype, strArray17, strArray18);
                if (!flag)
                {
                    return flag;
                }
                sName = "JYGLLX";
                sCtype = "经营管理类型";
                string[] strArray19 = new string[] { "1", "2", "3", "4" };
                string[] strArray20 = new string[] { "严格保护类", "重点保护类", "保护经营类", "集约经营类" };
                flag = this.UpdateCode(sName, sCtype, "280", 2, strArray19, strArray20, null, null);
                if (!flag)
                {
                    return flag;
                }
                flag = this.UpdateDomain(sName, sCtype, strArray19, strArray20);
                if (!flag)
                {
                    return flag;
                }
                sName = "LDGLLX";
                sCtype = "林地管理类型";
                flag = this.UpdateCode(sName, sCtype, "276", 2, strArray19, strArray20, null, null);
                if (!flag)
                {
                    return flag;
                }
                flag = this.UpdateDomain(sName, sCtype, strArray19, strArray20);
                if (!flag)
                {
                    return flag;
                }
            }
            return flag;
        }

        private bool UpdateCF()
        {
            try
            {
                //IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                //if (dBAccess == null)
                //{
                //    return false;
                //}
                string str = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
                string str2 = str.Substring(str.Length - 4);
                string name = "ZT_CF_" + str2;
                string str4 = "QTSM";
                IWorkspace editWorkspace = null;
                if (EditTask.EditWorkspace != null)
                {
                    editWorkspace = (IWorkspace) EditTask.EditWorkspace;
                }
                else
                {
                    if (this.m_Workspace == null)
                    {
                        this.m_Workspace = this.GetSDEworkspace();
                    }
                    if (this.m_Workspace == null)
                    {
                        MessageBox.Show("数据库连接失败，无法升级！", "数据库升级");
                        return false;
                    }
                    editWorkspace = this.m_Workspace;
                }
                IFeatureClass pFClass = null;
                IFeatureWorkspace workspace2 = (IFeatureWorkspace) editWorkspace;
                try
                {
                    pFClass = workspace2.OpenFeatureClass(name);
                }
                catch
                {
                    MessageBox.Show("数据库无法打开指定图层，无法升级！", "数据库升级");
                    return false;
                }
                int index = pFClass.Fields.FindField(str4);
                if (index < 0)
                {
                    MessageBox.Show("采伐图层中不存在其他说明字段！", "数据库升级");
                    return false;
                }
                bool flag = false;
                ISchemaLock @lock = (ISchemaLock) pFClass;
                try
                {
                    @lock.ChangeSchemaLock(esriSchemaLock.esriExclusiveSchemaLock);
                    IField field = pFClass.Fields.get_Field(index);
                    string sNames = "QTSM2";
                    int num = 0;
                    if (this.AddField(pFClass, sNames, "其他说明备份", "", "text", field.Length.ToString(), "", ref num))
                    {
                        string sCmdText = "update " + name + " set " + sNames + "=" + str4;
                        if (!MDM.UpdateDB(sCmdText))
                        {
                            flag = false;
                        }
                        else
                        {
                            pFClass.DeleteField(field);
                            if (this.AddField(pFClass, str4, "其他说明", "", "text", "250", "", ref num))
                            {
                                sCmdText = "update " + name + " set " + str4 + "=" + sNames;
                                if (!MDM.UpdateDB(sCmdText))
                                {
                                    flag = false;
                                }
                                else
                                {
                                    IField field2 = pFClass.Fields.get_Field(pFClass.FindField(sNames));
                                    pFClass.DeleteField(field2);
                                    flag = true;
                                }
                            }
                            else
                            {
                                flag = false;
                            }
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("升级失败！请检查是否有其他应用程序或用户正在连接数据库。", "数据库升级");
                    return false;
                }
                @lock.ChangeSchemaLock(esriSchemaLock.esriSharedSchemaLock);
                if (!flag)
                {
                    return false;
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "OperateLog.FormUpdateGDB", "UpdateCF", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("更新采伐数据结构失败！", "数据库升级");
                return false;
            }
        }

        private bool UpdateCode(string sName, string sCtype, string sCindex, int iClen, string[] pCodes, string[] pNames, string[] pOldCodes, string[] pNewCodes)
        {
            try
            {
               // IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                //if (dBAccess == null)
                //{
                //    MessageBox.Show("数据库连接失败！", "数据库升级");
                //    return false;
                //}
                string str = "T_SYS_META_CODE";
                string sCmdText = "";
                sCmdText = "delete from " + str + " where CTYPE='" + sCtype + "'";
                MDM.UpdateDB(sCmdText);
                sCmdText = "";
                for (int i = 0; i < pCodes.Length; i++)
                {
                    object obj2 = sCmdText;
                    sCmdText = string.Concat(new object[] { 
                        obj2, ";insert into ", str, "(CCODE,CNAME,CSNAME,CTYPE,CDOMAIN,CINDEX,CLEN) values('", pCodes[i], "','", pNames[i], "','", pNames[i], "','", sCtype, "','", sName, "','", sCindex, "',",
                        iClen, ")"
                    });
                }
                sCmdText = sCmdText.Substring(1);
                if (!MDM.UpdateDB(sCmdText))
                {
                    MessageBox.Show("修改" + sCtype + "代码失败！", "数据库升级");
                    return false;
                }
                if (pOldCodes != null)
                {
                    //20170223 jiayp 暂时不做
                    //sCmdText = "select distinct table_name from SDE_column_registry where column_name='" + sName + "'";
                    //DataTable dataTable = dBAccess.GetDataTable(dBAccess, sCmdText);
                    //if ((dataTable != null) && (dataTable.Rows.Count > 0))
                    //{
                    //    sCmdText = "";
                    //    for (int j = 0; j < dataTable.Rows.Count; j++)
                    //    {
                    //        for (int k = 0; k < pOldCodes.Length; k++)
                    //        {
                    //            object obj3 = sCmdText;
                    //            sCmdText = string.Concat(new object[] { obj3, ";update ", dataTable.Rows[j][0], " set ", sName, "='", pNewCodes[k], "' where ", sName, "='", pOldCodes[k], "'" });
                    //        }
                    //    }
                    //    sCmdText = sCmdText.Substring(1);
                    //    if (dBAccess.ExecuteNonQuery(sCmdText) < 0)
                    //    {
                    //        MessageBox.Show("修改" + sCtype + "代码失败！", "数据库升级");
                    //        return false;
                    //    }
                    //}
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "OperateLog.FormUpdateGDB", "UpdateCode", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("更新代码表失败！", "数据库升级");
                return false;
            }
        }

        private bool UpdateDist()
        {
            string[] source = new string[] { "450328002", "50328007", "450328001002", "450328006003" };
            string[] strArray2 = new string[] { "龙脊镇", "平等镇", "崇楼村", "李江村" };
            string sCmdText = "";
            for (int i = 0; i < source.Length; i++)
            {
                string str6 = sCmdText;
                string str7 = str6 + "update t_sys_meta_code set cname='" + strArray2[i] + "' where ccode='" + source[i] + "';";
                sCmdText = str7 + "update T_SYS_LD_ADMIN_CODES set cname='" + strArray2[i] + "' where ccode='" + source[i] + "';";
            }
            //if (UtilFactory.GetDBAccess("SqlServer").ExecuteNonQuery(sCmdText) < 0)
            //{
            //    MessageBox.Show("更新区划代码失败！", "数据库升级");
            //    return false;
            //}
            try
            {
                IWorkspace editWorkspace = null;
                if (EditTask.EditWorkspace != null)
                {
                    editWorkspace = (IWorkspace) EditTask.EditWorkspace;
                }
                else
                {
                    if (this.m_Workspace == null)
                    {
                        this.m_Workspace = this.GetSDEworkspace();
                    }
                    if (this.m_Workspace == null)
                    {
                        MessageBox.Show("数据库连接失败，无法升级！", "数据库升级");
                        return false;
                    }
                    editWorkspace = this.m_Workspace;
                }
                IWorkspaceDomains2 domains = (IWorkspaceDomains2) editWorkspace;
                string domainName = "XIANG";
                IDomain domain = domains.get_DomainByName(domainName);
                if (domain == null)
                {
                    return false;
                }
                ICodedValueDomain domain2 = (ICodedValueDomain) domain;
                ArrayList list = new ArrayList();
                ArrayList list2 = new ArrayList();
                for (int j = 0; j < domain2.CodeCount; j++)
                {
                    string str3 = domain2.get_Value(j).ToString();
                    list.Add(str3);
                    if (Enumerable.Contains<string>(source, str3))
                    {
                        int index = Enumerable.ToList<string>(source).IndexOf(str3);
                        list2.Add(strArray2[index]);
                    }
                    else
                    {
                        list2.Add(domain2.get_Name(j));
                    }
                }
                for (int k = 0; k < domain2.CodeCount; k++)
                {
                    domain2.DeleteCode(domain2.get_Value(k));
                    k--;
                }
                for (int m = 0; m < list.Count; m++)
                {
                    domain2.AddCode(list[m], list2[m].ToString());
                }
                domains.AlterDomain(domain);
                string str4 = "CUN";
                IDomain domain3 = domains.get_DomainByName(str4);
                if (domain3 == null)
                {
                    return false;
                }
                ICodedValueDomain domain4 = (ICodedValueDomain) domain3;
                ArrayList list3 = new ArrayList();
                ArrayList list4 = new ArrayList();
                for (int n = 0; n < domain4.CodeCount; n++)
                {
                    string str5 = domain4.get_Value(n).ToString();
                    list3.Add(str5);
                    if (Enumerable.Contains<string>(source, str5))
                    {
                        int num7 = Enumerable.ToList<string>(source).IndexOf(str5);
                        list4.Add(strArray2[num7]);
                    }
                    else
                    {
                        list4.Add(domain4.get_Name(n));
                    }
                }
                for (int num8 = 0; num8 < domain4.CodeCount; num8++)
                {
                    domain4.DeleteCode(domain4.get_Value(num8));
                    num8--;
                }
                for (int num9 = 0; num9 < list3.Count; num9++)
                {
                    domain4.AddCode(list3[num9], list4[num9].ToString());
                }
                domains.AlterDomain(domain3);
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "OperateLog.FormUpdateGDB", "UpdateDist", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("更新区划域失败！", "数据库升级");
                return false;
            }
        }

        private bool UpdateDomain(string sDomainName, string sDomainDes, string[] pCodes, string[] pNames)
        {
            try
            {
                IWorkspace editWorkspace = null;
                if (EditTask.EditWorkspace != null)
                {
                    editWorkspace = (IWorkspace) EditTask.EditWorkspace;
                }
                else
                {
                    if (this.m_Workspace == null)
                    {
                        this.m_Workspace = this.GetSDEworkspace();
                    }
                    if (this.m_Workspace == null)
                    {
                        MessageBox.Show("数据库连接失败，无法升级！", "数据库升级");
                        return false;
                    }
                    editWorkspace = this.m_Workspace;
                }
                IWorkspaceDomains2 domains = (IWorkspaceDomains2) editWorkspace;
                IDomain domain = domains.get_DomainByName(sDomainName);
                if (domain == null)
                {
                    ICodedValueDomain domain2 = new CodedValueDomainClass();
                    domain = (IDomain) domain2;
                    for (int i = 0; i < pCodes.Length; i++)
                    {
                        domain2.AddCode(pCodes[i], pNames[i]);
                    }
                    domain.Name = sDomainName;
                    domain.Description = sDomainDes;
                    domain.FieldType = esriFieldType.esriFieldTypeString;
                    domains.AddDomain(domain);
                }
                else
                {
                    ICodedValueDomain domain3 = (ICodedValueDomain) domain;
                    for (int j = 0; j < domain3.CodeCount; j++)
                    {
                        domain3.DeleteCode(domain3.get_Value(j));
                        j--;
                    }
                    for (int k = 0; k < pCodes.Length; k++)
                    {
                        domain3.AddCode(pCodes[k], pNames[k]);
                    }
                    domains.AlterDomain(domain);
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "OperateLog.FormUpdateGDB", "UpdateDomain", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("更新域失败！", "数据库升级");
                return false;
            }
        }

        private bool UpdateFieldAlias(IFeatureClass pFClass, string sField, string sAlias)
        {
            try
            {
                if (pFClass.FindField(sField) < 0)
                {
                    MessageBox.Show("指定图层中不存在字段" + sField + "，无法升级！", "数据库升级");
                    return false;
                }
                ((IClassSchemaEdit2) pFClass).AlterFieldAliasName(sField, sAlias);
            }
            catch (Exception)
            {
                MessageBox.Show("修改字段别名失败！", "数据库升级");
                return false;
            }
            return true;
        }

        private bool UpdateJCSZ()
        {
            try
            {
                string sCmdText = "";
                //IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
                //IDBAccess access2 = UtilFactory.GetDBAccess("SqlServer");
                string[] strArray = new string[] { "T_ZT_CF_SZ_JC_TO_CC", "T_ZT_CF_SZ_JC_TO_CZ" };
                string[] strArray2 = new string[] { "JCSZ,CCSZ", "JCSZ,CJSZ" };
                for (int i = 0; i < strArray.Length; i++)
                {
                    string str2 = strArray[i];
                    string sql = "select " + strArray2[i] + " from " + str2;
                    IList<IList<string>> lst=MDM.DBInfoService.ExecuteReaderSql(sql,2);                   
                 //   DataTable dataTable = dBAccess.GetDataTable(dBAccess, sql);
                    if ((lst == null) || (lst.Count < 1))
                    {
                        MessageBox.Show("更新检尺树种对照表时缺少需要的数据，升级失败！", "数据库升级");
                        return false;
                    }
                    sCmdText = "delete from " + str2;
                    if (!MDM.UpdateDB(sCmdText))
                    {
                        MessageBox.Show("更新检尺树种对照表失败！", "数据库升级");
                        return false;
                    }
                    sCmdText = "";
                    for (int j = 0; j < lst.Count; j++)
                    {
                        object obj2 = sCmdText;
                        sCmdText = string.Concat(new object[] { obj2, "insert into ", str2, "(OBJECTID,", strArray2[i], ") values(", j + 1, ",'", lst[j][0], "','", lst[j][1], "');" });
                    }
                    if (!MDM.UpdateDB(sCmdText))
                    {
                        MessageBox.Show("更新检尺树种对照表失败！", "数据库升级");
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                MessageBox.Show("更新检尺树种对照表失败！", "数据库升级");
                return false;
            }
        }

        private bool UpdateLZ()
        {
            try
            {
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "OperateLog.FormUpdateGDB", "UpdateLZ", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool UpdateNOTB(string sTableName)
        {
            try
            {
             //   IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                //if (dBAccess == null)
                //{
                //    return false;
                //}
                string name = "NO_TB";
                string sAliass = "判读图斑编号";
                IWorkspace editWorkspace = null;
                if (EditTask.EditWorkspace != null)
                {
                    editWorkspace = (IWorkspace) EditTask.EditWorkspace;
                }
                else
                {
                    if (this.m_Workspace == null)
                    {
                        this.m_Workspace = this.GetSDEworkspace();
                    }
                    if (this.m_Workspace == null)
                    {
                        MessageBox.Show("数据库连接失败，无法升级！", "数据库升级");
                        return false;
                    }
                    editWorkspace = this.m_Workspace;
                }
                IFeatureClass pFClass = null;
                IFeatureWorkspace workspace2 = (IFeatureWorkspace) editWorkspace;
                try
                {
                    pFClass = workspace2.OpenFeatureClass(sTableName);
                }
                catch
                {
                    MessageBox.Show("数据库无法打开指定图层，无法升级！", "数据库升级");
                    return false;
                }
                int index = pFClass.Fields.FindField(name);
                if (index < 0)
                {
                    MessageBox.Show("图层中不存在" + sAliass + "字段！", "数据库升级");
                    return false;
                }
                bool flag = false;
                ISchemaLock @lock = (ISchemaLock) pFClass;
                try
                {
                    @lock.ChangeSchemaLock(esriSchemaLock.esriExclusiveSchemaLock);
                    IField field = pFClass.Fields.get_Field(index);
                    string sNames = name + "2";
                    string sLengths = "20";
                    int num = 0;
                    if (this.AddField(pFClass, sNames, sAliass + "备份", "", "text", sLengths, "", ref num))
                    {
                        string sCmdText = "update " + sTableName + " set " + sNames + "=" + name;
                        if (!MDM.UpdateDB(sCmdText))
                        {
                            flag = false;
                        }
                        else
                        {
                            pFClass.DeleteField(field);
                            if (this.AddField(pFClass, name, sAliass, "", "text", sLengths, "", ref num))
                            {
                                sCmdText = "update " + sTableName + " set " + name + "=" + sNames;
                                if (!MDM.UpdateDB(sCmdText))
                                {
                                    flag = false;
                                }
                                else
                                {
                                    IField field2 = pFClass.Fields.get_Field(pFClass.FindField(sNames));
                                    pFClass.DeleteField(field2);
                                    flag = true;
                                }
                            }
                            else
                            {
                                flag = false;
                            }
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("升级失败！请检查是否有其他应用程序或用户正在连接数据库。", "数据库升级");
                    return false;
                }
                @lock.ChangeSchemaLock(esriSchemaLock.esriSharedSchemaLock);
                if (!flag)
                {
                    return false;
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "OperateLog.FormUpdateGDB", "UpdateCF", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("更新判读图斑编号数据类型失败！", "数据库升级");
                return false;
            }
        }

        private bool UpdateReport()
        {
            try
            {
                string sCmdText = "";
                //UtilFactory.GetDBAccess("Access");
                //IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                sCmdText = Resources.UpdateReport2;
                if (!MDM.UpdateDB(sCmdText))
                {
                    MessageBox.Show("更新统计报表失败！", "数据库升级");
                    return false;
                }
                sCmdText = Resources.DropReport2;
                MDM.UpdateDB(sCmdText);
                return true;
            }
            catch
            {
                MessageBox.Show("更新统计报表失败！", "数据库升级");
                return false;
            }
        }

        private bool UpdateScale()
        {
            try
            {
                //20170223 jiayp
                //string sql = "";
                //IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
                //sql = "select * from T_GDB_CHANGE";
                //DataTable dataTable = dBAccess.GetDataTable(dBAccess, sql);
                //if ((dataTable == null) || (dataTable.Rows.Count < 1))
                //{
                //    MessageBox.Show("更新数据库精度没有找到参考表！", "数据库升级");
                //    return false;
                //}
                //dBAccess = UtilFactory.GetDBAccess("SqlServer");
                //string str2 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
                //string str3 = str2.Substring(str2.Length - 4);
                //string newValue = (Convert.ToInt16(str3) - 1).ToString();
                //for (int i = 0; i < dataTable.Rows.Count; i++)
                //{
                //    sql = "";
                //    string str5 = dataTable.Rows[i]["table_name"].ToString().Replace("2013", newValue).Replace("2014", str3);
                //    string str6 = dataTable.Rows[i]["column_name"].ToString();
                //    string str7 = dataTable.Rows[i]["column_type"].ToString();
                //    string str8 = dataTable.Rows[i]["column_size"].ToString();
                //    switch (str7)
                //    {
                //        case "decimal":
                //        {
                //            string str9 = dataTable.Rows[i]["decimal_digits"].ToString();
                //            string str10 = "alter table " + str5 + " alter column " + str6 + " " + str7 + "(" + str8 + "," + str9 + ");";
                //            sql = str10 + "update SDE_column_registry set column_size=" + str8 + ",decimal_digits=" + str9 + " where column_name='" + str6 + "' and table_name='" + str5 + "'";
                //            break;
                //        }
                //        case "int":
                //        {
                //            string str11 = "alter table " + str5 + " alter column " + str6 + " " + str7 + ";";
                //            sql = str11 + "update SDE_column_registry set sde_type=2,column_size=" + str8 + ",decimal_digits=null where column_name='" + str6 + "' and table_name='" + str5 + "';";
                //            break;
                //        }
                //        case "nvarchar":
                //        {
                //            string str12 = "alter table " + str5 + " alter column " + str6 + " " + str7 + "(" + str8 + ");";
                //            sql = str12 + "update SDE_column_registry set column_size=" + str8 + " where column_name='" + str6 + "' and table_name='" + str5 + "';";
                //            break;
                //        }
                //    }
                //    if ((sql != "") && (dBAccess.ExecuteNonQuery(sql) < 0))
                //    {
                //        MessageBox.Show("更新数据库精度失败！", "数据库升级");
                //        return false;
                //    }
                //}
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "OperateLog.FormUpdateGDB", "UpdateScale", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("更新数据库精度失败！", "数据库升级");
                return false;
            }
        }

        private bool UpdateSubAlias()
        {
            IWorkspace editWorkspace = null;
            if (EditTask.EditWorkspace != null)
            {
                editWorkspace = (IWorkspace) EditTask.EditWorkspace;
            }
            else
            {
                if (this.m_Workspace == null)
                {
                    this.m_Workspace = this.GetSDEworkspace();
                }
                if (this.m_Workspace == null)
                {
                    MessageBox.Show("数据库连接失败，无法升级！", "数据库升级");
                    return false;
                }
                editWorkspace = this.m_Workspace;
            }
            bool flag = false;
            string str = "FOR_XIAOBAN";
            string str2 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
            string str3 = str2.Substring(str2.Length - 4);
            string name = str + "_" + str3;
            string str5 = str + "_" + ((Convert.ToInt16(str3) - 1)).ToString();
            IFeatureClass pFClass = null;
            IFeatureWorkspace workspace2 = (IFeatureWorkspace) editWorkspace;
            for (int i = 0; i < 2; i++)
            {
                ISchemaLock @lock;
                try
                {
                    switch (i)
                    {
                        case 0:
                            pFClass = workspace2.OpenFeatureClass(name);
                            goto Label_00EF;

                        case 1:
                            pFClass = workspace2.OpenFeatureClass(str5);
                            goto Label_00EF;
                    }
                }
                catch
                {
                    MessageBox.Show("数据库无法打开指定图层，无法升级！", "数据库升级");
                    return flag;
                }
            Label_00EF:
                @lock = (ISchemaLock) pFClass;
                try
                {
                    @lock.ChangeSchemaLock(esriSchemaLock.esriExclusiveSchemaLock);
                    flag = this.UpdateFieldAlias(pFClass, "BSSZPJXJ", "伴生树种平均胸径");
                    if (flag)
                    {
                        flag = this.UpdateFieldAlias(pFClass, "Q_BSSZPJXJ", "前期伴生树种平均胸径");
                        if (!flag)
                        {
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("升级失败！请检查是否有其他应用程序或用户正在连接数据库。", "数据库升级");
                    flag = false;
                }
                @lock.ChangeSchemaLock(esriSchemaLock.esriSharedSchemaLock);
                if (!flag)
                {
                    return flag;
                }
            }
            return flag;
        }

        private bool UpdateUser(string sAuthorName, string sSystemName, string sAuthorID)
        {
            try
            {
                //20170223 jiayp
                //IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                //if (dBAccess == null)
                //{
                //    return false;
                //}
                //string sCmdText = "";
                //sCmdText = "select AUTHOR_ID from T_SYS_FLOW_AUTHOR where SYSTEM_ZT='" + sSystemName + "'";
                //if (dBAccess.ExecuteScalar(sCmdText) == null)
                //{
                //    sCmdText = "insert into T_SYS_FLOW_AUTHOR(AUTHOR_ID,AUTHOR_NAME,AUTHOR_NOTE,SYSTEM_ZT) values(" + sAuthorID + ",'" + sAuthorName + "','" + sAuthorName + "','" + sSystemName + "')";
                //    if (dBAccess.ExecuteNonQuery(sCmdText) < 0)
                //    {
                //        return false;
                //    }
                //}
                //sCmdText = "select USER_ID from T_SYS_USER_AUTHOR where AUTHOR_ID='" + sAuthorID + "'";
                //if (dBAccess.ExecuteScalar(sCmdText) == null)
                //{
                //    sCmdText = "insert into T_SYS_USER_AUTHOR(USER_ID,AUTHOR_ID) values(1," + sAuthorID + ")";
                //    if (dBAccess.ExecuteNonQuery(sCmdText) < 0)
                //    {
                //        return false;
                //    }
                //}
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "OperateLog.FormUpdateGDB", "UpdateUser", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private void UpdateVersion(int iVersion)
        {
            try
            {
              //  IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                string sCmdText = ("update T_SYS_DB_INFO set V_VALUE= '" + iVersion + "' where V_ITEM='VERSION'") + ";update T_SYS_DB_INFO set V_VALUE= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' where V_ITEM='VDATE'";
                MDM.UpdateDB(sCmdText);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "OperateLog.FormUpdateGDB", "UpdateVersion", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
    }
}

