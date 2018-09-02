namespace AttributesEdit
{
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class ZLComboBox : ComboBox
    {
        private IContainer components;
        private RepositoryItemComboBox fProperties;
        private ArrayList m_AllList = new ArrayList();
        private bool m_AssDispValue;
        private ArrayList m_AssList = new ArrayList();
        private bool m_DrawBorder;
        private bool m_IsAss;
        private bool m_IsDisplayButton;
        private ArrayList m_List = new ArrayList();

        public ZLComboBox()
        {
            this.InitializeComponent();
        }

        public void AddItem(string sName, string sValue)
        {
            ZLComboItem item = new ZLComboItem(sName, sValue) {
                Enable = true
            };
            this.m_List.Add(item);
            this.m_AssList.Add(item);
            base.Items.Add(sName);
        }

        public void AddItem(string sName, string sValue, bool bEnable)
        {
            ZLComboItem item = new ZLComboItem(sName, sValue) {
                Enable = bEnable
            };
            this.m_List.Add(item);
            base.Items.Add(sName);
        }

        public void AddItem(string sName, string sValue, bool bEnable, int iLevel)
        {
            ZLComboItem item = new ZLComboItem(sName, sValue) {
                Enable = bEnable,
                Level = iLevel
            };
            this.m_List.Add(item);
            base.Items.Add(sName);
        }

        private void AdjustComboBoxDropDownListWidth()
        {
            Graphics graphics = null;
            Font font = null;
            try
            {
                int width = base.Width;
                graphics = base.CreateGraphics();
                font = this.Font;
                int num2 = (base.Items.Count > base.MaxDropDownItems) ? SystemInformation.VerticalScrollBarWidth : 0;
                foreach (object obj2 in base.Items)
                {
                    if (obj2 != null)
                    {
                        int num3 = ((int) graphics.MeasureString(obj2.ToString().Trim(), font).Width) + num2;
                        if (width < num3)
                        {
                            width = num3;
                        }
                    }
                }
                base.DropDownWidth = width;
            }
            catch
            {
            }
            finally
            {
                if (graphics != null)
                {
                    graphics.Dispose();
                }
            }
        }

        public void ClearItems()
        {
            this.m_List.Clear();
            this.m_AssList.Clear();
            this.m_IsAss = false;
            base.Items.Clear();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public string GetSelectedName()
        {
            try
            {
                int selectedIndex = this.SelectedIndex;
                if (selectedIndex > -1)
                {
                    ZLComboItem item = this.m_List[selectedIndex] as ZLComboItem;
                    if (item != null)
                    {
                        return item.Name;
                    }
                }
                return "";
            }
            catch
            {
                return "";
            }
        }

        public string GetSelectedValue()
        {
            try
            {
                if (this.m_List.Count < 1)
                {
                    return "";
                }
                int selectedIndex = this.SelectedIndex;
                if (selectedIndex > -1)
                {
                    ZLComboItem item = this.m_List[selectedIndex] as ZLComboItem;
                    return item.Value;
                }
                return this.Text;
            }
            catch
            {
                return "";
            }
        }

        [DllImport("user32.dll ")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);
        private void InitializeComponent()
        {
            this.fProperties = new RepositoryItemComboBox();
            this.fProperties.BeginInit();
            base.SuspendLayout();
            this.fProperties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.fProperties.Name = "fProperties";
            base.Size = new Size(0x84, 0x15);
            this.fProperties.EndInit();
            base.ResumeLayout(false);
        }

        public void ItemFilter(string sFilter)
        {
            try
            {
                if ((this.m_AllList == null) || (this.m_AllList.Count <= 1))
                {
                    this.m_AllList = this.m_List.Clone() as ArrayList;
                }
                if ((sFilter != "") && (this.m_AllList.Count >= 1))
                {
                    string selectedValue = this.GetSelectedValue();
                    this.m_List.Clear();
                    base.Items.Clear();
                    int num = 0;
                    for (int i = 0; i < this.m_AllList.Count; i++)
                    {
                        ZLComboItem item = this.m_AllList[i] as ZLComboItem;
                        if (item.Value == "")
                        {
                            this.m_List.Add(item);
                            base.Items.Add(item.Name);
                            if (item.Value == selectedValue)
                            {
                                num = this.m_List.Count - 1;
                            }
                        }
                        else if (item.Value.IndexOf(sFilter) == 0)
                        {
                            this.m_List.Add(item);
                            base.Items.Add(item.Name);
                            if (item.Value == selectedValue)
                            {
                                num = this.m_List.Count - 1;
                            }
                        }
                    }
                    this.SelectedIndex = num;
                }
            }
            catch
            {
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            int index = e.Index;
            ArrayList assList = null;
            if (this.m_IsAss)
            {
                assList = this.m_AssList;
            }
            else
            {
                assList = this.m_List;
            }
            if ((index >= 0) && (index < assList.Count))
            {
                ZLComboItem item = assList[index] as ZLComboItem;
                string s = "";
                if (this.m_IsAss)
                {
                    s = item.Value + "  " + item.Name;
                }
                else
                {
                    s = item.Name;
                }
                new Font("宋体", 9f);
                if (item.Enable)
                {
                    if ((e.State & DrawItemState.Selected) != DrawItemState.None)
                    {
                        SolidBrush brush = new SolidBrush(Color.FromArgb(0x33, 0x99, 0xff));
                        e.Graphics.FillRectangle(brush, e.Bounds);
                        e.Graphics.DrawString(s, e.Font, Brushes.White, e.Bounds, StringFormat.GenericDefault);
                    }
                    else
                    {
                        SolidBrush brush2 = new SolidBrush(Color.White);
                        e.Graphics.FillRectangle(brush2, e.Bounds);
                        e.Graphics.DrawString(s, e.Font, Brushes.Blue, e.Bounds, StringFormat.GenericDefault);
                    }
                }
                else
                {
                    SolidBrush brush3 = new SolidBrush(Color.FromArgb(240, 240, 240));
                    e.Graphics.FillRectangle(brush3, e.Bounds);
                    e.Graphics.DrawString(s, e.Font, Brushes.Blue, e.Bounds, StringFormat.GenericDefault);
                }
            }
        }

        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);
            this.AdjustComboBoxDropDownListWidth();
        }

        protected override void OnDropDownClosed(EventArgs e)
        {
            try
            {
                if (this.m_IsAss)
                {
                    int num = -1;
                    string text = null;
                    if (this.m_AssList.Count > 0)
                    {
                        text = this.Text;
                        num = base.SelectedIndex;
                        if (num >= 0)
                        {
                            ZLComboItem item = this.m_AssList[num] as ZLComboItem;
                            text = item.Value;
                        }
                    }
                    while (base.Items.Count > 0)
                    {
                        base.Items.RemoveAt(0);
                    }
                    num = -1;
                    for (int i = 0; i < this.m_List.Count; i++)
                    {
                        ZLComboItem item2 = this.m_List[i] as ZLComboItem;
                        base.Items.Add(item2.Name);
                        if (item2.Value == text)
                        {
                            num = i;
                        }
                    }
                    base.SelectedIndex = num;
                }
                this.m_IsAss = false;
            }
            catch
            {
            }
            base.OnDropDownClosed(e);
            int selectedIndex = this.SelectedIndex;
            if ((selectedIndex < 0) || (selectedIndex >= this.m_List.Count))
            {
                this.SelectedIndex = 0;
            }
            else
            {
                ZLComboItem item3 = this.m_List[selectedIndex] as ZLComboItem;
                if (!item3.Enable)
                {
                    this.SelectedIndex = 0;
                }
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.m_IsDisplayButton = true;
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            this.m_IsDisplayButton = false;
            base.OnLostFocus(e);
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            base.SelectionStart = this.Text.Length;
        }

        protected override void OnTextUpdate(EventArgs e)
        {
            string text;
            try
            {
                text = this.Text;
            }
            catch
            {
                text = "";
            }
            if (text != "")
            {
                base.Items.Clear();
                this.Text = text;
                try
                {
                    this.m_AssList.Clear();
                    for (int i = 0; i < this.m_List.Count; i++)
                    {
                        ZLComboItem item = this.m_List[i] as ZLComboItem;
                        if (item.Value.IndexOf(text) == 0)
                        {
                            this.m_AssList.Add(item);
                            if (this.m_AssDispValue)
                            {
                                base.Items.Add(item.Value + "  " + item.Name);
                            }
                            else
                            {
                                base.Items.Add(item.Name);
                            }
                        }
                    }
                    this.m_IsAss = true;
                    base.DroppedDown = true;
                    this.Text = text;
                    base.SelectionStart = this.Text.Length;
                }
                catch
                {
                }
            }
        }

        [DllImport("user32.dll ")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        public void SetSelectedItem(string sValue)
        {
            try
            {
                int num = -1;
                for (int i = 0; i < this.m_List.Count; i++)
                {
                    ZLComboItem item = this.m_List[i] as ZLComboItem;
                    if (item.Value == sValue)
                    {
                        num = i;
                        break;
                    }
                }
                if (num >= 0)
                {
                    this.SelectedIndex = num;
                }
            }
            catch
            {
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if ((m.Msg == 15) || (m.Msg == 0x133))
            {
                IntPtr windowDC = GetWindowDC(m.HWnd);
                if (windowDC.ToInt32() != 0)
                {
                    Graphics graphics = Graphics.FromHdc(windowDC);
                    if (this.m_DrawBorder)
                    {
                        ControlPaint.DrawBorder(graphics, new Rectangle(0, 0, base.Width, base.Height), Color.Gray, ButtonBorderStyle.Solid);
                    }
                    else
                    {
                        ControlPaint.DrawBorder(graphics, new Rectangle(0, 0, base.Width, base.Height), Color.White, ButtonBorderStyle.Solid);
                    }
                    if (this.m_IsDisplayButton)
                    {
                        ControlPaint.DrawComboButton(graphics, new Rectangle((base.Width - base.Height) + 2, 1, base.Height - 2, base.Height - 2), ButtonState.Flat);
                    }
                    else
                    {
                        graphics.FillRectangle(Brushes.White, new Rectangle((base.Width - base.Height) + 2, 1, base.Height - 2, base.Height - 2));
                    }
                    ReleaseDC(m.HWnd, windowDC);
                }
            }
        }

        public bool AssDispValue
        {
            get
            {
                return this.m_AssDispValue;
            }
            set
            {
                this.m_AssDispValue = value;
            }
        }

        public bool DrawBorder
        {
            set
            {
                this.m_DrawBorder = value;
            }
        }
    }
}

