public class GetBitmapFromSketchPicture 
    {
        private void GetBitmapFromSketchPicture(){}

        public static Bitmap Getbitmap(SketchPicture sp)
        {
            int heightint;
            sp.GetSize(ref width, ref height);
            widthint = Convert.ToInt32(width * 1000);
            heightint = Convert.ToInt32(height * 1000);
            int size = sp.GetPixelmapSize(ref widthint, ref heightint);
            short[] bmp = (short[])sp.GetPixelmap();
            List<pixel> pixels = new List<pixel>();
            for (int i = 0; i < size; i += 3)
            {
                pixel p = new pixel();
                p.Red = bmp[i];
                p.Green = bmp[i + 1];
                p.Blue = bmp[i + 2];

                pixels.Add(p);
            }
            Bitmap b = new Bitmap(widthint, heightint);
            int c = 0;
            for (int i = 0; i < widthint; i++)
            {
                for (int j = 0; j < heightint; j++)
                {
                    pixel pp = pixels[c];
                    b.SetPixel(i, j, Color.FromArgb(pp.Red, pp.Green, pp.Blue));
                    c++;
                }

            }
            return b;
        }

        public class pixel
        {
            private int _red;

            public int Red
            {
                get { return _red; }
                set { _red = value; }
            }

            private int _green;

            public int Green
            {
                get { return _green; }
                set { _green = value; }
            }

            private int _blue;

            public int Blue
            {
                get { return _blue; }
                set { _blue = value; }
            }

        }

    }
