public static class SolidWorksBitmapHelper
    {
        public static Bitmap GetBitmapFromSketchPicture(SketchPicture sp)
        {
         try
            {
                double width = 0;
                double height = 0;
                int widthint;
                int heightint;
                sp.GetSize(ref width, ref height);
                widthint = Convert.ToInt32(width * 1000);
                heightint = Convert.ToInt32(height * 1000);
                int size = sp.GetPixelmapSize(ref widthint, ref heightint);
                Logger.WriteStep(string.Format("    Size: " + size.ToString()));
                short[] bmp = (short[])sp.GetPixelmap();
               
                List<Pixel> pixels = new List<Pixel>();
                Logger.WriteStep("  List of pixels created");
                Bitmap b = new Bitmap(widthint, heightint);
                Logger.WriteStep("  Empty bitmap created");
                var l = size % 3;
                if (l == 0)
                {
                    l = 3;
                    Logger.WriteStep("  Entering l = 3 loop");
                    for (int i = 0; i < size; i += l)
                    {
                        
                       Pixel p = new Pixel();
                        p.Red = bmp[i];
                        p.Green = bmp[i + 1];
                        p.Blue = bmp[i + 2];
                        pixels.Add(p);
                    }
                    Logger.WriteStep("  List of pixels created. Count: " + pixels.Count.ToString() );

                    int c = 0;
                    for (int i = 0; i < widthint; i++)
                    {
                        for (int j = 0; j < heightint; j++)
                        {
                            Pixel pp = pixels[c];
                            b.SetPixel(j, i, System.Drawing.Color.FromArgb(pp.Red, pp.Green, pp.Blue));
                            c++;
                        }
                        
                    }
                }
                else
                {
                    l = 4;

                    for (int i = 0; i < size; i += l)
                    {
                        Pixel p = new Pixel();
                       
                        p.Red = bmp[i];
                        p.Green = bmp[i+1];
                        p.Blue = bmp[i +2];
                        p.Alpha = bmp[i+3];
                        pixels.Add(p);
                    }
                    Logger.WriteStep("  List of pixels created. Count: " + pixels.Count.ToString());

                    int c = 0;
                    for (int i = 0; i < widthint; i++)
                    {
                        for (int j = 0; j < heightint; j++)
                        {
                            Pixel pp = pixels[c];
                            b.SetPixel(j, i, System.Drawing.Color.FromArgb(pp.Alpha, pp.Red, pp.Green, pp.Blue));
                            c++;
                        }
                    }
                }
                return b;

            }
            catch (Exception e)
            {
                throw e;
                return null;
            }
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
            private int Alpha {get; private set;}      
        }

    }
