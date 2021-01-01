using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.Utilities
{
    public static class Extensions
    {
        /// <summary>
        /// Select on 2d array with x and y as parameters of the func
        /// </summary>
        public static U[,] Select<T, U>(this T[,] array, Func<int, int, T, U> func)
        {
            U[,] newArray = new U[array.GetLength(0), array.GetLength(1)];

            array.Foreach((x, y, t) => newArray[x, y] = func(x, y, t));

            return newArray;
        }

        public static void Foreach<T>(this T[,] array, Action<int, int, T> action)
        {
            for (int y = 0; y < array.GetLength(1); y++)
            {
                for (int x = 0; x < array.GetLength(0); x++)
                {
                    action(x, y, array[x, y]);
                }
            }
        }

        public static T Get<T>(this T[,] array, int x, int y)
        {
            if (x < 0 || y < 0 || x >= array.Length || y >= array.Length) return default;
            return array[x, y];
        }
    }
}
