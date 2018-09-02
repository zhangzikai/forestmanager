namespace VgsTiledMap.Ags.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0"), CompilerGenerated]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = ((Settings) SettingsBase.Synchronized(new Settings()));

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [UserScopedSetting, DebuggerNonUserCode, DefaultSettingValue(@"c:\\TileCache")]
        public string DefaultCacheDir
        {
            get
            {
                return (string) this["DefaultCacheDir"];
            }
            set
            {
                this["DefaultCacheDir"] = value;
            }
        }
    }
}

