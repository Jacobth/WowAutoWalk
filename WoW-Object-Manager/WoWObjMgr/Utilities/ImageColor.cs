using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace WowAuto.Utilities
{
    class ImageColor
    {


        public static bool ContainsColor(Bitmap src, byte r, byte g, byte b)
        {
            BitmapData data = src.LockBits(new Rectangle(0, 0, src.Width, src.Height),
            ImageLockMode.ReadOnly, src.PixelFormat);  // make sure you check the pixel format as you will be looking directly at memory

            unsafe
            {
                byte* ptrSrc = (byte*)data.Scan0;

                // example assumes 24bpp image.  You need to verify your pixel depth
                // loop by row for better data locality
                for (int y = 0; y < data.Height; ++y)
                {
                    for (int x = 0; x < data.Width; ++x)
                    {
                        // windows stores images in BGR pixel order
                        byte r_tmp = ptrSrc[2];
                        byte g_tmp = ptrSrc[1];
                        byte b_tmp = ptrSrc[0];

                        Console.WriteLine("r: " + r_tmp + " g: " + g_tmp + " b: " + b_tmp);

                        // next pixel in the row
                        ptrSrc += 3;

                        if(r == r_tmp && g == g_tmp && b == b_tmp)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
