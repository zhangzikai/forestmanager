namespace gylandzzytj
{
    using System;
    using System.Collections;
    using System.Reflection;

    internal class ForestConditionCollection : CollectionBase
    {
        public void Add(ForestCondition fc)
        {
            base.List.Add(fc);
        }

        private ForestCondition Find(string name)
        {
            foreach (ForestCondition condition2 in base.List)
            {
                if (condition2.Name == name)
                {
                    return condition2;
                }
            }
            return null;
        }

        public ForestCondition this[string name]
        {
            get
            {
                return this.Find(name);
            }
        }
    }
}

