public static class Extension
    {   
	/// <summary>
        /// return a Bitmap object from the Sketch Picture
        /// </summary>
        /// <param name="token"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Bitmap GetBitmap(this SketchPicture sp)
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
                short[] Pixelmap = (short[])sp.GetPixelmap();
                List<pixel> pixels = new List<pixel>();
                Bitmap b = new Bitmap(widthint, heightint);
                // remainder of div by 3 to determine the number of channels
                int d = size % 3;
                 
                if (d == 0)
                {
                        int l = 3;
                        for (int i = 0; i < size; i += l)
                        {

                            pixel p = new pixel();
                            p.Red = Pixelmap[i];
                            p.Green = Pixelmap[i + 1];
                            p.Blue = Pixelmap[i + 2];
                            pixels.Add(p);
                        }
                        int c = 0;
                        for (int i = 0; i < widthint; i++)
                        {
                            for (int j = 0; j < heightint; j++)
                            {
                                pixel pp = pixels[c];
                                b.SetPixel(j, i, System.Drawing.Color.FromArgb(pp.Red, pp.Green, pp.Blue));
                                c++;
                            }

                        }
                }  
                    
                   else {

                        // picture contains additional alpha channel
                        int l = 4;
                        for (int i = 0; i < size; i += l)
                        {
                            pixel p = new pixel();

                            p.Red = Pixelmap[i];
                            p.Green = Pixelmap[i + 1];
                            p.Blue = Pixelmap[i + 2];
                            p.Alpha = Pixelmap[i + 3];
                            pixels.Add(p);
                        }
                      

                        int c = 0;
                        for (int i = 0; i < widthint; i++)
                        {
                            for (int j = 0; j < heightint; j++)
                            {
                                pixel pp = pixels[c];
                                b.SetPixel(j, i, System.Drawing.Color.FromArgb(pp.Alpha, pp.Red, pp.Green, pp.Blue));
                                c++;
                            }
                        }
                
                     }
               
                return b;

            }
            catch (Exception e)
            {
                Debug.Print(string.Format("Message: {0} StackTrace: {1}",e.Message,e.StrackTrace));
            }
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
            private int _alpha;

            public int Alpha
            {
                get { return _alpha; }
                set { _alpha = value; }
            }
	
        }
