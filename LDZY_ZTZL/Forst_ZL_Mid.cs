using System;
using System.Collections.Generic;
using System.Text;

namespace td.db.gis
{
    /// <summary>
    /// 造林统计的底层数据操作类
    /// </summary>
    public class Forst_ZL_Mid
    {
        public string SHI { get; set; }
        public string XIAN { get; set; }
        public string XIANG { get; set; }
        public string CUN { get; set; }


        public string LD_QS { get; set; }
        /// <summary>
        /// 土地使用权
        /// </summary>
        public string TDJYQ { get; set; }

        /// <summary>
        /// 返回转换为数字后的“土地使用权”数据
        /// </summary>
        public int TDJYQ_I { get { return Convert.ToInt32(TDJYQ); } }
        public string LMSYQ { get; set; }
        /// <summary>
        /// 前期地类
        /// </summary>
        public string Q_DI_LEI { get; set; }
        public double HSMJ { get; set; }
        public double MIAN_JI { get; set; }
        public double SSZZS { get; set; }
        /// <summary>
        /// 林种
        /// </summary>
        public string LIN_ZHONG { get; set; }
        /// <summary>
        /// 返回转换为数字后的“林种”数据
        /// </summary>
        public int LIN_ZHONG_I { get { return Convert.ToInt32(LIN_ZHONG); } }
        public string YOU_SHI_SZ { get; set; }
        /// <summary>
        /// 返回转换为数字后的“优势树种”数据
        /// </summary>
        public int YOU_SHI_SZ_I { get { return Convert.ToInt32(YOU_SHI_SZ); } }

        /// <summary>
        /// 返回造林类别
        /// </summary>
        public string ZAO_LIN_LB { get; set; }

        /// <summary>
        /// 返回转换为数字后的“造林类别”数据
        /// </summary>
        public int ZAO_LIN_LB_I { get { return Convert.ToInt32(ZAO_LIN_LB); } }

        /// <summary>
        /// 资金来源
        /// </summary>
        public string ZJLY { get; set; }
        /// <summary>
        /// 工程类别
        /// </summary>
         public string G_CHENG_LB { get; set; }
        public string SEN_LIN_LB { get; set; }

        /// <summary>
        /// 造林类别：低产林改造造林
        /// </summary>
        public bool digaizaolin
        {
            get
            {
                return ZAO_LIN_LB == "122";
            }
        }

        /// <summary>
        /// 资金来源：中央财政
        /// </summary>
        public bool zytzwc
        {
            get
            {
                return ZJLY == "71";
            }
        }

        /// <summary>
        /// 造林类别：农地造林
        /// </summary>
        public bool nongdizaolin
        {
            get
            {
                return ZAO_LIN_LB == "140";
            }
        }

        /// <summary>
        /// 造林类别：种草
        /// </summary>
        public bool zhongcao
        {
            get
            {
                return ZAO_LIN_LB == "130";
            }
        }
 
        /// <summary>
        /// 工程类别：速生用材林
        /// </summary>
        public bool ssfcycl
        {
            get
            {
                return G_CHENG_LB.StartsWith("6");
            }
        }
     
        /// <summary>
        /// 工程类别：平原绿化工程
        /// </summary>
        public bool pingyuanlh
        {
            get
            {
                return G_CHENG_LB == "27";
            }
        }
        /// <summary>
        ///  工程类别：珠江流域防护林体系建设工程
        /// </summary>
        public bool zhufanglin
        {
            get
            {
                return G_CHENG_LB == "25";
            }
        }
     
        /// <summary>
        /// 工程类别：沿海防护林体系建设工程
        /// </summary>
        public bool haifanglin
        {
            get
            {
                return G_CHENG_LB == "24";
            }
        }
        /// <summary>
        /// 工程类别：退耕配套荒山荒地造林
        /// </summary>
        public bool tgpthszl
        {
            get
            {
                return G_CHENG_LB == "32";
            }
        }

        /// <summary>
        /// 工程类别：退耕地造林
        /// </summary>
        public bool tgdzlgclb
        {
            get
            {
                return G_CHENG_LB == "31";
            }
        }

        /// <summary>
        /// 造林类别：成林抚育
        /// </summary>
        public bool chenglin
        {
            get
            {
                return ZAO_LIN_LB_I == 124;
            }
        }

        /// <summary>
        /// 造林类别：幼林抚育
        /// </summary>
        public bool youlinfuyu
        {
            get
            {
                return ZAO_LIN_LB_I == 123;
            }
        }

        /// <summary>
        /// “荒山造林”、“沙荒造林”、“其他宜林地造林”、“退耕地造林”；获取“造林类别”》100并《114
        /// </summary>
        public bool rgzl
        {
            get
            {
                return ZAO_LIN_LB_I > 110 && ZAO_LIN_LB_I <= 114;
            }
        }

        /// <summary>
        /// “退耕地造林”；造林类别：退耕地造林
        /// </summary>
        public bool tgdzl
        {
            get
            {
                return ZAO_LIN_LB == "114";
            }
        }

        /// <summary>
        /// “宜林荒山荒地”，“宜林沙荒地”、“其他宜林地”、“退耕牧地”；判断"前期地类"的开头是否为17
        /// </summary>
        public bool huangshandi
        {
            get
            {
                return Q_DI_LEI.StartsWith("17");

            }
        }

        /// <summary>
        /// 判断优势树种是否大于》=400并《=430
        /// </summary>
        public bool zhulin
        {
            get
            {
                return YOU_SHI_SZ_I >= 400 && YOU_SHI_SZ_I < 430;

            }
        }
        /// <summary>
        /// “飞播造林”；判断造林类别是否为“115”
        /// </summary>
        public bool feibozaolin
        {
            get
            {
                return ZAO_LIN_LB == "115";

            }
        }
        /// <summary>
        /// “无林和疏林新封”；判断造林类别是否为“116”
        /// </summary>
        public bool wulinxinfeng
        {
            get
            {
                return ZAO_LIN_LB == "116";

            }
        }

        /// <summary>
        /// “国有”、“其他国有”；判断并返回“土地使用权”=“1”或者“3”
        /// </summary>
        public bool guoyoujjzaolin
        {
            get
            {
                return TDJYQ == "1" || TDJYQ == "3";

            }
        }
        
        /// <summary>
        /// “集体”、“联营”；判断并返回“土地使用权”=“2”或者“4”
        /// </summary>
        public bool jitijjzaolin
        {
            get
            {
                return TDJYQ == "2" || TDJYQ == "4";

            }
        }

        /// <summary>
        /// “非公有”、“”个人、，“被占”“其他”；判断并返回“土地使用权”>=“5”
        /// </summary>
        public bool feigongjjzaolin
        {
            get
            {
                return TDJYQ_I >= 5;

            }
        }
        /// <summary>
        /// “杉木类”、“杉木”、“柳杉”、“其他杉类”；判断并返回“优势树种”>=120，《124
        /// </summary>
        public bool shamu
        {
            get
            {
                return YOU_SHI_SZ_I >= 120 && YOU_SHI_SZ_I < 124;

            }
        }

        /// <summary>
        /// 返回杉类
        /// </summary>
        public bool songlei
        {
            get
            {
                return (YOU_SHI_SZ_I >= 130 && YOU_SHI_SZ_I < 133) || (YOU_SHI_SZ_I >= 110 && YOU_SHI_SZ_I < 115) || (YOU_SHI_SZ_I >= 140 && YOU_SHI_SZ_I < 164);

            }
        }

        /// <summary>
        /// 返回桉树
        /// </summary>
        public bool anshu
        {
            get
            {
                return YOU_SHI_SZ_I >= 280 && YOU_SHI_SZ_I < 308;

            }
        }

        /// <summary>
        /// 返回相思类树
        /// </summary>
        public bool xiangsi
        {
            get
            {
                return (YOU_SHI_SZ_I >= 310 && YOU_SHI_SZ_I < 321) || YOU_SHI_SZ_I == 331;

            }
        }

        /// <summary>
        /// 其他树种
        /// </summary>
        public bool yclqita
        {
            get
            {
                return (YOU_SHI_SZ_I >= 200 && YOU_SHI_SZ_I < 274) || YOU_SHI_SZ_I == 330 || (YOU_SHI_SZ_I >= 332 && YOU_SHI_SZ_I < 352);

            }
        }

        /// <summary>
        /// 造林类别：速生丰产用材林
        /// </summary>
        public bool sushengfcl
        {
            get
            {
                return LIN_ZHONG == "232";

            }
        }

        /// <summary>
        /// 优势树种：油茶
        /// </summary>
        public bool youcha
        {
            get
            {
                return YOU_SHI_SZ == "661";

            }
        }

        /// <summary>
        /// 优势树种：油桐
        /// </summary>
        public bool youtong
        {
            get
            {
                return YOU_SHI_SZ == "688";

            }
        }

        /// <summary>
        /// 优势树种：八角
        /// </summary>
        public bool bajiao
        {
            get
            {
                return YOU_SHI_SZ == "663";

            }
        }

        /// <summary>
        /// 优势树种：玉桂
        /// </summary>
        public bool yugui
        {
            get
            {
                return YOU_SHI_SZ == "681";

            }
        }

        /// <summary>
        /// 优势树种：核桃
        /// </summary>
        public bool hetao
        {
            get
            {
                return YOU_SHI_SZ == "639";

            }
        }

        /// <summary>
        /// 优势树种：板栗
        /// </summary>
        public bool banli
        {
            get
            {
                return YOU_SHI_SZ == "617";

            }
        }

        /// <summary>
        /// 优势树种：银杏
        /// </summary>
        public bool yinxing
        {
            get
            {
                return YOU_SHI_SZ == "691";

            }
        }

        /// <summary>
        /// 优势树种：果树
        /// </summary>
        public bool guoshu
        {
            get
            {
                return (YOU_SHI_SZ_I >= 610 && YOU_SHI_SZ_I < 647) && YOU_SHI_SZ_I != 617 && YOU_SHI_SZ_I != 639;

            }
        }

        /// <summary>
        /// 优势树种：其他经济林
        /// </summary>
        public bool jjlqita
        {
            get
            {
                return (YOU_SHI_SZ_I >= 660 && YOU_SHI_SZ_I < 705) && YOU_SHI_SZ_I != 661 && YOU_SHI_SZ_I != 663 && YOU_SHI_SZ_I != 681 && YOU_SHI_SZ_I != 688 && YOU_SHI_SZ_I != 691;

            }
        }

        /// <summary>
        /// 林种：防护林
        /// </summary>
        public bool fanghulin
        {
            get
            {
                return LIN_ZHONG_I >= 110 && LIN_ZHONG_I <= 117;

            }
        }

        /// <summary>
        /// 林种：薪炭林
        /// </summary>
        public bool xintanlin
        {
            get
            {
                return LIN_ZHONG_I == 240;

            }
        }

        /// <summary>
        /// 林种：特用林
        /// </summary>
        public bool teyonglin
        {
            get
            {
                return LIN_ZHONG_I >= 120 && LIN_ZHONG_I <= 127;

            }
        }

        /// <summary>
        /// 林种：其他防护林
        /// </summary>
        public bool linguanxiazaolin
        {
            get
            {
                return LIN_ZHONG_I == 117;

            }
        }

        /// <summary>
        /// 造林类别：飞播造林 和（荒山造林 或 沙荒造林 或 人工更新 或 种草）
        /// </summary>
        public bool feibolinb2
        {
            get
            {
                return ZAO_LIN_LB_I == 115 && (Q_DI_LEI == "111" || Q_DI_LEI == "112" || Q_DI_LEI == "120" || Q_DI_LEI == "130");

            }
        }

        /// <summary>
        ///  造林类别：有林地和灌木林新封
        /// </summary>
        public bool youlindixinfeng
        {
            get
            {
                return ZAO_LIN_LB_I == 119;

            }
        }

        /// <summary>
        ///  造林类别：人工更新
        /// </summary>
        public bool gengxinzaolin
        {
            get
            {
                return ZAO_LIN_LB_I == 120;

            }
        }

        /// <summary>
        /// 前期地类：迹地更新
        /// </summary>
        public bool jidisql
        {
            get
            {
                return (Q_DI_LEI=="601" || Q_DI_LEI =="602" || Q_DI_LEI=="6031");

            }
        }

        /// <summary>
        /// 造林类别：人工促进天然更新||萌芽更新
        /// </summary>
        public bool rengongcujingengxin
        {
            get
            {
                return ZAO_LIN_LB == "125" || ZAO_LIN_LB=="126";

            }
        }

        /// <summary>
        /// 造林类别：人工更新||迹地更新||人工促进天然更新||萌芽更新
        /// </summary>
        public bool gengxinzaolin2
        {
            get
            {
                return ZAO_LIN_LB == "120" || ZAO_LIN_LB == "121" || ZAO_LIN_LB == "125" || ZAO_LIN_LB == "126";

            }
        }
        /// <summary>
        /// 用材林：林种：断轮伐期工业原料、速生丰产用材林、一般用材林
        /// </summary>
        public bool yongcailin
        {
            get
            {
                return LIN_ZHONG_I > 230 && LIN_ZHONG_I<234;

            }
        }

        /// <summary>
        /// 林种：经济林
        /// </summary>
        public bool jingjilin
        {
            get
            {
                return LIN_ZHONG_I > 250 && LIN_ZHONG_I < 255;

            }
        }
       
        /// <summary>
        /// 更新时间
        /// </summary>
        public string GXSJ { get; set; }

    }
}
