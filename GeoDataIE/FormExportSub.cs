namespace GeoDataIE
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using GeoDataIE.Properties;
    using Microsoft.Office.Interop.Excel;
    using ShapeEdit;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class FormExportSub : FormBase3
    {
        private CheckEdit checkEditDbf;
        private CheckEdit checkEditExcel;
        private CheckEdit checkEditLD;
        private CheckEdit checkEditLDExcel;
        private CheckEdit checkEditShape;
        private IContainer components;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label LabelLoadInfo;
        internal System.Windows.Forms.Label LabelProgressBack;
        internal System.Windows.Forms.Label LabelProgressBar;
        private System.Windows.Forms.Label labelType;
        private string m_BHFilter = "";
        private byte[] m_BhLayerByte;
        private string m_CodeTableName = "T_SYS_META_CODE";
        private string m_DistName = "";
        private int m_ExportType = -1;
        private IHookHelper m_hookHelper;
        private string m_LastPath = "C:";
        private string m_LDFields = "";
        private string m_LDFields0 = "SHENG,XIAN,XIANG,CUN,LIN_YE_JU,LIN_CHANG,LIN_BAN,XIAO_BAN,DI_MAO,PO_XIANG,PO_WEI,KE_JI_DU,TU_RANG_LX,TU_CENG_HD,MIAN_JI,LD_QS,DI_LEI,LIN_ZHONG,QI_YUAN,SEN_LIN_LB,SHI_QUAN_D,GJGYL_BHDJ,G_CHENG_LB,LING_ZU,YU_BI_DU,YOU_SHI_SZ,PINGJUN_XJ,HUO_LMGQXJ,MEI_GQ_ZS,TD_TH_LX,DISPE,DISASTER_C,ZL_DJ,LD_KD,LD_CD,BCLD,BH_DJ,LYFQ,QYKZ,BHYY,BHND,GLLX,Remarks,PO_DU";
        private string m_LDGXFields = "SHENG,XIAN,XIANG,CUN,LIN_YE_JU,LIN_CHANG,LIN_BAN,XIAO_BAN,DI_MAO,PO_XIANG,PO_WEI,KE_JI_DU,TU_RANG_LX,TU_CENG_HD,MIAN_JI,Q_LD_QS,LD_QS,Q_DI_LEI,DI_LEI,Q_L_Z,LIN_ZHONG,QI_YUAN,Q_SEN_LB,SEN_LIN_LB,Q_SQ_D,SHI_QUAN_D,GJGYL_BHDJ,Q_GC_LB,G_CHENG_LB,LING_ZU,YU_BI_DU,YOU_SHI_SZ,PINGJUN_XJ,HUO_LMGQXJ,MEI_GQ_ZS,TD_TH_LX,DISPE,DISASTER_C,ZL_DJ,LD_KD,LD_CD,BCLD,BH_DJ,LYFQ,QYKZ,BHYY,BHND,GLLX,Remarks,PO_DU";
        private int m_LoadLength = 100;
        private byte[] m_NdLayerByte;
        private string m_Path = "";
        private const string mClassName = "GeoDataIE.FormExportSub";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
        private PanelControl panelBar;
        private Panel panelCheck;
        private Panel panelData;
        private Panel panelLDOption;
        private Panel panelOption;
        private Panel panelZYOption;
        private RadioGroup radioGroupType;
        private SimpleButton simpleButtonExport;
        private SimpleButton simpleButtonPrepare;
        private Thread thread;

        public FormExportSub()
        {
            this.InitializeComponent();
        }

        private void CallBack()
        {
            if (!base.InvokeRequired)
            {
                this.panelBar.Visible = false;
                this.panelData.Enabled = true;
            }
            else
            {
                base.Invoke(new ThreadStart(this.CallBack));
            }
        }

        private byte[] CreateByteFromObjData(object objData)
        {
            IMemoryBlobStream pstm = new MemoryBlobStreamClass();
            ((ESRI.ArcGIS.esriSystem.IPersistStream) objData).Save(pstm, 0);
            IMemoryBlobStreamVariant variant = (IMemoryBlobStreamVariant) pstm;
            object obj2 = new object();
            variant.ExportToVariant(out obj2);
            return (obj2 as byte[]);
        }

        private bool CreateDir(string sPath, int type)
        {
            if (type != 0)
            {
                if (File.Exists(sPath))
                {
                    if (DialogResult.Yes == MessageBox.Show("该目录下已存在【" + sPath + "】文件，是否替换？", "提示", MessageBoxButtons.YesNo))
                    {
                        try
                        {
                            new FileInfo(sPath).Delete();
                            goto Label_00A5;
                        }
                        catch
                        {
                            MessageBox.Show("删除文件失败，请检查是否有程序正在占用。", "提示");
                            return false;
                        }
                    }
                    return false;
                }
                goto Label_00A5;
            }
            if (Directory.Exists(sPath))
            {
                if (DialogResult.Yes == MessageBox.Show("该目录下已存在【" + sPath + "】文件夹，是否替换？", "提示", MessageBoxButtons.YesNo))
                {
                    try
                    {
                        new DirectoryInfo(sPath).Delete(true);
                        goto Label_0050;
                    }
                    catch
                    {
                        MessageBox.Show("删除文件夹失败，请检查是否有程序正在占用。", "提示");
                        return false;
                    }
                }
                return false;
            }
        Label_0050:
            Directory.CreateDirectory(sPath);
        Label_00A5:
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Export()
        {
            if (this.m_ExportType == 0)
            {
                if ((!this.checkEditDbf.Checked && !this.checkEditExcel.Checked) && !this.checkEditShape.Checked)
                {
                    MessageBox.Show("请选择导出项！", "提示");
                    return;
                }
                this.m_LoadLength = 0;
                if (this.checkEditExcel.Checked)
                {
                    this.m_LoadLength += 0x19;
                }
                if (this.checkEditDbf.Checked)
                {
                    this.m_LoadLength += 15;
                }
                if (this.checkEditShape.Checked)
                {
                    this.m_LoadLength += 60;
                }
            }
            else if (this.m_ExportType == 2)
            {
                if (!this.checkEditLDExcel.Checked && !this.checkEditLD.Checked)
                {
                    MessageBox.Show("请选择导出项！", "提示");
                    return;
                }
                if (this.checkEditLD.Checked)
                {
                    this.m_LDFields = this.m_LDFields0;
                }
                this.m_LoadLength = 0;
                if (this.checkEditLDExcel.Checked)
                {
                    this.m_LoadLength += 40;
                }
                if (this.checkEditLD.Checked)
                {
                    this.m_LoadLength += 60;
                }
            }
            else
            {
                this.m_LoadLength = 100;
            }
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.SelectedPath = this.m_LastPath;
            dialog.ShowNewFolderButton = true;
            dialog.Description = "请选择输出目录";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = dialog.SelectedPath;
                this.m_LastPath = selectedPath;
                this.panelBar.Visible = true;
                this.panelData.Enabled = false;
                this.SetLoadInfo("开始导出……", 5);
                try
                {
                    string str2 = EditTask.DistCode.Substring(0, 6);
                   // IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                    string sCmdText = "select CNAME from " + this.m_CodeTableName + " where CCODE='" + str2 + "'";
                  //  this.m_DistName = dBAccess.ExecuteScalar(sCmdText).ToString();
                }
                catch
                {
                    this.m_DistName = "未知区划";
                }
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("XBLayerName");
                string sLayerName = UtilFactory.GetConfigOpt().GetConfigValue("XBLayerName1");
                IBasicMap focusMap = this.m_hookHelper.FocusMap as IBasicMap;
                IFeatureLayer objData = GISFunFactory.LayerFun.FindFeatureLayer(focusMap, sLayerName, true);
                if (objData == null)
                {
                    MessageBox.Show("小班年度图层不存在，无法上报！", "提示");
                }
                else
                {
                    IFeatureLayer layer2 = GISFunFactory.LayerFun.FindFeatureLayer(focusMap, configValue, true);
                    if (layer2 == null)
                    {
                        MessageBox.Show("小班变化图层不存在，无法上报！", "提示");
                    }
                    else
                    {
                        this.m_NdLayerByte = this.CreateByteFromObjData(objData);
                        this.m_BhLayerByte = this.CreateByteFromObjData(layer2);
                        this.m_Path = selectedPath;
                        this.thread = new Thread(new ThreadStart(this.ExportThread));
                        this.thread.IsBackground = true;
                        this.thread.SetApartmentState(ApartmentState.STA);
                        this.thread.Start();
                    }
                }
            }
        }

        private System.Data.DataTable Export_Table2(SqlConnection pConnection, string pXBTableName, string pCodeTableName)
        {
            string sql = " select t.*,mj.土地总面积,'' as 覆盖率增减量 from ( select case when code.cname IS null then '合计' else code.CNAME end as 统计单位, case when (GROUPING (XIANG) = 1) then '合计' else ISNULL(XIANG,'1') end as tjdw, case when (GROUPING (地类) = 1) then '合计' else ISNULL(地类,'') end as 类型, sum(前期面积) as 前期面积, '' as 前期覆盖率, sum(增加合计) as 增加合计,sum(宜林地或其他无立林地) as 宜林地或其他无立林地, sum(迹地更新) as 迹地更新,sum(未成林转化) as 未成林转化,sum(农地造林) as 农地造林, sum(四旁增加) as 四旁增加,sum(其它增加) as 其它增加,sum(减少合计) as 减少合计, sum(皆伐改造) as 皆伐改造,sum(虫灾火灾) as 虫灾火灾,sum(盗伐滥伐) as 盗伐滥伐, sum(占用征收林地) as 占用征收林地,sum(砍伐四旁树) as 砍伐四旁树, sum(其它减少) as 其它减少,sum(本期面积) as 本期面积,'' as 本期覆盖率 from ( select xiang ,'有林地' as 地类, SUM(case when Q_DI_LEI < '200' and Q_DI_LEI <> '120' then convert(decimal(18,1),yxmj) else 0 end) as 前期面积, sum(case when (((DI_LEI < '200' and DI_LEI <> '120' and Q_DI_LEI >= '200') or (DI_LEI < '200' and DI_LEI <> '120' and Q_DI_LEI < '200' and Q_DI_LEI <> '120' and BHYY <> '80' and BHYY IS not null ))) then convert(decimal(18,1),yxmj) else 0 end) as 增加合计, sum(case when (Q_DI_LEI like '7%' OR Q_DI_LEI LIKE '603%') and (DI_LEI <'200' and DI_LEI <> '120') and BHYY <> '80' and BHYY IS not null then convert(decimal(18,1),yxmj) else 0 end) as 宜林地或其他无立林地, sum(case when ((Q_DI_LEI like '6%' and Q_DI_LEI not like '603%') OR (Q_DI_LEI < '200' and Q_DI_LEI <> '120')) and (DI_LEI <'200' and DI_LEI <> '120') and BHYY <> '80' and BHYY IS not null then convert(decimal(18,1),yxmj) else 0 end) as 迹地更新, sum(case when Q_DI_LEI like '4%' and (DI_LEI <'200' and DI_LEI <> '120') then convert(decimal(18,1),yxmj) else 0 end) as 未成林转化, 0 as 农地造林, 0 as 四旁增加, sum(case when not(((DI_LEI < '200' and DI_LEI <> '120' and Q_DI_LEI >= '200') or (DI_LEI < '200' and DI_LEI <> '120' and Q_DI_LEI < '200' and Q_DI_LEI <> '120' and BHYY <> '80' and BHYY IS not null )) and Q_DI_LEI < '900' and Q_DI_LEI not like '3%') and Q_DI_LEI >= '200' and DI_LEI < '200' and DI_LEI <> '120' then convert(decimal(18,1),yxmj) else 0 end) as 其它增加,  sum(case when (((Q_DI_LEI < '200' and Q_DI_LEI <> '120' and DI_LEI >= '200') and BHYY IS not null) or ((Q_DI_LEI < '200' and Q_DI_LEI <> '120' and DI_LEI <'200' and DI_LEI <> '120') and BHYY <> '80' and BHYY IS not null)) then convert(decimal(18,1),yxmj) else 0 end) as 减少合计, sum(case when Q_DI_LEI < '200' and Q_DI_LEI <> '120' and (DI_LEI <='500' and DI_LEI <> '120') and BHYY <> '80' and BHYY not like '4%' and BHYY not like '7%' and BHYY IS not null then convert(decimal(18,1),yxmj) else 0 end)as 皆伐改造, sum(case when Q_DI_LEI < '200' and Q_DI_LEI <> '120' and DI_LEI >='200' and BHYY like '7%' and BHYY IS not null then convert(decimal(18,1),yxmj) else 0 end)as 虫灾火灾, 0 as 盗伐滥伐, sum(case when Q_DI_LEI < '200' and Q_DI_LEI <> '120' and DI_LEI >='200' and BHYY like '4%' and BHYY IS not null then convert(decimal(18,1),yxmj) else 0 end)as 占用征收林地, 0 as 砍伐四旁树, sum(case when (((Q_DI_LEI < '200' and Q_DI_LEI <> '120' and DI_LEI >= '200') and BHYY IS not null) or ((Q_DI_LEI < '200' and Q_DI_LEI <> '120' and DI_LEI <'200' and DI_LEI <> '120') and BHYY <> '80' and BHYY IS not null)) and not(Q_DI_LEI < '200' and Q_DI_LEI <> '120' and (DI_LEI <='500' and DI_LEI <> '120') and BHYY <> '80' and BHYY not like '4%' and BHYY not like '7%' and BHYY IS not null) and not(Q_DI_LEI < '200' and Q_DI_LEI <> '120' and DI_LEI >='200' and BHYY like '7%' and BHYY IS not null) and not(Q_DI_LEI < '200' and Q_DI_LEI <> '120' and DI_LEI >='200' and BHYY like '4%' and BHYY IS not null) then convert(decimal(18,1),yxmj) else 0 end) as 其它减少, SUM(case when DI_LEI < '200' and DI_LEI <> '120' then convert(decimal(18,1),yxmj) else 0 end) as 本期面积 from " + pXBTableName + " group by cube(XIANG)  union all  select xiang ,'国灌' as 地类, SUM(case when Q_DI_LEI = '301' then convert(decimal(18,1),yxmj) else 0 end) as 前期面积, sum(case when (((DI_LEI = '301' and Q_DI_LEI <> '301') or (DI_LEI = '301' and Q_DI_LEI = '301' and BHYY <> '80' and BHYY IS not null ))) then convert(decimal(18,1),yxmj) else 0 end) as 增加合计, sum(case when (Q_DI_LEI like '7%' OR Q_DI_LEI LIKE '603%') and (DI_LEI ='301') and BHYY <> '80' and BHYY IS not null then convert(decimal(18,1),yxmj) else 0 end) as 宜林地或其他无立林地, sum(case when ((Q_DI_LEI like '6%' and Q_DI_LEI not like '603%') OR (Q_DI_LEI <= '301')) and (DI_LEI ='301') and BHYY <> '80' and BHYY IS not null then convert(decimal(18,1),yxmj) else 0 end) as 迹地更新, sum(case when Q_DI_LEI like '4%' and (DI_LEI = '301') then convert(decimal(18,1),yxmj) else 0 end) as 未成林转化, 0 as 农地造林, 0 as 四旁增加, sum(case when not(((DI_LEI = '301' and Q_DI_LEI <> '301') or (DI_LEI = '301' and Q_DI_LEI = '301' and BHYY <> '80' and BHYY IS not null )) and Q_DI_LEI < '900') and Q_DI_LEI <> '301' and DI_LEI = '301'  then convert(decimal(18,1),yxmj) else 0 end) as 其它增加,  sum(case when (((Q_DI_LEI = '301' and DI_LEI <> '301') and BHYY IS not null) or ((Q_DI_LEI = '301' and DI_LEI ='301') and BHYY <> '80' and BHYY IS not null)) then convert(decimal(18,1),yxmj) else 0 end) as 减少合计, sum(case when Q_DI_LEI = '301' and (DI_LEI <>'301') and BHYY <> '80' and BHYY not like '4%' and BHYY not like '7%' and BHYY IS not null then convert(decimal(18,1),yxmj) else 0 end)as 皆伐改造, sum(case when Q_DI_LEI = '301' and DI_LEI <>'301' and BHYY like '7%' and BHYY IS not null then convert(decimal(18,1),yxmj) else 0 end)as 虫灾火灾, 0 as 盗伐滥伐, sum(case when Q_DI_LEI = '301' and DI_LEI <>'301' and BHYY like '4%' and BHYY IS not null then convert(decimal(18,1),yxmj) else 0 end)as 占用征收林地, 0 as 砍伐四旁树, sum(case when (((Q_DI_LEI = '301' and DI_LEI <> '301') and BHYY IS not null) or ((Q_DI_LEI = '301' and DI_LEI ='301') and BHYY <> '80' and BHYY IS not null)) and not(Q_DI_LEI = '301' and (DI_LEI <>'301') and BHYY <> '80' and BHYY not like '4%' and BHYY not like '7%' and BHYY IS not null) and not(Q_DI_LEI = '301' and DI_LEI <>'301' and BHYY like '7%' and BHYY IS not null) and not(Q_DI_LEI = '301' and DI_LEI <>'301' and BHYY like '4%' and BHYY IS not null) then convert(decimal(18,1),yxmj) else 0 end) as 其它减少, SUM(case when DI_LEI = '301' then convert(decimal(18,1),yxmj) else 0 end) as 本期面积 from " + pXBTableName + " group by cube(XIANG)  union all  select xiang ,'农地乔木林' as 地类, SUM(case when Q_DI_LEI = '961' then convert(decimal(18,1),yxmj) else 0 end) as 前期面积, sum(case when ((DI_LEI = '961' and Q_DI_LEI <> '961') or (DI_LEI = '961' and Q_DI_LEI = '961' and BHYY <> '80' and BHYY IS not null )) then convert(decimal(18,1),yxmj) else 0 end) as 增加合计, 0 as 宜林地或其他无立林地, sum(case when DI_LEI = '961' and Q_DI_LEI = '961' and BHYY <> '80' and BHYY IS not null then convert(decimal(18,1),yxmj) else 0 end) as 迹地更新, 0 as 未成林转化, sum(case when DI_LEI = '961' and Q_DI_LEI <> '961' and Q_DI_LEI like '9%' then convert(decimal(18,1),yxmj) else 0 end) as 农地造林, 0 as 四旁增加, sum(case when ((DI_LEI = '961' and Q_DI_LEI <> '961') or (DI_LEI = '961' and Q_DI_LEI = '961' and BHYY <> '80' and BHYY IS not null )) and Q_DI_LEI < '900' then convert(decimal(18,1),yxmj) else 0 end) as 其它增加,  sum(case when ((DI_LEI <> '961' and Q_DI_LEI = '961') or (DI_LEI = '961' and Q_DI_LEI = '961' and BHYY <> '80' and BHYY IS not null )) then convert(decimal(18,1),yxmj) else 0 end) as 减少合计, sum(case when (DI_LEI = '961' and Q_DI_LEI = '961' and BHYY <> '80' and BHYY not like '4%' and BHYY not like '7%' and BHYY IS not null ) then convert(decimal(18,1),yxmj) else 0 end)as 皆伐改造, sum(case when (DI_LEI <> '961' and Q_DI_LEI = '961') and BHYY like '7%' and BHYY IS not null then convert(decimal(18,1),yxmj) else 0 end)as 虫灾火灾, 0 as 盗伐滥伐, sum(case when (DI_LEI <> '961' and Q_DI_LEI = '961') and BHYY like '4%' and BHYY IS not null then convert(decimal(18,1),yxmj) else 0 end)as 占用征收林地, 0 as 砍伐四旁树, sum(case when ((DI_LEI <> '961' and Q_DI_LEI = '961') or (DI_LEI = '961' and Q_DI_LEI = '961' and BHYY <> '80' and BHYY IS not null )) and not(DI_LEI = '961' and Q_DI_LEI = '961' and BHYY <> '80' and BHYY not like '4%' and BHYY not like '7%' and BHYY IS not null ) and not((DI_LEI <> '961' and Q_DI_LEI = '961') and BHYY like '7%' and BHYY IS not null) and not((DI_LEI <> '961' and Q_DI_LEI = '961') and BHYY like '4%' and BHYY IS not null) then convert(decimal(18,1),yxmj) else 0 end) as 其它减少, SUM(case when DI_LEI = '961' then convert(decimal(18,1),yxmj) else 0 end) as 本期面积 from " + pXBTableName + " group by cube(XIANG)  union all  select xiang ,'农地经济林' as 地类, SUM(case when Q_DI_LEI = '962' then convert(decimal(18,1),yxmj) else 0 end) as 前期面积, sum(case when ((DI_LEI = '962' and Q_DI_LEI <> '962') or (DI_LEI = '962' and Q_DI_LEI = '962' and BHYY <> '80' and BHYY IS not null )) then convert(decimal(18,1),yxmj) else 0 end) as 增加合计, 0 as 宜林地或其他无立林地, sum(case when DI_LEI = '962' and Q_DI_LEI = '962' and BHYY <> '80' and BHYY IS not null then convert(decimal(18,1),yxmj) else 0 end) as 迹地更新, 0 as 未成林转化, sum(case when DI_LEI = '962' and Q_DI_LEI <> '962' and Q_DI_LEI like '9%' then convert(decimal(18,1),yxmj) else 0 end) as 农地造林, 0 as 四旁增加, sum(case when ((DI_LEI = '962' and Q_DI_LEI <> '962') or (DI_LEI = '962' and Q_DI_LEI = '962' and BHYY <> '80' and BHYY IS not null )) and Q_DI_LEI < '900' then convert(decimal(18,1),yxmj) else 0 end) as 其它增加,  sum(case when ((DI_LEI <> '962' and Q_DI_LEI = '962') or (DI_LEI = '962' and Q_DI_LEI = '962' and BHYY <> '80' and BHYY IS not null )) then convert(decimal(18,1),yxmj) else 0 end) as 减少合计, sum(case when (DI_LEI = '962' and Q_DI_LEI = '962' and BHYY <> '80' and BHYY not like '4%' and BHYY not like '7%' and BHYY IS not null ) then convert(decimal(18,1),yxmj) else 0 end)as 皆伐改造, sum(case when (DI_LEI <> '962' and Q_DI_LEI = '962') and BHYY like '7%' and BHYY IS not null then convert(decimal(18,1),yxmj) else 0 end)as 虫灾火灾, 0 as 盗伐滥伐, sum(case when (DI_LEI <> '962' and Q_DI_LEI = '962') and BHYY like '4%' and BHYY IS not null then convert(decimal(18,1),yxmj) else 0 end)as 占用征收林地, 0 as 砍伐四旁树, sum(case when ((DI_LEI <> '962' and Q_DI_LEI = '962') or (DI_LEI = '962' and Q_DI_LEI = '962' and BHYY <> '80' and BHYY IS not null )) and not(DI_LEI = '962' and Q_DI_LEI = '962' and BHYY <> '80' and BHYY not like '4%' and BHYY not like '7%' and BHYY IS not null ) and not((DI_LEI <> '962' and Q_DI_LEI = '962') and BHYY like '7%' and BHYY IS not null) and not((DI_LEI <> '962' and Q_DI_LEI = '962') and BHYY like '4%' and BHYY IS not null) then convert(decimal(18,1),yxmj) else 0 end) as 其它减少, SUM(case when DI_LEI = '962' then convert(decimal(18,1),yxmj) else 0 end) as 本期面积 from " + pXBTableName + " group by cube(XIANG)  union all  select xiang ,'农地竹林' as 地类, SUM(case when Q_DI_LEI = '963' then convert(decimal(18,1),yxmj) else 0 end) as 前期面积, sum(case when ((DI_LEI = '963' and Q_DI_LEI <> '963') or (DI_LEI = '963' and Q_DI_LEI = '963' and BHYY <> '80' and BHYY IS not null )) then convert(decimal(18,1),yxmj) else 0 end) as 增加合计, 0 as 宜林地或其他无立林地, sum(case when DI_LEI = '963' and Q_DI_LEI = '963' and BHYY <> '80' and BHYY IS not null then convert(decimal(18,1),yxmj) else 0 end) as 迹地更新, 0 as 未成林转化, sum(case when DI_LEI = '963' and Q_DI_LEI <> '963' and Q_DI_LEI like '9%' then convert(decimal(18,1),yxmj) else 0 end) as 农地造林, 0 as 四旁增加, sum(case when ((DI_LEI = '963' and Q_DI_LEI <> '963') or (DI_LEI = '963' and Q_DI_LEI = '963' and BHYY <> '80' and BHYY IS not null )) and Q_DI_LEI < '900' then convert(decimal(18,1),yxmj) else 0 end) as 其它增加,  sum(case when ((DI_LEI <> '963' and Q_DI_LEI = '963') or (DI_LEI = '963' and Q_DI_LEI = '963' and BHYY <> '80' and BHYY IS not null )) then convert(decimal(18,1),yxmj) else 0 end) as 减少合计, sum(case when (DI_LEI = '963' and Q_DI_LEI = '963' and BHYY <> '80' and BHYY not like '4%' and BHYY not like '7%' and BHYY IS not null ) then convert(decimal(18,1),yxmj) else 0 end)as 皆伐改造, sum(case when (DI_LEI <> '963' and Q_DI_LEI = '963') and BHYY like '7%' and BHYY IS not null then convert(decimal(18,1),yxmj) else 0 end)as 虫灾火灾, 0 as 盗伐滥伐, sum(case when (DI_LEI <> '963' and Q_DI_LEI = '963') and BHYY like '4%' and BHYY IS not null then convert(decimal(18,1),yxmj) else 0 end)as 占用征收林地, 0 as 砍伐四旁树, sum(case when ((DI_LEI <> '963' and Q_DI_LEI = '963') or (DI_LEI = '963' and Q_DI_LEI = '963' and BHYY <> '80' and BHYY IS not null )) and not(DI_LEI = '963' and Q_DI_LEI = '963' and BHYY <> '80' and BHYY not like '4%' and BHYY not like '7%' and BHYY IS not null ) and not((DI_LEI <> '963' and Q_DI_LEI = '963') and BHYY like '7%' and BHYY IS not null) and not((DI_LEI <> '963' and Q_DI_LEI = '963') and BHYY like '4%' and BHYY IS not null) then convert(decimal(18,1),yxmj) else 0 end) as 其它减少, SUM(case when DI_LEI = '963' then convert(decimal(18,1),yxmj) else 0 end) as 本期面积 from " + pXBTableName + " group by cube(XIANG)  union all  select xiang ,'四旁绿化面积' as 地类, SUM(case when SSLX  = '2' then convert(decimal(18,1),(CAST((ISNULL(BAK1,0)) AS NUMERIC(38,1))/cast(1650 as float))) else 0 end) as 前期面积, SUM(CASE WHEN ISNULL(SSZZS,0)>ISNULL(BAK1,0) AND ISNULL(SSLX,0)='2' AND DI_LEI LIKE '9%' THEN convert(decimal(18,1),(CAST((ISNULL(SSZZS,0)-ISNULL(BAK1,0)) AS NUMERIC(38,1))/1650)) ELSE 0 END) as 增加合计, 0 as 宜林地或其他无立林地, 0 as 迹地更新, 0 as 未成林转化, 0 as 农地造林, SUM(CASE WHEN ISNULL(SSZZS,0)>ISNULL(BAK1,0) AND ISNULL(SSLX,0)='2' AND DI_LEI LIKE '9%' THEN convert(decimal(18,1),(CAST((ISNULL(SSZZS,0)-ISNULL(BAK1,0)) AS NUMERIC(38,1))/1650)) ELSE 0 END) as 四旁增加, 0 as 其它增加,  SUM(CASE WHEN ISNULL(SSZZS,0)<ISNULL(BAK1,0) AND ISNULL(SSLX,0)='2' AND DI_LEI LIKE '9%' THEN convert(decimal(18,1),CAST((ISNULL(BAK1,0)-ISNULL(SSZZS,0)) AS NUMERIC(38,1))/1650 ) ELSE 0 END)  as 减少合计, 0 as 皆伐改造, 0 as 虫灾火灾, 0 as 盗伐滥伐, 0 as 占用征收林地, SUM(CASE WHEN ISNULL(SSZZS,0)<ISNULL(BAK1,0) AND ISNULL(SSLX,0)='2' AND DI_LEI LIKE '9%' THEN convert(decimal(18,1),CAST((ISNULL(BAK1,0)-ISNULL(SSZZS,0)) AS NUMERIC(38,1))/1650 ) ELSE 0 END)  as 砍伐四旁树, 0 as 其它减少, SUM(case when SSLX  = '2' then convert(decimal(18,1),(CAST((ISNULL(SSZZS,0)) AS NUMERIC(38,1))/cast(1650 as float))) else 0 end) as 本期面积 from " + pXBTableName + " group by cube(XIANG) )as bb left join " + pCodeTableName + " as code  on bb.XIANG = code.CCODE and CTYPE = '乡' group by bb.XIANG,cube(bb.地类),code.CNAME  ) as t left join  (select case when (GROUPING (XIANG) = 1) then 1 else ISNULL(XIANG,'') end as tjdw, sum(convert(decimal(18,1),mian_ji)) as 土地总面积,'合计' as bb  from " + pXBTableName + " group by cube(xiang) ) as mj on t.tjdw = mj.tjdw and t.类型 = mj.bb order by t.tjdw , case when t.类型 ='有林地' then 1 when t.类型 ='国灌' then 2 when t.类型 ='农地乔木林' then 3 when t.类型 ='农地经济林' then 4 when t.类型 ='农地竹林' then 5 when t.类型 ='四旁绿化面积' then 6 end";
            System.Data.DataTable dataTable = this.GetDataTable(pConnection, sql);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i]["类型"].ToString().Trim() == "合计")
                {
                    dataTable.Rows[i]["前期覆盖率"] = ((double.Parse(dataTable.Rows[i]["前期面积"].ToString().Trim()) / double.Parse(dataTable.Rows[i]["土地总面积"].ToString().Trim())) * 100.0).ToString("0.00");
                    dataTable.Rows[i]["本期覆盖率"] = ((double.Parse(dataTable.Rows[i]["本期面积"].ToString().Trim()) / double.Parse(dataTable.Rows[i]["土地总面积"].ToString().Trim())) * 100.0).ToString("0.00");
                    dataTable.Rows[i]["覆盖率增减量"] = (double.Parse(dataTable.Rows[i]["本期覆盖率"].ToString()) - double.Parse(dataTable.Rows[i]["前期覆盖率"].ToString())).ToString("0.00");
                }
            }
            dataTable.Columns.Remove("tjdw");
            dataTable.Columns.Remove("土地总面积");
            for (int j = 0; j < dataTable.Rows.Count; j++)
            {
                for (int k = 0; k < dataTable.Columns.Count; k++)
                {
                    if (((dataTable.Rows[j][k].ToString().Trim() == "0.00") || (dataTable.Rows[j][k].ToString().Trim() == "0.0")) || (dataTable.Rows[j][k].ToString().Trim() == "0"))
                    {
                        dataTable.Rows[j][k] = DBNull.Value;
                    }
                }
            }
            return dataTable;
        }

        private bool Export2Xls(System.Data.DataTable data, string filename, int iSheet, int iStartRow, int iStartColumn, int iTitleRow, string sTitle)
        {
            bool flag = false;
            _Application o = null;
            _Workbook workbook = null;
            _Worksheet mySheet = null;
            try
            {
                o = new ApplicationClass();
                o.DisplayAlerts = false;
                workbook = o.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                mySheet = (_Worksheet) workbook.Worksheets[iSheet];
                mySheet.get_Range(mySheet.Cells[iTitleRow, 1], mySheet.Cells[iTitleRow, 1]).set_Value(Missing.Value, sTitle);
                try
                {
                    StringBuilder builder = new StringBuilder();
                    int recCount = 0;
                    int num2 = 0;
                    foreach (DataRow row in data.Rows)
                    {
                        foreach (DataColumn column in data.Columns)
                        {
                            builder.Append(row[column].ToString() + "\t");
                            if (recCount == 1)
                            {
                                num2++;
                            }
                        }
                        builder.AppendLine();
                        recCount++;
                    }
                    Clipboard.SetDataObject("");
                    Clipboard.SetDataObject(builder.ToString());
                    Microsoft.Office.Interop.Excel.Range destination = (Microsoft.Office.Interop.Excel.Range) mySheet.Cells[iStartRow, iStartColumn];
                    mySheet.Paste(destination, false);
                    Clipboard.SetDataObject("");
                    if (num2 > 0)
                    {
                        if ((iSheet == 1) || (iSheet == 2))
                        {
                            recCount = (recCount + iStartRow) - 1;
                            Microsoft.Office.Interop.Excel.Range range3 = mySheet.get_Range(mySheet.Cells[iStartRow, 1], mySheet.Cells[recCount, num2]);
                            range3.WrapText = true;
                            range3.Borders.LineStyle = 1;
                            range3.Borders.get_Item(XlBordersIndex.xlEdgeBottom).Weight = 3;
                            range3.Borders.get_Item(XlBordersIndex.xlEdgeLeft).Weight = 3;
                            range3.Borders.get_Item(XlBordersIndex.xlEdgeRight).Weight = 3;
                            range3.Borders.get_Item(XlBordersIndex.xlInsideHorizontal).Weight = 2;
                            range3.Borders.get_Item(XlBordersIndex.xlInsideVertical).Weight = 2;
                        }
                        if (iSheet == 2)
                        {
                            this.MergeCell(ref mySheet, iStartRow, recCount, 1);
                        }
                    }
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "Export2Xls", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
                workbook.Save();
                flag = true;
            }
            catch (Exception exception2)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "Export2Xls", exception2.GetHashCode().ToString(), exception2.Source, exception2.Message, "", "", "");
                MessageBox.Show("写入Excel时出错！", "提示");
                flag = false;
            }
            finally
            {
                if (workbook != null)
                {
                    workbook.Close(Missing.Value, Missing.Value, Missing.Value);
                }
                if (o != null)
                {
                    o.Quit();
                }
                Marshal.ReleaseComObject(o);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(mySheet);
                mySheet = null;
                workbook = null;
                o = null;
            }
            return flag;
        }

        private bool ExportCntyDbf(string sCodeTableName, string sPath)
        {
            try
            {
                if (!Directory.Exists(sPath))
                {
                    Directory.CreateDirectory(sPath);
                }
                string distCode = EditTask.DistCode;
              //  IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                string sql = "select CNAME,CCODE from " + sCodeTableName + " where CCODE like '" + distCode + "%'";
                System.Data.DataTable dataTable = null;// dBAccess.GetDataTable(dBAccess, sql);
                if ((dataTable == null) || (dataTable.Rows.Count < 1))
                {
                    XtraMessageBox.Show(this, "导出数据为空！", "提示");
                    return false;
                }
                OleDbConnection pConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sPath + ";Extended Properties=dBASE 5.0");
                string str4 = "xcdm_" + distCode + "_" + EditTask.TaskYear;
                string path = sPath + @"\" + str4 + ".DBF";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                string sTableName = DateTime.Now.ToString("ddHHmmss");
                sql = "create table " + sTableName + "(Dwmc varchar(20),Dwdm varchar(12))";
                if (pConnection.State == ConnectionState.Closed)
                {
                    pConnection.Open();
                }
                OleDbCommand command = new OleDbCommand();
                command.Connection = pConnection;
                command.CommandText = sql;
                command.ExecuteNonQuery();
                pConnection.Close();
                bool flag = false;
                if (this.ImportData(pConnection, dataTable, sTableName))
                {
                    File.Move(sPath + @"\" + sTableName + ".DBF", path);
                    flag = true;
                }
                else
                {
                    flag = false;
                }
                return flag;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportCntyDbf", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool ExportData(IWorkspace pTargetWorkspace, IFeatureClass pFClass, string sMessage, bool bDataset)
        {
            IDataset dataset = pFClass as IDataset;
            string name = dataset.Name;
            IWorkspace sourceWorkspace = dataset.Workspace;
            IFeatureWorkspace pFWorkspace = (IFeatureWorkspace) pTargetWorkspace;
            bool flag = false;
            if (bDataset)
            {
                IFeatureDataset pDataset = null;
                try
                {
                    pDataset = pFWorkspace.OpenFeatureDataset("FOREST");
                }
                catch
                {
                }
                if (pDataset == null)
                {
                    IGeoDataset dataset3 = (IGeoDataset) pFClass;
                    pDataset = ConvertData.CreateFeatureDataset(pFWorkspace, dataset3.SpatialReference, "FOREST");
                    if (pDataset == null)
                    {
                        MessageBox.Show(sMessage + "创建数据集失败！", "提示");
                        return false;
                    }
                }
                flag = ConvertData.CopyPasteGeodatabaseData(sourceWorkspace, pDataset, name, esriDatasetType.esriDTFeatureClass);
            }
            else
            {
                flag = ConvertData.CopyPasteGeodatabaseData(sourceWorkspace, pTargetWorkspace, name, esriDatasetType.esriDTFeatureClass);
            }
            GC.Collect();
            if (!flag)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportData", "0", "", "复制要素类出错", "", "", "");
                MessageBox.Show(sMessage + "数据上报出错！", "提示");
                return false;
            }
            return true;
        }

        private bool ExportExcel(string sPath, string sLastTableName, string sCurrentTableName, string sDistName, string sYear, string sFileName, ref int iLoad)
        {
            try
            {
                //IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                //if (dBAccess == null)
                //{
                //    MessageBox.Show("数据库连接失败！", "提示");
                //    return false;
                //}
                Thread.Sleep(50);
                string sourceFileName = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "ZYTemplateFile");
                string destFileName = sPath + @"\" + sFileName;
                File.Copy(sourceFileName, destFileName);
                Thread.Sleep(50);
                File.SetAttributes(destFileName, FileAttributes.Archive);
                int iStartRow = 0;
                int iStartColumn = 0;
                int iTitleRow = 0;
                string sTitle = "";
                iLoad += 5;
                this.SetLoadInfo("正在导出附表1……", iLoad);
                string codeTableName = this.m_CodeTableName;
                string sql = "select ";
                sql = (((((((((((((((sql + "(select CNAME from " + codeTableName + " where CTYPE='乡' and CCODE=t2.XIANG) as XIANG") + ",(select CNAME from " + codeTableName + " where CTYPE='村' and CCODE=t2.CUN) as CUN") + ",t2.LIN_BAN,'' as JYB,t2.XIAO_BAN") + ",(select CNAME from " + codeTableName + " where CTYPE='土地权属' and CCODE=t2.LD_QS) as LD_QS") + ",(select CNAME from " + codeTableName + " where CTYPE='地类' and CCODE=t2.Q_DI_LEI) as Q_DI_LEI") + ",t2.Q_MJ as Q_MIAN_JI") + ",(select CNAME from " + codeTableName + " where CTYPE='林种' and CCODE=t2.Q_LIN_ZHONG) as Q_LIN_ZHONG") + ",(select CNAME from " + codeTableName + " where CTYPE='树种' and CCODE=t2.Q_SZ) as Q_YOU_SHI_SZ") + ",t2.Q_YBD as Q_YU_BI_DU,t2.Q_PJNL as Q_PINGJUN_NL,round(t2.Q_PJXJ,1) as Q_PINGJUN_XJ,round(t2.Q_PJSG,1) as Q_PINGJUN_SG,round(t2.Q_PJDM,1) as Q_PINGJUN_DM,t2.Q_ZXJ as Q_ZXJ" + ",t2.XI_BAN") + ",(select CNAME from " + codeTableName + " where CTYPE='地类' and CCODE=t2.DI_LEI) as DI_LEI") + ",t2.MIAN_JI") + ",(select CNAME from " + codeTableName + " where CTYPE='树种' and CCODE=t2.YOU_SHI_SZ) as YOU_SHI_SZ") + ",t2.YU_BI_DU,t2.PINGJUN_NL,round(t2.PINGJUN_XJ,1),round(t2.PINGJUN_SG,1)") + ",(select CNAME from " + codeTableName + " where CTYPE='变化原因' and CCODE=t2.BHYY) as BHYY") + " from " + sCurrentTableName + " t2") + " where (t2.BHYY<>'') and (t2.BHYY is not NULL) and (t2.BHYY<>'80')" + " order by t2.CUN,t2.LIN_BAN,t2.XIAO_BAN";
                System.Data.DataTable dataTable = null;// this.GetDataTable(dBAccess.Connection as SqlConnection, sql);
                if (dataTable == null)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportExcel", "0", "FormExportSub", "查询结果表为null", "", "", "");
                }
                else
                {
                    iStartRow = 5;
                    iStartColumn = 1;
                    iTitleRow = 2;
                    sTitle = "表1 " + sDistName + sYear + "年度地类变化小班调查表";
                    if (!this.Export2Xls(dataTable, destFileName, 1, iStartRow, iStartColumn, iTitleRow, sTitle))
                    {
                        return false;
                    }
                    GC.Collect();
                }
                iLoad += 5;
                this.SetLoadInfo("正在导出附表2……", iLoad);
                System.Data.DataTable data = null;// this.Export_Table2(dBAccess.Connection as SqlConnection, "FOR_XIAOBAN_" + sYear, "T_SYS_META_CODE");
                if (data == null)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportExcel", "0", "FormExportSub", "查询结果表为null", "", "", "");
                }
                else
                {
                    iStartRow = 6;
                    iStartColumn = 1;
                    iTitleRow = 2;
                    sTitle = "表2 " + sDistName + sYear + "年度森林覆盖率更新表";
                    if (!this.Export2Xls(data, destFileName, 2, iStartRow, iStartColumn, iTitleRow, sTitle))
                    {
                        return false;
                    }
                    GC.Collect();
                }
                iLoad += 5;
                this.SetLoadInfo("正在导出附表3……", iLoad);
                string str6 = sLastTableName;
                string str7 = "";
                sql = "select case when sum(ZXJ) is NULL then 0 else sum(ZXJ) end as ZXJ";
                str7 = "(select sum(SLXJ) from " + str6 + " where DI_LEI='111' or DI_LEI='112')";
                string str8 = sql;
                sql = str8 + ",case when " + str7 + " is NULL then 0 else " + str7 + " end as QM_XJ";
                str7 = "(select sum(SLXJ) from " + str6 + " where DI_LEI='961')";
                string str9 = sql;
                sql = str9 + ",case when " + str7 + " is NULL then 0 else " + str7 + " end as ND_XJ";
                str7 = "(select sum(SLXJ) from " + str6 + " where DI_LEI='200')";
                string str10 = sql;
                sql = str10 + ",case when " + str7 + " is NULL then 0 else " + str7 + " end as SHU_XJ";
                str7 = "(select sum(SSXJ) from " + str6 + " where SSLX='1')";
                string str11 = sql;
                sql = str11 + ",case when " + str7 + " is NULL then 0 else " + str7 + " end as SS_XJ";
                str7 = "(select sum(SSXJ) from " + str6 + " where SSLX='2' and DI_LEI>='900')";
                string str12 = sql;
                sql = (str12 + ",case when " + str7 + " is NULL then 0 else " + str7 + " end as SP_XJ") + " from " + str6;
                System.Data.DataTable table3 = null;// dBAccess.GetDataTable(dBAccess, sql);
                if (table3 == null)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportExcel", "0", "FormExportSub", "查询结果表为null", "", "", "");
                    MessageBox.Show("统计蓄积量更新汇总表时出错，结果为空！", "提示");
                    return false;
                }
                sql = sql.Replace(sLastTableName, sCurrentTableName);
                System.Data.DataTable table4 = null;// dBAccess.GetDataTable(dBAccess, sql);
                if (table4 == null)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportExcel", "0", "FormExportSub", "查询结果表2为null", "", "", "");
                }
                else
                {
                    System.Data.DataTable table5 = new System.Data.DataTable();
                    DataColumn column = new DataColumn();
                    column.ColumnName = "ZXJ";
                    column.DataType = typeof(double);
                    table5.Columns.Add(column);
                    column = new DataColumn();
                    column.ColumnName = "QM_XJ";
                    column.DataType = typeof(double);
                    table5.Columns.Add(column);
                    column = new DataColumn();
                    column.ColumnName = "ND_XJ";
                    column.DataType = typeof(double);
                    table5.Columns.Add(column);
                    column = new DataColumn();
                    column.ColumnName = "SHU_XJ";
                    column.DataType = typeof(double);
                    table5.Columns.Add(column);
                    column = new DataColumn();
                    column.ColumnName = "SS_XJ";
                    column.DataType = typeof(double);
                    table5.Columns.Add(column);
                    column = new DataColumn();
                    column.ColumnName = "SP_XJ";
                    column.DataType = typeof(double);
                    table5.Columns.Add(column);
                    DataRow row = table5.NewRow();
                    for (int i = 0; i < table5.Columns.Count; i++)
                    {
                        row[i] = table3.Rows[0][i];
                    }
                    table5.Rows.Add(row);
                    row = table5.NewRow();
                    for (int j = 0; j < table5.Columns.Count; j++)
                    {
                        row[j] = table4.Rows[0][j];
                    }
                    table5.Rows.Add(row);
                    row = table5.NewRow();
                    for (int k = 0; k < table5.Columns.Count; k++)
                    {
                        object obj2 = table5.Rows[1][k];
                        if ((obj2 == DBNull.Value) || (obj2 == null))
                        {
                            obj2 = 0;
                        }
                        object obj3 = table5.Rows[0][k];
                        if ((obj3 == DBNull.Value) || (obj3 == null))
                        {
                            obj3 = 0;
                        }
                        row[k] = Convert.ToDouble(obj2.ToString()) - Convert.ToDouble(obj3.ToString());
                    }
                    table5.Rows.Add(row);
                    row = table5.NewRow();
                    for (int m = 0; m < table5.Columns.Count; m++)
                    {
                        object obj4 = table5.Rows[2][m];
                        if ((obj4 == DBNull.Value) || (obj4 == null))
                        {
                            obj4 = 0;
                        }
                        object obj5 = table5.Rows[0][m];
                        if ((obj5 == DBNull.Value) || (obj5 == null))
                        {
                            obj5 = 0;
                        }
                        double num8 = Convert.ToDouble(obj5.ToString());
                        if (num8 == 0.0)
                        {
                            row[m] = 0;
                        }
                        else
                        {
                            row[m] = Math.Round((double) ((Convert.ToDouble(obj4.ToString()) / num8) * 100.0), 2);
                        }
                    }
                    table5.Rows.Add(row);
                    iStartRow = 6;
                    iStartColumn = 2;
                    iTitleRow = 2;
                    sTitle = "表3 " + sDistName + sYear + "年度活立木蓄积量更新汇总表";
                    if (!this.Export2Xls(table5, destFileName, 3, iStartRow, iStartColumn, iTitleRow, sTitle))
                    {
                        return false;
                    }
                    GC.Collect();
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportExcel", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("导出附表出错！", "提示");
                return false;
            }
        }

        private bool ExportLD(IFeatureClass pNdFClass, string sDistCode, string sYear, ref string sPath, int iLoad)
        {
            IDataset dataset = (IDataset) pNdFClass;
            IFeatureWorkspace workspace = (IFeatureWorkspace) dataset.Workspace;
            IFeatureClass pLDFClass = ConvertData.OpenFeatureClass(workspace, "FOR_LD");
            if (pLDFClass == null)
            {
                MessageBox.Show("统计数据不存在，请先进行林地数据预处理！", "提示");
                return false;
            }
            IFeatureClass pStatisFClass = ConvertData.OpenFeatureClass(workspace, "FOR_LDSTATIS");
            if (pStatisFClass == null)
            {
                MessageBox.Show("统计数据不存在，请先进行林地数据预处理！", "提示");
                return false;
            }
            IFeatureClass pLBFclass = ConvertData.OpenFeatureClass(workspace, "FOR_LD_LB");
            if (pLBFclass == null)
            {
                MessageBox.Show("林地政区数据不存在，请先进行林地数据预处理！", "提示");
                return false;
            }
            string str2 = this.m_DistName + sYear + "林地更新成果";
            sPath = sPath + @"\" + str2;
            if (this.checkEditLDExcel.Checked)
            {
                string sFileName = sDistCode + "_林地变更调查成果统计表_" + sYear + ".xls";
                string str4 = sPath + @"\" + sFileName;
                if (!this.CreateDir(str4, 1))
                {
                    return false;
                }
                if (!Directory.Exists(sPath))
                {
                    Directory.CreateDirectory(sPath);
                }
                if (!this.ExportLDExcel(sPath, sFileName, sYear, "FOR_LD", "FOR_LDSTATIS", 1, ref iLoad))
                {
                    return false;
                }
                sFileName = sDistCode + "_林地变更调查成果统计表_" + sYear + "_2.xls";
                str4 = sPath + @"\" + sFileName;
                if (!this.CreateDir(str4, 1))
                {
                    return false;
                }
                if (!Directory.Exists(sPath))
                {
                    Directory.CreateDirectory(sPath);
                }
                if (!this.ExportLDExcel(sPath, sFileName, sYear, "FOR_LD", "FOR_LDSTATIS", 2, ref iLoad))
                {
                    return false;
                }
            }
            if (this.checkEditLD.Checked)
            {
                string str5 = sPath + @"\数据";
                if (!this.CreateDir(str5, 0))
                {
                    return false;
                }
                IWorkspace pTargetWorkspace = ConvertData.OpenWorkspace(str5);
                if (pTargetWorkspace == null)
                {
                    MessageBox.Show("成果上报失败！目标数据库无法打开。", "提示");
                    return false;
                }
                if (!this.ExportLDData(pTargetWorkspace, pLDFClass, pStatisFClass, pLBFclass, sDistCode, iLoad))
                {
                    Marshal.ReleaseComObject(pTargetWorkspace);
                    return false;
                }
                Marshal.ReleaseComObject(pTargetWorkspace);
            }
            return true;
        }

        private bool ExportLD2Xls(System.Data.DataTable data, string filename, int iSheet, int iStartRow, int iStartColumn, string sYear)
        {
            bool flag = false;
            _Application o = null;
            _Workbook workbook = null;
            _Worksheet mySheet = null;
            try
            {
                o = new ApplicationClass();
                o.DisplayAlerts = false;
                workbook = o.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                mySheet = (_Worksheet) workbook.Worksheets[iSheet];
                try
                {
                    StringBuilder builder = new StringBuilder();
                    int recCount = 0;
                    int num2 = 0;
                    foreach (DataRow row in data.Rows)
                    {
                        foreach (DataColumn column in data.Columns)
                        {
                            builder.Append(row[column].ToString() + "\t");
                            if (recCount == 1)
                            {
                                num2++;
                            }
                        }
                        builder.AppendLine();
                        recCount++;
                    }
                    Clipboard.SetDataObject("");
                    Clipboard.SetDataObject(builder.ToString());
                    Microsoft.Office.Interop.Excel.Range destination = (Microsoft.Office.Interop.Excel.Range) mySheet.Cells[iStartRow, iStartColumn];
                    mySheet.Paste(destination, false);
                    Clipboard.SetDataObject("");
                    if (num2 > 0)
                    {
                        recCount = (recCount + iStartRow) - 1;
                        Microsoft.Office.Interop.Excel.Range range2 = mySheet.get_Range(mySheet.Cells[iStartRow, 1], mySheet.Cells[recCount, num2]);
                        range2.WrapText = true;
                        range2.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        range2.Borders.LineStyle = 1;
                        range2.Borders.Weight = 2;
                        this.MergeCell(ref mySheet, iStartRow, recCount, 1);
                        if (((iSheet == 1) || (iSheet == 5)) || (iSheet == 6))
                        {
                            this.MergeCell(ref mySheet, iStartRow, recCount, 2);
                        }
                        if (filename.Contains("_2.xls"))
                        {
                            if (iSheet == 1)
                            {
                                this.MergeCell2(ref mySheet, iStartRow, recCount, 3, 4);
                                this.MergeCell(ref mySheet, iStartRow, recCount, 3);
                            }
                            else if ((iSheet == 2) || (iSheet == 3))
                            {
                                this.MergeCell2(ref mySheet, iStartRow, recCount, 2, 3);
                                this.MergeCell(ref mySheet, iStartRow, recCount, 2);
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportLD2Xls", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
                workbook.Save();
                flag = true;
            }
            catch (Exception exception2)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportLD2Xls", exception2.GetHashCode().ToString(), exception2.Source, exception2.Message, "", "", "");
                MessageBox.Show("写入Excel时出错！", "提示");
                flag = false;
            }
            finally
            {
                if (workbook != null)
                {
                    workbook.Close(Missing.Value, Missing.Value, Missing.Value);
                }
                if (o != null)
                {
                    o.Quit();
                }
                Marshal.ReleaseComObject(o);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(mySheet);
                mySheet = null;
                workbook = null;
                o = null;
            }
            return flag;
        }

        private bool ExportLD2Xls2(System.Data.DataTable data, string filename, int iSheet, int iStartRow, int iStartColumn, string sYear, string sCnty)
        {
            bool flag = false;
            _Application o = null;
            _Workbook workbook = null;
            _Worksheet worksheet = null;
            try
            {
                o = new ApplicationClass();
                o.DisplayAlerts = false;
                workbook = o.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                worksheet = (_Worksheet) workbook.Worksheets[iSheet];
                if (iSheet == 1)
                {
                    Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range(worksheet.Cells[2, iStartColumn], worksheet.Cells[2, iStartColumn]);
                    string str = sYear + "年度" + sCnty + "使用林地审核审批台账记录表";
                    range.set_Value(Missing.Value, str);
                }
                else if (iSheet == 2)
                {
                    Microsoft.Office.Interop.Excel.Range range2 = worksheet.get_Range(worksheet.Cells[2, iStartColumn], worksheet.Cells[2, iStartColumn]);
                    string str2 = sYear + "年度" + sCnty + "林地增减台账记录表";
                    range2.set_Value(Missing.Value, str2);
                }
                else if (iSheet == 3)
                {
                    Microsoft.Office.Interop.Excel.Range range3 = worksheet.get_Range(worksheet.Cells[2, iStartColumn], worksheet.Cells[2, iStartColumn]);
                    string str3 = sYear + "年度" + sCnty + "违法使用林地台账记录表";
                    range3.set_Value(Missing.Value, str3);
                }
                else if (iSheet == 4)
                {
                    Microsoft.Office.Interop.Excel.Range range4 = worksheet.get_Range(worksheet.Cells[2, iStartColumn], worksheet.Cells[2, iStartColumn]);
                    string str4 = sYear + "年度" + sCnty + "林地管理台账汇总统计表";
                    range4.set_Value(Missing.Value, str4);
                }
                else if (iSheet == 5)
                {
                    Microsoft.Office.Interop.Excel.Range range5 = worksheet.get_Range(worksheet.Cells[2, iStartColumn], worksheet.Cells[2, iStartColumn]);
                    string str5 = sYear + "年度" + sCnty + "公益林地情况汇总统计表";
                    range5.set_Value(Missing.Value, str5);
                }
                try
                {
                    StringBuilder builder = new StringBuilder();
                    int num = 0;
                    int num2 = 0;
                    foreach (DataRow row in data.Rows)
                    {
                        foreach (DataColumn column in data.Columns)
                        {
                            builder.Append(row[column].ToString() + "\t");
                            if (num == 1)
                            {
                                num2++;
                            }
                        }
                        builder.AppendLine();
                        num++;
                    }
                    Clipboard.SetDataObject("");
                    Clipboard.SetDataObject(builder.ToString());
                    Microsoft.Office.Interop.Excel.Range destination = (Microsoft.Office.Interop.Excel.Range) worksheet.Cells[iStartRow, iStartColumn];
                    worksheet.Paste(destination, false);
                    Clipboard.SetDataObject("");
                    if (num2 > 0)
                    {
                        num = (num + iStartRow) - 1;
                        Microsoft.Office.Interop.Excel.Range range7 = worksheet.get_Range(worksheet.Cells[iStartRow, iStartColumn], worksheet.Cells[num, (num2 + iStartColumn) - 1]);
                        range7.WrapText = true;
                        range7.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        range7.Borders.LineStyle = 1;
                        range7.Borders.Weight = 2;
                    }
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportLD2Xls2", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
                workbook.Save();
                flag = true;
            }
            catch (Exception exception2)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportLD2Xls2", exception2.GetHashCode().ToString(), exception2.Source, exception2.Message, "", "", "");
                MessageBox.Show("写入Excel时出错！", "提示");
                flag = false;
            }
            finally
            {
                if (workbook != null)
                {
                    workbook.Close(Missing.Value, Missing.Value, Missing.Value);
                }
                if (o != null)
                {
                    o.Quit();
                }
                Marshal.ReleaseComObject(o);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(worksheet);
                worksheet = null;
                workbook = null;
                o = null;
            }
            return flag;
        }

        private bool ExportLDData(IWorkspace pTargetWorkspace, IFeatureClass pLDFClass, IFeatureClass pStatisFClass, IFeatureClass pLBFclass, string sDistCode, int iLoad)
        {
            try
            {
                IDataset dataset = (IDataset) pLDFClass;
                IWorkspace workspace = dataset.Workspace;
                if (this.checkEditLD.Checked)
                {
                    string path = (UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("TempPath")) + @"\export.prj";
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    ISpatialReference spatialReference = Editor.UniqueInstance.Map.SpatialReference;
                    ISpatialReferenceFactory3 factory = new SpatialReferenceEnvironmentClass();
                    factory.ExportESRISpatialReferenceToPRJFile(path, spatialReference);
                    string taskYear = EditTask.TaskYear;
                    iLoad += 5;
                    this.SetLoadInfo("正在导出林地政区数据……", iLoad);
                    string str4 = sDistCode + "_ZQ";
                    string sOutPath = pTargetWorkspace.PathName + @"\" + str4 + "_" + taskYear + ".shp";
                    string sErrDescription = ConvertData.ProjectFeatureClass(pLBFclass, sOutPath, path);
                    if (sErrDescription != "")
                    {
                        this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportLDData", "2", "ProjectFeatureClass", sErrDescription, "", "", "");
                        MessageBox.Show("投影林地政区数据出错！", "提示");
                        return false;
                    }
                    iLoad += 15;
                    this.SetLoadInfo("正在导出林地变化数据……", iLoad);
                    str4 = sDistCode + "_BH";
                    sOutPath = pTargetWorkspace.PathName + @"\" + str4 + "_" + taskYear + ".shp";
                    sErrDescription = ConvertData.ProjectFeatureClass(pStatisFClass, sOutPath, path);
                    if (sErrDescription != "")
                    {
                        this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportLDData", "0", "ProjectFeatureClass", sErrDescription, "", "", "");
                        MessageBox.Show("投影林地变化数据出错！", "提示");
                        return false;
                    }
                    string[] source = this.m_LDGXFields.Split(new char[] { ',' });
                    ITable table = (ITable) ConvertData.OpenFeatureClass((IFeatureWorkspace) pTargetWorkspace, str4 + "_" + taskYear);
                    int fieldCount = table.Fields.FieldCount;
                    for (int i = 0; i < fieldCount; i++)
                    {
                        IField field = table.Fields.get_Field(i);
                        if (((field.Type != esriFieldType.esriFieldTypeOID) && (field.Type != esriFieldType.esriFieldTypeGeometry)) && (field.Editable && !Enumerable.Contains<string>(source, field.Name)))
                        {
                            table.DeleteField(field);
                            i--;
                            fieldCount--;
                        }
                    }
                    iLoad += 20;
                    this.SetLoadInfo("正在导出林地成果数据……", iLoad);
                    str4 = sDistCode + "_XZ";
                    sOutPath = pTargetWorkspace.PathName + @"\" + str4 + "_" + taskYear + ".shp";
                    sErrDescription = ConvertData.ProjectFeatureClass(pLDFClass, sOutPath, path);
                    if (sErrDescription != "")
                    {
                        this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportLDData", "1", "ProjectFeatureClass", sErrDescription, "", "", "");
                        MessageBox.Show("投影林地成果数据出错！", "提示");
                        return false;
                    }
                    source = this.m_LDFields.Split(new char[] { ',' });
                    ITable table2 = (ITable) ConvertData.OpenFeatureClass((IFeatureWorkspace) pTargetWorkspace, str4 + "_" + taskYear);
                    fieldCount = table2.Fields.FieldCount;
                    for (int j = 0; j < fieldCount; j++)
                    {
                        IField field2 = table2.Fields.get_Field(j);
                        if (((field2.Type != esriFieldType.esriFieldTypeOID) && (field2.Type != esriFieldType.esriFieldTypeGeometry)) && (field2.Editable && !Enumerable.Contains<string>(source, field2.Name)))
                        {
                            table2.DeleteField(field2);
                            j--;
                            fieldCount--;
                        }
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportLDData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("导出林地数据出错！", "提示");
                return false;
            }
        }

        private bool ExportLDExcel(string sPath, string sFileName, string sYear, string sTableName, string sBHTableName, int iExcel, ref int iLoad)
        {
            bool flag;
            try
            {
              
                this.SetLoadInfo("正在准备统计数据……", iLoad);
                LDStatis statis = new LDStatis();
                string sBHFilter = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "LDGXFilter").Replace("[]", "<>");
                string sViewPath = "";
                string str3 = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "LDTemplateFile");
                if (iExcel == 1)
                {
                    sViewPath = UtilFactory.GetConfigOpt().RootPath + @"\Data\ReportDDL\";
                }
                else
                {
                    sViewPath = UtilFactory.GetConfigOpt().RootPath + @"\Data\ReportDDL_2\";
                    str3 = @"bin\国家林地变更表_2.xls";
                }
                if (!statis.CreateView(sTableName, sBHTableName, sBHFilter, sViewPath))
                {
                    return false;
                }
                Thread.Sleep(50);
                string sourceFileName = UtilFactory.GetConfigOpt().RootPath + @"\" + str3;
                string destFileName = sPath + @"\" + sFileName;
                File.Copy(sourceFileName, destFileName);
                Thread.Sleep(50);
                File.SetAttributes(destFileName, FileAttributes.Archive);
                for (int i = 1; i < 7; i++)
                {
                    iLoad += 3;
                    string str6 = string.Concat(new object[] { "附表", iExcel, "-", i });
                    this.SetLoadInfo("正在导出" + str6 + "……", iLoad);
                    string sql = "";
                    int iStartRow = 0;
                    switch (i)
                    {
                        case 1:
                            sql = "select T_SYS_META_CODE.CNAME,case FLD2 when '00' then '合计' when '10' then '国有林地' when '20' then '集体林地' when '21' then '农户家庭承包经营' when '22' then '联户合作经营' when '23' then '集体经济组织经营' ELSE FLD2 end,";
                            sql = sql + "case FLD3 when '1' then '现状' when '2' then '新增' when '3' then '减少' when '4' then '净增' else FLD3 end" + ",FLD4,FLD5,FLD6,FLD7,FLD8,FLD9,FLD10,FLD11,FLD12,FLD13,FLD14,FLD15,FLD16,FLD17";
                            if (iExcel == 2)
                            {
                                sql = sql + ",FLD18";
                            }
                            sql = sql + " from T_STAT_01 left join T_SYS_META_CODE on FLD1=CCODE order by len(FLD1)";
                            iStartRow = 5;
                            break;

                        case 2:
                            sql = "select T_SYS_META_CODE.CNAME,case FLD2 when '1' then '现状' when '2' then '新增' when '3' then '减少' when '4' then '净增' else FLD2 end";
                            sql = sql + ",FLD3,FLD4,FLD5,FLD6,FLD7,FLD8,FLD9,FLD10,FLD11,FLD12,FLD13,FLD14,FLD15,FLD16,FLD17,FLD18";
                            if (iExcel == 2)
                            {
                                sql = sql + ",FLD19";
                            }
                            sql = sql + " from T_STAT_02 left join T_SYS_META_CODE on FLD1=CCODE order by len(FLD1)";
                            iStartRow = 7;
                            break;

                        case 3:
                            sql = "select T_SYS_META_CODE.CNAME,case FLD2 when '1' then '现状' when '2' then '新增' when '3' then '减少' when '4' then '净增' else FLD2 end";
                            sql = sql + ",FLD3,FLD4,FLD5,FLD6,FLD7,FLD8,FLD9,FLD10,FLD11,FLD12,FLD13,FLD14,FLD15";
                            if (iExcel == 2)
                            {
                                sql = sql + ",FLD16";
                            }
                            sql = sql + " from T_STAT_03 left join T_SYS_META_CODE on FLD1=CCODE order by len(FLD1)";
                            iStartRow = 6;
                            break;

                        case 4:
                            sql = "select T_SYS_META_CODE.CNAME,case FLD2 when '2' then '增加林地到' when '3' then '减少林地自' when '4' then '林地净增加' else FLD2 end";
                            sql = sql + ",FLD3,FLD4,FLD5,FLD6,FLD7,FLD8,FLD9,FLD10,FLD11 from T_STAT_04  left join T_SYS_META_CODE on FLD1=CCODE order by len(FLD1)";
                            iStartRow = 4;
                            break;

                        default:
                            if (i == 4)
                            {
                                sql = "select T_SYS_META_CODE.CNAME,case FLD2 when '2' then '增加林地到' when '3' then '减少林地自' when '4' then '林地净增加' else FLD2 end";
                                sql = sql + ",FLD3,FLD4,FLD5,FLD6,FLD7,FLD8,FLD9,FLD10,FLD11 from T_STAT_04  left join T_SYS_META_CODE on FLD1=CCODE order by len(FLD1)";
                                iStartRow = 4;
                            }
                            else if (i == 5)
                            {
                                sql = "select T_SYS_META_CODE.CNAME,case FLD2 when '00' then '合计' when '0110' then '有林地' when '0120' then '疏林地' when '0130' then '灌木林地'";
                                sql = ((sql + "when '0140' then '未成林地' when '0150' then '苗圃地' when '0160' then '无立木林地' when '0170' then '宜林地' when '0180' " + " then '林业辅助生产用地'  when '0190' then '' when '0200' then '非林地' ELSE FLD2 end") + " ,case FLD3 when '00' then '合计' when '0110' then '有林地' when '0120' then '疏林地' when '0130' then '灌木林地'" + " when '0140' then '未成林地' when '0150' then '苗圃地' when '0160' then '无立木林地' when '0170' then '宜林地' when '0180' ") + " then '林业辅助生产用地'  when '0190' then '' when '0200' then '非林地' ELSE FLD3 end " + ",FLD4,FLD5,FLD6,FLD7,FLD8,FLD9,FLD10,FLD11,FLD12 from T_STAT_05  left join T_SYS_META_CODE on FLD1=CCODE order by len(FLD1)";
                                iStartRow = 4;
                            }
                            else
                            {
                                if (i != 6)
                                {
                                    goto Label_03B4;
                                }
                                sql = "select T_SYS_META_CODE.CNAME,case FLD2 when '00' then '合计' when '1' then '一级' when '2' then '二级' when '3' then '三级'";
                                sql = (sql + " when '4' then '四级' when '5' then '非林地' ELSE FLD2 end" + " ,case FLD3 when '00' then '合计' when '1' then '一级' when '2' then '二级' when '3' then '三级'") + " when '4' then '四级' when '5' then '非林地' ELSE FLD3 end " + ",FLD4,FLD5,FLD6,FLD7,FLD8,FLD9,FLD10,FLD11,FLD12,FLD13 from T_STAT_06  left join T_SYS_META_CODE on FLD1=CCODE order by len(FLD1)";
                                iStartRow = 3;
                            }
                            break;
                    }
                    System.Data.DataTable dataTable = null;// this.GetDataTable((SqlConnection)dBAccess.Connection, sql);
                    if (dataTable == null)
                    {
                        this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportLDExcel", "0", "FormExportSub", "查询结果" + str6 + "为null", "", "", "");
                    }
                    else
                    {
                        int iStartColumn = 1;
                        if (!this.ExportLD2Xls(dataTable, destFileName, i, iStartRow, iStartColumn, sYear))
                        {
                            return false;
                        }
                        GC.Collect();
                    }
                }
            Label_03B4:
                flag = true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportExcel", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("导出附表出错！", "提示");
                flag = false;
            }
            return flag;
        }

        private bool ExportLDExcel2(string sPath, string sLastTableName, string sCurrentTableName, string sDistName, string sYear, string sFileName, ref int iLoad, int iSheetType)
        {
            try
            {
                //IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                //if (dBAccess == null)
                //{
                //    MessageBox.Show("数据库连接失败！", "提示");
                //    return false;
                //}
                Thread.Sleep(50);
                string sourceFileName = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "LDTemplateFile2");
                string destFileName = sPath + @"\" + sFileName;
                File.Copy(sourceFileName, destFileName);
                Thread.Sleep(50);
                File.SetAttributes(destFileName, FileAttributes.Archive);
                int num = 0;
                if (iSheetType == 1)
                {
                    num = 5;
                }
                else if (iSheetType == 2)
                {
                    num = 3;
                    Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
                    Workbook workbook = application.Workbooks.Open(destFileName, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing);
                    application.DisplayAlerts = false;
                    for (int j = workbook.Sheets.Count; j > num; j--)
                    {
                        (workbook.Sheets[j] as Worksheet).Delete();
                    }
                    workbook.Save();
                    application.Workbooks.Close();
                    application.Quit();
                    int generation = GC.GetGeneration(application);
                    Marshal.ReleaseComObject(application);
                    application = null;
                    GC.Collect(generation);
                }
                string codeTableName = this.m_CodeTableName;
                string newValue = "ZT_LDZZ_" + sYear;
                for (int i = 1; i <= num; i++)
                {
                    string str5 = "附表" + i;
                    if (iLoad > 0)
                    {
                        iLoad += 15;
                        this.SetLoadInfo("正在导出" + str5 + "……", iLoad);
                    }
                    string sql = "";
                    int iStartRow = 0;
                    int iStartColumn = 1;
                    if (i == 1)
                    {
                        sql = GeoDataIE.Properties.Resources.LDTZ1.Replace("ZT_LDZZ_2013", newValue);
                        iStartRow = 7;
                        iStartColumn = 2;
                    }
                    else if (i == 2)
                    {
                        sql = GeoDataIE.Properties.Resources.LDTZ2.Replace("ZT_LDZZ_2013", newValue);
                        iStartRow = 7;
                        iStartColumn = 2;
                    }
                    else if (i == 3)
                    {
                        sql = GeoDataIE.Properties.Resources.LDTZ3.Replace("ZT_LDZZ_2013", newValue);
                        iStartRow = 8;
                        iStartColumn = 2;
                    }
                    else if (i == 4)
                    {
                        sql = GeoDataIE.Properties.Resources.LDTZ;
                        iStartRow = 6;
                        iStartColumn = 2;
                    }
                    else
                    {
                        if (i != 5)
                        {
                            break;
                        }
                        sql = GeoDataIE.Properties.Resources.LDGYL;
                        iStartRow = 7;
                        iStartColumn = 2;
                    }
                    sql = sql.Replace("FRO_XIAOBAN_2013", sCurrentTableName).Replace("FRO_XIAOBAN_2012", sLastTableName).Replace("T_SYS_META_CODE", codeTableName);
                    System.Data.DataTable dataTable = null;// dBAccess.GetDataTable(dBAccess, sql);
                    if (dataTable == null)
                    {
                        this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportLDExcel2", "0", "FormExportSub", "查询结果" + str5 + "为null", "", "", "");
                    }
                    else
                    {
                        if (!this.ExportLD2Xls2(dataTable, destFileName, i, iStartRow, iStartColumn, sYear, sDistName))
                        {
                            return false;
                        }
                        GC.Collect();
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportLDExcel2", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("导出附表出错！", "提示");
                return false;
            }
        }

        public bool ExportLDTZ()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.SelectedPath = this.m_LastPath;
            dialog.ShowNewFolderButton = true;
            dialog.Description = "请选择输出目录";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = dialog.SelectedPath;
                string str2 = EditTask.DistCode.Substring(0, 6);
                string taskYear = EditTask.TaskYear;
                string sDistName = "";
                try
                {
                  //  IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                    string sCmdText = "select CNAME from " + this.m_CodeTableName + " where CCODE='" + str2 + "'";
                   // sDistName = dBAccess.ExecuteScalar(sCmdText).ToString();
                }
                catch
                {
                    sDistName = "未知区划";
                }
                string sFileName = str2 + "_" + sDistName + "_林地台账" + taskYear + ".xls";
                string sPath = selectedPath + @"\" + sFileName;
                if (!this.CreateDir(sPath, 1))
                {
                    return false;
                }
                if (!Directory.Exists(selectedPath))
                {
                    Directory.CreateDirectory(selectedPath);
                }
                int iLoad = 0;
                if (!this.ExportLDExcel2(selectedPath, "", "", sDistName, taskYear, sFileName, ref iLoad, 2))
                {
                    return false;
                }
            }
            return true;
        }

        private void ExportSub(string sPath)
        {
            try
            {
                if (!Directory.Exists(sPath))
                {
                    MessageBox.Show("路径不存在，无法上报！", "提示");
                }
                else
                {
                    int iValue = 4;
                    this.SetLoadInfo("正在获取导出数据……", iValue);
                    string sDistCode = EditTask.DistCode.Substring(0, 6);
                    string taskYear = EditTask.TaskYear;
                    string str3 = (int.Parse(taskYear) - 1).ToString();
                    IFeatureLayer layerFromByte = (IFeatureLayer) this.GetLayerFromByte(this.m_NdLayerByte);
                    if (layerFromByte != null)
                    {
                        IFeatureClass featureClass = layerFromByte.FeatureClass;
                        if (featureClass == null)
                        {
                            MessageBox.Show("小班年度的图层数据源丢失，无法上报！", "提示");
                        }
                        else
                        {
                            string name = ((IDataset) featureClass).Name;
                            string str5 = name.Substring(0, name.Length - 4) + str3;
                            if (this.m_ExportType == 0)
                            {
                                if (!this.ExportZYData(str5, name, featureClass, sDistCode, taskYear, ref sPath, iValue))
                                {
                                    return;
                                }
                            }
                            else if (this.m_ExportType == 1)
                            {
                                if (!this.ExportSystemData(featureClass, ref sPath, iValue))
                                {
                                    return;
                                }
                            }
                            else if (this.m_ExportType == 2)
                            {
                                if (!this.ExportLD(featureClass, sDistCode, taskYear, ref sPath, iValue))
                                {
                                    return;
                                }
                            }
                            else if (this.m_ExportType == 3)
                            {
                                string distName = this.m_DistName;
                                string sFileName = sDistCode + "_" + distName + "_林地台账" + taskYear + ".xls";
                                string str8 = sPath + @"\" + sFileName;
                                if (!this.CreateDir(str8, 1))
                                {
                                    return;
                                }
                                if (!Directory.Exists(sPath))
                                {
                                    Directory.CreateDirectory(sPath);
                                }
                                if (!this.ExportLDExcel2(sPath, str5, name, distName, taskYear, sFileName, ref iValue, 1))
                                {
                                    return;
                                }
                                sPath = str8;
                            }
                            iValue = 100;
                            this.SetLoadInfo("导出完成", iValue);
                            MessageBox.Show("成果上报成功：" + sPath + "！", "提示");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportSub", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("成果上报出错！", "提示");
            }
        }

        private bool ExportSystemData(IFeatureClass pNdFClass, ref string sPath, int iLoad)
        {
            try
            {
                IFeatureLayer layerFromByte = (IFeatureLayer) this.GetLayerFromByte(this.m_BhLayerByte);
                IFeatureClass featureClass = layerFromByte.FeatureClass;
                if (featureClass == null)
                {
                    MessageBox.Show("小班变化图层数据源丢失，无法上报！", "提示");
                    return false;
                }
                string str = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
                string str2 = this.m_DistName + "森林资源数据";
                sPath = sPath + str2;
                string str3 = sPath + @"\" + str + ".mdb";
                if (!this.CreateDir(str3, 0))
                {
                    return false;
                }
                iLoad += 10;
                this.SetLoadInfo("开始创建数据库……", iLoad);
                IWorkspace pTargetWorkspace = ConvertData.CreateDBFile(str3);
                if (pTargetWorkspace == null)
                {
                    MessageBox.Show("数据库创建失败！", "提示");
                    return false;
                }
                iLoad += 10;
                this.SetLoadInfo("正在导出变化图层……", iLoad);
                if (!this.ExportData(pTargetWorkspace, featureClass, "小班变化图层", true))
                {
                    return false;
                }
                iLoad += 15;
                this.SetLoadInfo("正在导出年度图层……", iLoad);
                if (!this.ExportData(pTargetWorkspace, pNdFClass, "小班年度图层", true))
                {
                    return false;
                }
                sPath = str3;
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportSystemData", "0", "", exception.Message, "", "", "");
                MessageBox.Show("数据上报出错：" + exception.Message, "提示");
                return false;
            }
        }

        private void ExportThread()
        {
            this.ExportSub(this.m_Path);
            GC.Collect();
            this.CallBack();
        }

        private bool ExportZYBHData(IWorkspace pTargetWorkspace, IFeatureClass pFClass, string sTargetName, string sMessage)
        {
            IDataset dataset = pFClass as IDataset;
            IWorkspace pSourceWS = dataset.Workspace;
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pQueryFilter.WhereClause = this.m_BHFilter;
            string str = ConvertData.ConvertFeatureClass(pSourceWS, pFClass, pTargetWorkspace, sTargetName, pQueryFilter);
            if (str != "")
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportZYBHData", "0", "FormExportSub", "ConvertFeatureClass出错：" + str, "", "", "");
                MessageBox.Show(sMessage + "数据上报出错！", "提示");
                return false;
            }
            return true;
        }

        private bool ExportZYData(IWorkspace pTargetWorkspace, IFeatureClass pFClass, string sTargetName, string sMessage)
        {
            IDataset dataset = pFClass as IDataset;
            string str = ConvertData.ConvertFeatureClass(dataset.Workspace, pFClass, pTargetWorkspace, sTargetName, null);
            GC.Collect();
            if (str != "")
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExportZYData", "0", "FormExportSub", "ConvertFeatureClass出错：" + str, "", "", "");
                MessageBox.Show(sMessage + "数据上报出错！", "提示");
                return false;
            }
            return true;
        }

        private bool ExportZYData(string sTableName1, string sTableName2, IFeatureClass pNdFClass, string sDistCode, string sYear, ref string sPath, int iLoad)
        {
            this.SetLoadInfo("正在准备数据……", iLoad);
            if (!this.SetDataDtsrc(sTableName1, sTableName2))
            {
                return false;
            }
            string distName = this.m_DistName;
            string str2 = distName + sYear + "森林资源数据更新成果";
            sPath = sPath + @"\" + str2;
            if (this.checkEditExcel.Checked)
            {
                string sFileName = sDistCode + "_" + distName + "_附表" + sYear + ".xls";
                string str4 = sPath + @"\" + sFileName;
                if (!this.CreateDir(str4, 1))
                {
                    return false;
                }
                if (!Directory.Exists(sPath))
                {
                    Directory.CreateDirectory(sPath);
                }
                if (!this.ExportExcel(sPath, sTableName1, sTableName2, distName, sYear, sFileName, ref iLoad))
                {
                    return false;
                }
                this.SetLoadInfo("正在导出森林资源动态统计表……      ", iLoad);
                sFileName = sDistCode + "_" + distName + "_森林资源动态统计表" + sYear + ".xls";
                str4 = sPath + @"\" + sFileName;
                ExportZYBHTable table = new ExportZYBHTable();
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("InitialCatalog");
                if (!table.ExportToFile(sYear, configValue, str4))
                {
                    return false;
                }
            }
            if (this.checkEditDbf.Checked)
            {
                iLoad += 5;
                this.SetLoadInfo("正在导出乡村代码表……", iLoad);
                string sCodeTableName = UtilFactory.GetConfigOpt().GetConfigValue("DicTableName");
                string str7 = sPath + @"\乡村代码表";
                if (!this.CreateDir(str7, 0))
                {
                    return false;
                }
                if (!this.ExportCntyDbf(sCodeTableName, str7))
                {
                    return false;
                }
            }
            if (this.checkEditShape.Checked)
            {
                iLoad += 5;
                this.SetLoadInfo("正在导出小班图层……", iLoad);
                string str8 = sPath + @"\小班图层";
                if (!this.CreateDir(str8, 0))
                {
                    return false;
                }
                IWorkspace pTargetWorkspace = ConvertData.OpenWorkspace(str8);
                if (pTargetWorkspace == null)
                {
                    MessageBox.Show("数据库创建失败！", "提示");
                    return false;
                }
                string sTargetName = "xb_" + sDistCode + "_" + sYear;
                bool flag = this.ExportZYData(pTargetWorkspace, pNdFClass, sTargetName, "小班年度图层");
                if (flag)
                {
                    iLoad += 20;
                    this.SetLoadInfo("正在修改小班图层数据……", iLoad);
                    flag = this.ModifyZYData(pTargetWorkspace, sTargetName, sTableName1, ref iLoad);
                    if (flag)
                    {
                        iLoad += 5;
                        this.SetLoadInfo("正在导出变化小班图层……", iLoad);
                        IFeatureWorkspace pWs = (IFeatureWorkspace) pTargetWorkspace;
                        IFeatureClass pFClass = ConvertData.OpenFeatureClass(pWs, sTargetName);
                        if (pFClass == null)
                        {
                            MessageBox.Show("打开小班图层出错！", "提示");
                            return false;
                        }
                        string str10 = sPath + @"\变化小班图层";
                        if (!this.CreateDir(str10, 0))
                        {
                            return false;
                        }
                        IWorkspace workspace3 = ConvertData.OpenWorkspace(str10);
                        string str11 = "bhxb_" + sDistCode + "_" + sYear;
                        flag = this.ExportZYBHData(workspace3, pFClass, str11, "小班变化图层");
                        Marshal.ReleaseComObject(pFClass);
                        Marshal.ReleaseComObject(workspace3);
                    }
                }
                Marshal.ReleaseComObject(pTargetWorkspace);
                this.ReleaseWorkspace(str8);
                if (!flag)
                {
                    return false;
                }
            }
            return true;
        }

        private void FormExportSub_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this.thread != null) && this.thread.IsAlive)
            {
                this.thread.Abort();
                this.thread.Join();
                this.thread = null;
            }
        }

        private void FormExportSub_Load(object sender, EventArgs e)
        {
            this.panelData.Enabled = true;
            this.panelBar.Visible = false;
            this.checkEditExcel.Checked = true;
        }

        private System.Data.DataTable GetDataTable(SqlConnection pCon, string sql)
        {
            try
            {
                SqlCommand selectCommand = pCon.CreateCommand();
                selectCommand.CommandTimeout = 0x3e7;
                selectCommand.CommandText = sql;
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                return dataSet.Tables[0];
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate("", "GeoDataIE.FormExportSub", "GetDataTable", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private string GetFieldValue2(IObject pObj, string sFieldName)
        {
            int index = pObj.Fields.FindField(sFieldName);
            if (index >= 0)
            {
                IField field = pObj.Fields.get_Field(index);
                string str = pObj.get_Value(index).ToString();
                IDomain domain = field.Domain;
                if (str == "<null>")
                {
                    return "";
                }
                if (domain == null)
                {
                    return str;
                }
                if (!(domain is ICodedValueDomain))
                {
                    return str;
                }
                ICodedValueDomain domain2 = domain as ICodedValueDomain;
                for (int i = 0; i < domain2.CodeCount; i++)
                {
                    string str2 = domain2.get_Name(i);
                    if (str == domain2.get_Value(i).ToString())
                    {
                        return str2;
                    }
                }
            }
            return "";
        }

        private ESRI.ArcGIS.esriSystem.IPersistStream GetLayerFromByte(byte[] tempByte)
        {
            IMemoryBlobStream pstm = new MemoryBlobStreamClass();
            IMemoryBlobStreamVariant variant = (IMemoryBlobStreamVariant) pstm;
            ESRI.ArcGIS.esriSystem.IPersistStream stream2 = null;
            object obj2 = tempByte;
            variant.ImportFromVariant(obj2);
            stream2 = new FeatureLayerClass();
            stream2.Load(pstm);
            return stream2;
        }

        private bool ImportData(OleDbConnection pConnection, System.Data.DataTable pDataTable, string sTableName)
        {
            try
            {
                if (pConnection == null)
                {
                    return false;
                }
                if (pConnection.State == ConnectionState.Closed)
                {
                    pConnection.Open();
                }
                string str = "";
                str = "Select  *  From  [" + sTableName + "]";
                OleDbCommand selectCommand = new OleDbCommand();
                selectCommand.Connection = pConnection;
                OleDbTransaction transaction = pConnection.BeginTransaction();
                selectCommand.Transaction = transaction;
                try
                {
                    selectCommand.CommandText = str;
                    OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand);
                    OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
                    builder.QuotePrefix = "[";
                    builder.QuoteSuffix = "]";
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, sTableName);
                    System.Data.DataTable table = dataSet.Tables[0];
                    foreach (DataRow row in pDataTable.Rows)
                    {
                        table.Rows.Add(row.ItemArray);
                    }
                    adapter.Update(dataSet, sTableName);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    pConnection.Close();
                    return false;
                }
                transaction.Dispose();
                transaction = null;
                selectCommand = null;
                pConnection.Close();
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ImportData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        public void Init(object hook, int type)
        {
            if (hook != null)
            {
                if (this.m_hookHelper == null)
                {
                    this.m_hookHelper = new HookHelperClass();
                }
                this.m_hookHelper.Hook = hook;
                this.panelOption.Visible = true;
                this.radioGroupType.SelectedIndex = 0;
                this.m_BHFilter = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "GXFilter").Replace("[]", "<>");
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormExportSub));
            this.panelData = new Panel();
            this.panelOption = new Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelLDOption = new Panel();
            this.panel2 = new Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.simpleButtonPrepare = new SimpleButton();
            this.panel1 = new Panel();
            this.checkEditLDExcel = new CheckEdit();
            this.checkEditLD = new CheckEdit();
            this.panelZYOption = new Panel();
            this.checkEditDbf = new CheckEdit();
            this.checkEditShape = new CheckEdit();
            this.checkEditExcel = new CheckEdit();
            this.labelType = new System.Windows.Forms.Label();
            this.panelCheck = new Panel();
            this.radioGroupType = new RadioGroup();
            this.panel4 = new Panel();
            this.simpleButtonExport = new SimpleButton();
            this.panelBar = new PanelControl();
            this.LabelProgressBack = new System.Windows.Forms.Label();
            this.LabelProgressBar = new System.Windows.Forms.Label();
            this.LabelLoadInfo = new System.Windows.Forms.Label();
            this.panelData.SuspendLayout();
            this.panelOption.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelLDOption.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.checkEditLDExcel.Properties.BeginInit();
            this.checkEditLD.Properties.BeginInit();
            this.panelZYOption.SuspendLayout();
            this.checkEditDbf.Properties.BeginInit();
            this.checkEditShape.Properties.BeginInit();
            this.checkEditExcel.Properties.BeginInit();
            this.panelCheck.SuspendLayout();
            this.radioGroupType.Properties.BeginInit();
            this.panel4.SuspendLayout();
            this.panelBar.BeginInit();
            this.panelBar.SuspendLayout();
            base.SuspendLayout();
            this.panelData.Controls.Add(this.panelOption);
            this.panelData.Controls.Add(this.panelCheck);
            this.panelData.Controls.Add(this.panel4);
            this.panelData.Dock = DockStyle.Top;
            this.panelData.Location = new System.Drawing.Point(10, 0);
            this.panelData.Name = "panelData";
            this.panelData.Size = new Size(0x164, 0x164);
            this.panelData.TabIndex = 2;
            this.panelOption.Controls.Add(this.groupBox1);
            this.panelOption.Dock = DockStyle.Top;
            this.panelOption.Location = new System.Drawing.Point(0, 0x69);
            this.panelOption.Name = "panelOption";
            this.panelOption.Padding = new Padding(5, 10, 5, 0);
            this.panelOption.Size = new Size(0x164, 190);
            this.panelOption.TabIndex = 5;
            this.groupBox1.Controls.Add(this.panelLDOption);
            this.groupBox1.Controls.Add(this.panelZYOption);
            this.groupBox1.Controls.Add(this.labelType);
            this.groupBox1.Dock = DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x15a, 180);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "导出项";
            this.panelLDOption.Controls.Add(this.panel2);
            this.panelLDOption.Controls.Add(this.panel1);
            this.panelLDOption.Dock = DockStyle.Top;
            this.panelLDOption.Location = new System.Drawing.Point(3, 0x47);
            this.panelLDOption.Name = "panelLDOption";
            this.panelLDOption.Size = new Size(340, 0x88);
            this.panelLDOption.TabIndex = 3;
            this.panel2.BorderStyle = BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.simpleButtonPrepare);
            this.panel2.Dock = DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(340, 0x58);
            this.panel2.TabIndex = 9;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0x27, 0x27);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x10f, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "如果您是第一次导出成果，请先进行数据预处理；";
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0x27, 60);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x127, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "如果您的年度数据发生了变化，请先进行数据预处理。";
            this.simpleButtonPrepare.Appearance.BackColor = Color.LightBlue;
            this.simpleButtonPrepare.Appearance.Font = new System.Drawing.Font("Tahoma", 9f, FontStyle.Bold);
            this.simpleButtonPrepare.Appearance.ForeColor = Color.Black;
            this.simpleButtonPrepare.Appearance.Options.UseBackColor = true;
            this.simpleButtonPrepare.Appearance.Options.UseFont = true;
            this.simpleButtonPrepare.Appearance.Options.UseForeColor = true;
            this.simpleButtonPrepare.ButtonStyle = BorderStyles.Simple;
            this.simpleButtonPrepare.Location = new System.Drawing.Point(0x18, 8);
            this.simpleButtonPrepare.Name = "simpleButtonPrepare";
            this.simpleButtonPrepare.Size = new Size(0x6a, 0x17);
            this.simpleButtonPrepare.TabIndex = 4;
            this.simpleButtonPrepare.Text = "林地数据预处理";
            this.simpleButtonPrepare.Click += new EventHandler(this.simpleButtonPrepare_Click);
            this.panel1.Controls.Add(this.checkEditLDExcel);
            this.panel1.Controls.Add(this.checkEditLD);
            this.panel1.Dock = DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 0x68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(340, 0x20);
            this.panel1.TabIndex = 6;
            this.checkEditLDExcel.EditValue = true;
            this.checkEditLDExcel.Location = new System.Drawing.Point(0x16, 6);
            this.checkEditLDExcel.Name = "checkEditLDExcel";
            this.checkEditLDExcel.Properties.Caption = "国家林地变更表";
            this.checkEditLDExcel.Size = new Size(0x6d, 0x13);
            this.checkEditLDExcel.TabIndex = 1;
            this.checkEditLD.Location = new System.Drawing.Point(0x92, 6);
            this.checkEditLD.Name = "checkEditLD";
            this.checkEditLD.Properties.Caption = "林地变更和成果数据";
            this.checkEditLD.Size = new Size(140, 0x13);
            this.checkEditLD.TabIndex = 3;
            this.panelZYOption.Controls.Add(this.checkEditDbf);
            this.panelZYOption.Controls.Add(this.checkEditShape);
            this.panelZYOption.Controls.Add(this.checkEditExcel);
            this.panelZYOption.Dock = DockStyle.Top;
            this.panelZYOption.Location = new System.Drawing.Point(3, 0x2c);
            this.panelZYOption.Name = "panelZYOption";
            this.panelZYOption.Size = new Size(340, 0x1b);
            this.panelZYOption.TabIndex = 2;
            this.checkEditDbf.Location = new System.Drawing.Point(0x56, 7);
            this.checkEditDbf.Name = "checkEditDbf";
            this.checkEditDbf.Properties.Caption = "乡村代码表";
            this.checkEditDbf.Size = new Size(0x55, 0x13);
            this.checkEditDbf.TabIndex = 3;
            this.checkEditShape.Location = new System.Drawing.Point(0xbf, 7);
            this.checkEditShape.Name = "checkEditShape";
            this.checkEditShape.Properties.Caption = "小班图层与变化图层";
            this.checkEditShape.Size = new Size(0x90, 0x13);
            this.checkEditShape.TabIndex = 2;
            this.checkEditExcel.Location = new System.Drawing.Point(0x16, 7);
            this.checkEditExcel.Name = "checkEditExcel";
            this.checkEditExcel.Properties.Caption = "附表";
            this.checkEditExcel.Size = new Size(0x33, 0x13);
            this.checkEditExcel.TabIndex = 1;
            this.labelType.Dock = DockStyle.Top;
            this.labelType.Location = new System.Drawing.Point(3, 0x12);
            this.labelType.Name = "labelType";
            this.labelType.Size = new Size(340, 0x1a);
            this.labelType.TabIndex = 0;
            this.panelCheck.Controls.Add(this.radioGroupType);
            this.panelCheck.Dock = DockStyle.Top;
            this.panelCheck.Location = new System.Drawing.Point(0, 0);
            this.panelCheck.Name = "panelCheck";
            this.panelCheck.Padding = new Padding(2, 10, 2, 0);
            this.panelCheck.Size = new Size(0x164, 0x69);
            this.panelCheck.TabIndex = 3;
            this.radioGroupType.Dock = DockStyle.Fill;
            this.radioGroupType.Location = new System.Drawing.Point(2, 10);
            this.radioGroupType.Name = "radioGroupType";
            this.radioGroupType.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, "上交资源更新成果数据"), new RadioGroupItem(null, "系统资源小班数据"), new RadioGroupItem(null, "林地更新数据"), new RadioGroupItem(null, "林地台账") });
            this.radioGroupType.Size = new Size(0x160, 0x5f);
            this.radioGroupType.TabIndex = 4;
            this.radioGroupType.SelectedIndexChanged += new EventHandler(this.radioGroupType_SelectedIndexChanged);
            this.panel4.Controls.Add(this.simpleButtonExport);
            this.panel4.Dock = DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 0x137);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(0x164, 0x2d);
            this.panel4.TabIndex = 4;
            this.simpleButtonExport.Location = new System.Drawing.Point(0x10d, 14);
            this.simpleButtonExport.Name = "simpleButtonExport";
            this.simpleButtonExport.Size = new Size(0x4b, 0x17);
            this.simpleButtonExport.TabIndex = 0;
            this.simpleButtonExport.Text = "导出";
            this.simpleButtonExport.Click += new EventHandler(this.simpleButtonExport_Click);
            this.panelBar.BorderStyle = BorderStyles.NoBorder;
            this.panelBar.Controls.Add(this.LabelProgressBack);
            this.panelBar.Controls.Add(this.LabelProgressBar);
            this.panelBar.Controls.Add(this.LabelLoadInfo);
            this.panelBar.Dock = DockStyle.Top;
            this.panelBar.Location = new System.Drawing.Point(10, 0x164);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new Size(0x164, 0x2a);
            this.panelBar.TabIndex = 11;
            this.panelBar.Visible = false;
            this.LabelProgressBack.BackColor = Color.White;
            this.LabelProgressBack.BorderStyle = BorderStyle.FixedSingle;
            this.LabelProgressBack.ForeColor = Color.White;
            this.LabelProgressBack.Location = new System.Drawing.Point(40, 0x1c);
            this.LabelProgressBack.Name = "LabelProgressBack";
            this.LabelProgressBack.Size = new Size(300, 4);
            this.LabelProgressBack.TabIndex = 15;
            this.LabelProgressBar.BackColor = Color.Orange;
            this.LabelProgressBar.BorderStyle = BorderStyle.FixedSingle;
            this.LabelProgressBar.ForeColor = Color.Black;
            this.LabelProgressBar.Location = new System.Drawing.Point(40, 0x1c);
            this.LabelProgressBar.Name = "LabelProgressBar";
            this.LabelProgressBar.Size = new Size(140, 4);
            this.LabelProgressBar.TabIndex = 14;
            this.LabelLoadInfo.BackColor = Color.Transparent;
            this.LabelLoadInfo.ForeColor = Color.FromArgb(0xff, 0x80, 0);
            this.LabelLoadInfo.Image = (Image)resources.GetObject("LabelLoadInfo.Image");
            this.LabelLoadInfo.ImageAlign = ContentAlignment.MiddleLeft;
            this.LabelLoadInfo.Location = new System.Drawing.Point(0x48, 6);
            this.LabelLoadInfo.Name = "LabelLoadInfo";
            this.LabelLoadInfo.Size = new Size(0xea, 0x13);
            this.LabelLoadInfo.TabIndex = 13;
            this.LabelLoadInfo.Text = "      正在导出，请稍候...";
            this.LabelLoadInfo.TextAlign = ContentAlignment.MiddleLeft;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x178, 0x1a8);
            base.Controls.Add(this.panelBar);
            base.Controls.Add(this.panelData);
//            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormExportSub";
            base.Padding = new Padding(10, 0, 10, 0);
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "成果上报";
            base.Load += new EventHandler(this.FormExportSub_Load);
            base.FormClosing += new FormClosingEventHandler(this.FormExportSub_FormClosing);
            this.panelData.ResumeLayout(false);
            this.panelOption.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panelLDOption.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.checkEditLDExcel.Properties.EndInit();
            this.checkEditLD.Properties.EndInit();
            this.panelZYOption.ResumeLayout(false);
            this.checkEditDbf.Properties.EndInit();
            this.checkEditShape.Properties.EndInit();
            this.checkEditExcel.Properties.EndInit();
            this.panelCheck.ResumeLayout(false);
            this.radioGroupType.Properties.EndInit();
            this.panel4.ResumeLayout(false);
            this.panelBar.EndInit();
            this.panelBar.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void MergeCell(ref _Worksheet mySheet, int startLine, int recCount, int col)
        {
            string str = ((Microsoft.Office.Interop.Excel.Range) mySheet.Cells[startLine, col]).Text.ToString();
            bool flag = false;
            int num = startLine;
            while ((num <= ((recCount + startLine) - 1)) && !flag)
            {
                for (int i = num + 1; i <= ((recCount + startLine) - 1); i++)
                {
                    Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range) mySheet.Cells[i, col];
                    if (range.Text.ToString().Trim().Trim() == str.Trim())
                    {
                        try
                        {
                            range = mySheet.get_Range(mySheet.Cells[num, col], mySheet.Cells[i, col]);
                            range.ClearContents();
                            range.MergeCells = true;
                            mySheet.Cells[num, col] = str;
                        }
                        catch
                        {
                            num = i;
                            str = mySheet.get_Range(mySheet.Cells[num, col], mySheet.Cells[i, col]).Text.ToString();
                            continue;
                        }
                        if (i == ((recCount + startLine) - 1))
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        num = i;
                        str = mySheet.get_Range(mySheet.Cells[num, col], mySheet.Cells[i, col]).Text.ToString();
                        continue;
                    }
                }
            }
        }

        private void MergeCell2(ref _Worksheet mySheet, int startLine, int recCount, int col1, int col2)
        {
            string str = "";
            for (int i = startLine; i <= ((recCount + startLine) - 1); i++)
            {
                str = ((Microsoft.Office.Interop.Excel.Range) mySheet.Cells[startLine, col1]).Text.ToString();
                Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range) mySheet.Cells[i, col2];
                if (range.Text.ToString().Trim().Trim() == str.Trim())
                {
                    range = mySheet.get_Range(mySheet.Cells[i, col1], mySheet.Cells[i, col2]);
                    range.ClearContents();
                    range.MergeCells = true;
                    mySheet.Cells[i, col1] = str;
                }
            }
        }

        private bool ModifyZYData(IWorkspace pTargetWorkspace, string sTargetName, string sLastTableName, ref int iLoad)
        {
            bool flag = false;
            IWorkspaceEdit edit = (IWorkspaceEdit) pTargetWorkspace;
            IFeatureWorkspace pWs = (IFeatureWorkspace) pTargetWorkspace;
            IFeatureClass o = ConvertData.OpenFeatureClass(pWs, sTargetName);
            ITable table = (ITable) o;
            iLoad += 5;
            this.SetLoadInfo("正在修改小班图层数据……", iLoad);
            flag = false;
            edit.StartEditing(false);
            try
            {
                string[] strArray = new string[] { "DI_LEI", "Q_DI_LEI", "BHYY", "BHYY", "BHYY", "BHYY", "BHYY", "BHYY", "BHYY", "BHYY" };
                string[] strArray2 = new string[] { "603", "603", "1", "2", "3", "4", "5", "6", "7", "9" };
                string[] strArray3 = new string[] { "DI_LEI like '603_'", "Q_DI_LEI like '603_'", "BHYY='10' or BHYY='11' or BHYY='13' or BHYY='31'", "BHYY='12'", "BHYY='81'", "BHYY='20' or BHYY='21' or BHYY='22' or BHYY='23' or BHYY='24'", "BHYY='40' or BHYY='41' or BHYY='42'", "BHYY='50'", "BHYY='71'", "BHYY='72' or BHYY='73'" };
                for (int i = 0; i < strArray.Length; i++)
                {
                    edit.StartEditOperation();
                    try
                    {
                        string name = strArray[i];
                        int index = table.Fields.FindField(name);
                        string str2 = strArray2[i];
                        IQueryFilter queryFilter = new QueryFilterClass();
                        queryFilter.WhereClause = strArray3[i];
                        queryFilter.SubFields = name;
                        ICursor cursor = table.Update(queryFilter, false);
                        for (IRow row = cursor.NextRow(); row != null; row = cursor.NextRow())
                        {
                            row.set_Value(index, str2);
                            cursor.UpdateRow(row);
                        }
                        edit.StopEditOperation();
                        Marshal.ReleaseComObject(queryFilter);
                        Marshal.ReleaseComObject(cursor);
                    }
                    catch
                    {
                        edit.AbortEditOperation();
                    }
                    GC.Collect();
                }
                edit.StopEditing(true);
                flag = true;
            }
            catch (Exception exception)
            {
                edit.StopEditing(false);
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "ExpertZYDataData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("修改数据出错！", "提示");
                flag = false;
                goto Label_02A1;
            }
            flag = true;
        Label_02A1:
            Marshal.ReleaseComObject(table);
            Marshal.ReleaseComObject(o);
            GC.Collect();
            return flag;
        }

        private void PrepareLDData()
        {
            try
            {
                this.m_LoadLength = 100;
                System.Windows.Forms.Application.DoEvents();
                this.SetLoadInfo("正在准备数据……", 5);
                string taskYear = EditTask.TaskYear;
                (int.Parse(taskYear) - 1).ToString();
                IFeatureWorkspace editWorkspace = EditTask.EditWorkspace;
                IFeatureClass pNdFClass = ConvertData.OpenFeatureClass(editWorkspace, "FOR_XIAOBAN_" + taskYear);
                if (pNdFClass == null)
                {
                    MessageBox.Show("小班年度的图层数据源丢失，数据预处理失败！", "提示");
                    return;
                }
                if (pNdFClass.FindField("Q_BH_DJ") < 0)
                {
                    MessageBox.Show("数据预处理失败！请去系统管理检查数据库是否为最新版本。", "提示");
                    return;
                }
                LDStatis statis = new LDStatis();
                IFeatureClass pLDFClass = null;
              //  IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                string sCmdText = "select V_VALUE from T_SYS_DB_INFO where V_ITEM='LD_STEP'";
                object obj2 = null;// dBAccess.ExecuteScalar(sCmdText);
                if (obj2 == null)
                {
                    sCmdText = "insert into T_SYS_DB_INFO values ('LD_STEP','0','导出林地步骤')";
                 //   dBAccess.ExecuteNonQuery(sCmdText);
                    sCmdText = "insert into T_SYS_DB_INFO values ('LD_OID','0','导出林地错误OBJECTID')";
                 //   dBAccess.ExecuteNonQuery(sCmdText);
                }
                else
                {
                    sCmdText = "select V_VALUE from T_SYS_DB_INFO where V_ITEM='LD_OID'";
                  //  dBAccess.ExecuteScalar(sCmdText).ToString();
                    string str3 = obj2.ToString();
                    switch (str3)
                    {
                        case "3":
                        case "4":
                            if (DialogResult.No == MessageBox.Show("    是否重新进行数据预处理？点击【是】，继续；点击【否】，取消处理。", "提示", MessageBoxButtons.YesNo))
                            {
                                return;
                            }
                            statis.SaveRecord("0", "0");
                            goto Label_01DB;

                        case "0":
                            goto Label_01DB;
                    }
                    DialogResult result = MessageBox.Show("    是否继续上次的处理？点击【是】，继续；点击【否】，则重新进行预处理；点击【取消】，取消处理。", "提示", MessageBoxButtons.YesNoCancel);
                    if (DialogResult.Yes == result)
                    {
                        if (str3 == "1")
                        {
                            pLDFClass = ConvertData.OpenFeatureClass(editWorkspace, "FOR_LD");
                            if (pLDFClass == null)
                            {
                                MessageBox.Show("无法继续进行处理！请选择重新进行预处理。");
                            }
                            goto Label_022D;
                        }
                        if (str3 != "2")
                        {
                            goto Label_01DB;
                        }
                        pLDFClass = ConvertData.OpenFeatureClass(editWorkspace, "FOR_LD");
                        if (pLDFClass == null)
                        {
                            MessageBox.Show("无法继续进行处理！请选择重新进行预处理。");
                        }
                        goto Label_0280;
                    }
                    if (DialogResult.Cancel == result)
                    {
                        return;
                    }
                }
            Label_01DB:
                System.Windows.Forms.Application.DoEvents();
                this.SetLoadInfo("正在生成林地年度数据……", 10);
                pLDFClass = statis.PrepareLDData(pNdFClass, "FOR_LD");
                if (pLDFClass == null)
                {
                    MessageBox.Show("林地年度数据生成失败！", "提示");
                    return;
                }
                statis.SaveRecord("1", "");
                statis.ClearMemory();
            Label_022D:
                System.Windows.Forms.Application.DoEvents();
                this.SetLoadInfo("正在生成林地政区数据……", 30);
                if (statis.PrepareLDLB(pLDFClass, "FOR_LD_LB") == null)
                {
                    MessageBox.Show("林地政区数据生成失败！", "提示");
                    return;
                }
                statis.SaveRecord("2", "");
                statis.ClearMemory();
            Label_0280:
                System.Windows.Forms.Application.DoEvents();
                this.SetLoadInfo("正在生成林地变化数据……", 60);
                IFeatureClass pELFClass = ConvertData.OpenFeatureClass(EditTask.EditWorkspace, "FOR_ELBH_" + taskYear);
                if (statis.PrepareLDStatisData(pELFClass, pNdFClass, pLDFClass.Fields, "FOR_LDSTATIS") == null)
                {
                    MessageBox.Show("林地变化数据生成失败！", "提示");
                }
                else
                {
                    statis.SaveRecord("3", "");
                    statis.ClearMemory();
                    System.Windows.Forms.Application.DoEvents();
                    this.SetLoadInfo("数据预处理完成……", 100);
                    MessageBox.Show("数据预处理完成！", "提示");
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "PrepareLDData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("数据预处理出错！", "提示");
            }
        }

        private void radioGroupType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroupType.SelectedIndex == 0)
            {
                this.simpleButtonExport.Enabled = true;
                this.labelType.Text = "    导出森林资源更新成果数据（包括附表、林地变化小班数据、小班数据、乡村代码表)";
                this.panelZYOption.Visible = true;
                this.panelLDOption.Visible = false;
                this.m_ExportType = 0;
            }
            else if (this.radioGroupType.SelectedIndex == 1)
            {
                this.simpleButtonExport.Enabled = true;
                this.labelType.Text = "    导出资源数据（包括变化小班与年度小班）";
                this.panelZYOption.Visible = false;
                this.panelLDOption.Visible = false;
                this.m_ExportType = 1;
            }
            else if (this.radioGroupType.SelectedIndex == 2)
            {
                this.simpleButtonExport.Enabled = true;
                this.labelType.Text = "    导出林地数据（包括林地变更小班与林地年度小班)";
                this.panelZYOption.Visible = false;
                this.panelLDOption.Visible = true;
                this.m_ExportType = 2;
            }
            else if (this.radioGroupType.SelectedIndex == 3)
            {
                this.simpleButtonExport.Enabled = true;
                this.labelType.Text = "    导出林地审核审批台账记录表、林地增减台账记录表、违法使用林地台账记录表、林地台账统计表、国家公益林情况统计表";
                this.panelZYOption.Visible = false;
                this.panelLDOption.Visible = false;
                this.m_ExportType = 3;
            }
            else
            {
                this.simpleButtonExport.Enabled = false;
                this.labelType.Text = "";
                this.panelZYOption.Visible = false;
                this.panelLDOption.Visible = false;
                this.m_ExportType = -1;
            }
        }

        private void ReleaseWorkspace(string sFullPath)
        {
            IWorkspaceName o = new WorkspaceNameClass();
            o.WorkspaceFactoryProgID = "esriDataSourcesGDB.FileGDBWorkspaceFactory";
            o.PathName = sFullPath;
            IWorkspaceFactory workspaceFactory = o.WorkspaceFactory;
            IWorkspaceFactoryLockControl control = (IWorkspaceFactoryLockControl) workspaceFactory;
            if (control.SchemaLockingEnabled)
            {
                control.DisableSchemaLocking();
            }
            Marshal.ReleaseComObject(control);
            Marshal.ReleaseComObject(workspaceFactory);
            Marshal.ReleaseComObject(o);
        }

        private bool SetDataDtsrc(string sTableName1, string sTableName2)
        {
            string str = "备份统计数据";
            try
            {
                //IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                //if (dBAccess == null)
                //{
                //    MessageBox.Show("数据库连接失败！", "提示");
                //    return false;
                //}
                string str2 = "BAK2";
                string sCmdText = "update " + sTableName2 + " set " + str2 + "=0";
             //   if (dBAccess.ExecuteNonQuery(sCmdText) < 0)
                {
                    MessageBox.Show(str + "出错！", "提示");
                    return false;
                }
                sCmdText = ("update t2 set t2." + str2 + "=12 from " + sTableName2 + " t2") + " where (t2.Q_DI_LEI in('111','112','120','130','301','961','962','963')) and (t2.DI_LEI in('111','112','120','130','301','961','962','963')) and (t2.BHYY in('11','12','13'))";
             //   if (dBAccess.ExecuteNonQuery(sCmdText) < 0)
                {
                    MessageBox.Show(str + "出错！", "提示");
                    return false;
                }
                str2 = "BAK1";
                sCmdText = "update " + sTableName2 + " set " + str2 + "=0";
             //   if (dBAccess.ExecuteNonQuery(sCmdText) < 0)
                {
                    MessageBox.Show(str + "出错！", "提示");
                    return false;
                }
                sCmdText = ("update t2 set t2." + str2 + "=round(t2.MIAN_JI/t1.MIAN_JI*t1.SSZZS,0) from " + sTableName1 + " t1," + sTableName2 + " t2") + " where t1.SSLX='2' and t1.CUN=t2.CUN and t1.LIN_BAN=t2.LIN_BAN and t1.XIAO_BAN=right(t2.XI_BAN,len(t2.XI_BAN)-charindex('-',t2.XI_BAN))";
              //  if (dBAccess.ExecuteNonQuery(sCmdText) < 0)
                {
                    MessageBox.Show(str + "出错！", "提示");
                    return false;
                }
                sCmdText = ("update t2 set t2." + str2 + "=round(t2.MIAN_JI/t1.MIAN_JI*t1.SSZZS,0) from " + sTableName1 + " t1," + sTableName2 + " t2") + " where t1.SSLX='2' and t1.CUN=t2.CUN and t1.LIN_BAN=t2.LIN_BAN and t1.XIAO_BAN=t2.XIAO_BAN";
              //  if (dBAccess.ExecuteNonQuery(sCmdText) < 0)
                {
                    MessageBox.Show(str + "出错！", "提示");
                    return false;
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GeoDataIE.FormExportSub", "SetDataDtsrc", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show(str + "出错！", "提示");
                return false;
            }
        }

        private void SetLoadInfo(string sInfo, int iValue)
        {
            if (!base.InvokeRequired)
            {
                if (iValue != 100)
                {
                    iValue = (iValue * 100) / this.m_LoadLength;
                }
                if (iValue >= 100)
                {
                    iValue = 100;
                }
                this.LabelLoadInfo.Text = string.Concat(new object[] { "      ", sInfo, "（", iValue, "%）" });
                this.LabelProgressBar.Width = ((this.LabelProgressBack.Width - 2) * iValue) / 100;
                this.LabelProgressBar.BringToFront();
                this.Refresh();
            }
            else
            {
                base.Invoke(new DeleSetLoadInfo(this.SetLoadInfo), new object[] { sInfo, iValue });
            }
        }

        private void simpleButtonExport_Click(object sender, EventArgs e)
        {
            this.Export();
        }

        private void simpleButtonPrepare_Click(object sender, EventArgs e)
        {
            this.panelBar.Visible = true;
            this.panelData.Enabled = false;
            this.PrepareLDData();
            this.panelBar.Visible = false;
            this.panelData.Enabled = true;
        }

        private delegate void DeleSetLoadInfo(string sInfo, int iValue);
    }
}

