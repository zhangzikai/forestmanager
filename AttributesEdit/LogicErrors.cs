namespace AttributesEdit
{
    using System;
    using System.Collections.Generic;

    public class LogicErrors
    {
        private IList<string> m_desList = new List<string>();
        private IList<string> m_keyList = new List<string>();

        public void AddError(string sKey, string sDes)
        {
            if (this.m_keyList.Contains(sKey))
            {
                int index = this.m_keyList.IndexOf(sKey);
                this.m_desList[index] = this.m_desList[index] + "；" + sDes;
            }
            else
            {
                this.m_keyList.Add(sKey);
                this.m_desList.Add(sDes);
            }
        }

        public string GetDescription(int index)
        {
            if (index < 0)
            {
                return "";
            }
            if (index >= this.m_desList.Count)
            {
                return "";
            }
            return this.m_desList[index];
        }

        public string GetKey(int index)
        {
            if (index < 0)
            {
                return "";
            }
            if (index >= this.m_keyList.Count)
            {
                return "";
            }
            return this.m_keyList[index];
        }

        public int Count
        {
            get
            {
                return this.m_keyList.Count;
            }
        }
    }
}

