namespace AttributesEdit
{
    using System;
    using System.Collections.Generic;

    public class LogicErrors2
    {
        private IList<string> m_FieldList = new List<string>();
        private IList<object> m_IDList = new List<object>();
        private IList<string> m_RuleDesList = new List<string>();
        private IList<string> m_RuleTypeList = new List<string>();
        private IList<string> m_SqlList = new List<string>();

        public void AddError(string sRuleDes, string sField, string sSql, string sRuleType, IList<int> pIDs)
        {
            if (((sRuleDes != "") && (sSql != "")) && (pIDs.Count >= 1))
            {
                this.m_RuleDesList.Add(sRuleDes);
                this.m_IDList.Add(pIDs);
                this.m_SqlList.Add(sSql);
                this.m_RuleTypeList.Add(sRuleType);
                this.m_FieldList.Add(sField);
            }
        }

        public string GetDescription(int index)
        {
            if (index < 0)
            {
                return "";
            }
            if (index >= this.m_RuleDesList.Count)
            {
                return "";
            }
            return this.m_RuleDesList[index];
        }

        public object GetErrorIDS(int index)
        {
            if (index < 0)
            {
                return null;
            }
            if (index >= this.m_IDList.Count)
            {
                return null;
            }
            return this.m_IDList[index];
        }

        public string GetErrorType(int index)
        {
            if (index < 0)
            {
                return null;
            }
            if (index >= this.m_RuleTypeList.Count)
            {
                return null;
            }
            return this.m_RuleTypeList[index];
        }

        public string GetField(int index)
        {
            if (index < 0)
            {
                return null;
            }
            if (index >= this.m_FieldList.Count)
            {
                return null;
            }
            return this.m_FieldList[index];
        }

        public string GetSql(int index)
        {
            if (index < 0)
            {
                return "";
            }
            if (index >= this.m_SqlList.Count)
            {
                return "";
            }
            return this.m_SqlList[index];
        }

        public int Count
        {
            get
            {
                return this.m_RuleDesList.Count;
            }
        }
    }
}

