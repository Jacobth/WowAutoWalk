using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace WoWObjMgr.Utilities
{
    class FileReader
    {

        public static List<Point> ReadFile(string file)
        {
            List<Point> list = new List<Point>();

            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(path + "\\Ores\\" + file))

            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;

                while ((line = streamReader.ReadLine()) != null)
                {                   
                    string[] pos = line.Split(',');                
                    Point p = getPoint(pos);
                    list.Add(p);

                   // Console.WriteLine("x: " + p.getX() + " y: " + p.getY() + " z: " + p.getZ());
                }
            }

       

            return list;
        }

        private static Point getPoint(string[] pos)
        {
            float x = float.Parse(pos[0], CultureInfo.InvariantCulture.NumberFormat);
            float y = float.Parse(pos[1], CultureInfo.InvariantCulture.NumberFormat);
            float z = float.Parse(pos[2], CultureInfo.InvariantCulture.NumberFormat);

            return new Point(x, y, z);
        }

    }
}
