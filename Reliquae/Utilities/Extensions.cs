using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.Utilities
{
    public static class Extensions
    {
        /// <summary>
        /// Select on 2d array with y and x as parameters of the func
        /// </summary>
        public static U[,] Select<T, U>(this T[,] array, Func<int, int, T, U> func)
        {
            U[,] newArray = new U[array.GetLength(0), array.GetLength(1)];

            array.Foreach((x, y, t) => newArray[y, x] = func(x, y, t));

            return newArray;
        }

        public static void Foreach<T>(this T[,] array, Action<int, int, T> action)
        {
            for (int y = 0; y < array.GetLength(0); y++)
            {
                for (int x = 0; x < array.GetLength(1); x++)
                {
                    action(x, y, array[y, x]);
                }
            }
        }
    }
}
