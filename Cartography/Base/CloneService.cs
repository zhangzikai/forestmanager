namespace Cartography.Base
{
    using ESRI.ArcGIS.esriSystem;
    using System;

    internal class CloneService
    {
        public static void Clone(object pSourceObj, object pTargetObj)
        {
            if ((pSourceObj == null) || (pTargetObj == null))
            {
                throw new Exception("对象为空！");
            }
            IObjectCopy copy = new ObjectCopyClass();
            copy.Copy(pSourceObj);
            copy.Overwrite(pSourceObj, ref pTargetObj);
        }
    }
}

