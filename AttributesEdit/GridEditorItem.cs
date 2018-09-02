namespace AttributesEdit
{
    using DevExpress.XtraEditors.Repository;
    using System;

    public class GridEditorItem
    {
        private string fName;
        private DevExpress.XtraEditors.Repository.RepositoryItem fRepositoryItem;
        private object fTag;
        private object fValue;

        public GridEditorItem(DevExpress.XtraEditors.Repository.RepositoryItem fRepositoryItem, string fName, object fValue)
        {
            this.fTag = null;
            this.fRepositoryItem = fRepositoryItem;
            this.fName = fName;
            this.fValue = fValue;
        }

        public GridEditorItem(DevExpress.XtraEditors.Repository.RepositoryItem fRepositoryItem, string fName, object fValue, object Tag)
        {
            this.fTag = null;
            this.fRepositoryItem = fRepositoryItem;
            this.fName = fName;
            this.fValue = fValue;
            this.fTag = Tag;
        }

        public string Name
        {
            get
            {
                return this.fName;
            }
        }

        public DevExpress.XtraEditors.Repository.RepositoryItem RepositoryItem
        {
            get
            {
                return this.fRepositoryItem;
            }
            set
            {
                this.fRepositoryItem = value;
            }
        }

        public object Tag
        {
            get
            {
                return this.fTag;
            }
            set
            {
                this.fTag = value;
            }
        }

        public object Value
        {
            get
            {
                return this.fValue;
            }
            set
            {
                this.fValue = value;
            }
        }
    }
}

