namespace GX_DB_INFO.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), CompilerGenerated]
    internal class Resources
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal Resources()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static string GETVERSION
        {
            get
            {
                return ResourceManager.GetString("GETVERSION", resourceCulture);
            }
        }

        internal static string NAUPDATE
        {
            get
            {
                return ResourceManager.GetString("NAUPDATE", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("GX_DB_INFO.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }

        internal static string UPANSXJ
        {
            get
            {
                return ResourceManager.GetString("UPANSXJ", resourceCulture);
            }
        }

        internal static string UPANSXJ2
        {
            get
            {
                return ResourceManager.GetString("UPANSXJ2", resourceCulture);
            }
        }

        internal static string UPBSANXJ
        {
            get
            {
                return ResourceManager.GetString("UPBSANXJ", resourceCulture);
            }
        }

        internal static string UPBSANXJ2
        {
            get
            {
                return ResourceManager.GetString("UPBSANXJ2", resourceCulture);
            }
        }

        internal static string V0TOV1
        {
            get
            {
                return ResourceManager.GetString("V0TOV1", resourceCulture);
            }
        }
    }
}

