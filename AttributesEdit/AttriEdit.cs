namespace AttributesEdit
{
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using TaskManage;
    using Utilities;

    public class AttriEdit
    {
        public static bool ExportToHarExcel(string sTableName, string sWhere, Workbook pWorkbook)
        {
            if (pWorkbook == null)
            {
                return false;
            }
            if ((sTableName == null) || (sTableName == ""))
            {
                sTableName = EditTask.LayerName;
            }
            try
            {
               
                string str2 = "SJBH,DCRY,SJRY,(select t2.CNAME from T_SYS_META_CODE t2 where XIAN=t2.CCODE and CTYPE='县') as XIAN,";
                str2 = str2 + "(select t2.CNAME from T_SYS_META_CODE t2 where XIANG=t2.CCODE and CTYPE='乡') as XIANG," + "(select t2.CNAME from T_SYS_META_CODE t2 where CUN=t2.CCODE and CTYPE='村') as CUN,";
           
                    str2 = str2 + "LIN_BAN,(case when XIAO_BAN+'.'+XI_BAN is null then XIAO_BAN else XIAO_BAN+'.'+XI_BAN end) as XIAO_BAN,XIAODM,EAST,WEST,SOUTH,NORTH,LMSYZXM,DW,MIAN_JI,";
                
                str2 = ((((((((((str2 + "(select t2.CNAME from T_SYS_META_CODE t2 where DI_LEI=t2.CCODE and CTYPE='地类') as DI_LEI," + "(select t2.CNAME from T_SYS_META_CODE t2 where LD_QS=t2.CCODE and CTYPE='土地权属') as LD_QS,") + "(select t2.CNAME from T_SYS_META_CODE t2 where PO_XIANG=t2.CCODE and CTYPE='坡向') as PO_XIANG," + "(select t2.CNAME from T_SYS_META_CODE t2 where PO_DU=t2.CCODE and CTYPE='坡度') as PO_DU,") + "(select t2.CNAME from T_SYS_META_CODE t2 where PO_WEI=t2.CCODE and CTYPE='坡位') as PO_WEI," + "HBG,(select t2.CNAME from T_SYS_META_CODE t2 where CTMY=t2.CCODE and CTYPE='成土母岩') as CTMY,") + "(select t2.CNAME from T_SYS_META_CODE t2 where TU_RANG_LX=t2.CCODE and CTYPE='土壤类型') as TU_RANG_LX," + "TU_CENG_HD,(select t2.CNAME from T_SYS_META_CODE t2 where SEN_LIN_LB=t2.CCODE and CTYPE='森林类别') as SEN_LIN_LB,") + "(select t2.CNAME from T_SYS_META_CODE t2 where LIN_ZHONG=t2.CCODE and CTYPE='林种') as LIN_ZHONG," + "(select t2.CNAME from T_SYS_META_CODE t2 where GJGYL_BHDJ=t2.CCODE and CTYPE='国家公益林保护等级') as GJGYL_BHDJ,") + "PINGJUN_NL,(select t2.CNAME from T_SYS_META_CODE t2 where LING_ZU=t2.CCODE and CTYPE='龄组') as LING_ZU," + "YU_BI_DU,(select t2.CNAME from T_SYS_META_CODE t2 where QI_YUAN=t2.CCODE and CTYPE='起源') as QI_YUAN,") + "(select t2.CNAME from T_SYS_META_CODE t2 where YOU_SHI_SZ=t2.CCODE and CTYPE='树种') as YOU_SHI_SZ," + "PINGJUN_XJ,PINGJUN_SG,HUO_LMGQXJ,MEI_GQ_ZS,ZXJ,FQZS,") + "(select t2.CNAME from T_SYS_META_CODE t2 where CFLX=t2.CCODE and CTYPE='采伐类型') as CFLX," + "(select t2.CNAME from T_SYS_META_CODE t2 where CFFS=t2.CCODE and CTYPE='采伐方式') as CFFS,") + "CFQD,CFMJ,CFXJ,GGCCCL,FGGCCCL,CCLV,BLMGQZS,BLMYBD,CFSJ,FMFF," + "(select t2.CNAME from T_SYS_META_CODE t2 where JCFS=t2.CCODE and CTYPE='集材方式') as JCFS,") + "GENGXINSJ,GXMJ," + "(select t2.CNAME from T_SYS_META_CODE t2 where GXSZ=t2.CCODE and CTYPE='树种') as GXSZ,") + "(select t2.CNAME from T_SYS_META_CODE t2 where GXFS=t2.CCODE and CTYPE='更新方式') as GXFS," + "ZDFS,ZDGG,ZLMD,ZHUHJ,MIAOMUGG,YML,FYCS,GXZRR,QTSM";
                string sql = "select " + str2 + " from " + sTableName + " where " + sWhere;
                System.Data.DataTable dataTable = null;// dBAccess.GetDataTable(dBAccess, sql);
                if (dataTable == null)
                {
                    return false;
                }
                int count = dataTable.Rows.Count;
                if (count >= 1)
                {
                    int num3 = pWorkbook.Sheets.Count;
                    for (int i = 1; i < count; i++)
                    {
                        Worksheet after = (Worksheet) pWorkbook.Sheets[(num3 + i) - 1];
                        after.Copy(Type.Missing, after);
                    }
                    int num5 = dataTable.Columns.Count;
                    for (int j = 0; j < count; j++)
                    {
                        Worksheet pSheet = (Worksheet) pWorkbook.Sheets[num3 + j];
                        DataRow row = dataTable.Rows[j];
                        for (int k = 0; k < num5; k++)
                        {
                            string columnName = dataTable.Columns[k].ColumnName;
                            Microsoft.Office.Interop.Excel.Range range = GetRange(pSheet, columnName);
                            if (range != null)
                            {
                                string str5 = row[k].ToString();
                                range.Value2 = str5;
                            }
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static Microsoft.Office.Interop.Excel.Range GetRange(Worksheet pSheet, string sName)
        {
            try
            {
                return pSheet.UsedRange.Find(sName, Type.Missing, XlFindLookIn.xlValues, XlLookAt.xlPart, XlSearchOrder.xlByRows, XlSearchDirection.xlNext, false, Type.Missing, Type.Missing);
            }
            catch
            {
                return null;
            }
        }

        public static string[] GetReadonlyItems(IField pField)
        {
            string name = pField.Name;
            string[] source = null;
            int num = 0;
            if (name.IndexOf("SZ") == (name.Length - 2))
            {
                source = SZCodes;
                num = 1;
            }
            else if ((name == "DI_LEI") || (name == "Q_DI_LEI"))
            {
                source = UnDLCodes;
                num = 2;
            }
            else
            {
                if ((name != "G_CHENG_LB") && (name != "Q_GC_LB"))
                {
                    return null;
                }
                source = UnGCLBCodes;
                num = 3;
            }
            IDomain domain = pField.Domain;
            if (domain == null)
            {
                return null;
            }
            if (!(domain is ICodedValueDomain))
            {
                return null;
            }
            ICodedValueDomain domain2 = (ICodedValueDomain) domain;
            IList<string> list = new List<string>();
            for (int i = 0; i < domain2.CodeCount; i++)
            {
                string str2 = domain2.get_Value(i).ToString();
                if (num == 1)
                {
                    if ((!source.Contains<string>(str2) && (str2.Length > 2)) && (str2.Substring(2) == "0"))
                    {
                        list.Add(domain2.get_Name(i).ToString());
                    }
                }
                else if (source.Contains<string>(str2))
                {
                    list.Add(domain2.get_Name(i).ToString());
                }
            }
            return list.ToArray<string>();
        }

        public static void SetAttributes(IFeature pFeature, object pHook, bool bbAttriBySub)
        {
            try
            {
                new UserControlAttrEdit().SetAttributes(pFeature, pHook, bbAttriBySub);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// 设置要素面积
        /// </summary>
        /// <param name="pFeature"></param>
        /// <param name="sKindCode"></param>
        /// <param name="pSpatialReference"></param>
        public static void SetFeatureArea(IFeature pFeature, string sKindCode, ISpatialReference pSpatialReference)
        {
            if (pFeature != null)
            {
                try
                {
                    IGeometry shapeCopy = pFeature.ShapeCopy;
                    double area = DataFuncs.GetArea(pSpatialReference, shapeCopy);
                    string name = "";
                    string str2 = "";
                    string str3 = "";
                    if (sKindCode == "01")
                    {
                        area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                        name = "Afforest";
                        str2 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                    }
                    else if (sKindCode == "02")
                    {
                        area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                        name = "Harvest";
                        str2 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "ZTAreaField");
                    }
                    else if (sKindCode == "06")
                    {
                        area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                        name = "Disaster";
                        str2 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                    }
                    else if (sKindCode == "07")
                    {
                        area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                        name = "ForestCase";
                        str2 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                    }
                    else if (sKindCode == "04")
                    {
                        area = Math.Round(Math.Abs((double) (area / 10000.0)), 4);
                        name = "Expropriation";
                        str2 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "ZTAreaField");
                    }
                    else if (sKindCode == "05")
                    {
                        area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                        name = "Fire";
                        str2 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                    }
                    else
                    {
                        area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                        name = "Sub";
                        str2 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                    }
                    int index = pFeature.Fields.FindField(str2);
                    if (index > -1)
                    {
                        pFeature.set_Value(index, area);
                    }
                    string[] strArray = str3.Split(new char[] { ',' });
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        index = pFeature.Fields.FindField(strArray[i]);
                        if (index > -1)
                        {
                            pFeature.set_Value(index, area);
                        }
                    }
                    pFeature.Store();
                }
                catch
                {
                }
            }
        }

        public static string[] DateFields
        {
            get
            {
                return new string[] { "GXSJ", "GENGXINSJ", "CFSJ", "SHSJ", "JLSJ", "JCSJ", "FXRQ", "FSRQ", "JLRQ" };
            }
        }

        public static string[] SZCodes
        {
            get
            {
                return new string[] { "290", "300", "320", "340", "510", "620", "640" };
            }
        }

        public static string[] UnDLCodes
        {
            get
            {
                return new string[] { "100", "300", "400", "600", "700", "900" };
            }
        }

        public static string[] UnGCLBCodes
        {
            get
            {
                return new string[] { "30", "50", "60" };
            }
        }

        public static string[] YBDFields
        {
            get
            {
                return new string[] { "YU_BI_DU", "BLMYBD", "Q_YBD" };
            }
        }
    }
}

