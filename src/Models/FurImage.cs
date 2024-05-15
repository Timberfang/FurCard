using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Avalonia.Media.Imaging;
using System.IO;
using System.Net.Http;

namespace FurCard.Models
{
    public class FurImage
    {
        public Bitmap Bitmap { get; }

        public FurImage(string Path)
        {
            Bitmap = new Bitmap(Path);
        }

        public FurImage(Uri URL)
        {
            Bitmap = GetBitmapFromURL(URL).Result;
        }

        private static async Task<Bitmap> GetBitmapFromURL(Uri URL)
        {
            HttpClient client = new();

            using Stream ImageIn = await client.GetStreamAsync(URL);

            return new Bitmap(ImageIn);
        }
    }
}
