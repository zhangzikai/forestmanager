namespace Cartography.Base
{
    using ESRI.ArcGIS.Geodatabase;
    using System;

    internal class DomainService
    {
        public static string GetValue(IDomain pDomain, string pCode)
        {
            string str = pCode;
            if ((pDomain != null) && (pDomain is ICodedValueDomain))
            {
                ICodedValueDomain domain = pDomain as ICodedValueDomain;
                for (int i = 0; i < domain.CodeCount; i++)
                {
                    if (domain.get_Name(i) == pCode)
                    {
                        return domain.get_Value(i).ToString();
                    }
                }
            }
            return str;
        }
    }
}

