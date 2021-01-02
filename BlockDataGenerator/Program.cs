﻿using Reliquae.Memory.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BlockDataGenerator
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter bitmap path:");
            Bitmap bitmap = (Bitmap)Image.FromFile(Console.ReadLine());

            Console.WriteLine("Please enter the path prefix (e.g. \"dirt/\"): ");
            string pathPrefix = Console.ReadLine();
            LinkedList<SingleAdjacencyModel> models = new LinkedList<SingleAdjacencyModel>();

            Dictionary<Color, string> colorMap = new Dictionary<Color, string>();

            int i = 1;
            for (int y = 0; y < bitmap.Height; y += 3)
            {
                for (int x = 0; x < bitmap.Width; x += 3)
                {
                    string w  = loadPixel(x    , y + 1);
                    string nw = loadPixel(x    , y    );
                    string n  = loadPixel(x + 1, y    );
                    string ne = loadPixel(x + 2, y    );
                    string e  = loadPixel(x + 2, y + 1);
                    string se = loadPixel(x + 2, y + 2);
                    string s  = loadPixel(x + 1, y + 2);
                    string sw = loadPixel(x    , y + 2);

                    var model = new SingleAdjacencyModel(pathPrefix + i, w, nw, n, ne, e, se, s, sw);

                    models.AddLast(model);

                    i++;
                }
            }

            var fullModel = new BlockModel<SingleAdjacencyModel>(ushort.MaxValue, null, null, models.ToArray());
            Console.WriteLine("\nProcessing Complete!");
            Console.WriteLine("\n");

            string json = JsonSerializer.Serialize(fullModel, new JsonSerializerOptions()
            {
                WriteIndented = true,
                AllowTrailingCommas = true
            });
            Console.WriteLine(json);
            

            string loadPixel(int x, int y)
            {
                string block;
                Color pixel = bitmap.GetPixel(x, y);
                if (colorMap.ContainsKey(pixel)) block = colorMap[pixel];
                else
                {
                    Colorful.Console.ForegroundColor = pixel;
                    Colorful.Console.WriteLine("What block does this color represent?");
                    Colorful.Console.ResetColor();

                    block = Console.ReadLine();
                    block = string.IsNullOrWhiteSpace(block) ? null : block;
                    colorMap.Add(pixel, block);
                }
                return block;
            }
        }
    }
}