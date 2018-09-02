namespace Report
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Popup;
    using System;

    public class CustomVistaPopupDateEditForm : VistaPopupDateEditForm
    {
        public CustomVistaPopupDateEditForm(DateEdit ownerEdit) : base(ownerEdit)
        {
        }

        protected override DateEditCalendar CreateCalendar()
        {
            return new CustomVistaDateEditCalendar(base.OwnerEdit.Properties, base.OwnerEdit.EditValue);
        }
    }
}

