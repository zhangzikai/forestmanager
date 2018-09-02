namespace GeoDataIE.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), CompilerGenerated, DebuggerNonUserCode]
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

        internal static string LDGYL
        {
            get
            {
                return ResourceManager.GetString("LDGYL", resourceCulture);
            }
        }

        internal static string LDTZ
        {
            get
            {
                return ResourceManager.GetString("LDTZ", resourceCulture);
            }
        }

        internal static string LDTZ1
        {
            get
            {
                return ResourceManager.GetString("LDTZ1", resourceCulture);
            }
        }

        internal static string LDTZ2
        {
            get
            {
                return ResourceManager.GetString("LDTZ2", resourceCulture);
            }
        }

        internal static string LDTZ3
        {
            get
            {
                return ResourceManager.GetString("LDTZ3", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("GeoDataIE.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }
    }
}

