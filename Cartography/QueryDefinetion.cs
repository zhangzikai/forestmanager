using DevExpress.XtraEditors;
using ESRI.ArcGIS.Carto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cartography
{
    public partial class QueryDefinetion : FormBase.FormBase3
    {
        private IFeatureLayerDefinition layerDefinition;
        public QueryDefinetion(IFeatureLayerDefinition layerDefinition)
        {
            InitializeComponent();
            this.layerDefinition = layerDefinition;
            this.memoEdit1.Text = layerDefinition.DefinitionExpression;
        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                layerDefinition.DefinitionExpression = memoEdit1.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("错误", "错误，输入的查询语句存在语法错误");
            }
        }
    }
}
