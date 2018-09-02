namespace AttributesEdit
{
    using DevExpress.XtraEditors.Repository;
    using System;
    using System.Collections;
    using System.Reflection;

    internal class GridEditorCollection : ArrayList
    {
        public void Add(RepositoryItem fRepositoryItem, string fName, object fValue)
        {
            base.Add(new GridEditorItem(fRepositoryItem, fName, fValue));
        }

        public void Add(RepositoryItem fRepositoryItem, string fName, object fValue, object Tag)
        {
            base.Add(new GridEditorItem(fRepositoryItem, fName, fValue, Tag));
        }

        public GridEditorItem this[int index]
        {
            get
            {
                return (base[index] as GridEditorItem);
            }
        }
    }
}

