namespace OperateLog
{
    using DevExpress.XtraEditors;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using td.db.orm;
    using td.db.service.sys;
    using td.logic.sys;
    using Utilities;

    public class FormSQL : FormBase3
    {
        private SimpleButton btCancel;
        private SimpleButton btOk;
        private IContainer components;
        private LabelControl g;
        private MemoEdit memoEditSQL;

        public FormSQL()
        {
            this.InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            string text = this.memoEditSQL.Text;
            if (text == "")
            {
                MessageBox.Show("请录入用于更新的SQL语句！", "自定义更新");
            }
            else
            {
            if ((DialogResult.Yes == MessageBox.Show("执行SQL语句可能会对数据库造成不可挽回的损失，确定要执行吗？", "自定义更新", MessageBoxButtons.YesNo)) )
                {
                    if (UserManager.Single.ExecuteNonQuery(text) >= 0)
                    {
                        MessageBox.Show("更新语句执行完成！", "自定义更新");
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

        private void InitializeComponent()
        {
            this.g = new LabelControl();
            this.btOk = new SimpleButton();
            this.btCancel = new SimpleButton();
            this.memoEditSQL = new MemoEdit();
            this.memoEditSQL.Properties.BeginInit();
            base.SuspendLayout();
            this.g.Location = new Point(15, 7);
            this.g.Name = "g";
            this.g.Size = new Size(0x92, 14);
            this.g.TabIndex = 1;
            this.g.Text = "请输入用于更新的SQL语句:";
            this.btOk.Location = new Point(0x20, 0x88);
            this.btOk.Name = "btOk";
            this.btOk.Size = new Size(0x57, 0x1b);
            this.btOk.TabIndex = 2;
            this.btOk.Text = "确定";
            this.btOk.Click += new EventHandler(this.btOk_Click);
//            this.btCancel.DialogResult = DialogResult.Cancel;
            this.btCancel.Location = new Point(0x9d, 0x88);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new Size(0x57, 0x1b);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new EventHandler(this.btCancel_Click);
            this.memoEditSQL.Location = new Point(12, 0x1c);
            this.memoEditSQL.Name = "memoEditSQL";
            this.memoEditSQL.Size = new Size(0x11f, 0x60);
            this.memoEditSQL.TabIndex = 4;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.White;
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.btCancel;
            base.ClientSize = new Size(0x137, 0xaf);
            base.Controls.Add(this.memoEditSQL);
            base.Controls.Add(this.btCancel);
            base.Controls.Add(this.btOk);
            base.Controls.Add(this.g);
//            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormSQL";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "自定义更新";
            this.memoEditSQL.Properties.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

