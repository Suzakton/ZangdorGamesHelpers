using System;
using System.Collections.Generic;
using System.Linq;

namespace ZangdorGames.Helpers.DataStructures
{
    public class GenericGrid<T>
    {
        private int _width;
        private int _height;
        private T[,] _grid;

        public T this[int x, int y]
        {
            get { return _grid[x, y]; }
            set { _grid[x, y] = value; }
        }

        public GenericGrid(int width, int height, Func<int, int, T> CreateGenericElement)
        {
            _width = width;
            _height = height;
            _grid = new T[_width, _height];
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    _grid[i, j] = CreateGenericElement(i, j);
                }
            }
        }
        
        public List<T> GetAllElements()
        {
            return _grid.Cast<T>().ToList();
        }

        public T TryGetElementAt(int x, int y)
        {
            if(x < 0 || x >= _width || y < 0 || y >= _height)
                return default(T);
            return _grid[x,y];
        }
    }
}