namespace StatisChart
{
    using DevExpress.XtraEditors.Calendar;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using System;

    public class CustomVistaDateEditCalendar : VistaDateEditCalendar
    {
        public CustomVistaDateEditCalendar(RepositoryItemDateEdit item, object editDate) : base(item, editDate)
        {
        }

        protected override void Init()
        {
            base.Init();
            this.View = DateEditCalendarViewType.YearInfo;
        }

        protected override void OnItemClick(CalendarHitInfo hitInfo)
        {
            DayNumberCellInfo hitObject = hitInfo.HitObject as DayNumberCellInfo;
            if (this.View == DateEditCalendarViewType.YearInfo)
            {
                DateTime time = new DateTime(base.DateTime.Year, hitObject.Date.Month, 1, 0, 0, 0);
                if (this.DateMode == ZLDateEdit.DateResultModeEnum.FirstDayOfMonth)
                {
                    this.OnDateTimeCommit(time, false);
                }
                else
                {
                    DateTime time2 = time.AddMonths(1).AddDays(-1.0);
                    time2 = new DateTime(time2.Year, time2.Month, time2.Day, 0x17, 0x3b, 0x3b);
                    this.OnDateTimeCommit(time2, false);
                }
            }
            else
            {
                base.OnItemClick(hitInfo);
            }
        }

        public ZLDateEdit.DateResultModeEnum DateMode
        {
            get
            {
                return ((ZLDateEdit) base.Properties.OwnerEdit).DateMode;
            }
        }
    }
}

