namespace Report
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Popup;
    using System;

    public class DateEditEx : DateEdit
    {
        private DateResultModeEnum _dateMode = DateResultModeEnum.FirstDayOfMonth;

        public DateEditEx()
        {
            base.Properties.VistaDisplayMode = DefaultBoolean.True;
            base.Properties.DisplayFormat.FormatString = "yyyy-MM";
            base.Properties.DisplayFormat.FormatType = FormatType.DateTime;
            base.Properties.Mask.EditMask = "yyyy-MM";
            base.Properties.ShowToday = false;
        }

        protected override PopupBaseForm CreatePopupForm()
        {
            if (base.Properties.VistaDisplayMode == DefaultBoolean.True)
            {
                return new CustomVistaPopupDateEditForm(this);
            }
            return new PopupDateEditForm(this);
        }

        public DateResultModeEnum DateMode
        {
            get
            {
                return this._dateMode;
            }
            set
            {
                this._dateMode = value;
            }
        }

        public enum DateResultModeEnum
        {
            FirstDayOfMonth = 1,
            LastDayOfMonth = 2
        }
    }
}

