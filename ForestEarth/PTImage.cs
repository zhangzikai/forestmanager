namespace ForestEarth
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;

    internal class PTImage
    {
        public static void ZoomAuto(StreamReader postedFile, string savePath, double targetWidth, double targetHeight, string watermarkText, string watermarkImage)
        {
            string directoryName = Path.GetDirectoryName(savePath);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            Image image = Image.FromStream(postedFile.BaseStream, true);
            if ((image.Width <= targetWidth) && (image.Height <= targetHeight))
            {
                if (watermarkText != "")
                {
                    using (Graphics graphics = Graphics.FromImage(image))
                    {
                        Font font = new Font("黑体", 10f);
                        Brush brush = new SolidBrush(Color.White);
                        graphics.DrawString(watermarkText, font, brush, (float) 10f, (float) 10f);
                        graphics.Dispose();
                    }
                }
                if ((watermarkImage != "") && File.Exists(watermarkImage))
                {
                    using (Image image2 = Image.FromFile(watermarkImage))
                    {
                        if ((image.Width >= image2.Width) && (image.Height >= image2.Height))
                        {
                            Graphics graphics2 = Graphics.FromImage(image);
                            ImageAttributes imageAttr = new ImageAttributes();
                            ColorMap map = new ColorMap();
                            map.OldColor = Color.FromArgb(0xff, 0, 0xff, 0);
                            map.NewColor = Color.FromArgb(0, 0, 0, 0);
                            ColorMap[] mapArray = new ColorMap[] { map };
                            imageAttr.SetRemapTable(mapArray, ColorAdjustType.Bitmap);
                            float[][] numArray3 = new float[5][];
                            float[] numArray4 = new float[5];
                            numArray4[0] = 1f;
                            numArray3[0] = numArray4;
                            float[] numArray5 = new float[5];
                            numArray5[1] = 1f;
                            numArray3[1] = numArray5;
                            float[] numArray6 = new float[5];
                            numArray6[2] = 1f;
                            numArray3[2] = numArray6;
                            float[] numArray7 = new float[5];
                            numArray7[3] = 0.5f;
                            numArray3[3] = numArray7;
                            float[] numArray8 = new float[5];
                            numArray8[4] = 1f;
                            numArray3[4] = numArray8;
                            float[][] newColorMatrix = numArray3;
                            ColorMatrix matrix = new ColorMatrix(newColorMatrix);
                            imageAttr.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                            graphics2.DrawImage(image2, new Rectangle(image.Width - image2.Width, image.Height - image2.Height, image2.Width, image2.Height), 0, 0, image2.Width, image2.Height, GraphicsUnit.Pixel, imageAttr);
                            graphics2.Dispose();
                        }
                        image2.Dispose();
                    }
                }
                image.Save(savePath, ImageFormat.Jpeg);
            }
            else
            {
                double width = image.Width;
                double height = image.Height;
                if ((image.Width > image.Height) || (image.Width == image.Height))
                {
                    if (image.Width > targetWidth)
                    {
                        width = targetWidth;
                        height = image.Height * (targetWidth / ((double) image.Width));
                    }
                }
                else if (image.Height > targetHeight)
                {
                    height = targetHeight;
                    width = image.Width * (targetHeight / ((double) image.Height));
                }
                Image image3 = new Bitmap((int) width, (int) height);
                Graphics graphics3 = Graphics.FromImage(image3);
                graphics3.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics3.SmoothingMode = SmoothingMode.HighQuality;
                graphics3.Clear(Color.White);
                graphics3.DrawImage(image, new Rectangle(0, 0, image3.Width, image3.Height), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
                if (watermarkText != "")
                {
                    using (Graphics graphics4 = Graphics.FromImage(image3))
                    {
                        Font font2 = new Font("宋体", 10f);
                        Brush brush2 = new SolidBrush(Color.White);
                        graphics4.DrawString(watermarkText, font2, brush2, (float) 10f, (float) 10f);
                        graphics4.Dispose();
                    }
                }
                if ((watermarkImage != "") && File.Exists(watermarkImage))
                {
                    using (Image image4 = Image.FromFile(watermarkImage))
                    {
                        if ((image3.Width >= image4.Width) && (image3.Height >= image4.Height))
                        {
                            Graphics graphics5 = Graphics.FromImage(image3);
                            ImageAttributes attributes2 = new ImageAttributes();
                            ColorMap map2 = new ColorMap();
                            map2.OldColor = Color.FromArgb(0xff, 0, 0xff, 0);
                            map2.NewColor = Color.FromArgb(0, 0, 0, 0);
                            ColorMap[] mapArray2 = new ColorMap[] { map2 };
                            attributes2.SetRemapTable(mapArray2, ColorAdjustType.Bitmap);
                            float[][] numArray9 = new float[5][];
                            float[] numArray10 = new float[5];
                            numArray10[0] = 1f;
                            numArray9[0] = numArray10;
                            float[] numArray11 = new float[5];
                            numArray11[1] = 1f;
                            numArray9[1] = numArray11;
                            float[] numArray12 = new float[5];
                            numArray12[2] = 1f;
                            numArray9[2] = numArray12;
                            float[] numArray13 = new float[5];
                            numArray13[3] = 0.5f;
                            numArray9[3] = numArray13;
                            float[] numArray14 = new float[5];
                            numArray14[4] = 1f;
                            numArray9[4] = numArray14;
                            float[][] numArray2 = numArray9;
                            ColorMatrix matrix2 = new ColorMatrix(numArray2);
                            attributes2.SetColorMatrix(matrix2, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                            graphics5.DrawImage(image4, new Rectangle(image3.Width - image4.Width, image3.Height - image4.Height, image4.Width, image4.Height), 0, 0, image4.Width, image4.Height, GraphicsUnit.Pixel, attributes2);
                            graphics5.Dispose();
                        }
                        image4.Dispose();
                    }
                }
                image3.Save(savePath, ImageFormat.Jpeg);
                graphics3.Dispose();
                image3.Dispose();
                image.Dispose();
                GC.Collect();
            }
        }
    }
}

