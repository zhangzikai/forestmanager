namespace Cf_Calc
{
    using System;
    using System.Collections;
    using System.Reflection;

    internal class JJCJ_RenderCollection : CollectionBase
    {
        public JJCJ_RenderCollection()
        {
            base.List.Add(new SM_CJ());
            base.List.Add(new MWS_CJ());
            base.List.Add(new YNS_CJ());
            base.List.Add(new YS_CJ());
            base.List.Add(new KYS_CJ());
            base.List.Add(new AS1_CJ());
            base.List.Add(new AS2_CJ());
            base.List.Add(new SSA_CJ());
        }

        private JJCJ_Render GetRender(string name)
        {
            foreach (JJCJ_Render render2 in base.List)
            {
                if (render2.Name == name.Replace(" ", ""))
                {
                    return render2;
                }
            }
            return null;
        }

        public JJCJ_Render this[string name]
        {
            get
            {
                return this.GetRender(name);
            }
        }
    }
}

