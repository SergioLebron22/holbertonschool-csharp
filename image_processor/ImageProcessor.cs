using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

/// <summary>
/// ImageProcessor class
/// </summary>
class ImageProcessor
{
    /// <summary>
    /// Inverse method
    /// </summary>
    /// <param name="filenames">Array of filenames</param>
    /// <returns>void</returns>
    public static void Inverse(string[] filenames)
    {
        Parallel.ForEach(filenames, (filename) =>
        {
            try
            {
                using (Bitmap image = new Bitmap(filename))
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        for (int x = 0; x < image.Width; x++)
                        {
                            Color pixelColor = image.GetPixel(x,y);
                            Color InvertedColor = Color.FromArgb(255- pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B);
                            image.SetPixel(x, y, InvertedColor);
                        }
                    }
                    string directory = Path.GetPathRoot(filename);
                    string extension = Path.GetExtension(filename);
                    string NameNoExtension = Path.GetFileNameWithoutExtension(filename);
                    string NewImage = Path.Combine(directory, $"{NameNoExtension}_inverse{extension}");

                    image.Save(NewImage);
                    Console.WriteLine(NewImage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        });
    }
}