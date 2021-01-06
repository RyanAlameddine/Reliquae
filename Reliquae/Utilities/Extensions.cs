using Microsoft.Xna.Framework;
using Reliquae.Worlds.TileMaps;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Converts the point from world coordinates to the equivalent coordinate on the tileMap.
        /// </summary>
        public static Point WorldToTile(this Point worldCoordinate)
            => new Point(worldCoordinate.X / TileMap.TileWidth, worldCoordinate.Y / TileMap.TileWidth);

        /// <summary>
        /// Converts the point from the tileMap to the world coordinates that represent the top left of the tile.
        /// </summary>
        public static Point TileToWorldTopLeft(this Point worldCoordinate)
            => new Point(worldCoordinate.X * TileMap.TileWidth, worldCoordinate.Y * TileMap.TileWidth);

        /// <summary>
        /// Converts the point from the tileMap to the world coordinates that represent the center of the tile.
        /// </summary>
        public static Point TileToWorldCenter(this Point worldCoordinate)
            => new Point(worldCoordinate.X * TileMap.TileWidth + TileMap.TileWidth / 2, worldCoordinate.Y * TileMap.TileWidth + TileMap.TileWidth / 2);

        public static Vector2 Copy(this Vector2 vector)
            => new Vector2(vector.X, vector.Y);


        /// <summary>
        /// Returns an IEnumerable<<typeparamref name="T2"/>> of all values which did not fail to cast.
        /// </summary>
        public static IEnumerable<T2> WhereCast<T1, T2>(this IEnumerable<T1> items) where T2 : class
            => items.Select((x) => x as T2).Where((x) => x != null);

        public static void ForEach<T1>(this IEnumerable<T1> items, Action<T1> action)
        { 
            foreach (var item in items) action(item);
        }
    }
}
