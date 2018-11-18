using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Script
{
    public class MazeCreater
    {
        /*
         char of map[,]:
         'r':road
         'w':wall
         'h':leaf or top
             */

        private Stack<Point> trace;
        private List<Point> leaves;
        private char[,] map;
        private Point begin;
        private Point current;
        private Random random;
        private bool arriveHeap = false;

        private class Point
        {
            public int x, y;
            public Point(int x,int y)
            {
                this.x = x;
                this.y = y;
            }

            public List<Point> Nears()
            {
                List<Point> nears = new List<Point>();

                nears.Add(new Point(x + 1, y));
                nears.Add(new Point(x - 1, y));
                nears.Add(new Point(x, y + 1));
                nears.Add(new Point(x, y - 1));

                return nears;
            }
        }
        

        public MazeCreater(int size)
        {
            random = new Random(DateTime.Now.Millisecond);
            trace = new Stack<Point>();
            leaves = new List<Point>();
            map = new char[size, size];
            begin = new Point(size / 2, size / 2);
            map[begin.x, begin.y] = 'r';

            current = begin;
            trace.Push(current);
        }

        // true : can pass. 
        public char[,] CreateMap()
        {
            while (trace.Count != 0)
            {
                var near = FindCanVisit();
                if (near.Count != 0)
                {
                    int target = random.Next() % near.Count;
                    current = near[target];
                    trace.Push(current);
                    map[current.x, current.y] = 'r';
                    arriveHeap = false;
                }
                else
                {
                    if (!arriveHeap)
                    {
                        map[current.x, current.y] = 'h';
                        leaves.Add(current);
                        arriveHeap = true;
                    }
                    
                    current = trace.Pop();
                }
            }

            return map;
        }

        // 將部分leaves 的標籤改為 [c]
        // rate 介於 [0,1]
        // 取前面 [rate * total] 個葉子.
        public char[,] ChangeSomeLeaves(float rate, char c, bool fromHead = true)
        {
            int total = leaves.Count;
            int num = (int)(rate * total);
            
            while (num != 0){

                int  i;
                if (fromHead)
                    i = num-1;
                else
                    i = total - num;

                var point = leaves.ElementAt(i);
                map[point.x, point.y] = c;

                --num;

            }

            return map;
        }

        // 將部分leaves 的標籤改為 [c]
        // rate 介於 [0,1]
        // 取距離大於 stepLargeThan 的葉子.
        // 數量隨機決定.
        public char[,] ChangeSomeLeavesForstep(float rate, int stepLargeThan, char c)
        {
            int total = leaves.Count;
            int num = (int)(total * rate);

            foreach(var e in leaves)
            {
                int step = Math.Abs(e.x - begin.x) + Math.Abs(e.y - begin.y);
                if (step > stepLargeThan && random.Next(total) < num)
                {
                    map[e.x, e.y] = c;
                }
            }
            
            return map;
        }

        private List<Point> FindCanVisit()
        {
            List<Point> canVisites = current.Nears();

            for(int i = 0; i < canVisites.Count; ++i)
            {
                if (CannotVisit(canVisites[i]))
                {
                    canVisites.RemoveAt(i);
                    --i;
                }
            }

            return canVisites;
        }

        private bool CannotVisit(Point point)
        {
            if (point.x < 0 || point.y < 0 || point.x >= map.GetLength(0) || point.y >= map.GetLength(1))
                return true;

            if (CanPass(point.x, point.y))
                return true;

            if (CloseValue(point) > 4)
                return true;
            else
                return false;
        }

        // 周圍有幾格不能走.
        private int CloseValue(Point point)
        {
            int closeCount = 0;
            for(int x = point.x - 2; x < point.x + 2; ++x)
            {
                for(int y = point.y - 2; y < point.y + 2; ++y)
                {
                    if (x <= 0 || y <= 0 || x >= map.GetLength(0) - 1 || y >= map.GetLength(1) - 1)
                        ++closeCount;
                    else if (CanPass(x, y))
                        ++closeCount;
                }
            }
            return closeCount;
        }

        private bool CanPass(int x,int y)
        {
            char c = map[x, y];
            if (c == 'r' || c == 'h')
                return true;
            else
                return false;
        }

    }
}
