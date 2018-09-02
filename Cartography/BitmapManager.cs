namespace Cartography
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.InteropServices;

    internal class BitmapManager
    {
        public static Bitmap GetBitMapFromItem(IStyleGalleryClass pStyleGalleryClass, object galleryItem, int imgWidth, int imgHeight)
        {
            Bitmap image = new Bitmap(imgWidth, imgHeight);
            Graphics graphics = Graphics.FromImage(image);
            tagRECT rectangle = new tagRECT();
            rectangle.right = image.Width;
            rectangle.bottom = image.Height;
            IntPtr hdc = graphics.GetHdc();
            pStyleGalleryClass.Preview(galleryItem, hdc.ToInt32(), ref rectangle);
            graphics.ReleaseHdc(hdc);
            graphics.Dispose();
            return image;
        }

        public static Dictionary<IStyleGalleryItem, Bitmap> GetBitMapText(string pStyleClassName, int pWidth, int pHeight)
        {
            Dictionary<IStyleGalleryItem, Bitmap> dictionary = new Dictionary<IStyleGalleryItem, Bitmap>();
            IStyleGallery o = null;
            try
            {
                IStyleGalleryClass class3;
                IEnumStyleGalleryItem item;
                o = new ServerStyleGalleryClass();
                IStyleGalleryStorage storage = (IStyleGalleryStorage) o;
                //此处读取图片出错。因为没有发现源文件。因此使用自定义固定的路径
                string styleGalleryFile = ElementService.StyleGalleryFile1;
                if (string.IsNullOrEmpty(styleGalleryFile))
                {
                    return null;
                }
                storage.AddFile(styleGalleryFile);
                IStyleGalleryClass pStyleGalleryClass = null;
                for (int i = 0; i < o.ClassCount; i++)
                {
                    class3 = o.get_Class(i);
                    if (class3.Name == pStyleClassName)
                    {
                        goto Label_0065;
                    }
                }
                goto Label_0069;
            Label_0065:
                pStyleGalleryClass = class3;
            Label_0069:
                item = null;
                IStyleGalleryItem key = null;
                string[] strArray = null;
                if (pStyleClassName == "Scale Bars")
                {
                    strArray = new string[] { "" };
                }
                else if ((pStyleClassName != "Scale Texts") && (pStyleClassName != "Color Ramps"))
                {
                    strArray = new string[] { "Default" };
                }
                else
                {
                    strArray = new string[] { "" };
                }
                for (int j = 0; j < strArray.Length; j++)
                {
                    item = o.get_Items(pStyleClassName, styleGalleryFile, strArray[j]);
                    item.Reset();
                    while ((key = item.Next()) != null)
                    {
                        Bitmap bitmap = GetBitMapFromItem(pStyleGalleryClass, key.Item, pWidth, pHeight);
                        dictionary.Add(key, bitmap);
                    }
                }
            }
            catch
            {
            }
            int num3 = 0;
            while (true)
            {
                if (o != null)
                {
                    num3 = Marshal.ReleaseComObject(o);
                }
                if (num3 <= 0)
                {
                    return dictionary;
                }
            }
        }

        public static Bitmap GetSymbolBitMap(ISymbol pSymbol, int pWidth, int pHeight)
        {
            IStyleGalleryClass class2 = null;
            if (pSymbol is IFillSymbol)
            {
                class2 = new FillSymbolStyleGalleryClassClass();
            }
            if (pSymbol is ILineSymbol)
            {
                class2 = new LineSymbolStyleGalleryClassClass();
            }
            if (pSymbol is IMarkerSymbol)
            {
                class2 = new MarkerSymbolStyleGalleryClassClass();
            }
            Bitmap image = new Bitmap(pWidth, pHeight);
            Graphics graphics = Graphics.FromImage(image);
            tagRECT rectangle = new tagRECT();
            rectangle.right = image.Width;
            rectangle.bottom = image.Height;
            IntPtr hdc = graphics.GetHdc();
            class2.Preview(pSymbol, hdc.ToInt32(), ref rectangle);
            graphics.ReleaseHdc(hdc);
            graphics.Dispose();
            return image;
        }

        public static Bitmap GetSymbolBitMap(object pItem, int pWidth, int pHeight)
        {
            IStyleGalleryClass class2 = null;
            if (pItem is ISymbolBackground)
            {
                class2 = new BackgroundStyleGalleryClassClass();
            }
            if (pItem is ISymbolShadow)
            {
                class2 = new ShadowStyleGalleryClassClass();
            }
            if (pItem is ISymbolBorder)
            {
                class2 = new BorderStyleGalleryClassClass();
            }
            if (pItem is IScaleBar)
            {
                class2 = new ScaleBarStyleGalleryClassClass();
            }
            if (pItem is IScaleText)
            {
                class2 = new ScaleTextStyleGalleryClassClass();
            }
            if (pItem is ITextSymbol)
            {
                class2 = new TextSymbolStyleGalleryClassClass();
            }
            Bitmap image = new Bitmap(pWidth, pHeight);
            Graphics graphics = Graphics.FromImage(image);
            tagRECT rectangle = new tagRECT();
            rectangle.right = image.Width;
            rectangle.bottom = image.Height;
            IntPtr hdc = graphics.GetHdc();
            class2.Preview(pItem, hdc.ToInt32(), ref rectangle);
            graphics.ReleaseHdc(hdc);
            graphics.Dispose();
            return image;
        }
    }
}

