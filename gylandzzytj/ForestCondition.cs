namespace gylandzzytj
{
    using System;

    public class ForestCondition
    {
        private string _Condition = "";
        private string _Name = "";

        public ForestCondition(string name, string condition)
        {
            this._Name = name;
            this._Condition = condition;
        }

        public string Condition
        {
            get
            {
                return this._Condition;
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
        }
    }
}

