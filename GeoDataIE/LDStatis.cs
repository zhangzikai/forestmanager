namespace GeoDataIE
{
    using ESRI.ArcGIS.DataManagementTools;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.Geoprocessing;
    using ESRI.ArcGIS.Geoprocessor;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    using Utilities;
    using td.logic.sys;
    using td.db.orm;

    public class LDStatis
    {
        private string m_LDFields = "SHENG,XIAN,XIANG,CUN,LIN_YE_JU,LIN_CHANG,LIN_BAN,XIAO_BAN,DI_MAO,PO_XIANG,PO_WEI,KE_JI_DU,TU_RANG_LX,TU_CENG_HD,MIAN_JI,LD_QS,DI_LEI,LIN_ZHONG,QI_YUAN,SEN_LIN_LB,SHI_QUAN_D,GJGYL_BHDJ,G_CHENG_LB,LING_ZU,YU_BI_DU,YOU_SHI_SZ,PINGJUN_XJ,HUO_LMGQXJ,MEI_GQ_ZS,TD_TH_LX,DISPE,DISASTER_C,ZL_DJ,LD_KD,LD_CD,BCLD,BH_DJ,LYFQ,QYKZ,BHYY,BHND,GLLX,Remarks,PO_DU,Q_LD_QS,Q_DI_LEI,Q_L_Z,Q_SEN_LB,Q_SQ_D,Q_GC_LB,Q_BH_DJ";
        private const string mClassName = "GeoDataIE.LDStatis";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public void ClearMemory()
        {
            try
            {
                Process process = new Process();
                ProcessStartInfo info = new ProcessStartInfo(Application.StartupPath + @"\MemoryClean.exe");
                process.StartInfo = info;
                process.StartInfo.UseShellExecute = false;
                process.Start();
            }
            catch
            {
            }
        }

        private void CopyBHAttirbutes(IObject pSrcObj, IObject pTargObj)
        {
            IFields fields = pTargObj.Fields;
            for (int i = 0; i < fields.FieldCount; i++)
            {
                if (fields.get_Field(i).Editable && (fields.get_Field(i).Type != esriFieldType.esriFieldTypeGeometry))
                {
                    string name = fields.get_Field(i).Name;
                    int index = pSrcObj.Fields.FindField(name);
                    if (index >= 0)
                    {
                        object obj2 = pSrcObj.get_Value(index);
                        pTargObj.set_Value(i, obj2);
                    }
                }
            }
        }

        private void CopyLDAttirbutes(IObject pSrcObj, IObject pTargObj)
        {
            IFields fields = pTargObj.Fields;
            for (int i = 0; i < fields.FieldCount; i++)
            {
                if (fields.get_Field(i).Editable && (fields.get_Field(i).Type != esriFieldType.esriFieldTypeGeometry))
                {
                    string name = fields.get_Field(i).Name;
                    if (name == "Q_L_Z")
                    {
                        name = "Q_LIN_ZHONG";
                    }
                    int index = pSrcObj.Fields.FindField(name);
                    if (index >= 0)
                    {
                        object obj2 = pSrcObj.get_Value(index);
                        if ((((name == "XIANG") || (name == "CUN")) || (name == "LIN_CHANG")) && ((obj2 != null) && (obj2.ToString().Length > 3)))
                        {
                            string str2 = obj2.ToString();
                            obj2 = str2.Substring(str2.Length - 3, 3);
                        }
                        if ((name == "PO_DU") && (obj2 != null))
                        {
                            string s = obj2.ToString();
                            try
                            {
                                obj2 = int.Parse(s);
                            }
                            catch
                            {
                                obj2 = 0;
                            }
                        }
                        pTargObj.set_Value(i, obj2);
                    }
                }
            }
        }

        public bool CreateView(string sLDName, string sLDGXName, string sBHFilter, string sViewPath)
        {
            try
            {
                //sBHFilter = sBHFilter.Replace("'", "''");
             
                //string excuteSql = this.GetExcuteSql(sViewPath + "0.PrepareData.sql");
                //string str2 = "PrepareSTATData";
                //if (dBAccess.GetDataTable(dBAccess, "SELECT COUNT(1) FROM sysobjects WHERE ID = object_id('" + str2 + "')").Rows[0][0].ToString() == "1")
                //{
                //    dBAccess.ExecuteNonQuery("DROP PROCEDURE " + str2);
                //}
                //dBAccess.ExecuteNonQuery(excuteSql);
                //excuteSql = "IF OBJECT_ID('" + str2 + "')IS NOT NULL EXEC " + str2 + " '" + sLDName + "','" + sLDGXName + "','" + sBHFilter + "'";
                //dBAccess.ExecuteNonQuery(excuteSql);
                //if (!this.ExecuteSql(dBAccess, sViewPath + "1.T_STAT_01.sql"))
                //{
                //    return false;
                //}
                //if (!this.ExecuteSql(dBAccess, sViewPath + "2.T_STAT_02.sql"))
                //{
                //    return false;
                //}
                //if (!this.ExecuteSql(dBAccess, sViewPath + "3.T_STAT_03.sql"))
                //{
                //    return false;
                //}
                //if (!this.ExecuteSql(dBAccess, sViewPath + "4.T_STAT_04.sql"))
                //{
                //    return false;
                //}
                //if (!this.ExecuteSql(dBAccess, sViewPath + "5.T_STAT_05.sql"))
                //{
                //    return false;
                //}
                //if (!this.ExecuteSql(dBAccess, sViewPath + "6.T_STAT_06.sql"))
                //{
                //    return false;
                //}
                return true;
            }
            catch
            {
                MessageBox.Show("创建数据视图出错！");
                return false;
            }
        }

        public IFeatureClass Dissolve(string sIn, string sOut, string sWorkPath)
        {
            try
            {
                IFeatureClass class2;
                IQueryFilter filter;
                ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                geoprocessor.SetEnvironmentValue("workspace", sWorkPath);
                geoprocessor.OverwriteOutput = true;
                ESRI.ArcGIS.DataManagementTools.Dissolve process = new ESRI.ArcGIS.DataManagementTools.Dissolve();
                process.in_features = sIn;
                process.out_feature_class = sOut;
                process.dissolve_field = "XIAN;XIANG;CUN;LIN_BAN";
                IGeoProcessorResult result = (IGeoProcessorResult) geoprocessor.Execute(process, null);
                if (result.Status != esriJobStatus.esriJobSucceeded)
                {
                    return null;
                }
                IGPUtilities utilities = new GPUtilitiesClass();
                utilities.DecodeFeatureLayer(result.GetOutput(0), out class2, out filter);
                this.ReleaseObject(result);
                return class2;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.LDStatis", "Dissolve", exception.GetHashCode().ToString(), "", exception.Message, "", "", "");
                return null;
            }
        }

        private bool ExecuteSql(string sFile)
        {
            IList<string> list = this.GetExcuteSql1(sFile);
            if (list == null)
            {
                return false;
            }
            string sCmdText = "";
            for (int i = 0; i < list.Count; i++)
            {
                sCmdText = list[i];
                MDM.UpdateDB(sCmdText);
            }
            return true;
        }

        private Encoding GetEncoding(string filePath)
        {
            Encoding currentEncoding = Encoding.Default;
            if (!File.Exists(filePath))
            {
                return currentEncoding;
            }
            try
            {
                using (System.IO.FileStream stream = new System.IO.FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    if (stream.Length > 0L)
                    {
                        using (StreamReader reader = new StreamReader(stream, true))
                        {
                            char[] chArray = new char[1];
                            reader.Read(chArray, 0, 1);
                            currentEncoding = reader.CurrentEncoding;
                            reader.BaseStream.Position = 0L;
                            if (currentEncoding == Encoding.UTF8)
                            {
                                byte[] preamble = currentEncoding.GetPreamble();
                                if (stream.Length >= preamble.Length)
                                {
                                    byte[] buffer = new byte[preamble.Length];
                                    stream.Read(buffer, 0, buffer.Length);
                                    for (int i = 0; i < buffer.Length; i++)
                                    {
                                        if (buffer[i] != preamble[i])
                                        {
                                            currentEncoding = Encoding.Default;
                                            goto Label_00D6;
                                        }
                                    }
                                }
                                else
                                {
                                    currentEncoding = Encoding.Default;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        Label_00D6:
            if (currentEncoding == null)
            {
                currentEncoding = Encoding.UTF8;
            }
            return currentEncoding;
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

        private IList<string> GetExcuteSql1(string sSqlFilePath)
        {
            FileInfo info = new FileInfo(sSqlFilePath);
            if (!info.Exists)
            {
                return null;
            }
            IList<string> list = new List<string>();
            StreamReader reader = new StreamReader(sSqlFilePath, this.GetEncoding(sSqlFilePath));
            string str = reader.ReadLine();
            StringBuilder builder = new StringBuilder();
            while (str != null)
            {
                if (str.Replace("  ", "").Replace(" ", "").ToUpper() == "GO")
                {
                    list.Add(builder.ToString());
                    builder = new StringBuilder();
                }
                else
                {
                    builder.Append(str + "  ");
                }
                str = reader.ReadLine();
            }
            if (builder.ToString() != "")
            {
                list.Add(builder.ToString());
            }
            reader.Close();
            return list;
        }

        private bool PrepareBH(IWorkspaceEdit pWsEdit, IFeatureCursor pFCursor1, IFeatureClass pBDFClass, IFeatureClass pNewFClass, DataTable pConvertTable, string sQFields1, string sHFields, int iAreaIndex1, Label pLabel)
        {
            bool flag = true;
            pWsEdit.StartEditing(false);
            pWsEdit.StartEditOperation();
            try
            {
                IFeature pSrcObj = null;
                int num = 0;
                while ((pSrcObj = pFCursor1.NextFeature()) != null)
                {
                    string str = pSrcObj.OID.ToString();
                    pLabel.Text = "      正在处理林地本底变化数据：" + str;
                    pLabel.Refresh();
                    num++;
                    if ((num % 0x3e8) == 0)
                    {
                        pWsEdit.StopEditOperation();
                        pWsEdit.StopEditing(true);
                        this.SaveRecord("4", str);
                        pWsEdit.StartEditing(false);
                        pWsEdit.StartEditOperation();
                    }
                    try
                    {
                        IGeometry shapeCopy = pSrcObj.ShapeCopy;
                        if (shapeCopy.IsEmpty)
                        {
                            continue;
                        }
                        double area = ((IArea) shapeCopy).Area;
                        double num3 = Convert.ToDouble(pSrcObj.get_Value(iAreaIndex1));
                        ISpatialFilter filter = new SpatialFilterClass();
                        filter.SubFields = pBDFClass.ShapeFieldName + "," + sHFields;
                        filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                        filter.Geometry = shapeCopy;
                        IFeatureCursor cursor = pBDFClass.Search(filter, false);
                        IFeature feature2 = null;
                        while ((feature2 = cursor.NextFeature()) != null)
                        {
                            IGeometry other = feature2.ShapeCopy;
                            if (other.IsEmpty)
                            {
                                this.ReleaseObject(feature2);
                            }
                            else
                            {
                                ITopologicalOperator2 @operator = (ITopologicalOperator2) shapeCopy;
                                @operator.Simplify();
                                IGeometry geometry3 = @operator.Intersect(other, esriGeometryDimension.esriGeometry2Dimension);
                                if (geometry3.IsEmpty)
                                {
                                    this.ReleaseObject(geometry3);
                                    this.ReleaseObject(feature2);
                                    continue;
                                }
                                IFeature pTargObj = pNewFClass.CreateFeature();
                                pTargObj.Shape = geometry3;
                                this.CopyBHAttirbutes(pSrcObj, pTargObj);
                                double num5 = Math.Round((double) ((((IArea) geometry3).Area * num3) / area), 2);
                                pTargObj.set_Value(iAreaIndex1, num5);
                                string[] strArray = sQFields1.Split(new char[] { ',' });
                                string[] strArray2 = sHFields.Split(new char[] { ',' });
                                for (int i = 0; i < strArray.Length; i++)
                                {
                                    int index = feature2.Fields.FindField(strArray2[i]);
                                    if (index >= 0)
                                    {
                                        object obj2 = feature2.get_Value(index);
                                        obj2 = this.TransCode(strArray2[i], obj2, pConvertTable);
                                        int num8 = pTargObj.Fields.FindField(strArray[i]);
                                        if (num8 >= 0)
                                        {
                                            pTargObj.set_Value(num8, obj2);
                                        }
                                    }
                                }
                                pTargObj.Store();
                                this.ReleaseObject(geometry3);
                                this.ReleaseObject(feature2);
                                this.ReleaseObject(pTargObj);
                            }
                        }
                        this.ReleaseObject(cursor);
                        this.ReleaseObject(shapeCopy);
                        this.ReleaseObject(pSrcObj);
                        continue;
                    }
                    catch (Exception exception)
                    {
                        this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.LDStatis", "PrepareBH", "0", str, exception.Message, "", "", "");
                        flag = false;
                        goto Label_030A;
                    }
                }
            }
            catch (Exception exception2)
            {
                flag = false;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.LDStatis", "PrepareBH", exception2.GetHashCode().ToString(), "", exception2.Message, "", "", "");
            }
        Label_030A:
            if (flag)
            {
                pWsEdit.StopEditOperation();
                pWsEdit.StopEditing(true);
                return flag;
            }
            pWsEdit.AbortEditOperation();
            pWsEdit.StopEditing(false);
            return flag;
        }

        public IFeatureClass PrepareLDData(IFeatureClass pNdFClass, string sLDName)
        {
            try
            {
                string[] source = this.m_LDFields.Split(new char[] { ',' });
                IDataset dataset = (IDataset) pNdFClass;
                IWorkspace pSWs = dataset.Workspace;
                IFeatureWorkspace pWs = (IFeatureWorkspace) pSWs;
                string sName = sLDName;
                IFeatureClass class2 = ConvertData.OpenFeatureClass(pWs, sName);
                if (class2 != null)
                {
                    ((IDataset) class2).Delete();
                    class2 = null;
                }
                if (class2 == null)
                {
                    IFeatureClassDescription description = new FeatureClassDescriptionClass();
                    IObjectClassDescription description2 = (IObjectClassDescription) description;
                    class2 = pWs.CreateFeatureClass(sName, pNdFClass.Fields, description2.InstanceCLSID, description2.ClassExtensionCLSID, esriFeatureType.esriFTSimple, "Shape", "");
                    GC.Collect();
                    ITable table = (ITable) class2;
                    string[] strArray2 = new string[] { "XIANG", "CUN", "LIN_CHANG", "LYFQ", "TU_RANG_LX", "TU_CENG_HD", "MEI_GQ_ZS", "PO_DU" };
                    esriFieldType[] typeArray2 = new esriFieldType[8];
                    typeArray2[0] = esriFieldType.esriFieldTypeString;
                    typeArray2[1] = esriFieldType.esriFieldTypeString;
                    typeArray2[2] = esriFieldType.esriFieldTypeString;
                    typeArray2[3] = esriFieldType.esriFieldTypeString;
                    typeArray2[4] = esriFieldType.esriFieldTypeString;
                    typeArray2[5] = esriFieldType.esriFieldTypeInteger;
                    typeArray2[6] = esriFieldType.esriFieldTypeInteger;
                    esriFieldType[] typeArray = typeArray2;
                    int[] numArray = new int[] { 3, 3, 3, 10, 20, 0, 0, 0 };
                    for (int i = 0; i < strArray2.Length; i++)
                    {
                        int num2 = table.FindField(strArray2[i]);
                        if (num2 >= 0)
                        {
                            IField field = table.Fields.get_Field(num2);
                            table.DeleteField(field);
                        }
                    }
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        IField field2 = new FieldClass();
                        IFieldEdit edit = (IFieldEdit) field2;
                        edit.Name_2 = strArray2[j];
                        edit.Type_2 = typeArray[j];
                        if (typeArray[j] == esriFieldType.esriFieldTypeString)
                        {
                            edit.Length_2 = numArray[j];
                        }
                        table.AddField(field2);
                    }
                    int fieldCount = table.Fields.FieldCount;
                    for (int k = 0; k < fieldCount; k++)
                    {
                        IField field3 = table.Fields.get_Field(k);
                        if ((((field3.Type != esriFieldType.esriFieldTypeOID) && (field3.Type != esriFieldType.esriFieldTypeGeometry)) && (field3.Editable && (field3 != class2.LengthField))) && (field3 != class2.AreaField))
                        {
                            if (Enumerable.Contains<string>(source, field3.Name))
                            {
                                if (field3.Domain != null)
                                {
                                    IFieldEdit2 edit2 = (IFieldEdit2) field3;
                                    edit2.Domain_2 = null;
                                }
                            }
                            else
                            {
                                try
                                {
                                    table.DeleteField(field3);
                                    k--;
                                    fieldCount--;
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                    GC.Collect();
                    int index = table.FindField("Q_LIN_ZHONG");
                    if (index >= 0)
                    {
                        IField field4 = table.Fields.get_Field(index);
                        table.DeleteField(field4);
                    }
                    IField field5 = new FieldClass();
                    IFieldEdit edit3 = (IFieldEdit) field5;
                    edit3.Name_2 = "Q_L_Z";
                    edit3.Type_2 = esriFieldType.esriFieldTypeString;
                    edit3.Length_2 = 3;
                    table.AddField(field5);
                    if (table.FindField("GLLX") < 0)
                    {
                        string str3 = "GLLX";
                        field5 = new FieldClass();
                        edit3 = (IFieldEdit) field5;
                        edit3.Name_2 = str3;
                        edit3.Type_2 = esriFieldType.esriFieldTypeString;
                        edit3.Length_2 = 2;
                        table.AddField(field5);
                    }
                }
                IFeatureCursor cursor = pNdFClass.Search(null, false);
                IWorkspaceEdit edit4 = (IWorkspaceEdit) pSWs;
                edit4.StartEditing(false);
                edit4.StartEditOperation();
                IFeatureBuffer buffer = null;
                IFeatureCursor cursor2 = class2.Insert(true);
                IFeature pSrcObj = null;
                while ((pSrcObj = cursor.NextFeature()) != null)
                {
                    buffer = class2.CreateFeatureBuffer();
                    buffer.Shape = pSrcObj.ShapeCopy;
                    this.CopyLDAttirbutes(pSrcObj, buffer as IObject);
                    cursor2.InsertFeature(buffer);
                    this.ReleaseObject(pSrcObj);
                    this.ReleaseObject(buffer);
                }
                cursor2.Flush();
                this.ReleaseObject(cursor2);
                edit4.StopEditOperation();
                edit4.StopEditing(true);
                GC.Collect();
                string str4 = "(LIN_ZHONG<>Q_L_Z or Q_GC_LB<>G_CHENG_LB or Q_SQ_D<>SHI_QUAN_D or Q_SEN_LB<>SEN_LIN_LB or Q_DI_LEI<>DI_LEI or Q_LD_QS<>LD_QS or Q_BH_DJ<>BH_DJ) and BHYY='80'";
                string sqlStmt = "update " + sName + " set BHYY='82' where " + str4;
                pSWs.ExecuteSQL(sqlStmt);
                sqlStmt = ("update " + sName + " set BHYY=null,BHND=null,LIN_ZHONG=null,SEN_LIN_LB=null,G_CHENG_LB=null,SHI_QUAN_D=null,GJGYL_BHDJ=null,ZL_DJ=null,BH_DJ=null,QYKZ=null,YU_BI_DU=null,YOU_SHI_SZ=null,QI_YUAN=null,PINGJUN_XJ=null,HUO_LMGQXJ=null,LING_ZU=null,LYFQ=null,MEI_GQ_ZS=null") + " where Q_DI_LEI in ('961','962','963') and (DI_LEI>'900' and DI_LEI<'961')";
                pSWs.ExecuteSQL(sqlStmt);
                sqlStmt = "update " + sName + " set BHYY='93' where DI_LEI in ('961','962','963') and (BHYY is null or ltrim(rtrim(BHYY))='')";
                pSWs.ExecuteSQL(sqlStmt);
                sqlStmt = "update " + sName + " set GLLX='20' where DI_LEI in ('961','962','963')";
                pSWs.ExecuteSQL(sqlStmt);
                this.UpdateCodes(pSWs, sName, source);
                return class2;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.LDStatis", "PrepareLDData", exception.GetHashCode().ToString(), "", exception.Message, "", "", "");
                return null;
            }
        }

        public IFeatureClass PrepareLDLB(IFeatureClass pLDFClass, string sName)
        {
            try
            {
                IDataset dataset = (IDataset) pLDFClass;
                IWorkspace workspace = dataset.Workspace;
                IFeatureWorkspace pWs = (IFeatureWorkspace) workspace;
                IFeatureClass class2 = ConvertData.OpenFeatureClass(pWs, sName);
                if (class2 != null)
                {
                    ((IDataset) class2).Delete();
                    class2 = null;
                }
                string parentDirectory = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("TempPath");
                string path = parentDirectory + @"\export.sde";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                string sWorkPath = string.Empty;
                IWorkspaceFactory factory = (IWorkspaceFactory) Activator.CreateInstance(System.Type.GetTypeFromProgID("esriDataSourcesGDB.SdeWorkspaceFactory"));
                sWorkPath = factory.Create(parentDirectory, "export.sde", workspace.ConnectionProperties, 0).PathName;
                string name = dataset.Name;
                string sOut = sName;
                IFeatureClass class3 = this.Dissolve(name, sOut, sWorkPath);
                if (class3 == null)
                {
                    return null;
                }
                string[] strArray = new string[] { "XIAN_NAME", "XIANG_NAME", "CUN_NAME", "LB_NAME" };
                string[] strArray2 = new string[] { "县名称", "乡名称", "村名称", "林班名称" };
                int[] numArray = new int[] { 50, 50, 50, 50 };
                for (int i = 0; i < strArray.Length; i++)
                {
                    IField field = new FieldClass();
                    IFieldEdit edit = (IFieldEdit) field;
                    edit.Name_2 = strArray[i];
                    edit.AliasName_2 = strArray2[i];
                    edit.Type_2 = esriFieldType.esriFieldTypeString;
                    edit.Length_2 = numArray[i];
                    class3.AddField(field);
                }
            //    IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                //string sCmdText = "update " + sName + " set XIAN_NAME=(select top 1 t2.CNAME from T_SYS_META_CODE t2 where XIAN=t2.CCODE and t2.CDOMAIN='XIAN')";
                //if (dBAccess.ExecuteNonQuery(sCmdText) < 0)
                //{
                //    return null;
                //}
                //sCmdText = "update " + sName + " set XIANG_NAME=(select top 1 t2.CNAME from T_SYS_META_CODE t2 where XIAN+XIANG=t2.CCODE and t2.CDOMAIN='XIANG') ";
                //if (dBAccess.ExecuteNonQuery(sCmdText) < 0)
                //{
                //    return null;
                //}
                //sCmdText = "update " + sName + " set CUN_NAME=(select top 1 t2.CNAME from T_SYS_META_CODE t2 where XIAN+XIANG+CUN=t2.CCODE and t2.CDOMAIN='CUN') ";
                //if (dBAccess.ExecuteNonQuery(sCmdText) < 0)
                //{
                //    return null;
                //}
                return class3;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.LDStatis", "PrepareLDLB", exception.GetHashCode().ToString(), "", exception.Message, "", "", "");
                return null;
            }
        }

        public IFeatureClass PrepareLDStatisData(IFeatureClass pELFClass, IFeatureClass pNdFClass, IFields pLDFields, string sLDName)
        {
            try
            {
                IDataset dataset = (IDataset) pNdFClass;
                IWorkspace pSWs = dataset.Workspace;
                IFeatureWorkspace pWs = (IFeatureWorkspace) pSWs;
                string sName = sLDName;
                IFeatureClass class2 = ConvertData.OpenFeatureClass(pWs, sName);
                if (class2 != null)
                {
                    ((IDataset) class2).Delete();
                    class2 = null;
                }
                if (class2 == null)
                {
                    IFeatureClassDescription description = new FeatureClassDescriptionClass();
                    IObjectClassDescription description2 = (IObjectClassDescription) description;
                    class2 = pWs.CreateFeatureClass(sName, pLDFields, description2.InstanceCLSID, description2.ClassExtensionCLSID, esriFeatureType.esriFTSimple, "Shape", "");
                }
                IWorkspaceEdit edit = (IWorkspaceEdit) pSWs;
                edit.StartEditing(false);
                IQueryFilter filter = new QueryFilterClass();
                string str2 = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "GXFilter").Replace("[]", "<>") + " and (DT_SRC<>'77' or DT_SRC is null)" + " and (not (DI_LEI>'900' and DI_LEI<'961' and Q_DI_LEI in ('961','962','963')))";
                filter.WhereClause = str2;
                IFeatureCursor cursor = pNdFClass.Search(filter, false);
                edit.StartEditOperation();
                IFeatureBuffer buffer = null;
                IFeatureCursor cursor2 = class2.Insert(true);
                IFeature pSrcObj = null;
                while ((pSrcObj = cursor.NextFeature()) != null)
                {
                    buffer = class2.CreateFeatureBuffer();
                    buffer.Shape = pSrcObj.ShapeCopy;
                    this.CopyLDAttirbutes(pSrcObj, buffer as IObject);
                    cursor2.InsertFeature(buffer);
                    this.ReleaseObject(buffer);
                    this.ReleaseObject(pSrcObj);
                }
                cursor2.Flush();
                edit.StopEditOperation();
                this.ReleaseObject(cursor);
                this.ReleaseObject(cursor2);
                if (pELFClass != null)
                {
                    IFeatureCursor cursor3 = pELFClass.Search(null, false);
                    edit.StartEditOperation();
                    IFeature feature2 = null;
                    while ((feature2 = cursor3.NextFeature()) != null)
                    {
                        IFeature pTargObj = class2.CreateFeature();
                        pTargObj.Shape = feature2.ShapeCopy;
                        this.CopyLDAttirbutes(feature2, pTargObj);
                        pTargObj.Store();
                        this.ReleaseObject(pTargObj);
                        this.ReleaseObject(feature2);
                    }
                    edit.StopEditOperation();
                    this.ReleaseObject(cursor3);
                }
                IQueryFilter filter2 = new QueryFilterClass();
                filter2.WhereClause = "DI_LEI in ('961','962','963') and (BHYY is null or ltrim(rtrim(BHYY))='')";
                IFeatureCursor cursor4 = pNdFClass.Search(filter2, false);
                edit.StartEditOperation();
                IFeatureBuffer buffer2 = null;
                IFeatureCursor cursor5 = class2.Insert(true);
                IFeature feature4 = null;
                while ((feature4 = cursor4.NextFeature()) != null)
                {
                    buffer2 = class2.CreateFeatureBuffer();
                    buffer2.Shape = feature4.ShapeCopy;
                    this.CopyLDAttirbutes(feature4, buffer2 as IObject);
                    int index = buffer2.Fields.FindField("BHYY");
                    if (index >= 0)
                    {
                        buffer2.set_Value(index, "93");
                    }
                    index = buffer2.Fields.FindField("GLLX");
                    if (index >= 0)
                    {
                        buffer2.set_Value(index, "20");
                    }
                    cursor5.InsertFeature(buffer2);
                    this.ReleaseObject(buffer2);
                    this.ReleaseObject(feature4);
                }
                cursor5.Flush();
                edit.StopEditOperation();
                this.ReleaseObject(cursor4);
                this.ReleaseObject(cursor5);
                string str3 = "(LIN_ZHONG<>Q_LIN_ZHONG or Q_GC_LB<>G_CHENG_LB or Q_SQ_D<>SHI_QUAN_D or Q_SEN_LB<>SEN_LIN_LB or Q_DI_LEI<>DI_LEI or Q_LD_QS<>LD_QS or Q_BH_DJ<>BH_DJ) and BHYY='80'";
                IQueryFilter filter3 = new QueryFilterClass();
                filter3.WhereClause = str3;
                IFeatureCursor cursor6 = pNdFClass.Search(filter3, false);
                edit.StartEditOperation();
                IFeatureBuffer buffer3 = null;
                IFeatureCursor cursor7 = class2.Insert(true);
                IFeature feature5 = null;
                while ((feature5 = cursor6.NextFeature()) != null)
                {
                    buffer3 = class2.CreateFeatureBuffer();
                    buffer3.Shape = feature5.ShapeCopy;
                    this.CopyLDAttirbutes(feature5, buffer3 as IObject);
                    int num2 = buffer3.Fields.FindField("BHYY");
                    if (num2 >= 0)
                    {
                        buffer3.set_Value(num2, "82");
                    }
                    cursor7.InsertFeature(buffer3);
                    this.ReleaseObject(buffer3);
                    this.ReleaseObject(feature5);
                }
                cursor7.Flush();
                edit.StopEditOperation();
                this.ReleaseObject(cursor6);
                this.ReleaseObject(cursor7);
                GC.Collect();
                edit.StopEditing(true);
                string sqlStmt = "update " + sName + " set GLLX='20' where DI_LEI in ('961','962','963')";
                pSWs.ExecuteSQL(sqlStmt);
                string[] pStayFields = this.m_LDFields.Split(new char[] { ',' });
                this.UpdateCodes(pSWs, sName, pStayFields);
                return class2;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.LDStatis", "PrepareLDStatisData", exception.GetHashCode().ToString(), "", exception.Message, "", "", "");
                return null;
            }
        }

        public IFeatureClass PrepareLDStatisData2(IFeatureClass pLDFClass, IFeatureClass pELFClass, string sLDName)
        {
            try
            {
                IDataset dataset = (IDataset) pLDFClass;
                IWorkspace pSourceWS = dataset.Workspace;
                IFeatureWorkspace pWs = (IFeatureWorkspace) pSourceWS;
                string sName = sLDName;
                IFeatureClass class2 = ConvertData.OpenFeatureClass(pWs, sName);
                if (class2 != null)
                {
                    ((IDataset) class2).Delete();
                    class2 = null;
                }
                string str2 = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "LDGXFilter").Replace("[]", "<>");
                IQueryFilter pQueryFilter = new QueryFilterClass();
                pQueryFilter.WhereClause = str2;
                string sErrDescription = ConvertData.ConvertFeatureClass(pSourceWS, pLDFClass, pSourceWS, sName, pQueryFilter);
                if (sErrDescription != "")
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.LDStatis", "PrepareLDStatisData2", "0", "ConvertFeatureClass", sErrDescription, "", "", "");
                    return null;
                }
                class2 = ConvertData.OpenFeatureClass(pWs, sName);
                if ((class2 != null) && (pELFClass != null))
                {
                    IWorkspaceEdit edit = (IWorkspaceEdit) pSourceWS;
                    edit.StartEditing(false);
                    IFeatureCursor cursor = pELFClass.Search(null, false);
                    edit.StartEditOperation();
                    IFeature pSrcObj = null;
                    while ((pSrcObj = cursor.NextFeature()) != null)
                    {
                        IFeature pTargObj = class2.CreateFeature();
                        pTargObj.Shape = pSrcObj.ShapeCopy;
                        this.CopyLDAttirbutes(pSrcObj, pTargObj);
                        pTargObj.Store();
                        this.ReleaseObject(pTargObj);
                        this.ReleaseObject(pSrcObj);
                    }
                    edit.StopEditOperation();
                    this.ReleaseObject(cursor);
                    edit.StopEditing(true);
                    string[] pStayFields = this.m_LDFields.Split(new char[] { ',' });
                    this.UpdateCodes(pSourceWS, sName, pStayFields);
                }
                return class2;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.LDStatis", "PrepareLDStatisData2", exception.GetHashCode().ToString(), "", exception.Message, "", "", "");
                return null;
            }
        }

        public IFeatureClass PrepareLDStatisData3(IFeatureClass pLDBHFClass, IFeatureClass pBDFClass, string sLDName, string sLastID, Label pLabel)
        {
            try
            {
                IDataset dataset = (IDataset) pLDBHFClass;
                IWorkspace workspace = dataset.Workspace;
                IFeatureWorkspace pWs = (IFeatureWorkspace) workspace;
                string sName = sLDName;
                IFeatureClass pNewFClass = ConvertData.OpenFeatureClass(pWs, sName);
                if (((sLastID == "0") || (sLastID == "")) && (pNewFClass != null))
                {
                    ((IDataset) pNewFClass).Delete();
                    pNewFClass = null;
                }
                if (pNewFClass == null)
                {
                    IFeatureClassDescription description = new FeatureClassDescriptionClass();
                    IObjectClassDescription description2 = (IObjectClassDescription) description;
                    pNewFClass = pWs.CreateFeatureClass(sName, pLDBHFClass.Fields, description2.InstanceCLSID, description2.ClassExtensionCLSID, esriFeatureType.esriFTSimple, "Shape", "");
                    GC.Collect();
                }
                string str2 = "Q_L_Z,Q_GC_LB,Q_SQ_D,Q_SEN_LB,Q_DI_LEI,Q_LD_QS,Q_BH_DJ";
                string sHFields = "LIN_ZHONG,G_CHENG_LB,SHI_QUAN_D,SEN_LIN_LB,DI_LEI,LD_QS,BH_DJ";
                string name = "MIAN_JI";
                int num = pLDBHFClass.FindField(name);
                string str5 = "T_SUB_LD";
             //   IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
                DataTable pConvertTable = null;
                //if (dBAccess != null)
                //{
                //    string sql = "select * from " + str5;
                //    pConvertTable = dBAccess.GetDataTable(dBAccess, sql);
                //}
                IWorkspaceEdit pWsEdit = (IWorkspaceEdit) workspace;
                pLDBHFClass.FeatureCount(null);
                string oIDFieldName = pLDBHFClass.OIDFieldName;
                string str8 = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "LDGXFilter").Replace("[]", "<>");
                if ((sLastID != "0") && (sLastID != ""))
                {
                    str8 = ((str8 + " and (") + oIDFieldName + ">=" + sLastID) + ")";
                }
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = str8;
                IQueryFilterDefinition definition = (IQueryFilterDefinition) filter;
                definition.PostfixClause = "ORDER BY " + pLDBHFClass.OIDFieldName;
                IFeatureCursor cursor = pLDBHFClass.Search(filter, false);
                if (!this.PrepareBH(pWsEdit, cursor, pBDFClass, pNewFClass, pConvertTable, str2, sHFields, num, pLabel))
                {
                    return null;
                }
                this.ReleaseObject(cursor);
                this.ReleaseObject(filter);
                return pNewFClass;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.LDStatis", "PrepareLDStatisData3", exception.GetHashCode().ToString(), "", exception.Message, "", "", "");
                return null;
            }
        }

        private void ReleaseObject(object obj)
        {
            if (obj != null)
            {
                while (Marshal.ReleaseComObject(obj) > 0)
                {
                }
                obj = null;
            }
        }
        public MetaDataManager MDM
        {
            get
            {
               return  DBServiceFactory<MetaDataManager>.Service;
            }
        }
        public void SaveRecord(string value1, string value2)
        {
            try
            {
                MDM.UpdateDBInfo("LD_STEP", value1);
                MDM.UpdateDBInfo("LD_OID", value2);
               // IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                string sCmdText = "update T_SYS_DB_INFO set V_VALUE='" + value1 + "' where V_ITEM='LD_STEP'";
              //  dBAccess.ExecuteNonQuery(sCmdText);
                if ((value2 != string.Empty) && (value2 != ""))
                {
                    sCmdText = "update T_SYS_DB_INFO set V_VALUE='" + value2 + "' where V_ITEM='LD_OID'";
                 
                }
            }
            catch
            {
            }
        }

        private object TransCode(string sFieldName, object value, DataTable pConvertTable)
        {
            if ((value == DBNull.Value) || (value == null))
            {
                return value;
            }
            try
            {
                if ((pConvertTable != null) && (pConvertTable.Rows.Count >= 1))
                {
                    string filterExpression = "CCATOG='" + sFieldName + "' and P_CODE='" + value.ToString() + "'";
                    DataRow[] rowArray = pConvertTable.Select(filterExpression);
                    if (rowArray.Length > 0)
                    {
                        return rowArray[0]["P_CODE_GJ"].ToString();
                    }
                }
                return value;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.LDStatis", "TransCode", exception.GetHashCode().ToString(), "", exception.Message, "", "", "");
                return value;
            }
        }

        private void UpdateCodes(IWorkspace pSWs, string sLDFClassName, string[] pStayFields)
        {
            string str = "T_SUB_LD";
          //  IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
          //  if (dBAccess != null)
            {
                string sql = "select * from " + str;
                DataTable dataTable = null;// dBAccess.GetDataTable(dBAccess, sql);
                if ((dataTable == null) || (dataTable.Rows.Count < 1))
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.LDStatis", "PrepareLDData", "0", "", "林地更新对照表不存在", "", "", "");
                }
                else
                {
                    sql = "";
                    DataRow[] rowArray = null;
                    rowArray = dataTable.Select("P_TYPE='CODE'");
                    if (rowArray.Length > 0)
                    {
                        for (int i = 0; i < rowArray.Length; i++)
                        {
                            string str3 = rowArray[i]["CCATOG"].ToString();
                            if (Enumerable.Contains<string>(pStayFields, str3))
                            {
                                string str4 = rowArray[i]["P_CODE"].ToString();
                                string str5 = rowArray[i]["P_CODE_GJ"].ToString();
                                if (str4 != str5)
                                {
                                    sql = "update " + sLDFClassName + " set " + str3 + "='" + str5 + "' where " + str3 + "='" + str4 + "'";
                                    pSWs.ExecuteSQL(sql);
                                }
                            }
                        }
                    }
                    rowArray = null;
                    rowArray = dataTable.Select("P_TYPE='NAME'");
                    if (rowArray.Length > 0)
                    {
                        for (int j = 0; j < rowArray.Length; j++)
                        {
                            string str6 = rowArray[j]["CCATOG"].ToString();
                            if (Enumerable.Contains<string>(pStayFields, str6))
                            {
                                string str7 = rowArray[j]["P_CODE"].ToString();
                                string str8 = rowArray[j]["P_NAME_GJ"].ToString();
                                sql = "update " + sLDFClassName + " set " + str6 + "='" + str8 + "' where " + str6 + "='" + str7 + "'";
                                pSWs.ExecuteSQL(sql);
                            }
                        }
                    }
                    string sqlStmt = "update " + sLDFClassName + " set GJGYL_BHDJ=null where SHI_QUAN_D<>'10'";
                    pSWs.ExecuteSQL(sqlStmt);
                }
            }
        }
    }
}

