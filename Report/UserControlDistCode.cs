namespace Report
{
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using td.db.mid.sys;
    using td.db.orm;
    using td.logic.sys;
    using Utilities;

    /// <summary>
    /// 用于显示行政区划的TreeList树的公用用户窗体。
    /// </summary>
    public class UserControlDistCode : UserControlBase1
    {
        private IContainer components;
        private const string mClassName = "Report.UserControlDistCode";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private TreeListColumn tlc_xzqh;
        /// <summary>
        /// 用于显示“行政区划”的TreeList树
        /// </summary>
        private TreeList treeList_XZQH;

        public UserControlDistCode()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 向TreeList树里加载乡名字
        /// </summary>
        /// <param name="pNode"></param>
        /// <param name="pCode"></param>
        private void AddTownNames(TreeListNode pNode, string pCode)
        {
            try
            {
                if (pNode.Nodes.Count <= 0)
                {
                   // foreach (DataRow row in this.GetDistNameCode("select XIANG,(select b.CNAME from T_SYS_META_CODE b where b.CCODE=a.XIANG and CINDEX='104') as xianname from BASE_P_XIANG_10K a where XIAN='" + pCode + "'").Rows)
                    foreach (T_SYS_META_CODE_Mid mid in MDM.FindXiang(pCode))
                    {
                        TreeListNode node = this.treeList_XZQH.AppendNode(mid.CCODE, pNode);
                        node.SetValue(0, mid.CNAME);
                        node.Tag = mid.CCODE;
                        node.Checked = true;
                        this.AddVillageNames(node, mid.CCODE);
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Report.UserControlDistCode", "AddTownNames", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        /// <summary>
        /// 向TreeList树里加载村名字
        /// </summary>
        /// <param name="pNode"></param>
        /// <param name="pCode"></param>
        private void AddVillageNames(TreeListNode pNode, string pCode)
        {
            try
            {
                if (pNode.Nodes.Count <= 0)
                {
                  //  foreach (DataRow row in this.GetDistNameCode("select CUN,(select b.CNAME from T_SYS_META_CODE b where b.CCODE=a.CUN and CINDEX='105') as xianname from BASE_P_CUN_10K a where XIANG='" + pCode + "'").Rows)
                    foreach (T_SYS_META_CODE_Mid mid in MDM.FindCun(pCode))
                    {
                        TreeListNode node = this.treeList_XZQH.AppendNode(mid.CCODE, pNode);
                        node.SetValue(0, mid.CNAME);
                        node.Tag = mid.CCODE;
                        node.Checked = true;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Report.UserControlDistCode", "AddVillageNames", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
  
        /// <summary>
        /// 返回选择的是“县”、“乡”，“村”
        /// </summary>
        /// <returns></returns>
        public string GetSelectedCode()
        {
            StringBuilder pSb = new StringBuilder();
            pSb.Append("(");
            for (int i = 0; i < this.treeList_XZQH.Nodes.Count; i++)
            {
                this.GetTj(this.treeList_XZQH.Nodes[i], ref pSb);
            }
            if (pSb.Length == 1)
            {
                return "1=1";
            }
            pSb = pSb.Remove(pSb.Length - 4, 4);
            pSb.Append(")");
            return pSb.ToString();
        }

        public string last = "";

        public string Last
        {
            get { return last; }
        }

        /// <summary>
        /// 根据字段长度判断选择是“县”、“乡”，“村”
        /// </summary>
        /// <param name="pNode"></param>
        /// <param name="pSb"></param>
        private void GetTj(TreeListNode pNode, ref StringBuilder pSb)
        {
            if (pNode.Checked)
            {
                string str = pNode.Tag.ToString();

                switch (str.Length)
                {
                    case 6:
                        pSb.Append("XIAN='" + str + "' or ");
                        return;

                    case 9:
                        pSb.Append("XIANG='" + str + "' or ");
                        return;
                }


            
                pSb.Append("CUN='" + str + "' or ");
            }
            else
            {
                for (int i = 0; i < pNode.Nodes.Count; i++)
                {
                    this.GetTj(pNode.Nodes[i], ref pSb);
                }
            }
        }
        private MetaDataManager MDM
        {
            get
            {
                return DBServiceFactory<MetaDataManager>.Service;
            }
        }
        private void InitDistList()
        {
            try
            {
                
            //   foreach (DataRow row in this.GetDistNameCode("select XIAN,(select b.CNAME from T_SYS_META_CODE b where b.CCODE=a.XIAN and CINDEX='103') as xianname from BASE_P_XIAN_10K a").Rows)
                foreach(T_SYS_META_CODE_Mid mid in  MDM.XianList)
                {
                    TreeListNode pNode = this.treeList_XZQH.AppendNode(mid.CCODE, -1);
                    pNode.SetValue(0, mid.CNAME);
                    pNode.Tag = mid.CCODE;
                    pNode.Checked = true;
                    this.AddTownNames(pNode, mid.CCODE);
                    pNode.Expanded = true;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Report.UserControlDistCode", "InitDistList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialControls()
        {
            try
            {
                this.InitDistList();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Report.UserControlDistCode", "InitialControls", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.treeList_XZQH = new TreeList();
            this.tlc_xzqh = new TreeListColumn();
            this.treeList_XZQH.BeginInit();
            base.SuspendLayout();
            this.treeList_XZQH.Columns.AddRange(new TreeListColumn[] { this.tlc_xzqh });
            this.treeList_XZQH.Dock = DockStyle.Fill;
            this.treeList_XZQH.Location = new Point(0, 0);
            this.treeList_XZQH.Name = "treeList_XZQH";
            this.treeList_XZQH.OptionsBehavior.AllowIndeterminateCheckState = true;
            this.treeList_XZQH.OptionsBehavior.Editable = false;
            this.treeList_XZQH.OptionsView.ShowCheckBoxes = true;
            this.treeList_XZQH.OptionsView.ShowHorzLines = false;
            this.treeList_XZQH.OptionsView.ShowIndicator = false;
            this.treeList_XZQH.OptionsView.ShowRoot = false;
            this.treeList_XZQH.OptionsView.ShowVertLines = false;
            this.treeList_XZQH.Size = new Size(0x127, 300);
            this.treeList_XZQH.TabIndex = 4;
            this.treeList_XZQH.BeforeCheckNode += new CheckNodeEventHandler(this.treeList_XZQH_BeforeCheckNode);
            this.treeList_XZQH.DoubleClick += new EventHandler(this.treeList_XZQH_DoubleClick);
            this.treeList_XZQH.AfterCheckNode += new NodeEventHandler(this.treeList_XZQH_AfterCheckNode);
            this.tlc_xzqh.Caption = "行政区划";
            this.tlc_xzqh.FieldName = "行政区划";
            this.tlc_xzqh.Name = "tlc_xzqh";
            this.tlc_xzqh.Visible = true;
            this.tlc_xzqh.VisibleIndex = 0;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.treeList_XZQH);
            this.MaximumSize = new Size(350, 300);
            base.Name = "UserControlDistCode";
            base.Size = new Size(0x127, 300);
            this.treeList_XZQH.EndInit();
            base.ResumeLayout(false);
        }

        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                this.SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        private void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool flag = false;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    CheckState checkState = node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(checkState))
                    {
                        flag = !flag;
                        break;
                    }
                }
                node.ParentNode.CheckState = flag ? CheckState.Indeterminate : check;
                this.SetCheckedParentNodes(node.ParentNode, check);
            }
        }

        private void treeList_XZQH_AfterCheckNode(object sender, NodeEventArgs e)
        {
            this.SetCheckedChildNodes(e.Node, e.Node.CheckState);
            this.SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        private void treeList_XZQH_BeforeCheckNode(object sender, CheckNodeEventArgs e)
        {
            e.State = (e.PrevState == CheckState.Checked) ? CheckState.Unchecked : CheckState.Checked;
        }

        private void treeList_XZQH_DoubleClick(object sender, EventArgs e)
        {
        }
    }
}

