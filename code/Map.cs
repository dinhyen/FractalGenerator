using System;
using System.Linq;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.IO;
using System.Text.RegularExpressions;

namespace FractalGenerator
{
    class MapHelper
    {
        private static byte[,] _colorMap;
    
        public static byte[,] ColorMap
        {
            get { return _colorMap; }
        }

        struct RgbColor {
            public RgbColor(object r, object g, object b)
            {
                R = (byte)r;
                G = (byte)g;
                B = (byte)b;
            }
            byte R;
            byte G;
            byte B;
        }

        public static void ReadMap(StreamResourceInfo info)
        {
            string text;
            using (Stream mapStream = info.Stream)
            {
                using (StreamReader reader = new StreamReader(mapStream))
                {
                    text = reader.ReadToEnd();
                }
            }
            Regex regexOnNewLine = new Regex(@"\n+");
            Regex regexNoText = new Regex(@"[^0-9 ]");
            Regex regexOnSpace = new Regex(@"\s+");
            var query = from line in regexOnNewLine.Split(text)
                        let rgb = regexOnSpace.Split(regexNoText.Replace(line, "").Trim())
                        select rgb;

            if (_colorMap == null)
                _colorMap = new byte[256, 3];

            int index = 0;
            try
            {

                byte R, G, B;
                foreach (var rgb in query)
                {
                    if (rgb != null)
                    {
                        R = Convert.ToByte(rgb[0]);
                        G = Convert.ToByte(rgb[1]);
                        B = Convert.ToByte(rgb[2]);

                        _colorMap[index, 0] = R;
                        _colorMap[index, 1] = G;
                        _colorMap[index, 2] = B;

                        if (++index >= 256)
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

    }   // class

}   // namespace
