using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    internal class ImageGenerator
    {
        public static string GenerateRandomBase64Image(int width, int height)
        {
            var image = new Image<Rgba32>(width, height);

            var random = new Random();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    image[x, y] = new Rgba32((byte)random.Next(255), (byte)random.Next(255), (byte)random.Next(255));
                }
            }

            var ms = new MemoryStream();
            image.SaveAsJpeg(ms);
            var base64Image = Convert.ToBase64String(ms.ToArray());

            return "data:image/jpeg;base64," + base64Image;
            //return base64Image;
        }
    }
}
