namespace DataEdit
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraTab;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormSetGeographicCoordinateSystem : FormBase2
    {
        private ComboBoxEdit comDatumName;
        private ComboBoxEdit comMeridian;
        private IContainer components = null;
        private ComboBoxEdit comSpheroidName;
        private ComboBoxEdit comUnit;
        public bool FlagOk = false;
        private GroupControl groupControl1;
        private GroupControl groupControl2;
        private GroupControl groupControl3;
        private Label label1;
        private Label label10;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private ArrayList mDatumList = null;
        private ArrayList mMeridianList = null;
        private ArrayList mShperoidList = null;
        private ISpatialReference mSpatialReference = null;
        private ArrayList mUnitList = null;
        private Panel panel1;
        private Panel panel10;
        private Panel panel12;
        private Panel panel13;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private PanelControl panelSpheroid;
        private RadioGroup radioAxis;
        private SimpleButton sButCancel;
        private TextEdit txtCoordinateName;
        private TextEdit txtDu;
        private TextEdit txtFen;
        private TextEdit txtInverseFlatter;
        private TextEdit txtMiao;
        private TextEdit txtperUnit;
        private TextEdit txtSemimajorName;
        private TextEdit txtSemiminorName;
        private XtraTabControl xtraTabControl1;
        private XtraTabPage xtraTabPage1;

        public FormSetGeographicCoordinateSystem()
        {
            this.InitializeComponent();
        }

        private void comDatumName_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.comDatumName.Properties.Items.Count != 0)
                {
                    if (this.comDatumName.SelectedIndex == 0)
                    {
                        this.comSpheroidName.Enabled = true;
                        this.panelSpheroid.Enabled = true;
                    }
                    else
                    {
                        this.comSpheroidName.Enabled = false;
                        this.panelSpheroid.Enabled = false;
                        for (int i = 0; i < this.mDatumList.Count; i++)
                        {
                            IDatum datum = this.mDatumList[i] as IDatum;
                            if (datum.Name == this.comDatumName.Text)
                            {
                                for (int j = 0; j < this.mShperoidList.Count; j++)
                                {
                                    ISpheroid spheroid = this.mShperoidList[j] as ISpheroid;
                                    if (spheroid.Name == datum.Spheroid.Name)
                                    {
                                        this.comSpheroidName.Text = spheroid.Name;
                                        this.txtSemimajorName.Text = spheroid.SemiMajorAxis.ToString("0.0000000000000000");
                                        this.txtSemiminorName.Text = spheroid.SemiMinorAxis.ToString("0.0000000000000000");
                                        if (spheroid.Flattening == 0.0)
                                        {
                                            this.txtInverseFlatter.Text = spheroid.Flattening.ToString();
                                        }
                                        else
                                        {
                                            this.txtInverseFlatter.Text = (1.0 / spheroid.Flattening).ToString("0.0000000000000000");
                                        }
                                        return;
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

        private void comSpheroidName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.comSpheroidName.SelectedIndex == 0)
            {
                this.radioAxis.Enabled = true;
                this.txtSemimajorName.Enabled = true;
                this.txtSemiminorName.Enabled = true;
            }
            else
            {
                this.radioAxis.Enabled = false;
                this.txtSemimajorName.Enabled = false;
                this.txtSemiminorName.Enabled = false;
                this.txtInverseFlatter.Enabled = false;
                for (int i = 0; i < this.mShperoidList.Count; i++)
                {
                    ISpheroid spheroid = this.mShperoidList[i] as ISpheroid;
                    if (spheroid.Name == this.comSpheroidName.Text)
                    {
                        this.txtSemimajorName.Text = spheroid.SemiMajorAxis.ToString("0.0000000000000000");
                        this.txtSemiminorName.Text = spheroid.SemiMinorAxis.ToString("0.0000000000000000");
                        if (spheroid.Flattening == 0.0)
                        {
                            this.txtInverseFlatter.Text = spheroid.Flattening.ToString();
                        }
                        else
                        {
                            this.txtInverseFlatter.Text = (1.0 / spheroid.Flattening).ToString("0.0000000000000000");
                        }
                        break;
                    }
                }
            }
        }

        private void comUnit_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.comUnit.Properties.Items.Count != 0)
            {
                if (this.comUnit.SelectedIndex == 0)
                {
                    this.txtperUnit.Enabled = true;
                }
                else
                {
                    this.txtperUnit.Enabled = false;
                    for (int i = 0; i < this.mUnitList.Count; i++)
                    {
                        IAngularUnit unit = this.mUnitList[i] as IAngularUnit;
                        if (unit.Name == this.comUnit.Text)
                        {
                            this.txtperUnit.Text = unit.RadiansPerUnit.ToString("0.0000000000000000");
                            break;
                        }
                    }
                }
            }
        }

        private void comUnitName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.comMeridian.Properties.Items.Count != 0)
            {
                if (this.comMeridian.SelectedIndex == 0)
                {
                    this.txtDu.Enabled = true;
                    this.txtFen.Enabled = true;
                    this.txtMiao.Enabled = true;
                }
                else
                {
                    this.txtDu.Enabled = false;
                    this.txtFen.Enabled = false;
                    this.txtMiao.Enabled = false;
                    for (int i = 0; i < this.mMeridianList.Count; i++)
                    {
                        IPrimeMeridian meridian = this.mMeridianList[i] as IPrimeMeridian;
                        if (meridian.Name == this.comMeridian.Text)
                        {
                            int longitude = (int) meridian.Longitude;
                            this.txtDu.Text = longitude.ToString();
                            this.txtFen.Text = ((int) ((meridian.Longitude - ((int) meridian.Longitude)) * 60.0)).ToString();
                            this.txtMiao.Text = (((meridian.Longitude - ((int) meridian.Longitude)) - (((double) ((int) ((meridian.Longitude - ((int) meridian.Longitude)) * 60.0))) / 60.0)) * 3600.0).ToString("0.000000");
                            break;
                        }
                    }
                }
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

        private bool InitialComDatumList(IDatum pDatum)
        {
            try
            {
                this.mDatumList = new ArrayList();
                IDatum datum = null;
                ISpatialReferenceFactory3 factory = new SpatialReferenceEnvironmentClass();
                this.comDatumName.Properties.Items.Clear();
                this.comDatumName.Properties.Sorted = true;
                bool flag = false;
                string[] strArray = "6001,6002,6003,6004,6005,6006,6007,6008,6009,6010,6011,6012,6013,6014,6015,6016,6018,6019,6020,6021,6022,6023,6024,6025,6027,6028,6029,6031,6032,6033,6034,6035,6036,6042,6044,6045,6047,6052,6053,6054,6120,6121,6122,6123,6124,6125,6126,6127,6128,6129,6130,6131,6132,6133,6134,6135,6136,6137,6138,6139,6140,6140,6141,6142,6143,6144,6145,6146,6147,6148,6149,6150,6151,6152,6153,6154,6155,6156,6157,6158,6159,6160,6161,6162,6163,6164,6165,6166,6167,6168,6169,6170,6171,6172,6173,6174,6175,6176,6178,6179,6180,6181,6182,6183,6184,6185,6188,6189,6190,6191,6192,6193,6194,6195,6196,6198,6199,6200,6201,6202,6203,6204,6205,6206,6207,6208,6209,6210,6211,6212,6213,6214,6215,6216,6217,6218,6219,6220,6221,6222,6223,6224,6225,6226,6227,6228,6229,6230,6231,6232,6233,6234,6235,6236,6237,6238,6239,6240,6241,6242,6243,6244,6245,6246,6247,6248,6249,6250,6251,6252,6253,6254,6255,6256,6257,6258,6259,6260,6261,6262,6263,6264,6265,6266,6267,6268,6269,6270,6271,6272,6273,6274,6275,6276,6277,6278,6279,6280,6281,6282,6283,6284,6285,6286,6287,6288,6289,6291,6292,6293,6294,6295,6296,6297,6298,6299,6300,6301,6302,6303,6304,6305,6306,6307,6308,6309,6310,6311,6312,6313,6314,6315,6316,6317,6318,6319,6322,6324,6326,6600,6601,6602,6603,6604,6605,6606,6607,6608,6609,6610,6611,6612,6613,6614,6615,6616,6619,6620,6621,6622,6623,6624,6625,6626,6626,6627,6628,6629,6630,6631,6632,6633,6634,6636,6637,6638,6639,6640,6641,6642,6643,6644,6645,6646,6647,6648,6649,6650,6651,6652,6653,6654,6655,6656,6657,6658,6659,6660,6661,6663,6664,6665,6666,6667,6668,6670,6671,6672,6673,6674,6675,6676,6677,6678,6679,6680,6682,6683,6684,6686,6687,6688,6689,6690,6691,6692,6693,6694,6695,6696,6697,6698,6699,6700,6701,6702,6703,6704,6705,6706,6707,6708,6709,6710,6711,6712,6713,6714,6715,6716,6717,6718,6719,6720,6721,6722,6723,6724,6725,6726,6727,6728,6729,6730,6731,6732,6733,6734,6735,6736,6737,6738,6739,6740,6741,6742,6743,6744,6745,6746,6747,6748,6749,6750,6753,6754,6755,6756,6757,6758,6759,6760,6896,6901,6902,6903,106002,106003,106004,106005,106006,106007,106008,106101,106102,106103,106202,106203,106206,106207,106218,106221,106240,106241,106243,106245,106249,106257,106258,106260,106262,106263,106266,106269,106270,106271,106274,106275,106276,106277,106278,106279,106281,106282,106283,106700,106701,106702,106703,106704,106705,106706,106707,106708,106709,106710,106711,106712,106713,106714,106715,106716,106717,106718,106719,106720,106721,106722,106723,106724,106725,106726,106727,106728,106729,106730,106731,106732,106733,106734,106735,106736,106737,106738,106739,106740,106741,106742,106743,106744,106745,106746,106747,106748,106749,106750,106751,106752,106753,106754,106755,106756,106757,106758,106759,106760,106761,106762,106763,106764,106765,106766,106767,106768,106769,106770,106771,106772,106773,106774,106775,106776,106777,106778,106779,106780,106781,106782,106783,106784,106785,106800,106801,106802,106803,106804,106805,106806,106807,106808,106809,106810,106811,106812,106813,106814,106815,106816,106817,106818,106819,106820,106821,106822,106823,106824,106825,106826,106827,106828,106829,106830,106831,106832,106833,106834,106835,106836,106837,106838,106839,106840,106841,106842,106843,106844,106845,106846,106847,106848,106849,106850,106851,106852,106853,106854,106855,106856,106857,106858,106900,106901,106902,106903,106904,106905,106906,106907,106908,106909,106910,106911,106912,106913,106914,106915,106916,106917,106918,106919,106920,106921,106922,106923,106924,106925,106926,106927,106928,106929,106930,106931,106932,106933,106934,106935,106936,106937,106938,106939,106940,106941,106942,106943,106944,106945,106946,106947,106948,106949,106950,106951,106952,106953,106954,106955,106956,106957,106958,106959,106960,106961,106962,106963,106964,106965,106966,106967,106968,106969,106970".Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    try
                    {
                        datum = factory.CreateDatum(int.Parse(strArray[i]));
                        if (datum.Name != "")
                        {
                            if (datum.Name == pDatum.Name)
                            {
                                flag = true;
                            }
                            this.comDatumName.Properties.Items.Add(datum.Name);
                            this.mDatumList.Add(datum);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                ISpheroid spheroid = new SpheroidClass();
                ISpheroidEdit edit = spheroid as ISpheroidEdit;
                object name = "Spheroid_China_2000";
                object alias = "Spheroid__China_2000";
                object abbreviation = "GCS2000";
                object remarks = "The spheroid is China_2000";
                object majorAxis = 0x615299;
                object flattening = 0.0033528106811823188;
                edit.Define(ref name, ref alias, ref abbreviation, ref remarks, ref majorAxis, ref flattening);
                datum = new DatumClass();
                IDatumEdit edit2 = datum as IDatumEdit;
                object obj8 = "D_China_2000";
                object obj9 = "D_China_2000";
                object obj10 = "DChina2000";
                object obj11 = "DChina2000 is the datum";
                object obj12 = spheroid;
                edit2.Define(ref obj8, ref obj9, ref obj10, ref obj11, ref obj12);
                this.comDatumName.Properties.Items.Add(datum.Name);
                this.mDatumList.Add(datum);
                if (!flag)
                {
                    this.comDatumName.Properties.Items.Add("<custom>");
                    this.mDatumList.Add(pDatum);
                }
                else
                {
                    this.comDatumName.Properties.Items.Add("<custom>");
                    this.mDatumList.Add(pDatum);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool InitialComMeridianList(IPrimeMeridian pPrimeMeridian)
        {
            try
            {
                IPrimeMeridian meridian = null;
                this.mMeridianList = new ArrayList();
                ISpatialReferenceFactory3 factory = new SpatialReferenceEnvironmentClass();
                bool flag = false;
                this.comMeridian.Properties.Items.Clear();
                this.comMeridian.Properties.Sorted = true;
                for (int i = 0x22c5; i < 0x22d1; i++)
                {
                    try
                    {
                        meridian = factory.CreatePrimeMeridian(i);
                        if ((meridian != null) && (meridian.Name != ""))
                        {
                            this.comMeridian.Properties.Items.Add(meridian.Name);
                            this.mMeridianList.Add(meridian);
                            if (meridian.Name == pPrimeMeridian.Name)
                            {
                                flag = true;
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                if (!flag)
                {
                    this.comMeridian.Properties.Items.Add("<custom>");
                    this.mMeridianList.Add(pPrimeMeridian);
                }
                else
                {
                    this.comMeridian.Properties.Items.Add("<custom>");
                    this.mMeridianList.Add(pPrimeMeridian);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool InitialComShperoidList(ISpheroid pSpheroid)
        {
            try
            {
                this.mShperoidList = new ArrayList();
                ISpheroid spheroid = null;
                ISpatialReferenceFactory3 factory = new SpatialReferenceEnvironmentClass();
                this.comSpheroidName.Properties.Items.Clear();
                this.comSpheroidName.Properties.Sorted = true;
                bool flag = false;
                string[] strArray = "7001,7002,7003,7004,7005,7006,7007,7008,7009,7010,7011,7012,7013,7014,7015,7016,7018,7019,7020,7021,7022,7023,7024,7025,7026,7027,7028,7029,7030,7031,7032,7033,7034,7035,7036,7041,7042,7043,7044,7045,7048,7049,7051,7052,7053,7054,7055,7057,7058,107001,107002,107003,107004,107006,107007,107008,107009,107036,107037,107700,107701,107702,107703,107704,107705,107706,107707,107708,107709,107710,107711,107712,107713,107714,107715,107716,107717,107718,107719,107720,107721,107722,107723,107724,107725,107726,107727,107728,107729,107730,107731,107732,107733,107734,107735,107736,107737,107738,107739,107740,107741,107742,107743,107744,107745,107746,107747,107748,107749,107750,107751,107752,107753,107754,107755,107756,107757,107758,107759,107760,107761,107762,107763,107764,107765,107766,107767,107768,107769,107770,107771,107772,107773,107774,107775,107776,107777,107778,107779,107780,107781,107782,107783,107784,107785,107800,107801,107802,107803,107804,107805,107806,107807,107808,107809,107810,107811,107812,107813,107814,107815,107816,107817,107818,107819,107820,107821,107822,107823,107824,107825,107826,107827,107828,107829,107830,107831,107832,107833,107834,107835,107836,107837,107838,107839,107840,107841,107842,107843,107844,107845,107846,107847,107848,107849,107850,107851,107852,107853,107854,107855,107856,107857,107858,107900,107901,107902,107903,107904,107905,107906,107907,107908,107909,107910,107911,107912,107913,107914,107915,107916,107917,107918,107919,107920,107921,107922,107923,107924,107925,107926,107927,107928,107929,107930,107931,107932,107933,107934,107935,107936,107937,107938,107939,107940,107941,107942,107943,107944,107945,107946,107947,107948,107949,107950,107951,107952,107953,107954,107955,107956,107957,107958,107959,107960,107961,107962,107963,107964,107965,107966,107967,107968,107969,107970".Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    try
                    {
                        spheroid = factory.CreateSpheroid(int.Parse(strArray[i]));
                        if (spheroid.Name != "")
                        {
                            if (spheroid.Name == pSpheroid.Name)
                            {
                                flag = true;
                            }
                            this.comSpheroidName.Properties.Items.Add(spheroid.Name);
                            this.mShperoidList.Add(spheroid);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                spheroid = new SpheroidClass();
                ISpheroidEdit edit = spheroid as ISpheroidEdit;
                object name = "Spheroid_China_2000";
                object alias = "Spheroid__China_2000";
                object abbreviation = "GCS2000";
                object remarks = "The spheroid is China_2000";
                object majorAxis = 0x615299;
                object flattening = 0.0033528106811823188;
                edit.Define(ref name, ref alias, ref abbreviation, ref remarks, ref majorAxis, ref flattening);
                this.comSpheroidName.Properties.Items.Add(spheroid.Name);
                this.mShperoidList.Add(spheroid);
                if (!flag)
                {
                    this.comSpheroidName.Properties.Items.Add("<custom>");
                    this.mShperoidList.Add(pSpheroid);
                }
                else
                {
                    this.comSpheroidName.Properties.Items.Add("<custom>");
                    this.mShperoidList.Add(pSpheroid);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool InitialComUnitList(IAngularUnit pAngularUnit)
        {
            try
            {
                int num;
                IAngularUnit unit = null;
                this.mUnitList = new ArrayList();
                ISpatialReferenceFactory3 factory = new SpatialReferenceEnvironmentClass();
                bool flag = false;
                this.comUnit.Properties.Items.Clear();
                this.comUnit.Properties.Sorted = true;
                for (num = 0x2329; num < 0x239b; num++)
                {
                    try
                    {
                        unit = factory.CreateUnit(num) as IAngularUnit;
                        if ((unit != null) && (unit.Name != ""))
                        {
                            this.comUnit.Properties.Items.Add(unit.Name);
                            this.mUnitList.Add(unit);
                            if (unit.Name == pAngularUnit.Name)
                            {
                                flag = true;
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                for (num = 0x1a9c9; num < 0x1a9e8; num++)
                {
                    try
                    {
                        unit = factory.CreateUnit(num) as IAngularUnit;
                        if ((unit != null) && (unit.Name != ""))
                        {
                            this.comUnit.Properties.Items.Add(unit.Name);
                            this.mUnitList.Add(unit);
                            if (unit.Name == pAngularUnit.Name)
                            {
                                flag = true;
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                if (!flag)
                {
                    this.comUnit.Properties.Items.Add("<custom>");
                    this.mUnitList.Add(pAngularUnit);
                }
                else
                {
                    this.comUnit.Properties.Items.Add("<custom>");
                    this.mUnitList.Add(pAngularUnit);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void InitializeComponent()
        {
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label5 = new System.Windows.Forms.Label();
            this.panelSpheroid = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtInverseFlatter = new DevExpress.XtraEditors.TextEdit();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txtSemiminorName = new DevExpress.XtraEditors.TextEdit();
            this.radioAxis = new DevExpress.XtraEditors.RadioGroup();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtSemimajorName = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.comSpheroidName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comDatumName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.panel12 = new System.Windows.Forms.Panel();
            this.txtperUnit = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.comUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtMiao = new DevExpress.XtraEditors.TextEdit();
            this.txtFen = new DevExpress.XtraEditors.TextEdit();
            this.txtDu = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.comMeridian = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCoordinateName = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.sButCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSpheroid)).BeginInit();
            this.panelSpheroid.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInverseFlatter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSemiminorName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioAxis.Properties)).BeginInit();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSemimajorName.Properties)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comSpheroidName.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comDatumName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtperUnit.Properties)).BeginInit();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMiao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDu.Properties)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comMeridian.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoordinateName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sButOk
            // 
            this.sButOk.Location = new System.Drawing.Point(276, 573);
            this.sButOk.Visible = true;
            this.sButOk.Click += new System.EventHandler(this.sButOk_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraTabControl1.Location = new System.Drawing.Point(8, 8);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(418, 554);
            this.xtraTabControl1.TabIndex = 6;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupControl1);
            this.xtraTabPage1.Controls.Add(this.panel5);
            this.xtraTabPage1.Controls.Add(this.groupControl3);
            this.xtraTabPage1.Controls.Add(this.panel4);
            this.xtraTabPage1.Controls.Add(this.groupControl2);
            this.xtraTabPage1.Controls.Add(this.panel2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Padding = new System.Windows.Forms.Padding(8);
            this.xtraTabPage1.Size = new System.Drawing.Size(412, 525);
            this.xtraTabPage1.Text = "普通";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.panelSpheroid);
            this.groupControl1.Controls.Add(this.panel3);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(8, 44);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(8);
            this.groupControl1.Size = new System.Drawing.Size(396, 251);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Tag = "";
            this.groupControl1.Text = "大地基准面";
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(19, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 26);
            this.label5.TabIndex = 11;
            this.label5.Text = "椭球体";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelSpheroid
            // 
            this.panelSpheroid.Controls.Add(this.panel1);
            this.panelSpheroid.Controls.Add(this.radioAxis);
            this.panelSpheroid.Controls.Add(this.panel9);
            this.panelSpheroid.Controls.Add(this.panel8);
            this.panelSpheroid.Location = new System.Drawing.Point(9, 89);
            this.panelSpheroid.Name = "panelSpheroid";
            this.panelSpheroid.Padding = new System.Windows.Forms.Padding(6);
            this.panelSpheroid.Size = new System.Drawing.Size(380, 160);
            this.panelSpheroid.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtInverseFlatter);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.txtSemiminorName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(86, 80);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 9, 0, 9);
            this.panel1.Size = new System.Drawing.Size(286, 72);
            this.panel1.TabIndex = 13;
            // 
            // txtInverseFlatter
            // 
            this.txtInverseFlatter.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtInverseFlatter.Enabled = false;
            this.txtInverseFlatter.Location = new System.Drawing.Point(0, 41);
            this.txtInverseFlatter.Name = "txtInverseFlatter";
            this.txtInverseFlatter.Size = new System.Drawing.Size(286, 20);
            this.txtInverseFlatter.TabIndex = 3;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 29);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(286, 12);
            this.panel10.TabIndex = 4;
            // 
            // txtSemiminorName
            // 
            this.txtSemiminorName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSemiminorName.Location = new System.Drawing.Point(0, 9);
            this.txtSemiminorName.Name = "txtSemiminorName";
            this.txtSemiminorName.Size = new System.Drawing.Size(286, 20);
            this.txtSemiminorName.TabIndex = 2;
            // 
            // radioAxis
            // 
            this.radioAxis.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioAxis.Location = new System.Drawing.Point(8, 80);
            this.radioAxis.Name = "radioAxis";
            this.radioAxis.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioAxis.Properties.Appearance.Options.UseBackColor = true;
            this.radioAxis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioAxis.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "短半轴"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "扁率倒数")});
            this.radioAxis.Size = new System.Drawing.Size(78, 72);
            this.radioAxis.TabIndex = 12;
            this.radioAxis.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.txtSemimajorName);
            this.panel9.Controls.Add(this.label7);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(8, 44);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(0, 4, 0, 8);
            this.panel9.Size = new System.Drawing.Size(364, 36);
            this.panel9.TabIndex = 11;
            // 
            // txtSemimajorName
            // 
            this.txtSemimajorName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSemimajorName.Location = new System.Drawing.Point(60, 4);
            this.txtSemimajorName.Name = "txtSemimajorName";
            this.txtSemimajorName.Size = new System.Drawing.Size(304, 20);
            this.txtSemimajorName.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(0, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 24);
            this.label7.TabIndex = 1;
            this.label7.Text = "长半轴";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.comSpheroidName);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(8, 8);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(0, 6, 0, 8);
            this.panel8.Size = new System.Drawing.Size(364, 36);
            this.panel8.TabIndex = 10;
            // 
            // comSpheroidName
            // 
            this.comSpheroidName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comSpheroidName.Location = new System.Drawing.Point(60, 6);
            this.comSpheroidName.Name = "comSpheroidName";
            this.comSpheroidName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comSpheroidName.Size = new System.Drawing.Size(304, 20);
            this.comSpheroidName.TabIndex = 2;
            this.comSpheroidName.SelectedValueChanged += new System.EventHandler(this.comSpheroidName_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(0, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 22);
            this.label6.TabIndex = 1;
            this.label6.Text = "名称";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comDatumName);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 30);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 8);
            this.panel3.Size = new System.Drawing.Size(376, 36);
            this.panel3.TabIndex = 9;
            // 
            // comDatumName
            // 
            this.comDatumName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comDatumName.Location = new System.Drawing.Point(67, 4);
            this.comDatumName.Name = "comDatumName";
            this.comDatumName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comDatumName.Size = new System.Drawing.Size(309, 20);
            this.comDatumName.TabIndex = 2;
            this.comDatumName.SelectedValueChanged += new System.EventHandler(this.comDatumName_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "名称";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(8, 295);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(396, 8);
            this.panel5.TabIndex = 13;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.panel12);
            this.groupControl3.Controls.Add(this.panel13);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl3.Location = new System.Drawing.Point(8, 303);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.groupControl3.Size = new System.Drawing.Size(396, 103);
            this.groupControl3.TabIndex = 14;
            this.groupControl3.Text = "角度单位";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.txtperUnit);
            this.panel12.Controls.Add(this.label8);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(10, 57);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(7, 7, 7, 9);
            this.panel12.Size = new System.Drawing.Size(376, 40);
            this.panel12.TabIndex = 11;
            // 
            // txtperUnit
            // 
            this.txtperUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtperUnit.Enabled = false;
            this.txtperUnit.Location = new System.Drawing.Point(77, 7);
            this.txtperUnit.Name = "txtperUnit";
            this.txtperUnit.Size = new System.Drawing.Size(292, 20);
            this.txtperUnit.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(7, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 24);
            this.label8.TabIndex = 1;
            this.label8.Text = "弧度/单位";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.comUnit);
            this.panel13.Controls.Add(this.label9);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(10, 22);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(7, 7, 7, 5);
            this.panel13.Size = new System.Drawing.Size(376, 35);
            this.panel13.TabIndex = 10;
            // 
            // comUnit
            // 
            this.comUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comUnit.Location = new System.Drawing.Point(77, 7);
            this.comUnit.Name = "comUnit";
            this.comUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comUnit.Size = new System.Drawing.Size(292, 20);
            this.comUnit.TabIndex = 2;
            this.comUnit.SelectedValueChanged += new System.EventHandler(this.comUnit_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Location = new System.Drawing.Point(7, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 23);
            this.label9.TabIndex = 1;
            this.label9.Text = "名称";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(8, 406);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(396, 8);
            this.panel4.TabIndex = 11;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.panel7);
            this.groupControl2.Controls.Add(this.panel6);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(8, 414);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.groupControl2.Size = new System.Drawing.Size(396, 103);
            this.groupControl2.TabIndex = 10;
            this.groupControl2.Text = "初始子午线";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtMiao);
            this.panel7.Controls.Add(this.txtFen);
            this.panel7.Controls.Add(this.txtDu);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(10, 57);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(7, 7, 7, 9);
            this.panel7.Size = new System.Drawing.Size(376, 40);
            this.panel7.TabIndex = 11;
            // 
            // txtMiao
            // 
            this.txtMiao.Enabled = false;
            this.txtMiao.Location = new System.Drawing.Point(253, 7);
            this.txtMiao.Name = "txtMiao";
            this.txtMiao.Size = new System.Drawing.Size(114, 20);
            this.txtMiao.TabIndex = 5;
            // 
            // txtFen
            // 
            this.txtFen.Enabled = false;
            this.txtFen.Location = new System.Drawing.Point(166, 7);
            this.txtFen.Name = "txtFen";
            this.txtFen.Size = new System.Drawing.Size(70, 20);
            this.txtFen.TabIndex = 4;
            // 
            // txtDu
            // 
            this.txtDu.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtDu.Enabled = false;
            this.txtDu.Location = new System.Drawing.Point(77, 7);
            this.txtDu.Name = "txtDu";
            this.txtDu.Size = new System.Drawing.Size(70, 20);
            this.txtDu.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(7, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "经度";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(148, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(247, 26);
            this.label10.TabIndex = 6;
            this.label10.Text = "°                  ′                           ″";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.comMeridian);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(10, 22);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(7, 7, 7, 5);
            this.panel6.Size = new System.Drawing.Size(376, 35);
            this.panel6.TabIndex = 10;
            // 
            // comMeridian
            // 
            this.comMeridian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comMeridian.EditValue = "";
            this.comMeridian.Location = new System.Drawing.Point(77, 7);
            this.comMeridian.Name = "comMeridian";
            this.comMeridian.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comMeridian.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comMeridian.Size = new System.Drawing.Size(292, 20);
            this.comMeridian.TabIndex = 2;
            this.comMeridian.SelectedValueChanged += new System.EventHandler(this.comUnitName_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "名称";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtCoordinateName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(8, 8);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(8);
            this.panel2.Size = new System.Drawing.Size(396, 36);
            this.panel2.TabIndex = 8;
            // 
            // txtCoordinateName
            // 
            this.txtCoordinateName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCoordinateName.Enabled = false;
            this.txtCoordinateName.Location = new System.Drawing.Point(77, 8);
            this.txtCoordinateName.Name = "txtCoordinateName";
            this.txtCoordinateName.Size = new System.Drawing.Size(311, 20);
            this.txtCoordinateName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sButCancel
            // 
            this.sButCancel.Location = new System.Drawing.Point(353, 573);
            this.sButCancel.Name = "sButCancel";
            this.sButCancel.Size = new System.Drawing.Size(70, 28);
            this.sButCancel.TabIndex = 5;
            this.sButCancel.Text = "取消";
            this.sButCancel.Click += new System.EventHandler(this.sButCancel_Click);
            // 
            // FormSetGeographicCoordinateSystem
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(434, 612);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.sButCancel);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetGeographicCoordinateSystem";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "地理坐标系统属性";
            this.Controls.SetChildIndex(this.sButCancel, 0);
            this.Controls.SetChildIndex(this.sButOk, 0);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSpheroid)).EndInit();
            this.panelSpheroid.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtInverseFlatter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSemiminorName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioAxis.Properties)).EndInit();
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSemimajorName.Properties)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comSpheroidName.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comDatumName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtperUnit.Properties)).EndInit();
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMiao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDu.Properties)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comMeridian.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCoordinateName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        public void InitialValue(ISpatialReference pSpr)
        {
            try
            {
                if (pSpr != null)
                {
                    this.mSpatialReference = pSpr;
                    IProjectedCoordinateSystem system = pSpr as IProjectedCoordinateSystem;
                    IGeographicCoordinateSystem geographicCoordinateSystem = pSpr as IGeographicCoordinateSystem;
                    if (geographicCoordinateSystem == null)
                    {
                        geographicCoordinateSystem = system.GeographicCoordinateSystem;
                    }
                    if (geographicCoordinateSystem != null)
                    {
                        this.txtCoordinateName.Text = geographicCoordinateSystem.Name;
                        this.txtCoordinateName.Enabled = true;
                        this.InitialComDatumList(geographicCoordinateSystem.Datum);
                        this.comDatumName.Text = geographicCoordinateSystem.Datum.Name;
                        this.InitialComShperoidList(geographicCoordinateSystem.Datum.Spheroid);
                        this.comSpheroidName.Text = geographicCoordinateSystem.Datum.Spheroid.Name;
                        this.txtSemimajorName.Text = geographicCoordinateSystem.Datum.Spheroid.SemiMajorAxis.ToString("0.0000000000000000");
                        this.txtSemiminorName.Text = geographicCoordinateSystem.Datum.Spheroid.SemiMinorAxis.ToString("0.0000000000000000");
                        if (geographicCoordinateSystem.Datum.Spheroid.Flattening == 0.0)
                        {
                            this.txtInverseFlatter.Text = geographicCoordinateSystem.Datum.Spheroid.Flattening.ToString();
                        }
                        else
                        {
                            this.txtInverseFlatter.Text = (1.0 / geographicCoordinateSystem.Datum.Spheroid.Flattening).ToString("0.0000000000000000");
                        }
                        IAngularUnit coordinateUnit = geographicCoordinateSystem.CoordinateUnit;
                        this.InitialComUnitList(coordinateUnit);
                        this.txtperUnit.Text = coordinateUnit.RadiansPerUnit.ToString("0.0000000000000000");
                        this.comUnit.Text = coordinateUnit.Name;
                        IPrimeMeridian primeMeridian = geographicCoordinateSystem.PrimeMeridian;
                        this.InitialComMeridianList(primeMeridian);
                        this.comMeridian.Text = primeMeridian.Name;
                        int longitude = (int) primeMeridian.Longitude;
                        this.txtDu.Text = longitude.ToString();
                        this.txtFen.Text = ((int) ((primeMeridian.Longitude - ((int) primeMeridian.Longitude)) * 60.0)).ToString();
                        this.txtMiao.Text = (((primeMeridian.Longitude - ((int) primeMeridian.Longitude)) - (((double) ((int) ((primeMeridian.Longitude - ((int) primeMeridian.Longitude)) * 60.0))) / 60.0)) * 3600.0).ToString("0.000000");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioAxis.SelectedIndex == 0)
            {
                this.txtInverseFlatter.Enabled = false;
                this.txtSemiminorName.Enabled = true;
            }
            else
            {
                this.txtInverseFlatter.Enabled = true;
                this.txtSemiminorName.Enabled = false;
            }
        }

        private void sButCancel_Click(object sender, EventArgs e)
        {
            this.FlagOk = false;
            base.Hide();
        }

        private void sButOk_Click(object sender, EventArgs e)
        {
            this.FlagOk = true;
            base.Hide();
        }

        public IGeographicCoordinateSystem SetGeographicValue()
        {
            try
            {
                object missing;
                object obj3;
                int num;
                IProjectedCoordinateSystem mSpatialReference = this.mSpatialReference as IProjectedCoordinateSystem;
                IGeographicCoordinateSystem geographicCoordinateSystem = this.mSpatialReference as IGeographicCoordinateSystem;
                if (geographicCoordinateSystem == null)
                {
                    geographicCoordinateSystem = mSpatialReference.GeographicCoordinateSystem;
                }
                if (geographicCoordinateSystem == null)
                {
                    return null;
                }
                ISpatialReferenceFactory3 factory = new SpatialReferenceEnvironmentClass();
                ISpheroid spheroid = null;
                if (this.comSpheroidName.SelectedIndex == 0)
                {
                    spheroid = new SpheroidClass();
                    ISpheroidEdit edit = spheroid as ISpheroidEdit;
                    missing = System.Type.Missing;
                    obj3 = this.comSpheroidName.Text;
                    object majorAxis = this.txtSemimajorName.Text;
                    object flattening = 1.0 / double.Parse(this.txtInverseFlatter.Text);
                    edit.Define(ref obj3, ref missing, ref missing, ref missing, ref majorAxis, ref flattening);
                }
                else
                {
                    for (num = 0; num < this.mShperoidList.Count; num++)
                    {
                        ISpheroid spheroid2 = this.mShperoidList[num] as ISpheroid;
                        if (spheroid2.Name == this.comSpheroidName.Text)
                        {
                            spheroid = spheroid2;
                            break;
                        }
                    }
                }
                IDatum datum = null;
                if (this.comDatumName.SelectedIndex == 0)
                {
                    datum = new DatumClass();
                    IDatumEdit edit2 = datum as IDatumEdit;
                    missing = System.Type.Missing;
                    obj3 = this.comDatumName.Text;
                    object obj6 = spheroid;
                    edit2.Define(ref obj3, ref missing, ref missing, ref missing, ref obj6);
                }
                else
                {
                    for (num = 0; num < this.mDatumList.Count; num++)
                    {
                        IDatum datum2 = this.mDatumList[num] as IDatum;
                        if (datum2.Name == this.comDatumName.Text)
                        {
                            datum = datum2;
                            break;
                        }
                    }
                }
                IDatumEdit edit3 = datum as IDatumEdit;
                object name = datum.Name;
                object alias = datum.Alias;
                object abbreviation = datum.Abbreviation;
                object remarks = datum.Remarks;
                object obj11 = spheroid;
                edit3.Define(ref name, ref alias, ref abbreviation, ref remarks, ref obj11);
                IPrimeMeridian meridian = null;
                if (this.comMeridian.SelectedIndex == 0)
                {
                    meridian = new PrimeMeridianClass();
                    IPrimeMeridianEdit edit4 = meridian as IPrimeMeridianEdit;
                    missing = System.Type.Missing;
                    obj3 = this.comMeridian.Text;
                    object longitude = (double.Parse(this.txtDu.Text) + (double.Parse(this.txtFen.Text) / 60.0)) + (double.Parse(this.txtMiao.Text) / 3600.0);
                    edit4.Define(ref obj3, ref missing, ref missing, ref missing, ref longitude);
                }
                else
                {
                    for (num = 0; num < this.mMeridianList.Count; num++)
                    {
                        IPrimeMeridian meridian2 = this.mMeridianList[num] as IPrimeMeridian;
                        if (meridian2.Name == this.comMeridian.Text)
                        {
                            meridian = meridian2;
                            break;
                        }
                    }
                }
                IUnit unit = null;
                if (this.comUnit.SelectedIndex == 0)
                {
                    IAngularUnit unit2 = new AngularUnitClass();
                    IAngularUnitEdit edit5 = unit2 as IAngularUnitEdit;
                    missing = System.Type.Missing;
                    obj3 = this.comUnit.Text;
                    object radiansPerUnit = this.txtperUnit.Text;
                    edit5.Define(ref obj3, ref missing, ref missing, ref missing, ref radiansPerUnit);
                    unit = unit2;
                }
                else
                {
                    for (num = 0; num < this.mMeridianList.Count; num++)
                    {
                        IUnit unit3 = this.mUnitList[num] as IUnit;
                        if (unit3.Name == this.comUnit.Text)
                        {
                            unit = unit3;
                            break;
                        }
                    }
                }
                IGeographicCoordinateSystemEdit edit6 = new GeographicCoordinateSystemClass();
                object text = this.txtCoordinateName.Text;
                object obj15 = datum.Alias;
                object obj16 = datum.Abbreviation;
                object obj17 = datum.Remarks;
                object useage = "Suitable for China";
                object obj19 = datum;
                object primeMeridian = meridian;
                object geographicUnit = unit;
                edit6.Define(ref text, ref obj15, ref obj16, ref obj17, ref useage, ref obj19, ref primeMeridian, ref geographicUnit);
                return (edit6 as IGeographicCoordinateSystem);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

