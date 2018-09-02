namespace Cartography
{
    using ESRI.ArcGIS.Display;
    using System;
    using System.Drawing;

    internal class ColorService
    {
        private System.Drawing.Color _color;

        public static System.Drawing.Color EsriColorToNetColor(IColor pColor)
        {
            if (pColor.Transparency != 0)
            {
                return ColorTranslator.FromOle(pColor.RGB);
            }
            return System.Drawing.Color.Transparent;
        }

        public static IColor NetColorToEsriColor(System.Drawing.Color pColor)
        {
            IColor color = new RgbColorClass();
            color.RGB = ((pColor.B * 0x10000) + (pColor.G * 0x100)) + pColor.R;
            color.Transparency = pColor.A;
            return color;
        }

        public static void NetColorToEsriColor(System.Drawing.Color pColor, IColor pEsriColor)
        {
            if (pEsriColor is ICmykColor)
            {
                ICmykColor color = (ICmykColor) pEsriColor;
                color.RGB = ((pColor.B * 0x10000) + (pColor.G * 0x100)) + pColor.R;
            }
            else if (pEsriColor is IGrayColor)
            {
                IGrayColor color2 = (IGrayColor) pEsriColor;
                color2.RGB = ((pColor.B * 0x10000) + (pColor.G * 0x100)) + pColor.R;
            }
            else if (pEsriColor is IHlsColor)
            {
                IHlsColor color3 = (IHlsColor) pEsriColor;
                color3.RGB = ((pColor.B * 0x10000) + (pColor.G * 0x100)) + pColor.R;
            }
            else if (pEsriColor is IHsvColor)
            {
                IHsvColor color4 = (IHsvColor) pEsriColor;
                color4.RGB = ((pColor.B * 0x10000) + (pColor.G * 0x100)) + pColor.R;
            }
            else
            {
                IRgbColor color5 = (IRgbColor) pEsriColor;
                color5.RGB = ((pColor.B * 0x10000) + (pColor.G * 0x100)) + pColor.R;
            }
        }

        public System.Drawing.Color Color
        {
            get
            {
                return this._color;
            }
            set
            {
                this._color = value;
            }
        }
    }
}

