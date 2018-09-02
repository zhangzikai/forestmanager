namespace QueryAnalysic
{
    using ESRI.ArcGIS.Geodatabase;
    using System;
    using System.Data;
    using System.Data.Common;
    using Utilities;

    public class QueryFun
    {
        private const string mClassName = "QueryAnalysic.QueryFun";
        private static ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private static string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private const string myClassName = "查询公共类";


        public static IDataset GetEditDataset(string editkindcode, IFeatureWorkspace pfw)
        {
            try
            {
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue(editkindcode + "Dataset");
                IDataset dataset = pfw as IDataset;
                IEnumDataset subsets = dataset.Subsets;
                IDataset dataset3 = subsets.Next();
                while (dataset3 != null)
                {
                    if (dataset3.Name.Contains(configValue + "_") && (dataset3.Name != (configValue + "_Templ")))
                    {
                        break;
                    }
                    dataset3 = subsets.Next();
                }
                if (dataset3 != null)
                {
                    string[] strArray = dataset3.Name.Split(new char[] { '_' });
                    string str2 = strArray[strArray.Length - 1];
                    string text1 = UtilFactory.GetConfigOpt().GetConfigValue(editkindcode + "Dataset") + "_" + str2;
                    return dataset3;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

