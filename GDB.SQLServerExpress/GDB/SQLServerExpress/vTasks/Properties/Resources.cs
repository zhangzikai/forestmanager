namespace GDB.SQLServerExpress.vTasks.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
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

        internal static string CREATE_VIEW
        {
            get
            {
                return ResourceManager.GetString("CREATE_VIEW", resourceCulture);
            }
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

        internal static Bitmap Cut
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Cut", resourceCulture);
            }
        }

        internal static Bitmap database
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("database", resourceCulture);
            }
        }

        internal static string DELE_INDX
        {
            get
            {
                return ResourceManager.GetString("DELE_INDX", resourceCulture);
            }
        }

        internal static Bitmap drive
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("drive", resourceCulture);
            }
        }

        internal static Bitmap folder
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("folder", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("GDB.SQLServerExpress.vTasks.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }

        internal static string XIAN_ADMIN_COUNT
        {
            get
            {
                return ResourceManager.GetString("XIAN_ADMIN_COUNT", resourceCulture);
            }
        }
    }
}

