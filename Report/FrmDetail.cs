using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Report
{
    public partial class FrmDetail : FormBase.FormBase3
    {
        public DataRow dr;

        public FrmDetail(DataRow dr)
        {
            InitializeComponent();
            this.dr = dr;
            resetForm();
        }
        public void resetForm() { 
            textEdit1.Text = dr["name"]==DBNull.Value?"":(string)dr["name"];
            textEdit5.Text = dr["createuser"] == DBNull.Value?"":Convert.ToString((int)dr["createuser"]);
            textEdit4.Text = dr["createtime"] == DBNull.Value?"":Convert.ToString((DateTime)dr["createtime"]);
            memoEdit1.Text = dr["dsc"] == DBNull.Value ? "" :(string)dr["dsc"];
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            resetForm();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if(textEdit1.Text == "")
                dr["name"] = DBNull.Value;
            else
                dr["name"] = textEdit1.Text;
            if (textEdit5.Text == "")
                dr["createuser"] = DBNull.Value;
            else
                dr["createuser"] = Convert.ToInt32(textEdit5.Text);
            if (textEdit4.Text == "")
                dr["createtime"] = DBNull.Value;
            else
                dr["createtime"] = Convert.ToDateTime(textEdit4.Text);
            if (memoEdit1.Text == "")
                dr["dsc"] = DBNull.Value;
            else
                dr["dsc"] = memoEdit1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
