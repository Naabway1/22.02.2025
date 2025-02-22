using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22._02._2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            Console.WriteLine(CanCross(new int[] { 0, 1, 3, 5, 6, 8, 12, 17 }));
            Console.WriteLine(CanCross(new int[] { 0, 1, 2, 3, 4, 8, 9, 11 }));

            //Задание 2
            int[][] grid1 = new int[][] {
            new int[] {1, 2},
            new int[] {3, 4}
        };
            Console.WriteLine(SurfaceArea(grid1));

            int[][] grid2 = new int[][] {
            new int[] {1, 1, 1},
            new int[] {1, 0, 1},
            new int[] {1, 1, 1}
        };
            Console.WriteLine(SurfaceArea(grid2));
            Console.ReadKey();
        }
        public static bool CanCross(int[] stones)
        {
            var dp = new Dictionary<int, HashSet<int>>(); // ключ - позиция камня, значение - множество разных возможных прыжков до камня
            foreach (var stone in stones) dp[stone] = new HashSet<int>(); // добавление всех позиций камней

            foreach (var stone in stones)
            {
                foreach (var k in dp[stone])
                {
                    for (int step = k - 1; step <= k + 1; step++)
                    {
                        if (step > 0 && dp.ContainsKey(stone + step)) // проверка на каждый камень, сможет ли лягушка до него допрыгнуть, используя все прыжки.
                            dp[stone + step].Add(step); // если может, добавление в словарь этого прыжка.
                    }
                }
            }
            return dp[stones[stones.Length - 1]].Count > 0;
        }
        public static int SurfaceArea(int[][] grid)
        {
            int n = grid.Length;
            int area = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] > 0)
                    {
                        area += 4 * grid[i][j] + 2;
                    }
                    if (i > 0)
                    {
                        area -= 2 * Math.Min(grid[i][j], grid[i - 1][j]);
                    }
                    if (j > 0)
                    {
                        area -= 2 * Math.Min(grid[i][j], grid[i][j - 1]);
                    }

                }
            }
            return area;
        }
    }
}
