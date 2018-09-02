namespace Tj
{
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraBars.Helpers;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.BandedGrid;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraNavBar;
    using DevExpress.XtraPrinting;
    using DevExpress.XtraPrinting.Preview;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    using TJ_DLL;
    using DevExpress.XtraGrid.Views.Base;

    public class Form1 : RibbonForm
    {
        private BarButtonGroup alignButtonGroup;
        private BandedGridColumn bandedGridColumn1;
        private BandedGridColumn bandedGridColumn10;
        private BandedGridColumn bandedGridColumn100;
        private BandedGridColumn bandedGridColumn101;
        private BandedGridColumn bandedGridColumn102;
        private BandedGridColumn bandedGridColumn103;
        private BandedGridColumn bandedGridColumn104;
        private BandedGridColumn bandedGridColumn105;
        private BandedGridColumn bandedGridColumn106;
        private BandedGridColumn bandedGridColumn107;
        private BandedGridColumn bandedGridColumn108;
        private BandedGridColumn bandedGridColumn109;
        private BandedGridColumn bandedGridColumn11;
        private BandedGridColumn bandedGridColumn110;
        private BandedGridColumn bandedGridColumn111;
        private BandedGridColumn bandedGridColumn112;
        private BandedGridColumn bandedGridColumn113;
        private BandedGridColumn bandedGridColumn114;
        private BandedGridColumn bandedGridColumn115;
        private BandedGridColumn bandedGridColumn116;
        private BandedGridColumn bandedGridColumn117;
        private BandedGridColumn bandedGridColumn12;
        private BandedGridColumn bandedGridColumn13;
        private BandedGridColumn bandedGridColumn138;
        private BandedGridColumn bandedGridColumn139;
        private BandedGridColumn bandedGridColumn14;
        private BandedGridColumn bandedGridColumn140;
        private BandedGridColumn bandedGridColumn141;
        private BandedGridColumn bandedGridColumn142;
        private BandedGridColumn bandedGridColumn143;
        private BandedGridColumn bandedGridColumn144;
        private BandedGridColumn bandedGridColumn145;
        private BandedGridColumn bandedGridColumn146;
        private BandedGridColumn bandedGridColumn147;
        private BandedGridColumn bandedGridColumn148;
        private BandedGridColumn bandedGridColumn149;
        private BandedGridColumn bandedGridColumn15;
        private BandedGridColumn bandedGridColumn150;
        private BandedGridColumn bandedGridColumn151;
        private BandedGridColumn bandedGridColumn152;
        private BandedGridColumn bandedGridColumn153;
        private BandedGridColumn bandedGridColumn154;
        private BandedGridColumn bandedGridColumn155;
        private BandedGridColumn bandedGridColumn156;
        private BandedGridColumn bandedGridColumn16;
        private BandedGridColumn bandedGridColumn17;
        private BandedGridColumn bandedGridColumn18;
        private BandedGridColumn bandedGridColumn19;
        private BandedGridColumn bandedGridColumn2;
        private BandedGridColumn bandedGridColumn20;
        private BandedGridColumn bandedGridColumn204;
        private BandedGridColumn bandedGridColumn205;
        private BandedGridColumn bandedGridColumn206;
        private BandedGridColumn bandedGridColumn207;
        private BandedGridColumn bandedGridColumn208;
        private BandedGridColumn bandedGridColumn209;
        private BandedGridColumn bandedGridColumn21;
        private BandedGridColumn bandedGridColumn210;
        private BandedGridColumn bandedGridColumn211;
        private BandedGridColumn bandedGridColumn212;
        private BandedGridColumn bandedGridColumn213;
        private BandedGridColumn bandedGridColumn214;
        private BandedGridColumn bandedGridColumn215;
        private BandedGridColumn bandedGridColumn216;
        private BandedGridColumn bandedGridColumn217;
        private BandedGridColumn bandedGridColumn218;
        private BandedGridColumn bandedGridColumn22;
        private BandedGridColumn bandedGridColumn23;
        private BandedGridColumn bandedGridColumn24;
        private BandedGridColumn bandedGridColumn25;
        private BandedGridColumn bandedGridColumn26;
        private BandedGridColumn bandedGridColumn27;
        private BandedGridColumn bandedGridColumn28;
        private BandedGridColumn bandedGridColumn29;
        private BandedGridColumn bandedGridColumn3;
        private BandedGridColumn bandedGridColumn30;
        private BandedGridColumn bandedGridColumn31;
        private BandedGridColumn bandedGridColumn32;
        private BandedGridColumn bandedGridColumn33;
        private BandedGridColumn bandedGridColumn34;
        private BandedGridColumn bandedGridColumn35;
        private BandedGridColumn bandedGridColumn36;
        private BandedGridColumn bandedGridColumn37;
        private BandedGridColumn bandedGridColumn38;
        private BandedGridColumn bandedGridColumn39;
        private BandedGridColumn bandedGridColumn4;
        private BandedGridColumn bandedGridColumn40;
        private BandedGridColumn bandedGridColumn41;
        private BandedGridColumn bandedGridColumn42;
        private BandedGridColumn bandedGridColumn43;
        private BandedGridColumn bandedGridColumn44;
        private BandedGridColumn bandedGridColumn45;
        private BandedGridColumn bandedGridColumn46;
        private BandedGridColumn bandedGridColumn47;
        private BandedGridColumn bandedGridColumn48;
        private BandedGridColumn bandedGridColumn49;
        private BandedGridColumn bandedGridColumn5;
        private BandedGridColumn bandedGridColumn50;
        private BandedGridColumn bandedGridColumn51;
        private BandedGridColumn bandedGridColumn52;
        private BandedGridColumn bandedGridColumn53;
        private BandedGridColumn bandedGridColumn54;
        private BandedGridColumn bandedGridColumn55;
        private BandedGridColumn bandedGridColumn56;
        private BandedGridColumn bandedGridColumn57;
        private BandedGridColumn bandedGridColumn58;
        private BandedGridColumn bandedGridColumn59;
        private BandedGridColumn bandedGridColumn6;
        private BandedGridColumn bandedGridColumn60;
        private BandedGridColumn bandedGridColumn61;
        private BandedGridColumn bandedGridColumn62;
        private BandedGridColumn bandedGridColumn63;
        private BandedGridColumn bandedGridColumn64;
        private BandedGridColumn bandedGridColumn65;
        private BandedGridColumn bandedGridColumn66;
        private BandedGridColumn bandedGridColumn67;
        private BandedGridColumn bandedGridColumn68;
        private BandedGridColumn bandedGridColumn69;
        private BandedGridColumn bandedGridColumn7;
        private BandedGridColumn bandedGridColumn70;
        private BandedGridColumn bandedGridColumn73;
        private BandedGridColumn bandedGridColumn74;
        private BandedGridColumn bandedGridColumn75;
        private BandedGridColumn bandedGridColumn76;
        private BandedGridColumn bandedGridColumn77;
        private BandedGridColumn bandedGridColumn78;
        private BandedGridColumn bandedGridColumn79;
        private BandedGridColumn bandedGridColumn8;
        private BandedGridColumn bandedGridColumn80;
        private BandedGridColumn bandedGridColumn81;
        private BandedGridColumn bandedGridColumn82;
        private BandedGridColumn bandedGridColumn83;
        private BandedGridColumn bandedGridColumn84;
        private BandedGridColumn bandedGridColumn85;
        private BandedGridColumn bandedGridColumn86;
        private BandedGridColumn bandedGridColumn87;
        private BandedGridColumn bandedGridColumn88;
        private BandedGridColumn bandedGridColumn89;
        private BandedGridColumn bandedGridColumn9;
        private BandedGridColumn bandedGridColumn90;
        private BandedGridColumn bandedGridColumn91;
        private BandedGridColumn bandedGridColumn92;
        private BandedGridColumn bandedGridColumn93;
        private BandedGridColumn bandedGridColumn94;
        private BandedGridColumn bandedGridColumn95;
        private BandedGridColumn bandedGridColumn96;
        private BandedGridColumn bandedGridColumn97;
        private BandedGridColumn bandedGridColumn98;
        private BandedGridColumn bandedGridColumn99;
        private BarButtonItem barButtonItem1;
        private BarButtonItem barButtonItem2;
        private BarButtonItem barButtonItem3;
        private BarButtonItem barButtonItem4;
        private BarButtonItem barButtonItem5;
        private BarButtonItem barButtonItem6;
        private BarStaticItem barStaticItem1;
        private BarButtonItem bBTN_Export;
        private BarButtonItem bBTN_LDBG_Print;
        private BarButtonItem bBTN_LDBG_TJ;
        private BarButtonItem bBTN_ZYGX_TJ;
        private BarEditItem bCHK_LDBG_GLLDDTZYTJB;
        private BarEditItem bCHK_LDBG_GLLDMJBGTJB;
        private BarEditItem bCHK_LDBG_GYLDMJBGTJB;
        private BarEditItem bCHK_LDBG_LDBHYYFXTJB;
        private BarEditItem bCHK_LDBG_SPLDMJBGTJB;
        private BarEditItem bCHK_ZYBH_B1_GLTDMJBHB;
        private BarEditItem bCHK_ZYBH_B2_GLSLLMMJXJBHB;
        private BarEditItem bCHK_ZYBH_B3_GLZMJXJBHB;
        private BarEditItem bCHK_ZYBH_B4_ZYSZMJXJBHB;
        private BarEditItem bCHK_ZYBH_B5_GYLDTJB;
        private BarEditItem bCHK_ZYBH_B5_YCLMJXJBHB;
        private BarEditItem bCHK_ZYGX_DLBHXBDCB;
        private BarButtonItem btn_Brow;
        private BarButtonItem btn_LDBG_Export;
        private BarButtonItem btn_ZYDC_ALL;
        private IContainer components;
        private BarButtonGroup fontStyleButtonGroup;
        private GridBand gBandLDBHB1DWND;
        private GridBand gBandLDBHB2DWND;
        private GridBand gBandLDBHB3DWND;
        private GridBand gBandLDBHB4DWND;
        private GridBand gBandLDBHB5DWND;
        private GridBand gBandZYBHB1DW;
        private GridBand gBandZYBHB2DW;
        private GridBand gBandZYBHB3DW;
        private GridBand gBandZYBHB4DW;
        private GridBand gBandZYBHB5DW;
        private BandedGridColumn gCol_GJGML;
        private BandedGridColumn gCol_GMLDXJ;
        private BandedGridColumn gCol_HJ;
        private BandedGridColumn gCol_HSL;
        private BandedGridColumn gCol_LYFZSCYD;
        private BandedGridColumn gCol_MPD;
        private BandedGridColumn gCol_QML;
        private BandedGridColumn gCol_QS;
        private BandedGridColumn gCol_QTGML;
        private BandedGridColumn gCol_SLD;
        private BandedGridColumn gCol_TJDW;
        private BandedGridColumn gCol_WCLD;
        private BandedGridColumn gCol_WLMLD;
        private BandedGridColumn gCol_YLD;
        private BandedGridColumn gCol_YLDXJ;
        private BandedGridColumn gCol_ZL;
        private GridBand gridBand1;
        private GridBand gridBand10;
        private GridBand gridBand100;
        private GridBand gridBand101;
        private GridBand gridBand102;
        private GridBand gridBand103;
        private GridBand gridBand104;
        private GridBand gridBand105;
        private GridBand gridBand106;
        private GridBand gridBand107;
        private GridBand gridBand108;
        private GridBand gridBand109;
        private GridBand gridBand11;
        private GridBand gridBand110;
        private GridBand gridBand111;
        private GridBand gridBand112;
        private GridBand gridBand113;
        private GridBand gridBand114;
        private GridBand gridBand115;
        private GridBand gridBand116;
        private GridBand gridBand117;
        private GridBand gridBand118;
        private GridBand gridBand119;
        private GridBand gridBand12;
        private GridBand gridBand120;
        private GridBand gridBand121;
        private GridBand gridBand122;
        private GridBand gridBand123;
        private GridBand gridBand124;
        private GridBand gridBand125;
        private GridBand gridBand126;
        private GridBand gridBand127;
        private GridBand gridBand128;
        private GridBand gridBand129;
        private GridBand gridBand13;
        private GridBand gridBand130;
        private GridBand gridBand131;
        private GridBand gridBand132;
        private GridBand gridBand133;
        private GridBand gridBand134;
        private GridBand gridBand135;
        private GridBand gridBand136;
        private GridBand gridBand137;
        private GridBand gridBand138;
        private GridBand gridBand139;
        private GridBand gridBand14;
        private GridBand gridBand140;
        private GridBand gridBand141;
        private GridBand gridBand142;
        private GridBand gridBand143;
        private GridBand gridBand144;
        private GridBand gridBand145;
        private GridBand gridBand146;
        private GridBand gridBand147;
        private GridBand gridBand148;
        private GridBand gridBand149;
        private GridBand gridBand15;
        private GridBand gridBand150;
        private GridBand gridBand151;
        private GridBand gridBand152;
        private GridBand gridBand153;
        private GridBand gridBand154;
        private GridBand gridBand155;
        private GridBand gridBand156;
        private GridBand gridBand157;
        private GridBand gridBand158;
        private GridBand gridBand159;
        private GridBand gridBand16;
        private GridBand gridBand160;
        private GridBand gridBand161;
        private GridBand gridBand162;
        private GridBand gridBand163;
        private GridBand gridBand164;
        private GridBand gridBand165;
        private GridBand gridBand166;
        private GridBand gridBand167;
        private GridBand gridBand168;
        private GridBand gridBand169;
        private GridBand gridBand17;
        private GridBand gridBand170;
        private GridBand gridBand171;
        private GridBand gridBand172;
        private GridBand gridBand173;
        private GridBand gridBand174;
        private GridBand gridBand175;
        private GridBand gridBand176;
        private GridBand gridBand177;
        private GridBand gridBand178;
        private GridBand gridBand179;
        private GridBand gridBand18;
        private GridBand gridBand180;
        private GridBand gridBand181;
        private GridBand gridBand182;
        private GridBand gridBand183;
        private GridBand gridBand184;
        private GridBand gridBand185;
        private GridBand gridBand186;
        private GridBand gridBand187;
        private GridBand gridBand188;
        private GridBand gridBand189;
        private GridBand gridBand19;
        private GridBand gridBand190;
        private GridBand gridBand191;
        private GridBand gridBand192;
        private GridBand gridBand193;
        private GridBand gridBand194;
        private GridBand gridBand195;
        private GridBand gridBand196;
        private GridBand gridBand197;
        private GridBand gridBand198;
        private GridBand gridBand199;
        private GridBand gridBand2;
        private GridBand gridBand20;
        private GridBand gridBand200;
        private GridBand gridBand201;
        private GridBand gridBand202;
        private GridBand gridBand203;
        private GridBand gridBand204;
        private GridBand gridBand205;
        private GridBand gridBand206;
        private GridBand gridBand207;
        private GridBand gridBand208;
        private GridBand gridBand209;
        private GridBand gridBand21;
        private GridBand gridBand210;
        private GridBand gridBand211;
        private GridBand gridBand212;
        private GridBand gridBand213;
        private GridBand gridBand214;
        private GridBand gridBand215;
        private GridBand gridBand216;
        private GridBand gridBand217;
        private GridBand gridBand218;
        private GridBand gridBand219;
        private GridBand gridBand22;
        private GridBand gridBand220;
        private GridBand gridBand221;
        private GridBand gridBand222;
        private GridBand gridBand223;
        private GridBand gridBand224;
        private GridBand gridBand225;
        private GridBand gridBand226;
        private GridBand gridBand227;
        private GridBand gridBand228;
        private GridBand gridBand229;
        private GridBand gridBand23;
        private GridBand gridBand230;
        private GridBand gridBand231;
        private GridBand gridBand232;
        private GridBand gridBand233;
        private GridBand gridBand234;
        private GridBand gridBand235;
        private GridBand gridBand236;
        private GridBand gridBand237;
        private GridBand gridBand238;
        private GridBand gridBand239;
        private GridBand gridBand24;
        private GridBand gridBand240;
        private GridBand gridBand241;
        private GridBand gridBand242;
        private GridBand gridBand243;
        private GridBand gridBand244;
        private GridBand gridBand245;
        private GridBand gridBand246;
        private GridBand gridBand247;
        private GridBand gridBand248;
        private GridBand gridBand249;
        private GridBand gridBand25;
        private GridBand gridBand250;
        private GridBand gridBand251;
        private GridBand gridBand252;
        private GridBand gridBand253;
        private GridBand gridBand254;
        private GridBand gridBand255;
        private GridBand gridBand256;
        private GridBand gridBand257;
        private GridBand gridBand258;
        private GridBand gridBand259;
        private GridBand gridBand26;
        private GridBand gridBand260;
        private GridBand gridBand261;
        private GridBand gridBand262;
        private GridBand gridBand263;
        private GridBand gridBand264;
        private GridBand gridBand265;
        private GridBand gridBand266;
        private GridBand gridBand267;
        private GridBand gridBand268;
        private GridBand gridBand269;
        private GridBand gridBand27;
        private GridBand gridBand270;
        private GridBand gridBand271;
        private GridBand gridBand272;
        private GridBand gridBand273;
        private GridBand gridBand274;
        private GridBand gridBand275;
        private GridBand gridBand276;
        private GridBand gridBand277;
        private GridBand gridBand278;
        private GridBand gridBand279;
        private GridBand gridBand28;
        private GridBand gridBand280;
        private GridBand gridBand281;
        private GridBand gridBand282;
        private GridBand gridBand283;
        private GridBand gridBand284;
        private GridBand gridBand286;
        private GridBand gridBand287;
        private GridBand gridBand288;
        private GridBand gridBand289;
        private GridBand gridBand29;
        private GridBand gridBand293;
        private GridBand gridBand3;
        private GridBand gridBand30;
        private GridBand gridBand307;
        private GridBand gridBand308;
        private GridBand gridBand309;
        private GridBand gridBand31;
        private GridBand gridBand315;
        private GridBand gridBand316;
        private GridBand gridBand317;
        private GridBand gridBand318;
        private GridBand gridBand319;
        private GridBand gridBand32;
        private GridBand gridBand320;
        private GridBand gridBand321;
        private GridBand gridBand322;
        private GridBand gridBand323;
        private GridBand gridBand324;
        private GridBand gridBand325;
        private GridBand gridBand326;
        private GridBand gridBand327;
        private GridBand gridBand328;
        private GridBand gridBand329;
        private GridBand gridBand33;
        private GridBand gridBand330;
        private GridBand gridBand331;
        private GridBand gridBand332;
        private GridBand gridBand333;
        private GridBand gridBand334;
        private GridBand gridBand335;
        private GridBand gridBand336;
        private GridBand gridBand337;
        private GridBand gridBand338;
        private GridBand gridBand339;
        private GridBand gridBand34;
        private GridBand gridBand340;
        private GridBand gridBand341;
        private GridBand gridBand342;
        private GridBand gridBand343;
        private GridBand gridBand344;
        private GridBand gridBand345;
        private GridBand gridBand346;
        private GridBand gridBand347;
        private GridBand gridBand348;
        private GridBand gridBand349;
        private GridBand gridBand35;
        private GridBand gridBand350;
        private GridBand gridBand351;
        private GridBand gridBand352;
        private GridBand gridBand353;
        private GridBand gridBand354;
        private GridBand gridBand355;
        private GridBand gridBand356;
        private GridBand gridBand357;
        private GridBand gridBand358;
        private GridBand gridBand359;
        private GridBand gridBand36;
        private GridBand gridBand360;
        private GridBand gridBand361;
        private GridBand gridBand362;
        private GridBand gridBand363;
        private GridBand gridBand364;
        private GridBand gridBand365;
        private GridBand gridBand366;
        private GridBand gridBand367;
        private GridBand gridBand368;
        private GridBand gridBand369;
        private GridBand gridBand37;
        private GridBand gridBand38;
        private GridBand gridBand385;
        private GridBand gridBand39;
        private GridBand gridBand4;
        private GridBand gridBand40;
        private GridBand gridBand41;
        private GridBand gridBand42;
        private GridBand gridBand43;
        private GridBand gridBand44;
        private GridBand gridBand45;
        private GridBand gridBand46;
        private GridBand gridBand47;
        private GridBand gridBand48;
        private GridBand gridBand480;
        private GridBand gridBand481;
        private GridBand gridBand482;
        private GridBand gridBand483;
        private GridBand gridBand484;
        private GridBand gridBand485;
        private GridBand gridBand49;
        private GridBand gridBand490;
        private GridBand gridBand491;
        private GridBand gridBand492;
        private GridBand gridBand493;
        private GridBand gridBand494;
        private GridBand gridBand495;
        private GridBand gridBand496;
        private GridBand gridBand497;
        private GridBand gridBand498;
        private GridBand gridBand499;
        private GridBand gridBand5;
        private GridBand gridBand50;
        private GridBand gridBand500;
        private GridBand gridBand501;
        private GridBand gridBand502;
        private GridBand gridBand503;
        private GridBand gridBand504;
        private GridBand gridBand505;
        private GridBand gridBand506;
        private GridBand gridBand507;
        private GridBand gridBand508;
        private GridBand gridBand509;
        private GridBand gridBand51;
        private GridBand gridBand510;
        private GridBand gridBand511;
        private GridBand gridBand512;
        private GridBand gridBand513;
        private GridBand gridBand514;
        private GridBand gridBand515;
        private GridBand gridBand516;
        private GridBand gridBand517;
        private GridBand gridBand518;
        private GridBand gridBand519;
        private GridBand gridBand52;
        private GridBand gridBand520;
        private GridBand gridBand521;
        private GridBand gridBand524;
        private GridBand gridBand53;
        private GridBand gridBand530;
        private GridBand gridBand54;
        private GridBand gridBand55;
        private GridBand gridBand56;
        private GridBand gridBand57;
        private GridBand gridBand58;
        private GridBand gridBand581;
        private GridBand gridBand582;
        private GridBand gridBand583;
        private GridBand gridBand584;
        private GridBand gridBand585;
        private GridBand gridBand586;
        private GridBand gridBand587;
        private GridBand gridBand588;
        private GridBand gridBand589;
        private GridBand gridBand59;
        private GridBand gridBand590;
        private GridBand gridBand591;
        private GridBand gridBand592;
        private GridBand gridBand593;
        private GridBand gridBand594;
        private GridBand gridBand595;
        private GridBand gridBand6;
        private GridBand gridBand60;
        private GridBand gridBand61;
        private GridBand gridBand62;
        private GridBand gridBand63;
        private GridBand gridBand64;
        private GridBand gridBand65;
        private GridBand gridBand66;
        private GridBand gridBand67;
        private GridBand gridBand68;
        private GridBand gridBand69;
        private GridBand gridBand7;
        private GridBand gridBand70;
        private GridBand gridBand71;
        private GridBand gridBand72;
        private GridBand gridBand73;
        private GridBand gridBand74;
        private GridBand gridBand75;
        private GridBand gridBand76;
        private GridBand gridBand77;
        private GridBand gridBand78;
        private GridBand gridBand79;
        private GridBand gridBand8;
        private GridBand gridBand80;
        private GridBand gridBand81;
        private GridBand gridBand82;
        private GridBand gridBand83;
        private GridBand gridBand84;
        private GridBand gridBand85;
        private GridBand gridBand86;
        private GridBand gridBand87;
        private GridBand gridBand88;
        private GridBand gridBand89;
        private GridBand gridBand9;
        private GridBand gridBand90;
        private GridBand gridBand91;
        private GridBand gridBand92;
        private GridBand gridBand93;
        private GridBand gridBand94;
        private GridBand gridBand95;
        private GridBand gridBand96;
        private GridBand gridBand97;
        private GridBand gridBand98;
        private GridBand gridBand99;
        private GridControl gridControl;
        private GridView gridView1;
        private AdvBandedGridView GView_GLLDDTZYTJB;
        private AdvBandedGridView GView_GLLDMJBGTJB;
        private AdvBandedGridView GView_GYLDMJBGTJB;
        private AdvBandedGridView GView_LDBHYYFXTJB;
        private AdvBandedGridView GView_SPLDMJBGTJB;
        private AdvBandedGridView GView_ZYBH_B1_GLTDMJBHB;
        private AdvBandedGridView GView_ZYBH_B2_GLSLLMMJXJBHB;
        private AdvBandedGridView GView_ZYBH_B3_GLZMJXJBHB;
        private AdvBandedGridView GView_ZYBH_B4_ZYSZMJXJBHB;
        private AdvBandedGridView GView_ZYBH_B5_YCLMJXJBHB;
        private BarButtonItem iAbout;
        private BarButtonItem iBoldFontStyle;
        private BarButtonItem iCenterTextAlign;
        private BarButtonItem iClose;
        private BarButtonItem iExit;
        private BarButtonItem iFind;
        private BarButtonItem iHelp;
        private BarButtonItem iItalicFontStyle;
        private BarButtonItem iLeftTextAlign;
        private BarButtonItem iNew;
        private BarButtonItem iOpen;
        private BarButtonItem iRightTextAlign;
        private BarButtonItem iSave;
        private BarButtonItem iSaveAs;
        private BarButtonItem iUnderlinedFontStyle;
        private NavBarControl navBarControl;
        private NavBarGroup navBarGroup_0;
        private ImageList navbarImageListLarge;
        private NavBarItem navBarItem_GLLDDTZYTJB;
        private NavBarItem navBarItem_GLLDMJBGTJB;
        private NavBarItem navBarItem_GYLDMJBGTJB;
        private NavBarItem navBarItem_LDBHYYFXTJB;
        private NavBarItem navBarItem_SPLDMJBGTJB;
        private NavBarItem navBarItem_ZYBH_B1_GLTDMJBHB;
        private NavBarItem navBarItem_ZYBH_B2_GLSLLMMJXJBHB;
        private NavBarItem navBarItem_ZYBH_B2_GLSLLMMJXJTJB2;
        private NavBarItem navBarItem_ZYBH_B3_GLZMJXJBHB;
        private NavBarItem navBarItem_ZYBH_B4_ZYSZMJXJBHB;
        private NavBarItem navBarItem_ZYBH_B5_YCLMJXJBHB;
        private NavBarItem navBarItem_ZYGX_DLBHXBDCB;
        private string pConn = "";
        private string pDataBase = "";
        private int pLastND;
        private int pNowND;
        private PrintPreviewBarItem printPreviewBarItem10;
        private PrintPreviewBarItem printPreviewBarItem11;
        private PrintPreviewBarItem printPreviewBarItem12;
        private PrintPreviewBarItem printPreviewBarItem13;
        private PrintPreviewBarItem printPreviewBarItem14;
        private PrintPreviewBarItem printPreviewBarItem15;
        private PrintPreviewBarItem printPreviewBarItem16;
        private PrintPreviewBarItem printPreviewBarItem17;
        private PrintPreviewBarItem printPreviewBarItem18;
        private PrintPreviewBarItem printPreviewBarItem19;
        private PrintPreviewBarItem printPreviewBarItem20;
        private PrintPreviewBarItem printPreviewBarItem21;
        private PrintPreviewBarItem printPreviewBarItem22;
        private PrintPreviewBarItem printPreviewBarItem23;
        private PrintPreviewBarItem printPreviewBarItem26;
        private PrintPreviewBarItem printPreviewBarItem27;
        private PrintPreviewBarItem printPreviewBarItem28;
        private PrintPreviewBarItem printPreviewBarItem29;
        private PrintPreviewBarItem printPreviewBarItem30;
        private PrintPreviewBarItem printPreviewBarItem31;
        private PrintPreviewBarItem printPreviewBarItem32;
        private PrintPreviewBarItem printPreviewBarItem33;
        private PrintPreviewBarItem printPreviewBarItem34;
        private PrintPreviewBarItem printPreviewBarItem35;
        private PrintPreviewBarItem printPreviewBarItem36;
        private PrintPreviewBarItem printPreviewBarItem37;
        private PrintPreviewBarItem printPreviewBarItem38;
        private PrintPreviewBarItem printPreviewBarItem39;
        private PrintPreviewBarItem printPreviewBarItem40;
        private PrintPreviewBarItem printPreviewBarItem41;
        private PrintPreviewBarItem printPreviewBarItem42;
        private PrintPreviewBarItem printPreviewBarItem43;
        private PrintPreviewBarItem printPreviewBarItem44;
        private PrintPreviewBarItem printPreviewBarItem45;
        private PrintPreviewBarItem printPreviewBarItem46;
        private PrintPreviewBarItem printPreviewBarItem47;
        private PrintPreviewBarItem printPreviewBarItem48;
        private PrintPreviewBarItem printPreviewBarItem5;
        private PrintPreviewBarItem printPreviewBarItem6;
        private PrintPreviewBarItem printPreviewBarItem7;
        private PrintPreviewBarItem printPreviewBarItem8;
        private PrintPreviewStaticItem printPreviewStaticItem1;
        private PrintPreviewStaticItem printPreviewStaticItem2;
        private PrintRibbonController printRibbonController1;
        private ProgressBarEditItem progressBarEditItem1;
        private string pTable_Code = "";
        private string pTable_gmlszhb = "";
        private string pTable_hslszhb = "";
        private string pTable_jjlszhb = "";
        private string pTable_qmlszhb = "";
        private string pTable_slszhb = "";
        private string pTable_XB_last = "";
        private string pTable_XB_now = "";
        private string pTable_yclszhb = "";
        private int pType;
        private string pXianName = "";
        private RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit1;
        private RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private RepositoryItemCheckEdit repositoryItemCheckEdit10;
        private RepositoryItemCheckEdit repositoryItemCheckEdit11;
        private RepositoryItemCheckEdit repositoryItemCheckEdit12;
        private RepositoryItemCheckEdit repositoryItemCheckEdit13;
        private RepositoryItemCheckEdit repositoryItemCheckEdit14;
        private RepositoryItemCheckEdit repositoryItemCheckEdit15;
        private RepositoryItemCheckEdit repositoryItemCheckEdit16;
        private RepositoryItemCheckEdit repositoryItemCheckEdit17;
        private RepositoryItemCheckEdit repositoryItemCheckEdit18;
        private RepositoryItemCheckEdit repositoryItemCheckEdit19;
        private RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private RepositoryItemCheckEdit repositoryItemCheckEdit20;
        private RepositoryItemCheckEdit repositoryItemCheckEdit21;
        private RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private RepositoryItemCheckEdit repositoryItemCheckEdit5;
        private RepositoryItemCheckEdit repositoryItemCheckEdit6;
        private RepositoryItemCheckEdit repositoryItemCheckEdit7;
        private RepositoryItemCheckEdit repositoryItemCheckEdit8;
        private RepositoryItemCheckEdit repositoryItemCheckEdit9;
        private RepositoryItemComboBox repositoryItemComboBox1;
        private RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit1;
        private RepositoryItemProgressBar repositoryItemProgressBar1;
        private RepositoryItemProgressBar repositoryItemProgressBar2;
        private RepositoryItemZoomTrackBar repositoryItemZoomTrackBar1;
        private RibbonGalleryBarItem rgbiSkins;
        private RibbonControl ribbonControl;
        private DevExpress.Utils.ImageCollection ribbonImageCollection;
        private DevExpress.Utils.ImageCollection ribbonImageCollectionLarge;
        private RibbonPageGroup ribbonPageGroup1;
        private RibbonPageGroup ribbonPageGroup2;
        private RibbonPageGroup ribbonPageGroup3;
        private RibbonPageGroup ribbonPageGroup4;
        private RibbonPageGroup ribbonPageGroup5;
        private RibbonPageGroup ribbonPageGroup6;
        private RibbonStatusBar ribbonStatusBar;
        private RibbonPage rp_LDNDBGDCTJB;
        private RibbonPage rp_ZYDCTJB;
        private RibbonPage rp_ZYGXTJB;
        private BarStaticItem siInfo;
        private BarStaticItem siStatus;
        private SplitContainerControl splitContainerControl;
        private ZoomTrackBarEditItem zoomTrackBarEditItem1;

        public Form1(string pConnecting, string pDataBaseName, int pTableType)
        {
            this.InitializeComponent();
            this.InitSkinGallery();
            this.pConn = pConnecting;
            this.pDataBase = pDataBaseName;
            this.pType = pTableType;
            this.SQLDataConfig();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            new fb2_table().Export_Table2("FOR_XIAOBAN_2015", "T_SYS_META_CODE", this.pConn);
        }

        private void bBTN_ZYDC_TJ_ItemClick(object sender, ItemClickEventArgs e)
        {
            string xlsModelPath = Application.StartupPath + @"\森林资源动态统计表表头.xls";
            string xlsTargetPath = "";
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "请为输出的Excel表选择一个存储位置";
            dialog.Filter = "Excel表(*.xls)|*.xls";
            dialog.InitialDirectory = Application.StartupPath;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                xlsTargetPath = dialog.FileName;
                try
                {
                    PrintZYDCTJBClass class2;
                    double num25;
                    string str8;
                    DataSet tjds = new DataSet("tjds");
                    if (this.bCHK_ZYBH_B1_GLTDMJBHB.EditValue.ToString() != "True")
                    {
                        goto Label_093B;
                    }
                    string cmdText = this.pSQL_ZYBH_B1_GLTDMJBHB();
                    SqlConnection connection = this.SQLDataConfig();
                    connection.Open();
                    SqlCommand selectCommand = new SqlCommand(cmdText, connection);
                    selectCommand.CommandTimeout = 60;
                    SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                    connection.Close();
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    if (dataTable.Columns.CanRemove(dataTable.Columns["tjdw"]))
                    {
                        dataTable.Columns.Remove(dataTable.Columns["tjdw"]);
                    }
                    dataTable.TableName = "b1";
                    dataTable.Columns.Add("id");
                    DataTable table = new DataTable();
                    table = dataTable.Copy();
                    table.Clear();
                    DataTable table3 = new DataTable();
                    table3 = dataTable.Copy();
                    table3.Clear();
                    int num = 0;
                Label_0158:
                    if (num >= dataTable.Rows.Count)
                    {
                        goto Label_0777;
                    }
                    double d = num;
                    d /= 2.0;
                    dataTable.Rows[num]["id"] = ((Math.Floor(d) * 2.0) + num) + 1.0;
                    if (((num + 1) % 2) != 0)
                    {
                        goto Label_0761;
                    }
                    DataRow row = table.NewRow();
                    DataRow row2 = table3.NewRow();
                    int num3 = 0;
                Label_01DA:
                    if (num3 < dataTable.Columns.Count)
                    {
                        try
                        {
                            switch (num3)
                            {
                                case 0:
                                    row[num3] = dataTable.Rows[num][num3].ToString();
                                    row2[num3] = dataTable.Rows[num][num3].ToString();
                                    goto Label_076C;

                                case 1:
                                    row[num3] = "变化量";
                                    row2[num3] = "变化率(%)";
                                    goto Label_076C;
                            }
                            if (dataTable.Columns[num3].ColumnName == "森林覆盖率")
                            {
                                num25 = Convert.ToDouble(dataTable.Rows[num]["森林覆盖率"]) - Convert.ToDouble(dataTable.Rows[num - 1]["森林覆盖率"]);
                                row[num3] = num25.ToString("f2");
                                num25 = (Convert.ToDouble(dataTable.Rows[num]["森林覆盖率"]) - Convert.ToDouble(dataTable.Rows[num - 1]["森林覆盖率"])) / Convert.ToDouble(dataTable.Rows[num - 1]["森林覆盖率"]);
                                row2[num3] = num25.ToString("f2");
                            }
                            else if (dataTable.Columns[num3].ColumnName == "林木覆盖率")
                            {
                                num25 = Convert.ToDouble(dataTable.Rows[num]["林木覆盖率"]) - Convert.ToDouble(dataTable.Rows[num - 1]["林木覆盖率"]);
                                row[num3] = num25.ToString("f2");
                                num25 = (Convert.ToDouble(dataTable.Rows[num]["林木覆盖率"]) - Convert.ToDouble(dataTable.Rows[num - 1]["林木覆盖率"])) / Convert.ToDouble(dataTable.Rows[num - 1]["林木覆盖率"]);
                                row2[num3] = num25.ToString("f2");
                            }
                            else if (((num3 + 1) % 2) == 0)
                            {
                                row[num3] = Convert.ToDouble((double) (double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString()))).ToString("f1");
                                if (double.Parse(dataTable.Rows[num - 1][num3].ToString()) != 0.0)
                                {
                                    try
                                    {
                                        num25 = Convert.ToDouble((double) ((double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString())) / double.Parse(dataTable.Rows[num - 1][num3].ToString()))) * 100.0;
                                        row2[num3] = num25.ToString("f1");
                                    }
                                    catch
                                    {
                                        row2[num3] = 0;
                                    }
                                }
                                else
                                {
                                    row2[num3] = 0;
                                }
                            }
                            else
                            {
                                row[num3] = Convert.ToDouble((double) (double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString()))).ToString("f1");
                                if (double.Parse(dataTable.Rows[num - 1][num3].ToString()) != 0.0)
                                {
                                    try
                                    {
                                        num25 = Convert.ToDouble((double) ((double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString())) / double.Parse(dataTable.Rows[num - 1][num3].ToString()))) * 100.0;
                                        row2[num3] = num25.ToString("f1");
                                    }
                                    catch
                                    {
                                        row2[num3] = 0;
                                    }
                                }
                                else
                                {
                                    row2[num3] = 0;
                                }
                            }
                        }
                        catch
                        {
                        }
                        goto Label_076C;
                    }
                    row["id"] = (((Math.Floor(d) * 2.0) + num) + 1.0) + 1.0;
                    row2["id"] = (((Math.Floor(d) * 2.0) + num) + 1.0) + 2.0;
                    table.Rows.Add(row);
                    table3.Rows.Add(row2);
                Label_0761:
                    num++;
                    goto Label_0158;
                Label_076C:
                    num3++;
                    goto Label_01DA;
                Label_0777:
                    dataTable.Merge(table);
                    dataTable.Merge(table3);
                    dataTable.Columns.Add("Sortid", typeof(double));
                    foreach (DataRow row3 in dataTable.Rows)
                    {
                        row3["Sortid"] = Convert.ToDouble(row3["id"]);
                    }
                    DataView view = new DataView(dataTable);
                    view.Sort = "Sortid";
                    DataTable table4 = new DataTable();
                    dataTable = view.ToTable();
                    dataTable.Columns.Remove("id");
                    dataTable.Columns.Remove("Sortid");
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (int num5 = 0; num5 < dataTable.Columns.Count; num5++)
                        {
                            if (((dataTable.Rows[i][num5].ToString().Trim() == "0.00") || (dataTable.Rows[i][num5].ToString().Trim() == "0.0")) || (dataTable.Rows[i][num5].ToString().Trim() == "0"))
                            {
                                dataTable.Rows[i][num5] = DBNull.Value;
                            }
                        }
                    }
                    tjds.Tables.Add(dataTable);
                Label_093B:
                    if (this.bCHK_ZYBH_B2_GLSLLMMJXJBHB.EditValue.ToString() != "True")
                    {
                        goto Label_128D;
                    }
                    string str4 = this.pSQL_ZYBH_B2_GLSLLMMJXJBHB();
                    SqlConnection connection2 = this.SQLDataConfig();
                    connection2.Open();
                    SqlCommand command2 = new SqlCommand(str4, connection2);
                    command2.CommandTimeout = 60;
                    SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                    connection2.Close();
                    DataTable table5 = new DataTable();
                    table5.TableName = "b2";
                    adapter2.Fill(table5);
                    if (table5.Columns.CanRemove(table5.Columns["tjdw"]))
                    {
                        table5.Columns.Remove(table5.Columns["tjdw"]);
                    }
                    table5.Columns.Add("id");
                    DataTable table6 = new DataTable();
                    table6 = table5.Copy();
                    table6.Clear();
                    DataTable table7 = new DataTable();
                    table7 = table5.Copy();
                    table7.Clear();
                    int num6 = 0;
                Label_0A31:
                    if (num6 >= table5.Rows.Count)
                    {
                        goto Label_108B;
                    }
                    double num7 = num6;
                    num7 /= 2.0;
                    table5.Rows[num6]["id"] = ((Math.Floor(num7) * 2.0) + num6) + 1.0;
                    if (((num6 + 1) % 2) != 0)
                    {
                        goto Label_1075;
                    }
                    DataRow row4 = table6.NewRow();
                    DataRow row5 = table7.NewRow();
                    int num8 = 0;
                Label_0AB3:
                    if (num8 < table5.Columns.Count)
                    {
                        try
                        {
                            switch (num8)
                            {
                                case 0:
                                    row4[num8] = table5.Rows[num6][num8].ToString();
                                    row5[num8] = table5.Rows[num6][num8].ToString();
                                    goto Label_1080;

                                case 1:
                                    row4[num8] = "变化量";
                                    row5[num8] = "变化率(%)";
                                    goto Label_1080;
                            }
                            if ((table5.Columns[num8].ColumnName != "森林覆盖率") && (table5.Columns[num8].ColumnName != "林木覆盖率"))
                            {
                                if (((num8 + 1) % 2) == 0)
                                {
                                    if (num8 == 3)
                                    {
                                        row4[num8] = Convert.ToDouble((double) (double.Parse(table5.Rows[num6][num8].ToString()) - double.Parse(table5.Rows[num6 - 1][num8].ToString()))).ToString("f1");
                                        try
                                        {
                                            num25 = Convert.ToDouble((double) ((double.Parse(table5.Rows[num6][num8].ToString()) - double.Parse(table5.Rows[num6 - 1][num8].ToString())) / double.Parse(table5.Rows[num6 - 1][num8].ToString()))) * 100.0;
                                            row5[num8] = num25.ToString("f1");
                                        }
                                        catch
                                        {
                                            row5[num8] = 0;
                                        }
                                    }
                                    else
                                    {
                                        row4[num8] = Convert.ToDouble((double) (double.Parse(table5.Rows[num6][num8].ToString()) - double.Parse(table5.Rows[num6 - 1][num8].ToString()))).ToString("f0");
                                        try
                                        {
                                            num25 = Convert.ToDouble((double) ((double.Parse(table5.Rows[num6][num8].ToString()) - double.Parse(table5.Rows[num6 - 1][num8].ToString())) / double.Parse(table5.Rows[num6 - 1][num8].ToString()))) * 100.0;
                                            row5[num8] = num25.ToString("f1");
                                        }
                                        catch
                                        {
                                            row5[num8] = 0;
                                        }
                                    }
                                }
                                else if (num8 == 2)
                                {
                                    row4[num8] = Convert.ToDouble((double) (double.Parse(table5.Rows[num6][num8].ToString()) - double.Parse(table5.Rows[num6 - 1][num8].ToString()))).ToString("f0");
                                    try
                                    {
                                        num25 = Convert.ToDouble((double) ((double.Parse(table5.Rows[num6][num8].ToString()) - double.Parse(table5.Rows[num6 - 1][num8].ToString())) / double.Parse(table5.Rows[num6 - 1][num8].ToString()))) * 100.0;
                                        row5[num8] = num25.ToString("f1");
                                    }
                                    catch
                                    {
                                        row5[num8] = 0;
                                    }
                                }
                                else
                                {
                                    row4[num8] = Convert.ToDouble((double) (double.Parse(table5.Rows[num6][num8].ToString()) - double.Parse(table5.Rows[num6 - 1][num8].ToString()))).ToString("f1");
                                    try
                                    {
                                        num25 = Convert.ToDouble((double) ((double.Parse(table5.Rows[num6][num8].ToString()) - double.Parse(table5.Rows[num6 - 1][num8].ToString())) / double.Parse(table5.Rows[num6 - 1][num8].ToString()))) * 100.0;
                                        row5[num8] = num25.ToString("f1");
                                    }
                                    catch
                                    {
                                        row5[num8] = 0;
                                    }
                                }
                            }
                            else
                            {
                                row4[num8] = table5.Rows[num6][num8].ToString();
                                row5[num8] = table5.Rows[num6][num8].ToString();
                            }
                            goto Label_1080;
                        }
                        catch
                        {
                            goto Label_1080;
                        }
                    }
                    row4["id"] = (((Math.Floor(num7) * 2.0) + num6) + 1.0) + 1.0;
                    row5["id"] = (((Math.Floor(num7) * 2.0) + num6) + 1.0) + 2.0;
                    table6.Rows.Add(row4);
                    table7.Rows.Add(row5);
                Label_1075:
                    num6++;
                    goto Label_0A31;
                Label_1080:
                    num8++;
                    goto Label_0AB3;
                Label_108B:
                    table5.Merge(table6);
                    table5.Merge(table7);
                    table5.Columns.Add("Sortid", typeof(double));
                    foreach (DataRow row6 in table5.Rows)
                    {
                        row6["Sortid"] = Convert.ToDouble(row6["id"]);
                    }
                    DataView view2 = new DataView(table5);
                    view2.Sort = "Sortid";
                    DataTable table8 = new DataTable();
                    table5 = view2.ToTable();
                    if (table5.Columns.CanRemove(table5.Columns["id"]))
                    {
                        table5.Columns.Remove("id");
                    }
                    if (table5.Columns.CanRemove(table5.Columns["Sortid"]))
                    {
                        table5.Columns.Remove("Sortid");
                    }
                    for (int j = 0; j < table5.Rows.Count; j++)
                    {
                        for (int num10 = 0; num10 < table5.Columns.Count; num10++)
                        {
                            if (((table5.Rows[j][num10].ToString().Trim() == "0.00") || (table5.Rows[j][num10].ToString().Trim() == "0.0")) || (table5.Rows[j][num10].ToString().Trim() == "0"))
                            {
                                table5.Rows[j][num10] = DBNull.Value;
                            }
                        }
                    }
                    tjds.Tables.Add(table5);
                Label_128D:
                    if (this.bCHK_ZYBH_B3_GLZMJXJBHB.EditValue.ToString() != "True")
                    {
                        goto Label_19AB;
                    }
                    string str5 = this.pSQL_ZYBH_B3_GLZMJXJBHB();
                    SqlConnection connection3 = this.SQLDataConfig();
                    connection3.Open();
                    SqlCommand command3 = new SqlCommand(str5, connection3);
                    command3.CommandTimeout = 60;
                    SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
                    connection3.Close();
                    DataTable table9 = new DataTable();
                    table9.TableName = "b3";
                    adapter3.Fill(table9);
                    table9.Columns.Add("id");
                    DataTable table10 = new DataTable();
                    table10 = table9.Copy();
                    table10.Clear();
                    DataTable table11 = new DataTable();
                    table11 = table9.Copy();
                    table11.Clear();
                    int num11 = 0;
                Label_1347:
                    if (num11 >= table9.Rows.Count)
                    {
                        goto Label_17A9;
                    }
                    double num12 = num11;
                    num12 /= 2.0;
                    table9.Rows[num11]["id"] = ((Math.Floor(num12) * 2.0) + num11) + 1.0;
                    if (((num11 + 1) % 2) != 0)
                    {
                        goto Label_1793;
                    }
                    DataRow row7 = table10.NewRow();
                    DataRow row8 = table11.NewRow();
                    int num13 = 0;
                Label_13C9:
                    if (num13 < table9.Columns.Count)
                    {
                        try
                        {
                            switch (num13)
                            {
                                case 0:
                                    row7[num13] = table9.Rows[num11][num13].ToString();
                                    row8[num13] = table9.Rows[num11][num13].ToString();
                                    goto Label_179E;

                                case 1:
                                    row7[num13] = "变化量";
                                    row8[num13] = "变化率(%)";
                                    goto Label_179E;
                            }
                            if ((table9.Columns[num13].ColumnName != "森林覆盖率") && (table9.Columns[num13].ColumnName != "林木覆盖率"))
                            {
                                if (((num13 + 1) % 2) == 0)
                                {
                                    row7[num13] = Convert.ToDouble((double) (double.Parse(table9.Rows[num11][num13].ToString()) - double.Parse(table9.Rows[num11 - 1][num13].ToString()))).ToString("f0");
                                    try
                                    {
                                        num25 = Convert.ToDouble((double) ((double.Parse(table9.Rows[num11][num13].ToString()) - double.Parse(table9.Rows[num11 - 1][num13].ToString())) / double.Parse(table9.Rows[num11 - 1][num13].ToString()))) * 100.0;
                                        row8[num13] = num25.ToString("f1");
                                    }
                                    catch
                                    {
                                        row8[num13] = 0;
                                    }
                                }
                                else
                                {
                                    row7[num13] = Convert.ToDouble((double) (double.Parse(table9.Rows[num11][num13].ToString()) - double.Parse(table9.Rows[num11 - 1][num13].ToString()))).ToString("f1");
                                    try
                                    {
                                        num25 = Convert.ToDouble((double) ((double.Parse(table9.Rows[num11][num13].ToString()) - double.Parse(table9.Rows[num11 - 1][num13].ToString())) / double.Parse(table9.Rows[num11 - 1][num13].ToString()))) * 100.0;
                                        row8[num13] = num25.ToString("f1");
                                    }
                                    catch
                                    {
                                        row8[num13] = 0;
                                    }
                                }
                            }
                            else
                            {
                                row7[num13] = table9.Rows[num11][num13].ToString();
                                row8[num13] = table9.Rows[num11][num13].ToString();
                            }
                            goto Label_179E;
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("3" + exception.Message);
                            goto Label_179E;
                        }
                    }
                    row7["id"] = (((Math.Floor(num12) * 2.0) + num11) + 1.0) + 1.0;
                    row8["id"] = (((Math.Floor(num12) * 2.0) + num11) + 1.0) + 2.0;
                    table10.Rows.Add(row7);
                    table11.Rows.Add(row8);
                Label_1793:
                    num11++;
                    goto Label_1347;
                Label_179E:
                    num13++;
                    goto Label_13C9;
                Label_17A9:
                    table9.Merge(table10);
                    table9.Merge(table11);
                    table9.Columns.Add("Sortid", typeof(double));
                    foreach (DataRow row9 in table9.Rows)
                    {
                        row9["Sortid"] = Convert.ToDouble(row9["id"]);
                    }
                    DataView view3 = new DataView(table9);
                    view3.Sort = "Sortid";
                    DataTable table12 = new DataTable();
                    table9 = view3.ToTable();
                    if (table9.Columns.CanRemove(table9.Columns["id"]))
                    {
                        table9.Columns.Remove("id");
                    }
                    if (table9.Columns.CanRemove(table9.Columns["Sortid"]))
                    {
                        table9.Columns.Remove("Sortid");
                    }
                    for (int k = 0; k < table9.Rows.Count; k++)
                    {
                        for (int num15 = 0; num15 < table9.Columns.Count; num15++)
                        {
                            if (((table9.Rows[k][num15].ToString().Trim() == "0.00") || (table9.Rows[k][num15].ToString().Trim() == "0.0")) || (table9.Rows[k][num15].ToString().Trim() == "0"))
                            {
                                table9.Rows[k][num15] = DBNull.Value;
                            }
                        }
                    }
                    tjds.Tables.Add(table9);
                Label_19AB:
                    if (this.bCHK_ZYBH_B4_ZYSZMJXJBHB.EditValue.ToString() == "True")
                    {
                        SqlConnection connection4 = this.SQLDataConfig();
                        connection4.Open();
                        SqlCommand command4 = new SqlCommand("update " + this.pTable_XB_last + " set SZMERGE ='' update " + this.pTable_XB_now + " set SZMERGE ='' select * from " + this.pTable_slszhb, connection4);
                        SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                        DataTable table13 = new DataTable();
                        adapter4.Fill(table13);
                        for (int num16 = 0; num16 < table13.Rows.Count; num16++)
                        {
                            str8 = "update " + this.pTable_XB_last + " set SZMERGE = '" + table13.Rows[num16]["cname"].ToString().Trim() + "' where " + table13.Rows[num16]["mergerule"].ToString().Trim();
                            command4 = new SqlCommand(str8 + " update " + this.pTable_XB_now + " set SZMERGE = '" + table13.Rows[num16]["cname"].ToString().Trim() + "' where " + table13.Rows[num16]["mergerule"].ToString().Trim(), connection4);
                            adapter4 = new SqlDataAdapter(command4);
                            DataTable table14 = new DataTable();
                            adapter4.Fill(table14);
                        }
                        command4 = new SqlCommand(this.pSQL_ZYBH_B4_ZYSZMJXJBHB(), connection4);
                        command4.CommandTimeout = 60;
                        adapter4 = new SqlDataAdapter(command4);
                        connection4.Close();
                        table13 = new DataTable();
                        table13.TableName = "b4";
                        adapter4.Fill(table13);
                        for (int num17 = 0; num17 < table13.Rows.Count; num17++)
                        {
                            for (int num18 = 0; num18 < table13.Columns.Count; num18++)
                            {
                                if (((table13.Rows[num17][num18].ToString().Trim() == "0.00") || (table13.Rows[num17][num18].ToString().Trim() == "0.0")) || (table13.Rows[num17][num18].ToString().Trim() == "0"))
                                {
                                    table13.Rows[num17][num18] = DBNull.Value;
                                }
                            }
                        }
                        tjds.Tables.Add(table13);
                    }
                    if (this.bCHK_ZYBH_B5_YCLMJXJBHB.EditValue.ToString() != "True")
                    {
                        goto Label_25C0;
                    }
                    SqlConnection connection5 = this.SQLDataConfig();
                    connection5.Open();
                    SqlCommand command5 = new SqlCommand("update " + this.pTable_XB_last + " set SZMERGE ='' update " + this.pTable_XB_now + " set SZMERGE =''  select * from " + this.pTable_yclszhb, connection5);
                    SqlDataAdapter adapter5 = new SqlDataAdapter(command5);
                    DataTable table15 = new DataTable();
                    adapter5.Fill(table15);
                    for (int m = 0; m < table15.Rows.Count; m++)
                    {
                        str8 = "update " + this.pTable_XB_last + " set SZMERGE = '" + table15.Rows[m]["cname"].ToString().Trim() + "' where " + table15.Rows[m]["mergerule"].ToString().Trim();
                        command5 = new SqlCommand(str8 + " update " + this.pTable_XB_now + " set SZMERGE = '" + table15.Rows[m]["cname"].ToString().Trim() + "' where " + table15.Rows[m]["mergerule"].ToString().Trim(), connection5);
                        adapter5 = new SqlDataAdapter(command5);
                        DataTable table16 = new DataTable();
                        adapter5.Fill(table16);
                    }
                    command5 = new SqlCommand(this.pSQL_ZYBH_B5_YCLMJXJBHB(), connection5);
                    command5.CommandTimeout = 60;
                    adapter5 = new SqlDataAdapter(command5);
                    connection5.Close();
                    table15 = new DataTable();
                    table15.TableName = "b5";
                    adapter5.Fill(table15);
                    table15.Columns.Add("id");
                    DataTable table17 = new DataTable();
                    table17 = table15.Copy();
                    table17.Clear();
                    DataTable table18 = new DataTable();
                    table18 = table15.Copy();
                    table18.Clear();
                    int num20 = 0;
                Label_1F4C:
                    if (num20 >= table15.Rows.Count)
                    {
                        goto Label_23BE;
                    }
                    double num21 = num20;
                    num21 /= 2.0;
                    table15.Rows[num20]["id"] = ((Math.Floor(num21) * 2.0) + num20) + 1.0;
                    if (((num20 + 1) % 2) != 0)
                    {
                        goto Label_23A8;
                    }
                    DataRow row10 = table17.NewRow();
                    DataRow row11 = table18.NewRow();
                    int num22 = 0;
                Label_1FCE:
                    if (num22 < table15.Columns.Count)
                    {
                        try
                        {
                            switch (num22)
                            {
                                case 0:
                                case 1:
                                    row10[num22] = table15.Rows[num20][num22].ToString();
                                    row11[num22] = table15.Rows[num20][num22].ToString();
                                    goto Label_23B3;

                                case 2:
                                    row10[num22] = "变化量";
                                    row11[num22] = "变化率(%)";
                                    goto Label_23B3;
                            }
                            if ((table15.Columns[num22].ColumnName != "森林覆盖率") && (table15.Columns[num22].ColumnName != "林木覆盖率"))
                            {
                                if (((num22 + 1) % 2) == 0)
                                {
                                    row10[num22] = Convert.ToDouble((double) (double.Parse(table15.Rows[num20][num22].ToString()) - double.Parse(table15.Rows[num20 - 1][num22].ToString()))).ToString("f1");
                                    try
                                    {
                                        num25 = Convert.ToDouble((double) ((double.Parse(table15.Rows[num20][num22].ToString()) - double.Parse(table15.Rows[num20 - 1][num22].ToString())) / double.Parse(table15.Rows[num20 - 1][num22].ToString()))) * 100.0;
                                        row11[num22] = num25.ToString("f1");
                                    }
                                    catch
                                    {
                                        row11[num22] = 0;
                                    }
                                }
                                else
                                {
                                    row10[num22] = Convert.ToDouble((double) (double.Parse(table15.Rows[num20][num22].ToString()) - double.Parse(table15.Rows[num20 - 1][num22].ToString()))).ToString("f0");
                                    try
                                    {
                                        row11[num22] = (Convert.ToDouble((double) ((double.Parse(table15.Rows[num20][num22].ToString()) - double.Parse(table15.Rows[num20 - 1][num22].ToString())) / double.Parse(table15.Rows[num20 - 1][num22].ToString()))) * 100.0).ToString("f1");
                                    }
                                    catch
                                    {
                                        row11[num22] = 0;
                                    }
                                }
                            }
                            else
                            {
                                row10[num22] = table15.Rows[num20][num22].ToString();
                                row11[num22] = table15.Rows[num20][num22].ToString();
                            }
                            goto Label_23B3;
                        }
                        catch (Exception exception2)
                        {
                            MessageBox.Show("5" + exception2.Message);
                            goto Label_23B3;
                        }
                    }
                    row10["id"] = (((Math.Floor(num21) * 2.0) + num20) + 1.0) + 1.0;
                    row11["id"] = (((Math.Floor(num21) * 2.0) + num20) + 1.0) + 2.0;
                    table17.Rows.Add(row10);
                    table18.Rows.Add(row11);
                Label_23A8:
                    num20++;
                    goto Label_1F4C;
                Label_23B3:
                    num22++;
                    goto Label_1FCE;
                Label_23BE:
                    table15.Merge(table17);
                    table15.Merge(table18);
                    table15.Columns.Add("Sortid", typeof(double));
                    foreach (DataRow row12 in table15.Rows)
                    {
                        row12["Sortid"] = Convert.ToDouble(row12["id"]);
                    }
                    DataView view4 = new DataView(table15);
                    view4.Sort = "Sortid";
                    DataTable table19 = new DataTable();
                    table15 = view4.ToTable();
                    if (table15.Columns.CanRemove(table15.Columns["id"]))
                    {
                        table15.Columns.Remove("id");
                    }
                    if (table15.Columns.CanRemove(table15.Columns["Sortid"]))
                    {
                        table15.Columns.Remove("Sortid");
                    }
                    for (int n = 0; n < table15.Rows.Count; n++)
                    {
                        for (int num24 = 0; num24 < table15.Columns.Count; num24++)
                        {
                            if (((table15.Rows[n][num24].ToString().Trim() == "0.00") || (table15.Rows[n][num24].ToString().Trim() == "0.0")) || (table15.Rows[n][num24].ToString().Trim() == "0"))
                            {
                                table15.Rows[n][num24] = DBNull.Value;
                            }
                        }
                    }
                    tjds.Tables.Add(table15);
                Label_25C0:
                    class2 = new PrintZYDCTJBClass();
                    class2.SaveZYBHTJB(this.pXianName, tjds, xlsModelPath, xlsTargetPath);
                    Process.Start(xlsTargetPath);
                }
                catch
                {
                    MessageBox.Show("导出数据出错了");
                }
                finally
                {
                    GC.Collect();
                }
            }
        }

        private void bBtn_ZYGX_TJ_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.navBarControl.Groups[0].Caption = "资源更新";
            if (this.bCHK_ZYGX_DLBHXBDCB.EditValue.ToString() == "True")
            {
                this.navBarItem_ZYGX_DLBHXBDCB.Visible = true;
            }
            else
            {
                this.navBarItem_ZYGX_DLBHXBDCB.Visible = false;
            }
        }

        private void bBtnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void bBtnTJ_ItemClick(object sender, ItemClickEventArgs e)
        {
            for (int i = 0; i < this.navBarControl.Items.Count; i++)
            {
                this.navBarControl.Items[i].Visible = false;
            }
            this.navBarControl.Groups[0].Caption = "林地年度变更调查统计表";
            if (this.bCHK_LDBG_GLLDMJBGTJB.EditValue.ToString() == "True")
            {
                this.navBarItem_GLLDMJBGTJB.Visible = true;
            }
            else
            {
                this.navBarItem_GLLDMJBGTJB.Visible = false;
            }
            if (this.bCHK_LDBG_GYLDMJBGTJB.EditValue.ToString() == "True")
            {
                this.navBarItem_GYLDMJBGTJB.Visible = true;
            }
            else
            {
                this.navBarItem_GYLDMJBGTJB.Visible = false;
            }
            if (this.bCHK_LDBG_SPLDMJBGTJB.EditValue.ToString() == "True")
            {
                this.navBarItem_SPLDMJBGTJB.Visible = true;
            }
            else
            {
                this.navBarItem_SPLDMJBGTJB.Visible = false;
            }
            if (this.bCHK_LDBG_GLLDDTZYTJB.EditValue.ToString() == "True")
            {
                this.navBarItem_GLLDDTZYTJB.Visible = true;
            }
            else
            {
                this.navBarItem_GLLDDTZYTJB.Visible = false;
            }
            if (this.bCHK_LDBG_LDBHYYFXTJB.EditValue.ToString() == "True")
            {
                this.navBarItem_LDBHYYFXTJB.Visible = true;
            }
            else
            {
                this.navBarItem_LDBHYYFXTJB.Visible = false;
            }
            if (this.navBarItem_GLLDMJBGTJB.Visible)
            {
                this.navBarItem_GLLDMJBGTJB_LinkClicked(null, null);
            }
            else if (this.navBarItem_GYLDMJBGTJB.Visible)
            {
                this.navBarItem_GYLDMJBGTJB_LinkClicked(null, null);
            }
            else if (this.navBarItem_SPLDMJBGTJB.Visible)
            {
                this.navBarItem_SPLDMJBGTJB_LinkClicked(null, null);
            }
            else if (this.navBarItem_GLLDDTZYTJB.Visible)
            {
                this.navBarItem_GLLDDTZYTJB_LinkClicked(null, null);
            }
            else if (this.navBarItem_LDBHYYFXTJB.Visible)
            {
                this.navBarItem_LDBHYYFXTJB_LinkClicked(null, null);
            }
            else
            {
                MessageBox.Show("没有任何统计表可以显示");
            }
        }

        private void btn_Brow_ItemClick(object sender, ItemClickEventArgs e)
        {
            for (int i = 0; i < this.navBarControl.Items.Count; i++)
            {
                this.navBarControl.Items[i].Visible = false;
            }
            if (this.pType == 1)
            {
                this.navBarControl.Groups[0].Caption = "森林资源变化情况表";
                if (this.bCHK_ZYBH_B1_GLTDMJBHB.EditValue.ToString() == "True")
                {
                    this.navBarItem_ZYBH_B1_GLTDMJBHB.Visible = true;
                }
                else
                {
                    this.navBarItem_ZYBH_B1_GLTDMJBHB.Visible = false;
                }
                if (this.bCHK_ZYBH_B2_GLSLLMMJXJBHB.EditValue.ToString() == "True")
                {
                    this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB.Visible = true;
                }
                else
                {
                    this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB.Visible = false;
                }
                if (this.bCHK_ZYBH_B3_GLZMJXJBHB.EditValue.ToString() == "True")
                {
                    this.navBarItem_ZYBH_B3_GLZMJXJBHB.Visible = true;
                }
                else
                {
                    this.navBarItem_ZYBH_B3_GLZMJXJBHB.Visible = false;
                }
                if (this.bCHK_ZYBH_B4_ZYSZMJXJBHB.EditValue.ToString() == "True")
                {
                    this.navBarItem_ZYBH_B4_ZYSZMJXJBHB.Visible = true;
                }
                else
                {
                    this.navBarItem_ZYBH_B4_ZYSZMJXJBHB.Visible = false;
                }
                if (this.bCHK_ZYBH_B5_YCLMJXJBHB.EditValue.ToString() == "True")
                {
                    this.navBarItem_ZYBH_B5_YCLMJXJBHB.Visible = true;
                }
                else
                {
                    this.navBarItem_ZYBH_B5_YCLMJXJBHB.Visible = false;
                }
                if (this.navBarItem_ZYBH_B1_GLTDMJBHB.Visible)
                {
                    this.navBarItem_ZYBH_B1_GLTDMJBHB_LinkClicked(null, null);
                }
                else if (this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB.Visible)
                {
                    this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB_LinkClicked(null, null);
                }
                else if (this.navBarItem_ZYBH_B3_GLZMJXJBHB.Visible)
                {
                    this.navBarItem_ZYBH_B3_GLZMJXJBHB_LinkClicked(null, null);
                }
                else if (this.navBarItem_ZYBH_B4_ZYSZMJXJBHB.Visible)
                {
                    this.navBarItem_ZYBH_B4_ZYSZMJXJBHB_LinkClicked(null, null);
                }
                else if (this.navBarItem_ZYBH_B5_YCLMJXJBHB.Visible)
                {
                    this.navBarItem_ZYBH_B5_YCLMJXJBHB_LinkClicked(null, null);
                }
            }
            else if (this.pType == 2)
            {
                this.navBarControl.Groups[0].Caption = "森林资源变化情况表";
                if (this.bCHK_ZYBH_B1_GLTDMJBHB.EditValue.ToString() == "True")
                {
                    this.navBarItem_ZYBH_B1_GLTDMJBHB.Visible = true;
                }
                else
                {
                    this.navBarItem_ZYBH_B1_GLTDMJBHB.Visible = false;
                }
                if (this.bCHK_ZYBH_B2_GLSLLMMJXJBHB.EditValue.ToString() == "True")
                {
                    this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB.Visible = true;
                }
                else
                {
                    this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB.Visible = false;
                }
                if (this.bCHK_ZYBH_B3_GLZMJXJBHB.EditValue.ToString() == "True")
                {
                    this.navBarItem_ZYBH_B3_GLZMJXJBHB.Visible = true;
                }
                else
                {
                    this.navBarItem_ZYBH_B3_GLZMJXJBHB.Visible = false;
                }
                if (this.bCHK_ZYBH_B4_ZYSZMJXJBHB.EditValue.ToString() == "True")
                {
                    this.navBarItem_ZYBH_B4_ZYSZMJXJBHB.Visible = true;
                }
                else
                {
                    this.navBarItem_ZYBH_B4_ZYSZMJXJBHB.Visible = false;
                }
                if (this.bCHK_ZYBH_B5_YCLMJXJBHB.EditValue.ToString() == "True")
                {
                    this.navBarItem_ZYBH_B5_YCLMJXJBHB.Visible = true;
                }
                else
                {
                    this.navBarItem_ZYBH_B5_YCLMJXJBHB.Visible = false;
                }
                if (this.navBarItem_ZYBH_B1_GLTDMJBHB.Visible)
                {
                    this.navBarItem_ZYBH_B1_GLTDMJBHB_LinkClicked(null, null);
                }
                else if (this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB.Visible)
                {
                    this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB_LinkClicked(null, null);
                }
                else if (this.navBarItem_ZYBH_B3_GLZMJXJBHB.Visible)
                {
                    this.navBarItem_ZYBH_B3_GLZMJXJBHB_LinkClicked(null, null);
                }
                else if (this.navBarItem_ZYBH_B4_ZYSZMJXJBHB.Visible)
                {
                    this.navBarItem_ZYBH_B4_ZYSZMJXJBHB_LinkClicked(null, null);
                }
                else if (this.navBarItem_ZYBH_B5_YCLMJXJBHB.Visible)
                {
                    this.navBarItem_ZYBH_B5_YCLMJXJBHB_LinkClicked(null, null);
                }
            }
            else
            {
                this.navBarControl.Groups[0].Caption = "森林资源变化情况表";
                if (this.bCHK_ZYBH_B1_GLTDMJBHB.EditValue.ToString() == "True")
                {
                    this.navBarItem_ZYBH_B1_GLTDMJBHB.Visible = true;
                }
                else
                {
                    this.navBarItem_ZYBH_B1_GLTDMJBHB.Visible = false;
                }
                if (this.bCHK_ZYBH_B2_GLSLLMMJXJBHB.EditValue.ToString() == "True")
                {
                    this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB.Visible = true;
                }
                else
                {
                    this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB.Visible = false;
                }
                if (this.bCHK_ZYBH_B3_GLZMJXJBHB.EditValue.ToString() == "True")
                {
                    this.navBarItem_ZYBH_B3_GLZMJXJBHB.Visible = true;
                }
                else
                {
                    this.navBarItem_ZYBH_B3_GLZMJXJBHB.Visible = false;
                }
                if (this.bCHK_ZYBH_B4_ZYSZMJXJBHB.EditValue.ToString() == "True")
                {
                    this.navBarItem_ZYBH_B4_ZYSZMJXJBHB.Visible = true;
                }
                else
                {
                    this.navBarItem_ZYBH_B4_ZYSZMJXJBHB.Visible = false;
                }
                if (this.bCHK_ZYBH_B5_YCLMJXJBHB.EditValue.ToString() == "True")
                {
                    this.navBarItem_ZYBH_B5_YCLMJXJBHB.Visible = true;
                }
                else
                {
                    this.navBarItem_ZYBH_B5_YCLMJXJBHB.Visible = false;
                }
                if (this.navBarItem_ZYBH_B1_GLTDMJBHB.Visible)
                {
                    this.navBarItem_ZYBH_B1_GLTDMJBHB_LinkClicked(null, null);
                }
                else if (this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB.Visible)
                {
                    this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB_LinkClicked(null, null);
                }
                else if (this.navBarItem_ZYBH_B3_GLZMJXJBHB.Visible)
                {
                    this.navBarItem_ZYBH_B3_GLZMJXJBHB_LinkClicked(null, null);
                }
                else if (this.navBarItem_ZYBH_B4_ZYSZMJXJBHB.Visible)
                {
                    this.navBarItem_ZYBH_B4_ZYSZMJXJBHB_LinkClicked(null, null);
                }
                else if (this.navBarItem_ZYBH_B5_YCLMJXJBHB.Visible)
                {
                    this.navBarItem_ZYBH_B5_YCLMJXJBHB_LinkClicked(null, null);
                }
            }
        }

        private void btn_LDBG_Export_ItemClick(object sender, ItemClickEventArgs e)
        {
            string xlsModelPath = Application.StartupPath + @"\国家林地变更表.xls";
            string xlsTargetPath = "";
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "请为输出的Excel表选择一个存储位置";
            dialog.Filter = "Excel表(*.xls)|*.xls";
            dialog.InitialDirectory = Application.StartupPath;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                xlsTargetPath = dialog.FileName;
                try
                {
                    DataSet tjds = new DataSet("tjds");
                    for (int i = 0; i < this.ribbonControl.Items.Count; i++)
                    {
                        if ((this.ribbonControl.Items[i].Name == "bCHK_LDBG_GLLDMJBGTJB") && (this.bCHK_LDBG_GLLDMJBGTJB.EditValue.ToString() == "True"))
                        {
                            string cmdText = this.pSQL_CreateGLLDMJBGTJB();
                            SqlConnection connection = this.SQLDataConfig();
                            connection.Open();
                            SqlCommand selectCommand = new SqlCommand(cmdText, connection);
                            selectCommand.CommandTimeout = 60;
                            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                            connection.Close();
                            DataTable dataTable = new DataTable();
                            dataTable.TableName = "b1";
                            adapter.Fill(dataTable);
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
                            tjds.Tables.Add(dataTable);
                        }
                        else if ((this.ribbonControl.Items[i].Name == "bCHK_LDBG_GYLDMJBGTJB") && (this.bCHK_LDBG_GYLDMJBGTJB.EditValue.ToString() == "True"))
                        {
                            string str4 = this.pSQL_CreateGYLDMJBGTJB();
                            SqlConnection connection2 = this.SQLDataConfig();
                            connection2.Open();
                            SqlCommand command2 = new SqlCommand(str4, connection2);
                            command2.CommandTimeout = 60;
                            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                            connection2.Close();
                            DataTable table2 = new DataTable();
                            table2.TableName = "b2";
                            adapter2.Fill(table2);
                            for (int m = 0; m < table2.Rows.Count; m++)
                            {
                                for (int n = 0; n < table2.Columns.Count; n++)
                                {
                                    if (((table2.Rows[m][n].ToString().Trim() == "0.00") || (table2.Rows[m][n].ToString().Trim() == "0.0")) || (table2.Rows[m][n].ToString().Trim() == "0"))
                                    {
                                        table2.Rows[m][n] = DBNull.Value;
                                    }
                                }
                            }
                            tjds.Tables.Add(table2);
                        }
                        else if ((this.ribbonControl.Items[i].Name == "bCHK_LDBG_SPLDMJBGTJB") && (this.bCHK_LDBG_SPLDMJBGTJB.EditValue.ToString() == "True"))
                        {
                            string str5 = this.pSQL_CreateSPLDMJBGTJB();
                            SqlConnection connection3 = this.SQLDataConfig();
                            connection3.Open();
                            SqlCommand command3 = new SqlCommand(str5, connection3);
                            command3.CommandTimeout = 60;
                            SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
                            connection3.Close();
                            DataTable table3 = new DataTable();
                            table3.TableName = "b3";
                            adapter3.Fill(table3);
                            for (int num6 = 0; num6 < table3.Rows.Count; num6++)
                            {
                                for (int num7 = 0; num7 < table3.Columns.Count; num7++)
                                {
                                    if (((table3.Rows[num6][num7].ToString().Trim() == "0.00") || (table3.Rows[num6][num7].ToString().Trim() == "0.0")) || (table3.Rows[num6][num7].ToString().Trim() == "0"))
                                    {
                                        table3.Rows[num6][num7] = DBNull.Value;
                                    }
                                }
                            }
                            tjds.Tables.Add(table3);
                        }
                        else if ((this.ribbonControl.Items[i].Name == "bCHK_LDBG_GLLDDTZYTJB") && (this.bCHK_LDBG_GLLDDTZYTJB.EditValue.ToString() == "True"))
                        {
                            string str6 = this.pSQL_CreateGLLDDTZYTJB();
                            SqlConnection connection4 = this.SQLDataConfig();
                            connection4.Open();
                            SqlCommand command4 = new SqlCommand(str6, connection4);
                            command4.CommandTimeout = 60;
                            SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                            connection4.Close();
                            DataTable table4 = new DataTable();
                            table4.TableName = "b4";
                            adapter4.Fill(table4);
                            for (int num8 = 0; num8 < table4.Rows.Count; num8++)
                            {
                                for (int num9 = 0; num9 < table4.Columns.Count; num9++)
                                {
                                    if (((table4.Rows[num8][num9].ToString().Trim() == "0.00") || (table4.Rows[num8][num9].ToString().Trim() == "0.0")) || (table4.Rows[num8][num9].ToString().Trim() == "0"))
                                    {
                                        table4.Rows[num8][num9] = DBNull.Value;
                                    }
                                }
                            }
                            tjds.Tables.Add(table4);
                        }
                        else if ((this.ribbonControl.Items[i].Name == "bCHK_LDBG_LDBHYYFXTJB") && (this.bCHK_LDBG_LDBHYYFXTJB.EditValue.ToString() == "True"))
                        {
                            string str7 = this.pSQL_CreateLDBHYYFXTJB();
                            SqlConnection connection5 = this.SQLDataConfig();
                            connection5.Open();
                            SqlCommand command5 = new SqlCommand(str7, connection5);
                            command5.CommandTimeout = 60;
                            SqlDataAdapter adapter5 = new SqlDataAdapter(command5);
                            connection5.Close();
                            DataTable table5 = new DataTable();
                            table5.TableName = "b5";
                            adapter5.Fill(table5);
                            for (int num10 = 0; num10 < table5.Rows.Count; num10++)
                            {
                                for (int num11 = 0; num11 < table5.Columns.Count; num11++)
                                {
                                    if (((table5.Rows[num10][num11].ToString().Trim() == "0.00") || (table5.Rows[num10][num11].ToString().Trim() == "0.0")) || (table5.Rows[num10][num11].ToString().Trim() == "0"))
                                    {
                                        table5.Rows[num10][num11] = DBNull.Value;
                                    }
                                }
                            }
                            tjds.Tables.Add(table5);
                        }
                    }
                    new PrintZYDCTJBClass().ExportGJBHTJB(this.pXianName, this.pNowND.ToString(), tjds, xlsModelPath, xlsTargetPath);
                    Process.Start(xlsTargetPath);
                }
                catch
                {
                    MessageBox.Show("导出数据出错了");
                }
                finally
                {
                    GC.Collect();
                }
            }
        }

        private void btn_ZYDC_ALL_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmSelectTable(this.pConn, this.pDataBase).ShowDialog();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.pType == 1)
            {
                this.rp_LDNDBGDCTJB.Visible = false;
                this.rp_ZYDCTJB.Visible = true;
            }
            else if (this.pType == 2)
            {
                this.rp_LDNDBGDCTJB.Visible = false;
                this.rp_ZYDCTJB.Visible = true;
            }
            else
            {
                this.rp_LDNDBGDCTJB.Visible = false;
                this.rp_ZYDCTJB.Visible = true;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(this.pBackgroundWorker_DoWork);
            backgroundWorker.RunWorkerAsync(this);
            new frmWaiting(backgroundWorker).ShowDialog();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            SuperToolTip tip = new SuperToolTip();
            ToolTipTitleItem item = new ToolTipTitleItem();
            ToolTipItem item2 = new ToolTipItem();
            SuperToolTip tip2 = new SuperToolTip();
            ToolTipTitleItem item3 = new ToolTipTitleItem();
            ToolTipItem item4 = new ToolTipItem();
            SuperToolTip tip3 = new SuperToolTip();
            ToolTipTitleItem item5 = new ToolTipTitleItem();
            ToolTipItem item6 = new ToolTipItem();
            SuperToolTip tip4 = new SuperToolTip();
            ToolTipTitleItem item7 = new ToolTipTitleItem();
            ToolTipItem item8 = new ToolTipItem();
            SuperToolTip tip5 = new SuperToolTip();
            ToolTipTitleItem item9 = new ToolTipTitleItem();
            ToolTipItem item10 = new ToolTipItem();
            SuperToolTip tip6 = new SuperToolTip();
            ToolTipTitleItem item11 = new ToolTipTitleItem();
            ToolTipItem item12 = new ToolTipItem();
            SuperToolTip tip7 = new SuperToolTip();
            ToolTipTitleItem item13 = new ToolTipTitleItem();
            ToolTipItem item14 = new ToolTipItem();
            SuperToolTip tip8 = new SuperToolTip();
            ToolTipTitleItem item15 = new ToolTipTitleItem();
            ToolTipItem item16 = new ToolTipItem();
            SuperToolTip tip9 = new SuperToolTip();
            ToolTipTitleItem item17 = new ToolTipTitleItem();
            ToolTipItem item18 = new ToolTipItem();
            SuperToolTip tip10 = new SuperToolTip();
            ToolTipTitleItem item19 = new ToolTipTitleItem();
            ToolTipItem item20 = new ToolTipItem();
            SuperToolTip tip11 = new SuperToolTip();
            ToolTipTitleItem item21 = new ToolTipTitleItem();
            ToolTipItem item22 = new ToolTipItem();
            SuperToolTip tip12 = new SuperToolTip();
            ToolTipTitleItem item23 = new ToolTipTitleItem();
            ToolTipItem item24 = new ToolTipItem();
            SuperToolTip tip13 = new SuperToolTip();
            ToolTipTitleItem item25 = new ToolTipTitleItem();
            ToolTipItem item26 = new ToolTipItem();
            SuperToolTip tip14 = new SuperToolTip();
            ToolTipTitleItem item27 = new ToolTipTitleItem();
            ToolTipItem item28 = new ToolTipItem();
            SuperToolTip tip15 = new SuperToolTip();
            ToolTipTitleItem item29 = new ToolTipTitleItem();
            ToolTipItem item30 = new ToolTipItem();
            SuperToolTip tip16 = new SuperToolTip();
            ToolTipTitleItem item31 = new ToolTipTitleItem();
            ToolTipItem item32 = new ToolTipItem();
            SuperToolTip tip17 = new SuperToolTip();
            ToolTipTitleItem item33 = new ToolTipTitleItem();
            ToolTipItem item34 = new ToolTipItem();
            SuperToolTip tip18 = new SuperToolTip();
            ToolTipTitleItem item35 = new ToolTipTitleItem();
            ToolTipItem item36 = new ToolTipItem();
            SuperToolTip tip19 = new SuperToolTip();
            ToolTipTitleItem item37 = new ToolTipTitleItem();
            ToolTipItem item38 = new ToolTipItem();
            SuperToolTip tip20 = new SuperToolTip();
            ToolTipTitleItem item39 = new ToolTipTitleItem();
            ToolTipItem item40 = new ToolTipItem();
            SuperToolTip tip21 = new SuperToolTip();
            ToolTipTitleItem item41 = new ToolTipTitleItem();
            ToolTipItem item42 = new ToolTipItem();
            SuperToolTip tip22 = new SuperToolTip();
            ToolTipTitleItem item43 = new ToolTipTitleItem();
            ToolTipItem item44 = new ToolTipItem();
            SuperToolTip tip23 = new SuperToolTip();
            ToolTipTitleItem item45 = new ToolTipTitleItem();
            ToolTipItem item46 = new ToolTipItem();
            SuperToolTip tip24 = new SuperToolTip();
            ToolTipTitleItem item47 = new ToolTipTitleItem();
            ToolTipItem item48 = new ToolTipItem();
            SuperToolTip tip25 = new SuperToolTip();
            ToolTipTitleItem item49 = new ToolTipTitleItem();
            ToolTipItem item50 = new ToolTipItem();
            SuperToolTip tip26 = new SuperToolTip();
            ToolTipTitleItem item51 = new ToolTipTitleItem();
            ToolTipItem item52 = new ToolTipItem();
            SuperToolTip tip27 = new SuperToolTip();
            ToolTipTitleItem item53 = new ToolTipTitleItem();
            ToolTipItem item54 = new ToolTipItem();
            SuperToolTip tip28 = new SuperToolTip();
            ToolTipTitleItem item55 = new ToolTipTitleItem();
            ToolTipItem item56 = new ToolTipItem();
            SuperToolTip tip29 = new SuperToolTip();
            ToolTipTitleItem item57 = new ToolTipTitleItem();
            ToolTipItem item58 = new ToolTipItem();
            SuperToolTip tip30 = new SuperToolTip();
            ToolTipTitleItem item59 = new ToolTipTitleItem();
            ToolTipItem item60 = new ToolTipItem();
            SuperToolTip tip31 = new SuperToolTip();
            ToolTipTitleItem item61 = new ToolTipTitleItem();
            ToolTipItem item62 = new ToolTipItem();
            SuperToolTip tip32 = new SuperToolTip();
            ToolTipTitleItem item63 = new ToolTipTitleItem();
            ToolTipItem item64 = new ToolTipItem();
            SuperToolTip tip33 = new SuperToolTip();
            ToolTipTitleItem item65 = new ToolTipTitleItem();
            ToolTipItem item66 = new ToolTipItem();
            SuperToolTip tip34 = new SuperToolTip();
            ToolTipTitleItem item67 = new ToolTipTitleItem();
            ToolTipItem item68 = new ToolTipItem();
            SuperToolTip tip35 = new SuperToolTip();
            ToolTipTitleItem item69 = new ToolTipTitleItem();
            ToolTipItem item70 = new ToolTipItem();
            SuperToolTip tip36 = new SuperToolTip();
            ToolTipTitleItem item71 = new ToolTipTitleItem();
            ToolTipItem item72 = new ToolTipItem();
            SuperToolTip tip37 = new SuperToolTip();
            ToolTipTitleItem item73 = new ToolTipTitleItem();
            ToolTipItem item74 = new ToolTipItem();
            SuperToolTip tip38 = new SuperToolTip();
            ToolTipTitleItem item75 = new ToolTipTitleItem();
            ToolTipItem item76 = new ToolTipItem();
            SuperToolTip tip39 = new SuperToolTip();
            ToolTipTitleItem item77 = new ToolTipTitleItem();
            ToolTipItem item78 = new ToolTipItem();
            SuperToolTip tip40 = new SuperToolTip();
            ToolTipTitleItem item79 = new ToolTipTitleItem();
            ToolTipItem item80 = new ToolTipItem();
            GridLevelNode node = new GridLevelNode();
            this.ribbonControl = new RibbonControl();
            this.ribbonImageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.iNew = new BarButtonItem();
            this.iOpen = new BarButtonItem();
            this.iClose = new BarButtonItem();
            this.iFind = new BarButtonItem();
            this.iSave = new BarButtonItem();
            this.iSaveAs = new BarButtonItem();
            this.iExit = new BarButtonItem();
            this.iHelp = new BarButtonItem();
            this.iAbout = new BarButtonItem();
            this.siStatus = new BarStaticItem();
            this.siInfo = new BarStaticItem();
            this.alignButtonGroup = new BarButtonGroup();
            this.iBoldFontStyle = new BarButtonItem();
            this.iItalicFontStyle = new BarButtonItem();
            this.iUnderlinedFontStyle = new BarButtonItem();
            this.fontStyleButtonGroup = new BarButtonGroup();
            this.iLeftTextAlign = new BarButtonItem();
            this.iCenterTextAlign = new BarButtonItem();
            this.iRightTextAlign = new BarButtonItem();
            this.rgbiSkins = new RibbonGalleryBarItem();
            this.barButtonItem1 = new BarButtonItem();
            this.printPreviewBarItem5 = new PrintPreviewBarItem();
            this.printRibbonController1 = new PrintRibbonController();
            this.ribbonStatusBar = new RibbonStatusBar();
            this.printPreviewStaticItem1 = new PrintPreviewStaticItem();
            this.barStaticItem1 = new BarStaticItem();
            this.progressBarEditItem1 = new ProgressBarEditItem();
            this.repositoryItemProgressBar1 = new RepositoryItemProgressBar();
            this.printPreviewBarItem48 = new PrintPreviewBarItem();
            this.barButtonItem2 = new BarButtonItem();
            this.printPreviewStaticItem2 = new PrintPreviewStaticItem();
            this.zoomTrackBarEditItem1 = new ZoomTrackBarEditItem();
            this.repositoryItemZoomTrackBar1 = new RepositoryItemZoomTrackBar();
            this.printPreviewBarItem6 = new PrintPreviewBarItem();
            this.printPreviewBarItem7 = new PrintPreviewBarItem();
            this.printPreviewBarItem8 = new PrintPreviewBarItem();
            this.printPreviewBarItem10 = new PrintPreviewBarItem();
            this.printPreviewBarItem11 = new PrintPreviewBarItem();
            this.printPreviewBarItem12 = new PrintPreviewBarItem();
            this.printPreviewBarItem13 = new PrintPreviewBarItem();
            this.printPreviewBarItem14 = new PrintPreviewBarItem();
            this.printPreviewBarItem15 = new PrintPreviewBarItem();
            this.printPreviewBarItem16 = new PrintPreviewBarItem();
            this.printPreviewBarItem17 = new PrintPreviewBarItem();
            this.printPreviewBarItem18 = new PrintPreviewBarItem();
            this.printPreviewBarItem19 = new PrintPreviewBarItem();
            this.printPreviewBarItem20 = new PrintPreviewBarItem();
            this.printPreviewBarItem21 = new PrintPreviewBarItem();
            this.printPreviewBarItem22 = new PrintPreviewBarItem();
            this.printPreviewBarItem23 = new PrintPreviewBarItem();
            this.printPreviewBarItem26 = new PrintPreviewBarItem();
            this.printPreviewBarItem27 = new PrintPreviewBarItem();
            this.printPreviewBarItem28 = new PrintPreviewBarItem();
            this.printPreviewBarItem29 = new PrintPreviewBarItem();
            this.printPreviewBarItem30 = new PrintPreviewBarItem();
            this.printPreviewBarItem31 = new PrintPreviewBarItem();
            this.printPreviewBarItem32 = new PrintPreviewBarItem();
            this.printPreviewBarItem33 = new PrintPreviewBarItem();
            this.printPreviewBarItem34 = new PrintPreviewBarItem();
            this.printPreviewBarItem35 = new PrintPreviewBarItem();
            this.printPreviewBarItem36 = new PrintPreviewBarItem();
            this.printPreviewBarItem37 = new PrintPreviewBarItem();
            this.printPreviewBarItem38 = new PrintPreviewBarItem();
            this.printPreviewBarItem39 = new PrintPreviewBarItem();
            this.printPreviewBarItem40 = new PrintPreviewBarItem();
            this.printPreviewBarItem41 = new PrintPreviewBarItem();
            this.printPreviewBarItem42 = new PrintPreviewBarItem();
            this.printPreviewBarItem43 = new PrintPreviewBarItem();
            this.printPreviewBarItem44 = new PrintPreviewBarItem();
            this.printPreviewBarItem45 = new PrintPreviewBarItem();
            this.printPreviewBarItem46 = new PrintPreviewBarItem();
            this.printPreviewBarItem47 = new PrintPreviewBarItem();
            this.bCHK_LDBG_GLLDMJBGTJB = new BarEditItem();
            this.repositoryItemCheckEdit2 = new RepositoryItemCheckEdit();
            this.bCHK_LDBG_GYLDMJBGTJB = new BarEditItem();
            this.repositoryItemCheckEdit3 = new RepositoryItemCheckEdit();
            this.bCHK_LDBG_SPLDMJBGTJB = new BarEditItem();
            this.repositoryItemCheckEdit4 = new RepositoryItemCheckEdit();
            this.bCHK_LDBG_GLLDDTZYTJB = new BarEditItem();
            this.repositoryItemCheckEdit5 = new RepositoryItemCheckEdit();
            this.bCHK_LDBG_LDBHYYFXTJB = new BarEditItem();
            this.repositoryItemCheckEdit6 = new RepositoryItemCheckEdit();
            this.bBTN_LDBG_Print = new BarButtonItem();
            this.bBTN_LDBG_TJ = new BarButtonItem();
            this.bCHK_ZYGX_DLBHXBDCB = new BarEditItem();
            this.repositoryItemCheckEdit9 = new RepositoryItemCheckEdit();
            this.bBTN_ZYGX_TJ = new BarButtonItem();
            this.bCHK_ZYBH_B1_GLTDMJBHB = new BarEditItem();
            this.repositoryItemCheckEdit10 = new RepositoryItemCheckEdit();
            this.bCHK_ZYBH_B2_GLSLLMMJXJBHB = new BarEditItem();
            this.repositoryItemCheckEdit11 = new RepositoryItemCheckEdit();
            this.bBTN_Export = new BarButtonItem();
            this.bCHK_ZYBH_B3_GLZMJXJBHB = new BarEditItem();
            this.repositoryItemCheckEdit12 = new RepositoryItemCheckEdit();
            this.bCHK_ZYBH_B4_ZYSZMJXJBHB = new BarEditItem();
            this.repositoryItemCheckEdit14 = new RepositoryItemCheckEdit();
            this.bCHK_ZYBH_B5_YCLMJXJBHB = new BarEditItem();
            this.repositoryItemCheckEdit15 = new RepositoryItemCheckEdit();
            this.bCHK_ZYBH_B5_GYLDTJB = new BarEditItem();
            this.repositoryItemCheckEdit16 = new RepositoryItemCheckEdit();
            this.btn_Brow = new BarButtonItem();
            this.btn_ZYDC_ALL = new BarButtonItem();
            this.btn_LDBG_Export = new BarButtonItem();
            this.ribbonImageCollectionLarge = new DevExpress.Utils.ImageCollection(this.components);
            this.rp_ZYDCTJB = new RibbonPage();
            this.ribbonPageGroup5 = new RibbonPageGroup();
            this.ribbonPageGroup6 = new RibbonPageGroup();
            this.rp_LDNDBGDCTJB = new RibbonPage();
            this.ribbonPageGroup1 = new RibbonPageGroup();
            this.ribbonPageGroup2 = new RibbonPageGroup();
            this.rp_ZYGXTJB = new RibbonPage();
            this.ribbonPageGroup3 = new RibbonPageGroup();
            this.ribbonPageGroup4 = new RibbonPageGroup();
            this.repositoryItemCheckEdit1 = new RepositoryItemCheckEdit();
            this.repositoryItemButtonEdit1 = new RepositoryItemButtonEdit();
            this.repositoryItemCheckEdit8 = new RepositoryItemCheckEdit();
            this.repositoryItemProgressBar2 = new RepositoryItemProgressBar();
            this.repositoryItemCheckEdit13 = new RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit17 = new RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit18 = new RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit19 = new RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit20 = new RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit21 = new RepositoryItemCheckEdit();
            this.repositoryItemComboBox1 = new RepositoryItemComboBox();
            this.repositoryItemPopupContainerEdit1 = new RepositoryItemPopupContainerEdit();
            this.repositoryItemCheckedComboBoxEdit1 = new RepositoryItemCheckedComboBoxEdit();
            this.repositoryItemButtonEdit2 = new RepositoryItemButtonEdit();
            this.navBarControl = new NavBarControl();
            this.navBarGroup_0 = new NavBarGroup();
            this.navBarItem_GLLDMJBGTJB = new NavBarItem();
            this.navBarItem_GYLDMJBGTJB = new NavBarItem();
            this.navBarItem_SPLDMJBGTJB = new NavBarItem();
            this.navBarItem_GLLDDTZYTJB = new NavBarItem();
            this.navBarItem_LDBHYYFXTJB = new NavBarItem();
            this.navBarItem_ZYGX_DLBHXBDCB = new NavBarItem();
            this.navBarItem_ZYBH_B1_GLTDMJBHB = new NavBarItem();
            this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB = new NavBarItem();
            this.navBarItem_ZYBH_B3_GLZMJXJBHB = new NavBarItem();
            this.navBarItem_ZYBH_B2_GLSLLMMJXJTJB2 = new NavBarItem();
            this.navBarItem_ZYBH_B4_ZYSZMJXJBHB = new NavBarItem();
            this.navBarItem_ZYBH_B5_YCLMJXJBHB = new NavBarItem();
            this.navbarImageListLarge = new ImageList(this.components);
            this.splitContainerControl = new SplitContainerControl();
            this.gridControl = new GridControl();
            this.GView_ZYBH_B1_GLTDMJBHB = new AdvBandedGridView();
            this.gridBand274 = new GridBand();
            this.gBandZYBHB1DW = new GridBand();
            this.gridBand134 = new GridBand();
            this.gridBand137 = new GridBand();
            this.bandedGridColumn81 = new BandedGridColumn();
            this.gridBand135 = new GridBand();
            this.gridBand138 = new GridBand();
            this.bandedGridColumn82 = new BandedGridColumn();
            this.gridBand136 = new GridBand();
            this.gridBand161 = new GridBand();
            this.bandedGridColumn83 = new BandedGridColumn();
            this.gridBand162 = new GridBand();
            this.gridBand189 = new GridBand();
            this.gridBand230 = new GridBand();
            this.bandedGridColumn84 = new BandedGridColumn();
            this.gridBand190 = new GridBand();
            this.gridBand191 = new GridBand();
            this.gridBand231 = new GridBand();
            this.bandedGridColumn85 = new BandedGridColumn();
            this.gridBand192 = new GridBand();
            this.gridBand193 = new GridBand();
            this.gridBand232 = new GridBand();
            this.bandedGridColumn86 = new BandedGridColumn();
            this.gridBand194 = new GridBand();
            this.gridBand233 = new GridBand();
            this.bandedGridColumn87 = new BandedGridColumn();
            this.gridBand195 = new GridBand();
            this.gridBand234 = new GridBand();
            this.bandedGridColumn88 = new BandedGridColumn();
            this.gridBand196 = new GridBand();
            this.gridBand235 = new GridBand();
            this.bandedGridColumn89 = new BandedGridColumn();
            this.gridBand197 = new GridBand();
            this.gridBand236 = new GridBand();
            this.bandedGridColumn90 = new BandedGridColumn();
            this.gridBand198 = new GridBand();
            this.gridBand237 = new GridBand();
            this.bandedGridColumn91 = new BandedGridColumn();
            this.gridBand200 = new GridBand();
            this.gridBand201 = new GridBand();
            this.gridBand238 = new GridBand();
            this.bandedGridColumn92 = new BandedGridColumn();
            this.gridBand202 = new GridBand();
            this.gridBand203 = new GridBand();
            this.gridBand239 = new GridBand();
            this.bandedGridColumn93 = new BandedGridColumn();
            this.gridBand204 = new GridBand();
            this.gridBand240 = new GridBand();
            this.bandedGridColumn94 = new BandedGridColumn();
            this.gridBand205 = new GridBand();
            this.gridBand241 = new GridBand();
            this.bandedGridColumn95 = new BandedGridColumn();
            this.gridBand199 = new GridBand();
            this.gridBand207 = new GridBand();
            this.gridBand242 = new GridBand();
            this.bandedGridColumn96 = new BandedGridColumn();
            this.gridBand206 = new GridBand();
            this.gridBand243 = new GridBand();
            this.bandedGridColumn97 = new BandedGridColumn();
            this.gridBand208 = new GridBand();
            this.gridBand244 = new GridBand();
            this.bandedGridColumn98 = new BandedGridColumn();
            this.gridBand209 = new GridBand();
            this.gridBand245 = new GridBand();
            this.bandedGridColumn99 = new BandedGridColumn();
            this.gridBand210 = new GridBand();
            this.gridBand211 = new GridBand();
            this.gridBand246 = new GridBand();
            this.bandedGridColumn100 = new BandedGridColumn();
            this.gridBand212 = new GridBand();
            this.gridBand247 = new GridBand();
            this.bandedGridColumn101 = new BandedGridColumn();
            this.gridBand213 = new GridBand();
            this.gridBand248 = new GridBand();
            this.bandedGridColumn102 = new BandedGridColumn();
            this.gridBand214 = new GridBand();
            this.gridBand249 = new GridBand();
            this.bandedGridColumn103 = new BandedGridColumn();
            this.gridBand215 = new GridBand();
            this.gridBand216 = new GridBand();
            this.gridBand250 = new GridBand();
            this.bandedGridColumn104 = new BandedGridColumn();
            this.gridBand217 = new GridBand();
            this.gridBand251 = new GridBand();
            this.bandedGridColumn105 = new BandedGridColumn();
            this.gridBand218 = new GridBand();
            this.gridBand252 = new GridBand();
            this.gridBand219 = new GridBand();
            this.gridBand253 = new GridBand();
            this.bandedGridColumn106 = new BandedGridColumn();
            this.gridBand220 = new GridBand();
            this.gridBand254 = new GridBand();
            this.bandedGridColumn107 = new BandedGridColumn();
            this.gridBand221 = new GridBand();
            this.gridBand255 = new GridBand();
            this.bandedGridColumn108 = new BandedGridColumn();
            this.gridBand222 = new GridBand();
            this.gridBand223 = new GridBand();
            this.gridBand256 = new GridBand();
            this.bandedGridColumn109 = new BandedGridColumn();
            this.gridBand224 = new GridBand();
            this.gridBand524 = new GridBand();
            this.gridBand257 = new GridBand();
            this.bandedGridColumn110 = new BandedGridColumn();
            this.gridBand225 = new GridBand();
            this.gridBand258 = new GridBand();
            this.bandedGridColumn111 = new BandedGridColumn();
            this.gridBand226 = new GridBand();
            this.gridBand259 = new GridBand();
            this.bandedGridColumn112 = new BandedGridColumn();
            this.gridBand227 = new GridBand();
            this.gridBand260 = new GridBand();
            this.bandedGridColumn113 = new BandedGridColumn();
            this.gridBand228 = new GridBand();
            this.gridBand261 = new GridBand();
            this.bandedGridColumn114 = new BandedGridColumn();
            this.gridBand229 = new GridBand();
            this.gridBand266 = new GridBand();
            this.bandedGridColumn115 = new BandedGridColumn();
            this.GView_ZYBH_B2_GLSLLMMJXJBHB = new AdvBandedGridView();
            this.gridBand276 = new GridBand();
            this.gBandZYBHB2DW = new GridBand();
            this.gridBand286 = new GridBand();
            this.gridBand287 = new GridBand();
            this.bandedGridColumn138 = new BandedGridColumn();
            this.gridBand288 = new GridBand();
            this.gridBand289 = new GridBand();
            this.bandedGridColumn139 = new BandedGridColumn();
            this.gridBand330 = new GridBand();
            this.gridBand331 = new GridBand();
            this.bandedGridColumn140 = new BandedGridColumn();
            this.gridBand293 = new GridBand();
            this.gridBand315 = new GridBand();
            this.gridBand316 = new GridBand();
            this.bandedGridColumn141 = new BandedGridColumn();
            this.gridBand317 = new GridBand();
            this.gridBand318 = new GridBand();
            this.gridBand332 = new GridBand();
            this.gridBand333 = new GridBand();
            this.bandedGridColumn142 = new BandedGridColumn();
            this.gridBand335 = new GridBand();
            this.gridBand336 = new GridBand();
            this.bandedGridColumn143 = new BandedGridColumn();
            this.gridBand320 = new GridBand();
            this.gridBand324 = new GridBand();
            this.gridBand325 = new GridBand();
            this.bandedGridColumn144 = new BandedGridColumn();
            this.gridBand339 = new GridBand();
            this.gridBand340 = new GridBand();
            this.bandedGridColumn145 = new BandedGridColumn();
            this.gridBand337 = new GridBand();
            this.gridBand328 = new GridBand();
            this.gridBand329 = new GridBand();
            this.bandedGridColumn146 = new BandedGridColumn();
            this.gridBand341 = new GridBand();
            this.gridBand342 = new GridBand();
            this.bandedGridColumn147 = new BandedGridColumn();
            this.gridBand334 = new GridBand();
            this.gridBand344 = new GridBand();
            this.gridBand345 = new GridBand();
            this.bandedGridColumn148 = new BandedGridColumn();
            this.gridBand343 = new GridBand();
            this.gridBand346 = new GridBand();
            this.gridBand347 = new GridBand();
            this.bandedGridColumn149 = new BandedGridColumn();
            this.gridBand348 = new GridBand();
            this.gridBand349 = new GridBand();
            this.bandedGridColumn150 = new BandedGridColumn();
            this.gridBand350 = new GridBand();
            this.gridBand352 = new GridBand();
            this.gridBand353 = new GridBand();
            this.bandedGridColumn151 = new BandedGridColumn();
            this.gridBand354 = new GridBand();
            this.gridBand355 = new GridBand();
            this.bandedGridColumn152 = new BandedGridColumn();
            this.gridBand356 = new GridBand();
            this.gridBand358 = new GridBand();
            this.gridBand357 = new GridBand();
            this.bandedGridColumn153 = new BandedGridColumn();
            this.gridBand359 = new GridBand();
            this.gridBand360 = new GridBand();
            this.bandedGridColumn154 = new BandedGridColumn();
            this.gridBand361 = new GridBand();
            this.gridBand362 = new GridBand();
            this.gridBand363 = new GridBand();
            this.bandedGridColumn155 = new BandedGridColumn();
            this.gridBand364 = new GridBand();
            this.gridBand365 = new GridBand();
            this.bandedGridColumn156 = new BandedGridColumn();
            this.gridBand170 = new GridBand();
            this.gridBand183 = new GridBand();
            this.gridBand282 = new GridBand();
            this.bandedGridColumn50 = new BandedGridColumn();
            this.gridBand283 = new GridBand();
            this.gridBand284 = new GridBand();
            this.bandedGridColumn70 = new BandedGridColumn();
            this.gridView1 = new GridView();
            this.GView_ZYBH_B5_YCLMJXJBHB = new AdvBandedGridView();
            this.gridBand481 = new GridBand();
            this.gridBand482 = new GridBand();
            this.gridBand521 = new GridBand();
            this.gridBand530 = new GridBand();
            this.gridBand281 = new GridBand();
            this.gBandZYBHB5DW = new GridBand();
            this.gridBand385 = new GridBand();
            this.gridBand480 = new GridBand();
            this.bandedGridColumn204 = new BandedGridColumn();
            this.gridBand485 = new GridBand();
            this.gridBand484 = new GridBand();
            this.bandedGridColumn205 = new BandedGridColumn();
            this.gridBand483 = new GridBand();
            this.gridBand520 = new GridBand();
            this.bandedGridColumn206 = new BandedGridColumn();
            this.gridBand490 = new GridBand();
            this.gridBand491 = new GridBand();
            this.gridBand492 = new GridBand();
            this.bandedGridColumn207 = new BandedGridColumn();
            this.gridBand493 = new GridBand();
            this.gridBand494 = new GridBand();
            this.bandedGridColumn208 = new BandedGridColumn();
            this.gridBand495 = new GridBand();
            this.gridBand496 = new GridBand();
            this.gridBand497 = new GridBand();
            this.bandedGridColumn209 = new BandedGridColumn();
            this.gridBand498 = new GridBand();
            this.gridBand499 = new GridBand();
            this.bandedGridColumn210 = new BandedGridColumn();
            this.gridBand500 = new GridBand();
            this.gridBand501 = new GridBand();
            this.gridBand502 = new GridBand();
            this.bandedGridColumn211 = new BandedGridColumn();
            this.gridBand503 = new GridBand();
            this.gridBand504 = new GridBand();
            this.bandedGridColumn212 = new BandedGridColumn();
            this.gridBand505 = new GridBand();
            this.gridBand506 = new GridBand();
            this.gridBand507 = new GridBand();
            this.bandedGridColumn213 = new BandedGridColumn();
            this.gridBand508 = new GridBand();
            this.gridBand509 = new GridBand();
            this.bandedGridColumn214 = new BandedGridColumn();
            this.gridBand510 = new GridBand();
            this.gridBand511 = new GridBand();
            this.gridBand512 = new GridBand();
            this.bandedGridColumn215 = new BandedGridColumn();
            this.gridBand513 = new GridBand();
            this.gridBand514 = new GridBand();
            this.bandedGridColumn216 = new BandedGridColumn();
            this.gridBand515 = new GridBand();
            this.gridBand516 = new GridBand();
            this.gridBand517 = new GridBand();
            this.bandedGridColumn217 = new BandedGridColumn();
            this.gridBand518 = new GridBand();
            this.gridBand519 = new GridBand();
            this.bandedGridColumn218 = new BandedGridColumn();
            this.GView_GYLDMJBGTJB = new AdvBandedGridView();
            this.gridBand268 = new GridBand();
            this.gBandLDBHB2DWND = new GridBand();
            this.gridBand36 = new GridBand();
            this.gridBand37 = new GridBand();
            this.bandedGridColumn1 = new BandedGridColumn();
            this.gridBand52 = new GridBand();
            this.gridBand69 = new GridBand();
            this.bandedGridColumn2 = new BandedGridColumn();
            this.gridBand38 = new GridBand();
            this.gridBand39 = new GridBand();
            this.gridBand70 = new GridBand();
            this.bandedGridColumn3 = new BandedGridColumn();
            this.gridBand40 = new GridBand();
            this.gridBand59 = new GridBand();
            this.gridBand60 = new GridBand();
            this.bandedGridColumn4 = new BandedGridColumn();
            this.gridBand61 = new GridBand();
            this.gridBand62 = new GridBand();
            this.bandedGridColumn5 = new BandedGridColumn();
            this.gridBand63 = new GridBand();
            this.gridBand64 = new GridBand();
            this.bandedGridColumn6 = new BandedGridColumn();
            this.gridBand65 = new GridBand();
            this.gridBand66 = new GridBand();
            this.bandedGridColumn7 = new BandedGridColumn();
            this.gridBand67 = new GridBand();
            this.gridBand71 = new GridBand();
            this.gridBand68 = new GridBand();
            this.bandedGridColumn8 = new BandedGridColumn();
            this.gridBand72 = new GridBand();
            this.gridBand73 = new GridBand();
            this.gridBand74 = new GridBand();
            this.bandedGridColumn9 = new BandedGridColumn();
            this.gridBand75 = new GridBand();
            this.gridBand76 = new GridBand();
            this.bandedGridColumn10 = new BandedGridColumn();
            this.gridBand77 = new GridBand();
            this.gridBand78 = new GridBand();
            this.bandedGridColumn11 = new BandedGridColumn();
            this.gridBand79 = new GridBand();
            this.gridBand80 = new GridBand();
            this.bandedGridColumn12 = new BandedGridColumn();
            this.gridBand81 = new GridBand();
            this.gridBand82 = new GridBand();
            this.gridBand87 = new GridBand();
            this.bandedGridColumn13 = new BandedGridColumn();
            this.gridBand83 = new GridBand();
            this.gridBand84 = new GridBand();
            this.gridBand89 = new GridBand();
            this.bandedGridColumn14 = new BandedGridColumn();
            this.gridBand85 = new GridBand();
            this.gridBand90 = new GridBand();
            this.bandedGridColumn15 = new BandedGridColumn();
            this.gridBand86 = new GridBand();
            this.gridBand91 = new GridBand();
            this.bandedGridColumn16 = new BandedGridColumn();
            this.gridBand92 = new GridBand();
            this.gridBand93 = new GridBand();
            this.bandedGridColumn17 = new BandedGridColumn();
            this.GView_GLLDMJBGTJB = new AdvBandedGridView();
            this.gridBand267 = new GridBand();
            this.gBandLDBHB1DWND = new GridBand();
            this.gridBand1 = new GridBand();
            this.gridBand19 = new GridBand();
            this.gCol_TJDW = new BandedGridColumn();
            this.gridBand2 = new GridBand();
            this.gridBand20 = new GridBand();
            this.gCol_QS = new BandedGridColumn();
            this.gridBand3 = new GridBand();
            this.gridBand21 = new GridBand();
            this.gCol_HJ = new BandedGridColumn();
            this.gridBand4 = new GridBand();
            this.gridBand5 = new GridBand();
            this.gridBand22 = new GridBand();
            this.gCol_YLDXJ = new BandedGridColumn();
            this.gridBand6 = new GridBand();
            this.gridBand23 = new GridBand();
            this.gCol_QML = new BandedGridColumn();
            this.gridBand7 = new GridBand();
            this.gridBand24 = new GridBand();
            this.gCol_ZL = new BandedGridColumn();
            this.gridBand8 = new GridBand();
            this.gridBand25 = new GridBand();
            this.gCol_HSL = new BandedGridColumn();
            this.gridBand9 = new GridBand();
            this.gridBand26 = new GridBand();
            this.gCol_SLD = new BandedGridColumn();
            this.gridBand10 = new GridBand();
            this.gridBand11 = new GridBand();
            this.gridBand27 = new GridBand();
            this.gCol_GMLDXJ = new BandedGridColumn();
            this.gridBand12 = new GridBand();
            this.gridBand28 = new GridBand();
            this.gCol_GJGML = new BandedGridColumn();
            this.gridBand13 = new GridBand();
            this.gridBand29 = new GridBand();
            this.gCol_QTGML = new BandedGridColumn();
            this.gridBand14 = new GridBand();
            this.gridBand30 = new GridBand();
            this.gCol_WCLD = new BandedGridColumn();
            this.gridBand15 = new GridBand();
            this.gridBand31 = new GridBand();
            this.gCol_MPD = new BandedGridColumn();
            this.gridBand16 = new GridBand();
            this.gridBand32 = new GridBand();
            this.gCol_WLMLD = new BandedGridColumn();
            this.gridBand17 = new GridBand();
            this.gridBand33 = new GridBand();
            this.gCol_YLD = new BandedGridColumn();
            this.gridBand18 = new GridBand();
            this.gridBand34 = new GridBand();
            this.gCol_LYFZSCYD = new BandedGridColumn();
            this.GView_ZYBH_B4_ZYSZMJXJBHB = new AdvBandedGridView();
            this.gridBand280 = new GridBand();
            this.gBandZYBHB4DW = new GridBand();
            this.gridBand262 = new GridBand();
            this.gridBand263 = new GridBand();
            this.bandedGridColumn73 = new BandedGridColumn();
            this.gridBand264 = new GridBand();
            this.gridBand265 = new GridBand();
            this.bandedGridColumn74 = new BandedGridColumn();
            this.gridBand272 = new GridBand();
            this.gridBand273 = new GridBand();
            this.gridBand307 = new GridBand();
            this.bandedGridColumn75 = new BandedGridColumn();
            this.gridBand275 = new GridBand();
            this.gridBand308 = new GridBand();
            this.bandedGridColumn76 = new BandedGridColumn();
            this.gridBand277 = new GridBand();
            this.gridBand278 = new GridBand();
            this.gridBand309 = new GridBand();
            this.bandedGridColumn77 = new BandedGridColumn();
            this.gridBand319 = new GridBand();
            this.gridBand321 = new GridBand();
            this.bandedGridColumn78 = new BandedGridColumn();
            this.gridBand322 = new GridBand();
            this.gridBand323 = new GridBand();
            this.gridBand326 = new GridBand();
            this.bandedGridColumn79 = new BandedGridColumn();
            this.gridBand327 = new GridBand();
            this.gridBand338 = new GridBand();
            this.bandedGridColumn80 = new BandedGridColumn();
            this.gridBand351 = new GridBand();
            this.gridBand366 = new GridBand();
            this.gridBand367 = new GridBand();
            this.bandedGridColumn116 = new BandedGridColumn();
            this.gridBand368 = new GridBand();
            this.gridBand369 = new GridBand();
            this.bandedGridColumn117 = new BandedGridColumn();
            this.GView_ZYBH_B3_GLZMJXJBHB = new AdvBandedGridView();
            this.gridBand97 = new GridBand();
            this.gridBand98 = new GridBand();
            this.gridBand101 = new GridBand();
            this.gridBand102 = new GridBand();
            this.gridBand115 = new GridBand();
            this.gridBand116 = new GridBand();
            this.gridBand279 = new GridBand();
            this.gBandZYBHB3DW = new GridBand();
            this.gridBand95 = new GridBand();
            this.gridBand96 = new GridBand();
            this.bandedGridColumn56 = new BandedGridColumn();
            this.gridBand99 = new GridBand();
            this.gridBand100 = new GridBand();
            this.bandedGridColumn57 = new BandedGridColumn();
            this.gridBand117 = new GridBand();
            this.gridBand118 = new GridBand();
            this.gridBand595 = new GridBand();
            this.bandedGridColumn58 = new BandedGridColumn();
            this.gridBand120 = new GridBand();
            this.gridBand119 = new GridBand();
            this.bandedGridColumn59 = new BandedGridColumn();
            this.gridBand122 = new GridBand();
            this.gridBand123 = new GridBand();
            this.gridBand121 = new GridBand();
            this.bandedGridColumn60 = new BandedGridColumn();
            this.gridBand125 = new GridBand();
            this.gridBand124 = new GridBand();
            this.bandedGridColumn61 = new BandedGridColumn();
            this.gridBand127 = new GridBand();
            this.gridBand128 = new GridBand();
            this.gridBand126 = new GridBand();
            this.bandedGridColumn62 = new BandedGridColumn();
            this.gridBand130 = new GridBand();
            this.gridBand129 = new GridBand();
            this.bandedGridColumn63 = new BandedGridColumn();
            this.gridBand132 = new GridBand();
            this.gridBand133 = new GridBand();
            this.gridBand131 = new GridBand();
            this.bandedGridColumn64 = new BandedGridColumn();
            this.gridBand583 = new GridBand();
            this.gridBand582 = new GridBand();
            this.bandedGridColumn65 = new BandedGridColumn();
            this.gridBand585 = new GridBand();
            this.gridBand586 = new GridBand();
            this.gridBand584 = new GridBand();
            this.bandedGridColumn66 = new BandedGridColumn();
            this.gridBand588 = new GridBand();
            this.gridBand587 = new GridBand();
            this.bandedGridColumn67 = new BandedGridColumn();
            this.gridBand590 = new GridBand();
            this.gridBand591 = new GridBand();
            this.gridBand589 = new GridBand();
            this.bandedGridColumn68 = new BandedGridColumn();
            this.gridBand593 = new GridBand();
            this.gridBand592 = new GridBand();
            this.bandedGridColumn69 = new BandedGridColumn();
            this.gridBand594 = new GridBand();
            this.GView_LDBHYYFXTJB = new AdvBandedGridView();
            this.gridBand271 = new GridBand();
            this.gBandLDBHB5DWND = new GridBand();
            this.gridBand163 = new GridBand();
            this.gridBand176 = new GridBand();
            this.bandedGridColumn43 = new BandedGridColumn();
            this.gridBand164 = new GridBand();
            this.gridBand177 = new GridBand();
            this.bandedGridColumn44 = new BandedGridColumn();
            this.gridBand165 = new GridBand();
            this.gridBand178 = new GridBand();
            this.bandedGridColumn45 = new BandedGridColumn();
            this.gridBand166 = new GridBand();
            this.gridBand175 = new GridBand();
            this.bandedGridColumn46 = new BandedGridColumn();
            this.gridBand167 = new GridBand();
            this.gridBand179 = new GridBand();
            this.bandedGridColumn47 = new BandedGridColumn();
            this.gridBand168 = new GridBand();
            this.gridBand181 = new GridBand();
            this.bandedGridColumn48 = new BandedGridColumn();
            this.gridBand169 = new GridBand();
            this.gridBand182 = new GridBand();
            this.bandedGridColumn49 = new BandedGridColumn();
            this.gridBand171 = new GridBand();
            this.gridBand184 = new GridBand();
            this.bandedGridColumn51 = new BandedGridColumn();
            this.gridBand172 = new GridBand();
            this.gridBand185 = new GridBand();
            this.bandedGridColumn52 = new BandedGridColumn();
            this.gridBand173 = new GridBand();
            this.gridBand186 = new GridBand();
            this.bandedGridColumn53 = new BandedGridColumn();
            this.gridBand174 = new GridBand();
            this.gridBand187 = new GridBand();
            this.bandedGridColumn54 = new BandedGridColumn();
            this.gridBand180 = new GridBand();
            this.gridBand188 = new GridBand();
            this.bandedGridColumn55 = new BandedGridColumn();
            this.GView_GLLDDTZYTJB = new AdvBandedGridView();
            this.gridBand270 = new GridBand();
            this.gBandLDBHB4DWND = new GridBand();
            this.gridBand139 = new GridBand();
            this.gridBand150 = new GridBand();
            this.bandedGridColumn32 = new BandedGridColumn();
            this.gridBand140 = new GridBand();
            this.gridBand151 = new GridBand();
            this.bandedGridColumn33 = new BandedGridColumn();
            this.gridBand141 = new GridBand();
            this.gridBand152 = new GridBand();
            this.bandedGridColumn34 = new BandedGridColumn();
            this.gridBand142 = new GridBand();
            this.gridBand153 = new GridBand();
            this.bandedGridColumn35 = new BandedGridColumn();
            this.gridBand143 = new GridBand();
            this.gridBand154 = new GridBand();
            this.bandedGridColumn36 = new BandedGridColumn();
            this.gridBand144 = new GridBand();
            this.gridBand155 = new GridBand();
            this.bandedGridColumn37 = new BandedGridColumn();
            this.gridBand145 = new GridBand();
            this.gridBand156 = new GridBand();
            this.bandedGridColumn38 = new BandedGridColumn();
            this.gridBand146 = new GridBand();
            this.gridBand157 = new GridBand();
            this.bandedGridColumn39 = new BandedGridColumn();
            this.gridBand147 = new GridBand();
            this.gridBand158 = new GridBand();
            this.bandedGridColumn40 = new BandedGridColumn();
            this.gridBand148 = new GridBand();
            this.gridBand159 = new GridBand();
            this.bandedGridColumn41 = new BandedGridColumn();
            this.gridBand149 = new GridBand();
            this.gridBand160 = new GridBand();
            this.bandedGridColumn42 = new BandedGridColumn();
            this.GView_SPLDMJBGTJB = new AdvBandedGridView();
            this.gridBand269 = new GridBand();
            this.gBandLDBHB3DWND = new GridBand();
            this.gridBand35 = new GridBand();
            this.gridBand41 = new GridBand();
            this.bandedGridColumn18 = new BandedGridColumn();
            this.gridBand42 = new GridBand();
            this.gridBand43 = new GridBand();
            this.bandedGridColumn19 = new BandedGridColumn();
            this.gridBand44 = new GridBand();
            this.gridBand45 = new GridBand();
            this.gridBand46 = new GridBand();
            this.bandedGridColumn20 = new BandedGridColumn();
            this.gridBand47 = new GridBand();
            this.gridBand48 = new GridBand();
            this.gridBand49 = new GridBand();
            this.bandedGridColumn21 = new BandedGridColumn();
            this.gridBand50 = new GridBand();
            this.gridBand51 = new GridBand();
            this.bandedGridColumn22 = new BandedGridColumn();
            this.gridBand53 = new GridBand();
            this.gridBand54 = new GridBand();
            this.bandedGridColumn23 = new BandedGridColumn();
            this.gridBand57 = new GridBand();
            this.gridBand58 = new GridBand();
            this.bandedGridColumn24 = new BandedGridColumn();
            this.gridBand55 = new GridBand();
            this.gridBand56 = new GridBand();
            this.bandedGridColumn25 = new BandedGridColumn();
            this.gridBand103 = new GridBand();
            this.gridBand104 = new GridBand();
            this.gridBand105 = new GridBand();
            this.bandedGridColumn26 = new BandedGridColumn();
            this.gridBand106 = new GridBand();
            this.gridBand107 = new GridBand();
            this.gridBand108 = new GridBand();
            this.bandedGridColumn27 = new BandedGridColumn();
            this.gridBand109 = new GridBand();
            this.gridBand110 = new GridBand();
            this.bandedGridColumn28 = new BandedGridColumn();
            this.gridBand111 = new GridBand();
            this.gridBand112 = new GridBand();
            this.bandedGridColumn29 = new BandedGridColumn();
            this.gridBand88 = new GridBand();
            this.gridBand94 = new GridBand();
            this.bandedGridColumn30 = new BandedGridColumn();
            this.gridBand113 = new GridBand();
            this.gridBand114 = new GridBand();
            this.bandedGridColumn31 = new BandedGridColumn();
            this.repositoryItemCheckEdit7 = new RepositoryItemCheckEdit();
            this.gridBand581 = new GridBand();
            this.barButtonItem4 = new BarButtonItem();
            this.barButtonItem3 = new BarButtonItem();
            this.barButtonItem5 = new BarButtonItem();
            this.barButtonItem6 = new BarButtonItem();
            this.ribbonControl.BeginInit();
            this.ribbonImageCollection.BeginInit();
            this.printRibbonController1.BeginInit();
            this.repositoryItemProgressBar1.BeginInit();
            this.repositoryItemZoomTrackBar1.BeginInit();
            this.repositoryItemCheckEdit2.BeginInit();
            this.repositoryItemCheckEdit3.BeginInit();
            this.repositoryItemCheckEdit4.BeginInit();
            this.repositoryItemCheckEdit5.BeginInit();
            this.repositoryItemCheckEdit6.BeginInit();
            this.repositoryItemCheckEdit9.BeginInit();
            this.repositoryItemCheckEdit10.BeginInit();
            this.repositoryItemCheckEdit11.BeginInit();
            this.repositoryItemCheckEdit12.BeginInit();
            this.repositoryItemCheckEdit14.BeginInit();
            this.repositoryItemCheckEdit15.BeginInit();
            this.repositoryItemCheckEdit16.BeginInit();
            this.ribbonImageCollectionLarge.BeginInit();
            this.repositoryItemCheckEdit1.BeginInit();
            this.repositoryItemButtonEdit1.BeginInit();
            this.repositoryItemCheckEdit8.BeginInit();
            this.repositoryItemProgressBar2.BeginInit();
            this.repositoryItemCheckEdit13.BeginInit();
            this.repositoryItemCheckEdit17.BeginInit();
            this.repositoryItemCheckEdit18.BeginInit();
            this.repositoryItemCheckEdit19.BeginInit();
            this.repositoryItemCheckEdit20.BeginInit();
            this.repositoryItemCheckEdit21.BeginInit();
            this.repositoryItemComboBox1.BeginInit();
            this.repositoryItemPopupContainerEdit1.BeginInit();
            this.repositoryItemCheckedComboBoxEdit1.BeginInit();
            this.repositoryItemButtonEdit2.BeginInit();
            this.navBarControl.BeginInit();
            this.splitContainerControl.BeginInit();
            this.splitContainerControl.SuspendLayout();
            this.gridControl.BeginInit();
            this.GView_ZYBH_B1_GLTDMJBHB.BeginInit();
            this.GView_ZYBH_B2_GLSLLMMJXJBHB.BeginInit();
            this.gridView1.BeginInit();
            this.GView_ZYBH_B5_YCLMJXJBHB.BeginInit();
            this.GView_GYLDMJBGTJB.BeginInit();
            this.GView_GLLDMJBGTJB.BeginInit();
            this.GView_ZYBH_B4_ZYSZMJXJBHB.BeginInit();
            this.GView_ZYBH_B3_GLZMJXJBHB.BeginInit();
            this.GView_LDBHYYFXTJB.BeginInit();
            this.GView_GLLDDTZYTJB.BeginInit();
            this.GView_SPLDMJBGTJB.BeginInit();
            this.repositoryItemCheckEdit7.BeginInit();
            base.SuspendLayout();
            this.ribbonControl.ApplicationButtonText = null;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.ExpandCollapseItem.Name = "";
            this.ribbonControl.Images = this.ribbonImageCollection;
            this.ribbonControl.Items.AddRange(new BarItem[] { 
                this.ribbonControl.ExpandCollapseItem, this.iNew, this.iOpen, this.iClose, this.iFind, this.iSave, this.iSaveAs, this.iExit, this.iHelp, this.iAbout, this.siStatus, this.siInfo, this.alignButtonGroup, this.iBoldFontStyle, this.iItalicFontStyle, this.iUnderlinedFontStyle,
                this.fontStyleButtonGroup, this.iLeftTextAlign, this.iCenterTextAlign, this.iRightTextAlign, this.rgbiSkins, this.barButtonItem1, this.printPreviewBarItem5, this.printPreviewBarItem6, this.printPreviewBarItem7, this.printPreviewBarItem8, this.printPreviewBarItem10, this.printPreviewBarItem11, this.printPreviewBarItem12, this.printPreviewBarItem13, this.printPreviewBarItem14, this.printPreviewBarItem15,
                this.printPreviewBarItem16, this.printPreviewBarItem17, this.printPreviewBarItem18, this.printPreviewBarItem19, this.printPreviewBarItem20, this.printPreviewBarItem21, this.printPreviewBarItem22, this.printPreviewBarItem23, this.printPreviewBarItem26, this.printPreviewBarItem27, this.printPreviewBarItem28, this.printPreviewBarItem29, this.printPreviewBarItem30, this.printPreviewBarItem31, this.printPreviewBarItem32, this.printPreviewBarItem33,
                this.printPreviewBarItem34, this.printPreviewBarItem35, this.printPreviewBarItem36, this.printPreviewBarItem37, this.printPreviewBarItem38, this.printPreviewBarItem39, this.printPreviewBarItem40, this.printPreviewBarItem41, this.printPreviewBarItem42, this.printPreviewBarItem43, this.printPreviewBarItem44, this.printPreviewBarItem45, this.printPreviewBarItem46, this.printPreviewBarItem47, this.printPreviewStaticItem1, this.barStaticItem1,
                this.progressBarEditItem1, this.printPreviewBarItem48, this.barButtonItem2, this.printPreviewStaticItem2, this.zoomTrackBarEditItem1, this.bCHK_LDBG_GLLDMJBGTJB, this.bCHK_LDBG_GYLDMJBGTJB, this.bCHK_LDBG_SPLDMJBGTJB, this.bCHK_LDBG_GLLDDTZYTJB, this.bCHK_LDBG_LDBHYYFXTJB, this.bBTN_LDBG_Print, this.bBTN_LDBG_TJ, this.bCHK_ZYGX_DLBHXBDCB, this.bBTN_ZYGX_TJ, this.bCHK_ZYBH_B1_GLTDMJBHB, this.bCHK_ZYBH_B2_GLSLLMMJXJBHB,
                this.bBTN_Export, this.bCHK_ZYBH_B3_GLZMJXJBHB, this.bCHK_ZYBH_B4_ZYSZMJXJBHB, this.bCHK_ZYBH_B5_YCLMJXJBHB, this.bCHK_ZYBH_B5_GYLDTJB, this.btn_Brow, this.btn_ZYDC_ALL, this.btn_LDBG_Export, this.barButtonItem6
            });
            this.ribbonControl.LargeImages = this.ribbonImageCollectionLarge;
            this.ribbonControl.Location = new Point(0, 0);
            this.ribbonControl.MaxItemId = 0xb3;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.PageHeaderItemLinks.Add(this.iAbout);
            this.ribbonControl.Pages.AddRange(new RibbonPage[] { this.rp_ZYDCTJB, this.rp_LDNDBGDCTJB, this.rp_ZYGXTJB });
            this.ribbonControl.RepositoryItems.AddRange(new RepositoryItem[] { 
                this.repositoryItemCheckEdit1, this.repositoryItemCheckEdit2, this.repositoryItemCheckEdit3, this.repositoryItemCheckEdit4, this.repositoryItemCheckEdit5, this.repositoryItemCheckEdit6, this.repositoryItemButtonEdit1, this.repositoryItemProgressBar1, this.repositoryItemZoomTrackBar1, this.repositoryItemCheckEdit8, this.repositoryItemProgressBar2, this.repositoryItemCheckEdit9, this.repositoryItemCheckEdit10, this.repositoryItemCheckEdit11, this.repositoryItemCheckEdit12, this.repositoryItemCheckEdit13,
                this.repositoryItemCheckEdit14, this.repositoryItemCheckEdit15, this.repositoryItemCheckEdit16, this.repositoryItemCheckEdit17, this.repositoryItemCheckEdit18, this.repositoryItemCheckEdit19, this.repositoryItemCheckEdit20, this.repositoryItemCheckEdit21, this.repositoryItemComboBox1, this.repositoryItemPopupContainerEdit1, this.repositoryItemCheckedComboBoxEdit1, this.repositoryItemButtonEdit2
            });
            this.ribbonControl.RibbonStyle = RibbonControlStyle.Office2010;
            this.ribbonControl.SelectedPage = this.rp_ZYDCTJB;
            this.ribbonControl.Size = new Size(950, 0x95);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.Toolbar.ItemLinks.Add(this.iNew);
            this.ribbonControl.Toolbar.ItemLinks.Add(this.iOpen);
            this.ribbonControl.Toolbar.ItemLinks.Add(this.iSave);
            this.ribbonControl.Toolbar.ItemLinks.Add(this.iSaveAs);
            this.ribbonControl.Toolbar.ItemLinks.Add(this.iHelp);
            this.ribbonControl.ToolbarLocation = RibbonQuickAccessToolbarLocation.Hidden;
            this.ribbonControl.TransparentEditors = true;
            this.ribbonImageCollection.ImageStream = (ImageCollectionStreamer) resources.GetObject("ribbonImageCollection.ImageStream");
            this.ribbonImageCollection.Images.SetKeyName(0, "Ribbon_New_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(1, "Ribbon_Open_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(2, "Ribbon_Close_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(3, "Ribbon_Find_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(4, "Ribbon_Save_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(5, "Ribbon_SaveAs_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(6, "Ribbon_Exit_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(7, "Ribbon_Content_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(8, "Ribbon_Info_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(9, "Ribbon_Bold_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(10, "Ribbon_Italic_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(11, "Ribbon_Underline_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(12, "Ribbon_AlignLeft_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(13, "Ribbon_AlignCenter_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(14, "Ribbon_AlignRight_16x16.png");
            this.iNew.Caption = "New";
            this.iNew.Description = "Creates a new, blank file.";
            this.iNew.Hint = "Creates a new, blank file";
            this.iNew.Id = 1;
            this.iNew.ImageIndex = 0;
            this.iNew.LargeImageIndex = 0;
            this.iNew.Name = "iNew";
            this.iOpen.Caption = "&Open";
            this.iOpen.Description = "Opens a file.";
            this.iOpen.Hint = "Opens a file";
            this.iOpen.Id = 2;
            this.iOpen.ImageIndex = 1;
            this.iOpen.LargeImageIndex = 1;
            this.iOpen.Name = "iOpen";
            this.iOpen.RibbonStyle = RibbonItemStyles.SmallWithoutText | RibbonItemStyles.SmallWithText;
            this.iClose.Caption = "&Close";
            this.iClose.Description = "Closes the active document.";
            this.iClose.Hint = "Closes the active document";
            this.iClose.Id = 3;
            this.iClose.ImageIndex = 2;
            this.iClose.LargeImageIndex = 2;
            this.iClose.Name = "iClose";
            this.iClose.RibbonStyle = RibbonItemStyles.SmallWithoutText | RibbonItemStyles.SmallWithText;
            this.iFind.Caption = "Find";
            this.iFind.Description = "Searches for the specified info.";
            this.iFind.Hint = "Searches for the specified info";
            this.iFind.Id = 15;
            this.iFind.ImageIndex = 3;
            this.iFind.LargeImageIndex = 3;
            this.iFind.Name = "iFind";
            this.iFind.RibbonStyle = RibbonItemStyles.SmallWithoutText | RibbonItemStyles.SmallWithText;
            this.iSave.Caption = "&Save";
            this.iSave.Description = "Saves the active document.";
            this.iSave.Hint = "Saves the active document";
            this.iSave.Id = 0x10;
            this.iSave.ImageIndex = 4;
            this.iSave.LargeImageIndex = 4;
            this.iSave.Name = "iSave";
            this.iSaveAs.Caption = "Save As";
            this.iSaveAs.Description = "Saves the active document in a different location.";
            this.iSaveAs.Hint = "Saves the active document in a different location";
            this.iSaveAs.Id = 0x11;
            this.iSaveAs.ImageIndex = 5;
            this.iSaveAs.LargeImageIndex = 5;
            this.iSaveAs.Name = "iSaveAs";
            this.iExit.Caption = "Exit";
            this.iExit.Description = "Closes this program after prompting you to save unsaved data.";
            this.iExit.Hint = "Closes this program after prompting you to save unsaved data";
            this.iExit.Id = 20;
            this.iExit.ImageIndex = 6;
            this.iExit.LargeImageIndex = 6;
            this.iExit.Name = "iExit";
            this.iHelp.Caption = "Help";
            this.iHelp.Description = "Start the program help system.";
            this.iHelp.Hint = "Start the program help system";
            this.iHelp.Id = 0x16;
            this.iHelp.ImageIndex = 7;
            this.iHelp.LargeImageIndex = 7;
            this.iHelp.Name = "iHelp";
            this.iAbout.Caption = "About";
            this.iAbout.Description = "Displays general program information.";
            this.iAbout.Hint = "Displays general program information";
            this.iAbout.Id = 0x18;
            this.iAbout.ImageIndex = 8;
            this.iAbout.LargeImageIndex = 8;
            this.iAbout.Name = "iAbout";
            this.siStatus.Caption = "Some Status Info";
            this.siStatus.Id = 0x1f;
            this.siStatus.Name = "siStatus";
            this.siStatus.TextAlignment = StringAlignment.Near;
            this.siStatus.Visibility = BarItemVisibility.Never;
            this.siInfo.Caption = "Some Info";
            this.siInfo.Id = 0x20;
            this.siInfo.Name = "siInfo";
            this.siInfo.TextAlignment = StringAlignment.Near;
            this.siInfo.Visibility = BarItemVisibility.Never;
            this.alignButtonGroup.Caption = "Align Commands";
            this.alignButtonGroup.Id = 0x34;
            this.alignButtonGroup.ItemLinks.Add(this.iBoldFontStyle);
            this.alignButtonGroup.ItemLinks.Add(this.iItalicFontStyle);
            this.alignButtonGroup.ItemLinks.Add(this.iUnderlinedFontStyle);
            this.alignButtonGroup.Name = "alignButtonGroup";
            this.iBoldFontStyle.Caption = "Bold";
            this.iBoldFontStyle.Id = 0x35;
            this.iBoldFontStyle.ImageIndex = 9;
            this.iBoldFontStyle.Name = "iBoldFontStyle";
            this.iItalicFontStyle.Caption = "Italic";
            this.iItalicFontStyle.Id = 0x36;
            this.iItalicFontStyle.ImageIndex = 10;
            this.iItalicFontStyle.Name = "iItalicFontStyle";
            this.iUnderlinedFontStyle.Caption = "Underlined";
            this.iUnderlinedFontStyle.Id = 0x37;
            this.iUnderlinedFontStyle.ImageIndex = 11;
            this.iUnderlinedFontStyle.Name = "iUnderlinedFontStyle";
            this.fontStyleButtonGroup.Caption = "Font Style";
            this.fontStyleButtonGroup.Id = 0x38;
            this.fontStyleButtonGroup.ItemLinks.Add(this.iLeftTextAlign);
            this.fontStyleButtonGroup.ItemLinks.Add(this.iCenterTextAlign);
            this.fontStyleButtonGroup.ItemLinks.Add(this.iRightTextAlign);
            this.fontStyleButtonGroup.Name = "fontStyleButtonGroup";
            this.iLeftTextAlign.Caption = "Left";
            this.iLeftTextAlign.Id = 0x39;
            this.iLeftTextAlign.ImageIndex = 12;
            this.iLeftTextAlign.Name = "iLeftTextAlign";
            this.iCenterTextAlign.Caption = "Center";
            this.iCenterTextAlign.Id = 0x3a;
            this.iCenterTextAlign.ImageIndex = 13;
            this.iCenterTextAlign.Name = "iCenterTextAlign";
            this.iRightTextAlign.Caption = "Right";
            this.iRightTextAlign.Id = 0x3b;
            this.iRightTextAlign.ImageIndex = 14;
            this.iRightTextAlign.Name = "iRightTextAlign";
            this.rgbiSkins.Caption = "Skins";
            this.rgbiSkins.Gallery.AllowHoverImages = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaption.Options.UseFont = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaption.Options.UseTextOptions = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaption.TextOptions.HAlignment = HorzAlignment.Center;
            this.rgbiSkins.Gallery.ColumnCount = 4;
            this.rgbiSkins.Gallery.FixedHoverImageSize = false;
            this.rgbiSkins.Gallery.ImageSize = new Size(0x20, 0x11);
            this.rgbiSkins.Gallery.ItemImageLocation = Locations.Top;
            this.rgbiSkins.Gallery.RowCount = 4;
            this.rgbiSkins.Id = 60;
            this.rgbiSkins.Name = "rgbiSkins";
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 0x4b;
            this.barButtonItem1.Name = "barButtonItem1";
            this.printPreviewBarItem5.Caption = "Print";
            this.printPreviewBarItem5.Command = PrintingSystemCommand.Print;
            this.printPreviewBarItem5.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem5.Enabled = false;
            this.printPreviewBarItem5.Id = 80;
            this.printPreviewBarItem5.Name = "printPreviewBarItem5";
            tip.FixedTooltipWidth = true;
            item.Text = "Print (Ctrl+P)";
            item2.LeftIndent = 6;
            item2.Text = "Select a printer, number of copies and other printing options before printing.";
            tip.Items.Add(item);
            tip.Items.Add(item2);
            tip.MaxWidth = 210;
            this.printPreviewBarItem5.SuperTip = tip;
            this.printRibbonController1.PrintControl = null;
            this.printRibbonController1.RibbonControl = this.ribbonControl;
            this.printRibbonController1.RibbonStatusBar = this.ribbonStatusBar;
            this.ribbonStatusBar.ItemLinks.Add(this.siStatus);
            this.ribbonStatusBar.ItemLinks.Add(this.siInfo);
            this.ribbonStatusBar.ItemLinks.Add(this.printPreviewStaticItem1);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem1, true);
            this.ribbonStatusBar.ItemLinks.Add(this.progressBarEditItem1);
            this.ribbonStatusBar.ItemLinks.Add(this.printPreviewBarItem48);
            this.ribbonStatusBar.ItemLinks.Add(this.barButtonItem2);
            this.ribbonStatusBar.ItemLinks.Add(this.printPreviewStaticItem2);
            this.ribbonStatusBar.ItemLinks.Add(this.zoomTrackBarEditItem1);
            this.ribbonStatusBar.Location = new Point(0, 0x207);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new Size(950, 0x1f);
            this.printPreviewStaticItem1.Caption = "Nothing";
            this.printPreviewStaticItem1.Id = 0x7b;
            this.printPreviewStaticItem1.LeftIndent = 1;
            this.printPreviewStaticItem1.Name = "printPreviewStaticItem1";
            this.printPreviewStaticItem1.RightIndent = 1;
            this.printPreviewStaticItem1.TextAlignment = StringAlignment.Near;
            this.printPreviewStaticItem1.Type = "PageOfPages";
            this.printPreviewStaticItem1.Visibility = BarItemVisibility.Never;
            this.barStaticItem1.Id = 0x7c;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = StringAlignment.Near;
            this.barStaticItem1.Visibility = BarItemVisibility.OnlyInRuntime;
            this.progressBarEditItem1.ContextSpecifier = this.printRibbonController1;
            this.progressBarEditItem1.Edit = this.repositoryItemProgressBar1;
            this.progressBarEditItem1.EditHeight = 12;
            this.progressBarEditItem1.Id = 0x7d;
            this.progressBarEditItem1.Name = "progressBarEditItem1";
            this.progressBarEditItem1.Visibility = BarItemVisibility.Never;
            this.progressBarEditItem1.Width = 150;
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            this.repositoryItemProgressBar1.UseParentBackground = true;
            this.printPreviewBarItem48.Caption = "Stop";
            this.printPreviewBarItem48.Command = PrintingSystemCommand.StopPageBuilding;
            this.printPreviewBarItem48.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem48.Enabled = false;
            this.printPreviewBarItem48.Hint = "Stop";
            this.printPreviewBarItem48.Id = 0x7e;
            this.printPreviewBarItem48.Name = "printPreviewBarItem48";
            this.printPreviewBarItem48.Visibility = BarItemVisibility.Never;
            this.barButtonItem2.Alignment = BarItemLinkAlignment.Left;
            this.barButtonItem2.Enabled = false;
            this.barButtonItem2.Id = 0x7f;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.Visibility = BarItemVisibility.OnlyInRuntime;
            this.printPreviewStaticItem2.Alignment = BarItemLinkAlignment.Right;
            this.printPreviewStaticItem2.AutoSize = BarStaticItemSize.None;
            this.printPreviewStaticItem2.Caption = "100%";
            this.printPreviewStaticItem2.Id = 0x80;
            this.printPreviewStaticItem2.Name = "printPreviewStaticItem2";
            this.printPreviewStaticItem2.TextAlignment = StringAlignment.Near;
            this.printPreviewStaticItem2.Type = "ZoomFactorText";
            this.printPreviewStaticItem2.Visibility = BarItemVisibility.Never;
            this.printPreviewStaticItem2.Width = 0x2a;
            this.zoomTrackBarEditItem1.Alignment = BarItemLinkAlignment.Right;
            this.zoomTrackBarEditItem1.ContextSpecifier = this.printRibbonController1;
            this.zoomTrackBarEditItem1.Edit = this.repositoryItemZoomTrackBar1;
            this.zoomTrackBarEditItem1.EditValue = 90;
            this.zoomTrackBarEditItem1.Enabled = false;
            this.zoomTrackBarEditItem1.Id = 0x81;
            this.zoomTrackBarEditItem1.Name = "zoomTrackBarEditItem1";
            this.zoomTrackBarEditItem1.Range = new int[] { 10, 500 };
            this.zoomTrackBarEditItem1.Visibility = BarItemVisibility.Never;
            this.zoomTrackBarEditItem1.Width = 140;
            this.repositoryItemZoomTrackBar1.Alignment = VertAlignment.Center;
            this.repositoryItemZoomTrackBar1.AllowFocused = false;
            this.repositoryItemZoomTrackBar1.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemZoomTrackBar1.Maximum = 180;
            this.repositoryItemZoomTrackBar1.Name = "repositoryItemZoomTrackBar1";
            this.repositoryItemZoomTrackBar1.ScrollThumbStyle = ScrollThumbStyle.ArrowDownRight;
            this.repositoryItemZoomTrackBar1.UseParentBackground = true;
            this.printPreviewBarItem6.Caption = "Quick Print";
            this.printPreviewBarItem6.Command = PrintingSystemCommand.PrintDirect;
            this.printPreviewBarItem6.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem6.Enabled = false;
            this.printPreviewBarItem6.Id = 0x51;
            this.printPreviewBarItem6.Name = "printPreviewBarItem6";
            tip2.FixedTooltipWidth = true;
            item3.Text = "Quick Print";
            item4.LeftIndent = 6;
            item4.Text = "Send the document directly to the default printer without making changes.";
            tip2.Items.Add(item3);
            tip2.Items.Add(item4);
            tip2.MaxWidth = 210;
            this.printPreviewBarItem6.SuperTip = tip2;
            this.printPreviewBarItem7.Caption = "Custom Margins...";
            this.printPreviewBarItem7.Command = PrintingSystemCommand.PageSetup;
            this.printPreviewBarItem7.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem7.Enabled = false;
            this.printPreviewBarItem7.Id = 0x52;
            this.printPreviewBarItem7.Name = "printPreviewBarItem7";
            tip3.FixedTooltipWidth = true;
            item5.Text = "Page Setup";
            item6.LeftIndent = 6;
            item6.Text = "Show the Page Setup dialog.";
            tip3.Items.Add(item5);
            tip3.Items.Add(item6);
            tip3.MaxWidth = 210;
            this.printPreviewBarItem7.SuperTip = tip3;
            this.printPreviewBarItem8.Caption = "Header/Footer";
            this.printPreviewBarItem8.Command = PrintingSystemCommand.EditPageHF;
            this.printPreviewBarItem8.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem8.Enabled = false;
            this.printPreviewBarItem8.Id = 0x53;
            this.printPreviewBarItem8.Name = "printPreviewBarItem8";
            tip4.FixedTooltipWidth = true;
            item7.Text = "Header and Footer";
            item8.LeftIndent = 6;
            item8.Text = "Edit the header and footer of the document.";
            tip4.Items.Add(item7);
            tip4.Items.Add(item8);
            tip4.MaxWidth = 210;
            this.printPreviewBarItem8.SuperTip = tip4;
            this.printPreviewBarItem10.ButtonStyle = BarButtonStyle.Check;
            this.printPreviewBarItem10.Caption = "Pointer";
            this.printPreviewBarItem10.Command = PrintingSystemCommand.Pointer;
            this.printPreviewBarItem10.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem10.Down = true;
            this.printPreviewBarItem10.Enabled = false;
            this.printPreviewBarItem10.GroupIndex = 1;
            this.printPreviewBarItem10.Id = 0x55;
            this.printPreviewBarItem10.Name = "printPreviewBarItem10";
            this.printPreviewBarItem10.RibbonStyle = RibbonItemStyles.SmallWithoutText;
            tip5.FixedTooltipWidth = true;
            item9.Text = "Mouse Pointer";
            item10.LeftIndent = 6;
            item10.Text = "Show the mouse pointer.";
            tip5.Items.Add(item9);
            tip5.Items.Add(item10);
            tip5.MaxWidth = 210;
            this.printPreviewBarItem10.SuperTip = tip5;
            this.printPreviewBarItem11.ButtonStyle = BarButtonStyle.Check;
            this.printPreviewBarItem11.Caption = "Hand Tool";
            this.printPreviewBarItem11.Command = PrintingSystemCommand.HandTool;
            this.printPreviewBarItem11.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem11.Enabled = false;
            this.printPreviewBarItem11.GroupIndex = 1;
            this.printPreviewBarItem11.Id = 0x56;
            this.printPreviewBarItem11.Name = "printPreviewBarItem11";
            this.printPreviewBarItem11.RibbonStyle = RibbonItemStyles.SmallWithoutText;
            tip6.FixedTooltipWidth = true;
            item11.Text = "Hand Tool";
            item12.LeftIndent = 6;
            item12.Text = "Invoke the Hand tool to manually scroll through pages.";
            tip6.Items.Add(item11);
            tip6.Items.Add(item12);
            tip6.MaxWidth = 210;
            this.printPreviewBarItem11.SuperTip = tip6;
            this.printPreviewBarItem12.ButtonStyle = BarButtonStyle.Check;
            this.printPreviewBarItem12.Caption = "Magnifier";
            this.printPreviewBarItem12.Command = PrintingSystemCommand.Magnifier;
            this.printPreviewBarItem12.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem12.Enabled = false;
            this.printPreviewBarItem12.GroupIndex = 1;
            this.printPreviewBarItem12.Id = 0x57;
            this.printPreviewBarItem12.Name = "printPreviewBarItem12";
            this.printPreviewBarItem12.RibbonStyle = RibbonItemStyles.SmallWithoutText;
            tip7.FixedTooltipWidth = true;
            item13.Text = "Magnifier";
            item14.LeftIndent = 6;
            item14.Text = "Invoke the Magnifier tool.\r\n\r\nClicking once on a document zooms it so that a single page becomes entirely visible, while clicking another time zooms it to 100% of the normal size.";
            tip7.Items.Add(item13);
            tip7.Items.Add(item14);
            tip7.MaxWidth = 210;
            this.printPreviewBarItem12.SuperTip = tip7;
            this.printPreviewBarItem13.Caption = "Zoom Out";
            this.printPreviewBarItem13.Command = PrintingSystemCommand.ZoomOut;
            this.printPreviewBarItem13.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem13.Enabled = false;
            this.printPreviewBarItem13.Id = 0x58;
            this.printPreviewBarItem13.Name = "printPreviewBarItem13";
            tip8.FixedTooltipWidth = true;
            item15.Text = "Zoom Out";
            item16.LeftIndent = 6;
            item16.Text = "Zoom out to see more of the page at a reduced size.";
            tip8.Items.Add(item15);
            tip8.Items.Add(item16);
            tip8.MaxWidth = 210;
            this.printPreviewBarItem13.SuperTip = tip8;
            this.printPreviewBarItem14.Caption = "Zoom In";
            this.printPreviewBarItem14.Command = PrintingSystemCommand.ZoomIn;
            this.printPreviewBarItem14.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem14.Enabled = false;
            this.printPreviewBarItem14.Id = 0x59;
            this.printPreviewBarItem14.Name = "printPreviewBarItem14";
            tip9.FixedTooltipWidth = true;
            item17.Text = "Zoom In";
            item18.LeftIndent = 6;
            item18.Text = "Zoom in to get a close-up view of the document.";
            tip9.Items.Add(item17);
            tip9.Items.Add(item18);
            tip9.MaxWidth = 210;
            this.printPreviewBarItem14.SuperTip = tip9;
            this.printPreviewBarItem15.ButtonStyle = BarButtonStyle.DropDown;
            this.printPreviewBarItem15.Caption = "Zoom";
            this.printPreviewBarItem15.Command = PrintingSystemCommand.Zoom;
            this.printPreviewBarItem15.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem15.Enabled = false;
            this.printPreviewBarItem15.Id = 90;
            this.printPreviewBarItem15.Name = "printPreviewBarItem15";
            tip10.FixedTooltipWidth = true;
            item19.Text = "Zoom";
            item20.LeftIndent = 6;
            item20.Text = "Change the zoom level of the document preview.";
            tip10.Items.Add(item19);
            tip10.Items.Add(item20);
            tip10.MaxWidth = 210;
            this.printPreviewBarItem15.SuperTip = tip10;
            this.printPreviewBarItem16.Caption = "First Page";
            this.printPreviewBarItem16.Command = PrintingSystemCommand.ShowFirstPage;
            this.printPreviewBarItem16.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem16.Enabled = false;
            this.printPreviewBarItem16.Id = 0x5b;
            this.printPreviewBarItem16.Name = "printPreviewBarItem16";
            tip11.FixedTooltipWidth = true;
            item21.Text = "First Page (Ctrl+Home)";
            item22.LeftIndent = 6;
            item22.Text = "Navigate to the first page of the document.";
            tip11.Items.Add(item21);
            tip11.Items.Add(item22);
            tip11.MaxWidth = 210;
            this.printPreviewBarItem16.SuperTip = tip11;
            this.printPreviewBarItem17.Caption = "Previous Page";
            this.printPreviewBarItem17.Command = PrintingSystemCommand.ShowPrevPage;
            this.printPreviewBarItem17.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem17.Enabled = false;
            this.printPreviewBarItem17.Id = 0x5c;
            this.printPreviewBarItem17.Name = "printPreviewBarItem17";
            tip12.FixedTooltipWidth = true;
            item23.Text = "Previous Page (PageUp)";
            item24.LeftIndent = 6;
            item24.Text = "Navigate to the previous page of the document.";
            tip12.Items.Add(item23);
            tip12.Items.Add(item24);
            tip12.MaxWidth = 210;
            this.printPreviewBarItem17.SuperTip = tip12;
            this.printPreviewBarItem18.Caption = "Next  Page ";
            this.printPreviewBarItem18.Command = PrintingSystemCommand.ShowNextPage;
            this.printPreviewBarItem18.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem18.Enabled = false;
            this.printPreviewBarItem18.Id = 0x5d;
            this.printPreviewBarItem18.Name = "printPreviewBarItem18";
            tip13.FixedTooltipWidth = true;
            item25.Text = "Next Page (PageDown)";
            item26.LeftIndent = 6;
            item26.Text = "Navigate to the next page of the document.";
            tip13.Items.Add(item25);
            tip13.Items.Add(item26);
            tip13.MaxWidth = 210;
            this.printPreviewBarItem18.SuperTip = tip13;
            this.printPreviewBarItem19.Caption = "Last  Page ";
            this.printPreviewBarItem19.Command = PrintingSystemCommand.ShowLastPage;
            this.printPreviewBarItem19.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem19.Enabled = false;
            this.printPreviewBarItem19.Id = 0x5e;
            this.printPreviewBarItem19.Name = "printPreviewBarItem19";
            tip14.FixedTooltipWidth = true;
            item27.Text = "Last Page (Ctrl+End)";
            item28.LeftIndent = 6;
            item28.Text = "Navigate to the last page of the document.";
            tip14.Items.Add(item27);
            tip14.Items.Add(item28);
            tip14.MaxWidth = 210;
            this.printPreviewBarItem19.SuperTip = tip14;
            this.printPreviewBarItem20.ButtonStyle = BarButtonStyle.DropDown;
            this.printPreviewBarItem20.Caption = "Many Pages";
            this.printPreviewBarItem20.Command = PrintingSystemCommand.MultiplePages;
            this.printPreviewBarItem20.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem20.Enabled = false;
            this.printPreviewBarItem20.Id = 0x5f;
            this.printPreviewBarItem20.Name = "printPreviewBarItem20";
            tip15.FixedTooltipWidth = true;
            item29.Text = "View Many Pages";
            item30.LeftIndent = 6;
            item30.Text = "Choose the page layout to arrange the document pages in preview.";
            tip15.Items.Add(item29);
            tip15.Items.Add(item30);
            tip15.MaxWidth = 210;
            this.printPreviewBarItem20.SuperTip = tip15;
            this.printPreviewBarItem21.ButtonStyle = BarButtonStyle.DropDown;
            this.printPreviewBarItem21.Caption = "Page Color";
            this.printPreviewBarItem21.Command = PrintingSystemCommand.FillBackground;
            this.printPreviewBarItem21.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem21.Enabled = false;
            this.printPreviewBarItem21.Id = 0x60;
            this.printPreviewBarItem21.Name = "printPreviewBarItem21";
            tip16.FixedTooltipWidth = true;
            item31.Text = "Background Color";
            item32.LeftIndent = 6;
            item32.Text = "Choose a color for the background of the document pages.";
            tip16.Items.Add(item31);
            tip16.Items.Add(item32);
            tip16.MaxWidth = 210;
            this.printPreviewBarItem21.SuperTip = tip16;
            this.printPreviewBarItem22.Caption = "Watermark";
            this.printPreviewBarItem22.Command = PrintingSystemCommand.Watermark;
            this.printPreviewBarItem22.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem22.Enabled = false;
            this.printPreviewBarItem22.Id = 0x61;
            this.printPreviewBarItem22.Name = "printPreviewBarItem22";
            tip17.FixedTooltipWidth = true;
            item33.Text = "Watermark";
            item34.LeftIndent = 6;
            item34.Text = "Insert ghosted text or image behind the content of a page.\r\n\r\nThis is often used to indicate that a document is to be treated specially.";
            tip17.Items.Add(item33);
            tip17.Items.Add(item34);
            tip17.MaxWidth = 210;
            this.printPreviewBarItem22.SuperTip = tip17;
            this.printPreviewBarItem23.ButtonStyle = BarButtonStyle.DropDown;
            this.printPreviewBarItem23.Caption = "Export To";
            this.printPreviewBarItem23.Command = PrintingSystemCommand.ExportFile;
            this.printPreviewBarItem23.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem23.Enabled = false;
            this.printPreviewBarItem23.Glyph = (Image) resources.GetObject("printPreviewBarItem23.Glyph");
            this.printPreviewBarItem23.Id = 0x62;
            this.printPreviewBarItem23.LargeGlyph = (Image) resources.GetObject("printPreviewBarItem23.LargeGlyph");
            this.printPreviewBarItem23.Name = "printPreviewBarItem23";
            tip18.FixedTooltipWidth = true;
            item35.Text = "Export To...";
            item36.LeftIndent = 6;
            item36.Text = "Export the current document in one of the available formats, and save it to the file on a disk.";
            tip18.Items.Add(item35);
            tip18.Items.Add(item36);
            tip18.MaxWidth = 210;
            this.printPreviewBarItem23.SuperTip = tip18;
            this.printPreviewBarItem26.ButtonStyle = BarButtonStyle.DropDown;
            this.printPreviewBarItem26.Caption = "Orientation";
            this.printPreviewBarItem26.Command = PrintingSystemCommand.PageOrientation;
            this.printPreviewBarItem26.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem26.Enabled = false;
            this.printPreviewBarItem26.Id = 0x65;
            this.printPreviewBarItem26.Name = "printPreviewBarItem26";
            tip19.FixedTooltipWidth = true;
            item37.Text = "Page Orientation";
            item38.LeftIndent = 6;
            item38.Text = "Switch the pages between portrait and landscape layouts.";
            tip19.Items.Add(item37);
            tip19.Items.Add(item38);
            tip19.MaxWidth = 210;
            this.printPreviewBarItem26.SuperTip = tip19;
            this.printPreviewBarItem27.ButtonStyle = BarButtonStyle.DropDown;
            this.printPreviewBarItem27.Caption = "Size";
            this.printPreviewBarItem27.Command = PrintingSystemCommand.PaperSize;
            this.printPreviewBarItem27.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem27.Enabled = false;
            this.printPreviewBarItem27.Id = 0x66;
            this.printPreviewBarItem27.Name = "printPreviewBarItem27";
            tip20.FixedTooltipWidth = true;
            item39.Text = "Page Size";
            item40.LeftIndent = 6;
            item40.Text = "Choose the paper size of the document.";
            tip20.Items.Add(item39);
            tip20.Items.Add(item40);
            tip20.MaxWidth = 210;
            this.printPreviewBarItem27.SuperTip = tip20;
            this.printPreviewBarItem28.ButtonStyle = BarButtonStyle.DropDown;
            this.printPreviewBarItem28.Caption = "Margins";
            this.printPreviewBarItem28.Command = PrintingSystemCommand.PageMargins;
            this.printPreviewBarItem28.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem28.Enabled = false;
            this.printPreviewBarItem28.Id = 0x67;
            this.printPreviewBarItem28.Name = "printPreviewBarItem28";
            tip21.FixedTooltipWidth = true;
            item41.Text = "Page Margins";
            item42.LeftIndent = 6;
            item42.Text = "Select the margin sizes for the entire document.\r\n\r\nTo apply specific margin sizes to the document, click Custom Margins.";
            tip21.Items.Add(item41);
            tip21.Items.Add(item42);
            tip21.MaxWidth = 210;
            this.printPreviewBarItem28.SuperTip = tip21;
            this.printPreviewBarItem29.Caption = "PDF File";
            this.printPreviewBarItem29.Command = PrintingSystemCommand.SendPdf;
            this.printPreviewBarItem29.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem29.Description = "Adobe Portable Document Format";
            this.printPreviewBarItem29.Enabled = false;
            this.printPreviewBarItem29.Id = 0x68;
            this.printPreviewBarItem29.Name = "printPreviewBarItem29";
            tip22.FixedTooltipWidth = true;
            item43.Text = "E-Mail As PDF";
            item44.LeftIndent = 6;
            item44.Text = "Export the document to PDF and attach it to the e-mail.";
            tip22.Items.Add(item43);
            tip22.Items.Add(item44);
            tip22.MaxWidth = 210;
            this.printPreviewBarItem29.SuperTip = tip22;
            this.printPreviewBarItem30.Caption = "Text File";
            this.printPreviewBarItem30.Command = PrintingSystemCommand.SendTxt;
            this.printPreviewBarItem30.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem30.Description = "Plain Text";
            this.printPreviewBarItem30.Enabled = false;
            this.printPreviewBarItem30.Id = 0x69;
            this.printPreviewBarItem30.Name = "printPreviewBarItem30";
            tip23.FixedTooltipWidth = true;
            item45.Text = "E-Mail As Text";
            item46.LeftIndent = 6;
            item46.Text = "Export the document to Text and attach it to the e-mail.";
            tip23.Items.Add(item45);
            tip23.Items.Add(item46);
            tip23.MaxWidth = 210;
            this.printPreviewBarItem30.SuperTip = tip23;
            this.printPreviewBarItem31.Caption = "CSV File";
            this.printPreviewBarItem31.Command = PrintingSystemCommand.SendCsv;
            this.printPreviewBarItem31.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem31.Description = "Comma-Separated Values Text";
            this.printPreviewBarItem31.Enabled = false;
            this.printPreviewBarItem31.Id = 0x6a;
            this.printPreviewBarItem31.Name = "printPreviewBarItem31";
            tip24.FixedTooltipWidth = true;
            item47.Text = "E-Mail As CSV";
            item48.LeftIndent = 6;
            item48.Text = "Export the document to CSV and attach it to the e-mail.";
            tip24.Items.Add(item47);
            tip24.Items.Add(item48);
            tip24.MaxWidth = 210;
            this.printPreviewBarItem31.SuperTip = tip24;
            this.printPreviewBarItem32.Caption = "MHT File";
            this.printPreviewBarItem32.Command = PrintingSystemCommand.SendMht;
            this.printPreviewBarItem32.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem32.Description = "Single File Web Page";
            this.printPreviewBarItem32.Enabled = false;
            this.printPreviewBarItem32.Id = 0x6b;
            this.printPreviewBarItem32.Name = "printPreviewBarItem32";
            tip25.FixedTooltipWidth = true;
            item49.Text = "E-Mail As MHT";
            item50.LeftIndent = 6;
            item50.Text = "Export the document to MHT and attach it to the e-mail.";
            tip25.Items.Add(item49);
            tip25.Items.Add(item50);
            tip25.MaxWidth = 210;
            this.printPreviewBarItem32.SuperTip = tip25;
            this.printPreviewBarItem33.Caption = "XLS File";
            this.printPreviewBarItem33.Command = PrintingSystemCommand.SendXls;
            this.printPreviewBarItem33.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem33.Description = "Microsoft Excel 2000-2003 Workbook";
            this.printPreviewBarItem33.Enabled = false;
            this.printPreviewBarItem33.Id = 0x6c;
            this.printPreviewBarItem33.Name = "printPreviewBarItem33";
            tip26.FixedTooltipWidth = true;
            item51.Text = "E-Mail As XLS";
            item52.LeftIndent = 6;
            item52.Text = "Export the document to XLS and attach it to the e-mail.";
            tip26.Items.Add(item51);
            tip26.Items.Add(item52);
            tip26.MaxWidth = 210;
            this.printPreviewBarItem33.SuperTip = tip26;
            this.printPreviewBarItem34.Caption = "XLSX File";
            this.printPreviewBarItem34.Command = PrintingSystemCommand.SendXlsx;
            this.printPreviewBarItem34.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem34.Description = "Microsoft Excel 2007 Workbook";
            this.printPreviewBarItem34.Enabled = false;
            this.printPreviewBarItem34.Id = 0x6d;
            this.printPreviewBarItem34.Name = "printPreviewBarItem34";
            tip27.FixedTooltipWidth = true;
            item53.Text = "E-Mail As XLSX";
            item54.LeftIndent = 6;
            item54.Text = "Export the document to XLSX and attach it to the e-mail.";
            tip27.Items.Add(item53);
            tip27.Items.Add(item54);
            tip27.MaxWidth = 210;
            this.printPreviewBarItem34.SuperTip = tip27;
            this.printPreviewBarItem35.Caption = "RTF File";
            this.printPreviewBarItem35.Command = PrintingSystemCommand.SendRtf;
            this.printPreviewBarItem35.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem35.Description = "Rich Text Format";
            this.printPreviewBarItem35.Enabled = false;
            this.printPreviewBarItem35.Id = 110;
            this.printPreviewBarItem35.Name = "printPreviewBarItem35";
            tip28.FixedTooltipWidth = true;
            item55.Text = "E-Mail As RTF";
            item56.LeftIndent = 6;
            item56.Text = "Export the document to RTF and attach it to the e-mail.";
            tip28.Items.Add(item55);
            tip28.Items.Add(item56);
            tip28.MaxWidth = 210;
            this.printPreviewBarItem35.SuperTip = tip28;
            this.printPreviewBarItem36.Caption = "Image File";
            this.printPreviewBarItem36.Command = PrintingSystemCommand.SendGraphic;
            this.printPreviewBarItem36.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem36.Description = "BMP, GIF, JPEG, PNG, TIFF, EMF, WMF";
            this.printPreviewBarItem36.Enabled = false;
            this.printPreviewBarItem36.Id = 0x6f;
            this.printPreviewBarItem36.Name = "printPreviewBarItem36";
            tip29.FixedTooltipWidth = true;
            item57.Text = "E-Mail As Image";
            item58.LeftIndent = 6;
            item58.Text = "Export the document to Image and attach it to the e-mail.";
            tip29.Items.Add(item57);
            tip29.Items.Add(item58);
            tip29.MaxWidth = 210;
            this.printPreviewBarItem36.SuperTip = tip29;
            this.printPreviewBarItem37.Caption = "PDF File";
            this.printPreviewBarItem37.Command = PrintingSystemCommand.ExportPdf;
            this.printPreviewBarItem37.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem37.Description = "Adobe Portable Document Format";
            this.printPreviewBarItem37.Enabled = false;
            this.printPreviewBarItem37.Id = 0x70;
            this.printPreviewBarItem37.Name = "printPreviewBarItem37";
            tip30.FixedTooltipWidth = true;
            item59.Text = "Export to PDF";
            item60.LeftIndent = 6;
            item60.Text = "Export the document to PDF and save it to the file on a disk.";
            tip30.Items.Add(item59);
            tip30.Items.Add(item60);
            tip30.MaxWidth = 210;
            this.printPreviewBarItem37.SuperTip = tip30;
            this.printPreviewBarItem38.Caption = "HTML File";
            this.printPreviewBarItem38.Command = PrintingSystemCommand.ExportHtm;
            this.printPreviewBarItem38.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem38.Description = "Web Page";
            this.printPreviewBarItem38.Enabled = false;
            this.printPreviewBarItem38.Id = 0x71;
            this.printPreviewBarItem38.Name = "printPreviewBarItem38";
            tip31.FixedTooltipWidth = true;
            item61.Text = "Export to HTML";
            item62.LeftIndent = 6;
            item62.Text = "Export the document to HTML and save it to the file on a disk.";
            tip31.Items.Add(item61);
            tip31.Items.Add(item62);
            tip31.MaxWidth = 210;
            this.printPreviewBarItem38.SuperTip = tip31;
            this.printPreviewBarItem39.Caption = "Text File";
            this.printPreviewBarItem39.Command = PrintingSystemCommand.ExportTxt;
            this.printPreviewBarItem39.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem39.Description = "Plain Text";
            this.printPreviewBarItem39.Enabled = false;
            this.printPreviewBarItem39.Id = 0x72;
            this.printPreviewBarItem39.Name = "printPreviewBarItem39";
            tip32.FixedTooltipWidth = true;
            item63.Text = "Export to Text";
            item64.LeftIndent = 6;
            item64.Text = "Export the document to Text and save it to the file on a disk.";
            tip32.Items.Add(item63);
            tip32.Items.Add(item64);
            tip32.MaxWidth = 210;
            this.printPreviewBarItem39.SuperTip = tip32;
            this.printPreviewBarItem40.Caption = "CSV File";
            this.printPreviewBarItem40.Command = PrintingSystemCommand.ExportCsv;
            this.printPreviewBarItem40.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem40.Description = "Comma-Separated Values Text";
            this.printPreviewBarItem40.Enabled = false;
            this.printPreviewBarItem40.Id = 0x73;
            this.printPreviewBarItem40.Name = "printPreviewBarItem40";
            tip33.FixedTooltipWidth = true;
            item65.Text = "Export to CSV";
            item66.LeftIndent = 6;
            item66.Text = "Export the document to CSV and save it to the file on a disk.";
            tip33.Items.Add(item65);
            tip33.Items.Add(item66);
            tip33.MaxWidth = 210;
            this.printPreviewBarItem40.SuperTip = tip33;
            this.printPreviewBarItem41.Caption = "MHT File";
            this.printPreviewBarItem41.Command = PrintingSystemCommand.ExportMht;
            this.printPreviewBarItem41.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem41.Description = "Single File Web Page";
            this.printPreviewBarItem41.Enabled = false;
            this.printPreviewBarItem41.Id = 0x74;
            this.printPreviewBarItem41.Name = "printPreviewBarItem41";
            tip34.FixedTooltipWidth = true;
            item67.Text = "Export to MHT";
            item68.LeftIndent = 6;
            item68.Text = "Export the document to MHT and save it to the file on a disk.";
            tip34.Items.Add(item67);
            tip34.Items.Add(item68);
            tip34.MaxWidth = 210;
            this.printPreviewBarItem41.SuperTip = tip34;
            this.printPreviewBarItem42.Caption = "XLS File";
            this.printPreviewBarItem42.Command = PrintingSystemCommand.ExportXls;
            this.printPreviewBarItem42.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem42.Description = "Microsoft Excel 2000-2003 Workbook";
            this.printPreviewBarItem42.Enabled = false;
            this.printPreviewBarItem42.Id = 0x75;
            this.printPreviewBarItem42.Name = "printPreviewBarItem42";
            tip35.FixedTooltipWidth = true;
            item69.Text = "Export to XLS";
            item70.LeftIndent = 6;
            item70.Text = "Export the document to XLS and save it to the file on a disk.";
            tip35.Items.Add(item69);
            tip35.Items.Add(item70);
            tip35.MaxWidth = 210;
            this.printPreviewBarItem42.SuperTip = tip35;
            this.printPreviewBarItem43.Caption = "XLSX File";
            this.printPreviewBarItem43.Command = PrintingSystemCommand.ExportXlsx;
            this.printPreviewBarItem43.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem43.Description = "Microsoft Excel 2007 Workbook";
            this.printPreviewBarItem43.Enabled = false;
            this.printPreviewBarItem43.Id = 0x76;
            this.printPreviewBarItem43.Name = "printPreviewBarItem43";
            tip36.FixedTooltipWidth = true;
            item71.Text = "Export to XLSX";
            item72.LeftIndent = 6;
            item72.Text = "Export the document to XLSX and save it to the file on a disk.";
            tip36.Items.Add(item71);
            tip36.Items.Add(item72);
            tip36.MaxWidth = 210;
            this.printPreviewBarItem43.SuperTip = tip36;
            this.printPreviewBarItem44.Caption = "RTF File";
            this.printPreviewBarItem44.Command = PrintingSystemCommand.ExportRtf;
            this.printPreviewBarItem44.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem44.Description = "Rich Text Format";
            this.printPreviewBarItem44.Enabled = false;
            this.printPreviewBarItem44.Id = 0x77;
            this.printPreviewBarItem44.Name = "printPreviewBarItem44";
            tip37.FixedTooltipWidth = true;
            item73.Text = "Export to RTF";
            item74.LeftIndent = 6;
            item74.Text = "Export the document to RTF and save it to the file on a disk.";
            tip37.Items.Add(item73);
            tip37.Items.Add(item74);
            tip37.MaxWidth = 210;
            this.printPreviewBarItem44.SuperTip = tip37;
            this.printPreviewBarItem45.Caption = "Image File";
            this.printPreviewBarItem45.Command = PrintingSystemCommand.ExportGraphic;
            this.printPreviewBarItem45.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem45.Description = "BMP, GIF, JPEG, PNG, TIFF, EMF, WMF";
            this.printPreviewBarItem45.Enabled = false;
            this.printPreviewBarItem45.Id = 120;
            this.printPreviewBarItem45.Name = "printPreviewBarItem45";
            tip38.FixedTooltipWidth = true;
            item75.Text = "Export to Image";
            item76.LeftIndent = 6;
            item76.Text = "Export the document to Image and save it to the file on a disk.";
            tip38.Items.Add(item75);
            tip38.Items.Add(item76);
            tip38.MaxWidth = 210;
            this.printPreviewBarItem45.SuperTip = tip38;
            this.printPreviewBarItem46.Caption = "Open";
            this.printPreviewBarItem46.Command = PrintingSystemCommand.Open;
            this.printPreviewBarItem46.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem46.Enabled = false;
            this.printPreviewBarItem46.Id = 0x79;
            this.printPreviewBarItem46.Name = "printPreviewBarItem46";
            tip39.FixedTooltipWidth = true;
            item77.Text = "Open (Ctrl + O)";
            item78.LeftIndent = 6;
            item78.Text = "Open a document.";
            tip39.Items.Add(item77);
            tip39.Items.Add(item78);
            tip39.MaxWidth = 210;
            this.printPreviewBarItem46.SuperTip = tip39;
            this.printPreviewBarItem47.Caption = "Save";
            this.printPreviewBarItem47.Command = PrintingSystemCommand.Save;
            this.printPreviewBarItem47.ContextSpecifier = this.printRibbonController1;
            this.printPreviewBarItem47.Enabled = false;
            this.printPreviewBarItem47.Id = 0x7a;
            this.printPreviewBarItem47.Name = "printPreviewBarItem47";
            tip40.FixedTooltipWidth = true;
            item79.Text = "Save (Ctrl + S)";
            item80.LeftIndent = 6;
            item80.Text = "Save the document.";
            tip40.Items.Add(item79);
            tip40.Items.Add(item80);
            tip40.MaxWidth = 210;
            this.printPreviewBarItem47.SuperTip = tip40;
            this.bCHK_LDBG_GLLDMJBGTJB.Caption = "表1 各类林地面积变更统计表";
            this.bCHK_LDBG_GLLDMJBGTJB.Edit = this.repositoryItemCheckEdit2;
            this.bCHK_LDBG_GLLDMJBGTJB.EditValue = false;
            this.bCHK_LDBG_GLLDMJBGTJB.Id = 0x41;
            this.bCHK_LDBG_GLLDMJBGTJB.Name = "bCHK_LDBG_GLLDMJBGTJB";
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.UseParentBackground = true;
            this.bCHK_LDBG_GYLDMJBGTJB.Caption = "表2 公益林地面积变更统计表";
            this.bCHK_LDBG_GYLDMJBGTJB.Edit = this.repositoryItemCheckEdit3;
            this.bCHK_LDBG_GYLDMJBGTJB.EditValue = false;
            this.bCHK_LDBG_GYLDMJBGTJB.Id = 0x42;
            this.bCHK_LDBG_GYLDMJBGTJB.Name = "bCHK_LDBG_GYLDMJBGTJB";
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            this.repositoryItemCheckEdit3.UseParentBackground = true;
            this.bCHK_LDBG_SPLDMJBGTJB.Caption = "表3 商品林地面积变更统计表";
            this.bCHK_LDBG_SPLDMJBGTJB.Edit = this.repositoryItemCheckEdit4;
            this.bCHK_LDBG_SPLDMJBGTJB.EditValue = false;
            this.bCHK_LDBG_SPLDMJBGTJB.Id = 0x43;
            this.bCHK_LDBG_SPLDMJBGTJB.Name = "bCHK_LDBG_SPLDMJBGTJB";
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            this.repositoryItemCheckEdit4.UseParentBackground = true;
            this.bCHK_LDBG_GLLDDTZYTJB.Caption = "表4 各类林地动态转移统计表";
            this.bCHK_LDBG_GLLDDTZYTJB.Edit = this.repositoryItemCheckEdit5;
            this.bCHK_LDBG_GLLDDTZYTJB.EditValue = false;
            this.bCHK_LDBG_GLLDDTZYTJB.Id = 0x44;
            this.bCHK_LDBG_GLLDDTZYTJB.Name = "bCHK_LDBG_GLLDDTZYTJB";
            this.repositoryItemCheckEdit5.AutoHeight = false;
            this.repositoryItemCheckEdit5.Name = "repositoryItemCheckEdit5";
            this.repositoryItemCheckEdit5.UseParentBackground = true;
            this.bCHK_LDBG_LDBHYYFXTJB.Caption = "表5 林地变化原因分析统计表";
            this.bCHK_LDBG_LDBHYYFXTJB.Edit = this.repositoryItemCheckEdit6;
            this.bCHK_LDBG_LDBHYYFXTJB.EditValue = false;
            this.bCHK_LDBG_LDBHYYFXTJB.Id = 0x45;
            this.bCHK_LDBG_LDBHYYFXTJB.Name = "bCHK_LDBG_LDBHYYFXTJB";
            this.repositoryItemCheckEdit6.AutoHeight = false;
            this.repositoryItemCheckEdit6.Name = "repositoryItemCheckEdit6";
            this.repositoryItemCheckEdit6.UseParentBackground = true;
            this.bBTN_LDBG_Print.Caption = "打印设置";
            this.bBTN_LDBG_Print.Id = 0x83;
            this.bBTN_LDBG_Print.Name = "bBTN_LDBG_Print";
            this.bBTN_LDBG_Print.Visibility = BarItemVisibility.Never;
            this.bBTN_LDBG_Print.ItemClick += new ItemClickEventHandler(this.bBtnPrint_ItemClick);
            this.bBTN_LDBG_TJ.Caption = "浏 览";
            this.bBTN_LDBG_TJ.Id = 0x84;
            this.bBTN_LDBG_TJ.LargeImageIndex = 3;
            this.bBTN_LDBG_TJ.Name = "bBTN_LDBG_TJ";
            this.bBTN_LDBG_TJ.ItemClick += new ItemClickEventHandler(this.bBtnTJ_ItemClick);
            this.bCHK_ZYGX_DLBHXBDCB.Caption = "表1 **县**年度地类变化小班调查表";
            this.bCHK_ZYGX_DLBHXBDCB.Edit = this.repositoryItemCheckEdit9;
            this.bCHK_ZYGX_DLBHXBDCB.Id = 0x8a;
            this.bCHK_ZYGX_DLBHXBDCB.Name = "bCHK_ZYGX_DLBHXBDCB";
            this.repositoryItemCheckEdit9.AutoHeight = false;
            this.repositoryItemCheckEdit9.Name = "repositoryItemCheckEdit9";
            this.repositoryItemCheckEdit9.UseParentBackground = true;
            this.bBTN_ZYGX_TJ.Caption = "统计";
            this.bBTN_ZYGX_TJ.Id = 0x8b;
            this.bBTN_ZYGX_TJ.LargeImageIndex = 9;
            this.bBTN_ZYGX_TJ.Name = "bBTN_ZYGX_TJ";
            this.bBTN_ZYGX_TJ.ItemClick += new ItemClickEventHandler(this.bBtn_ZYGX_TJ_ItemClick);
            this.bCHK_ZYBH_B1_GLTDMJBHB.Caption = "表1    各类土地面积变化情况表               ";
            this.bCHK_ZYBH_B1_GLTDMJBHB.Edit = this.repositoryItemCheckEdit10;
            this.bCHK_ZYBH_B1_GLTDMJBHB.EditValue = false;
            this.bCHK_ZYBH_B1_GLTDMJBHB.Id = 0x8e;
            this.bCHK_ZYBH_B1_GLTDMJBHB.Name = "bCHK_ZYBH_B1_GLTDMJBHB";
            this.repositoryItemCheckEdit10.AutoHeight = false;
            this.repositoryItemCheckEdit10.Name = "repositoryItemCheckEdit10";
            this.repositoryItemCheckEdit10.UseParentBackground = true;
            this.bCHK_ZYBH_B2_GLSLLMMJXJBHB.Caption = "表2    各类森林、林木面积蓄积变化情况表";
            this.bCHK_ZYBH_B2_GLSLLMMJXJBHB.Edit = this.repositoryItemCheckEdit11;
            this.bCHK_ZYBH_B2_GLSLLMMJXJBHB.EditValue = false;
            this.bCHK_ZYBH_B2_GLSLLMMJXJBHB.Id = 0x90;
            this.bCHK_ZYBH_B2_GLSLLMMJXJBHB.Name = "bCHK_ZYBH_B2_GLSLLMMJXJBHB";
            this.repositoryItemCheckEdit11.AutoHeight = false;
            this.repositoryItemCheckEdit11.Name = "repositoryItemCheckEdit11";
            this.repositoryItemCheckEdit11.UseParentBackground = true;
            this.bBTN_Export.Caption = "导 出";
            this.bBTN_Export.Id = 0x8f;
            this.bBTN_Export.LargeImageIndex = 9;
            this.bBTN_Export.Name = "bBTN_Export";
            this.bBTN_Export.ItemClick += new ItemClickEventHandler(this.bBTN_ZYDC_TJ_ItemClick);
            this.bCHK_ZYBH_B3_GLZMJXJBHB.Caption = "表3    各林种面积蓄积变化情况表            ";
            this.bCHK_ZYBH_B3_GLZMJXJBHB.Edit = this.repositoryItemCheckEdit12;
            this.bCHK_ZYBH_B3_GLZMJXJBHB.EditValue = false;
            this.bCHK_ZYBH_B3_GLZMJXJBHB.Id = 0x91;
            this.bCHK_ZYBH_B3_GLZMJXJBHB.Name = "bCHK_ZYBH_B3_GLZMJXJBHB";
            this.repositoryItemCheckEdit12.AutoHeight = false;
            this.repositoryItemCheckEdit12.Name = "repositoryItemCheckEdit12";
            this.repositoryItemCheckEdit12.UseParentBackground = true;
            this.bCHK_ZYBH_B4_ZYSZMJXJBHB.Caption = "表4    各主要树种面积蓄积变化情况表";
            this.bCHK_ZYBH_B4_ZYSZMJXJBHB.Edit = this.repositoryItemCheckEdit14;
            this.bCHK_ZYBH_B4_ZYSZMJXJBHB.EditValue = false;
            this.bCHK_ZYBH_B4_ZYSZMJXJBHB.Id = 0x93;
            this.bCHK_ZYBH_B4_ZYSZMJXJBHB.Name = "bCHK_ZYBH_B4_ZYSZMJXJBHB";
            this.repositoryItemCheckEdit14.AutoHeight = false;
            this.repositoryItemCheckEdit14.Name = "repositoryItemCheckEdit14";
            this.repositoryItemCheckEdit14.UseParentBackground = true;
            this.bCHK_ZYBH_B5_YCLMJXJBHB.Caption = "表5    用材林面积蓄积变化情况表      ";
            this.bCHK_ZYBH_B5_YCLMJXJBHB.Edit = this.repositoryItemCheckEdit15;
            this.bCHK_ZYBH_B5_YCLMJXJBHB.EditValue = false;
            this.bCHK_ZYBH_B5_YCLMJXJBHB.Id = 0x94;
            this.bCHK_ZYBH_B5_YCLMJXJBHB.Name = "bCHK_ZYBH_B5_YCLMJXJBHB";
            this.repositoryItemCheckEdit15.AutoHeight = false;
            this.repositoryItemCheckEdit15.Name = "repositoryItemCheckEdit15";
            this.repositoryItemCheckEdit15.UseParentBackground = true;
            this.bCHK_ZYBH_B5_GYLDTJB.Caption = "表5    公益林(地)统计表";
            this.bCHK_ZYBH_B5_GYLDTJB.Edit = this.repositoryItemCheckEdit16;
            this.bCHK_ZYBH_B5_GYLDTJB.EditValue = false;
            this.bCHK_ZYBH_B5_GYLDTJB.Id = 0x95;
            this.bCHK_ZYBH_B5_GYLDTJB.Name = "bCHK_ZYBH_B5_GYLDTJB";
            this.repositoryItemCheckEdit16.AutoHeight = false;
            this.repositoryItemCheckEdit16.Name = "repositoryItemCheckEdit16";
            this.repositoryItemCheckEdit16.UseParentBackground = true;
            this.btn_Brow.Caption = "浏 览";
            this.btn_Brow.Id = 0xad;
            this.btn_Brow.LargeImageIndex = 3;
            this.btn_Brow.Name = "btn_Brow";
            this.btn_Brow.ItemClick += new ItemClickEventHandler(this.btn_Brow_ItemClick);
            this.btn_ZYDC_ALL.Caption = "森林资源调查表输出";
            this.btn_ZYDC_ALL.Id = 0xae;
            this.btn_ZYDC_ALL.LargeImageIndex = 7;
            this.btn_ZYDC_ALL.Name = "btn_ZYDC_ALL";
            this.btn_ZYDC_ALL.ItemClick += new ItemClickEventHandler(this.btn_ZYDC_ALL_ItemClick);
            this.btn_LDBG_Export.Caption = "导 出";
            this.btn_LDBG_Export.Id = 0xb0;
            this.btn_LDBG_Export.LargeImageIndex = 9;
            this.btn_LDBG_Export.Name = "btn_LDBG_Export";
            this.btn_LDBG_Export.ItemClick += new ItemClickEventHandler(this.btn_LDBG_Export_ItemClick);
            this.ribbonImageCollectionLarge.ImageSize = new Size(0x20, 0x20);
            this.ribbonImageCollectionLarge.ImageStream = (ImageCollectionStreamer) resources.GetObject("ribbonImageCollectionLarge.ImageStream");
            this.ribbonImageCollectionLarge.Images.SetKeyName(0, "Ribbon_New_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(1, "Ribbon_Open_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(2, "Ribbon_Close_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(3, "Ribbon_Find_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(4, "Ribbon_Save_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(5, "Ribbon_SaveAs_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(6, "Ribbon_Exit_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(7, "Ribbon_Content_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(8, "Ribbon_Info_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(9, "HugeAmountRecords.Icon.png");
            this.rp_ZYDCTJB.Groups.AddRange(new RibbonPageGroup[] { this.ribbonPageGroup5, this.ribbonPageGroup6 });
            this.rp_ZYDCTJB.Name = "rp_ZYDCTJB";
            this.rp_ZYDCTJB.Text = "森林资源变化情况表";
            this.ribbonPageGroup5.ItemLinks.Add(this.bCHK_ZYBH_B1_GLTDMJBHB);
            this.ribbonPageGroup5.ItemLinks.Add(this.bCHK_ZYBH_B2_GLSLLMMJXJBHB);
            this.ribbonPageGroup5.ItemLinks.Add(this.bCHK_ZYBH_B3_GLZMJXJBHB);
            this.ribbonPageGroup5.ItemLinks.Add(this.bCHK_ZYBH_B4_ZYSZMJXJBHB);
            this.ribbonPageGroup5.ItemLinks.Add(this.bCHK_ZYBH_B5_YCLMJXJBHB);
            this.ribbonPageGroup5.ItemLinks.Add(this.btn_Brow);
            this.ribbonPageGroup5.ItemLinks.Add(this.bBTN_Export);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "森林资源变化情况表";
            this.ribbonPageGroup6.ItemLinks.Add(this.btn_ZYDC_ALL);
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem6);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.rp_LDNDBGDCTJB.Groups.AddRange(new RibbonPageGroup[] { this.ribbonPageGroup1, this.ribbonPageGroup2 });
            this.rp_LDNDBGDCTJB.Name = "rp_LDNDBGDCTJB";
            this.rp_LDNDBGDCTJB.Text = "林地年度变更调查统计表";
            this.ribbonPageGroup1.ItemLinks.Add(this.bCHK_LDBG_GLLDMJBGTJB);
            this.ribbonPageGroup1.ItemLinks.Add(this.bCHK_LDBG_GYLDMJBGTJB);
            this.ribbonPageGroup1.ItemLinks.Add(this.bCHK_LDBG_SPLDMJBGTJB);
            this.ribbonPageGroup1.ItemLinks.Add(this.bCHK_LDBG_GLLDDTZYTJB);
            this.ribbonPageGroup1.ItemLinks.Add(this.bCHK_LDBG_LDBHYYFXTJB);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "林地年度变更调查统计表";
            this.ribbonPageGroup2.ItemLinks.Add(this.bBTN_LDBG_TJ);
            this.ribbonPageGroup2.ItemLinks.Add(this.btn_LDBG_Export);
            this.ribbonPageGroup2.ItemLinks.Add(this.bBTN_LDBG_Print);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.rp_ZYGXTJB.Groups.AddRange(new RibbonPageGroup[] { this.ribbonPageGroup3, this.ribbonPageGroup4 });
            this.rp_ZYGXTJB.Name = "rp_ZYGXTJB";
            this.rp_ZYGXTJB.Text = "资源更新统计表";
            this.rp_ZYGXTJB.Visible = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.bCHK_ZYGX_DLBHXBDCB);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup4.ItemLinks.Add(this.bBTN_ZYGX_TJ);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.CheckStyle = CheckStyles.Style4;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemCheckEdit8.AutoHeight = false;
            this.repositoryItemCheckEdit8.Name = "repositoryItemCheckEdit8";
            this.repositoryItemCheckEdit8.UseParentBackground = true;
            this.repositoryItemProgressBar2.Name = "repositoryItemProgressBar2";
            this.repositoryItemProgressBar2.UseParentBackground = true;
            this.repositoryItemCheckEdit13.AutoHeight = false;
            this.repositoryItemCheckEdit13.Name = "repositoryItemCheckEdit13";
            this.repositoryItemCheckEdit13.UseParentBackground = true;
            this.repositoryItemCheckEdit17.AutoHeight = false;
            this.repositoryItemCheckEdit17.Name = "repositoryItemCheckEdit17";
            this.repositoryItemCheckEdit17.UseParentBackground = true;
            this.repositoryItemCheckEdit18.AutoHeight = false;
            this.repositoryItemCheckEdit18.Name = "repositoryItemCheckEdit18";
            this.repositoryItemCheckEdit18.UseParentBackground = true;
            this.repositoryItemCheckEdit19.AutoHeight = false;
            this.repositoryItemCheckEdit19.Name = "repositoryItemCheckEdit19";
            this.repositoryItemCheckEdit19.UseParentBackground = true;
            this.repositoryItemCheckEdit20.AutoHeight = false;
            this.repositoryItemCheckEdit20.Name = "repositoryItemCheckEdit20";
            this.repositoryItemCheckEdit20.UseParentBackground = true;
            this.repositoryItemCheckEdit21.AutoHeight = false;
            this.repositoryItemCheckEdit21.Name = "repositoryItemCheckEdit21";
            this.repositoryItemCheckEdit21.UseParentBackground = true;
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.UseParentBackground = true;
            this.repositoryItemPopupContainerEdit1.AutoHeight = false;
            this.repositoryItemPopupContainerEdit1.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repositoryItemPopupContainerEdit1.Name = "repositoryItemPopupContainerEdit1";
            this.repositoryItemPopupContainerEdit1.UseParentBackground = true;
            this.repositoryItemCheckedComboBoxEdit1.AutoHeight = false;
            this.repositoryItemCheckedComboBoxEdit1.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repositoryItemCheckedComboBoxEdit1.Name = "repositoryItemCheckedComboBoxEdit1";
            this.repositoryItemCheckedComboBoxEdit1.UseParentBackground = true;
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.UseParentBackground = true;
            this.navBarControl.ActiveGroup = this.navBarGroup_0;
            this.navBarControl.AllowSelectedLink = true;
            this.navBarControl.Dock = DockStyle.Fill;
            this.navBarControl.Groups.AddRange(new NavBarGroup[] { this.navBarGroup_0 });
            this.navBarControl.Items.AddRange(new NavBarItem[] { this.navBarItem_GLLDMJBGTJB, this.navBarItem_GYLDMJBGTJB, this.navBarItem_SPLDMJBGTJB, this.navBarItem_GLLDDTZYTJB, this.navBarItem_LDBHYYFXTJB, this.navBarItem_ZYGX_DLBHXBDCB, this.navBarItem_ZYBH_B1_GLTDMJBHB, this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB, this.navBarItem_ZYBH_B3_GLZMJXJBHB, this.navBarItem_ZYBH_B2_GLSLLMMJXJTJB2, this.navBarItem_ZYBH_B4_ZYSZMJXJBHB, this.navBarItem_ZYBH_B5_YCLMJXJBHB });
            this.navBarControl.LargeImages = this.navbarImageListLarge;
            this.navBarControl.Location = new Point(0, 0);
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsNavPane.ExpandedWidth = 350;
            this.navBarControl.PaintStyleKind = NavBarViewKind.NavigationPane;
            this.navBarControl.Size = new Size(0x10c, 0x166);
            this.navBarControl.SmallImages = this.ribbonImageCollection;
            this.navBarControl.StoreDefaultPaintStyleName = true;
            this.navBarControl.TabIndex = 1;
            this.navBarControl.Text = "navBarControl1";
            this.navBarGroup_0.Caption = "统计表";
            this.navBarGroup_0.Expanded = true;
            this.navBarGroup_0.ItemLinks.AddRange(new NavBarItemLink[] { new NavBarItemLink(this.navBarItem_GLLDMJBGTJB), new NavBarItemLink(this.navBarItem_GYLDMJBGTJB), new NavBarItemLink(this.navBarItem_SPLDMJBGTJB), new NavBarItemLink(this.navBarItem_GLLDDTZYTJB), new NavBarItemLink(this.navBarItem_LDBHYYFXTJB), new NavBarItemLink(this.navBarItem_ZYGX_DLBHXBDCB), new NavBarItemLink(this.navBarItem_ZYBH_B1_GLTDMJBHB), new NavBarItemLink(this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB), new NavBarItemLink(this.navBarItem_ZYBH_B3_GLZMJXJBHB), new NavBarItemLink(this.navBarItem_ZYBH_B2_GLSLLMMJXJTJB2), new NavBarItemLink(this.navBarItem_ZYBH_B4_ZYSZMJXJBHB), new NavBarItemLink(this.navBarItem_ZYBH_B5_YCLMJXJBHB) });
            this.navBarGroup_0.Name = "统计表";
            this.navBarGroup_0.SelectedLinkIndex = 0;
            this.navBarGroup_0.SmallImageIndex = 7;
            this.navBarItem_GLLDMJBGTJB.Caption = "表1 各类林地面积变更统计表";
            this.navBarItem_GLLDMJBGTJB.Name = "navBarItem_GLLDMJBGTJB";
            this.navBarItem_GLLDMJBGTJB.Visible = false;
            this.navBarItem_GLLDMJBGTJB.LinkClicked += new NavBarLinkEventHandler(this.navBarItem_GLLDMJBGTJB_LinkClicked);
            this.navBarItem_GYLDMJBGTJB.Caption = "表2 公益林地面积变更统计表";
            this.navBarItem_GYLDMJBGTJB.Name = "navBarItem_GYLDMJBGTJB";
            this.navBarItem_GYLDMJBGTJB.Visible = false;
            this.navBarItem_GYLDMJBGTJB.LinkClicked += new NavBarLinkEventHandler(this.navBarItem_GYLDMJBGTJB_LinkClicked);
            this.navBarItem_SPLDMJBGTJB.Caption = "表3 商品林地面积变更统计表";
            this.navBarItem_SPLDMJBGTJB.Name = "navBarItem_SPLDMJBGTJB";
            this.navBarItem_SPLDMJBGTJB.Visible = false;
            this.navBarItem_SPLDMJBGTJB.LinkClicked += new NavBarLinkEventHandler(this.navBarItem_SPLDMJBGTJB_LinkClicked);
            this.navBarItem_GLLDDTZYTJB.Caption = "表4 各类林地动态转移统计表";
            this.navBarItem_GLLDDTZYTJB.Name = "navBarItem_GLLDDTZYTJB";
            this.navBarItem_GLLDDTZYTJB.Visible = false;
            this.navBarItem_GLLDDTZYTJB.LinkClicked += new NavBarLinkEventHandler(this.navBarItem_GLLDDTZYTJB_LinkClicked);
            this.navBarItem_LDBHYYFXTJB.Caption = "表5 林地变化原因分析统计表";
            this.navBarItem_LDBHYYFXTJB.Name = "navBarItem_LDBHYYFXTJB";
            this.navBarItem_LDBHYYFXTJB.Visible = false;
            this.navBarItem_LDBHYYFXTJB.LinkClicked += new NavBarLinkEventHandler(this.navBarItem_LDBHYYFXTJB_LinkClicked);
            this.navBarItem_ZYGX_DLBHXBDCB.Caption = "年度地类变化小班调查表";
            this.navBarItem_ZYGX_DLBHXBDCB.Name = "navBarItem_ZYGX_DLBHXBDCB";
            this.navBarItem_ZYGX_DLBHXBDCB.Visible = false;
            this.navBarItem_ZYBH_B1_GLTDMJBHB.Caption = "表1 各类土地面积变化情况表";
            this.navBarItem_ZYBH_B1_GLTDMJBHB.Name = "navBarItem_ZYBH_B1_GLTDMJBHB";
            this.navBarItem_ZYBH_B1_GLTDMJBHB.Visible = false;
            this.navBarItem_ZYBH_B1_GLTDMJBHB.LinkClicked += new NavBarLinkEventHandler(this.navBarItem_ZYBH_B1_GLTDMJBHB_LinkClicked);
            this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB.Caption = "表2 各类森林、林木面积蓄积变化情况表";
            this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB.Name = "navBarItem_ZYBH_B2_GLSLLMMJXJBHB";
            this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB.Visible = false;
            this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB.LinkClicked += new NavBarLinkEventHandler(this.navBarItem_ZYBH_B2_GLSLLMMJXJBHB_LinkClicked);
            this.navBarItem_ZYBH_B3_GLZMJXJBHB.Caption = "表3 各林种面积蓄积变化情况表";
            this.navBarItem_ZYBH_B3_GLZMJXJBHB.Name = "navBarItem_ZYBH_B3_GLZMJXJBHB";
            this.navBarItem_ZYBH_B3_GLZMJXJBHB.Visible = false;
            this.navBarItem_ZYBH_B3_GLZMJXJBHB.LinkClicked += new NavBarLinkEventHandler(this.navBarItem_ZYBH_B3_GLZMJXJBHB_LinkClicked);
            this.navBarItem_ZYBH_B2_GLSLLMMJXJTJB2.Caption = "表2-1 各类森林、林木面积蓄积统计表(2)";
            this.navBarItem_ZYBH_B2_GLSLLMMJXJTJB2.Name = "navBarItem_ZYBH_B2_GLSLLMMJXJTJB2";
            this.navBarItem_ZYBH_B2_GLSLLMMJXJTJB2.Visible = false;
            this.navBarItem_ZYBH_B4_ZYSZMJXJBHB.Caption = "表4 各主要树种面积蓄积变化情况表";
            this.navBarItem_ZYBH_B4_ZYSZMJXJBHB.Name = "navBarItem_ZYBH_B4_ZYSZMJXJBHB";
            this.navBarItem_ZYBH_B4_ZYSZMJXJBHB.Visible = false;
            this.navBarItem_ZYBH_B4_ZYSZMJXJBHB.LinkClicked += new NavBarLinkEventHandler(this.navBarItem_ZYBH_B4_ZYSZMJXJBHB_LinkClicked);
            this.navBarItem_ZYBH_B5_YCLMJXJBHB.Caption = "表5 用材林面积蓄积变化表";
            this.navBarItem_ZYBH_B5_YCLMJXJBHB.Name = "navBarItem_ZYBH_B5_YCLMJXJBHB";
            this.navBarItem_ZYBH_B5_YCLMJXJBHB.Visible = false;
            this.navBarItem_ZYBH_B5_YCLMJXJBHB.LinkClicked += new NavBarLinkEventHandler(this.navBarItem_ZYBH_B5_YCLMJXJBHB_LinkClicked);
            this.navbarImageListLarge.ImageStream = (ImageListStreamer) resources.GetObject("navbarImageListLarge.ImageStream");
            this.navbarImageListLarge.TransparentColor = Color.Transparent;
            this.navbarImageListLarge.Images.SetKeyName(0, "TableView.Icon.png");
            this.splitContainerControl.Dock = DockStyle.Fill;
            this.splitContainerControl.Location = new Point(0, 0x95);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Padding = new Padding(6);
            this.splitContainerControl.Panel1.Controls.Add(this.navBarControl);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.gridControl);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new Size(950, 370);
            this.splitContainerControl.SplitterPosition = 0x10c;
            this.splitContainerControl.TabIndex = 0;
            this.splitContainerControl.Text = "splitContainerControl1";
            this.gridControl.Dock = DockStyle.Fill;
            node.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new GridLevelNode[] { node });
            this.gridControl.Location = new Point(0, 0);
            this.gridControl.MainView = this.GView_ZYBH_B1_GLTDMJBHB;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new Size(0x299, 0x166);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new BaseView[] { this.GView_ZYBH_B1_GLTDMJBHB, this.GView_ZYBH_B2_GLSLLMMJXJBHB, this.gridView1, this.GView_ZYBH_B5_YCLMJXJBHB, this.GView_GYLDMJBGTJB, this.GView_GLLDMJBGTJB, this.GView_ZYBH_B4_ZYSZMJXJBHB, this.GView_ZYBH_B3_GLZMJXJBHB, this.GView_LDBHYYFXTJB, this.GView_GLLDDTZYTJB, this.GView_SPLDMJBGTJB });
            this.GView_ZYBH_B1_GLTDMJBHB.Appearance.BandPanel.Options.UseTextOptions = true;
            this.GView_ZYBH_B1_GLTDMJBHB.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
            this.GView_ZYBH_B1_GLTDMJBHB.Appearance.BandPanel.TextOptions.WordWrap = WordWrap.Wrap;
            this.GView_ZYBH_B1_GLTDMJBHB.Bands.AddRange(new GridBand[] { this.gridBand274 });
            this.GView_ZYBH_B1_GLTDMJBHB.BorderStyle = BorderStyles.Simple;
            this.GView_ZYBH_B1_GLTDMJBHB.Columns.AddRange(new BandedGridColumn[] { 
                this.bandedGridColumn81, this.bandedGridColumn82, this.bandedGridColumn83, this.bandedGridColumn84, this.bandedGridColumn85, this.bandedGridColumn86, this.bandedGridColumn87, this.bandedGridColumn88, this.bandedGridColumn89, this.bandedGridColumn90, this.bandedGridColumn91, this.bandedGridColumn92, this.bandedGridColumn93, this.bandedGridColumn94, this.bandedGridColumn95, this.bandedGridColumn96,
                this.bandedGridColumn97, this.bandedGridColumn98, this.bandedGridColumn99, this.bandedGridColumn100, this.bandedGridColumn101, this.bandedGridColumn102, this.bandedGridColumn103, this.bandedGridColumn104, this.bandedGridColumn105, this.bandedGridColumn106, this.bandedGridColumn107, this.bandedGridColumn108, this.bandedGridColumn109, this.bandedGridColumn110, this.bandedGridColumn111, this.bandedGridColumn112,
                this.bandedGridColumn113, this.bandedGridColumn114, this.bandedGridColumn115
            });
            this.GView_ZYBH_B1_GLTDMJBHB.GridControl = this.gridControl;
            this.GView_ZYBH_B1_GLTDMJBHB.Name = "GView_ZYBH_B1_GLTDMJBHB";
            this.GView_ZYBH_B1_GLTDMJBHB.OptionsView.ShowColumnHeaders = false;
            this.GView_ZYBH_B1_GLTDMJBHB.OptionsView.ShowGroupPanel = false;
            this.gridBand274.AppearanceHeader.Font = new Font("Tahoma", 12f, FontStyle.Bold);
            this.gridBand274.AppearanceHeader.Options.UseFont = true;
            this.gridBand274.Caption = "表1  各类土地面积变化情况表";
            this.gridBand274.Children.AddRange(new GridBand[] { this.gBandZYBHB1DW });
            this.gridBand274.Name = "gridBand274";
            this.gridBand274.RowCount = 2;
            this.gridBand274.Width = 0xa32;
            this.gBandZYBHB1DW.AppearanceHeader.Options.UseTextOptions = true;
            this.gBandZYBHB1DW.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Near;
            this.gBandZYBHB1DW.Children.AddRange(new GridBand[] { this.gridBand134, this.gridBand135, this.gridBand136, this.gridBand162, this.gridBand222, this.gridBand228, this.gridBand229 });
            this.gBandZYBHB1DW.Name = "gBandZYBHB1DW";
            this.gBandZYBHB1DW.Width = 0xa32;
            this.gridBand134.Caption = "统计单位";
            this.gridBand134.Children.AddRange(new GridBand[] { this.gridBand137 });
            this.gridBand134.MinWidth = 20;
            this.gridBand134.Name = "gridBand134";
            this.gridBand134.RowCount = 4;
            this.gridBand134.Width = 0x4b;
            this.gridBand137.Caption = "1";
            this.gridBand137.Columns.Add(this.bandedGridColumn81);
            this.gridBand137.Name = "gridBand137";
            this.gridBand137.Width = 0x4b;
            this.bandedGridColumn81.Caption = "bandedGridColumn81";
            this.bandedGridColumn81.Name = "bandedGridColumn81";
            this.bandedGridColumn81.Visible = true;
            this.gridBand135.Caption = "年度";
            this.gridBand135.Children.AddRange(new GridBand[] { this.gridBand138 });
            this.gridBand135.MinWidth = 20;
            this.gridBand135.Name = "gridBand135";
            this.gridBand135.RowCount = 4;
            this.gridBand135.Width = 0x4b;
            this.gridBand138.Caption = "2";
            this.gridBand138.Columns.Add(this.bandedGridColumn82);
            this.gridBand138.Name = "gridBand138";
            this.gridBand138.Width = 0x4b;
            this.bandedGridColumn82.Caption = "bandedGridColumn82";
            this.bandedGridColumn82.Name = "bandedGridColumn82";
            this.bandedGridColumn82.Visible = true;
            this.gridBand136.Caption = "土地总面积";
            this.gridBand136.Children.AddRange(new GridBand[] { this.gridBand161 });
            this.gridBand136.MinWidth = 20;
            this.gridBand136.Name = "gridBand136";
            this.gridBand136.RowCount = 4;
            this.gridBand136.Width = 0x4b;
            this.gridBand161.Caption = "3";
            this.gridBand161.Columns.Add(this.bandedGridColumn83);
            this.gridBand161.Name = "gridBand161";
            this.gridBand161.Width = 0x4b;
            this.bandedGridColumn83.Caption = "bandedGridColumn83";
            this.bandedGridColumn83.Name = "bandedGridColumn83";
            this.bandedGridColumn83.Visible = true;
            this.gridBand162.Caption = "林地";
            this.gridBand162.Children.AddRange(new GridBand[] { this.gridBand189, this.gridBand190, this.gridBand198, this.gridBand200, this.gridBand199, this.gridBand209, this.gridBand210, this.gridBand215, this.gridBand220, this.gridBand221 });
            this.gridBand162.MinWidth = 20;
            this.gridBand162.Name = "gridBand162";
            this.gridBand162.Width = 0x763;
            this.gridBand189.Caption = "合计";
            this.gridBand189.Children.AddRange(new GridBand[] { this.gridBand230 });
            this.gridBand189.Name = "gridBand189";
            this.gridBand189.RowCount = 3;
            this.gridBand189.Width = 0x4b;
            this.gridBand230.Caption = "4";
            this.gridBand230.Columns.Add(this.bandedGridColumn84);
            this.gridBand230.Name = "gridBand230";
            this.gridBand230.Width = 0x4b;
            this.bandedGridColumn84.Caption = "bandedGridColumn84";
            this.bandedGridColumn84.Name = "bandedGridColumn84";
            this.bandedGridColumn84.Visible = true;
            this.gridBand190.Caption = "有林地";
            this.gridBand190.Children.AddRange(new GridBand[] { this.gridBand191, this.gridBand192, this.gridBand196, this.gridBand197 });
            this.gridBand190.Name = "gridBand190";
            this.gridBand190.Width = 450;
            this.gridBand191.Caption = "小计";
            this.gridBand191.Children.AddRange(new GridBand[] { this.gridBand231 });
            this.gridBand191.Name = "gridBand191";
            this.gridBand191.RowCount = 2;
            this.gridBand191.Width = 0x4b;
            this.gridBand231.Caption = "5";
            this.gridBand231.Columns.Add(this.bandedGridColumn85);
            this.gridBand231.Name = "gridBand231";
            this.gridBand231.Width = 0x4b;
            this.bandedGridColumn85.Caption = "bandedGridColumn85";
            this.bandedGridColumn85.Name = "bandedGridColumn85";
            this.bandedGridColumn85.Visible = true;
            this.gridBand192.Caption = "乔木林地";
            this.gridBand192.Children.AddRange(new GridBand[] { this.gridBand193, this.gridBand194, this.gridBand195 });
            this.gridBand192.Name = "gridBand192";
            this.gridBand192.Width = 0xe1;
            this.gridBand193.Caption = "小计";
            this.gridBand193.Children.AddRange(new GridBand[] { this.gridBand232 });
            this.gridBand193.Name = "gridBand193";
            this.gridBand193.Width = 0x4b;
            this.gridBand232.Caption = "6";
            this.gridBand232.Columns.Add(this.bandedGridColumn86);
            this.gridBand232.Name = "gridBand232";
            this.gridBand232.Width = 0x4b;
            this.bandedGridColumn86.Caption = "bandedGridColumn86";
            this.bandedGridColumn86.Name = "bandedGridColumn86";
            this.bandedGridColumn86.Visible = true;
            this.gridBand194.Caption = "纯林";
            this.gridBand194.Children.AddRange(new GridBand[] { this.gridBand233 });
            this.gridBand194.Name = "gridBand194";
            this.gridBand194.Width = 0x4b;
            this.gridBand233.Caption = "7";
            this.gridBand233.Columns.Add(this.bandedGridColumn87);
            this.gridBand233.Name = "gridBand233";
            this.gridBand233.Width = 0x4b;
            this.bandedGridColumn87.Caption = "bandedGridColumn87";
            this.bandedGridColumn87.Name = "bandedGridColumn87";
            this.bandedGridColumn87.Visible = true;
            this.gridBand195.Caption = "混交林";
            this.gridBand195.Children.AddRange(new GridBand[] { this.gridBand234 });
            this.gridBand195.Name = "gridBand195";
            this.gridBand195.Width = 0x4b;
            this.gridBand234.Caption = "8";
            this.gridBand234.Columns.Add(this.bandedGridColumn88);
            this.gridBand234.Name = "gridBand234";
            this.gridBand234.Width = 0x4b;
            this.bandedGridColumn88.Caption = "bandedGridColumn88";
            this.bandedGridColumn88.Name = "bandedGridColumn88";
            this.bandedGridColumn88.Visible = true;
            this.gridBand196.Caption = "红树林";
            this.gridBand196.Children.AddRange(new GridBand[] { this.gridBand235 });
            this.gridBand196.Name = "gridBand196";
            this.gridBand196.RowCount = 2;
            this.gridBand196.Width = 0x4b;
            this.gridBand235.Caption = "9";
            this.gridBand235.Columns.Add(this.bandedGridColumn89);
            this.gridBand235.Name = "gridBand235";
            this.gridBand235.Width = 0x4b;
            this.bandedGridColumn89.Caption = "bandedGridColumn89";
            this.bandedGridColumn89.Name = "bandedGridColumn89";
            this.bandedGridColumn89.Visible = true;
            this.gridBand197.Caption = "竹林";
            this.gridBand197.Children.AddRange(new GridBand[] { this.gridBand236 });
            this.gridBand197.Name = "gridBand197";
            this.gridBand197.RowCount = 2;
            this.gridBand197.Width = 0x4b;
            this.gridBand236.Caption = "10";
            this.gridBand236.Columns.Add(this.bandedGridColumn90);
            this.gridBand236.Name = "gridBand236";
            this.gridBand236.Width = 0x4b;
            this.bandedGridColumn90.Caption = "bandedGridColumn90";
            this.bandedGridColumn90.Name = "bandedGridColumn90";
            this.bandedGridColumn90.Visible = true;
            this.gridBand198.Caption = "疏林地";
            this.gridBand198.Children.AddRange(new GridBand[] { this.gridBand237 });
            this.gridBand198.Name = "gridBand198";
            this.gridBand198.RowCount = 3;
            this.gridBand198.Width = 0x4b;
            this.gridBand237.Caption = "11";
            this.gridBand237.Columns.Add(this.bandedGridColumn91);
            this.gridBand237.Name = "gridBand237";
            this.gridBand237.Width = 0x4b;
            this.bandedGridColumn91.Caption = "bandedGridColumn91";
            this.bandedGridColumn91.Name = "bandedGridColumn91";
            this.bandedGridColumn91.Visible = true;
            this.gridBand200.Caption = "灌木林地";
            this.gridBand200.Children.AddRange(new GridBand[] { this.gridBand201, this.gridBand202, this.gridBand205 });
            this.gridBand200.Name = "gridBand200";
            this.gridBand200.Width = 0x13c;
            this.gridBand201.Caption = "小计";
            this.gridBand201.Children.AddRange(new GridBand[] { this.gridBand238 });
            this.gridBand201.Name = "gridBand201";
            this.gridBand201.RowCount = 2;
            this.gridBand201.Width = 0x4b;
            this.gridBand238.Caption = "12";
            this.gridBand238.Columns.Add(this.bandedGridColumn92);
            this.gridBand238.Name = "gridBand238";
            this.gridBand238.Width = 0x4b;
            this.bandedGridColumn92.Caption = "bandedGridColumn92";
            this.bandedGridColumn92.Name = "bandedGridColumn92";
            this.bandedGridColumn92.Visible = true;
            this.gridBand202.Caption = "国家特灌";
            this.gridBand202.Children.AddRange(new GridBand[] { this.gridBand203, this.gridBand204 });
            this.gridBand202.Name = "gridBand202";
            this.gridBand202.Width = 0xa6;
            this.gridBand203.Caption = "小计";
            this.gridBand203.Children.AddRange(new GridBand[] { this.gridBand239 });
            this.gridBand203.Name = "gridBand203";
            this.gridBand203.Width = 0x4d;
            this.gridBand239.Caption = "13";
            this.gridBand239.Columns.Add(this.bandedGridColumn93);
            this.gridBand239.Name = "gridBand239";
            this.gridBand239.Width = 0x4d;
            this.bandedGridColumn93.Caption = "bandedGridColumn93";
            this.bandedGridColumn93.Name = "bandedGridColumn93";
            this.bandedGridColumn93.Visible = true;
            this.bandedGridColumn93.Width = 0x4d;
            this.gridBand204.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand204.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand204.AppearanceHeader.TextOptions.WordWrap = WordWrap.NoWrap;
            this.gridBand204.Caption = "其中灌木经济林";
            this.gridBand204.Children.AddRange(new GridBand[] { this.gridBand240 });
            this.gridBand204.Name = "gridBand204";
            this.gridBand204.Width = 0x59;
            this.gridBand240.Caption = "14";
            this.gridBand240.Columns.Add(this.bandedGridColumn94);
            this.gridBand240.Name = "gridBand240";
            this.gridBand240.Width = 0x59;
            this.bandedGridColumn94.Caption = "bandedGridColumn94";
            this.bandedGridColumn94.Name = "bandedGridColumn94";
            this.bandedGridColumn94.Visible = true;
            this.bandedGridColumn94.Width = 0x59;
            this.gridBand205.Caption = "其它灌木林";
            this.gridBand205.Children.AddRange(new GridBand[] { this.gridBand241 });
            this.gridBand205.Name = "gridBand205";
            this.gridBand205.RowCount = 2;
            this.gridBand205.Width = 0x4b;
            this.gridBand241.Caption = "15";
            this.gridBand241.Columns.Add(this.bandedGridColumn95);
            this.gridBand241.Name = "gridBand241";
            this.gridBand241.Width = 0x4b;
            this.bandedGridColumn95.Caption = "bandedGridColumn95";
            this.bandedGridColumn95.Name = "bandedGridColumn95";
            this.bandedGridColumn95.Visible = true;
            this.gridBand199.Caption = "未成林造林地";
            this.gridBand199.Children.AddRange(new GridBand[] { this.gridBand207, this.gridBand206, this.gridBand208 });
            this.gridBand199.MinWidth = 20;
            this.gridBand199.Name = "gridBand199";
            this.gridBand199.Width = 0xe1;
            this.gridBand207.Caption = "小计";
            this.gridBand207.Children.AddRange(new GridBand[] { this.gridBand242 });
            this.gridBand207.Name = "gridBand207";
            this.gridBand207.RowCount = 2;
            this.gridBand207.Width = 0x4b;
            this.gridBand242.Caption = "16";
            this.gridBand242.Columns.Add(this.bandedGridColumn96);
            this.gridBand242.Name = "gridBand242";
            this.gridBand242.Width = 0x4b;
            this.bandedGridColumn96.Caption = "bandedGridColumn96";
            this.bandedGridColumn96.Name = "bandedGridColumn96";
            this.bandedGridColumn96.Visible = true;
            this.gridBand206.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand206.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand206.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand206.Caption = "人工造林未成林地";
            this.gridBand206.Children.AddRange(new GridBand[] { this.gridBand243 });
            this.gridBand206.Name = "gridBand206";
            this.gridBand206.RowCount = 2;
            this.gridBand206.Width = 0x4b;
            this.gridBand243.Caption = "17";
            this.gridBand243.Columns.Add(this.bandedGridColumn97);
            this.gridBand243.Name = "gridBand243";
            this.gridBand243.Width = 0x4b;
            this.bandedGridColumn97.Caption = "bandedGridColumn97";
            this.bandedGridColumn97.Name = "bandedGridColumn97";
            this.bandedGridColumn97.Visible = true;
            this.gridBand208.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand208.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand208.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand208.Caption = "封育未成林地";
            this.gridBand208.Children.AddRange(new GridBand[] { this.gridBand244 });
            this.gridBand208.MinWidth = 20;
            this.gridBand208.Name = "gridBand208";
            this.gridBand208.RowCount = 2;
            this.gridBand208.Width = 0x4b;
            this.gridBand244.Caption = "18";
            this.gridBand244.Columns.Add(this.bandedGridColumn98);
            this.gridBand244.Name = "gridBand244";
            this.gridBand244.Width = 0x4b;
            this.bandedGridColumn98.Caption = "bandedGridColumn98";
            this.bandedGridColumn98.Name = "bandedGridColumn98";
            this.bandedGridColumn98.Visible = true;
            this.gridBand209.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand209.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridBand209.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand209.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand209.Caption = "苗圃地";
            this.gridBand209.Children.AddRange(new GridBand[] { this.gridBand245 });
            this.gridBand209.MinWidth = 20;
            this.gridBand209.Name = "gridBand209";
            this.gridBand209.RowCount = 3;
            this.gridBand209.Width = 0x4b;
            this.gridBand245.Caption = "19";
            this.gridBand245.Columns.Add(this.bandedGridColumn99);
            this.gridBand245.Name = "gridBand245";
            this.gridBand245.Width = 0x4b;
            this.bandedGridColumn99.Caption = "bandedGridColumn99";
            this.bandedGridColumn99.Name = "bandedGridColumn99";
            this.bandedGridColumn99.Visible = true;
            this.gridBand210.Caption = "无立木林地";
            this.gridBand210.Children.AddRange(new GridBand[] { this.gridBand211, this.gridBand212, this.gridBand213, this.gridBand214 });
            this.gridBand210.Name = "gridBand210";
            this.gridBand210.Width = 300;
            this.gridBand211.Caption = "小计";
            this.gridBand211.Children.AddRange(new GridBand[] { this.gridBand246 });
            this.gridBand211.Name = "gridBand211";
            this.gridBand211.RowCount = 2;
            this.gridBand211.Width = 0x4b;
            this.gridBand246.Caption = "20";
            this.gridBand246.Columns.Add(this.bandedGridColumn100);
            this.gridBand246.Name = "gridBand246";
            this.gridBand246.Width = 0x4b;
            this.bandedGridColumn100.Caption = "bandedGridColumn100";
            this.bandedGridColumn100.Name = "bandedGridColumn100";
            this.bandedGridColumn100.Visible = true;
            this.gridBand212.Caption = "采伐迹地";
            this.gridBand212.Children.AddRange(new GridBand[] { this.gridBand247 });
            this.gridBand212.Name = "gridBand212";
            this.gridBand212.RowCount = 2;
            this.gridBand212.Width = 0x4b;
            this.gridBand247.Caption = "21";
            this.gridBand247.Columns.Add(this.bandedGridColumn101);
            this.gridBand247.Name = "gridBand247";
            this.gridBand247.Width = 0x4b;
            this.bandedGridColumn101.Caption = "bandedGridColumn101";
            this.bandedGridColumn101.Name = "bandedGridColumn101";
            this.bandedGridColumn101.Visible = true;
            this.gridBand213.Caption = "火烧迹地";
            this.gridBand213.Children.AddRange(new GridBand[] { this.gridBand248 });
            this.gridBand213.Name = "gridBand213";
            this.gridBand213.RowCount = 2;
            this.gridBand213.Width = 0x4b;
            this.gridBand248.Caption = "22";
            this.gridBand248.Columns.Add(this.bandedGridColumn102);
            this.gridBand248.Name = "gridBand248";
            this.gridBand248.Width = 0x4b;
            this.bandedGridColumn102.Caption = "bandedGridColumn102";
            this.bandedGridColumn102.Name = "bandedGridColumn102";
            this.bandedGridColumn102.Visible = true;
            this.gridBand214.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand214.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand214.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand214.Caption = "其它无立木林地";
            this.gridBand214.Children.AddRange(new GridBand[] { this.gridBand249 });
            this.gridBand214.Name = "gridBand214";
            this.gridBand214.RowCount = 2;
            this.gridBand214.Width = 0x4b;
            this.gridBand249.Caption = "23";
            this.gridBand249.Columns.Add(this.bandedGridColumn103);
            this.gridBand249.Name = "gridBand249";
            this.gridBand249.Width = 0x4b;
            this.bandedGridColumn103.Caption = "bandedGridColumn103";
            this.bandedGridColumn103.Name = "bandedGridColumn103";
            this.bandedGridColumn103.Visible = true;
            this.gridBand215.Caption = "宜林地";
            this.gridBand215.Children.AddRange(new GridBand[] { this.gridBand216, this.gridBand217, this.gridBand218, this.gridBand219 });
            this.gridBand215.Name = "gridBand215";
            this.gridBand215.Width = 0xe1;
            this.gridBand216.Caption = "小计";
            this.gridBand216.Children.AddRange(new GridBand[] { this.gridBand250 });
            this.gridBand216.Name = "gridBand216";
            this.gridBand216.RowCount = 2;
            this.gridBand216.Width = 0x4b;
            this.gridBand250.Caption = "24";
            this.gridBand250.Columns.Add(this.bandedGridColumn104);
            this.gridBand250.Name = "gridBand250";
            this.gridBand250.Width = 0x4b;
            this.bandedGridColumn104.Caption = "bandedGridColumn104";
            this.bandedGridColumn104.Name = "bandedGridColumn104";
            this.bandedGridColumn104.Visible = true;
            this.gridBand217.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand217.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand217.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand217.Caption = "宜林荒山荒地";
            this.gridBand217.Children.AddRange(new GridBand[] { this.gridBand251 });
            this.gridBand217.Name = "gridBand217";
            this.gridBand217.RowCount = 2;
            this.gridBand217.Width = 0x4b;
            this.gridBand251.Caption = "25";
            this.gridBand251.Columns.Add(this.bandedGridColumn105);
            this.gridBand251.Name = "gridBand251";
            this.gridBand251.Width = 0x4b;
            this.bandedGridColumn105.Caption = "bandedGridColumn105";
            this.bandedGridColumn105.Name = "bandedGridColumn105";
            this.bandedGridColumn105.Visible = true;
            this.gridBand218.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand218.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand218.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand218.Caption = "宜林沙荒地";
            this.gridBand218.Children.AddRange(new GridBand[] { this.gridBand252 });
            this.gridBand218.Name = "gridBand218";
            this.gridBand218.RowCount = 2;
            this.gridBand218.Visible = false;
            this.gridBand218.Width = 0x4b;
            this.gridBand252.Caption = "26";
            this.gridBand252.Name = "gridBand252";
            this.gridBand252.Visible = false;
            this.gridBand252.Width = 0x4b;
            this.gridBand219.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand219.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand219.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand219.Caption = "其它宜林地";
            this.gridBand219.Children.AddRange(new GridBand[] { this.gridBand253 });
            this.gridBand219.Name = "gridBand219";
            this.gridBand219.RowCount = 2;
            this.gridBand219.Width = 0x4b;
            this.gridBand253.Caption = "26";
            this.gridBand253.Columns.Add(this.bandedGridColumn106);
            this.gridBand253.Name = "gridBand253";
            this.gridBand253.Width = 0x4b;
            this.bandedGridColumn106.Caption = "bandedGridColumn106";
            this.bandedGridColumn106.Name = "bandedGridColumn106";
            this.bandedGridColumn106.Visible = true;
            this.gridBand220.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand220.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand220.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand220.Caption = "辅助生产用地";
            this.gridBand220.Children.AddRange(new GridBand[] { this.gridBand254 });
            this.gridBand220.Name = "gridBand220";
            this.gridBand220.RowCount = 3;
            this.gridBand220.Width = 0x4b;
            this.gridBand254.Caption = "27";
            this.gridBand254.Columns.Add(this.bandedGridColumn107);
            this.gridBand254.Name = "gridBand254";
            this.gridBand254.Width = 0x4b;
            this.bandedGridColumn107.Caption = "bandedGridColumn107";
            this.bandedGridColumn107.Name = "bandedGridColumn107";
            this.bandedGridColumn107.Visible = true;
            this.gridBand221.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand221.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand221.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand221.Caption = "被占用林地";
            this.gridBand221.Children.AddRange(new GridBand[] { this.gridBand255 });
            this.gridBand221.Name = "gridBand221";
            this.gridBand221.RowCount = 3;
            this.gridBand221.Width = 0x4b;
            this.gridBand255.Caption = "28";
            this.gridBand255.Columns.Add(this.bandedGridColumn108);
            this.gridBand255.Name = "gridBand255";
            this.gridBand255.Width = 0x4b;
            this.bandedGridColumn108.Caption = "bandedGridColumn108";
            this.bandedGridColumn108.Name = "bandedGridColumn108";
            this.bandedGridColumn108.Visible = true;
            this.gridBand222.Caption = "非林地";
            this.gridBand222.Children.AddRange(new GridBand[] { this.gridBand223, this.gridBand224 });
            this.gridBand222.Name = "gridBand222";
            this.gridBand222.Width = 0x177;
            this.gridBand223.Caption = "合计";
            this.gridBand223.Children.AddRange(new GridBand[] { this.gridBand256 });
            this.gridBand223.Name = "gridBand223";
            this.gridBand223.RowCount = 3;
            this.gridBand223.Width = 0x4b;
            this.gridBand256.Caption = "29";
            this.gridBand256.Columns.Add(this.bandedGridColumn109);
            this.gridBand256.Name = "gridBand256";
            this.gridBand256.Width = 0x4b;
            this.bandedGridColumn109.Caption = "bandedGridColumn109";
            this.bandedGridColumn109.Name = "bandedGridColumn109";
            this.bandedGridColumn109.Visible = true;
            this.gridBand224.Caption = "其中";
            this.gridBand224.Children.AddRange(new GridBand[] { this.gridBand524, this.gridBand225, this.gridBand226, this.gridBand227 });
            this.gridBand224.Name = "gridBand224";
            this.gridBand224.Width = 300;
            this.gridBand524.Caption = "农地乔木林";
            this.gridBand524.Children.AddRange(new GridBand[] { this.gridBand257 });
            this.gridBand524.Name = "gridBand524";
            this.gridBand524.RowCount = 2;
            this.gridBand524.Width = 0x4b;
            this.gridBand257.Caption = "30";
            this.gridBand257.Columns.Add(this.bandedGridColumn110);
            this.gridBand257.Name = "gridBand257";
            this.gridBand257.Width = 0x4b;
            this.bandedGridColumn110.Caption = "bandedGridColumn110";
            this.bandedGridColumn110.Name = "bandedGridColumn110";
            this.bandedGridColumn110.Visible = true;
            this.gridBand225.Caption = "农地经济林";
            this.gridBand225.Children.AddRange(new GridBand[] { this.gridBand258 });
            this.gridBand225.Name = "gridBand225";
            this.gridBand225.RowCount = 2;
            this.gridBand225.Width = 0x4b;
            this.gridBand258.Caption = "31";
            this.gridBand258.Columns.Add(this.bandedGridColumn111);
            this.gridBand258.Name = "gridBand258";
            this.gridBand258.Width = 0x4b;
            this.bandedGridColumn111.Caption = "bandedGridColumn111";
            this.bandedGridColumn111.Name = "bandedGridColumn111";
            this.bandedGridColumn111.Visible = true;
            this.gridBand226.Caption = "农地竹林";
            this.gridBand226.Children.AddRange(new GridBand[] { this.gridBand259 });
            this.gridBand226.Name = "gridBand226";
            this.gridBand226.RowCount = 2;
            this.gridBand226.Width = 0x4b;
            this.gridBand259.Caption = "32";
            this.gridBand259.Columns.Add(this.bandedGridColumn112);
            this.gridBand259.Name = "gridBand259";
            this.gridBand259.Width = 0x4b;
            this.bandedGridColumn112.Caption = "bandedGridColumn112";
            this.bandedGridColumn112.Name = "bandedGridColumn112";
            this.bandedGridColumn112.Visible = true;
            this.gridBand227.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand227.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand227.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand227.Caption = "四旁树覆盖面积";
            this.gridBand227.Children.AddRange(new GridBand[] { this.gridBand260 });
            this.gridBand227.Name = "gridBand227";
            this.gridBand227.RowCount = 2;
            this.gridBand227.Width = 0x4b;
            this.gridBand260.Caption = "33";
            this.gridBand260.Columns.Add(this.bandedGridColumn113);
            this.gridBand260.Name = "gridBand260";
            this.gridBand260.Width = 0x4b;
            this.bandedGridColumn113.Caption = "bandedGridColumn113";
            this.bandedGridColumn113.Name = "bandedGridColumn113";
            this.bandedGridColumn113.Visible = true;
            this.gridBand228.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand228.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand228.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand228.Caption = "森林覆盖率%";
            this.gridBand228.Children.AddRange(new GridBand[] { this.gridBand261 });
            this.gridBand228.Name = "gridBand228";
            this.gridBand228.RowCount = 4;
            this.gridBand228.Width = 0x3f;
            this.gridBand261.Caption = "34";
            this.gridBand261.Columns.Add(this.bandedGridColumn114);
            this.gridBand261.Name = "gridBand261";
            this.gridBand261.Width = 0x3f;
            this.bandedGridColumn114.Caption = "bandedGridColumn114";
            this.bandedGridColumn114.Name = "bandedGridColumn114";
            this.bandedGridColumn114.Visible = true;
            this.bandedGridColumn114.Width = 0x3f;
            this.gridBand229.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand229.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand229.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand229.Caption = "林木绿化率%";
            this.gridBand229.Children.AddRange(new GridBand[] { this.gridBand266 });
            this.gridBand229.Name = "gridBand229";
            this.gridBand229.RowCount = 4;
            this.gridBand229.Width = 0x38;
            this.gridBand266.Caption = "35";
            this.gridBand266.Columns.Add(this.bandedGridColumn115);
            this.gridBand266.Name = "gridBand266";
            this.gridBand266.Width = 0x38;
            this.bandedGridColumn115.Caption = "bandedGridColumn115";
            this.bandedGridColumn115.Name = "bandedGridColumn115";
            this.bandedGridColumn115.Visible = true;
            this.bandedGridColumn115.Width = 0x38;
            this.GView_ZYBH_B2_GLSLLMMJXJBHB.Appearance.BandPanel.Options.UseTextOptions = true;
            this.GView_ZYBH_B2_GLSLLMMJXJBHB.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
            this.GView_ZYBH_B2_GLSLLMMJXJBHB.Appearance.BandPanel.TextOptions.WordWrap = WordWrap.Wrap;
            this.GView_ZYBH_B2_GLSLLMMJXJBHB.Bands.AddRange(new GridBand[] { this.gridBand276 });
            this.GView_ZYBH_B2_GLSLLMMJXJBHB.BorderStyle = BorderStyles.Simple;
            this.GView_ZYBH_B2_GLSLLMMJXJBHB.Columns.AddRange(new BandedGridColumn[] { 
                this.bandedGridColumn138, this.bandedGridColumn139, this.bandedGridColumn140, this.bandedGridColumn141, this.bandedGridColumn142, this.bandedGridColumn143, this.bandedGridColumn144, this.bandedGridColumn145, this.bandedGridColumn146, this.bandedGridColumn147, this.bandedGridColumn148, this.bandedGridColumn149, this.bandedGridColumn150, this.bandedGridColumn151, this.bandedGridColumn152, this.bandedGridColumn153,
                this.bandedGridColumn154, this.bandedGridColumn155, this.bandedGridColumn156, this.bandedGridColumn50, this.bandedGridColumn70
            });
            this.GView_ZYBH_B2_GLSLLMMJXJBHB.GridControl = this.gridControl;
            this.GView_ZYBH_B2_GLSLLMMJXJBHB.Name = "GView_ZYBH_B2_GLSLLMMJXJBHB";
            this.GView_ZYBH_B2_GLSLLMMJXJBHB.OptionsView.ShowColumnHeaders = false;
            this.GView_ZYBH_B2_GLSLLMMJXJBHB.OptionsView.ShowGroupPanel = false;
            this.gridBand276.AppearanceHeader.Font = new Font("Tahoma", 12f, FontStyle.Bold);
            this.gridBand276.AppearanceHeader.Options.UseFont = true;
            this.gridBand276.Caption = "表2  各类森林、林木面积蓄积变化情况表";
            this.gridBand276.Children.AddRange(new GridBand[] { this.gBandZYBHB2DW });
            this.gridBand276.Name = "gridBand276";
            this.gridBand276.RowCount = 2;
            this.gridBand276.Width = 0x627;
            this.gBandZYBHB2DW.AppearanceHeader.Options.UseTextOptions = true;
            this.gBandZYBHB2DW.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Near;
            this.gBandZYBHB2DW.Caption = "gridBand279";
            this.gBandZYBHB2DW.Children.AddRange(new GridBand[] { this.gridBand286, this.gridBand288, this.gridBand330, this.gridBand293, this.gridBand350, this.gridBand356, this.gridBand361, this.gridBand170 });
            this.gBandZYBHB2DW.Name = "gBandZYBHB2DW";
            this.gBandZYBHB2DW.Width = 0x627;
            this.gridBand286.Caption = "统计单位";
            this.gridBand286.Children.AddRange(new GridBand[] { this.gridBand287 });
            this.gridBand286.MinWidth = 20;
            this.gridBand286.Name = "gridBand286";
            this.gridBand286.RowCount = 4;
            this.gridBand286.Width = 0x4b;
            this.gridBand287.Caption = "1";
            this.gridBand287.Columns.Add(this.bandedGridColumn138);
            this.gridBand287.Name = "gridBand287";
            this.gridBand287.Width = 0x4b;
            this.bandedGridColumn138.Caption = "bandedGridColumn138";
            this.bandedGridColumn138.Name = "bandedGridColumn138";
            this.bandedGridColumn138.Visible = true;
            this.gridBand288.Caption = "年度";
            this.gridBand288.Children.AddRange(new GridBand[] { this.gridBand289 });
            this.gridBand288.MinWidth = 20;
            this.gridBand288.Name = "gridBand288";
            this.gridBand288.RowCount = 4;
            this.gridBand288.Width = 0x4b;
            this.gridBand289.Caption = "2";
            this.gridBand289.Columns.Add(this.bandedGridColumn139);
            this.gridBand289.Name = "gridBand289";
            this.gridBand289.Width = 0x4b;
            this.bandedGridColumn139.Caption = "bandedGridColumn139";
            this.bandedGridColumn139.Name = "bandedGridColumn139";
            this.bandedGridColumn139.Visible = true;
            this.gridBand330.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand330.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridBand330.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand330.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand330.Caption = "活立木总蓄积量";
            this.gridBand330.Children.AddRange(new GridBand[] { this.gridBand331 });
            this.gridBand330.MinWidth = 20;
            this.gridBand330.Name = "gridBand330";
            this.gridBand330.RowCount = 4;
            this.gridBand330.Width = 0x4b;
            this.gridBand331.Caption = "3";
            this.gridBand331.Columns.Add(this.bandedGridColumn140);
            this.gridBand331.Name = "gridBand331";
            this.gridBand331.Width = 0x4b;
            this.bandedGridColumn140.Caption = "bandedGridColumn140";
            this.bandedGridColumn140.Name = "bandedGridColumn140";
            this.bandedGridColumn140.Visible = true;
            this.gridBand293.Caption = "有林地";
            this.gridBand293.Children.AddRange(new GridBand[] { this.gridBand315, this.gridBand317, this.gridBand334, this.gridBand343 });
            this.gridBand293.MinWidth = 20;
            this.gridBand293.Name = "gridBand293";
            this.gridBand293.Width = 750;
            this.gridBand315.Caption = "面积合计";
            this.gridBand315.Children.AddRange(new GridBand[] { this.gridBand316 });
            this.gridBand315.Name = "gridBand315";
            this.gridBand315.RowCount = 3;
            this.gridBand315.Width = 0x4b;
            this.gridBand316.Caption = "4";
            this.gridBand316.Columns.Add(this.bandedGridColumn141);
            this.gridBand316.Name = "gridBand316";
            this.gridBand316.Width = 0x4b;
            this.bandedGridColumn141.Caption = "bandedGridColumn141";
            this.bandedGridColumn141.Name = "bandedGridColumn141";
            this.bandedGridColumn141.Visible = true;
            this.gridBand317.Caption = "乔木林地";
            this.gridBand317.Children.AddRange(new GridBand[] { this.gridBand318, this.gridBand320, this.gridBand337 });
            this.gridBand317.Name = "gridBand317";
            this.gridBand317.Width = 450;
            this.gridBand318.Caption = "小计";
            this.gridBand318.Children.AddRange(new GridBand[] { this.gridBand332, this.gridBand335 });
            this.gridBand318.MinWidth = 20;
            this.gridBand318.Name = "gridBand318";
            this.gridBand318.Width = 150;
            this.gridBand332.Caption = "面积";
            this.gridBand332.Children.AddRange(new GridBand[] { this.gridBand333 });
            this.gridBand332.Name = "gridBand332";
            this.gridBand332.Width = 0x4b;
            this.gridBand333.Caption = "5";
            this.gridBand333.Columns.Add(this.bandedGridColumn142);
            this.gridBand333.Name = "gridBand333";
            this.gridBand333.Width = 0x4b;
            this.bandedGridColumn142.Caption = "bandedGridColumn142";
            this.bandedGridColumn142.Name = "bandedGridColumn142";
            this.bandedGridColumn142.Visible = true;
            this.gridBand335.Caption = "蓄积";
            this.gridBand335.Children.AddRange(new GridBand[] { this.gridBand336 });
            this.gridBand335.Name = "gridBand335";
            this.gridBand335.Width = 0x4b;
            this.gridBand336.Caption = "6";
            this.gridBand336.Columns.Add(this.bandedGridColumn143);
            this.gridBand336.Name = "gridBand336";
            this.gridBand336.Width = 0x4b;
            this.bandedGridColumn143.Caption = "bandedGridColumn143";
            this.bandedGridColumn143.Name = "bandedGridColumn143";
            this.bandedGridColumn143.Visible = true;
            this.gridBand320.Caption = "纯林";
            this.gridBand320.Children.AddRange(new GridBand[] { this.gridBand324, this.gridBand339 });
            this.gridBand320.MinWidth = 20;
            this.gridBand320.Name = "gridBand320";
            this.gridBand320.Width = 150;
            this.gridBand324.Caption = "面积";
            this.gridBand324.Children.AddRange(new GridBand[] { this.gridBand325 });
            this.gridBand324.Name = "gridBand324";
            this.gridBand324.Width = 0x4b;
            this.gridBand325.Caption = "7";
            this.gridBand325.Columns.Add(this.bandedGridColumn144);
            this.gridBand325.Name = "gridBand325";
            this.gridBand325.Width = 0x4b;
            this.bandedGridColumn144.Caption = "bandedGridColumn144";
            this.bandedGridColumn144.Name = "bandedGridColumn144";
            this.bandedGridColumn144.Visible = true;
            this.gridBand339.Caption = "蓄积";
            this.gridBand339.Children.AddRange(new GridBand[] { this.gridBand340 });
            this.gridBand339.Name = "gridBand339";
            this.gridBand339.Width = 0x4b;
            this.gridBand340.Caption = "8";
            this.gridBand340.Columns.Add(this.bandedGridColumn145);
            this.gridBand340.Name = "gridBand340";
            this.gridBand340.Width = 0x4b;
            this.bandedGridColumn145.Caption = "bandedGridColumn145";
            this.bandedGridColumn145.Name = "bandedGridColumn145";
            this.bandedGridColumn145.Visible = true;
            this.gridBand337.Caption = "混交林";
            this.gridBand337.Children.AddRange(new GridBand[] { this.gridBand328, this.gridBand341 });
            this.gridBand337.Name = "gridBand337";
            this.gridBand337.Width = 150;
            this.gridBand328.Caption = "面积";
            this.gridBand328.Children.AddRange(new GridBand[] { this.gridBand329 });
            this.gridBand328.Name = "gridBand328";
            this.gridBand328.Width = 0x4b;
            this.gridBand329.Caption = "9";
            this.gridBand329.Columns.Add(this.bandedGridColumn146);
            this.gridBand329.Name = "gridBand329";
            this.gridBand329.Width = 0x4b;
            this.bandedGridColumn146.Caption = "bandedGridColumn146";
            this.bandedGridColumn146.Name = "bandedGridColumn146";
            this.bandedGridColumn146.Visible = true;
            this.gridBand341.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand341.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridBand341.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand341.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand341.Caption = "蓄积";
            this.gridBand341.Children.AddRange(new GridBand[] { this.gridBand342 });
            this.gridBand341.Name = "gridBand341";
            this.gridBand341.Width = 0x4b;
            this.gridBand342.Caption = "10";
            this.gridBand342.Columns.Add(this.bandedGridColumn147);
            this.gridBand342.Name = "gridBand342";
            this.gridBand342.Width = 0x4b;
            this.bandedGridColumn147.Caption = "bandedGridColumn147";
            this.bandedGridColumn147.Name = "bandedGridColumn147";
            this.bandedGridColumn147.Visible = true;
            this.gridBand334.Caption = "红树林";
            this.gridBand334.Children.AddRange(new GridBand[] { this.gridBand344 });
            this.gridBand334.MinWidth = 20;
            this.gridBand334.Name = "gridBand334";
            this.gridBand334.RowCount = 2;
            this.gridBand334.Width = 0x4b;
            this.gridBand344.Caption = "面积";
            this.gridBand344.Children.AddRange(new GridBand[] { this.gridBand345 });
            this.gridBand344.Name = "gridBand344";
            this.gridBand344.Width = 0x4b;
            this.gridBand345.Caption = "11";
            this.gridBand345.Columns.Add(this.bandedGridColumn148);
            this.gridBand345.Name = "gridBand345";
            this.gridBand345.Width = 0x4b;
            this.bandedGridColumn148.Caption = "bandedGridColumn148";
            this.bandedGridColumn148.Name = "bandedGridColumn148";
            this.bandedGridColumn148.Visible = true;
            this.gridBand343.Caption = "竹林";
            this.gridBand343.Children.AddRange(new GridBand[] { this.gridBand346, this.gridBand348 });
            this.gridBand343.MinWidth = 20;
            this.gridBand343.Name = "gridBand343";
            this.gridBand343.RowCount = 2;
            this.gridBand343.Width = 150;
            this.gridBand346.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand346.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridBand346.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand346.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand346.Caption = "面积";
            this.gridBand346.Children.AddRange(new GridBand[] { this.gridBand347 });
            this.gridBand346.Name = "gridBand346";
            this.gridBand346.Width = 0x4b;
            this.gridBand347.Caption = "12";
            this.gridBand347.Columns.Add(this.bandedGridColumn149);
            this.gridBand347.Name = "gridBand347";
            this.gridBand347.Width = 0x4b;
            this.bandedGridColumn149.Caption = "bandedGridColumn149";
            this.bandedGridColumn149.Name = "bandedGridColumn149";
            this.bandedGridColumn149.Visible = true;
            this.gridBand348.Caption = "株数";
            this.gridBand348.Children.AddRange(new GridBand[] { this.gridBand349 });
            this.gridBand348.Name = "gridBand348";
            this.gridBand348.Width = 0x4b;
            this.gridBand349.Caption = "13";
            this.gridBand349.Columns.Add(this.bandedGridColumn150);
            this.gridBand349.Name = "gridBand349";
            this.gridBand349.Width = 0x4b;
            this.bandedGridColumn150.Caption = "bandedGridColumn150";
            this.bandedGridColumn150.Name = "bandedGridColumn150";
            this.bandedGridColumn150.Visible = true;
            this.gridBand350.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand350.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridBand350.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand350.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand350.Caption = "疏林";
            this.gridBand350.Children.AddRange(new GridBand[] { this.gridBand352, this.gridBand354 });
            this.gridBand350.Name = "gridBand350";
            this.gridBand350.RowCount = 3;
            this.gridBand350.Width = 150;
            this.gridBand352.Caption = "面积";
            this.gridBand352.Children.AddRange(new GridBand[] { this.gridBand353 });
            this.gridBand352.MinWidth = 20;
            this.gridBand352.Name = "gridBand352";
            this.gridBand352.Width = 0x4b;
            this.gridBand353.Caption = "14";
            this.gridBand353.Columns.Add(this.bandedGridColumn151);
            this.gridBand353.Name = "gridBand353";
            this.gridBand353.Width = 0x4b;
            this.bandedGridColumn151.Caption = "bandedGridColumn151";
            this.bandedGridColumn151.Name = "bandedGridColumn151";
            this.bandedGridColumn151.Visible = true;
            this.gridBand354.Caption = "蓄积";
            this.gridBand354.Children.AddRange(new GridBand[] { this.gridBand355 });
            this.gridBand354.MinWidth = 20;
            this.gridBand354.Name = "gridBand354";
            this.gridBand354.Width = 0x4b;
            this.gridBand355.Caption = "15";
            this.gridBand355.Columns.Add(this.bandedGridColumn152);
            this.gridBand355.Name = "gridBand355";
            this.gridBand355.Width = 0x4b;
            this.bandedGridColumn152.Caption = "bandedGridColumn152";
            this.bandedGridColumn152.Name = "bandedGridColumn152";
            this.bandedGridColumn152.Visible = true;
            this.gridBand356.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand356.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridBand356.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand356.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand356.Caption = "四旁树";
            this.gridBand356.Children.AddRange(new GridBand[] { this.gridBand358, this.gridBand359 });
            this.gridBand356.MinWidth = 20;
            this.gridBand356.Name = "gridBand356";
            this.gridBand356.RowCount = 3;
            this.gridBand356.Width = 150;
            this.gridBand358.Caption = "株数";
            this.gridBand358.Children.AddRange(new GridBand[] { this.gridBand357 });
            this.gridBand358.Name = "gridBand358";
            this.gridBand358.Width = 0x4b;
            this.gridBand357.Caption = "16";
            this.gridBand357.Columns.Add(this.bandedGridColumn153);
            this.gridBand357.Name = "gridBand357";
            this.gridBand357.Width = 0x4b;
            this.bandedGridColumn153.Caption = "bandedGridColumn153";
            this.bandedGridColumn153.Name = "bandedGridColumn153";
            this.bandedGridColumn153.Visible = true;
            this.gridBand359.Caption = "蓄积";
            this.gridBand359.Children.AddRange(new GridBand[] { this.gridBand360 });
            this.gridBand359.Name = "gridBand359";
            this.gridBand359.Width = 0x4b;
            this.gridBand360.Caption = "17";
            this.gridBand360.Columns.Add(this.bandedGridColumn154);
            this.gridBand360.Name = "gridBand360";
            this.gridBand360.Width = 0x4b;
            this.bandedGridColumn154.Caption = "bandedGridColumn154";
            this.bandedGridColumn154.Name = "bandedGridColumn154";
            this.bandedGridColumn154.Visible = true;
            this.gridBand361.Caption = "散生木";
            this.gridBand361.Children.AddRange(new GridBand[] { this.gridBand362, this.gridBand364 });
            this.gridBand361.Name = "gridBand361";
            this.gridBand361.RowCount = 3;
            this.gridBand361.Width = 150;
            this.gridBand362.Caption = "株数";
            this.gridBand362.Children.AddRange(new GridBand[] { this.gridBand363 });
            this.gridBand362.Name = "gridBand362";
            this.gridBand362.Width = 0x4b;
            this.gridBand363.Caption = "18";
            this.gridBand363.Columns.Add(this.bandedGridColumn155);
            this.gridBand363.Name = "gridBand363";
            this.gridBand363.Width = 0x4b;
            this.bandedGridColumn155.Caption = "bandedGridColumn155";
            this.bandedGridColumn155.Name = "bandedGridColumn155";
            this.bandedGridColumn155.Visible = true;
            this.gridBand364.Caption = "蓄积";
            this.gridBand364.Children.AddRange(new GridBand[] { this.gridBand365 });
            this.gridBand364.Name = "gridBand364";
            this.gridBand364.Width = 0x4b;
            this.gridBand365.Caption = "19";
            this.gridBand365.Columns.Add(this.bandedGridColumn156);
            this.gridBand365.Name = "gridBand365";
            this.gridBand365.Width = 0x4b;
            this.bandedGridColumn156.Caption = "bandedGridColumn156";
            this.bandedGridColumn156.Name = "bandedGridColumn156";
            this.bandedGridColumn156.Visible = true;
            this.gridBand170.Caption = "非林地乔木林";
            this.gridBand170.Children.AddRange(new GridBand[] { this.gridBand183, this.gridBand283 });
            this.gridBand170.Name = "gridBand170";
            this.gridBand170.RowCount = 3;
            this.gridBand170.Width = 150;
            this.gridBand183.Caption = "面积";
            this.gridBand183.Children.AddRange(new GridBand[] { this.gridBand282 });
            this.gridBand183.Name = "gridBand183";
            this.gridBand183.Width = 0x4b;
            this.gridBand282.Caption = "20";
            this.gridBand282.Columns.Add(this.bandedGridColumn50);
            this.gridBand282.Name = "gridBand282";
            this.gridBand282.Width = 0x4b;
            this.bandedGridColumn50.Caption = "bandedGridColumn50";
            this.bandedGridColumn50.Name = "bandedGridColumn50";
            this.bandedGridColumn50.Visible = true;
            this.gridBand283.Caption = "蓄积";
            this.gridBand283.Children.AddRange(new GridBand[] { this.gridBand284 });
            this.gridBand283.Name = "gridBand283";
            this.gridBand283.Width = 0x4b;
            this.gridBand284.Caption = "21";
            this.gridBand284.Columns.Add(this.bandedGridColumn70);
            this.gridBand284.Name = "gridBand284";
            this.gridBand284.Width = 0x4b;
            this.bandedGridColumn70.Caption = "bandedGridColumn70";
            this.bandedGridColumn70.Name = "bandedGridColumn70";
            this.bandedGridColumn70.Visible = true;
            this.gridView1.BorderStyle = BorderStyles.Simple;
            this.gridView1.GridControl = this.gridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.GView_ZYBH_B5_YCLMJXJBHB.Appearance.BandPanel.Options.UseTextOptions = true;
            this.GView_ZYBH_B5_YCLMJXJBHB.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
            this.GView_ZYBH_B5_YCLMJXJBHB.Appearance.BandPanel.TextOptions.WordWrap = WordWrap.Wrap;
            this.GView_ZYBH_B5_YCLMJXJBHB.Bands.AddRange(new GridBand[] { this.gridBand481, this.gridBand521, this.gridBand281 });
            this.GView_ZYBH_B5_YCLMJXJBHB.BorderStyle = BorderStyles.Simple;
            this.GView_ZYBH_B5_YCLMJXJBHB.Columns.AddRange(new BandedGridColumn[] { this.bandedGridColumn204, this.bandedGridColumn205, this.bandedGridColumn206, this.bandedGridColumn207, this.bandedGridColumn208, this.bandedGridColumn209, this.bandedGridColumn210, this.bandedGridColumn211, this.bandedGridColumn212, this.bandedGridColumn213, this.bandedGridColumn214, this.bandedGridColumn215, this.bandedGridColumn216, this.bandedGridColumn217, this.bandedGridColumn218 });
            this.GView_ZYBH_B5_YCLMJXJBHB.GridControl = this.gridControl;
            this.GView_ZYBH_B5_YCLMJXJBHB.Name = "GView_ZYBH_B5_YCLMJXJBHB";
            this.GView_ZYBH_B5_YCLMJXJBHB.OptionsView.ShowColumnHeaders = false;
            this.GView_ZYBH_B5_YCLMJXJBHB.OptionsView.ShowGroupPanel = false;
            this.gridBand481.Caption = "林种";
            this.gridBand481.Children.AddRange(new GridBand[] { this.gridBand482 });
            this.gridBand481.MinWidth = 20;
            this.gridBand481.Name = "gridBand481";
            this.gridBand481.RowCount = 2;
            this.gridBand481.Visible = false;
            this.gridBand481.Width = 0x4b;
            this.gridBand482.Caption = "4";
            this.gridBand482.Name = "gridBand482";
            this.gridBand482.Visible = false;
            this.gridBand482.Width = 0x4b;
            this.gridBand521.Caption = "亚林种";
            this.gridBand521.Children.AddRange(new GridBand[] { this.gridBand530 });
            this.gridBand521.Name = "gridBand521";
            this.gridBand521.RowCount = 2;
            this.gridBand521.Visible = false;
            this.gridBand521.Width = 0x4b;
            this.gridBand530.Caption = "5";
            this.gridBand530.Name = "gridBand530";
            this.gridBand530.Visible = false;
            this.gridBand530.Width = 0x4b;
            this.gridBand281.AppearanceHeader.Font = new Font("Tahoma", 12f, FontStyle.Bold);
            this.gridBand281.AppearanceHeader.Options.UseFont = true;
            this.gridBand281.Caption = "表5  用材林面积蓄积变化情况表";
            this.gridBand281.Children.AddRange(new GridBand[] { this.gBandZYBHB5DW });
            this.gridBand281.Name = "gridBand281";
            this.gridBand281.RowCount = 2;
            this.gridBand281.Width = 0x465;
            this.gBandZYBHB5DW.AppearanceHeader.Options.UseTextOptions = true;
            this.gBandZYBHB5DW.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Near;
            this.gBandZYBHB5DW.Caption = "gridBand282";
            this.gBandZYBHB5DW.Children.AddRange(new GridBand[] { this.gridBand385, this.gridBand485, this.gridBand483, this.gridBand490, this.gridBand495, this.gridBand500, this.gridBand505, this.gridBand510, this.gridBand515 });
            this.gBandZYBHB5DW.Name = "gBandZYBHB5DW";
            this.gBandZYBHB5DW.Width = 0x465;
            this.gridBand385.Caption = "统计单位";
            this.gridBand385.Children.AddRange(new GridBand[] { this.gridBand480 });
            this.gridBand385.MinWidth = 20;
            this.gridBand385.Name = "gridBand385";
            this.gridBand385.RowCount = 2;
            this.gridBand385.Width = 0x4b;
            this.gridBand480.Caption = "1";
            this.gridBand480.Columns.Add(this.bandedGridColumn204);
            this.gridBand480.Name = "gridBand480";
            this.gridBand480.Width = 0x4b;
            this.bandedGridColumn204.Caption = "bandedGridColumn204";
            this.bandedGridColumn204.Name = "bandedGridColumn204";
            this.bandedGridColumn204.Visible = true;
            this.gridBand485.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand485.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridBand485.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand485.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand485.Caption = "优势树种";
            this.gridBand485.Children.AddRange(new GridBand[] { this.gridBand484 });
            this.gridBand485.MinWidth = 20;
            this.gridBand485.Name = "gridBand485";
            this.gridBand485.RowCount = 2;
            this.gridBand485.Width = 0x4b;
            this.gridBand484.Caption = "2";
            this.gridBand484.Columns.Add(this.bandedGridColumn205);
            this.gridBand484.Name = "gridBand484";
            this.gridBand484.Width = 0x4b;
            this.bandedGridColumn205.Caption = "bandedGridColumn205";
            this.bandedGridColumn205.Name = "bandedGridColumn205";
            this.bandedGridColumn205.Visible = true;
            this.gridBand483.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand483.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridBand483.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand483.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand483.Caption = "年度";
            this.gridBand483.Children.AddRange(new GridBand[] { this.gridBand520 });
            this.gridBand483.MinWidth = 20;
            this.gridBand483.Name = "gridBand483";
            this.gridBand483.RowCount = 2;
            this.gridBand483.Width = 0x4b;
            this.gridBand520.Caption = "3";
            this.gridBand520.Columns.Add(this.bandedGridColumn206);
            this.gridBand520.MinWidth = 20;
            this.gridBand520.Name = "gridBand520";
            this.gridBand520.Width = 0x4b;
            this.bandedGridColumn206.Caption = "bandedGridColumn206";
            this.bandedGridColumn206.Name = "bandedGridColumn206";
            this.bandedGridColumn206.Visible = true;
            this.gridBand490.Caption = "小计";
            this.gridBand490.Children.AddRange(new GridBand[] { this.gridBand491, this.gridBand493 });
            this.gridBand490.MinWidth = 20;
            this.gridBand490.Name = "gridBand490";
            this.gridBand490.Width = 150;
            this.gridBand491.Caption = "面积";
            this.gridBand491.Children.AddRange(new GridBand[] { this.gridBand492 });
            this.gridBand491.Name = "gridBand491";
            this.gridBand491.Width = 0x4b;
            this.gridBand492.Caption = "4";
            this.gridBand492.Columns.Add(this.bandedGridColumn207);
            this.gridBand492.Name = "gridBand492";
            this.gridBand492.Width = 0x4b;
            this.bandedGridColumn207.Caption = "bandedGridColumn207";
            this.bandedGridColumn207.Name = "bandedGridColumn207";
            this.bandedGridColumn207.Visible = true;
            this.gridBand493.Caption = "蓄积";
            this.gridBand493.Children.AddRange(new GridBand[] { this.gridBand494 });
            this.gridBand493.Name = "gridBand493";
            this.gridBand493.Width = 0x4b;
            this.gridBand494.Caption = "5";
            this.gridBand494.Columns.Add(this.bandedGridColumn208);
            this.gridBand494.Name = "gridBand494";
            this.gridBand494.Width = 0x4b;
            this.bandedGridColumn208.Caption = "bandedGridColumn208";
            this.bandedGridColumn208.Name = "bandedGridColumn208";
            this.bandedGridColumn208.Visible = true;
            this.gridBand495.Caption = "幼龄林";
            this.gridBand495.Children.AddRange(new GridBand[] { this.gridBand496, this.gridBand498 });
            this.gridBand495.MinWidth = 20;
            this.gridBand495.Name = "gridBand495";
            this.gridBand495.Width = 150;
            this.gridBand496.Caption = "面积";
            this.gridBand496.Children.AddRange(new GridBand[] { this.gridBand497 });
            this.gridBand496.Name = "gridBand496";
            this.gridBand496.Width = 0x4b;
            this.gridBand497.Caption = "6";
            this.gridBand497.Columns.Add(this.bandedGridColumn209);
            this.gridBand497.Name = "gridBand497";
            this.gridBand497.Width = 0x4b;
            this.bandedGridColumn209.Caption = "bandedGridColumn209";
            this.bandedGridColumn209.Name = "bandedGridColumn209";
            this.bandedGridColumn209.Visible = true;
            this.gridBand498.Caption = "蓄积";
            this.gridBand498.Children.AddRange(new GridBand[] { this.gridBand499 });
            this.gridBand498.Name = "gridBand498";
            this.gridBand498.Width = 0x4b;
            this.gridBand499.Caption = "7";
            this.gridBand499.Columns.Add(this.bandedGridColumn210);
            this.gridBand499.Name = "gridBand499";
            this.gridBand499.Width = 0x4b;
            this.bandedGridColumn210.Caption = "bandedGridColumn210";
            this.bandedGridColumn210.Name = "bandedGridColumn210";
            this.bandedGridColumn210.Visible = true;
            this.gridBand500.Caption = "中龄林";
            this.gridBand500.Children.AddRange(new GridBand[] { this.gridBand501, this.gridBand503 });
            this.gridBand500.Name = "gridBand500";
            this.gridBand500.Width = 150;
            this.gridBand501.Caption = "面积";
            this.gridBand501.Children.AddRange(new GridBand[] { this.gridBand502 });
            this.gridBand501.Name = "gridBand501";
            this.gridBand501.Width = 0x4b;
            this.gridBand502.Caption = "8";
            this.gridBand502.Columns.Add(this.bandedGridColumn211);
            this.gridBand502.Name = "gridBand502";
            this.gridBand502.Width = 0x4b;
            this.bandedGridColumn211.Caption = "bandedGridColumn211";
            this.bandedGridColumn211.Name = "bandedGridColumn211";
            this.bandedGridColumn211.Visible = true;
            this.gridBand503.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand503.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridBand503.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand503.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand503.Caption = "蓄积";
            this.gridBand503.Children.AddRange(new GridBand[] { this.gridBand504 });
            this.gridBand503.Name = "gridBand503";
            this.gridBand503.Width = 0x4b;
            this.gridBand504.Caption = "9";
            this.gridBand504.Columns.Add(this.bandedGridColumn212);
            this.gridBand504.Name = "gridBand504";
            this.gridBand504.Width = 0x4b;
            this.bandedGridColumn212.Caption = "bandedGridColumn212";
            this.bandedGridColumn212.Name = "bandedGridColumn212";
            this.bandedGridColumn212.Visible = true;
            this.gridBand505.Caption = "近熟林";
            this.gridBand505.Children.AddRange(new GridBand[] { this.gridBand506, this.gridBand508 });
            this.gridBand505.Name = "gridBand505";
            this.gridBand505.Width = 150;
            this.gridBand506.Caption = "面积";
            this.gridBand506.Children.AddRange(new GridBand[] { this.gridBand507 });
            this.gridBand506.Name = "gridBand506";
            this.gridBand506.Width = 0x4b;
            this.gridBand507.Caption = "10";
            this.gridBand507.Columns.Add(this.bandedGridColumn213);
            this.gridBand507.Name = "gridBand507";
            this.gridBand507.Width = 0x4b;
            this.bandedGridColumn213.Caption = "bandedGridColumn213";
            this.bandedGridColumn213.Name = "bandedGridColumn213";
            this.bandedGridColumn213.Visible = true;
            this.gridBand508.Caption = "蓄积";
            this.gridBand508.Children.AddRange(new GridBand[] { this.gridBand509 });
            this.gridBand508.Name = "gridBand508";
            this.gridBand508.Width = 0x4b;
            this.gridBand509.Caption = "11";
            this.gridBand509.Columns.Add(this.bandedGridColumn214);
            this.gridBand509.Name = "gridBand509";
            this.gridBand509.Width = 0x4b;
            this.bandedGridColumn214.Caption = "bandedGridColumn214";
            this.bandedGridColumn214.Name = "bandedGridColumn214";
            this.bandedGridColumn214.Visible = true;
            this.gridBand510.Caption = "成熟林";
            this.gridBand510.Children.AddRange(new GridBand[] { this.gridBand511, this.gridBand513 });
            this.gridBand510.Name = "gridBand510";
            this.gridBand510.Width = 150;
            this.gridBand511.Caption = "面积";
            this.gridBand511.Children.AddRange(new GridBand[] { this.gridBand512 });
            this.gridBand511.Name = "gridBand511";
            this.gridBand511.Width = 0x4b;
            this.gridBand512.Caption = "12";
            this.gridBand512.Columns.Add(this.bandedGridColumn215);
            this.gridBand512.Name = "gridBand512";
            this.gridBand512.Width = 0x4b;
            this.bandedGridColumn215.Caption = "bandedGridColumn215";
            this.bandedGridColumn215.Name = "bandedGridColumn215";
            this.bandedGridColumn215.Visible = true;
            this.gridBand513.Caption = "蓄积";
            this.gridBand513.Children.AddRange(new GridBand[] { this.gridBand514 });
            this.gridBand513.Name = "gridBand513";
            this.gridBand513.Width = 0x4b;
            this.gridBand514.Caption = "13";
            this.gridBand514.Columns.Add(this.bandedGridColumn216);
            this.gridBand514.Name = "gridBand514";
            this.gridBand514.Width = 0x4b;
            this.bandedGridColumn216.Caption = "bandedGridColumn216";
            this.bandedGridColumn216.Name = "bandedGridColumn216";
            this.bandedGridColumn216.Visible = true;
            this.gridBand515.Caption = "过熟林";
            this.gridBand515.Children.AddRange(new GridBand[] { this.gridBand516, this.gridBand518 });
            this.gridBand515.Name = "gridBand515";
            this.gridBand515.Width = 150;
            this.gridBand516.Caption = "面积";
            this.gridBand516.Children.AddRange(new GridBand[] { this.gridBand517 });
            this.gridBand516.Name = "gridBand516";
            this.gridBand516.Width = 0x4b;
            this.gridBand517.Caption = "14";
            this.gridBand517.Columns.Add(this.bandedGridColumn217);
            this.gridBand517.Name = "gridBand517";
            this.gridBand517.Width = 0x4b;
            this.bandedGridColumn217.Caption = "bandedGridColumn217";
            this.bandedGridColumn217.Name = "bandedGridColumn217";
            this.bandedGridColumn217.Visible = true;
            this.gridBand518.Caption = "蓄积";
            this.gridBand518.Children.AddRange(new GridBand[] { this.gridBand519 });
            this.gridBand518.Name = "gridBand518";
            this.gridBand518.Width = 0x4b;
            this.gridBand519.Caption = "15";
            this.gridBand519.Columns.Add(this.bandedGridColumn218);
            this.gridBand519.Name = "gridBand519";
            this.gridBand519.Width = 0x4b;
            this.bandedGridColumn218.Caption = "bandedGridColumn218";
            this.bandedGridColumn218.Name = "bandedGridColumn218";
            this.bandedGridColumn218.Visible = true;
            this.GView_GYLDMJBGTJB.Appearance.BandPanel.Options.UseTextOptions = true;
            this.GView_GYLDMJBGTJB.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
            this.GView_GYLDMJBGTJB.Appearance.BandPanel.TextOptions.WordWrap = WordWrap.Wrap;
            this.GView_GYLDMJBGTJB.Bands.AddRange(new GridBand[] { this.gridBand268 });
            this.GView_GYLDMJBGTJB.BorderStyle = BorderStyles.Simple;
            this.GView_GYLDMJBGTJB.Columns.AddRange(new BandedGridColumn[] { 
                this.bandedGridColumn1, this.bandedGridColumn2, this.bandedGridColumn3, this.bandedGridColumn4, this.bandedGridColumn5, this.bandedGridColumn6, this.bandedGridColumn7, this.bandedGridColumn8, this.bandedGridColumn9, this.bandedGridColumn10, this.bandedGridColumn11, this.bandedGridColumn12, this.bandedGridColumn13, this.bandedGridColumn14, this.bandedGridColumn15, this.bandedGridColumn16,
                this.bandedGridColumn17
            });
            this.GView_GYLDMJBGTJB.GridControl = this.gridControl;
            this.GView_GYLDMJBGTJB.Name = "GView_GYLDMJBGTJB";
            this.GView_GYLDMJBGTJB.OptionsView.ShowColumnHeaders = false;
            this.GView_GYLDMJBGTJB.OptionsView.ShowGroupPanel = false;
            this.gridBand268.AppearanceHeader.Font = new Font("Tahoma", 12f, FontStyle.Bold);
            this.gridBand268.AppearanceHeader.Options.UseFont = true;
            this.gridBand268.Caption = "表2 公益林地面积变更统计表";
            this.gridBand268.Children.AddRange(new GridBand[] { this.gBandLDBHB2DWND });
            this.gridBand268.Name = "gridBand268";
            this.gridBand268.RowCount = 2;
            this.gridBand268.Width = 0x50a;
            this.gBandLDBHB2DWND.AppearanceHeader.Options.UseTextOptions = true;
            this.gBandLDBHB2DWND.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Near;
            this.gBandLDBHB2DWND.Caption = "gridBand269";
            this.gBandLDBHB2DWND.Children.AddRange(new GridBand[] { this.gridBand36, this.gridBand52, this.gridBand38, this.gridBand81 });
            this.gBandLDBHB2DWND.Name = "gBandLDBHB2DWND";
            this.gBandLDBHB2DWND.Width = 0x50a;
            this.gridBand36.Caption = "统计单位";
            this.gridBand36.Children.AddRange(new GridBand[] { this.gridBand37 });
            this.gridBand36.Name = "gridBand36";
            this.gridBand36.RowCount = 4;
            this.gridBand36.Width = 90;
            this.gridBand37.Caption = "1";
            this.gridBand37.Columns.Add(this.bandedGridColumn1);
            this.gridBand37.Name = "gridBand37";
            this.gridBand37.Width = 90;
            this.bandedGridColumn1.Caption = "bandedGridColumn1";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.Visible = true;
            this.bandedGridColumn1.Width = 90;
            this.gridBand52.Caption = "合计";
            this.gridBand52.Children.AddRange(new GridBand[] { this.gridBand69 });
            this.gridBand52.MinWidth = 20;
            this.gridBand52.Name = "gridBand52";
            this.gridBand52.RowCount = 4;
            this.gridBand52.Width = 0x4b;
            this.gridBand69.Caption = "2";
            this.gridBand69.Columns.Add(this.bandedGridColumn2);
            this.gridBand69.Name = "gridBand69";
            this.gridBand69.Width = 0x4b;
            this.bandedGridColumn2.Caption = "bandedGridColumn2";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.Visible = true;
            this.gridBand38.Caption = "重点公益林地";
            this.gridBand38.Children.AddRange(new GridBand[] { this.gridBand39, this.gridBand40, this.gridBand65, this.gridBand67 });
            this.gridBand38.Name = "gridBand38";
            this.gridBand38.Width = 750;
            this.gridBand39.Caption = "小计";
            this.gridBand39.Children.AddRange(new GridBand[] { this.gridBand70 });
            this.gridBand39.Name = "gridBand39";
            this.gridBand39.RowCount = 3;
            this.gridBand39.Width = 0x4b;
            this.gridBand70.Caption = "3";
            this.gridBand70.Columns.Add(this.bandedGridColumn3);
            this.gridBand70.Name = "gridBand70";
            this.gridBand70.Width = 0x4b;
            this.bandedGridColumn3.Caption = "bandedGridColumn3";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.Visible = true;
            this.gridBand40.Caption = "公益林";
            this.gridBand40.Children.AddRange(new GridBand[] { this.gridBand59, this.gridBand61, this.gridBand63 });
            this.gridBand40.Name = "gridBand40";
            this.gridBand40.RowCount = 2;
            this.gridBand40.Width = 0xe1;
            this.gridBand59.Caption = "小计";
            this.gridBand59.Children.AddRange(new GridBand[] { this.gridBand60 });
            this.gridBand59.MinWidth = 20;
            this.gridBand59.Name = "gridBand59";
            this.gridBand59.Width = 0x4b;
            this.gridBand60.Caption = "4";
            this.gridBand60.Columns.Add(this.bandedGridColumn4);
            this.gridBand60.Name = "gridBand60";
            this.gridBand60.Width = 0x4b;
            this.bandedGridColumn4.Caption = "bandedGridColumn4";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.Visible = true;
            this.gridBand61.Caption = "防护林";
            this.gridBand61.Children.AddRange(new GridBand[] { this.gridBand62 });
            this.gridBand61.MinWidth = 20;
            this.gridBand61.Name = "gridBand61";
            this.gridBand61.Width = 0x4b;
            this.gridBand62.Caption = "5";
            this.gridBand62.Columns.Add(this.bandedGridColumn5);
            this.gridBand62.Name = "gridBand62";
            this.gridBand62.Width = 0x4b;
            this.bandedGridColumn5.Caption = "bandedGridColumn5";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            this.bandedGridColumn5.Visible = true;
            this.gridBand63.Caption = "特用林";
            this.gridBand63.Children.AddRange(new GridBand[] { this.gridBand64 });
            this.gridBand63.MinWidth = 20;
            this.gridBand63.Name = "gridBand63";
            this.gridBand63.Width = 0x4b;
            this.gridBand64.Caption = "6";
            this.gridBand64.Columns.Add(this.bandedGridColumn6);
            this.gridBand64.Name = "gridBand64";
            this.gridBand64.Width = 0x4b;
            this.bandedGridColumn6.Caption = "bandedGridColumn6";
            this.bandedGridColumn6.Name = "bandedGridColumn6";
            this.bandedGridColumn6.Visible = true;
            this.gridBand65.Caption = "其它林地";
            this.gridBand65.Children.AddRange(new GridBand[] { this.gridBand66 });
            this.gridBand65.MinWidth = 20;
            this.gridBand65.Name = "gridBand65";
            this.gridBand65.RowCount = 3;
            this.gridBand65.Width = 0x4b;
            this.gridBand66.Caption = "7";
            this.gridBand66.Columns.Add(this.bandedGridColumn7);
            this.gridBand66.Name = "gridBand66";
            this.gridBand66.Width = 0x4b;
            this.bandedGridColumn7.Caption = "bandedGridColumn7";
            this.bandedGridColumn7.Name = "bandedGridColumn7";
            this.bandedGridColumn7.Visible = true;
            this.gridBand67.Caption = "其中，国家级公益林地";
            this.gridBand67.Children.AddRange(new GridBand[] { this.gridBand71, this.gridBand72, this.gridBand79 });
            this.gridBand67.MinWidth = 20;
            this.gridBand67.Name = "gridBand67";
            this.gridBand67.Width = 0x177;
            this.gridBand71.Caption = "小计";
            this.gridBand71.Children.AddRange(new GridBand[] { this.gridBand68 });
            this.gridBand71.Name = "gridBand71";
            this.gridBand71.RowCount = 2;
            this.gridBand71.Width = 0x4b;
            this.gridBand68.Caption = "8";
            this.gridBand68.Columns.Add(this.bandedGridColumn8);
            this.gridBand68.Name = "gridBand68";
            this.gridBand68.Width = 0x4b;
            this.bandedGridColumn8.Caption = "bandedGridColumn8";
            this.bandedGridColumn8.Name = "bandedGridColumn8";
            this.bandedGridColumn8.Visible = true;
            this.gridBand72.Caption = "公益林";
            this.gridBand72.Children.AddRange(new GridBand[] { this.gridBand73, this.gridBand75, this.gridBand77 });
            this.gridBand72.Name = "gridBand72";
            this.gridBand72.Width = 0xe1;
            this.gridBand73.Caption = "小计";
            this.gridBand73.Children.AddRange(new GridBand[] { this.gridBand74 });
            this.gridBand73.Name = "gridBand73";
            this.gridBand73.Width = 0x4b;
            this.gridBand74.Caption = "9";
            this.gridBand74.Columns.Add(this.bandedGridColumn9);
            this.gridBand74.Name = "gridBand74";
            this.gridBand74.Width = 0x4b;
            this.bandedGridColumn9.Caption = "bandedGridColumn9";
            this.bandedGridColumn9.Name = "bandedGridColumn9";
            this.bandedGridColumn9.Visible = true;
            this.gridBand75.Caption = "防护林";
            this.gridBand75.Children.AddRange(new GridBand[] { this.gridBand76 });
            this.gridBand75.Name = "gridBand75";
            this.gridBand75.Width = 0x4b;
            this.gridBand76.Caption = "10";
            this.gridBand76.Columns.Add(this.bandedGridColumn10);
            this.gridBand76.Name = "gridBand76";
            this.gridBand76.Width = 0x4b;
            this.bandedGridColumn10.Caption = "bandedGridColumn10";
            this.bandedGridColumn10.Name = "bandedGridColumn10";
            this.bandedGridColumn10.Visible = true;
            this.gridBand77.Caption = "特用林";
            this.gridBand77.Children.AddRange(new GridBand[] { this.gridBand78 });
            this.gridBand77.Name = "gridBand77";
            this.gridBand77.Width = 0x4b;
            this.gridBand78.Caption = "11";
            this.gridBand78.Columns.Add(this.bandedGridColumn11);
            this.gridBand78.Name = "gridBand78";
            this.gridBand78.Width = 0x4b;
            this.bandedGridColumn11.Caption = "bandedGridColumn11";
            this.bandedGridColumn11.Name = "bandedGridColumn11";
            this.bandedGridColumn11.Visible = true;
            this.gridBand79.Caption = "其它林地";
            this.gridBand79.Children.AddRange(new GridBand[] { this.gridBand80 });
            this.gridBand79.Name = "gridBand79";
            this.gridBand79.RowCount = 2;
            this.gridBand79.Width = 0x4b;
            this.gridBand80.Caption = "12";
            this.gridBand80.Columns.Add(this.bandedGridColumn12);
            this.gridBand80.Name = "gridBand80";
            this.gridBand80.Width = 0x4b;
            this.bandedGridColumn12.Caption = "bandedGridColumn12";
            this.bandedGridColumn12.Name = "bandedGridColumn12";
            this.bandedGridColumn12.Visible = true;
            this.gridBand81.Caption = "一般公益林地";
            this.gridBand81.Children.AddRange(new GridBand[] { this.gridBand82, this.gridBand83, this.gridBand92 });
            this.gridBand81.Name = "gridBand81";
            this.gridBand81.RowCount = 2;
            this.gridBand81.Width = 0x177;
            this.gridBand82.Caption = "小计";
            this.gridBand82.Children.AddRange(new GridBand[] { this.gridBand87 });
            this.gridBand82.Name = "gridBand82";
            this.gridBand82.RowCount = 2;
            this.gridBand82.Width = 0x4b;
            this.gridBand87.Caption = "13";
            this.gridBand87.Columns.Add(this.bandedGridColumn13);
            this.gridBand87.Name = "gridBand87";
            this.gridBand87.Width = 0x4b;
            this.bandedGridColumn13.Caption = "bandedGridColumn13";
            this.bandedGridColumn13.Name = "bandedGridColumn13";
            this.bandedGridColumn13.Visible = true;
            this.gridBand83.Caption = "公益林";
            this.gridBand83.Children.AddRange(new GridBand[] { this.gridBand84, this.gridBand85, this.gridBand86 });
            this.gridBand83.Name = "gridBand83";
            this.gridBand83.Width = 0xe1;
            this.gridBand84.Caption = "小计";
            this.gridBand84.Children.AddRange(new GridBand[] { this.gridBand89 });
            this.gridBand84.Name = "gridBand84";
            this.gridBand84.Width = 0x4b;
            this.gridBand89.Caption = "14";
            this.gridBand89.Columns.Add(this.bandedGridColumn14);
            this.gridBand89.Name = "gridBand89";
            this.gridBand89.Width = 0x4b;
            this.bandedGridColumn14.Caption = "bandedGridColumn14";
            this.bandedGridColumn14.Name = "bandedGridColumn14";
            this.bandedGridColumn14.Visible = true;
            this.gridBand85.Caption = "防护林";
            this.gridBand85.Children.AddRange(new GridBand[] { this.gridBand90 });
            this.gridBand85.Name = "gridBand85";
            this.gridBand85.Width = 0x4b;
            this.gridBand90.Caption = "15";
            this.gridBand90.Columns.Add(this.bandedGridColumn15);
            this.gridBand90.Name = "gridBand90";
            this.gridBand90.Width = 0x4b;
            this.bandedGridColumn15.Caption = "bandedGridColumn15";
            this.bandedGridColumn15.Name = "bandedGridColumn15";
            this.bandedGridColumn15.Visible = true;
            this.gridBand86.Caption = "特用林";
            this.gridBand86.Children.AddRange(new GridBand[] { this.gridBand91 });
            this.gridBand86.Name = "gridBand86";
            this.gridBand86.Width = 0x4b;
            this.gridBand91.Caption = "16";
            this.gridBand91.Columns.Add(this.bandedGridColumn16);
            this.gridBand91.Name = "gridBand91";
            this.gridBand91.Width = 0x4b;
            this.bandedGridColumn16.Caption = "bandedGridColumn16";
            this.bandedGridColumn16.Name = "bandedGridColumn16";
            this.bandedGridColumn16.Visible = true;
            this.gridBand92.Caption = "其它林地";
            this.gridBand92.Children.AddRange(new GridBand[] { this.gridBand93 });
            this.gridBand92.Name = "gridBand92";
            this.gridBand92.RowCount = 2;
            this.gridBand92.Width = 0x4b;
            this.gridBand93.Caption = "17";
            this.gridBand93.Columns.Add(this.bandedGridColumn17);
            this.gridBand93.Name = "gridBand93";
            this.gridBand93.Width = 0x4b;
            this.bandedGridColumn17.Caption = "bandedGridColumn17";
            this.bandedGridColumn17.Name = "bandedGridColumn17";
            this.bandedGridColumn17.Visible = true;
            this.GView_GLLDMJBGTJB.Appearance.BandPanel.Options.UseTextOptions = true;
            this.GView_GLLDMJBGTJB.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
            this.GView_GLLDMJBGTJB.Appearance.BandPanel.TextOptions.WordWrap = WordWrap.Wrap;
            this.GView_GLLDMJBGTJB.Bands.AddRange(new GridBand[] { this.gridBand267 });
            this.GView_GLLDMJBGTJB.BorderStyle = BorderStyles.Simple;
            this.GView_GLLDMJBGTJB.Columns.AddRange(new BandedGridColumn[] { this.gCol_TJDW, this.gCol_QS, this.gCol_HJ, this.gCol_YLDXJ, this.gCol_QML, this.gCol_ZL, this.gCol_HSL, this.gCol_SLD, this.gCol_GMLDXJ, this.gCol_GJGML, this.gCol_QTGML, this.gCol_WCLD, this.gCol_MPD, this.gCol_WLMLD, this.gCol_YLD, this.gCol_LYFZSCYD });
            this.GView_GLLDMJBGTJB.GridControl = this.gridControl;
            this.GView_GLLDMJBGTJB.Name = "GView_GLLDMJBGTJB";
            this.GView_GLLDMJBGTJB.OptionsView.ShowColumnHeaders = false;
            this.GView_GLLDMJBGTJB.OptionsView.ShowGroupPanel = false;
            this.GView_GLLDMJBGTJB.RowHeight = 2;
            this.gridBand267.AppearanceHeader.Font = new Font("Tahoma", 12f, FontStyle.Bold);
            this.gridBand267.AppearanceHeader.Options.UseFont = true;
            this.gridBand267.Caption = "表1 各类林地面积变更统计表";
            this.gridBand267.Children.AddRange(new GridBand[] { this.gBandLDBHB1DWND });
            this.gridBand267.Name = "gridBand267";
            this.gridBand267.RowCount = 2;
            this.gridBand267.Width = 0x475;
            this.gBandLDBHB1DWND.AppearanceHeader.Options.UseTextOptions = true;
            this.gBandLDBHB1DWND.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Near;
            this.gBandLDBHB1DWND.Caption = "gridBand268";
            this.gBandLDBHB1DWND.Children.AddRange(new GridBand[] { this.gridBand1, this.gridBand2, this.gridBand3, this.gridBand4, this.gridBand9, this.gridBand10, this.gridBand14, this.gridBand15, this.gridBand16, this.gridBand17, this.gridBand18 });
            this.gBandLDBHB1DWND.Name = "gBandLDBHB1DWND";
            this.gBandLDBHB1DWND.Width = 0x475;
            this.gridBand1.Caption = "统计单位";
            this.gridBand1.Children.AddRange(new GridBand[] { this.gridBand19 });
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.RowCount = 3;
            this.gridBand1.Width = 90;
            this.gridBand19.Caption = "1";
            this.gridBand19.Columns.Add(this.gCol_TJDW);
            this.gridBand19.Name = "gridBand19";
            this.gridBand19.Width = 90;
            this.gCol_TJDW.Caption = "统计单位";
            this.gCol_TJDW.Name = "gCol_TJDW";
            this.gCol_TJDW.Visible = true;
            this.gCol_TJDW.Width = 90;
            this.gridBand2.Caption = "权属";
            this.gridBand2.Children.AddRange(new GridBand[] { this.gridBand20 });
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.RowCount = 3;
            this.gridBand2.Width = 0x4b;
            this.gridBand20.Caption = "2";
            this.gridBand20.Columns.Add(this.gCol_QS);
            this.gridBand20.Name = "gridBand20";
            this.gridBand20.Width = 0x4b;
            this.gCol_QS.Caption = "权属";
            this.gCol_QS.Name = "gCol_QS";
            this.gCol_QS.Visible = true;
            this.gridBand3.Caption = "合计";
            this.gridBand3.Children.AddRange(new GridBand[] { this.gridBand21 });
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.RowCount = 3;
            this.gridBand3.Width = 0x4b;
            this.gridBand21.Caption = "3";
            this.gridBand21.Columns.Add(this.gCol_HJ);
            this.gridBand21.Name = "gridBand21";
            this.gridBand21.Width = 0x4b;
            this.gCol_HJ.Caption = "合计";
            this.gCol_HJ.Name = "gCol_HJ";
            this.gCol_HJ.Visible = true;
            this.gridBand4.Caption = "有林地";
            this.gridBand4.Children.AddRange(new GridBand[] { this.gridBand5, this.gridBand6, this.gridBand7, this.gridBand8 });
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Width = 0x117;
            this.gridBand5.Caption = "小计";
            this.gridBand5.Children.AddRange(new GridBand[] { this.gridBand22 });
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.RowCount = 2;
            this.gridBand5.Width = 0x4a;
            this.gridBand22.Caption = "4";
            this.gridBand22.Columns.Add(this.gCol_YLDXJ);
            this.gridBand22.Name = "gridBand22";
            this.gridBand22.Width = 0x4a;
            this.gCol_YLDXJ.Caption = "有林地小计";
            this.gCol_YLDXJ.Name = "gCol_YLDXJ";
            this.gCol_YLDXJ.Visible = true;
            this.gCol_YLDXJ.Width = 0x4a;
            this.gridBand6.Caption = "乔木林";
            this.gridBand6.Children.AddRange(new GridBand[] { this.gridBand23 });
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.RowCount = 2;
            this.gridBand6.Width = 0x4a;
            this.gridBand23.Caption = "5";
            this.gridBand23.Columns.Add(this.gCol_QML);
            this.gridBand23.Name = "gridBand23";
            this.gridBand23.Width = 0x4a;
            this.gCol_QML.Caption = "乔木林";
            this.gCol_QML.Name = "gCol_QML";
            this.gCol_QML.Visible = true;
            this.gCol_QML.Width = 0x4a;
            this.gridBand7.Caption = "竹林";
            this.gridBand7.Children.AddRange(new GridBand[] { this.gridBand24 });
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.RowCount = 2;
            this.gridBand7.Width = 0x4a;
            this.gridBand24.Caption = "6";
            this.gridBand24.Columns.Add(this.gCol_ZL);
            this.gridBand24.Name = "gridBand24";
            this.gridBand24.Width = 0x4a;
            this.gCol_ZL.Caption = "竹林";
            this.gCol_ZL.Name = "gCol_ZL";
            this.gCol_ZL.Visible = true;
            this.gCol_ZL.Width = 0x4a;
            this.gridBand8.Caption = "红树林";
            this.gridBand8.Children.AddRange(new GridBand[] { this.gridBand25 });
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.RowCount = 2;
            this.gridBand8.Width = 0x39;
            this.gridBand25.Caption = "7";
            this.gridBand25.Columns.Add(this.gCol_HSL);
            this.gridBand25.Name = "gridBand25";
            this.gridBand25.Width = 0x39;
            this.gCol_HSL.Caption = "红树林";
            this.gCol_HSL.Name = "gCol_HSL";
            this.gCol_HSL.Visible = true;
            this.gCol_HSL.Width = 0x39;
            this.gridBand9.Caption = "疏林地";
            this.gridBand9.Children.AddRange(new GridBand[] { this.gridBand26 });
            this.gridBand9.Name = "gridBand9";
            this.gridBand9.RowCount = 3;
            this.gridBand9.Width = 0x3b;
            this.gridBand26.Caption = "8";
            this.gridBand26.Columns.Add(this.gCol_SLD);
            this.gridBand26.Name = "gridBand26";
            this.gridBand26.Width = 0x3b;
            this.gCol_SLD.Caption = "疏林地";
            this.gCol_SLD.Name = "gCol_SLD";
            this.gCol_SLD.Visible = true;
            this.gCol_SLD.Width = 0x3b;
            this.gridBand10.Caption = "灌木林地";
            this.gridBand10.Children.AddRange(new GridBand[] { this.gridBand11, this.gridBand12, this.gridBand13 });
            this.gridBand10.Name = "gridBand10";
            this.gridBand10.Width = 0xdb;
            this.gridBand11.Caption = "小计";
            this.gridBand11.Children.AddRange(new GridBand[] { this.gridBand27 });
            this.gridBand11.Name = "gridBand11";
            this.gridBand11.RowCount = 2;
            this.gridBand11.Width = 0x4b;
            this.gridBand27.Caption = "9";
            this.gridBand27.Columns.Add(this.gCol_GMLDXJ);
            this.gridBand27.Name = "gridBand27";
            this.gridBand27.Width = 0x4b;
            this.gCol_GMLDXJ.Caption = "灌木林小计";
            this.gCol_GMLDXJ.Name = "gCol_GMLDXJ";
            this.gCol_GMLDXJ.Visible = true;
            this.gridBand12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand12.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand12.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand12.Caption = "国家特别规定灌木林";
            this.gridBand12.Children.AddRange(new GridBand[] { this.gridBand28 });
            this.gridBand12.Name = "gridBand12";
            this.gridBand12.RowCount = 2;
            this.gridBand12.Width = 0x45;
            this.gridBand28.Caption = "10";
            this.gridBand28.Columns.Add(this.gCol_GJGML);
            this.gridBand28.Name = "gridBand28";
            this.gridBand28.Width = 0x45;
            this.gCol_GJGML.Caption = "国家特别规定灌木林";
            this.gCol_GJGML.Name = "gCol_GJGML";
            this.gCol_GJGML.Visible = true;
            this.gCol_GJGML.Width = 0x45;
            this.gridBand13.Caption = "其它灌木林";
            this.gridBand13.Children.AddRange(new GridBand[] { this.gridBand29 });
            this.gridBand13.Name = "gridBand13";
            this.gridBand13.RowCount = 2;
            this.gridBand13.Width = 0x4b;
            this.gridBand29.Caption = "11";
            this.gridBand29.Columns.Add(this.gCol_QTGML);
            this.gridBand29.Name = "gridBand29";
            this.gridBand29.Width = 0x4b;
            this.gCol_QTGML.Caption = "其它灌木林";
            this.gCol_QTGML.Name = "gCol_QTGML";
            this.gCol_QTGML.Visible = true;
            this.gridBand14.Caption = "未成林地";
            this.gridBand14.Children.AddRange(new GridBand[] { this.gridBand30 });
            this.gridBand14.Name = "gridBand14";
            this.gridBand14.RowCount = 3;
            this.gridBand14.Width = 0x41;
            this.gridBand30.Caption = "12";
            this.gridBand30.Columns.Add(this.gCol_WCLD);
            this.gridBand30.Name = "gridBand30";
            this.gridBand30.Width = 0x41;
            this.gCol_WCLD.Caption = "未成林地";
            this.gCol_WCLD.Name = "gCol_WCLD";
            this.gCol_WCLD.Visible = true;
            this.gCol_WCLD.Width = 0x41;
            this.gridBand15.Caption = "苗圃地";
            this.gridBand15.Children.AddRange(new GridBand[] { this.gridBand31 });
            this.gridBand15.Name = "gridBand15";
            this.gridBand15.RowCount = 3;
            this.gridBand15.Width = 0x40;
            this.gridBand31.Caption = "13";
            this.gridBand31.Columns.Add(this.gCol_MPD);
            this.gridBand31.Name = "gridBand31";
            this.gridBand31.Width = 0x40;
            this.gCol_MPD.Caption = "苗圃地";
            this.gCol_MPD.Name = "gCol_MPD";
            this.gCol_MPD.Visible = true;
            this.gCol_MPD.Width = 0x40;
            this.gridBand16.Caption = "无立木林地";
            this.gridBand16.Children.AddRange(new GridBand[] { this.gridBand32 });
            this.gridBand16.Name = "gridBand16";
            this.gridBand16.RowCount = 3;
            this.gridBand16.Width = 0x4b;
            this.gridBand32.Caption = "14";
            this.gridBand32.Columns.Add(this.gCol_WLMLD);
            this.gridBand32.Name = "gridBand32";
            this.gridBand32.Width = 0x4b;
            this.gCol_WLMLD.Caption = "无立木林地";
            this.gCol_WLMLD.Name = "gCol_WLMLD";
            this.gCol_WLMLD.Visible = true;
            this.gridBand17.Caption = "宜林地";
            this.gridBand17.Children.AddRange(new GridBand[] { this.gridBand33 });
            this.gridBand17.Name = "gridBand17";
            this.gridBand17.RowCount = 3;
            this.gridBand17.Width = 0x4b;
            this.gridBand33.Caption = "15";
            this.gridBand33.Columns.Add(this.gCol_YLD);
            this.gridBand33.Name = "gridBand33";
            this.gridBand33.Width = 0x4b;
            this.gCol_YLD.Caption = "宜林地";
            this.gCol_YLD.Name = "gCol_YLD";
            this.gCol_YLD.Visible = true;
            this.gridBand18.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand18.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand18.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand18.Caption = "林业辅助生产用地";
            this.gridBand18.Children.AddRange(new GridBand[] { this.gridBand34 });
            this.gridBand18.Name = "gridBand18";
            this.gridBand18.RowCount = 3;
            this.gridBand18.Width = 0x41;
            this.gridBand34.Caption = "16";
            this.gridBand34.Columns.Add(this.gCol_LYFZSCYD);
            this.gridBand34.Name = "gridBand34";
            this.gridBand34.Width = 0x41;
            this.gCol_LYFZSCYD.Caption = "林业辅助生产用地";
            this.gCol_LYFZSCYD.Name = "gCol_LYFZSCYD";
            this.gCol_LYFZSCYD.Visible = true;
            this.gCol_LYFZSCYD.Width = 0x41;
            this.GView_ZYBH_B4_ZYSZMJXJBHB.Appearance.BandPanel.Options.UseTextOptions = true;
            this.GView_ZYBH_B4_ZYSZMJXJBHB.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
            this.GView_ZYBH_B4_ZYSZMJXJBHB.Appearance.BandPanel.TextOptions.WordWrap = WordWrap.Wrap;
            this.GView_ZYBH_B4_ZYSZMJXJBHB.Bands.AddRange(new GridBand[] { this.gridBand280 });
            this.GView_ZYBH_B4_ZYSZMJXJBHB.BorderStyle = BorderStyles.Simple;
            this.GView_ZYBH_B4_ZYSZMJXJBHB.Columns.AddRange(new BandedGridColumn[] { this.bandedGridColumn73, this.bandedGridColumn74, this.bandedGridColumn75, this.bandedGridColumn76, this.bandedGridColumn77, this.bandedGridColumn78, this.bandedGridColumn79, this.bandedGridColumn80, this.bandedGridColumn116, this.bandedGridColumn117 });
            this.GView_ZYBH_B4_ZYSZMJXJBHB.GridControl = this.gridControl;
            this.GView_ZYBH_B4_ZYSZMJXJBHB.Name = "GView_ZYBH_B4_ZYSZMJXJBHB";
            this.GView_ZYBH_B4_ZYSZMJXJBHB.OptionsView.ShowColumnHeaders = false;
            this.GView_ZYBH_B4_ZYSZMJXJBHB.OptionsView.ShowGroupPanel = false;
            this.gridBand280.AppearanceHeader.Font = new Font("Tahoma", 12f, FontStyle.Bold);
            this.gridBand280.AppearanceHeader.Options.UseFont = true;
            this.gridBand280.Caption = "表4  各主要树种面积蓄积变化情况表";
            this.gridBand280.Children.AddRange(new GridBand[] { this.gBandZYBHB4DW });
            this.gridBand280.Name = "gridBand280";
            this.gridBand280.RowCount = 2;
            this.gridBand280.Width = 750;
            this.gBandZYBHB4DW.AppearanceHeader.Options.UseTextOptions = true;
            this.gBandZYBHB4DW.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Near;
            this.gBandZYBHB4DW.Caption = "gridBand281";
            this.gBandZYBHB4DW.Children.AddRange(new GridBand[] { this.gridBand262, this.gridBand264, this.gridBand272, this.gridBand277, this.gridBand322, this.gridBand351 });
            this.gBandZYBHB4DW.Name = "gBandZYBHB4DW";
            this.gBandZYBHB4DW.Width = 750;
            this.gridBand262.Caption = "统计单位";
            this.gridBand262.Children.AddRange(new GridBand[] { this.gridBand263 });
            this.gridBand262.MinWidth = 20;
            this.gridBand262.Name = "gridBand262";
            this.gridBand262.RowCount = 2;
            this.gridBand262.Width = 0x4b;
            this.gridBand263.Caption = "1";
            this.gridBand263.Columns.Add(this.bandedGridColumn73);
            this.gridBand263.Name = "gridBand263";
            this.gridBand263.Width = 0x4b;
            this.bandedGridColumn73.Caption = "bandedGridColumn73";
            this.bandedGridColumn73.Name = "bandedGridColumn73";
            this.bandedGridColumn73.Visible = true;
            this.gridBand264.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand264.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridBand264.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand264.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand264.Caption = "树种";
            this.gridBand264.Children.AddRange(new GridBand[] { this.gridBand265 });
            this.gridBand264.MinWidth = 20;
            this.gridBand264.Name = "gridBand264";
            this.gridBand264.RowCount = 2;
            this.gridBand264.Width = 0x4b;
            this.gridBand265.Caption = "2";
            this.gridBand265.Columns.Add(this.bandedGridColumn74);
            this.gridBand265.Name = "gridBand265";
            this.gridBand265.Width = 0x4b;
            this.bandedGridColumn74.Caption = "bandedGridColumn74";
            this.bandedGridColumn74.Name = "bandedGridColumn74";
            this.bandedGridColumn74.Visible = true;
            this.gridBand272.Caption = "前期";
            this.gridBand272.Children.AddRange(new GridBand[] { this.gridBand273, this.gridBand275 });
            this.gridBand272.MinWidth = 20;
            this.gridBand272.Name = "gridBand272";
            this.gridBand272.Width = 150;
            this.gridBand273.Caption = "面积";
            this.gridBand273.Children.AddRange(new GridBand[] { this.gridBand307 });
            this.gridBand273.Name = "gridBand273";
            this.gridBand273.Width = 0x4b;
            this.gridBand307.Caption = "3";
            this.gridBand307.Columns.Add(this.bandedGridColumn75);
            this.gridBand307.Name = "gridBand307";
            this.gridBand307.Width = 0x4b;
            this.bandedGridColumn75.Caption = "bandedGridColumn75";
            this.bandedGridColumn75.Name = "bandedGridColumn75";
            this.bandedGridColumn75.Visible = true;
            this.gridBand275.Caption = "蓄积";
            this.gridBand275.Children.AddRange(new GridBand[] { this.gridBand308 });
            this.gridBand275.Name = "gridBand275";
            this.gridBand275.Width = 0x4b;
            this.gridBand308.Caption = "4";
            this.gridBand308.Columns.Add(this.bandedGridColumn76);
            this.gridBand308.Name = "gridBand308";
            this.gridBand308.Width = 0x4b;
            this.bandedGridColumn76.Caption = "bandedGridColumn76";
            this.bandedGridColumn76.Name = "bandedGridColumn76";
            this.bandedGridColumn76.Visible = true;
            this.gridBand277.Caption = "后期";
            this.gridBand277.Children.AddRange(new GridBand[] { this.gridBand278, this.gridBand319 });
            this.gridBand277.MinWidth = 20;
            this.gridBand277.Name = "gridBand277";
            this.gridBand277.Width = 150;
            this.gridBand278.Caption = "面积";
            this.gridBand278.Children.AddRange(new GridBand[] { this.gridBand309 });
            this.gridBand278.Name = "gridBand278";
            this.gridBand278.Width = 0x4b;
            this.gridBand309.Caption = "5";
            this.gridBand309.Columns.Add(this.bandedGridColumn77);
            this.gridBand309.Name = "gridBand309";
            this.gridBand309.Width = 0x4b;
            this.bandedGridColumn77.Caption = "bandedGridColumn77";
            this.bandedGridColumn77.Name = "bandedGridColumn77";
            this.bandedGridColumn77.Visible = true;
            this.gridBand319.Caption = "蓄积";
            this.gridBand319.Children.AddRange(new GridBand[] { this.gridBand321 });
            this.gridBand319.Name = "gridBand319";
            this.gridBand319.Width = 0x4b;
            this.gridBand321.Caption = "6";
            this.gridBand321.Columns.Add(this.bandedGridColumn78);
            this.gridBand321.Name = "gridBand321";
            this.gridBand321.Width = 0x4b;
            this.bandedGridColumn78.Caption = "bandedGridColumn78";
            this.bandedGridColumn78.Name = "bandedGridColumn78";
            this.bandedGridColumn78.Visible = true;
            this.gridBand322.Caption = "变化量";
            this.gridBand322.Children.AddRange(new GridBand[] { this.gridBand323, this.gridBand327 });
            this.gridBand322.Name = "gridBand322";
            this.gridBand322.Width = 150;
            this.gridBand323.Caption = "面积";
            this.gridBand323.Children.AddRange(new GridBand[] { this.gridBand326 });
            this.gridBand323.Name = "gridBand323";
            this.gridBand323.Width = 0x4b;
            this.gridBand326.Caption = "7";
            this.gridBand326.Columns.Add(this.bandedGridColumn79);
            this.gridBand326.Name = "gridBand326";
            this.gridBand326.Width = 0x4b;
            this.bandedGridColumn79.Caption = "bandedGridColumn79";
            this.bandedGridColumn79.Name = "bandedGridColumn79";
            this.bandedGridColumn79.Visible = true;
            this.gridBand327.Caption = "蓄积";
            this.gridBand327.Children.AddRange(new GridBand[] { this.gridBand338 });
            this.gridBand327.Name = "gridBand327";
            this.gridBand327.Width = 0x4b;
            this.gridBand338.Caption = "8";
            this.gridBand338.Columns.Add(this.bandedGridColumn80);
            this.gridBand338.Name = "gridBand338";
            this.gridBand338.Width = 0x4b;
            this.bandedGridColumn80.Caption = "bandedGridColumn80";
            this.bandedGridColumn80.Name = "bandedGridColumn80";
            this.bandedGridColumn80.Visible = true;
            this.gridBand351.Caption = "变化率(%)";
            this.gridBand351.Children.AddRange(new GridBand[] { this.gridBand366, this.gridBand368 });
            this.gridBand351.Name = "gridBand351";
            this.gridBand351.Width = 150;
            this.gridBand366.Caption = "面积";
            this.gridBand366.Children.AddRange(new GridBand[] { this.gridBand367 });
            this.gridBand366.Name = "gridBand366";
            this.gridBand366.Width = 0x4b;
            this.gridBand367.Caption = "9";
            this.gridBand367.Columns.Add(this.bandedGridColumn116);
            this.gridBand367.Name = "gridBand367";
            this.gridBand367.Width = 0x4b;
            this.bandedGridColumn116.Caption = "bandedGridColumn116";
            this.bandedGridColumn116.Name = "bandedGridColumn116";
            this.bandedGridColumn116.Visible = true;
            this.gridBand368.Caption = "蓄积";
            this.gridBand368.Children.AddRange(new GridBand[] { this.gridBand369 });
            this.gridBand368.Name = "gridBand368";
            this.gridBand368.Width = 0x4b;
            this.gridBand369.Caption = "10";
            this.gridBand369.Columns.Add(this.bandedGridColumn117);
            this.gridBand369.Name = "gridBand369";
            this.gridBand369.Width = 0x4b;
            this.bandedGridColumn117.Caption = "bandedGridColumn117";
            this.bandedGridColumn117.Name = "bandedGridColumn117";
            this.bandedGridColumn117.Visible = true;
            this.GView_ZYBH_B3_GLZMJXJBHB.Appearance.BandPanel.Options.UseTextOptions = true;
            this.GView_ZYBH_B3_GLZMJXJBHB.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
            this.GView_ZYBH_B3_GLZMJXJBHB.Appearance.BandPanel.TextOptions.WordWrap = WordWrap.Wrap;
            this.GView_ZYBH_B3_GLZMJXJBHB.Bands.AddRange(new GridBand[] { this.gridBand97, this.gridBand101, this.gridBand115, this.gridBand279 });
            this.GView_ZYBH_B3_GLZMJXJBHB.BorderStyle = BorderStyles.Simple;
            this.GView_ZYBH_B3_GLZMJXJBHB.Columns.AddRange(new BandedGridColumn[] { this.bandedGridColumn56, this.bandedGridColumn57, this.bandedGridColumn58, this.bandedGridColumn59, this.bandedGridColumn60, this.bandedGridColumn61, this.bandedGridColumn62, this.bandedGridColumn63, this.bandedGridColumn64, this.bandedGridColumn65, this.bandedGridColumn66, this.bandedGridColumn67, this.bandedGridColumn68, this.bandedGridColumn69 });
            this.GView_ZYBH_B3_GLZMJXJBHB.GridControl = this.gridControl;
            this.GView_ZYBH_B3_GLZMJXJBHB.Name = "GView_ZYBH_B3_GLZMJXJBHB";
            this.GView_ZYBH_B3_GLZMJXJBHB.OptionsView.ShowColumnHeaders = false;
            this.GView_ZYBH_B3_GLZMJXJBHB.OptionsView.ShowGroupPanel = false;
            this.gridBand97.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand97.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridBand97.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand97.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand97.Caption = "优势树种";
            this.gridBand97.Children.AddRange(new GridBand[] { this.gridBand98 });
            this.gridBand97.MinWidth = 20;
            this.gridBand97.Name = "gridBand97";
            this.gridBand97.RowCount = 2;
            this.gridBand97.Visible = false;
            this.gridBand97.Width = 0x4b;
            this.gridBand98.Caption = "2";
            this.gridBand98.Name = "gridBand98";
            this.gridBand98.Visible = false;
            this.gridBand98.Width = 0x4b;
            this.gridBand101.Caption = "林种";
            this.gridBand101.Children.AddRange(new GridBand[] { this.gridBand102 });
            this.gridBand101.MinWidth = 20;
            this.gridBand101.Name = "gridBand101";
            this.gridBand101.RowCount = 2;
            this.gridBand101.Visible = false;
            this.gridBand101.Width = 0x4b;
            this.gridBand102.Caption = "4";
            this.gridBand102.Name = "gridBand102";
            this.gridBand102.Visible = false;
            this.gridBand102.Width = 0x4b;
            this.gridBand115.Caption = "亚林种";
            this.gridBand115.Children.AddRange(new GridBand[] { this.gridBand116 });
            this.gridBand115.MinWidth = 20;
            this.gridBand115.Name = "gridBand115";
            this.gridBand115.RowCount = 2;
            this.gridBand115.Visible = false;
            this.gridBand115.Width = 0x4b;
            this.gridBand116.Caption = "5";
            this.gridBand116.Name = "gridBand116";
            this.gridBand116.Visible = false;
            this.gridBand116.Width = 0x4b;
            this.gridBand279.AppearanceHeader.Font = new Font("Tahoma", 12f, FontStyle.Bold);
            this.gridBand279.AppearanceHeader.Options.UseFont = true;
            this.gridBand279.Caption = "表3  各林种面积蓄积变化情况表";
            this.gridBand279.Children.AddRange(new GridBand[] { this.gBandZYBHB3DW });
            this.gridBand279.Name = "gridBand279";
            this.gridBand279.RowCount = 2;
            this.gridBand279.Width = 0x436;
            this.gBandZYBHB3DW.AppearanceHeader.Options.UseTextOptions = true;
            this.gBandZYBHB3DW.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Near;
            this.gBandZYBHB3DW.Caption = "gridBand280";
            this.gBandZYBHB3DW.Children.AddRange(new GridBand[] { this.gridBand95, this.gridBand99, this.gridBand117, this.gridBand122, this.gridBand127, this.gridBand132, this.gridBand585, this.gridBand590 });
            this.gBandZYBHB3DW.Name = "gBandZYBHB3DW";
            this.gBandZYBHB3DW.Width = 0x436;
            this.gridBand95.Caption = "统计单位";
            this.gridBand95.Children.AddRange(new GridBand[] { this.gridBand96 });
            this.gridBand95.MinWidth = 20;
            this.gridBand95.Name = "gridBand95";
            this.gridBand95.RowCount = 2;
            this.gridBand95.Width = 0x4b;
            this.gridBand96.Caption = "1";
            this.gridBand96.Columns.Add(this.bandedGridColumn56);
            this.gridBand96.Name = "gridBand96";
            this.gridBand96.Width = 0x4b;
            this.bandedGridColumn56.Caption = "bandedGridColumn204";
            this.bandedGridColumn56.Name = "bandedGridColumn56";
            this.bandedGridColumn56.Visible = true;
            this.gridBand99.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand99.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridBand99.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand99.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand99.Caption = "年度";
            this.gridBand99.Children.AddRange(new GridBand[] { this.gridBand100 });
            this.gridBand99.MinWidth = 20;
            this.gridBand99.Name = "gridBand99";
            this.gridBand99.RowCount = 2;
            this.gridBand99.Width = 0x4b;
            this.gridBand100.Caption = "2";
            this.gridBand100.Columns.Add(this.bandedGridColumn57);
            this.gridBand100.MinWidth = 20;
            this.gridBand100.Name = "gridBand100";
            this.gridBand100.Width = 0x4b;
            this.bandedGridColumn57.Caption = "bandedGridColumn205";
            this.bandedGridColumn57.Name = "bandedGridColumn57";
            this.bandedGridColumn57.Visible = true;
            this.gridBand117.Caption = "小计";
            this.gridBand117.Children.AddRange(new GridBand[] { this.gridBand118, this.gridBand120 });
            this.gridBand117.MinWidth = 20;
            this.gridBand117.Name = "gridBand117";
            this.gridBand117.Width = 150;
            this.gridBand118.Caption = "面积";
            this.gridBand118.Children.AddRange(new GridBand[] { this.gridBand595 });
            this.gridBand118.Name = "gridBand118";
            this.gridBand118.Width = 0x4b;
            this.gridBand595.Caption = "3";
            this.gridBand595.Columns.Add(this.bandedGridColumn58);
            this.gridBand595.Name = "gridBand595";
            this.gridBand595.Width = 0x4b;
            this.bandedGridColumn58.Caption = "bandedGridColumn206";
            this.bandedGridColumn58.Name = "bandedGridColumn58";
            this.bandedGridColumn58.Visible = true;
            this.gridBand120.Caption = "蓄积";
            this.gridBand120.Children.AddRange(new GridBand[] { this.gridBand119 });
            this.gridBand120.Name = "gridBand120";
            this.gridBand120.Width = 0x4b;
            this.gridBand119.Caption = "4";
            this.gridBand119.Columns.Add(this.bandedGridColumn59);
            this.gridBand119.Name = "gridBand119";
            this.gridBand119.Width = 0x4b;
            this.bandedGridColumn59.Caption = "bandedGridColumn207";
            this.bandedGridColumn59.Name = "bandedGridColumn59";
            this.bandedGridColumn59.Visible = true;
            this.gridBand122.Caption = "防护林";
            this.gridBand122.Children.AddRange(new GridBand[] { this.gridBand123, this.gridBand125 });
            this.gridBand122.MinWidth = 20;
            this.gridBand122.Name = "gridBand122";
            this.gridBand122.Width = 0x9f;
            this.gridBand123.Caption = "面积";
            this.gridBand123.Children.AddRange(new GridBand[] { this.gridBand121 });
            this.gridBand123.Name = "gridBand123";
            this.gridBand123.Width = 0x49;
            this.gridBand121.Caption = "5";
            this.gridBand121.Columns.Add(this.bandedGridColumn60);
            this.gridBand121.Name = "gridBand121";
            this.gridBand121.Width = 0x49;
            this.bandedGridColumn60.Caption = "bandedGridColumn208";
            this.bandedGridColumn60.Name = "bandedGridColumn60";
            this.bandedGridColumn60.Visible = true;
            this.bandedGridColumn60.Width = 0x49;
            this.gridBand125.Caption = "蓄积";
            this.gridBand125.Children.AddRange(new GridBand[] { this.gridBand124 });
            this.gridBand125.Name = "gridBand125";
            this.gridBand125.Width = 0x56;
            this.gridBand124.Caption = "6";
            this.gridBand124.Columns.Add(this.bandedGridColumn61);
            this.gridBand124.Name = "gridBand124";
            this.gridBand124.Width = 0x56;
            this.bandedGridColumn61.Caption = "bandedGridColumn209";
            this.bandedGridColumn61.Name = "bandedGridColumn61";
            this.bandedGridColumn61.Visible = true;
            this.bandedGridColumn61.Width = 0x56;
            this.gridBand127.Caption = "特用林";
            this.gridBand127.Children.AddRange(new GridBand[] { this.gridBand128, this.gridBand130 });
            this.gridBand127.MinWidth = 20;
            this.gridBand127.Name = "gridBand127";
            this.gridBand127.Width = 0xa9;
            this.gridBand128.Caption = "面积";
            this.gridBand128.Children.AddRange(new GridBand[] { this.gridBand126 });
            this.gridBand128.Name = "gridBand128";
            this.gridBand128.Width = 0x58;
            this.gridBand126.Caption = "7";
            this.gridBand126.Columns.Add(this.bandedGridColumn62);
            this.gridBand126.Name = "gridBand126";
            this.gridBand126.Width = 0x58;
            this.bandedGridColumn62.Caption = "bandedGridColumn210";
            this.bandedGridColumn62.Name = "bandedGridColumn62";
            this.bandedGridColumn62.Visible = true;
            this.bandedGridColumn62.Width = 0x58;
            this.gridBand130.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand130.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridBand130.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand130.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand130.Caption = "蓄积";
            this.gridBand130.Children.AddRange(new GridBand[] { this.gridBand129 });
            this.gridBand130.Name = "gridBand130";
            this.gridBand130.Width = 0x51;
            this.gridBand129.Caption = "8";
            this.gridBand129.Columns.Add(this.bandedGridColumn63);
            this.gridBand129.Name = "gridBand129";
            this.gridBand129.Width = 0x51;
            this.bandedGridColumn63.Caption = "bandedGridColumn211";
            this.bandedGridColumn63.Name = "bandedGridColumn63";
            this.bandedGridColumn63.Visible = true;
            this.bandedGridColumn63.Width = 0x51;
            this.gridBand132.Caption = "用材林";
            this.gridBand132.Children.AddRange(new GridBand[] { this.gridBand133, this.gridBand583 });
            this.gridBand132.MinWidth = 20;
            this.gridBand132.Name = "gridBand132";
            this.gridBand132.Width = 150;
            this.gridBand133.Caption = "面积";
            this.gridBand133.Children.AddRange(new GridBand[] { this.gridBand131 });
            this.gridBand133.Name = "gridBand133";
            this.gridBand133.Width = 0x4b;
            this.gridBand131.Caption = "9";
            this.gridBand131.Columns.Add(this.bandedGridColumn64);
            this.gridBand131.Name = "gridBand131";
            this.gridBand131.Width = 0x4b;
            this.bandedGridColumn64.Caption = "bandedGridColumn212";
            this.bandedGridColumn64.Name = "bandedGridColumn64";
            this.bandedGridColumn64.Visible = true;
            this.gridBand583.Caption = "蓄积";
            this.gridBand583.Children.AddRange(new GridBand[] { this.gridBand582 });
            this.gridBand583.Name = "gridBand583";
            this.gridBand583.Width = 0x4b;
            this.gridBand582.Caption = "10";
            this.gridBand582.Columns.Add(this.bandedGridColumn65);
            this.gridBand582.Name = "gridBand582";
            this.gridBand582.Width = 0x4b;
            this.bandedGridColumn65.Caption = "bandedGridColumn213";
            this.bandedGridColumn65.Name = "bandedGridColumn65";
            this.bandedGridColumn65.Visible = true;
            this.gridBand585.Caption = "薪炭林";
            this.gridBand585.Children.AddRange(new GridBand[] { this.gridBand586, this.gridBand588 });
            this.gridBand585.MinWidth = 20;
            this.gridBand585.Name = "gridBand585";
            this.gridBand585.Width = 150;
            this.gridBand586.Caption = "面积";
            this.gridBand586.Children.AddRange(new GridBand[] { this.gridBand584 });
            this.gridBand586.Name = "gridBand586";
            this.gridBand586.Width = 0x4b;
            this.gridBand584.Caption = "11";
            this.gridBand584.Columns.Add(this.bandedGridColumn66);
            this.gridBand584.Name = "gridBand584";
            this.gridBand584.Width = 0x4b;
            this.bandedGridColumn66.Caption = "bandedGridColumn214";
            this.bandedGridColumn66.Name = "bandedGridColumn66";
            this.bandedGridColumn66.Visible = true;
            this.gridBand588.Caption = "蓄积";
            this.gridBand588.Children.AddRange(new GridBand[] { this.gridBand587 });
            this.gridBand588.Name = "gridBand588";
            this.gridBand588.Width = 0x4b;
            this.gridBand587.Caption = "12";
            this.gridBand587.Columns.Add(this.bandedGridColumn67);
            this.gridBand587.Name = "gridBand587";
            this.gridBand587.Width = 0x4b;
            this.bandedGridColumn67.Caption = "bandedGridColumn215";
            this.bandedGridColumn67.Name = "bandedGridColumn67";
            this.bandedGridColumn67.Visible = true;
            this.gridBand590.Caption = "经济林";
            this.gridBand590.Children.AddRange(new GridBand[] { this.gridBand591, this.gridBand593 });
            this.gridBand590.MinWidth = 20;
            this.gridBand590.Name = "gridBand590";
            this.gridBand590.Width = 150;
            this.gridBand591.Caption = "面积";
            this.gridBand591.Children.AddRange(new GridBand[] { this.gridBand589 });
            this.gridBand591.Name = "gridBand591";
            this.gridBand591.Width = 0x4b;
            this.gridBand589.Caption = "13";
            this.gridBand589.Columns.Add(this.bandedGridColumn68);
            this.gridBand589.Name = "gridBand589";
            this.gridBand589.Width = 0x4b;
            this.bandedGridColumn68.Caption = "bandedGridColumn216";
            this.bandedGridColumn68.Name = "bandedGridColumn68";
            this.bandedGridColumn68.Visible = true;
            this.gridBand593.Caption = "蓄积";
            this.gridBand593.Children.AddRange(new GridBand[] { this.gridBand592, this.gridBand594 });
            this.gridBand593.Name = "gridBand593";
            this.gridBand593.Width = 0x4b;
            this.gridBand592.Caption = "14";
            this.gridBand592.Columns.Add(this.bandedGridColumn69);
            this.gridBand592.Name = "gridBand592";
            this.gridBand592.Width = 0x4b;
            this.bandedGridColumn69.Caption = "bandedGridColumn217";
            this.bandedGridColumn69.Name = "bandedGridColumn69";
            this.bandedGridColumn69.Visible = true;
            this.gridBand594.Caption = "15";
            this.gridBand594.Name = "gridBand594";
            this.gridBand594.Visible = false;
            this.gridBand594.Width = 0x4b;
            this.GView_LDBHYYFXTJB.Appearance.BandPanel.Options.UseTextOptions = true;
            this.GView_LDBHYYFXTJB.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
            this.GView_LDBHYYFXTJB.Appearance.BandPanel.TextOptions.WordWrap = WordWrap.Wrap;
            this.GView_LDBHYYFXTJB.Bands.AddRange(new GridBand[] { this.gridBand271 });
            this.GView_LDBHYYFXTJB.BorderStyle = BorderStyles.Simple;
            this.GView_LDBHYYFXTJB.Columns.AddRange(new BandedGridColumn[] { this.bandedGridColumn43, this.bandedGridColumn44, this.bandedGridColumn45, this.bandedGridColumn46, this.bandedGridColumn47, this.bandedGridColumn48, this.bandedGridColumn49, this.bandedGridColumn51, this.bandedGridColumn52, this.bandedGridColumn53, this.bandedGridColumn54, this.bandedGridColumn55 });
            this.GView_LDBHYYFXTJB.GridControl = this.gridControl;
            this.GView_LDBHYYFXTJB.Name = "GView_LDBHYYFXTJB";
            this.GView_LDBHYYFXTJB.OptionsView.ShowColumnHeaders = false;
            this.GView_LDBHYYFXTJB.OptionsView.ShowGroupPanel = false;
            this.GView_LDBHYYFXTJB.RowHeight = 2;
            this.gridBand271.AppearanceHeader.Font = new Font("Tahoma", 12f, FontStyle.Bold);
            this.gridBand271.AppearanceHeader.Options.UseFont = true;
            this.gridBand271.Caption = "表5 林地变化原因分析统计表";
            this.gridBand271.Children.AddRange(new GridBand[] { this.gBandLDBHB5DWND });
            this.gridBand271.Name = "gridBand271";
            this.gridBand271.RowCount = 2;
            this.gridBand271.Width = 0x393;
            this.gBandLDBHB5DWND.AppearanceHeader.Options.UseTextOptions = true;
            this.gBandLDBHB5DWND.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Near;
            this.gBandLDBHB5DWND.Caption = "gridBand274";
            this.gBandLDBHB5DWND.Children.AddRange(new GridBand[] { this.gridBand163, this.gridBand164, this.gridBand165, this.gridBand166, this.gridBand167, this.gridBand168, this.gridBand169, this.gridBand171, this.gridBand172, this.gridBand173, this.gridBand174, this.gridBand180 });
            this.gBandLDBHB5DWND.Name = "gBandLDBHB5DWND";
            this.gBandLDBHB5DWND.Width = 0x393;
            this.gridBand163.Caption = "统计单位";
            this.gridBand163.Children.AddRange(new GridBand[] { this.gridBand176 });
            this.gridBand163.Name = "gridBand163";
            this.gridBand163.RowCount = 2;
            this.gridBand163.Width = 90;
            this.gridBand176.Caption = "1";
            this.gridBand176.Columns.Add(this.bandedGridColumn43);
            this.gridBand176.Name = "gridBand176";
            this.gridBand176.Width = 90;
            this.bandedGridColumn43.Caption = "bandedGridColumn43";
            this.bandedGridColumn43.Name = "bandedGridColumn43";
            this.bandedGridColumn43.Visible = true;
            this.bandedGridColumn43.Width = 90;
            this.gridBand164.Caption = "前期地类";
            this.gridBand164.Children.AddRange(new GridBand[] { this.gridBand177 });
            this.gridBand164.Name = "gridBand164";
            this.gridBand164.RowCount = 2;
            this.gridBand164.Width = 0x4b;
            this.gridBand177.Caption = "2";
            this.gridBand177.Columns.Add(this.bandedGridColumn44);
            this.gridBand177.Name = "gridBand177";
            this.gridBand177.Width = 0x4b;
            this.bandedGridColumn44.Caption = "bandedGridColumn44";
            this.bandedGridColumn44.Name = "bandedGridColumn44";
            this.bandedGridColumn44.Visible = true;
            this.gridBand165.Caption = "后期地类";
            this.gridBand165.Children.AddRange(new GridBand[] { this.gridBand178 });
            this.gridBand165.Name = "gridBand165";
            this.gridBand165.RowCount = 2;
            this.gridBand165.Width = 0x4b;
            this.gridBand178.Caption = "3";
            this.gridBand178.Columns.Add(this.bandedGridColumn45);
            this.gridBand178.Name = "gridBand178";
            this.gridBand178.Width = 0x4b;
            this.bandedGridColumn45.Caption = "bandedGridColumn45";
            this.bandedGridColumn45.Name = "bandedGridColumn45";
            this.bandedGridColumn45.Visible = true;
            this.gridBand166.Caption = "合计";
            this.gridBand166.Children.AddRange(new GridBand[] { this.gridBand175 });
            this.gridBand166.Name = "gridBand166";
            this.gridBand166.RowCount = 2;
            this.gridBand166.Width = 0x4b;
            this.gridBand175.Caption = "4";
            this.gridBand175.Columns.Add(this.bandedGridColumn46);
            this.gridBand175.Name = "gridBand175";
            this.gridBand175.Width = 0x4b;
            this.bandedGridColumn46.Caption = "bandedGridColumn46";
            this.bandedGridColumn46.Name = "bandedGridColumn46";
            this.bandedGridColumn46.Visible = true;
            this.gridBand167.Caption = "造林更新";
            this.gridBand167.Children.AddRange(new GridBand[] { this.gridBand179 });
            this.gridBand167.Name = "gridBand167";
            this.gridBand167.RowCount = 2;
            this.gridBand167.Width = 0x4b;
            this.gridBand179.Caption = "5";
            this.gridBand179.Columns.Add(this.bandedGridColumn47);
            this.gridBand179.Name = "gridBand179";
            this.gridBand179.Width = 0x4b;
            this.bandedGridColumn47.Caption = "bandedGridColumn47";
            this.bandedGridColumn47.Name = "bandedGridColumn47";
            this.bandedGridColumn47.Visible = true;
            this.gridBand168.Caption = "森林采伐";
            this.gridBand168.Children.AddRange(new GridBand[] { this.gridBand181 });
            this.gridBand168.Name = "gridBand168";
            this.gridBand168.RowCount = 2;
            this.gridBand168.Width = 0x4b;
            this.gridBand181.Caption = "6";
            this.gridBand181.Columns.Add(this.bandedGridColumn48);
            this.gridBand181.Name = "gridBand181";
            this.gridBand181.Width = 0x4b;
            this.bandedGridColumn48.Caption = "bandedGridColumn48";
            this.bandedGridColumn48.Name = "bandedGridColumn48";
            this.bandedGridColumn48.Visible = true;
            this.gridBand169.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand169.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            this.gridBand169.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand169.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand169.Caption = "规划调整";
            this.gridBand169.Children.AddRange(new GridBand[] { this.gridBand182 });
            this.gridBand169.Name = "gridBand169";
            this.gridBand169.RowCount = 2;
            this.gridBand169.Width = 0x4b;
            this.gridBand182.Caption = "7";
            this.gridBand182.Columns.Add(this.bandedGridColumn49);
            this.gridBand182.Name = "gridBand182";
            this.gridBand182.Width = 0x4b;
            this.bandedGridColumn49.Caption = "bandedGridColumn49";
            this.bandedGridColumn49.Name = "bandedGridColumn49";
            this.bandedGridColumn49.Visible = true;
            this.gridBand171.Caption = "占用征收";
            this.gridBand171.Children.AddRange(new GridBand[] { this.gridBand184 });
            this.gridBand171.Name = "gridBand171";
            this.gridBand171.RowCount = 2;
            this.gridBand171.Width = 0x4b;
            this.gridBand184.Caption = "8";
            this.gridBand184.Columns.Add(this.bandedGridColumn51);
            this.gridBand184.Name = "gridBand184";
            this.gridBand184.Width = 0x4b;
            this.bandedGridColumn51.Caption = "bandedGridColumn51";
            this.bandedGridColumn51.Name = "bandedGridColumn51";
            this.bandedGridColumn51.Visible = true;
            this.gridBand172.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand172.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand172.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand172.Caption = "毁林开垦";
            this.gridBand172.Children.AddRange(new GridBand[] { this.gridBand185 });
            this.gridBand172.Name = "gridBand172";
            this.gridBand172.RowCount = 2;
            this.gridBand172.Width = 0x4b;
            this.gridBand185.Caption = "9";
            this.gridBand185.Columns.Add(this.bandedGridColumn52);
            this.gridBand185.Name = "gridBand185";
            this.gridBand185.Width = 0x4b;
            this.bandedGridColumn52.Caption = "bandedGridColumn52";
            this.bandedGridColumn52.Name = "bandedGridColumn52";
            this.bandedGridColumn52.Visible = true;
            this.gridBand173.Caption = "灾害因素";
            this.gridBand173.Children.AddRange(new GridBand[] { this.gridBand186 });
            this.gridBand173.Name = "gridBand173";
            this.gridBand173.RowCount = 2;
            this.gridBand173.Width = 0x4b;
            this.gridBand186.Caption = "10";
            this.gridBand186.Columns.Add(this.bandedGridColumn53);
            this.gridBand186.Name = "gridBand186";
            this.gridBand186.Width = 0x4b;
            this.bandedGridColumn53.Caption = "bandedGridColumn53";
            this.bandedGridColumn53.Name = "bandedGridColumn53";
            this.bandedGridColumn53.Visible = true;
            this.gridBand174.Caption = "自然因素";
            this.gridBand174.Children.AddRange(new GridBand[] { this.gridBand187 });
            this.gridBand174.Name = "gridBand174";
            this.gridBand174.RowCount = 2;
            this.gridBand174.Width = 0x4b;
            this.gridBand187.Caption = "11";
            this.gridBand187.Columns.Add(this.bandedGridColumn54);
            this.gridBand187.Name = "gridBand187";
            this.gridBand187.Width = 0x4b;
            this.bandedGridColumn54.Caption = "bandedGridColumn54";
            this.bandedGridColumn54.Name = "bandedGridColumn54";
            this.bandedGridColumn54.Visible = true;
            this.gridBand180.Caption = "调查因素";
            this.gridBand180.Children.AddRange(new GridBand[] { this.gridBand188 });
            this.gridBand180.Name = "gridBand180";
            this.gridBand180.RowCount = 2;
            this.gridBand180.Width = 0x4b;
            this.gridBand188.Caption = "12";
            this.gridBand188.Columns.Add(this.bandedGridColumn55);
            this.gridBand188.Name = "gridBand188";
            this.gridBand188.Width = 0x4b;
            this.bandedGridColumn55.Caption = "bandedGridColumn55";
            this.bandedGridColumn55.Name = "bandedGridColumn55";
            this.bandedGridColumn55.Visible = true;
            this.GView_GLLDDTZYTJB.Appearance.BandPanel.Options.UseTextOptions = true;
            this.GView_GLLDDTZYTJB.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
            this.GView_GLLDDTZYTJB.Appearance.BandPanel.TextOptions.WordWrap = WordWrap.Wrap;
            this.GView_GLLDDTZYTJB.Bands.AddRange(new GridBand[] { this.gridBand270 });
            this.GView_GLLDDTZYTJB.BorderStyle = BorderStyles.Simple;
            this.GView_GLLDDTZYTJB.Columns.AddRange(new BandedGridColumn[] { this.bandedGridColumn32, this.bandedGridColumn33, this.bandedGridColumn34, this.bandedGridColumn35, this.bandedGridColumn36, this.bandedGridColumn37, this.bandedGridColumn38, this.bandedGridColumn39, this.bandedGridColumn40, this.bandedGridColumn41, this.bandedGridColumn42 });
            this.GView_GLLDDTZYTJB.GridControl = this.gridControl;
            this.GView_GLLDDTZYTJB.Name = "GView_GLLDDTZYTJB";
            this.GView_GLLDDTZYTJB.OptionsView.ShowColumnHeaders = false;
            this.GView_GLLDDTZYTJB.OptionsView.ShowGroupPanel = false;
            this.gridBand270.AppearanceHeader.Font = new Font("Tahoma", 12f, FontStyle.Bold);
            this.gridBand270.AppearanceHeader.Options.UseFont = true;
            this.gridBand270.Caption = "表4 林地与非林地动态转移统计表";
            this.gridBand270.Children.AddRange(new GridBand[] { this.gBandLDBHB4DWND });
            this.gridBand270.Name = "gridBand270";
            this.gridBand270.RowCount = 2;
            this.gridBand270.Width = 0x33c;
            this.gBandLDBHB4DWND.AppearanceHeader.Options.UseTextOptions = true;
            this.gBandLDBHB4DWND.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Near;
            this.gBandLDBHB4DWND.Caption = "gridBand271";
            this.gBandLDBHB4DWND.Children.AddRange(new GridBand[] { this.gridBand139, this.gridBand140, this.gridBand141, this.gridBand142, this.gridBand143, this.gridBand144, this.gridBand145, this.gridBand146, this.gridBand147, this.gridBand148, this.gridBand149 });
            this.gBandLDBHB4DWND.Name = "gBandLDBHB4DWND";
            this.gBandLDBHB4DWND.Width = 0x33c;
            this.gridBand139.Caption = "统计单位";
            this.gridBand139.Children.AddRange(new GridBand[] { this.gridBand150 });
            this.gridBand139.Name = "gridBand139";
            this.gridBand139.RowCount = 2;
            this.gridBand139.Width = 90;
            this.gridBand150.Caption = "1";
            this.gridBand150.Columns.Add(this.bandedGridColumn32);
            this.gridBand150.Name = "gridBand150";
            this.gridBand150.Width = 90;
            this.bandedGridColumn32.Caption = "bandedGridColumn32";
            this.bandedGridColumn32.Name = "bandedGridColumn32";
            this.bandedGridColumn32.Visible = true;
            this.bandedGridColumn32.Width = 90;
            this.gridBand140.Caption = "项目";
            this.gridBand140.Children.AddRange(new GridBand[] { this.gridBand151 });
            this.gridBand140.Name = "gridBand140";
            this.gridBand140.RowCount = 2;
            this.gridBand140.Width = 0x4b;
            this.gridBand151.Caption = "2";
            this.gridBand151.Columns.Add(this.bandedGridColumn33);
            this.gridBand151.Name = "gridBand151";
            this.gridBand151.Width = 0x4b;
            this.bandedGridColumn33.Caption = "bandedGridColumn33";
            this.bandedGridColumn33.Name = "bandedGridColumn33";
            this.bandedGridColumn33.Visible = true;
            this.gridBand141.Caption = "合计";
            this.gridBand141.Children.AddRange(new GridBand[] { this.gridBand152 });
            this.gridBand141.Name = "gridBand141";
            this.gridBand141.RowCount = 2;
            this.gridBand141.Width = 0x4b;
            this.gridBand152.Caption = "3";
            this.gridBand152.Columns.Add(this.bandedGridColumn34);
            this.gridBand152.Name = "gridBand152";
            this.gridBand152.Width = 0x4b;
            this.bandedGridColumn34.Caption = "bandedGridColumn34";
            this.bandedGridColumn34.Name = "bandedGridColumn34";
            this.bandedGridColumn34.Visible = true;
            this.gridBand142.Caption = "有林地";
            this.gridBand142.Children.AddRange(new GridBand[] { this.gridBand153 });
            this.gridBand142.Name = "gridBand142";
            this.gridBand142.RowCount = 2;
            this.gridBand142.Width = 0x4b;
            this.gridBand153.Caption = "4";
            this.gridBand153.Columns.Add(this.bandedGridColumn35);
            this.gridBand153.Name = "gridBand153";
            this.gridBand153.Width = 0x4b;
            this.bandedGridColumn35.Caption = "bandedGridColumn35";
            this.bandedGridColumn35.Name = "bandedGridColumn35";
            this.bandedGridColumn35.Visible = true;
            this.gridBand143.Caption = "疏林地";
            this.gridBand143.Children.AddRange(new GridBand[] { this.gridBand154 });
            this.gridBand143.Name = "gridBand143";
            this.gridBand143.RowCount = 2;
            this.gridBand143.Width = 0x4b;
            this.gridBand154.Caption = "5";
            this.gridBand154.Columns.Add(this.bandedGridColumn36);
            this.gridBand154.Name = "gridBand154";
            this.gridBand154.Width = 0x4b;
            this.bandedGridColumn36.Caption = "bandedGridColumn36";
            this.bandedGridColumn36.Name = "bandedGridColumn36";
            this.bandedGridColumn36.Visible = true;
            this.gridBand144.Caption = "灌木林地";
            this.gridBand144.Children.AddRange(new GridBand[] { this.gridBand155 });
            this.gridBand144.Name = "gridBand144";
            this.gridBand144.RowCount = 2;
            this.gridBand144.Width = 0x4b;
            this.gridBand155.Caption = "6";
            this.gridBand155.Columns.Add(this.bandedGridColumn37);
            this.gridBand155.Name = "gridBand155";
            this.gridBand155.Width = 0x4b;
            this.bandedGridColumn37.Caption = "bandedGridColumn37";
            this.bandedGridColumn37.Name = "bandedGridColumn37";
            this.bandedGridColumn37.Visible = true;
            this.gridBand145.Caption = "未成林地";
            this.gridBand145.Children.AddRange(new GridBand[] { this.gridBand156 });
            this.gridBand145.Name = "gridBand145";
            this.gridBand145.RowCount = 2;
            this.gridBand145.Width = 0x4b;
            this.gridBand156.Caption = "7";
            this.gridBand156.Columns.Add(this.bandedGridColumn38);
            this.gridBand156.Name = "gridBand156";
            this.gridBand156.Width = 0x4b;
            this.bandedGridColumn38.Caption = "bandedGridColumn38";
            this.bandedGridColumn38.Name = "bandedGridColumn38";
            this.bandedGridColumn38.Visible = true;
            this.gridBand146.Caption = "苗圃地";
            this.gridBand146.Children.AddRange(new GridBand[] { this.gridBand157 });
            this.gridBand146.Name = "gridBand146";
            this.gridBand146.RowCount = 2;
            this.gridBand146.Width = 0x4b;
            this.gridBand157.Caption = "8";
            this.gridBand157.Columns.Add(this.bandedGridColumn39);
            this.gridBand157.Name = "gridBand157";
            this.gridBand157.Width = 0x4b;
            this.bandedGridColumn39.Caption = "bandedGridColumn39";
            this.bandedGridColumn39.Name = "bandedGridColumn39";
            this.bandedGridColumn39.Visible = true;
            this.gridBand147.Caption = "无立木林地";
            this.gridBand147.Children.AddRange(new GridBand[] { this.gridBand158 });
            this.gridBand147.Name = "gridBand147";
            this.gridBand147.RowCount = 2;
            this.gridBand147.Width = 0x4b;
            this.gridBand158.Caption = "9";
            this.gridBand158.Columns.Add(this.bandedGridColumn40);
            this.gridBand158.Name = "gridBand158";
            this.gridBand158.Width = 0x4b;
            this.bandedGridColumn40.Caption = "bandedGridColumn40";
            this.bandedGridColumn40.Name = "bandedGridColumn40";
            this.bandedGridColumn40.Visible = true;
            this.gridBand148.Caption = "宜林地";
            this.gridBand148.Children.AddRange(new GridBand[] { this.gridBand159 });
            this.gridBand148.Name = "gridBand148";
            this.gridBand148.RowCount = 2;
            this.gridBand148.Width = 0x4b;
            this.gridBand159.Caption = "10";
            this.gridBand159.Columns.Add(this.bandedGridColumn41);
            this.gridBand159.Name = "gridBand159";
            this.gridBand159.Width = 0x4b;
            this.bandedGridColumn41.Caption = "bandedGridColumn41";
            this.bandedGridColumn41.Name = "bandedGridColumn41";
            this.bandedGridColumn41.Visible = true;
            this.gridBand149.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand149.AppearanceHeader.TextOptions.Trimming = Trimming.None;
            this.gridBand149.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            this.gridBand149.Caption = "林业辅助生产用地";
            this.gridBand149.Children.AddRange(new GridBand[] { this.gridBand160 });
            this.gridBand149.Name = "gridBand149";
            this.gridBand149.RowCount = 2;
            this.gridBand149.Width = 0x3f;
            this.gridBand160.Caption = "11";
            this.gridBand160.Columns.Add(this.bandedGridColumn42);
            this.gridBand160.Name = "gridBand160";
            this.gridBand160.Width = 0x3f;
            this.bandedGridColumn42.Caption = "bandedGridColumn42";
            this.bandedGridColumn42.Name = "bandedGridColumn42";
            this.bandedGridColumn42.Visible = true;
            this.bandedGridColumn42.Width = 0x3f;
            this.GView_SPLDMJBGTJB.Appearance.BandPanel.Options.UseTextOptions = true;
            this.GView_SPLDMJBGTJB.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
            this.GView_SPLDMJBGTJB.Appearance.BandPanel.TextOptions.WordWrap = WordWrap.Wrap;
            this.GView_SPLDMJBGTJB.Bands.AddRange(new GridBand[] { this.gridBand269 });
            this.GView_SPLDMJBGTJB.BorderStyle = BorderStyles.Simple;
            this.GView_SPLDMJBGTJB.Columns.AddRange(new BandedGridColumn[] { this.bandedGridColumn18, this.bandedGridColumn19, this.bandedGridColumn20, this.bandedGridColumn21, this.bandedGridColumn22, this.bandedGridColumn23, this.bandedGridColumn24, this.bandedGridColumn25, this.bandedGridColumn26, this.bandedGridColumn27, this.bandedGridColumn28, this.bandedGridColumn29, this.bandedGridColumn30, this.bandedGridColumn31 });
            this.GView_SPLDMJBGTJB.GridControl = this.gridControl;
            this.GView_SPLDMJBGTJB.Name = "GView_SPLDMJBGTJB";
            this.GView_SPLDMJBGTJB.OptionsView.ShowColumnHeaders = false;
            this.GView_SPLDMJBGTJB.OptionsView.ShowGroupPanel = false;
            this.gridBand269.AppearanceHeader.Font = new Font("Tahoma", 12f, FontStyle.Bold);
            this.gridBand269.AppearanceHeader.Options.UseFont = true;
            this.gridBand269.Caption = "表3 商品林地面积变更统计表";
            this.gridBand269.Children.AddRange(new GridBand[] { this.gBandLDBHB3DWND });
            this.gridBand269.Name = "gridBand269";
            this.gridBand269.RowCount = 2;
            this.gridBand269.Width = 0x429;
            this.gBandLDBHB3DWND.AppearanceHeader.Options.UseTextOptions = true;
            this.gBandLDBHB3DWND.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Near;
            this.gBandLDBHB3DWND.Caption = "gridBand270";
            this.gBandLDBHB3DWND.Children.AddRange(new GridBand[] { this.gridBand35, this.gridBand42, this.gridBand44, this.gridBand103 });
            this.gBandLDBHB3DWND.Name = "gBandLDBHB3DWND";
            this.gBandLDBHB3DWND.Width = 0x429;
            this.gridBand35.Caption = "统计单位";
            this.gridBand35.Children.AddRange(new GridBand[] { this.gridBand41 });
            this.gridBand35.MinWidth = 20;
            this.gridBand35.Name = "gridBand35";
            this.gridBand35.RowCount = 4;
            this.gridBand35.Width = 90;
            this.gridBand41.Caption = "1";
            this.gridBand41.Columns.Add(this.bandedGridColumn18);
            this.gridBand41.Name = "gridBand41";
            this.gridBand41.Width = 90;
            this.bandedGridColumn18.Caption = "bandedGridColumn18";
            this.bandedGridColumn18.Name = "bandedGridColumn18";
            this.bandedGridColumn18.Visible = true;
            this.bandedGridColumn18.Width = 90;
            this.gridBand42.Caption = "合计";
            this.gridBand42.Children.AddRange(new GridBand[] { this.gridBand43 });
            this.gridBand42.MinWidth = 20;
            this.gridBand42.Name = "gridBand42";
            this.gridBand42.RowCount = 4;
            this.gridBand42.Width = 0x4b;
            this.gridBand43.Caption = "2";
            this.gridBand43.Columns.Add(this.bandedGridColumn19);
            this.gridBand43.Name = "gridBand43";
            this.gridBand43.Width = 0x4b;
            this.bandedGridColumn19.Caption = "bandedGridColumn19";
            this.bandedGridColumn19.Name = "bandedGridColumn19";
            this.bandedGridColumn19.Visible = true;
            this.gridBand44.Caption = "重点商品林地";
            this.gridBand44.Children.AddRange(new GridBand[] { this.gridBand45, this.gridBand47, this.gridBand55 });
            this.gridBand44.MinWidth = 20;
            this.gridBand44.Name = "gridBand44";
            this.gridBand44.Width = 450;
            this.gridBand45.Caption = "合计";
            this.gridBand45.Children.AddRange(new GridBand[] { this.gridBand46 });
            this.gridBand45.Name = "gridBand45";
            this.gridBand45.RowCount = 3;
            this.gridBand45.Width = 0x4b;
            this.gridBand46.Caption = "3";
            this.gridBand46.Columns.Add(this.bandedGridColumn20);
            this.gridBand46.Name = "gridBand46";
            this.gridBand46.Width = 0x4b;
            this.bandedGridColumn20.Caption = "bandedGridColumn20";
            this.bandedGridColumn20.Name = "bandedGridColumn20";
            this.bandedGridColumn20.Visible = true;
            this.gridBand47.Caption = "商品林";
            this.gridBand47.Children.AddRange(new GridBand[] { this.gridBand48, this.gridBand50, this.gridBand53, this.gridBand57 });
            this.gridBand47.Name = "gridBand47";
            this.gridBand47.Width = 300;
            this.gridBand48.Caption = "小计";
            this.gridBand48.Children.AddRange(new GridBand[] { this.gridBand49 });
            this.gridBand48.MinWidth = 20;
            this.gridBand48.Name = "gridBand48";
            this.gridBand48.RowCount = 2;
            this.gridBand48.Width = 0x4b;
            this.gridBand49.Caption = "4";
            this.gridBand49.Columns.Add(this.bandedGridColumn21);
            this.gridBand49.Name = "gridBand49";
            this.gridBand49.Width = 0x4b;
            this.bandedGridColumn21.Caption = "bandedGridColumn21";
            this.bandedGridColumn21.Name = "bandedGridColumn21";
            this.bandedGridColumn21.Visible = true;
            this.gridBand50.Caption = "用材林";
            this.gridBand50.Children.AddRange(new GridBand[] { this.gridBand51 });
            this.gridBand50.MinWidth = 20;
            this.gridBand50.Name = "gridBand50";
            this.gridBand50.RowCount = 2;
            this.gridBand50.Width = 0x4b;
            this.gridBand51.Caption = "5";
            this.gridBand51.Columns.Add(this.bandedGridColumn22);
            this.gridBand51.Name = "gridBand51";
            this.gridBand51.Width = 0x4b;
            this.bandedGridColumn22.Caption = "bandedGridColumn22";
            this.bandedGridColumn22.Name = "bandedGridColumn22";
            this.bandedGridColumn22.Visible = true;
            this.gridBand53.Caption = "薪炭林";
            this.gridBand53.Children.AddRange(new GridBand[] { this.gridBand54 });
            this.gridBand53.MinWidth = 20;
            this.gridBand53.Name = "gridBand53";
            this.gridBand53.RowCount = 2;
            this.gridBand53.Width = 0x4b;
            this.gridBand54.Caption = "6";
            this.gridBand54.Columns.Add(this.bandedGridColumn23);
            this.gridBand54.Name = "gridBand54";
            this.gridBand54.Width = 0x4b;
            this.bandedGridColumn23.Caption = "bandedGridColumn23";
            this.bandedGridColumn23.Name = "bandedGridColumn23";
            this.bandedGridColumn23.Visible = true;
            this.gridBand57.Caption = "经济林";
            this.gridBand57.Children.AddRange(new GridBand[] { this.gridBand58 });
            this.gridBand57.Name = "gridBand57";
            this.gridBand57.RowCount = 2;
            this.gridBand57.Width = 0x4b;
            this.gridBand58.Caption = "7";
            this.gridBand58.Columns.Add(this.bandedGridColumn24);
            this.gridBand58.Name = "gridBand58";
            this.gridBand58.Width = 0x4b;
            this.bandedGridColumn24.Caption = "bandedGridColumn24";
            this.bandedGridColumn24.Name = "bandedGridColumn24";
            this.bandedGridColumn24.Visible = true;
            this.gridBand55.Caption = "其它林地";
            this.gridBand55.Children.AddRange(new GridBand[] { this.gridBand56 });
            this.gridBand55.MinWidth = 20;
            this.gridBand55.Name = "gridBand55";
            this.gridBand55.RowCount = 3;
            this.gridBand55.Width = 0x4b;
            this.gridBand56.Caption = "8";
            this.gridBand56.Columns.Add(this.bandedGridColumn25);
            this.gridBand56.Name = "gridBand56";
            this.gridBand56.Width = 0x4b;
            this.bandedGridColumn25.Caption = "bandedGridColumn25";
            this.bandedGridColumn25.Name = "bandedGridColumn25";
            this.bandedGridColumn25.Visible = true;
            this.gridBand103.Caption = "一般商品林地";
            this.gridBand103.Children.AddRange(new GridBand[] { this.gridBand104, this.gridBand106, this.gridBand113 });
            this.gridBand103.MinWidth = 20;
            this.gridBand103.Name = "gridBand103";
            this.gridBand103.Width = 450;
            this.gridBand104.Caption = "合计";
            this.gridBand104.Children.AddRange(new GridBand[] { this.gridBand105 });
            this.gridBand104.Name = "gridBand104";
            this.gridBand104.RowCount = 3;
            this.gridBand104.Width = 0x4b;
            this.gridBand105.Caption = "9";
            this.gridBand105.Columns.Add(this.bandedGridColumn26);
            this.gridBand105.Name = "gridBand105";
            this.gridBand105.Width = 0x4b;
            this.bandedGridColumn26.Caption = "bandedGridColumn26";
            this.bandedGridColumn26.Name = "bandedGridColumn26";
            this.bandedGridColumn26.Visible = true;
            this.gridBand106.Caption = "商品林";
            this.gridBand106.Children.AddRange(new GridBand[] { this.gridBand107, this.gridBand109, this.gridBand111, this.gridBand88 });
            this.gridBand106.Name = "gridBand106";
            this.gridBand106.Width = 300;
            this.gridBand107.Caption = "小计";
            this.gridBand107.Children.AddRange(new GridBand[] { this.gridBand108 });
            this.gridBand107.Name = "gridBand107";
            this.gridBand107.RowCount = 2;
            this.gridBand107.Width = 0x4b;
            this.gridBand108.Caption = "10";
            this.gridBand108.Columns.Add(this.bandedGridColumn27);
            this.gridBand108.Name = "gridBand108";
            this.gridBand108.Width = 0x4b;
            this.bandedGridColumn27.Caption = "bandedGridColumn27";
            this.bandedGridColumn27.Name = "bandedGridColumn27";
            this.bandedGridColumn27.Visible = true;
            this.gridBand109.Caption = "用材林";
            this.gridBand109.Children.AddRange(new GridBand[] { this.gridBand110 });
            this.gridBand109.Name = "gridBand109";
            this.gridBand109.RowCount = 2;
            this.gridBand109.Width = 0x4b;
            this.gridBand110.Caption = "11";
            this.gridBand110.Columns.Add(this.bandedGridColumn28);
            this.gridBand110.Name = "gridBand110";
            this.gridBand110.Width = 0x4b;
            this.bandedGridColumn28.Caption = "bandedGridColumn28";
            this.bandedGridColumn28.Name = "bandedGridColumn28";
            this.bandedGridColumn28.Visible = true;
            this.gridBand111.Caption = "薪炭林";
            this.gridBand111.Children.AddRange(new GridBand[] { this.gridBand112 });
            this.gridBand111.Name = "gridBand111";
            this.gridBand111.RowCount = 2;
            this.gridBand111.Width = 0x4b;
            this.gridBand112.Caption = "12";
            this.gridBand112.Columns.Add(this.bandedGridColumn29);
            this.gridBand112.Name = "gridBand112";
            this.gridBand112.Width = 0x4b;
            this.bandedGridColumn29.Caption = "bandedGridColumn29";
            this.bandedGridColumn29.Name = "bandedGridColumn29";
            this.bandedGridColumn29.Visible = true;
            this.gridBand88.Caption = "经济林";
            this.gridBand88.Children.AddRange(new GridBand[] { this.gridBand94 });
            this.gridBand88.Name = "gridBand88";
            this.gridBand88.RowCount = 2;
            this.gridBand88.Width = 0x4b;
            this.gridBand94.Caption = "13";
            this.gridBand94.Columns.Add(this.bandedGridColumn30);
            this.gridBand94.Name = "gridBand94";
            this.gridBand94.Width = 0x4b;
            this.bandedGridColumn30.Caption = "bandedGridColumn30";
            this.bandedGridColumn30.Name = "bandedGridColumn30";
            this.bandedGridColumn30.Visible = true;
            this.gridBand113.Caption = "其它林地";
            this.gridBand113.Children.AddRange(new GridBand[] { this.gridBand114 });
            this.gridBand113.Name = "gridBand113";
            this.gridBand113.RowCount = 3;
            this.gridBand113.Width = 0x4b;
            this.gridBand114.Caption = "14";
            this.gridBand114.Columns.Add(this.bandedGridColumn31);
            this.gridBand114.Name = "gridBand114";
            this.gridBand114.Width = 0x4b;
            this.bandedGridColumn31.Caption = "bandedGridColumn31";
            this.bandedGridColumn31.Name = "bandedGridColumn31";
            this.bandedGridColumn31.Visible = true;
            this.repositoryItemCheckEdit7.Name = "repositoryItemCheckEdit7";
            this.gridBand581.Caption = "gridBand581";
            this.gridBand581.Name = "gridBand581";
            this.barButtonItem4.Caption = "输出";
            this.barButtonItem4.Id = 0x8f;
            this.barButtonItem4.LargeImageIndex = 9;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem3.Caption = "输出";
            this.barButtonItem3.Id = 0x8f;
            this.barButtonItem3.LargeImageIndex = 9;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem5.Caption = "输出";
            this.barButtonItem5.Id = 0x8f;
            this.barButtonItem5.LargeImageIndex = 9;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem6.Caption = "barButtonItem6";
            this.barButtonItem6.Id = 0xb2;
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.ItemClick += new ItemClickEventHandler(this.barButtonItem6_ItemClick);
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(950, 550);
            base.Controls.Add(this.splitContainerControl);
            base.Controls.Add(this.ribbonControl);
            base.Controls.Add(this.ribbonStatusBar);
            base.Icon = (Icon) resources.GetObject("$this.Icon");
            base.Name = "Form1";
            this.Ribbon = this.ribbonControl;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "森林资源管理信息平台报表";
            base.Load += new EventHandler(this.Form1_Load);
            base.Shown += new EventHandler(this.Form1_Shown);
            this.ribbonControl.EndInit();
            this.ribbonImageCollection.EndInit();
            this.printRibbonController1.EndInit();
            this.repositoryItemProgressBar1.EndInit();
            this.repositoryItemZoomTrackBar1.EndInit();
            this.repositoryItemCheckEdit2.EndInit();
            this.repositoryItemCheckEdit3.EndInit();
            this.repositoryItemCheckEdit4.EndInit();
            this.repositoryItemCheckEdit5.EndInit();
            this.repositoryItemCheckEdit6.EndInit();
            this.repositoryItemCheckEdit9.EndInit();
            this.repositoryItemCheckEdit10.EndInit();
            this.repositoryItemCheckEdit11.EndInit();
            this.repositoryItemCheckEdit12.EndInit();
            this.repositoryItemCheckEdit14.EndInit();
            this.repositoryItemCheckEdit15.EndInit();
            this.repositoryItemCheckEdit16.EndInit();
            this.ribbonImageCollectionLarge.EndInit();
            this.repositoryItemCheckEdit1.EndInit();
            this.repositoryItemButtonEdit1.EndInit();
            this.repositoryItemCheckEdit8.EndInit();
            this.repositoryItemProgressBar2.EndInit();
            this.repositoryItemCheckEdit13.EndInit();
            this.repositoryItemCheckEdit17.EndInit();
            this.repositoryItemCheckEdit18.EndInit();
            this.repositoryItemCheckEdit19.EndInit();
            this.repositoryItemCheckEdit20.EndInit();
            this.repositoryItemCheckEdit21.EndInit();
            this.repositoryItemComboBox1.EndInit();
            this.repositoryItemPopupContainerEdit1.EndInit();
            this.repositoryItemCheckedComboBoxEdit1.EndInit();
            this.repositoryItemButtonEdit2.EndInit();
            this.navBarControl.EndInit();
            this.splitContainerControl.EndInit();
            this.splitContainerControl.ResumeLayout(false);
            this.gridControl.EndInit();
            this.GView_ZYBH_B1_GLTDMJBHB.EndInit();
            this.GView_ZYBH_B2_GLSLLMMJXJBHB.EndInit();
            this.gridView1.EndInit();
            this.GView_ZYBH_B5_YCLMJXJBHB.EndInit();
            this.GView_GYLDMJBGTJB.EndInit();
            this.GView_GLLDMJBGTJB.EndInit();
            this.GView_ZYBH_B4_ZYSZMJXJBHB.EndInit();
            this.GView_ZYBH_B3_GLZMJXJBHB.EndInit();
            this.GView_LDBHYYFXTJB.EndInit();
            this.GView_GLLDDTZYTJB.EndInit();
            this.GView_SPLDMJBGTJB.EndInit();
            this.repositoryItemCheckEdit7.EndInit();
            base.ResumeLayout(false);
        }

        private void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(this.rgbiSkins, true);
        }

        private void navBarItem_GLLDDTZYTJB_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                this.GView_GLLDDTZYTJB.OptionsBehavior.Editable = false;
                string cmdText = this.pSQL_CreateGLLDDTZYTJB();
                SqlConnection connection = this.SQLDataConfig();
                connection.Open();
                SqlCommand selectCommand = new SqlCommand(cmdText, connection);
                selectCommand.CommandTimeout = 60;
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                connection.Close();
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        if (dataTable.Rows[i][j].ToString().Trim() == "0.00")
                        {
                            dataTable.Rows[i][j] = DBNull.Value;
                        }
                    }
                }
                this.gridControl.DataSource = dataTable;
                if (this.GView_GLLDDTZYTJB.Columns.Count == dataTable.Columns.Count)
                {
                    for (int k = 0; k < this.GView_GLLDDTZYTJB.Columns.Count; k++)
                    {
                        this.GView_GLLDDTZYTJB.Columns[k].FieldName = dataTable.Columns[k].ColumnName;
                    }
                }
                this.gridControl.MainView = this.GView_GLLDDTZYTJB;
                connection.Close();
                this.gBandLDBHB4DWND.Caption = string.Concat(new object[] { this.pNowND, "年      ", this.pXianName, "                 单位：公顷" });
            }
            catch
            {
            }
            finally
            {
                GC.Collect();
            }
        }

        private void navBarItem_GLLDMJBGTJB_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                this.GView_GLLDMJBGTJB.OptionsBehavior.Editable = false;
                string cmdText = this.pSQL_CreateGLLDMJBGTJB();
                SqlConnection connection = this.SQLDataConfig();
                connection.Open();
                SqlCommand selectCommand = new SqlCommand(cmdText, connection);
                selectCommand.CommandTimeout = 60;
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                connection.Close();
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        if (dataTable.Rows[i][j].ToString().Trim() == "0.00")
                        {
                            dataTable.Rows[i][j] = DBNull.Value;
                        }
                    }
                }
                this.gridControl.DataSource = dataTable;
                if (this.GView_GLLDMJBGTJB.Columns.Count == dataTable.Columns.Count)
                {
                    for (int k = 0; k < this.GView_GLLDMJBGTJB.Columns.Count; k++)
                    {
                        this.GView_GLLDMJBGTJB.Columns[k].FieldName = dataTable.Columns[k].ColumnName;
                    }
                }
                this.gridControl.MainView = this.GView_GLLDMJBGTJB;
                this.gBandLDBHB1DWND.Caption = string.Concat(new object[] { this.pNowND, "年      ", this.pXianName, "                 单位：公顷" });
            }
            catch
            {
            }
            finally
            {
                GC.Collect();
            }
        }

        private void navBarItem_GYLDMJBGTJB_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                this.GView_GYLDMJBGTJB.OptionsBehavior.Editable = false;
                string cmdText = this.pSQL_CreateGYLDMJBGTJB();
                SqlConnection connection = this.SQLDataConfig();
                connection.Open();
                SqlCommand selectCommand = new SqlCommand(cmdText, connection);
                selectCommand.CommandTimeout = 60;
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                connection.Close();
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        if (dataTable.Rows[i][j].ToString().Trim() == "0.00")
                        {
                            dataTable.Rows[i][j] = DBNull.Value;
                        }
                    }
                }
                this.gridControl.DataSource = dataTable;
                if (this.GView_GYLDMJBGTJB.Columns.Count == dataTable.Columns.Count)
                {
                    for (int k = 0; k < this.GView_GYLDMJBGTJB.Columns.Count; k++)
                    {
                        this.GView_GYLDMJBGTJB.Columns[k].FieldName = dataTable.Columns[k].ColumnName;
                    }
                }
                this.gridControl.MainView = this.GView_GYLDMJBGTJB;
                connection.Close();
                this.gBandLDBHB2DWND.Caption = string.Concat(new object[] { this.pNowND, "年      ", this.pXianName, "                 单位：公顷" });
            }
            catch
            {
            }
            finally
            {
                GC.Collect();
            }
        }

        private void navBarItem_LDBHYYFXTJB_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                this.GView_LDBHYYFXTJB.OptionsBehavior.Editable = false;
                string cmdText = this.pSQL_CreateLDBHYYFXTJB();
                SqlConnection connection = this.SQLDataConfig();
                connection.Open();
                SqlCommand selectCommand = new SqlCommand(cmdText, connection);
                selectCommand.CommandTimeout = 60;
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                connection.Close();
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        if (dataTable.Rows[i][j].ToString().Trim() == "0.00")
                        {
                            dataTable.Rows[i][j] = DBNull.Value;
                        }
                    }
                }
                this.gridControl.DataSource = dataTable;
                if (this.GView_LDBHYYFXTJB.Columns.Count == dataTable.Columns.Count)
                {
                    for (int k = 0; k < this.GView_LDBHYYFXTJB.Columns.Count; k++)
                    {
                        this.GView_LDBHYYFXTJB.Columns[k].FieldName = dataTable.Columns[k].ColumnName;
                    }
                }
                this.gridControl.MainView = this.GView_LDBHYYFXTJB;
                connection.Close();
                this.gBandLDBHB5DWND.Caption = string.Concat(new object[] { this.pNowND, "年      ", this.pXianName, "                 单位：公顷" });
            }
            catch
            {
            }
            finally
            {
                GC.Collect();
            }
        }

        private void navBarItem_SPLDMJBGTJB_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                this.GView_SPLDMJBGTJB.OptionsBehavior.Editable = false;
                string cmdText = this.pSQL_CreateSPLDMJBGTJB();
                SqlConnection connection = this.SQLDataConfig();
                connection.Open();
                SqlCommand selectCommand = new SqlCommand(cmdText, connection);
                selectCommand.CommandTimeout = 60;
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                connection.Close();
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        if (dataTable.Rows[i][j].ToString().Trim() == "0.00")
                        {
                            dataTable.Rows[i][j] = DBNull.Value;
                        }
                    }
                }
                this.gridControl.DataSource = dataTable;
                if (this.GView_SPLDMJBGTJB.Columns.Count == dataTable.Columns.Count)
                {
                    for (int k = 0; k < this.GView_SPLDMJBGTJB.Columns.Count; k++)
                    {
                        this.GView_SPLDMJBGTJB.Columns[k].FieldName = dataTable.Columns[k].ColumnName;
                    }
                }
                this.gridControl.MainView = this.GView_SPLDMJBGTJB;
                connection.Close();
                this.gBandLDBHB3DWND.Caption = string.Concat(new object[] { this.pNowND, "年      ", this.pXianName, "                 单位：公顷" });
            }
            catch
            {
            }
            finally
            {
                GC.Collect();
            }
        }

        private void navBarItem_ZYBH_B1_GLTDMJBHB_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                this.GView_ZYBH_B1_GLTDMJBHB.OptionsBehavior.Editable = false;
                string cmdText = this.pSQL_ZYBH_B1_GLTDMJBHB();
                SqlConnection connection = this.SQLDataConfig();
                connection.Open();
                SqlCommand selectCommand = new SqlCommand(cmdText, connection);
                selectCommand.CommandTimeout = 60;
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                connection.Close();
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                if (dataTable.Columns.CanRemove(dataTable.Columns["tjdw"]))
                {
                    dataTable.Columns.Remove(dataTable.Columns["tjdw"]);
                }
                dataTable.Columns.Add("id");
                DataTable table = new DataTable();
                table = dataTable.Copy();
                table.Clear();
                DataTable table3 = new DataTable();
                table3 = dataTable.Copy();
                table3.Clear();
                int num = 0;
            Label_00D1:
                if (num >= dataTable.Rows.Count)
                {
                    goto Label_06F0;
                }
                double d = num;
                d /= 2.0;
                dataTable.Rows[num]["id"] = ((Math.Floor(d) * 2.0) + num) + 1.0;
                if (((num + 1) % 2) != 0)
                {
                    goto Label_06DA;
                }
                DataRow row = table.NewRow();
                DataRow row2 = table3.NewRow();
                int num3 = 0;
            Label_0153:
                if (num3 < dataTable.Columns.Count)
                {
                    try
                    {
                        switch (num3)
                        {
                            case 0:
                                row[num3] = dataTable.Rows[num][num3].ToString();
                                row2[num3] = dataTable.Rows[num][num3].ToString();
                                goto Label_06E5;

                            case 1:
                                row[num3] = "变化量";
                                row2[num3] = "变化率(%)";
                                goto Label_06E5;
                        }
                        if (dataTable.Columns[num3].ColumnName == "森林覆盖率")
                        {
                            row[num3] = (Convert.ToDouble(dataTable.Rows[num]["森林覆盖率"]) - Convert.ToDouble(dataTable.Rows[num - 1]["森林覆盖率"])).ToString("f2");
                            row2[num3] = ((Convert.ToDouble(dataTable.Rows[num]["森林覆盖率"]) - Convert.ToDouble(dataTable.Rows[num - 1]["森林覆盖率"])) / Convert.ToDouble(dataTable.Rows[num - 1]["森林覆盖率"])).ToString("f2");
                        }
                        else if (dataTable.Columns[num3].ColumnName == "林木覆盖率")
                        {
                            row[num3] = (Convert.ToDouble(dataTable.Rows[num]["林木覆盖率"]) - Convert.ToDouble(dataTable.Rows[num - 1]["林木覆盖率"])).ToString("f2");
                            row2[num3] = ((Convert.ToDouble(dataTable.Rows[num]["林木覆盖率"]) - Convert.ToDouble(dataTable.Rows[num - 1]["林木覆盖率"])) / Convert.ToDouble(dataTable.Rows[num - 1]["林木覆盖率"])).ToString("f2");
                        }
                        else if (((num3 + 1) % 2) == 0)
                        {
                            row[num3] = Convert.ToDouble((double) (double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString()))).ToString("f1");
                            if (double.Parse(dataTable.Rows[num - 1][num3].ToString()) != 0.0)
                            {
                                try
                                {
                                    row2[num3] = (Convert.ToDouble((double) ((double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString())) / double.Parse(dataTable.Rows[num - 1][num3].ToString()))) * 100.0).ToString("f1");
                                }
                                catch
                                {
                                    row2[num3] = 0;
                                }
                            }
                            else
                            {
                                row2[num3] = 0;
                            }
                        }
                        else
                        {
                            row[num3] = Convert.ToDouble((double) (double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString()))).ToString("f1");
                            if (double.Parse(dataTable.Rows[num - 1][num3].ToString()) != 0.0)
                            {
                                try
                                {
                                    row2[num3] = (Convert.ToDouble((double) ((double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString())) / double.Parse(dataTable.Rows[num - 1][num3].ToString()))) * 100.0).ToString("f1");
                                }
                                catch
                                {
                                    row2[num3] = 0;
                                }
                            }
                            else
                            {
                                row2[num3] = 0;
                            }
                        }
                    }
                    catch
                    {
                    }
                    goto Label_06E5;
                }
                row["id"] = (((Math.Floor(d) * 2.0) + num) + 1.0) + 1.0;
                row2["id"] = (((Math.Floor(d) * 2.0) + num) + 1.0) + 2.0;
                table.Rows.Add(row);
                table3.Rows.Add(row2);
            Label_06DA:
                num++;
                goto Label_00D1;
            Label_06E5:
                num3++;
                goto Label_0153;
            Label_06F0:
                dataTable.Merge(table);
                dataTable.Merge(table3);
                dataTable.Columns.Add("Sortid", typeof(double));
                foreach (DataRow row3 in dataTable.Rows)
                {
                    row3["Sortid"] = Convert.ToDouble(row3["id"]);
                }
                DataView view = new DataView(dataTable);
                view.Sort = "Sortid";
                DataTable table4 = new DataTable();
                dataTable = view.ToTable();
                dataTable.Columns.Remove("id");
                dataTable.Columns.Remove("Sortid");
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        if (((dataTable.Rows[i][j].ToString().Trim() == "0.00") || (dataTable.Rows[i][j].ToString().Trim() == "0.0")) || (dataTable.Rows[i][j].ToString().Trim() == "0"))
                        {
                            dataTable.Rows[i][j] = DBNull.Value;
                        }
                    }
                }
                this.gridControl.DataSource = dataTable;
                if (this.GView_ZYBH_B1_GLTDMJBHB.Columns.Count == dataTable.Columns.Count)
                {
                    for (int k = 0; k < this.GView_ZYBH_B1_GLTDMJBHB.Columns.Count; k++)
                    {
                        this.GView_ZYBH_B1_GLTDMJBHB.Columns[k].FieldName = dataTable.Columns[k].ColumnName;
                    }
                }
                this.gridControl.MainView = this.GView_ZYBH_B1_GLTDMJBHB;
                connection.Close();
                this.gBandZYBHB1DW.Caption = "单位名称：" + this.pXianName + "                    单位：公顷、%";
            }
            catch
            {
            }
            finally
            {
                GC.Collect();
            }
        }

        private void navBarItem_ZYBH_B2_GLSLLMMJXJBHB_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                this.GView_ZYBH_B2_GLSLLMMJXJBHB.OptionsBehavior.Editable = false;
                string cmdText = this.pSQL_ZYBH_B2_GLSLLMMJXJBHB();
                SqlConnection connection = this.SQLDataConfig();
                connection.Open();
                SqlCommand selectCommand = new SqlCommand(cmdText, connection);
                selectCommand.CommandTimeout = 60;
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                connection.Close();
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                if (dataTable.Columns.CanRemove(dataTable.Columns["tjdw"]))
                {
                    dataTable.Columns.Remove(dataTable.Columns["tjdw"]);
                }
                dataTable.Columns.Add("id");
                DataTable table = new DataTable();
                table = dataTable.Copy();
                table.Clear();
                DataTable table3 = new DataTable();
                table3 = dataTable.Copy();
                table3.Clear();
                int num = 0;
            Label_00D1:
                if (num >= dataTable.Rows.Count)
                {
                    goto Label_072B;
                }
                double d = num;
                d /= 2.0;
                dataTable.Rows[num]["id"] = ((Math.Floor(d) * 2.0) + num) + 1.0;
                if (((num + 1) % 2) != 0)
                {
                    goto Label_0715;
                }
                DataRow row = table.NewRow();
                DataRow row2 = table3.NewRow();
                int num3 = 0;
            Label_0153:
                if (num3 < dataTable.Columns.Count)
                {
                    try
                    {
                        switch (num3)
                        {
                            case 0:
                                row[num3] = dataTable.Rows[num][num3].ToString();
                                row2[num3] = dataTable.Rows[num][num3].ToString();
                                goto Label_0720;

                            case 1:
                                row[num3] = "变化量";
                                row2[num3] = "变化率(%)";
                                goto Label_0720;
                        }
                        if ((dataTable.Columns[num3].ColumnName != "森林覆盖率") && (dataTable.Columns[num3].ColumnName != "林木覆盖率"))
                        {
                            if (((num3 + 1) % 2) == 0)
                            {
                                if (num3 == 3)
                                {
                                    row[num3] = Convert.ToDouble((double) (double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString()))).ToString("f1");
                                    try
                                    {
                                        row2[num3] = (Convert.ToDouble((double) ((double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString())) / double.Parse(dataTable.Rows[num - 1][num3].ToString()))) * 100.0).ToString("f1");
                                    }
                                    catch
                                    {
                                        row2[num3] = 0;
                                    }
                                }
                                else
                                {
                                    row[num3] = Convert.ToDouble((double) (double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString()))).ToString("f0");
                                    try
                                    {
                                        row2[num3] = (Convert.ToDouble((double) ((double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString())) / double.Parse(dataTable.Rows[num - 1][num3].ToString()))) * 100.0).ToString("f1");
                                    }
                                    catch
                                    {
                                        row2[num3] = 0;
                                    }
                                }
                            }
                            else if (num3 == 2)
                            {
                                row[num3] = Convert.ToDouble((double) (double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString()))).ToString("f0");
                                try
                                {
                                    row2[num3] = (Convert.ToDouble((double) ((double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString())) / double.Parse(dataTable.Rows[num - 1][num3].ToString()))) * 100.0).ToString("f1");
                                }
                                catch
                                {
                                    row2[num3] = 0;
                                }
                            }
                            else
                            {
                                row[num3] = Convert.ToDouble((double) (double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString()))).ToString("f1");
                                try
                                {
                                    row2[num3] = (Convert.ToDouble((double) ((double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString())) / double.Parse(dataTable.Rows[num - 1][num3].ToString()))) * 100.0).ToString("f1");
                                }
                                catch
                                {
                                    row2[num3] = 0;
                                }
                            }
                        }
                        else
                        {
                            row[num3] = dataTable.Rows[num][num3].ToString();
                            row2[num3] = dataTable.Rows[num][num3].ToString();
                        }
                    }
                    catch
                    {
                    }
                    goto Label_0720;
                }
                row["id"] = (((Math.Floor(d) * 2.0) + num) + 1.0) + 1.0;
                row2["id"] = (((Math.Floor(d) * 2.0) + num) + 1.0) + 2.0;
                table.Rows.Add(row);
                table3.Rows.Add(row2);
            Label_0715:
                num++;
                goto Label_00D1;
            Label_0720:
                num3++;
                goto Label_0153;
            Label_072B:
                dataTable.Merge(table);
                dataTable.Merge(table3);
                dataTable.Columns.Add("Sortid", typeof(double));
                foreach (DataRow row3 in dataTable.Rows)
                {
                    row3["Sortid"] = Convert.ToDouble(row3["id"]);
                }
                DataView view = new DataView(dataTable);
                view.Sort = "Sortid";
                DataTable table4 = new DataTable();
                dataTable = view.ToTable();
                dataTable.Columns.Remove("id");
                dataTable.Columns.Remove("Sortid");
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        if (((dataTable.Rows[i][j].ToString().Trim() == "0.00") || (dataTable.Rows[i][j].ToString().Trim() == "0.0")) || (dataTable.Rows[i][j].ToString().Trim() == "0"))
                        {
                            dataTable.Rows[i][j] = DBNull.Value;
                        }
                    }
                }
                this.gridControl.DataSource = dataTable;
                if (this.GView_ZYBH_B2_GLSLLMMJXJBHB.Columns.Count == dataTable.Columns.Count)
                {
                    for (int k = 0; k < this.GView_ZYBH_B2_GLSLLMMJXJBHB.Columns.Count; k++)
                    {
                        this.GView_ZYBH_B2_GLSLLMMJXJBHB.Columns[k].FieldName = dataTable.Columns[k].ColumnName;
                    }
                }
                this.gridControl.MainView = this.GView_ZYBH_B2_GLSLLMMJXJBHB;
                connection.Close();
                this.gBandZYBHB2DW.Caption = "单位名称：" + this.pXianName + "                    单位：公顷、立方米、万株";
            }
            catch
            {
            }
            finally
            {
                GC.Collect();
            }
        }

        private void navBarItem_ZYBH_B3_GLZMJXJBHB_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                this.GView_ZYBH_B3_GLZMJXJBHB.OptionsBehavior.Editable = false;
                string cmdText = this.pSQL_ZYBH_B3_GLZMJXJBHB();
                SqlConnection connection = this.SQLDataConfig();
                connection.Open();
                SqlCommand selectCommand = new SqlCommand(cmdText, connection);
                selectCommand.CommandTimeout = 60;
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                connection.Close();
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataTable.Columns.Add("id");
                DataTable table = new DataTable();
                table = dataTable.Copy();
                table.Clear();
                DataTable table3 = new DataTable();
                table3 = dataTable.Copy();
                table3.Clear();
                int num = 0;
            Label_0095:
                if (num >= dataTable.Rows.Count)
                {
                    goto Label_04DF;
                }
                double d = num;
                d /= 2.0;
                dataTable.Rows[num]["id"] = ((Math.Floor(d) * 2.0) + num) + 1.0;
                if (((num + 1) % 2) != 0)
                {
                    goto Label_04C9;
                }
                DataRow row = table.NewRow();
                DataRow row2 = table3.NewRow();
                int num3 = 0;
            Label_0117:
                if (num3 < dataTable.Columns.Count)
                {
                    try
                    {
                        switch (num3)
                        {
                            case 0:
                                row[num3] = dataTable.Rows[num][num3].ToString();
                                row2[num3] = dataTable.Rows[num][num3].ToString();
                                goto Label_04D4;

                            case 1:
                                row[num3] = "变化量";
                                row2[num3] = "变化率(%)";
                                goto Label_04D4;
                        }
                        if ((dataTable.Columns[num3].ColumnName != "森林覆盖率") && (dataTable.Columns[num3].ColumnName != "林木覆盖率"))
                        {
                            if (((num3 + 1) % 2) == 0)
                            {
                                row[num3] = Convert.ToDouble((double) (double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString()))).ToString("f0");
                                try
                                {
                                    row2[num3] = (Convert.ToDouble((double) ((double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString())) / double.Parse(dataTable.Rows[num - 1][num3].ToString()))) * 100.0).ToString("f1");
                                }
                                catch
                                {
                                    row2[num3] = 0;
                                }
                            }
                            else
                            {
                                row[num3] = Convert.ToDouble((double) (double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString()))).ToString("f1");
                                try
                                {
                                    row2[num3] = (Convert.ToDouble((double) ((double.Parse(dataTable.Rows[num][num3].ToString()) - double.Parse(dataTable.Rows[num - 1][num3].ToString())) / double.Parse(dataTable.Rows[num - 1][num3].ToString()))) * 100.0).ToString("f1");
                                }
                                catch
                                {
                                    row2[num3] = 0;
                                }
                            }
                        }
                        else
                        {
                            row[num3] = dataTable.Rows[num][num3].ToString();
                            row2[num3] = dataTable.Rows[num][num3].ToString();
                        }
                    }
                    catch
                    {
                    }
                    goto Label_04D4;
                }
                row["id"] = (((Math.Floor(d) * 2.0) + num) + 1.0) + 1.0;
                row2["id"] = (((Math.Floor(d) * 2.0) + num) + 1.0) + 2.0;
                table.Rows.Add(row);
                table3.Rows.Add(row2);
            Label_04C9:
                num++;
                goto Label_0095;
            Label_04D4:
                num3++;
                goto Label_0117;
            Label_04DF:
                dataTable.Merge(table);
                dataTable.Merge(table3);
                dataTable.Columns.Add("Sortid", typeof(double));
                foreach (DataRow row3 in dataTable.Rows)
                {
                    row3["Sortid"] = Convert.ToDouble(row3["id"]);
                }
                DataView view = new DataView(dataTable);
                view.Sort = "Sortid";
                DataTable table4 = new DataTable();
                dataTable = view.ToTable();
                dataTable.Columns.Remove("id");
                dataTable.Columns.Remove("Sortid");
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        if (((dataTable.Rows[i][j].ToString().Trim() == "0.00") || (dataTable.Rows[i][j].ToString().Trim() == "0.0")) || (dataTable.Rows[i][j].ToString().Trim() == "0"))
                        {
                            dataTable.Rows[i][j] = DBNull.Value;
                        }
                    }
                }
                this.gridControl.DataSource = dataTable;
                if (this.GView_ZYBH_B3_GLZMJXJBHB.Columns.Count == dataTable.Columns.Count)
                {
                    for (int k = 0; k < this.GView_ZYBH_B3_GLZMJXJBHB.Columns.Count; k++)
                    {
                        this.GView_ZYBH_B3_GLZMJXJBHB.Columns[k].FieldName = dataTable.Columns[k].ColumnName;
                    }
                }
                this.gridControl.MainView = this.GView_ZYBH_B3_GLZMJXJBHB;
                connection.Close();
                this.gBandZYBHB3DW.Caption = "单位名称：" + this.pXianName + "                    单位：公顷、立方米";
            }
            catch
            {
            }
            finally
            {
                GC.Collect();
            }
        }

        private void navBarItem_ZYBH_B4_ZYSZMJXJBHB_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                this.GView_ZYBH_B4_ZYSZMJXJBHB.OptionsBehavior.Editable = false;
                SqlConnection connection = this.SQLDataConfig();
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("update " + this.pTable_XB_last + " set SZMERGE ='' update " + this.pTable_XB_now + " set SZMERGE ='' select * from " + this.pTable_slszhb, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string str2 = "update " + this.pTable_XB_last + " set SZMERGE = '" + dataTable.Rows[i]["cname"].ToString().Trim() + "' where " + dataTable.Rows[i]["mergerule"].ToString().Trim();
                    selectCommand = new SqlCommand(str2 + " update " + this.pTable_XB_now + " set SZMERGE = '" + dataTable.Rows[i]["cname"].ToString().Trim() + "' where " + dataTable.Rows[i]["mergerule"].ToString().Trim(), connection);
                    adapter = new SqlDataAdapter(selectCommand);
                    DataTable table2 = new DataTable();
                    adapter.Fill(table2);
                }
                selectCommand = new SqlCommand(this.pSQL_ZYBH_B4_ZYSZMJXJBHB(), connection);
                selectCommand.CommandTimeout = 60;
                adapter = new SqlDataAdapter(selectCommand);
                connection.Close();
                dataTable = new DataTable();
                adapter.Fill(dataTable);
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
                this.gridControl.DataSource = dataTable;
                if (this.GView_ZYBH_B4_ZYSZMJXJBHB.Columns.Count == dataTable.Columns.Count)
                {
                    for (int m = 0; m < this.GView_ZYBH_B4_ZYSZMJXJBHB.Columns.Count; m++)
                    {
                        this.GView_ZYBH_B4_ZYSZMJXJBHB.Columns[m].FieldName = dataTable.Columns[m].ColumnName;
                    }
                }
                this.gridControl.MainView = this.GView_ZYBH_B4_ZYSZMJXJBHB;
                connection.Close();
                this.gBandZYBHB4DW.Caption = "单位名称：" + this.pXianName + "                    单位：公顷、立方米";
            }
            catch
            {
            }
            finally
            {
                GC.Collect();
            }
        }

        private void navBarItem_ZYBH_B5_YCLMJXJBHB_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                this.GView_ZYBH_B5_YCLMJXJBHB.OptionsBehavior.Editable = false;
                SqlConnection connection = this.SQLDataConfig();
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("update " + this.pTable_XB_last + " set SZMERGE ='' update " + this.pTable_XB_now + " set SZMERGE =''  select * from " + this.pTable_yclszhb, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string str2 = "update " + this.pTable_XB_last + " set SZMERGE = '" + dataTable.Rows[i]["cname"].ToString().Trim() + "' where " + dataTable.Rows[i]["mergerule"].ToString().Trim();
                    selectCommand = new SqlCommand(str2 + " update " + this.pTable_XB_now + " set SZMERGE = '" + dataTable.Rows[i]["cname"].ToString().Trim() + "' where " + dataTable.Rows[i]["mergerule"].ToString().Trim(), connection);
                    adapter = new SqlDataAdapter(selectCommand);
                    DataTable table2 = new DataTable();
                    adapter.Fill(table2);
                }
                selectCommand = new SqlCommand(this.pSQL_ZYBH_B5_YCLMJXJBHB(), connection);
                selectCommand.CommandTimeout = 60;
                adapter = new SqlDataAdapter(selectCommand);
                connection.Close();
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataTable.Columns.Add("id");
                DataTable table = new DataTable();
                table = dataTable.Copy();
                table.Clear();
                DataTable table4 = new DataTable();
                table4 = dataTable.Copy();
                table4.Clear();
                int num2 = 0;
            Label_0248:
                if (num2 >= dataTable.Rows.Count)
                {
                    goto Label_06A2;
                }
                double d = num2;
                d /= 2.0;
                dataTable.Rows[num2]["id"] = ((Math.Floor(d) * 2.0) + num2) + 1.0;
                if (((num2 + 1) % 2) != 0)
                {
                    goto Label_068C;
                }
                DataRow row = table.NewRow();
                DataRow row2 = table4.NewRow();
                int num4 = 0;
            Label_02CA:
                if (num4 < dataTable.Columns.Count)
                {
                    try
                    {
                        switch (num4)
                        {
                            case 0:
                            case 1:
                                break;

                            case 2:
                                row[num4] = "变化量";
                                row2[num4] = "变化率(%)";
                                goto Label_0697;

                            default:
                                if ((dataTable.Columns[num4].ColumnName != "森林覆盖率") && (dataTable.Columns[num4].ColumnName != "林木覆盖率"))
                                {
                                    if (((num4 + 1) % 2) == 0)
                                    {
                                        row[num4] = Convert.ToDouble((double) (double.Parse(dataTable.Rows[num2][num4].ToString()) - double.Parse(dataTable.Rows[num2 - 1][num4].ToString()))).ToString("f1");
                                        try
                                        {
                                            row2[num4] = (Convert.ToDouble((double) ((double.Parse(dataTable.Rows[num2][num4].ToString()) - double.Parse(dataTable.Rows[num2 - 1][num4].ToString())) / double.Parse(dataTable.Rows[num2 - 1][num4].ToString()))) * 100.0).ToString("f1");
                                        }
                                        catch
                                        {
                                            row2[num4] = 0;
                                        }
                                    }
                                    else
                                    {
                                        row[num4] = Convert.ToDouble((double) (double.Parse(dataTable.Rows[num2][num4].ToString()) - double.Parse(dataTable.Rows[num2 - 1][num4].ToString()))).ToString("f0");
                                        try
                                        {
                                            row2[num4] = (Convert.ToDouble((double) ((double.Parse(dataTable.Rows[num2][num4].ToString()) - double.Parse(dataTable.Rows[num2 - 1][num4].ToString())) / double.Parse(dataTable.Rows[num2 - 1][num4].ToString()))) * 100.0).ToString("f1");
                                        }
                                        catch
                                        {
                                            row2[num4] = 0;
                                        }
                                    }
                                }
                                else
                                {
                                    row[num4] = dataTable.Rows[num2][num4].ToString();
                                    row2[num4] = dataTable.Rows[num2][num4].ToString();
                                }
                                goto Label_0697;
                        }
                        row[num4] = dataTable.Rows[num2][num4].ToString();
                        row2[num4] = dataTable.Rows[num2][num4].ToString();
                    }
                    catch
                    {
                    }
                    goto Label_0697;
                }
                row["id"] = (((Math.Floor(d) * 2.0) + num2) + 1.0) + 1.0;
                row2["id"] = (((Math.Floor(d) * 2.0) + num2) + 1.0) + 2.0;
                table.Rows.Add(row);
                table4.Rows.Add(row2);
            Label_068C:
                num2++;
                goto Label_0248;
            Label_0697:
                num4++;
                goto Label_02CA;
            Label_06A2:
                dataTable.Merge(table);
                dataTable.Merge(table4);
                dataTable.Columns.Add("Sortid", typeof(double));
                foreach (DataRow row3 in dataTable.Rows)
                {
                    row3["Sortid"] = Convert.ToDouble(row3["id"]);
                }
                DataView view = new DataView(dataTable);
                view.Sort = "Sortid";
                DataTable table5 = new DataTable();
                dataTable = view.ToTable();
                dataTable.Columns.Remove("id");
                dataTable.Columns.Remove("Sortid");
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
                this.gridControl.DataSource = dataTable;
                if (this.GView_ZYBH_B5_YCLMJXJBHB.Columns.Count == dataTable.Columns.Count)
                {
                    for (int m = 0; m < this.GView_ZYBH_B5_YCLMJXJBHB.Columns.Count; m++)
                    {
                        this.GView_ZYBH_B5_YCLMJXJBHB.Columns[m].FieldName = dataTable.Columns[m].ColumnName;
                    }
                }
                this.gridControl.MainView = this.GView_ZYBH_B5_YCLMJXJBHB;
                connection.Close();
                this.gBandZYBHB5DW.Caption = "单位名称：" + this.pXianName + "                    单位：公顷、立方米";
            }
            catch
            {
            }
            finally
            {
                GC.Collect();
            }
        }

        private void pBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = this.UpdateTempXBT_Table();
        }

        private string pSQL_CreateGLLDDTZYTJB()
        {
            return (" select case when (GROUPING (MergeSJ.CNAME) = 1) then '合计' else ISNULL(MergeSJ.CNAME,'null') end as 统计单位, Type as 状态, SUM(convert(decimal(18,2),hj)) as 合计, SUM(convert(decimal(18,2),yld)) as 有林地, SUM(convert(decimal(18,2),sld)) as 疏林地, SUM(convert(decimal(18,2),gmld)) as 灌木林地, SUM(convert(decimal(18,2),wcld)) as 未成林地, SUM(convert(decimal(18,2),mpd)) as 苗圃地, SUM(convert(decimal(18,2),wlmld)) as 无立木林地, SUM(convert(decimal(18,2),yilind)) as 宜林地, SUM(convert(decimal(18,2),fzd)) as 林地生产辅助用地 FROM( select code.CNAME,xiang,'增加林地到' as Type, sum (case when [Q_DI_LEI] not like '1%' and [DI_LEI] like '1%' then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] <> '200' and [DI_LEI] = '200'  then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] not like '3%' and [DI_LEI] like '3%' then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] not like '4%' and [DI_LEI] like '4%' then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] <> '500' and [DI_LEI] = '500'  then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] not like '6%' and [DI_LEI] like '6%' then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] not like '7%' and [DI_LEI] like '7%' then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] <> '800' and [DI_LEI] = '800'  then [MIAN_JI] else 0 end ) as hj, sum (case when [Q_DI_LEI] not like '1%' and [DI_LEI] like '1%' then [MIAN_JI] else 0 end ) as yld, sum (case when [Q_DI_LEI] <> '200' and [DI_LEI] = '200'  then [MIAN_JI] else 0 end ) as sld, sum (case when [Q_DI_LEI] not like '3%' and [DI_LEI] like '3%' then [MIAN_JI] else 0 end ) as gmld, sum (case when [Q_DI_LEI] not like '4%' and [DI_LEI] like '4%' then [MIAN_JI] else 0 end ) as wcld, sum (case when [Q_DI_LEI] <> '500' and [DI_LEI] = '500'  then [MIAN_JI] else 0 end ) as mpd, sum (case when [Q_DI_LEI] not like '6%' and [DI_LEI] like '6%' then [MIAN_JI] else 0 end ) as wlmld, sum (case when [Q_DI_LEI] not like '7%' and [DI_LEI] like '7%' then [MIAN_JI] else 0 end ) as yilind, sum (case when [Q_DI_LEI] <> '800' and [DI_LEI] = '800'  then [MIAN_JI] else 0 end ) as fzd FROM " + this.pTable_XB_now + " as xb inner join " + this.pTable_Code + " as code on xb.XIANG = code.CCODE group by code.CNAME,XIANG union all select code.CNAME,xiang,'减少林地至' as Type, sum (case when [Q_DI_LEI] like '1%' and [DI_LEI] not like '1%' then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] = '200' and [DI_LEI] <> '200' then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] like '3%' and [DI_LEI] not like '3%' then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] like '4%' and [DI_LEI] not like '4%' then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] = '500' and [DI_LEI] <> '500' then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] like '6%' and [DI_LEI] not like '6%' then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] like '7%' and [DI_LEI] not like '7%' then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] = '800' and [DI_LEI] <> '800' then [MIAN_JI] else 0 end ) as hj, sum (case when [Q_DI_LEI] like '1%' and [DI_LEI] not like '1%' then [MIAN_JI] else 0 end ) as yld, sum (case when [Q_DI_LEI] = '200' and [DI_LEI] <> '200' then [MIAN_JI] else 0 end ) as sld, sum (case when [Q_DI_LEI] like '3%' and [DI_LEI] not like '3%' then [MIAN_JI] else 0 end ) as gmld, sum (case when [Q_DI_LEI] like '4%' and [DI_LEI] not like '4%' then [MIAN_JI] else 0 end ) as wcld, sum (case when [Q_DI_LEI] = '500' and [DI_LEI] <> '500' then [MIAN_JI] else 0 end ) as mpd, sum (case when [Q_DI_LEI] like '6%' and [DI_LEI] not like '6%' then [MIAN_JI] else 0 end ) as wlmld, sum (case when [Q_DI_LEI] like '7%' and [DI_LEI] not like '7%' then [MIAN_JI] else 0 end ) as yilind, sum (case when [Q_DI_LEI] = '800' and [DI_LEI] <> '800' then [MIAN_JI] else 0 end ) as fzd FROM " + this.pTable_XB_now + " as xb inner join " + this.pTable_Code + " as code on xb.XIANG = code.CCODE group by code.CNAME, XIANG union all select code.CNAME,xiang,'林地净增加' as Type, sum (case when [Q_DI_LEI] not like '1%' and [DI_LEI] like '1%' then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] <> '200' and [DI_LEI] = '200'  then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] not like '3%' and [DI_LEI] like '3%' then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] not like '4%' and [DI_LEI] like '4%' then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] <> '500' and [DI_LEI] = '500'  then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] not like '6%' and [DI_LEI] like '6%' then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] not like '7%' and [DI_LEI] like '7%' then [MIAN_JI] else 0 end ) + sum (case when [Q_DI_LEI] <> '800' and [DI_LEI] = '800'  then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '1%' and [DI_LEI] not like '1%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '200' and [DI_LEI] <> '200' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '3%' and [DI_LEI] not like '3%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '4%' and [DI_LEI] not like '4%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '500' and [DI_LEI] <> '500' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '6%' and [DI_LEI] not like '6%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '7%' and [DI_LEI] not like '7%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '800' and [DI_LEI] <> '800' then [MIAN_JI] else 0 end ) as hj, sum (case when [Q_DI_LEI] not like '1%' and [DI_LEI] like '1%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '1%' and [DI_LEI] not like '1%' then [MIAN_JI] else 0 end ) as yld, sum (case when [Q_DI_LEI] <> '200' and [DI_LEI] = '200'  then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '200' and [DI_LEI] <> '200' then [MIAN_JI] else 0 end ) as sld, sum (case when [Q_DI_LEI] not like '3%' and [DI_LEI] like '3%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '3%' and [DI_LEI] not like '3%' then [MIAN_JI] else 0 end ) as gmld, sum (case when [Q_DI_LEI] not like '4%' and [DI_LEI] like '4%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '4%' and [DI_LEI] not like '4%' then [MIAN_JI] else 0 end ) as wcld, sum (case when [Q_DI_LEI] <> '500' and [DI_LEI] = '500'  then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '500' and [DI_LEI] <> '500' then [MIAN_JI] else 0 end ) as mpd, sum (case when [Q_DI_LEI] not like '6%' and [DI_LEI] like '6%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '6%' and [DI_LEI] not like '6%' then [MIAN_JI] else 0 end ) as wlmld, sum (case when [Q_DI_LEI] not like '7%' and [DI_LEI] like '7%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '7%' and [DI_LEI] not like '7%' then [MIAN_JI] else 0 end ) as yilind, sum (case when [Q_DI_LEI] <> '800' and [DI_LEI] = '800'  then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '800' and [DI_LEI] <> '800' then [MIAN_JI] else 0 end ) as fzd FROM " + this.pTable_XB_now + " as xb inner join " + this.pTable_Code + " as code on xb.XIANG = code.CCODE group by code.CNAME,XIANG )as MergeSJ inner join " + this.pTable_Code + " as code on MergeSJ.XIANG = code.CCODE group by cube(MergeSJ.CNAME),Type order by MIN(code.ccode),MergeSJ.CNAME,case Type when '增加林地到' then 1 when '减少林地至' then 2 when '林地净增加' then 3 end");
        }

        private string pSQL_CreateGLLDMJBGTJB()
        {
            return (" Select case when (GROUPING (MergeSJ.CNAME) = 1) then '合计' else ISNULL(MergeSJ.CNAME,'null') end as 统计单位, case when (GROUPING (qs) = 1) then '合计' else ISNULL(qs,'null') end as 权属, Type as 状态, SUM(convert(decimal(18,2),yld)) as 有林地小计, sum(convert(decimal(18,2),qml)) as 乔木林, sum(convert(decimal(18,2),zl)) as 竹林, sum(convert(decimal(18,2),hsl)) as 红树林, SUM(convert(decimal(18,2),sld)) as 疏林地, SUM(convert(decimal(18,2),gml)) as 灌木林地小计, sum(convert(decimal(18,2),gjgml)) as 国家灌, SUM(convert(decimal(18,2),qtgml))as 其它灌, SUM(convert(decimal(18,2),wcld))as 未成林, SUM(convert(decimal(18,2),mpd))as 苗圃地, SUM(convert(decimal(18,2),wlmld))as 无立木林地, SUM(convert(decimal(18,2),yilind))as 宜林地, SUM(convert(decimal(18,2),fzd))as 辅助地 FROM( select code.CNAME,xiang,'国有' as qs,'现状' as Type, sum (case when [DI_LEI] like '1%' then [MIAN_JI] else 0 end ) as yld, sum (case when [DI_LEI] like '11%' then [MIAN_JI] else 0 end ) as qml, sum (case when [DI_LEI] = '120' then [MIAN_JI] else 0 end ) as hsl, sum (case when [DI_LEI] = '130' then [MIAN_JI] else 0 end ) as zl, sum (case when [DI_LEI] = '200' then [MIAN_JI] else 0 end ) as sld, sum (case when [DI_LEI] like '3%' then [MIAN_JI] else 0 end ) as gml, sum (case when [DI_LEI] = '301' then [MIAN_JI] else 0 end ) as gjgml, sum (case when [DI_LEI] = '302' then [MIAN_JI] else 0 end ) as qtgml, sum (case when [DI_LEI] like '4%' then [MIAN_JI] else 0 end ) as wcld, sum (case when [DI_LEI] = '500' then [MIAN_JI] else 0 end ) as mpd, sum (case when [DI_LEI] like '6%' then [MIAN_JI] else 0 end ) as wlmld, sum (case when [DI_LEI] like '7%' then [MIAN_JI] else 0 end ) as yilind, sum (case when [DI_LEI] = '800' then [MIAN_JI] else 0 end ) as fzd FROM " + this.pTable_XB_now + " as xb inner join " + this.pTable_Code + " as code on xb.XIANG = code.CCODE where [LD_QS] = '10' group by code.CNAME,[LD_QS],XIANG union all select code.CNAME,xiang,'国有' as qs,'新增' as Type, sum (case when [Q_DI_LEI] not like '1%' and [DI_LEI] like '1%' then [MIAN_JI] else 0 end ) as yld, sum (case when [Q_DI_LEI] not like '11%' and DI_LEI like '11%' then [MIAN_JI] else 0 end ) as qml, sum (case when [Q_DI_LEI] <> '120' and [DI_LEI] = '120'  then [MIAN_JI] else 0 end ) as hsl, sum (case when [Q_DI_LEI] <> '130' and [DI_LEI] = '130'  then [MIAN_JI] else 0 end ) as zl, sum (case when [Q_DI_LEI] <> '200' and [DI_LEI] = '200'  then [MIAN_JI] else 0 end ) as sld, sum (case when [Q_DI_LEI] not like '3%' and [DI_LEI] like '3%' then [MIAN_JI] else 0 end ) as gml, sum (case when [Q_DI_LEI] <> '301' and [DI_LEI] = '301'  then [MIAN_JI] else 0 end ) as gjgml, sum (case when [Q_DI_LEI] <> '302' and [DI_LEI] = '302'  then [MIAN_JI] else 0 end ) as qtgml, sum (case when [Q_DI_LEI] not like '4%' and [DI_LEI] like '4%' then [MIAN_JI] else 0 end ) as wcld, sum (case when [Q_DI_LEI] <> '500' and [DI_LEI] = '500'  then [MIAN_JI] else 0 end ) as mpd, sum (case when [Q_DI_LEI] not like '6%' and [DI_LEI] like '6%' then [MIAN_JI] else 0 end ) as wlmld, sum (case when [Q_DI_LEI] not like '7%' and [DI_LEI] like '7%' then [MIAN_JI] else 0 end ) as yilind, sum (case when [Q_DI_LEI] <> '800' and [DI_LEI] = '800'  then [MIAN_JI] else 0 end ) as fzd FROM " + this.pTable_XB_now + " as xb inner join " + this.pTable_Code + " as code on xb.XIANG = code.CCODE where [LD_QS] = '10' group by code.CNAME,[LD_QS],XIANG union all select code.CNAME,xiang,'国有' as qs,'减少' as Type, sum (case when [Q_DI_LEI] like '1%' and [DI_LEI] not like '1%' then [MIAN_JI] else 0 end ) as yld, sum (case when [Q_DI_LEI] like '11%' and [DI_LEI] not like '11%' then [MIAN_JI] else 0 end ) as qml, sum (case when [Q_DI_LEI] = '120' and [DI_LEI] <> '120' then [MIAN_JI] else 0 end ) as hsl, sum (case when [Q_DI_LEI] = '130' and [DI_LEI] <> '130' then [MIAN_JI] else 0 end ) as zl, sum (case when [Q_DI_LEI] = '200' and [DI_LEI] <> '200' then [MIAN_JI] else 0 end ) as sld, sum (case when [Q_DI_LEI] like '3%' and [DI_LEI] not like '3%' then [MIAN_JI] else 0 end ) as gml, sum (case when [Q_DI_LEI] = '301' and [DI_LEI] <> '301' then [MIAN_JI] else 0 end ) as gjgml, sum (case when [Q_DI_LEI] = '302' and [DI_LEI] <> '302' then [MIAN_JI] else 0 end ) as qtgml, sum (case when [Q_DI_LEI] like '4%' and [DI_LEI] not like '4%' then [MIAN_JI] else 0 end ) as wcld, sum (case when [Q_DI_LEI] = '500' and [DI_LEI] <> '500' then [MIAN_JI] else 0 end ) as mpd, sum (case when [Q_DI_LEI] like '6%' and [DI_LEI] not like '6%' then [MIAN_JI] else 0 end ) as wlmld, sum (case when [Q_DI_LEI] like '7%' and [DI_LEI] not like '7%' then [MIAN_JI] else 0 end ) as yilind, sum (case when [Q_DI_LEI] = '800' and [DI_LEI] <> '800' then [MIAN_JI] else 0 end ) as fzd FROM " + this.pTable_XB_now + " as xb inner join " + this.pTable_Code + " as code on xb.XIANG = code.CCODE where [LD_QS] = '10' group by code.CNAME,[LD_QS],XIANG union all select code.CNAME,xiang,'国有' as qs,'净增' as Type, sum (case when [DI_LEI] like '1%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '1%' then [MIAN_JI] else 0 end )as yld, sum (case when [DI_LEI] like '11%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '11%' then [MIAN_JI] else 0 end ) as qml, sum (case when [DI_LEI] = '120'  then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '120' then [MIAN_JI] else 0 end ) as hsl, sum (case when [DI_LEI] = '130'  then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '130' then [MIAN_JI] else 0 end ) as zl, sum (case when [DI_LEI] = '200'  then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '200' then [MIAN_JI] else 0 end ) as sld, sum (case when [DI_LEI] like '3%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '3%' then [MIAN_JI] else 0 end ) as gml, sum (case when [DI_LEI] = '301'  then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '301' then [MIAN_JI] else 0 end ) as gjgml, sum (case when [DI_LEI] = '302'  then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '302' then [MIAN_JI] else 0 end ) as qtgml, sum (case when [DI_LEI] like '4%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '4%' then [MIAN_JI] else 0 end ) as wcld, sum (case when [DI_LEI] = '500'  then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '500' then [MIAN_JI] else 0 end ) as mpd, sum (case when [DI_LEI] like '6%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '6%' then [MIAN_JI] else 0 end ) as wlmld, sum (case when [DI_LEI] like '7%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '7%' then [MIAN_JI] else 0 end ) as yilind, sum (case when [DI_LEI] = '800'  then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '800' then [MIAN_JI] else 0 end ) as fzd FROM " + this.pTable_XB_now + " as xb inner join " + this.pTable_Code + " as code on xb.XIANG = code.CCODE where [LD_QS] = '10' group by code.CNAME,[LD_QS],XIANG union all select code.CNAME,xiang,'集体' as qs,'现状' as Type, sum (case when [DI_LEI] like '1%' then [MIAN_JI] else 0 end ) as yld, sum (case when [DI_LEI] like '11%' then [MIAN_JI] else 0 end ) as qml, sum (case when [DI_LEI] = '120' then [MIAN_JI] else 0 end ) as hsl, sum (case when [DI_LEI] = '130' then [MIAN_JI] else 0 end ) as zl, sum (case when [DI_LEI] = '200' then [MIAN_JI] else 0 end ) as sld, sum (case when [DI_LEI] like '3%' then [MIAN_JI] else 0 end ) as gml, sum (case when [DI_LEI] = '301' then [MIAN_JI] else 0 end ) as gjgml, sum (case when [DI_LEI] = '302' then [MIAN_JI] else 0 end ) as qtgml, sum (case when [DI_LEI] like '4%' then [MIAN_JI] else 0 end ) as wcld, sum (case when [DI_LEI] = '500' then [MIAN_JI] else 0 end ) as mpd, sum (case when [DI_LEI] like '6%' then [MIAN_JI] else 0 end ) as wlmld, sum (case when [DI_LEI] like '7%' then [MIAN_JI] else 0 end ) as yilind, sum (case when [DI_LEI] = '800' then [MIAN_JI] else 0 end ) as fzd FROM " + this.pTable_XB_now + " as xb inner join " + this.pTable_Code + " as code on xb.XIANG = code.CCODE where [LD_QS] like '2%' group by code.CNAME,XIANG union all select code.CNAME,xiang,'集体' as qs,'新增' as Type, sum (case when [Q_DI_LEI] not like '1%' and [DI_LEI] like '1%' then [MIAN_JI] else 0 end ) as yld, sum (case when [Q_DI_LEI] not like '11%' and DI_LEI like '11%' then [MIAN_JI] else 0 end ) as qml, sum (case when [Q_DI_LEI] <> '120' and [DI_LEI] = '120'  then [MIAN_JI] else 0 end ) as hsl, sum (case when [Q_DI_LEI] <> '130' and [DI_LEI] = '130'  then [MIAN_JI] else 0 end ) as zl, sum (case when [Q_DI_LEI] <> '200' and [DI_LEI] = '200'  then [MIAN_JI] else 0 end ) as sld, sum (case when [Q_DI_LEI] not like '3%' and [DI_LEI] like '3%' then [MIAN_JI] else 0 end ) as gml, sum (case when [Q_DI_LEI] <> '301' and [DI_LEI] = '301'  then [MIAN_JI] else 0 end ) as gjgml, sum (case when [Q_DI_LEI] <> '302' and [DI_LEI] = '302'  then [MIAN_JI] else 0 end ) as qtgml, sum (case when [Q_DI_LEI] not like '4%' and [DI_LEI] like '4%' then [MIAN_JI] else 0 end ) as wcld, sum (case when [Q_DI_LEI] <> '500' and [DI_LEI] = '500'  then [MIAN_JI] else 0 end ) as mpd, sum (case when [Q_DI_LEI] not like '6%' and [DI_LEI] like '6%' then [MIAN_JI] else 0 end ) as wlmld, sum (case when [Q_DI_LEI] not like '7%' and [DI_LEI] like '7%' then [MIAN_JI] else 0 end ) as yilind, sum (case when [Q_DI_LEI] <> '800' and [DI_LEI] = '800'  then [MIAN_JI] else 0 end ) as fzd FROM " + this.pTable_XB_now + " as xb inner join " + this.pTable_Code + " as code on xb.XIANG = code.CCODE where [LD_QS] like '2%' group by code.CNAME,XIANG union all select code.CNAME,xiang,'集体' as qs,'减少' as Type, sum (case when [Q_DI_LEI] like '1%' and [DI_LEI] not like '1%' then [MIAN_JI] else 0 end ) as yld, sum (case when [Q_DI_LEI] like '11%' and [DI_LEI] not like '11%' then [MIAN_JI] else 0 end ) as qml, sum (case when [Q_DI_LEI] = '120' and [DI_LEI] <> '120' then [MIAN_JI] else 0 end ) as hsl, sum (case when [Q_DI_LEI] = '130' and [DI_LEI] <> '130' then [MIAN_JI] else 0 end ) as zl, sum (case when [Q_DI_LEI] = '200' and [DI_LEI] <> '200' then [MIAN_JI] else 0 end ) as sld, sum (case when [Q_DI_LEI] like '3%' and [DI_LEI] not like '3%' then [MIAN_JI] else 0 end ) as gml, sum (case when [Q_DI_LEI] = '301' and [DI_LEI] <> '301' then [MIAN_JI] else 0 end ) as gjgml, sum (case when [Q_DI_LEI] = '302' and [DI_LEI] <> '302' then [MIAN_JI] else 0 end ) as qtgml, sum (case when [Q_DI_LEI] like '4%' and [DI_LEI] not like '4%' then [MIAN_JI] else 0 end ) as wcld, sum (case when [Q_DI_LEI] = '500' and [DI_LEI] <> '500' then [MIAN_JI] else 0 end ) as mpd, sum (case when [Q_DI_LEI] like '6%' and [DI_LEI] not like '6%' then [MIAN_JI] else 0 end ) as wlmld, sum (case when [Q_DI_LEI] like '7%' and [DI_LEI] not like '7%' then [MIAN_JI] else 0 end ) as yilind, sum (case when [Q_DI_LEI] = '800' and [DI_LEI] <> '800' then [MIAN_JI] else 0 end ) as fzd FROM " + this.pTable_XB_now + " as xb inner join " + this.pTable_Code + " as code on xb.XIANG = code.CCODE where [LD_QS] like '2%' group by code.CNAME,XIANG union all select code.CNAME,xiang,'集体' as qs,'净增' as Type, sum (case when [DI_LEI] like '1%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '1%' then [MIAN_JI] else 0 end )as yld, sum (case when [DI_LEI] like '11%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '11%' then [MIAN_JI] else 0 end ) as qml, sum (case when [DI_LEI] = '120'  then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '120' then [MIAN_JI] else 0 end ) as hsl, sum (case when [DI_LEI] = '130'  then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '130' then [MIAN_JI] else 0 end ) as zl, sum (case when [DI_LEI] = '200'  then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '200' then [MIAN_JI] else 0 end ) as sld, sum (case when [DI_LEI] like '3%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '3%' then [MIAN_JI] else 0 end ) as gml, sum (case when [DI_LEI] = '301'  then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '301' then [MIAN_JI] else 0 end ) as gjgml, sum (case when [DI_LEI] = '302'  then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '302' then [MIAN_JI] else 0 end ) as qtgml, sum (case when [DI_LEI] like '4%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '4%' then [MIAN_JI] else 0 end ) as wcld, sum (case when [DI_LEI] = '500'  then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '500' then [MIAN_JI] else 0 end ) as mpd, sum (case when [DI_LEI] like '6%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '6%' then [MIAN_JI] else 0 end ) as wlmld, sum (case when [DI_LEI] like '7%' then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] like '7%' then [MIAN_JI] else 0 end ) as yilind, sum (case when [DI_LEI] = '800'  then [MIAN_JI] else 0 end ) - sum (case when [Q_DI_LEI] = '800' then [MIAN_JI] else 0 end ) as fzd FROM " + this.pTable_XB_now + " as xb inner join " + this.pTable_Code + " as code on xb.XIANG = code.CCODE where [LD_QS] like '2%' group by code.CNAME,XIANG ) as MergeSJ inner join " + this.pTable_Code + " as code on MergeSJ.XIANG = code.CCODE group by cube(MergeSJ.CNAME,qs),Type order by MIN(code.ccode),MergeSJ.CNAME,qs,case Type when '现状' then 1 when '新增' then 2 when '减少' then 3 when '净增' then 4 end");
        }

        private string pSQL_CreateGYLDMJBGTJB()
        {
            return (" select case when (GROUPING (MergeSJ.CNAME) = 1) then '合计' else ISNULL(MergeSJ.CNAME,'null') end as 统计单位, Type as 状态, SUM(convert(decimal(18,2),zdgyld)) as 重点公益林地小计, sum(convert(decimal(18,2),zdgyld_gyl)) as 重点公益林地中公益林小计, sum(convert(decimal(18,2),zdgyld_gyl_fhl)) as 重点公益林地中防护林小计, sum(convert(decimal(18,2),zdgyld_gyl_tyl)) as 重点公益林地中特用林小计, SUM(convert(decimal(18,2),zdgyld_qtld)) as 重点公益林地中其它林地小计, SUM(convert(decimal(18,2),zdgyld_gyjgyld)) as 其中国家重点公益林地小计, sum(convert(decimal(18,2),zdgyld_gyjgyld_gyl)) as 其中国家重点公益林地中公益林小计, SUM(convert(decimal(18,2),zdgyld_gyjgyld_gyl_fhl))as 其中国家重点公益林地中防护林小计, SUM(convert(decimal(18,2),zdgyld_gyjgyld_gyl_tyl))as 其中国家重点公益林地中特用林小计, SUM(convert(decimal(18,2),zdgyld_gyjgyld_qtld))as 其中国家重点公益林地中其它林地小计, SUM(convert(decimal(18,2),ybgyld))as 一般公益林地小计, SUM(convert(decimal(18,2),ybgyld_gyl))as 一般公益林地中公益林小计, SUM(convert(decimal(18,2),ybgyld_gyl_fhl))as 一般公益林地中防护林小计, SUM(convert(decimal(18,2),ybgyld_gyl_tyl))as 一般公益林地中特用林小计, SUM(convert(decimal(18,2),ybgyld_qtld))as 一般公益林地中其它林地小计 FROM( select code.CNAME,[XIANG],'现状' as Type, sum (case when [SEN_LIN_LB] like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') then [MIAN_JI] else 0 end ) as zdgyld, sum (case when [SEN_LIN_LB] like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] like '1%' then [MIAN_JI] else 0 end ) as zdgyld_gyl, sum (case when [SEN_LIN_LB] like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] like '11%' then [MIAN_JI]  else 0 end ) as zdgyld_gyl_fhl, sum (case when [SEN_LIN_LB] like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] like '12%' then [MIAN_JI]  else 0 end ) as zdgyld_gyl_tyl, sum (case when [SEN_LIN_LB] like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] not like '1%' then [MIAN_JI] else 0 end ) as zdgyld_qtld, sum (case when [SEN_LIN_LB] like '11%' and [SHI_QUAN_D] = '10' then [MIAN_JI] else 0 end ) as zdgyld_gyjgyld, sum (case when [SEN_LIN_LB] like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] like '1%' then [MIAN_JI] else 0 end ) as zdgyld_gyjgyld_gyl, sum (case when [SEN_LIN_LB] like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] like '11%' then [MIAN_JI]  else 0 end ) as zdgyld_gyjgyld_gyl_fhl, sum (case when [SEN_LIN_LB] like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] like '12%' then [MIAN_JI]  else 0 end ) as zdgyld_gyjgyld_gyl_tyl, sum (case when [SEN_LIN_LB] like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] not like '1%' then [MIAN_JI] else 0 end ) as zdgyld_gyjgyld_qtld, sum (case when [SEN_LIN_LB] like '12%' then [MIAN_JI] else 0 end ) as ybgyld, sum (case when [SEN_LIN_LB] like '12%' and [LIN_ZHONG] like '1%' then [MIAN_JI] else 0 end ) as ybgyld_gyl, sum (case when [SEN_LIN_LB] like '12%' and [LIN_ZHONG] like '11%' then [MIAN_JI]  else 0 end ) as ybgyld_gyl_fhl, sum (case when [SEN_LIN_LB] like '12%' and [LIN_ZHONG] like '12%' then [MIAN_JI]  else 0 end ) as ybgyld_gyl_tyl, sum (case when [SEN_LIN_LB] like '12%' and [LIN_ZHONG] not like '1%' then [MIAN_JI] else 0 end ) as ybgyld_qtld FROM " + this.pTable_XB_now + " as xb inner join " + this.pTable_Code + " as code on xb.XIANG = code.CCODE group by code.CNAME,XIANG union all select code.CNAME,[XIANG],'新增' as Type, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') then [MIAN_JI]  else 0 end ) as zdgyld, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] like '1%' then [MIAN_JI] else 0 end ) as zdgyld_gyl, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] like '11%' then [MIAN_JI]  else 0 end ) as zdgyld_gyl_fhl, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] like '12%' then [MIAN_JI]  else 0 end ) as zdgyld_gyl_tyl, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] not like '1%' then [MIAN_JI] else 0 end ) as zdgyld_qtld, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and [SHI_QUAN_D] = '10' then [MIAN_JI] else 0 end ) as zdgyld_gyjgyld, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] like '1%' then [MIAN_JI] else 0 end ) as zdgyld_gyjgyld_gyl, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] like '11%' then [MIAN_JI]  else 0 end ) as zdgyld_gyjgyld_gyl_fhl, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] like '12%' then [MIAN_JI]  else 0 end ) as zdgyld_gyjgyld_gyl_tyl, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] not like '1%' then [MIAN_JI] else 0 end ) as zdgyld_gyjgyld_qtld, sum (case when [SEN_LIN_LB] like '12%' and [Q_SEN_LB] not like '12%' then [MIAN_JI] else 0 end ) as ybgyld, sum (case when [SEN_LIN_LB] like '12%' and [Q_SEN_LB] not like '12%' and [LIN_ZHONG] like '1%' then [MIAN_JI] else 0 end ) as ybgyld_gyl, sum (case when [SEN_LIN_LB] like '12%' and [Q_SEN_LB] not like '12%' and [LIN_ZHONG] like '11%' then [MIAN_JI]  else 0 end ) as ybgyld_gyl_fhl, sum (case when [SEN_LIN_LB] like '12%' and [Q_SEN_LB] not like '12%' and [LIN_ZHONG] like '12%' then [MIAN_JI]  else 0 end ) as ybgyld_gyl_tyl, sum (case when [SEN_LIN_LB] like '12%' and [Q_SEN_LB] not like '12%' and [LIN_ZHONG] not like '1%' then [MIAN_JI] else 0 end ) as ybgyld_qtld FROM " + this.pTable_XB_now + " as xb inner join " + this.pTable_Code + " as code on xb.XIANG = code.CCODE group by code.CNAME,XIANG union all select code.CNAME,[XIANG],'减少' as Type, sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') then [MIAN_JI]  else 0 end ) as zdgyld, sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] like '1%' then [MIAN_JI] else 0 end ) as zdgyld_gyl, sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] like '11%' then [MIAN_JI]  else 0 end ) as zdgyld_gyl_fhl, sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] like '12%' then [MIAN_JI]  else 0 end ) as zdgyld_gyl_tyl, sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] not like '1%' then [MIAN_JI] else 0 end ) as zdgyld_qtld, sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and [SHI_QUAN_D] = '10' then [MIAN_JI] else 0 end ) as zdgyld_gyjgyld, sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] like '1%' then [MIAN_JI] else 0 end ) as zdgyld_gyjgyld_gyl, sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] like '11%' then [MIAN_JI]  else 0 end ) as zdgyld_gyjgyld_gyl_fhl, sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] like '12%' then [MIAN_JI]  else 0 end ) as zdgyld_gyjgyld_gyl_tyl, sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] not like '1%' then [MIAN_JI] else 0 end ) as zdgyld_gyjgyld_qtld, sum (case when [SEN_LIN_LB] not like '12%' and [Q_SEN_LB] like '12%' then [MIAN_JI] else 0 end ) as ybgyld, sum (case when [SEN_LIN_LB] not like '12%' and [Q_SEN_LB] like '12%' and [LIN_ZHONG] like '1%' then [MIAN_JI] else 0 end ) as ybgyld_gyl, sum (case when [SEN_LIN_LB] not like '12%' and [Q_SEN_LB] like '12%' and [LIN_ZHONG] like '11%' then [MIAN_JI]  else 0 end ) as ybgyld_gyl_fhl, sum (case when [SEN_LIN_LB] not like '12%' and [Q_SEN_LB] like '12%' and [LIN_ZHONG] like '12%' then [MIAN_JI]  else 0 end ) as ybgyld_gyl_tyl, sum (case when [SEN_LIN_LB] not like '12%' and [Q_SEN_LB] like '12%' and [LIN_ZHONG] not like '1%' then [MIAN_JI] else 0 end ) as ybgyld_qtld FROM " + this.pTable_XB_now + " as xb inner join " + this.pTable_Code + " as code on xb.XIANG = code.CCODE group by code.CNAME,XIANG union all select code.CNAME,[XIANG],'净增' as Type, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') then [MIAN_JI]  else 0 end ) - sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') then [MIAN_JI]  else 0 end ) as zdgyld, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] like '1%' then [MIAN_JI] else 0 end ) - sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] like '1%' then [MIAN_JI] else 0 end ) as zdgyld_gyl, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] like '11%' then [MIAN_JI]  else 0 end ) - sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] like '11%' then [MIAN_JI]  else 0 end ) as zdgyld_gyl_fhl, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] like '12%' then [MIAN_JI]  else 0 end ) - sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] like '12%' then [MIAN_JI]  else 0 end ) as zdgyld_gyl_tyl, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] not like '1%' then [MIAN_JI] else 0 end ) - sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and ([SHI_QUAN_D] = '10' or [SHI_QUAN_D] = '20') and [LIN_ZHONG] not like '1%' then [MIAN_JI] else 0 end ) as zdgyld_qtld, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and [SHI_QUAN_D] = '10' then [MIAN_JI] else 0 end ) - sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and [SHI_QUAN_D] = '10' then [MIAN_JI] else 0 end ) as zdgyld_gyjgyld, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] like '1%' then [MIAN_JI] else 0 end ) - sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] like '1%' then [MIAN_JI] else 0 end ) as zdgyld_gyjgyld_gyl, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] like '11%' then [MIAN_JI]  else 0 end ) - sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] like '11%' then [MIAN_JI]  else 0 end ) as zdgyld_gyjgyld_gyl_fhl, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] like '12%' then [MIAN_JI]  else 0 end ) - sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] like '12%' then [MIAN_JI]  else 0 end ) as zdgyld_gyjgyld_gyl_tyl, sum (case when [SEN_LIN_LB] like '11%' and [Q_SEN_LB] not like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] not like '1%' then [MIAN_JI] else 0 end ) - sum (case when [SEN_LIN_LB] not like '11%' and [Q_SEN_LB] like '11%' and [SHI_QUAN_D] = '10' and [LIN_ZHONG] not like '1%' then [MIAN_JI] else 0 end ) as zdgyld_gyjgyld_qtld, sum (case when [SEN_LIN_LB] like '12%' and [Q_SEN_LB] not like '12%' then [MIAN_JI] else 0 end ) - sum (case when [SEN_LIN_LB] not like '12%' and [Q_SEN_LB] like '12%' then [MIAN_JI] else 0 end ) as ybgyld, sum (case when [SEN_LIN_LB] like '12%' and [Q_SEN_LB] not like '12%' and [LIN_ZHONG] like '1%' then [MIAN_JI] else 0 end ) - sum (case when [SEN_LIN_LB] not like '12%' and [Q_SEN_LB] like '12%' and [LIN_ZHONG] like '1%' then [MIAN_JI] else 0 end ) as ybgyld_gyl, sum (case when [SEN_LIN_LB] like '12%' and [Q_SEN_LB] not like '12%' and [LIN_ZHONG] like '11%' then [MIAN_JI]  else 0 end ) - sum (case when [SEN_LIN_LB] not like '12%' and [Q_SEN_LB] like '12%' and [LIN_ZHONG] like '11%' then [MIAN_JI]  else 0 end ) as ybgyld_gyl_fhl, sum (case when [SEN_LIN_LB] like '12%' and [Q_SEN_LB] not like '12%' and [LIN_ZHONG] like '12%' then [MIAN_JI]  else 0 end ) - sum (case when [SEN_LIN_LB] not like '12%' and [Q_SEN_LB] like '12%' and [LIN_ZHONG] like '12%' then [MIAN_JI]  else 0 end ) as ybgyld_gyl_tyl, sum (case when [SEN_LIN_LB] like '12%' and [Q_SEN_LB] not like '12%' and [LIN_ZHONG] not like '1%' then [MIAN_JI] else 0 end ) - sum (case when [SEN_LIN_LB] not like '12%' and [Q_SEN_LB] like '12%' and [LIN_ZHONG] not like '1%' then [MIAN_JI] else 0 end ) as ybgyld_qtld FROM " + this.pTable_XB_now + " as xb inner join " + this.pTable_Code + " as code on xb.XIANG = code.CCODE group by code.CNAME,XIANG )as MergeSJ inner join " + this.pTable_Code + " as code on MergeSJ.XIANG = code.CCODE group by cube(MergeSJ.CNAME),Type order by MIN(code.ccode),MergeSJ.CNAME,case Type when '现状' then 1 when '新增' then 2 when '减少' then 3 when '净增' then 4 end");
        }

        private string pSQL_CreateLDBHYYFXTJB()
        {
            return (" select case when (GROUPING (CNAME) = 1) then '合计' else ISNULL(CNAME,'合计') end as 统计单位, case when (GROUPING (qqdl) = 1) then '合计' else ISNULL(qqdl,'合计') end as 前期地类, case when (GROUPING (hqdl) = 1) then '合计' else ISNULL(hqdl,'合计') end as 后期地类, SUM(convert(decimal(18,2),hj)) as 合计, sum(convert(decimal(18,2),zszl)) as 造林更新, sum(convert(decimal(18,2),slcf)) as 森林采伐, SUM(convert(decimal(18,2),ghtz)) as 规划调整, SUM(convert(decimal(18,2),zyzs)) as 占用征收, sum(convert(decimal(18,2),hlffzy)) as 毁林开垦, SUM(convert(decimal(18,2),zhys))as 灾害因素, SUM(convert(decimal(18,2),zyys))as 自然因素, SUM(convert(decimal(18,2),dcys))as 调查因素 FROM( select [xiang],qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'有林地' as qqdl,'有林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '1%' and [DI_LEI] like '1%' and [BHYY] <> '80' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang],qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'有林地' as qqdl,'疏林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '1%' and [DI_LEI] = '200' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang],qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'有林地' as qqdl,'灌木林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '1%' and [DI_LEI] like '3%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang],qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'有林地' as qqdl,'未成林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '1%' and [DI_LEI] like '4%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang],qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'有林地' as qqdl,'苗圃地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '1%' and [DI_LEI] = '500' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang],qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'有林地' as qqdl,'无立木地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '1%' and [DI_LEI] like '6%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang],qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'有林地' as qqdl,'宜林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '1%' and [DI_LEI] like '7%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang],qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'有林地' as qqdl,'林业辅助生产用地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '1%' and [DI_LEI] like '8%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang],qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'有林地' as qqdl,'非林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '1%' and [DI_LEI] like '9%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang],qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'疏林地' as qqdl,'有林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] = '200' and [DI_LEI] like '1%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'疏林地' as qqdl,'疏林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] = '200' and [DI_LEI] = '200' and [BHYY] <> '80' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'疏林地' as qqdl,'灌木林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] = '200' and [DI_LEI] like '3%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'疏林地' as qqdl,'未成林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] = '200' and [DI_LEI] like '4%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'疏林地' as qqdl,'苗圃地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] = '200' and [DI_LEI] = '500' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'疏林地' as qqdl,'无立木地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] = '200' and [DI_LEI] like '6%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'疏林地' as qqdl,'宜林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] = '200' and [DI_LEI] like '7%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'疏林地' as qqdl,'林业辅助生产用地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] = '200' and [DI_LEI] like '8%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'疏林地' as qqdl,'非林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] = '200' and [DI_LEI] like '9%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'灌木林地' as qqdl,'有林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '3%' and [DI_LEI] like '1%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'灌木林地' as qqdl,'疏林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '3%' and [DI_LEI] = '200' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'灌木林地' as qqdl,'灌木林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '3%' and [DI_LEI] like '3%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'灌木林地' as qqdl,'未成林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '3%' and [DI_LEI] like '4%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'灌木林地' as qqdl,'苗圃地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '3%' and [DI_LEI] = '500' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'灌木林地' as qqdl,'无立木地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '3%' and [DI_LEI] like '6%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'灌木林地' as qqdl,'宜林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '3%' and [DI_LEI] like '7%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'灌木林地' as qqdl,'林业辅助生产用地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '3%' and [DI_LEI] like '8%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'灌木林地' as qqdl,'非林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '3%' and [DI_LEI] like '9%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'未成林地' as qqdl,'有林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '4%' and [DI_LEI] like '1%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'未成林地' as qqdl,'疏林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '4%' and [DI_LEI] = '200' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'未成林地' as qqdl,'灌木林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '4%' and [DI_LEI] like '3%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'未成林地' as qqdl,'未成林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '4%' and [DI_LEI] like '4%' and [BHYY] <> '80' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'未成林地' as qqdl,'苗圃地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '4%' and [DI_LEI] = '500' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'未成林地' as qqdl,'无立木地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '4%' and [DI_LEI] like '6%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'未成林地' as qqdl,'宜林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '4%' and [DI_LEI] like '7%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'未成林地' as qqdl,'林业辅助生产用地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '4%' and [DI_LEI] like '8%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'未成林地' as qqdl,'非林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '4%' and [DI_LEI] like '9%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'苗圃地' as qqdl,'有林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] = '500' and [DI_LEI] like '1%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'苗圃地' as qqdl,'疏林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] = '500' and [DI_LEI] = '200' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'苗圃地' as qqdl,'灌木林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] = '500' and [DI_LEI] like '3%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'苗圃地' as qqdl,'未成林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] = '500' and [DI_LEI] like '4%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'苗圃地' as qqdl,'苗圃地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] = '500' and [DI_LEI] = '500' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'苗圃地' as qqdl,'无立木地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] = '500' and [DI_LEI] like '6%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'苗圃地' as qqdl,'宜林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] = '500' and [DI_LEI] like '7%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'苗圃地' as qqdl,'林业辅助生产用地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] = '500' and [DI_LEI] like '8%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'苗圃地' as qqdl,'非林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] = '500' and [DI_LEI] like '9%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'无立木地' as qqdl,'有林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '6%' and [DI_LEI] like '1%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'无立木地' as qqdl,'疏林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '6%' and [DI_LEI] = '200' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'无立木地' as qqdl,'灌木林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '6%' and [DI_LEI] like '3%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'无立木地' as qqdl,'未成林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '6%' and [DI_LEI] like '4%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'无立木地' as qqdl,'苗圃地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '6%' and [DI_LEI] = '500' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'无立木地' as qqdl,'无立木地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '6%' and [DI_LEI] like '6%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'无立木地' as qqdl,'宜林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '6%' and [DI_LEI] like '7%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'无立木地' as qqdl,'林业辅助生产用地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '6%' and [DI_LEI] like '8%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'无立木地' as qqdl,'非林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '6%' and [DI_LEI] like '9%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'宜林地' as qqdl,'有林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '7%' and [DI_LEI] like '1%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'宜林地' as qqdl,'疏林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '7%' and [DI_LEI] = '200' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'宜林地' as qqdl,'灌木林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '7%' and [DI_LEI] like '3%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'宜林地' as qqdl,'未成林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '7%' and [DI_LEI] like '4%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'宜林地' as qqdl,'苗圃地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '7%' and [DI_LEI] = '500' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'宜林地' as qqdl,'无立木地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '7%' and [DI_LEI] like '6%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'宜林地' as qqdl,'宜林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '7%' and [DI_LEI] like '7%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'宜林地' as qqdl,'林业辅助生产用地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '7%' and [DI_LEI] like '8%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'宜林地' as qqdl,'非林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '7%' and [DI_LEI] like '9%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'林业辅助生产用地' as qqdl,'有林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '8%' and [DI_LEI] like '1%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'林业辅助生产用地' as qqdl,'疏林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '8%' and [DI_LEI] = '200' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'林业辅助生产用地' as qqdl,'灌木林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '8%' and [DI_LEI] like '3%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'林业辅助生产用地' as qqdl,'未成林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '8%' and [DI_LEI] like '4%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'林业辅助生产用地' as qqdl,'苗圃地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '8%' and [DI_LEI] = '500' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'林业辅助生产用地' as qqdl,'无立木地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '8%' and [DI_LEI] like '6%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'林业辅助生产用地' as qqdl,'宜林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '8%' and [DI_LEI] like '7%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'林业辅助生产用地' as qqdl,'林业辅助生产用地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '8%' and [DI_LEI]like '8%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'林业辅助生产用地' as qqdl,'非林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '8%' and [DI_LEI] like '9%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'非林地' as qqdl,'有林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '9%' and [DI_LEI] like '1%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'非林地' as qqdl,'疏林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '9%' and [DI_LEI] = '200' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'非林地' as qqdl,'灌木林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '9%' and [DI_LEI] like '3%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'非林地' as qqdl,'未成林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '9%' and [DI_LEI] like '4%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'非林地' as qqdl,'苗圃地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '9%' and [DI_LEI] = '500' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'非林地' as qqdl,'无立木地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '9%' and [DI_LEI] like '6%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'非林地' as qqdl,'宜林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '9%' and [DI_LEI] like '7%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'非林地' as qqdl,'林业辅助生产用地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '9%' and [DI_LEI] like '8%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) union all select [xiang] ,qqdl,hqdl,sum(hj)as hj,sum(zszl)as zszl,sum(slcf)as slcf, sum(ghtz)as ghtz,sum(zyzs)as zyzs,sum(hlffzy)as hlffzy,sum(zhys)as zhys,sum(zyys)as zyys,sum(dcys)as dcys from( select [xiang],'非林地' as qqdl,'非林地' as hqdl, sum (case when [BHYY] IS NOT NULL then [MIAN_JI] else 0 end ) as hj, sum (case when [BHYY] like '1%' then [MIAN_JI] else 0 end ) as zszl, sum (case when [BHYY] like '2%' then [MIAN_JI] else 0 end ) as slcf, sum (case when [BHYY] like '3%' then [MIAN_JI] else 0 end ) as ghtz, sum (case when [BHYY] like '4%' then [MIAN_JI] else 0 end ) as zyzs, sum (case when [BHYY] = '50' or [BHYY] = '60' then [MIAN_JI] else 0 end ) as hlffzy, sum (case when [BHYY] like '7%' then [MIAN_JI] else 0 end ) as zhys, sum (case when [BHYY] like '8%' then [MIAN_JI] else 0 end ) as zyys, sum (case when [BHYY] like '9%' then [MIAN_JI] else 0 end ) as dcys FROM " + this.pTable_XB_now + " where [Q_DI_LEI] like '9%' and [DI_LEI] like '9%' group by [xiang],[Q_DI_LEI],[DI_LEI] )as xb group by cube([xiang],qqdl,hqdl) )as bb where hj <> 0 group by [xiang],qqdl,hqdl ) as kk LEFT JOIN " + this.pTable_Code + " on [xiang] = CCODE and CTYPE = '乡' group by CNAME,qqdl,hqdl order by min(CCODE),CNAME, case qqdl when '有林地' then 1 when '疏林地' then 2 when '灌木林地' then 3 when '未成林地' then 4 when '苗圃地' then 5 when '无立木地' then 6 when '宜林地' then 7 when '林业辅助生产用地' then 8 when '非林地' then 9 end, case hqdl when '有林地' then 1 when '疏林地' then 2 when '灌木林地' then 3 when '未成林地' then 4 when '苗圃地' then 5 when '无立木地' then 6 when '宜林地' then 7 when '林业辅助生产用地' then 8 when '非林地' then 9 end");
        }

        private string pSQL_CreateSPLDMJBGTJB()
        {
            return (" select case when (GROUPING (MergeSJ.CNAME) = 1) then '合计' else ISNULL(MergeSJ.CNAME,'null') end as 统计单位, Type as 状态, SUM(convert(decimal(18,2),zdspld)) as 重点商品林地小计, SUM(convert(decimal(18,2),zdspld_spl)) as 重点商品林地中商品林小计, SUM(convert(decimal(18,2),zdspld_spl_ycl)) as 重点商品林地中用材林小计, SUM(convert(decimal(18,2),zdspld_spl_xtl)) as 重点商品林地中薪炭林小计, SUM(convert(decimal(18,2),zdspld_spl_jjl)) as 重点商品林地中经济林小计, SUM(convert(decimal(18,2),zdspld_qtld)) as 重点商品林地中其它林地小计, SUM(convert(decimal(18,2),ybspld)) as 一般商品林地小计, SUM(convert(decimal(18,2),ybspld_spl)) as 一般商品林地中商品林小计, SUM(convert(decimal(18,2),ybspld_spl_ycl)) as 一般商品林地中用材林小计, SUM(convert(decimal(18,2),ybspld_spl_xtl)) as 一般商品林地中薪炭林小计, SUM(convert(decimal(18,2),ybspld_spl_jjl)) as 一般商品林地中经济林小计, SUM(convert(decimal(18,2),ybspld_qtld)) as 一般商品林地中其它林地小计 FROM( select code.CNAME,[XIANG],'现状' as Type, sum (case when [SEN_LIN_LB] like '21%' then [MIAN_JI] else 0 end ) as zdspld, sum (case when [SEN_LIN_LB] like '21%' and [LIN_ZHONG] like '2%' then [MIAN_JI] else 0 end ) as zdspld_spl, sum (case when [SEN_LIN_LB] like '21%' and [LIN_ZHONG] like '23%' then [MIAN_JI]  else 0 end ) as zdspld_spl_ycl, sum (case when [SEN_LIN_LB] like '21%' and [LIN_ZHONG] like '24%' then [MIAN_JI]  else 0 end ) as zdspld_spl_xtl, sum (case when [SEN_LIN_LB] like '21%' and [LIN_ZHONG] like '25%' then [MIAN_JI] else 0 end ) as zdspld_spl_jjl, sum (case when [SEN_LIN_LB] like '21%' and [LIN_ZHONG] not like '2%' then [MIAN_JI] else 0 end ) as zdspld_qtld, sum (case when [SEN_LIN_LB] like '22%' then [MIAN_JI] else 0 end ) as ybspld, sum (case when [SEN_LIN_LB] like '22%' and [LIN_ZHONG] like '2%' then [MIAN_JI] else 0 end ) as ybspld_spl, sum (case when [SEN_LIN_LB] like '22%' and [LIN_ZHONG] like '23%' then [MIAN_JI]  else 0 end ) as ybspld_spl_ycl, sum (case when [SEN_LIN_LB] like '22%' and [LIN_ZHONG] like '24%' then [MIAN_JI]  else 0 end ) as ybspld_spl_xtl, sum (case when [SEN_LIN_LB] like '22%' and [LIN_ZHONG] like '25%' then [MIAN_JI]  else 0 end ) as ybspld_spl_jjl, sum (case when [SEN_LIN_LB] like '22%' and [LIN_ZHONG] not like '2%' then [MIAN_JI] else 0 end ) as ybspld_qtld FROM " + this.pTable_XB_now + " as xb inner join " + this.pTable_Code + " as code on xb.XIANG = code.CCODE group by code.CNAME,XIANG union all select code.CNAME,[XIANG],'新增' as Type, sum (case when [SEN_LIN_LB] like '21%' and [Q_SEN_LB] not like '21%' then [MIAN_JI] else 0 end ) as zdspld, sum (case when [SEN_LIN_LB] like '21%' and [Q_SEN_LB] not like '21%' and [LIN_ZHONG] like '2%' then [MIAN_JI] else 0 end ) as zdspld_spl, sum (case when [SEN_LIN_LB] like '21%' and [Q_SEN_LB] not like '21%' and [LIN_ZHONG] like '23%' then [MIAN_JI]  else 0 end ) as zdspld_spl_ycl, sum (case when [SEN_LIN_LB] like '21%' and [Q_SEN_LB] not like '21%' and [LIN_ZHONG] like '24%' then [MIAN_JI]  else 0 end ) as zdspld_spl_xtl, sum (case when [SEN_LIN_LB] like '21%' and [Q_SEN_LB] not like '21%' and [LIN_ZHONG] like '25%' then [MIAN_JI] else 0 end ) as zdspld_spl_jjl, sum (case when [SEN_LIN_LB] like '21%' and [Q_SEN_LB] not like '21%' and [LIN_ZHONG] not like '2%' then [MIAN_JI] else 0 end ) as zdspld_qtld, sum (case when [SEN_LIN_LB] like '22%' and [Q_SEN_LB] not like '22%' then [MIAN_JI] else 0 end ) as ybspld, sum (case when [SEN_LIN_LB] like '22%' and [Q_SEN_LB] not like '22%' and [LIN_ZHONG] like '2%' then [MIAN_JI] else 0 end ) as ybspld_spl, sum (case when [SEN_LIN_LB] like '22%' and [Q_SEN_LB] not like '22%' and [LIN_ZHONG] like '23%' then [MIAN_JI]  else 0 end ) as ybspld_spl_ycl, sum (case when [SEN_LIN_LB] like '22%' and [Q_SEN_LB] not like '22%' and [LIN_ZHONG] like '24%' then [MIAN_JI]  else 0 end ) as ybspld_spl_xtl, sum (case when [SEN_LIN_LB] like '22%' and [Q_SEN_LB] not like '22%' and [LIN_ZHONG] like '25%' then [MIAN_JI]  else 0 end ) as ybspld_spl_jjl, sum (case when [SEN_LIN_LB] like '22%' and [Q_SEN_LB] not like '22%' and [LIN_ZHONG] not like '2%' then [MIAN_JI] else 0 end ) as ybspld_qtld FROM " + this.pTable_XB_now + " as xb inner join " + this.pTable_Code + " as code on xb.XIANG = code.CCODE group by code.CNAME,XIANG union all select code.CNAME,[XIANG],'减少' as Type, sum (case when [SEN_LIN_LB] not like '21%' and [Q_SEN_LB] like '21%' then [MIAN_JI] else 0 end ) as zdspld, sum (case when [SEN_LIN_LB] not like '21%' and [Q_SEN_LB] like '21%' and [LIN_ZHONG] like '2%' then [MIAN_JI] else 0 end ) as zdspld_spl, sum (case when [SEN_LIN_LB] not like '21%' and [Q_SEN_LB] like '21%' and [LIN_ZHONG] like '23%' then [MIAN_JI]  else 0 end ) as zdspld_spl_ycl, sum (case when [SEN_LIN_LB] not like '21%' and [Q_SEN_LB] like '21%' and [LIN_ZHONG] like '24%' then [MIAN_JI]  else 0 end ) as zdspld_spl_xtl, sum (case when [SEN_LIN_LB] not like '21%' and [Q_SEN_LB] like '21%' and [LIN_ZHONG] like '25%' then [MIAN_JI] else 0 end ) as zdspld_spl_jjl, sum (case when [SEN_LIN_LB] not like '21%' and [Q_SEN_LB] like '21%' and [LIN_ZHONG] not like '2%' then [MIAN_JI] else 0 end ) as zdspld_qtld, sum (case when [SEN_LIN_LB] not like '22%' and [Q_SEN_LB] like '22%' then [MIAN_JI] else 0 end ) as ybspld, sum (case when [SEN_LIN_LB] not like '22%' and [Q_SEN_LB] like '22%' and [LIN_ZHONG] like '2%' then [MIAN_JI] else 0 end ) as ybspld_spl, sum (case when [SEN_LIN_LB] not like '22%' and [Q_SEN_LB] like '22%' and [LIN_ZHONG] like '23%' then [MIAN_JI]  else 0 end ) as ybspld_spl_ycl, sum (case when [SEN_LIN_LB] not like '22%' and [Q_SEN_LB] like '22%' and [LIN_ZHONG] like '24%' then [MIAN_JI]  else 0 end ) as ybspld_spl_xtl, sum (case when [SEN_LIN_LB] not like '22%' and [Q_SEN_LB] like '22%' and [LIN_ZHONG] like '25%' then [MIAN_JI]  else 0 end ) as ybspld_spl_jjl, sum (case when [SEN_LIN_LB] not like '22%' and [Q_SEN_LB] like '22%' and [LIN_ZHONG] not like '2%' then [MIAN_JI] else 0 end ) as ybspld_qtld FROM " + this.pTable_XB_now + " as xb inner join " + this.pTable_Code + " as code on xb.XIANG = code.CCODE group by code.CNAME,XIANG union all select code.CNAME,[XIANG],'净增' as Type, sum (case when [SEN_LIN_LB] like '21%' and [Q_SEN_LB] not like '21%' then [MIAN_JI] else 0 end ) - sum (case when [SEN_LIN_LB] not like '21%' and [Q_SEN_LB] like '21%' then [MIAN_JI] else 0 end ) as zdspld, sum (case when [SEN_LIN_LB] like '21%' and [Q_SEN_LB] not like '21%' and [LIN_ZHONG] like '2%' then [MIAN_JI] else 0 end ) - sum (case when [SEN_LIN_LB] not like '21%' and [Q_SEN_LB] like '21%' and [LIN_ZHONG] like '2%' then [MIAN_JI] else 0 end ) as zdspld_spl, sum (case when [SEN_LIN_LB] like '21%' and [Q_SEN_LB] not like '21%' and [LIN_ZHONG] like '23%' then [MIAN_JI]  else 0 end ) - sum (case when [SEN_LIN_LB] not like '21%' and [Q_SEN_LB] like '21%' and [LIN_ZHONG] like '23%' then [MIAN_JI]  else 0 end ) as zdspld_spl_ycl, sum (case when [SEN_LIN_LB] like '21%' and [Q_SEN_LB] not like '21%' and [LIN_ZHONG] like '24%' then [MIAN_JI]  else 0 end ) - sum (case when [SEN_LIN_LB] not like '21%' and [Q_SEN_LB] like '21%' and [LIN_ZHONG] like '24%' then [MIAN_JI]  else 0 end ) as zdspld_spl_xtl, sum (case when [SEN_LIN_LB] like '21%' and [Q_SEN_LB] not like '21%' and [LIN_ZHONG] like '25%' then [MIAN_JI] else 0 end ) - sum (case when [SEN_LIN_LB] not like '21%' and [Q_SEN_LB] like '21%' and [LIN_ZHONG] like '25%' then [MIAN_JI] else 0 end ) as zdspld_spl_jjl, sum (case when [SEN_LIN_LB] like '21%' and [Q_SEN_LB] not like '21%' and [LIN_ZHONG] not like '2%' then [MIAN_JI] else 0 end ) - sum (case when [SEN_LIN_LB] not like '21%' and [Q_SEN_LB] like '21%' and [LIN_ZHONG] not like '2%' then [MIAN_JI] else 0 end ) as zdspld_qtld, sum (case when [SEN_LIN_LB] like '22%' and [Q_SEN_LB] not like '22%' then [MIAN_JI] else 0 end ) - sum (case when [SEN_LIN_LB] not like '22%' and [Q_SEN_LB] like '22%' then [MIAN_JI] else 0 end ) as ybspld, sum (case when [SEN_LIN_LB] like '22%' and [Q_SEN_LB] not like '22%' and [LIN_ZHONG] like '2%' then [MIAN_JI] else 0 end ) - sum (case when [SEN_LIN_LB] not like '22%' and [Q_SEN_LB] like '22%' and [LIN_ZHONG] like '2%' then [MIAN_JI] else 0 end ) as ybspld_spl, sum (case when [SEN_LIN_LB] like '22%' and [Q_SEN_LB] not like '22%' and [LIN_ZHONG] like '23%' then [MIAN_JI]  else 0 end ) - sum (case when [SEN_LIN_LB] not like '22%' and [Q_SEN_LB] like '22%' and [LIN_ZHONG] like '23%' then [MIAN_JI]  else 0 end ) as ybspld_spl_ycl, sum (case when [SEN_LIN_LB] like '22%' and [Q_SEN_LB] not like '22%' and [LIN_ZHONG] like '24%' then [MIAN_JI]  else 0 end ) - sum (case when [SEN_LIN_LB] not like '22%' and [Q_SEN_LB] like '22%' and [LIN_ZHONG] like '24%' then [MIAN_JI]  else 0 end ) as ybspld_spl_xtl, sum (case when [SEN_LIN_LB] like '22%' and [Q_SEN_LB] not like '22%' and [LIN_ZHONG] like '25%' then [MIAN_JI]  else 0 end ) - sum (case when [SEN_LIN_LB] not like '22%' and [Q_SEN_LB] like '22%' and [LIN_ZHONG] like '25%' then [MIAN_JI]  else 0 end ) as ybspld_spl_jjl, sum (case when [SEN_LIN_LB] like '22%' and [Q_SEN_LB] not like '22%' and [LIN_ZHONG] not like '2%' then [MIAN_JI] else 0 end ) - sum (case when [SEN_LIN_LB] not like '22%' and [Q_SEN_LB] like '22%' and [LIN_ZHONG] not like '2%' then [MIAN_JI] else 0 end ) as ybspld_qtld FROM " + this.pTable_XB_now + " as xb inner join " + this.pTable_Code + " as code on xb.XIANG = code.CCODE group by code.CNAME,XIANG )as MergeSJ inner join " + this.pTable_Code + " as code on MergeSJ.XIANG = code.CCODE group by cube(MergeSJ.CNAME),Type order by MIN(code.ccode),MergeSJ.CNAME,case Type when '现状' then 1 when '新增' then 2 when '减少' then 3 when '净增' then 4 end");
        }

        private string pSQL_ZYBH_B1_GLTDMJBHB()
        {
            return string.Concat(new object[] { 
                " select xb_Merge.* from ( select '[统计单位]' = case when code.CNAME IS NULL and (xb_cube.tjdw = '' or xb_cube.tjdw IS NULL) then '合  计' when code.CNAME IS NULL and (xb_cube.tjdw <> '' and xb_cube.tjdw IS NOT NULL) then xb_cube.tjdw else code.CNAME end, xb_cube.* from ( Select 'tjdw'= xiang, case when (GROUPING (tjnd) = 1) then '合  计' else ISNULL(tjnd,'null') end as 统计年度, SUM(cld_mj + hjld_mj + hsld_mj + zld_mj + sld_mj + gmld_gg_mj + gmld_qt_mj + wcld_zl_mj + wcld_fy_mj + mpd_mj + wlmld_cf_mj + wlmld_hs_mj + wlmld_qt_mj + yilind_hshd + yilind_shd + yilind_qt + fzd_mj1 + fzd_mj2 + fld1 + fld2 + fld3 + ndgmjjld + ndqmld + ndzld + bzd_mj) as 总面积, SUM(cld_mj + hjld_mj + hsld_mj + zld_mj + sld_mj + gmld_gg_mj + gmld_qt_mj + wcld_zl_mj + wcld_fy_mj + mpd_mj + wlmld_cf_mj + wlmld_hs_mj + wlmld_qt_mj + yilind_hshd + yilind_shd + yilind_qt + fzd_mj1 + fzd_mj2 + bzd_mj) as 林地, SUM(cld_mj + hjld_mj + hsld_mj + zld_mj) as 有林地, sum(cld_mj + hjld_mj) as 乔木林, SUM(cld_mj) as 纯林地, SUM(hjld_mj) as 混交林地, sum(hsld_mj) as 红树林, sum(zld_mj) as 竹林, SUM(sld_mj) as 疏林地, SUM(gmld_gg_mj + gmld_qt_mj) as 灌木林地小计, sum(gmld_gg_mj) as 国家灌, sum(gmld_gg_jjl_mj) as 国家灌木经济林, SUM(gmld_qt_mj)as 其它灌, SUM(wcld_zl_mj + wcld_fy_mj) as 未成林地, SUM(wcld_zl_mj) as 未成林造林地, SUM(wcld_fy_mj) as 未成林封育地, SUM(mpd_mj)as 苗圃地, SUM(wlmld_cf_mj + wlmld_hs_mj + wlmld_qt_mj)as 无立木林地, SUM(wlmld_cf_mj)as 采伐迹地, SUM(wlmld_hs_mj)as 火烧迹地, SUM(wlmld_qt_mj)as 其它无立木林地, SUM(yilind_hshd + yilind_shd + yilind_qt) as 宜林地, SUM(yilind_hshd) as 宜林荒山荒地, SUM(yilind_shd + yilind_qt) as 其它宜林地, SUM(fzd_mj1 + fzd_mj2)as 辅助地, SUM(bzd_mj)as 被占地, SUM(fld1 + fld2 + fld3 + ndgmjjld + ndqmld + ndzld) as 非林地, SUM(ndqmld) as 农地乔木林, SUM(ndgmjjld) as 农地经济林, SUM(ndzld) as 农地竹林, SUM(spsmj) as 四旁树面积, cast(isnull((cast((sum(spsmj) + sum(ndgmjjld)+ sum(ndqmld) + sum(ndzld) + sum(gmld_gg_mj) + sum(cld_mj + hjld_mj + zld_mj)) as float) /cast(sum(nullif(cld_mj + hjld_mj + hsld_mj + zld_mj + sld_mj + gmld_gg_mj + gmld_qt_mj + wcld_zl_mj + wcld_fy_mj + mpd_mj + wlmld_cf_mj + wlmld_hs_mj + wlmld_qt_mj + yilind_hshd + yilind_shd + yilind_qt + fzd_mj1 + fzd_mj2 + fld1 + fld2 + fld3 + ndgmjjld + ndqmld + ndzld + bzd_mj,0)) as float)) * 100,0) as decimal(18,2)) as 森林覆盖率, cast(isnull((cast((sum(spsmj) + sum(ndgmjjld)+ sum(ndqmld) + sum(ndzld) + sum(gmld_gg_mj) + SUM(gmld_qt_mj) + sum(cld_mj + hjld_mj + hsld_mj + zld_mj)) as float) /cast(sum(nullif((cld_mj + hjld_mj + hsld_mj + zld_mj + sld_mj + gmld_gg_mj + gmld_qt_mj + wcld_zl_mj + wcld_fy_mj + mpd_mj + wlmld_cf_mj + wlmld_hs_mj + wlmld_qt_mj + yilind_hshd + yilind_shd + yilind_qt + fzd_mj1 + fzd_mj2 + fld1 + fld2 + fld3 + ndgmjjld + ndqmld + ndzld + bzd_mj),0)) as float) * 100),0) as decimal(18,2)) as 林木覆盖率 FROM( select 'XIANG' = XIANG, 'tjnd' = '", this.pLastND, "', SUM (case when [DI_LEI] = '111' then convert(decimal(18,1),[YXMJ]) else 0 end) as cld_mj, SUM (case when [DI_LEI] = '112' then convert(decimal(18,1),[YXMJ]) else 0 end) as hjld_mj, SUM (case when [DI_LEI] = '120' then convert(decimal(18,1),[YXMJ]) else 0 end) as hsld_mj, SUM (case when [DI_LEI] = '130' then convert(decimal(18,1),[YXMJ]) else 0 end) as zld_mj, SUM (case when [DI_LEI] = '200' then convert(decimal(18,1),[YXMJ]) else 0 end) as sld_mj, SUM (case when [DI_LEI] = '301' then convert(decimal(18,1),[YXMJ]) else 0 end) as gmld_gg_mj, SUM (case when [DI_LEI] = '301' and [LIN_ZHONG] like '25%' then convert(decimal(18,1),[YXMJ]) else 0 end) as gmld_gg_jjl_mj, SUM (case when [DI_LEI] = '302' then convert(decimal(18,1),[YXMJ]) else 0 end) as gmld_qt_mj, SUM (case when [DI_LEI] = '401' OR [DI_LEI] = '403' then convert(decimal(18,1),[YXMJ]) else 0 end) as wcld_zl_mj, SUM (case when [DI_LEI] = '402' OR [DI_LEI] = '404' then convert(decimal(18,1),[YXMJ]) else 0 end) as wcld_fy_mj, SUM (case when [DI_LEI] = '500' then convert(decimal(18,1),[YXMJ]) else 0 end) as mpd_mj, SUM (case when [DI_LEI] = '601' then convert(decimal(18,1),[YXMJ]) else 0 end) as wlmld_cf_mj, SUM (case when [DI_LEI] = '602' then convert(decimal(18,1),[YXMJ]) else 0 end) as wlmld_hs_mj, SUM (case when [DI_LEI] like '603%' then convert(decimal(18,1),[YXMJ]) else 0 end) as wlmld_qt_mj, SUM (case when [DI_LEI] = '701' then convert(decimal(18,1),[YXMJ]) else 0 end ) as yilind_hshd, SUM (case when [DI_LEI] = '702' then convert(decimal(18,1),[YXMJ]) else 0 end ) as yilind_shd, SUM (case when [DI_LEI] like '7%' and [DI_LEI] <> '701' and [DI_LEI] <> '702' then convert(decimal(18,1),[YXMJ]) else 0 end ) as yilind_qt, SUM (case when [DI_LEI] = '800' then convert(decimal(18,1),[YXMJ]) else 0 end) as fzd_mj1, SUM (case when [DI_LEI] = '850' then convert(decimal(18,1),[YXMJ]) else 0 end) as bzd_mj, sum (case when [DI_LEI] like '9%' and [DI_LEI] not like '96%' then convert(decimal(18,1),[YXMJ]) else 0 end ) as fld1, sum (case when [DI_LEI] = '961' then convert(decimal(18,1),[YXMJ]) else 0 end ) as ndqmld, sum (case when [DI_LEI] = '962' then convert(decimal(18,1),[YXMJ]) else 0 end ) as ndgmjjld, sum (case when [DI_LEI] = '963' then convert(decimal(18,1),[YXMJ]) else 0 end ) as ndzld, sum (case when [SSLX] = '2' then convert(decimal(18,1),[SSZZS])/1650 else 0 end ) as spsmj, sum (case when ([XZWZL] = '11' or [XZWZL] = '12' or [XZWZL] = '41' or [XZWZL] = '42') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fzd_mj2, sum (case when ([XZWZL] = '13' or [XZWZL] = '14' or [XZWZL] = '23' or [XZWZL] = '31' or [XZWZL] = '32') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fld2, sum (case when ([XZWZL] = '21' or [XZWZL] = '22') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fld3 FROM ", this.pTable_XB_last, " group by XIANG  union all  select 'XIANG' = XIANG, 'tjnd' = '", this.pNowND, "', SUM (case when [DI_LEI] = '111' then convert(decimal(18,1),[YXMJ]) else 0 end) as cld_mj, SUM (case when [DI_LEI] = '112' then convert(decimal(18,1),[YXMJ]) else 0 end) as hjld_mj, SUM (case when [DI_LEI] = '120' then convert(decimal(18,1),[YXMJ]) else 0 end) as hsld_mj, SUM (case when [DI_LEI] = '130' then convert(decimal(18,1),[YXMJ]) else 0 end) as zld_mj, SUM (case when [DI_LEI] = '200' then convert(decimal(18,1),[YXMJ]) else 0 end) as sld_mj, SUM (case when [DI_LEI] = '301' then convert(decimal(18,1),[YXMJ]) else 0 end) as gmld_gg_mj, SUM (case when [DI_LEI] = '301' and [LIN_ZHONG] like '25%' then convert(decimal(18,1),[YXMJ]) else 0 end) as gmld_gg_jjl_mj, SUM (case when [DI_LEI] = '302' then convert(decimal(18,1),[YXMJ]) else 0 end) as gmld_qt_mj, SUM (case when [DI_LEI] = '401' OR [DI_LEI] = '403' then convert(decimal(18,1),[YXMJ]) else 0 end) as wcld_zl_mj, SUM (case when [DI_LEI] = '402' OR [DI_LEI] = '404' then convert(decimal(18,1),[YXMJ]) else 0 end) as wcld_fy_mj, SUM (case when [DI_LEI] = '500' then convert(decimal(18,1),[YXMJ]) else 0 end) as mpd_mj, SUM (case when [DI_LEI] = '601' then convert(decimal(18,1),[YXMJ]) else 0 end) as wlmld_cf_mj, SUM (case when [DI_LEI] = '602' then convert(decimal(18,1),[YXMJ]) else 0 end) as wlmld_hs_mj, SUM (case when [DI_LEI] like '603%' then convert(decimal(18,1),[YXMJ]) else 0 end) as wlmld_qt_mj, SUM (case when [DI_LEI] = '701' then convert(decimal(18,1),[YXMJ]) else 0 end ) as yilind_hshd, SUM (case when [DI_LEI] = '702' then convert(decimal(18,1),[YXMJ]) else 0 end ) as yilind_shd, SUM (case when [DI_LEI] like '7%' and [DI_LEI] <> '701' and [DI_LEI] <> '702' then convert(decimal(18,1),[YXMJ]) else 0 end ) as yilind_qt, SUM (case when [DI_LEI] = '800' then convert(decimal(18,1),[YXMJ]) else 0 end) as fzd_mj1, SUM (0) as bzd_mj, sum (case when [DI_LEI] like '9%' and [DI_LEI] not like '96%' then convert(decimal(18,1),[YXMJ]) else 0 end ) as fld1, sum (case when [DI_LEI] = '961' then convert(decimal(18,1),[YXMJ]) else 0 end ) as ndqmld, sum (case when [DI_LEI] = '962' then convert(decimal(18,1),[YXMJ]) else 0 end ) as ndgmjjld, sum (case when [DI_LEI] = '963' then convert(decimal(18,1),[YXMJ]) else 0 end ) as ndzld, sum (case when [SSLX] = '2' then round(cast([SSZZS] as float)/cast(1650 as float),1) else 0 end ) as spsmj, sum (case when ([XZWZL] = '11' or [XZWZL] = '12' or [XZWZL] = '41' or [XZWZL] = '42') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fzd_mj2, sum (case when ([XZWZL] = '13' or [XZWZL] = '14' or [XZWZL] = '23' or [XZWZL] = '31' or [XZWZL] = '32') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fld2, sum (case when ([XZWZL] = '21' or [XZWZL] = '22') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fld3 FROM   ", this.pTable_XB_now, " where TDJYQ not like '7%' group by XIANG union all /*除线状物外的其它被占地类面积*/ select 'XIANG' = XIANG, 'tjnd' = '", this.pNowND, "', SUM (0) as cld_mj, SUM (0) as hjld_mj, SUM (0) as hsld_mj, SUM (0) as zld_mj, SUM (0) as sld_mj, SUM (0) as gmld_gg_mj, SUM (0) as gmld_gg_jjl_mj, SUM (0) as gmld_qt_mj, SUM (0) as wcld_zl_mj, SUM (0) as wcld_fy_mj, SUM (0) as mpd_mj, SUM (0) as wlmld_cf_mj, SUM (0) as wlmld_hs_mj, SUM (0) as wlmld_qt_mj, SUM (0) as yilind_hshd, SUM (0) as yilind_shd, SUM (0) as yilind_qt, SUM (0) as fzd_mj1, SUM (case when [TDJYQ] like '7%' then convert(decimal(18,1),[YXMJ]) else 0 end) as bzd_mj, sum (0) as fld1, sum (0) as ndqmld, sum (0) as ndgmjjld, sum (0) as ndzld, sum (0) as spsmj, sum (case when ([XZWZL] = '11' or [XZWZL] = '12') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fzd_mj2, sum (case when ([XZWZL] = '13' or [XZWZL] = '14' or [XZWZL] = '23' or [XZWZL] = '31' or [XZWZL] = '32') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fld2, sum (case when ([XZWZL] = '21' or [XZWZL] = '22') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fld3 FROM   ", this.pTable_XB_now, " where TDJYQ like '7%' group by XIANG /*线状物的被占面积*/ union all select 'XIANG' = XIANG, 'tjnd' = '", this.pNowND, "', SUM (0) as cld_mj, SUM (0) as hjld_mj, SUM (0) as hsld_mj, SUM (0) as zld_mj, SUM (0) as sld_mj, SUM (0) as gmld_gg_mj, SUM (0) as gmld_gg_jjl_mj, SUM (0) as gmld_qt_mj, SUM (0) as wcld_zl_mj, SUM (0) as wcld_fy_mj, SUM (0) as mpd_mj, SUM (0) as wlmld_cf_mj, SUM (0) as wlmld_hs_mj, SUM (0) as wlmld_qt_mj, SUM (0) as yilind_hshd, SUM (0) as yilind_shd, SUM (0) as yilind_qt, SUM (0) as fzd_mj1, SUM (case when ([XZWZL] = '41' or [XZWZL] = '42') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as bzd_mj, sum (0) as fld1, sum (0) as ndqmld, sum (0) as ndgmjjld, sum (0) as ndzld, sum (0) as spsmj, sum (0) as fzd_mj2, sum (0) as fld2, sum (0) as fld3 FROM   ", this.pTable_XB_now,
                " where TDJYQ like '7%' group by XIANG ) as xb group by cube(XIANG),tjnd ) as xb_cube left join ", this.pTable_Code, " as code on xb_cube.tjdw = code.CCODE and code.CTYPE = '乡' ) as xb_Merge order by xb_Merge.tjdw,统计年度"
            });
        }

        private string pSQL_ZYBH_B2_GLSLLMMJXJBHB()
        {
            return string.Concat(new object[] { " select xb_Merge.* from ( select '[统计单位]' = case when code.CNAME IS NULL and (xb_cube.tjdw = '' or xb_cube.tjdw IS NULL) then '合  计' when code.CNAME IS NULL and (xb_cube.tjdw <> '' and xb_cube.tjdw IS NOT NULL) then xb_cube.tjdw else code.CNAME end, xb_cube.* from ( select 'tjdw' = xiang, 'tjnd' = '", this.pLastND, "', SUM(cld_xj + hjld_xj + sld_xj + sps_xj + ss_xj + fql_xj) as 总蓄积量, SUM(cld_mj + hjld_mj + hsld_mj + zld_mj) as 有林地面积, sum(cld_mj + hjld_mj) as 乔木林面积, SUM(cld_xj + hjld_xj) as 乔木林蓄积, SUM(cld_mj) as 纯林地面积, SUM(cld_xj) as 纯林地蓄积, SUM(hjld_mj) as 混交林地面积, SUM(hjld_xj) as 混交林地蓄积, sum(hsld_mj) as 红树林面积, sum(zld_mj) as 竹林面积, cast(SUM(zld_zs)/cast(10000 as float) as decimal(8,2)) as 竹林株数, SUM(sld_mj) as 疏林地面积, SUM(sld_xj) as 疏林地蓄积, cast(SUM(sps_zs)/cast(10000 as float) as decimal(8,2)) as 四旁树株数, SUM (sps_xj) as 四旁树蓄积, cast(SUM(ss_zs)/cast(10000 as float) as decimal(8,2)) as 散生树株数, SUM (ss_xj) as 散生树蓄积, SUM(fql_mj) as 非乔林面积, SUM(fql_xj) as 非乔林蓄积 FROM( select 'xiang' = xiang, SUM (case when [DI_LEI] = '111' then convert(decimal(18,1),[YXMJ]) else 0 end) as cld_mj, SUM (case when [DI_LEI] = '111' then convert(decimal(18,0),[SLXJ]) else 0 end) as cld_xj, SUM (case when [DI_LEI] = '112' then convert(decimal(18,1),[YXMJ]) else 0 end) as hjld_mj, SUM (case when [DI_LEI] = '112' then convert(decimal(18,0),[SLXJ]) else 0 end) as hjld_xj, SUM (case when [DI_LEI] = '120' then convert(decimal(18,1),[YXMJ]) else 0 end) as hsld_mj, SUM (case when [DI_LEI] = '130' then convert(decimal(18,1),[YXMJ]) else 0 end) as zld_mj, SUM (case when [DI_LEI] = '130' then cast(convert(decimal(18,1),[YXMJ]) * MEI_GQ_ZS as float) else 0 end) as zld_zs, SUM (case when [DI_LEI] = '200' then convert(decimal(18,1),[YXMJ]) else 0 end) as sld_mj, SUM (case when [DI_LEI] = '200' then convert(decimal(18,0),[SLXJ]) else 0 end) as sld_xj, SUM (0) as sps_zs, SUM (0) as sps_xj, SUM (0) as ss_zs, SUM (0) as ss_xj, SUM (case when [DI_LEI] = '961' then convert(decimal(18,1),[YXMJ]) else 0 end) as fql_mj, SUM (case when [DI_LEI] = '961' then convert(decimal(18,0),[SLXJ]) else 0 end) as fql_xj FROM  ", this.pTable_XB_last, " as xb where DI_LEI in ('111','112','120','130','200','961') group by xiang  union all select xiang, SUM (0) as cld_mj, SUM (0) as cld_xj, SUM (0) as hjld_mj, SUM (0) as hjld_xj, SUM (0) as hsld_mj, SUM (0) as zld_mj, SUM (0) as zld_zs, SUM (0) as sld_mj, SUM (0) as sld_xj, SUM (case when [SSLX] = '2' then SSZZS else 0 end ) as sps_zs, SUM (case when [SSLX] = '2' then [SSXJ] else 0 end ) as sps_xj, SUM (case when [SSLX] = '1' then SSZZS else 0 end ) as ss_zs, SUM (case when [SSLX] = '1' then [SSXJ] else 0 end ) as ss_xj, SUM (0) as fql_mj, SUM (0) as fql_xj FROM  ", this.pTable_XB_last, " as xb where sslx <> '' and DI_LEI <> '850' group by xiang )as xb group by cube(xb.xiang)  union all  Select 'tjdw' = xiang, 'tjnd' = '", this.pNowND, "', SUM(cld_xj + hjld_xj + sld_xj + sps_xj + ss_xj + fql_xj) as 总蓄积量, SUM(cld_mj + hjld_mj + hsld_mj + zld_mj) as 有林地面积, sum(cld_mj + hjld_mj) as 乔木林面积, SUM(cld_xj + hjld_xj) as 乔木林蓄积, SUM(cld_mj) as 纯林地面积, SUM(cld_xj) as 纯林地蓄积, SUM(hjld_mj) as 混交林地面积, SUM(hjld_xj) as 混交林地蓄积, sum(hsld_mj) as 红树林面积, sum(zld_mj) as 竹林面积, cast(SUM(zld_zs)/cast(10000 as float) as decimal(8,2)) as 竹林株数, SUM(sld_mj) as 疏林地面积, SUM(sld_xj) as 疏林地蓄积, cast(SUM(sps_zs)/cast(10000 as float) as decimal(8,2)) as 四旁树株数, SUM (sps_xj) as 四旁树蓄积, cast(SUM(ss_zs)/cast(10000 as float) as decimal(8,2)) as 散生树株数, SUM (ss_xj) as 散生树蓄积, SUM(fql_mj) as 非乔林面积, SUM(fql_xj) as 非乔林蓄积 FROM( select xiang, SUM (case when [DI_LEI] = '111' then convert(decimal(18,1),[YXMJ]) else 0 end) as cld_mj, SUM (case when [DI_LEI] = '111' then convert(decimal(18,0),[SLXJ]) else 0 end) as cld_xj, SUM (case when [DI_LEI] = '112' then convert(decimal(18,1),[YXMJ]) else 0 end) as hjld_mj, SUM (case when [DI_LEI] = '112' then convert(decimal(18,0),[SLXJ]) else 0 end) as hjld_xj, SUM (case when [DI_LEI] = '120' then convert(decimal(18,1),[YXMJ]) else 0 end) as hsld_mj, SUM (case when [DI_LEI] = '130' then convert(decimal(18,1),[YXMJ]) else 0 end) as zld_mj, SUM (case when [DI_LEI] = '130' then cast(convert(decimal(18,1),[YXMJ]) * MEI_GQ_ZS as float) else 0 end) as zld_zs, SUM (case when [DI_LEI] = '200' then convert(decimal(18,1),[YXMJ]) else 0 end) as sld_mj, SUM (case when [DI_LEI] = '200' then convert(decimal(18,0),[SLXJ]) else 0 end) as sld_xj, SUM (0) as sps_zs, SUM (0) as sps_xj, SUM (0) as ss_zs, SUM (0) as ss_xj, SUM (case when [DI_LEI] = '961' then convert(decimal(18,1),[YXMJ]) else 0 end) as fql_mj, SUM (case when [DI_LEI] = '961' then convert(decimal(18,0),[SLXJ]) else 0 end) as fql_xj FROM  ", this.pTable_XB_now, " as xb group by xiang  union all  select xiang, SUM (0) as cld_mj, SUM (0) as cld_xj, SUM (0) as hjld_mj, SUM (0) as hjld_xj, SUM (0) as hsld_mj, SUM (0) as zld_mj, SUM (0) as zld_zs, SUM (0) as sld_mj, SUM (0) as sld_xj, SUM (case when [SSLX] = '2' then SSZZS else 0 end ) as sps_zs, SUM (case when [SSLX] = '2' then [SSXJ] else 0 end ) as sps_xj, SUM (case when [SSLX] = '1' then SSZZS else 0 end ) as ss_zs, SUM (case when [SSLX] = '1' then [SSXJ] else 0 end ) as ss_xj, SUM (0) as fql_mj, SUM (0) as fql_xj FROM  ", this.pTable_XB_now, " as xb group by xiang )as xb group by cube(xb.xiang) ) as xb_cube LEFT JOIN ", this.pTable_Code, " as code on xb_cube.tjdw = code.CCODE and code.CTYPE = '乡' ) as xb_Merge order by xb_Merge.tjdw,tjnd" });
        }

        private string pSQL_ZYBH_B3_GLZMJXJBHB()
        {
            return string.Concat(new object[] { " Select case when (GROUPING (code.CNAME) = 1) then '合计' else ISNULL(code.CNAME,'null') end as 统计单位, case when (GROUPING (nd) = 1) then '合计' else ISNULL(nd,'null') end as 年度, SUM(fhl_mj + tyl_mj + ycl_mj + xtl_mj + jjl_mj) as 总面积, SUM(fhl_xj + tyl_xj + ycl_xj + xtl_xj + jjl_xj) as 总蓄积, SUM(fhl_mj) as 防护林面积, SUM(fhl_xj) as 防护林蓄积, SUM(tyl_mj) as 特用林面积, SUM(tyl_xj) as 特用林蓄积, SUM(ycl_mj) as 用材林面积, SUM(ycl_xj) as 用材林蓄积, SUM(xtl_mj) as 薪炭林面积, SUM(xtl_xj) as 薪炭林蓄积, SUM(jjl_mj) as 经济林面积, SUM(jjl_xj) as 经济林蓄积 FROM( select [XIANG] as tjdw, 'nd' = '", this.pLastND, "年', SUM (case when [LIN_ZHONG] like '11%' then convert(decimal(18,1),[YXMJ]) else 0 end) as fhl_mj, SUM (case when [LIN_ZHONG] like '11%' then convert(decimal(18,0),[SLXJ]) else 0 end) as fhl_xj, SUM (case when [LIN_ZHONG] like '12%' then convert(decimal(18,1),[YXMJ]) else 0 end) as tyl_mj, SUM (case when [LIN_ZHONG] like '12%' then convert(decimal(18,0),[SLXJ]) else 0 end) as tyl_xj, SUM (case when [LIN_ZHONG] like '23%' then convert(decimal(18,1),[YXMJ]) else 0 end) as ycl_mj, SUM (case when [LIN_ZHONG] like '23%' then convert(decimal(18,0),[SLXJ]) else 0 end) as ycl_xj, SUM (case when [LIN_ZHONG] = '240' then convert(decimal(18,1),[YXMJ]) else 0 end) as xtl_mj, SUM (case when [LIN_ZHONG] = '240' then convert(decimal(18,0),[SLXJ]) else 0 end) as xtl_xj, SUM (case when [LIN_ZHONG] like '25%' then convert(decimal(18,1),[YXMJ]) else 0 end) as jjl_mj, SUM (case when [LIN_ZHONG] like '25%' then convert(decimal(18,0),[SLXJ]) else 0 end ) as jjl_xj FROM ", this.pTable_XB_last, " where convert(decimal(18,0),[DI_LEI]) < 400 group by XIANG  union all  select [XIANG] as tjdw, 'nd' = '", this.pNowND, "年', SUM (case when [LIN_ZHONG] like '11%' then convert(decimal(18,1),[YXMJ]) else 0 end) as fhl_mj, SUM (case when [LIN_ZHONG] like '11%' then convert(decimal(18,0),[SLXJ]) else 0 end) as fhl_xj, SUM (case when [LIN_ZHONG] like '12%' then convert(decimal(18,1),[YXMJ]) else 0 end) as tyl_mj, SUM (case when [LIN_ZHONG] like '12%' then convert(decimal(18,0),[SLXJ]) else 0 end) as tyl_xj, SUM (case when [LIN_ZHONG] like '23%' then convert(decimal(18,1),[YXMJ]) else 0 end) as ycl_mj, SUM (case when [LIN_ZHONG] like '23%' then convert(decimal(18,0),[SLXJ]) else 0 end) as ycl_xj, SUM (case when [LIN_ZHONG] = '240' then convert(decimal(18,1),[YXMJ]) else 0 end) as xtl_mj, SUM (case when [LIN_ZHONG] = '240' then convert(decimal(18,0),[SLXJ]) else 0 end) as xtl_xj, SUM (case when [LIN_ZHONG] like '25%' then convert(decimal(18,1),[YXMJ]) else 0 end) as jjl_mj, SUM (case when [LIN_ZHONG] like '25%' then convert(decimal(18,0),[SLXJ]) else 0 end ) as jjl_xj FROM ", this.pTable_XB_now, " where convert(decimal(18,0),[DI_LEI]) < 400 group by XIANG  ) as xb LEFT JOIN ", this.pTable_Code, " as code on xb.tjdw = code.CCODE and code.CTYPE = '乡' group by cube(code.CNAME),nd order by min(code.CCODE),code.CNAME,nd" });
        }

        private string pSQL_ZYBH_B4_ZYSZMJXJBHB()
        {
            return (" select Table_order.* FROM ( Select case when (GROUPING (Table_now.统计单位) = 1) then '合计' else ISNULL(Table_now.统计单位,'null') end as 统计单位, case when (GROUPING (Table_now.sz) = 1) then '合计' else ISNULL(Table_now.sz,'null') end as 优势树种, 'last_mj' = SUM(isnull(Table_last.last_mj,0.0)),'last_xj' = SUM(isnull(Table_last.last_xj,0)), SUM(Table_now.now_mj) as 'now_mj',SUM(Table_now.now_xj) as 'now_xj', 'bhl_mj' = convert(decimal(18,1),SUM(Table_now.now_mj - isnull(Table_last.last_mj,0.0))), 'bhl_xj' = convert(decimal(18,1),SUM(Table_now.now_xj - isnull(Table_last.last_xj,0.0))), 'bhlv_mj' = case when SUM(Table_now.now_mj) > 0 and SUM(isnull(Table_last.last_mj,0)) = 0 then 100 else convert(decimal(18,1),SUM(Table_now.now_mj - isnull(Table_last.last_mj,0.0))/SUM(nullif(isnull(Table_last.last_mj,0.0),0.0)) * 100) end, 'bhlv_xj' = case when SUM(Table_now.now_xj) > 0 and SUM(isnull(Table_last.last_xj,0)) = 0 then 100 when SUM(isnull(Table_last.last_xj,0)) = 0 then 0 else convert(decimal(18,1),SUM(Table_now.now_xj - isnull(Table_last.last_xj,0.0))/SUM(nullif(isnull(Table_last.last_xj,0.0),0.0)) * 100) end FROM ( select case when (GROUPING (XIANG) = 1) then '合计' else ISNULL(XIANG,'null') end as 'tjdw', case when (GROUPING (code.CNAME) = 1) then '合计' else ISNULL(code.CNAME,'null') end as '统计单位', case when (GROUPING (szmerge) = 1) then '合计' else ISNULL(szmerge,'null') end as 'sz', SUM(convert(decimal(18,1),[YXMJ])) as 'now_mj', SUM(convert(decimal(18,0),[SLXJ])) as 'now_xj' FROM " + this.pTable_XB_now + " as xb LEFT JOIN " + this.pTable_Code + " as code on xb.XIANG = code.CCODE and code.CTYPE = '乡' where [szmerge] <> '' group by cube(code.CNAME,[szmerge]),XIANG ) as Table_now  LEFT JOIN  ( select case when (GROUPING (XIANG) = 1) then '合计' else ISNULL(XIANG,'null') end as 'tjdw', case when (GROUPING (code.CNAME) = 1) then '合计' else ISNULL(code.CNAME,'null') end as '统计单位', case when (GROUPING (szmerge) = 1) then '合计' else ISNULL(szmerge,'null') end as 'sz', SUM(convert(decimal(18,1),[YXMJ])) as 'last_mj', SUM(convert(decimal(18,0),[SLXJ])) as 'last_xj' FROM " + this.pTable_XB_last + " as xb LEFT JOIN " + this.pTable_Code + " as code on xb.XIANG = code.CCODE and code.CTYPE = '乡' where [szmerge] <> '' group by cube(code.CNAME,[szmerge]),XIANG ) as Table_last ON Table_now.sz = Table_last.sz and Table_now.tjdw = Table_last.tjdw group by Table_now.统计单位,Table_now.sz ) as Table_order LEFT JOIN " + this.pTable_Code + " as Table_code on Table_order.统计单位 = Table_code.CNAME and Table_code.CTYPE = '乡' LEFT JOIN " + this.pTable_slszhb + " as Table_slszhb on Table_order.优势树种 = Table_slszhb.CNAME order by Table_code.CCODE,Table_slszhb.SORTID");
        }

        private string pSQL_ZYBH_B5_YCLMJXJBHB()
        {
            return string.Concat(new object[] { " Select case when (GROUPING (code.CNAME) = 1) then '合计' else ISNULL(code.CNAME,'合计') end as 统计单位, case when (GROUPING (sz) = 1) then '合计' else ISNULL(sz,'合计') end as 优势树种, case when (GROUPING (nd) = 1) then '合计' else ISNULL(nd,'null') end as 年度, SUM(yll_mj + zll_mj + jsl_mj + csl_mj + gsl_mj) as 总面积, SUM(yll_xj + zll_xj + jsl_xj + csl_xj + gsl_xj) as 总蓄积, SUM(yll_mj) as 幼龄林面积, SUM(yll_xj) as 幼龄林蓄积, SUM(zll_mj) as 中龄林面积, SUM(zll_xj) as 中龄林蓄积, SUM(jsl_mj) as 近熟林面积, SUM(jsl_xj) as 近熟林蓄积, SUM(csl_mj) as 成熟林面积, SUM(csl_xj) as 成熟林蓄积, SUM(gsl_mj) as 过熟林面积, SUM(gsl_xj) as 过熟林蓄积 FROM( select [XIANG] as 'tjdw', [szmerge] as 'sz', 'nd' ='", this.pLastND, "年', SUM (case when [LING_ZU] = '1' then convert(decimal(18,1),[YXMJ]) else 0 end) as yll_mj, SUM (case when [LING_ZU] = '1' then convert(decimal(18,0),[SLXJ]) else 0 end) as yll_xj, SUM (case when [LING_ZU] = '2' then convert(decimal(18,1),[YXMJ]) else 0 end) as zll_mj, SUM (case when [LING_ZU] = '2' then convert(decimal(18,0),[SLXJ]) else 0 end) as zll_xj, SUM (case when [LING_ZU] = '3' then convert(decimal(18,1),[YXMJ]) else 0 end) as jsl_mj, SUM (case when [LING_ZU] = '3' then convert(decimal(18,0),[SLXJ]) else 0 end) as jsl_xj, SUM (case when [LING_ZU] = '4' then convert(decimal(18,1),[YXMJ]) else 0 end) as csl_mj, SUM (case when [LING_ZU] = '4' then convert(decimal(18,0),[SLXJ]) else 0 end) as csl_xj, SUM (case when [LING_ZU] = '5' then convert(decimal(18,1),[YXMJ]) else 0 end) as gsl_mj, SUM (case when [LING_ZU] = '5' then convert(decimal(18,0),[SLXJ]) else 0 end) as gsl_xj FROM ", this.pTable_XB_last, " where convert(decimal(18,0),[DI_LEI]) <= 200 and DI_LEI <> '130' and LIN_ZHONG like '23%' group by cube(XIANG,[szmerge])  union all  select [XIANG] as 'tjdw', [szmerge] as 'sz', 'nd' = '", this.pNowND, "年', SUM (case when [LING_ZU] = '1' then convert(decimal(18,1),[YXMJ]) else 0 end) as yll_mj, SUM (case when [LING_ZU] = '1' then convert(decimal(18,0),[SLXJ]) else 0 end) as yll_xj, SUM (case when [LING_ZU] = '2' then convert(decimal(18,1),[YXMJ]) else 0 end) as zll_mj, SUM (case when [LING_ZU] = '2' then convert(decimal(18,0),[SLXJ]) else 0 end) as zll_xj, SUM (case when [LING_ZU] = '3' then convert(decimal(18,1),[YXMJ]) else 0 end) as jsl_mj, SUM (case when [LING_ZU] = '3' then convert(decimal(18,0),[SLXJ]) else 0 end) as jsl_xj, SUM (case when [LING_ZU] = '4' then convert(decimal(18,1),[YXMJ]) else 0 end) as csl_mj, SUM (case when [LING_ZU] = '4' then convert(decimal(18,0),[SLXJ]) else 0 end) as csl_xj, SUM (case when [LING_ZU] = '5' then convert(decimal(18,1),[YXMJ]) else 0 end) as gsl_mj, SUM (case when [LING_ZU] = '5' then convert(decimal(18,0),[SLXJ]) else 0 end) as gsl_xj FROM ", this.pTable_XB_now, " where convert(decimal(18,0),[DI_LEI]) <= 200 and DI_LEI <> '130' and LIN_ZHONG like '23%' group by cube(XIANG,[szmerge]) ) as xb LEFT JOIN ", this.pTable_Code, " as code on xb.tjdw = code.CCODE and code.CTYPE = '乡' group by code.CNAME,sz,nd order by min(code.CCODE),code.CNAME,sz,nd" });
        }

        private SqlConnection SQLDataConfig()
        {
            SqlConnection connection = new SqlConnection();
            string pConn = this.pConn;
            connection.ConnectionString = pConn;
            string pDataBase = this.pDataBase;
            string text1 = string.Concat(new object[] { "[", pDataBase, "].[dbo].[FOR_XIAOBAN_", this.pNowND, "]" });
            string text2 = string.Concat(new object[] { "[", pDataBase, "].[dbo].[FOR_XIAOBAN_", this.pLastND, "]" });
            this.pTable_XB_now = "[" + pDataBase + "].[dbo].[XBSZMERGE_NOW]";
            this.pTable_XB_last = "[" + pDataBase + "].[dbo].[XBSZMERGE_LAST]";
            this.pTable_Code = "[" + pDataBase + "].[dbo].[T_SYS_META_CODE]";
            this.pTable_slszhb = "[" + pDataBase + "].[dbo].[T_SYS_META_SLSZHB]";
            this.pTable_qmlszhb = "[" + pDataBase + "].[dbo].[T_SYS_META_QMLSZHB]";
            this.pTable_gmlszhb = "[" + pDataBase + "].[dbo].[T_SYS_META_GMLSZHB]";
            this.pTable_jjlszhb = "[" + pDataBase + "].[dbo].[T_SYS_META_JJLSZHB]";
            this.pTable_yclszhb = "[" + pDataBase + "].[dbo].[T_SYS_META_YCLSZHB]";
            this.pTable_hslszhb = "[" + pDataBase + "].[dbo].[T_SYS_META_HSLSZHB]";
            this.pNowND = int.Parse(this.pDataBase.Substring(this.pDataBase.Length - 4, 4));
            this.pLastND = this.pNowND - 1;
            connection.ConnectionString = pConn;
            SqlCommand selectCommand = new SqlCommand(" select cname from " + this.pTable_Code + " where ccode='" + this.pDataBase.Substring(8, 6) + "' and CTYPE = '县'", connection);
            selectCommand.CommandTimeout = 60;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            connection.Close();
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            this.pXianName = dataTable.Rows[0][0].ToString();
            return connection;
        }

        private long UpdateTempXBT_Table()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = this.pConn;
            string pDataBase = this.pDataBase;
            string str3 = string.Concat(new object[] { "[", pDataBase, "].[dbo].[FOR_XIAOBAN_", this.pNowND, "]" });
            string str4 = string.Concat(new object[] { "[", pDataBase, "].[dbo].[FOR_XIAOBAN_", this.pLastND, "]" });
            SqlCommand selectCommand = new SqlCommand("select top 1 * from " + str3, connection);
            selectCommand.CommandTimeout = 60;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            string str6 = "";
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                string columnName = dataTable.Columns[i].ColumnName;
                if (columnName.ToLower().ToString().Trim() != "shape")
                {
                    str6 = str6 + columnName + ",";
                }
            }
            selectCommand = new SqlCommand(" use " + pDataBase + " if not exists (select name from sysobjects where [name] = 'XBSZMERGE_NOW' and xtype='U') begin select " + str6.TrimEnd(new char[] { ',' }) + " into " + this.pTable_XB_now + " from " + str3 + " alter table " + this.pTable_XB_now + " add szmerge varchar(10) alter table " + this.pTable_XB_now + " add szmerge_xj varchar(10) end else begin drop table " + this.pTable_XB_now + " select " + str6.TrimEnd(new char[] { ',' }) + " into " + this.pTable_XB_now + " from " + str3 + " alter table " + this.pTable_XB_now + " add szmerge varchar(10) alter table " + this.pTable_XB_now + " add szmerge_xj varchar(10) end", connection);
            selectCommand.CommandTimeout = 60;
            adapter = new SqlDataAdapter(selectCommand);
            DataTable table2 = new DataTable();
            adapter.Fill(table2);
            selectCommand = new SqlCommand(" use " + pDataBase + " if not exists (select name from sysobjects where [name] = 'XBSZMERGE_LAST' and xtype='U') begin select " + str6.TrimEnd(new char[] { ',' }) + " into " + this.pTable_XB_last + " from " + str4 + " alter table " + this.pTable_XB_last + " add szmerge varchar(10) alter table " + this.pTable_XB_last + " add szmerge_xj varchar(10) end else begin drop table " + this.pTable_XB_last + " select " + str6.TrimEnd(new char[] { ',' }) + " into " + this.pTable_XB_last + " from " + str4 + " alter table " + this.pTable_XB_last + " add szmerge varchar(10) alter table " + this.pTable_XB_last + " add szmerge_xj varchar(10) end", connection);
            selectCommand.CommandTimeout = 60;
            adapter = new SqlDataAdapter(selectCommand);
            table2 = new DataTable();
            adapter.Fill(table2);
            return 0L;
        }
    }
}

