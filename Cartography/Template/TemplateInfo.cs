namespace Cartography.Template
{
    using System;
    using System.Text;
    using td.db.orm;
    using td.forest.task.linker;
    using Utilities;

    /// <summary>
    /// 模板信息
    /// </summary>
    public class TemplateInfo
    {
        private SystemType _sysType;
        private BusinessType _templateBusiness;
        private Direction _templateDirection;
        private string _tf;
        public static TemplateInfo CurrentTemplateInfo;
         public DB2LayerModelManager DMM { get { return DBServiceFactory<DB2LayerModelManager>.Service; } }
        public string GetFullName()
        {
            StringBuilder builder = new StringBuilder();
            string str = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("CartoTemplatePath") + @"\";
            ///string str = DMM.CartoTemplatePath;///此处会使路径调用陷入死循环
            builder.Append(str);
            if (this._sysType == SystemType.ZYGL)
            {
                switch (this._templateBusiness)
                {
                    case BusinessType.ZaoLinSJ:
                        builder.Append("编辑任务-造林");
                        break;

                    case BusinessType.ZaoLinDC:
                        builder.Append("编辑任务-造林调查");
                        break;

                    case BusinessType.ZaoLINCX:
                        builder.Append("查询-造林");
                        break;

                    case BusinessType.CaiFaSJ:
                        builder.Append("编辑任务-采伐");
                        break;

                    case BusinessType.CaiFaDC:
                        builder.Append("编辑任务-采伐调查");
                        break;

                    case BusinessType.CaiFaCX:
                        builder.Append("查询-采伐");
                        break;

                    case BusinessType.ZZDC:
                        builder.Append("编辑任务-征占用");
                        break;

                    case BusinessType.ZZWZ:
                        builder.Append("编辑任务-征占用位置");
                        break;

                    case BusinessType.ZZCX:
                        builder.Append("查询-征占用");
                        break;

                    case BusinessType.HZBJ:
                        builder.Append("编辑任务-火灾");
                        break;

                    case BusinessType.HZCX:
                        builder.Append("查询-火灾");
                        break;

                    case BusinessType.AJBJ:
                        builder.Append("编辑任务-林业案件");
                        break;

                    case BusinessType.AJCX:
                        builder.Append("查询-林业案件");
                        break;

                    case BusinessType.NDXBBJ:
                        builder.Append("编辑任务-年度小班");
                        break;

                    case BusinessType.NDXBCX:
                        builder.Append("查询-年度小班");
                        break;

                    case BusinessType.XBBJ:
                        builder.Append("编辑任务-小班");
                        break;

                    case BusinessType.XBCX:
                        builder.Append("查询-小班");
                        break;

                    case BusinessType.ZHBJ:
                        builder.Append("编辑任务-自然灾害");
                        break;

                    case BusinessType.ZHCX:
                        builder.Append("查询-自然灾害");
                        break;

                    case BusinessType.YGBJ:
                        builder.Append("编辑任务-遥感");
                        break;
                }
            }
            else if (this._sysType == SystemType.FQSJ)
            {
                switch (this._templateBusiness)
                {
                    case BusinessType.CaiFaSJ:
                        builder.Append("编辑任务-采伐作业");
                        break;

                    case BusinessType.CaiFaDC:
                        builder.Append("编辑任务-采伐作业调查");
                        break;
                }
            }
            else
            {
                switch (this._templateBusiness)
                {
                    case BusinessType.ZZDC:
                        builder.Append("编辑任务-征占用项目");
                        break;

                    case BusinessType.ZZWZ:
                        builder.Append("编辑任务-征占用项目位置");
                        break;

                    case BusinessType.ZZCX:
                        builder.Append("查询-征占用");
                        break;
                }
            }
            switch (this._templateDirection)
            {
                case Direction.Heng:
                    if (this._tf != "A4")
                    {
                        builder.Append("3.mxd");
                        break;
                    }
                    builder.Append(".mxd");
                    break;

                case Direction.Zong:
                    if (this._tf != "A4")
                    {
                        builder.Append("4.mxd");
                        break;
                    }
                    builder.Append("2.mxd");
                    break;
            }
            return builder.ToString();
        }

        public SystemType SysType
        {
            get
            {
                return this._sysType;
            }
            set
            {
                this._sysType = value;
            }
        }

        public BusinessType TemplateBusiness
        {
            get
            {
                return this._templateBusiness;
            }
            set
            {
                this._templateBusiness = value;
            }
        }

        public Direction TemplateDirection
        {
            get
            {
                return this._templateDirection;
            }
            set
            {
                this._templateDirection = value;
            }
        }

        public string TF
        {
            get
            {
                return this._tf;
            }
            set
            {
                this._tf = value;
            }
        }
    }
}

