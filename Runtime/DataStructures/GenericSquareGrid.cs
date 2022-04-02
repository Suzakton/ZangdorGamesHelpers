using System;
using System.Collections.Generic;
using System.Linq;
using ZangdorGames.Helpers.Extensions;

namespace ZangdorGames.Helpers.DataStructures
{
    /// <summary>
    /// A generic square grid data structure.
    /// The size of the grid can't be changed after creation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericSquareGrid<T>
    {
        /// <summary>
        /// The width of the grid.
        /// </summary>
        private int _width;

        /// <summary>
        /// The height of the grid
        /// </summary>
        private int _height;

        /// <summary>
        /// The grid array.
        /// </summary>
        private T[,] _grid;

        /// <summary>
        /// Grid's width accessor.
        /// </summary>
        public int Width => _width;

        /// <summary>
        /// Grid's height accessor.
        /// </summary>
        public int Height => _height;

        /// <summary>
        /// Operator to directly access elements.
        /// </summary>
        /// <value></value>
        public T this[int x, int y]
        {
            get { return _grid[x, y]; }
            set { _grid[x, y] = value; }
        }

        /// <summary>
        /// Constructor of the grid.
        /// </summary>
        /// <param name="width">Width of the grid.</param>
        /// <param name="height">Height of the grid.</param>
        /// <param name="CreateGenericElement">Function used to populate the grid.</param>
        public GenericSquareGrid(int width, int height, Func<int, int, T> CreateGenericElement)
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
        
        /// <summary>
        /// Return all elements of the grid on a list.
        /// </summary>
        /// <returns>The list containing all the elements of the grid.</returns>
        public List<T> GetAllElements()
        {
            return _grid.Cast<T>().ToList();
        }

        /// <summary>
        /// Check if the index is in the grid.
        /// </summary>
        /// <param name="x">The x position.</param>
        /// <param name="y">Ths y position.</param>
        /// <returns>True if this index is valid. False otherwise.</returns>
        public bool HasIndex(int x, int y)
        {
            return _grid.HasIndex(x, y);
        }

        /// <summary>
        /// Return all neighbourgs of the element at the position (x, y).
        /// </summary>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        /// <param name="includeDiagonal">If true diagonals are returned as neightbours.</param>
        /// <returns>A list of neighbourg elements.</returns>
        public List<T> GetNeighbourgs(int x, int y, bool includeDiagonal)
        {
            List<T> neighbourgs = new List<T>();
            if(_grid.HasIndex(x - 1, y))
                neighbourgs.Add(_grid[x - 1, y]);
            if(_grid.HasIndex(x + 1, y))
                neighbourgs.Add(_grid[x + 1, y]);
            if(_grid.HasIndex(x , y - 1))
                neighbourgs.Add(_grid[x, y - 1]);
            if(_grid.HasIndex(x, y + 1))
                neighbourgs.Add(_grid[x, y + 1]);

            if(includeDiagonal)
            {
                if(_grid.HasIndex(x - 1, y - 1))
                    neighbourgs.Add(_grid[x - 1, y - 1]);
                if(_grid.HasIndex(x + 1, y - 1))
                    neighbourgs.Add(_grid[x + 1, y - 1]);
                if(_grid.HasIndex(x - 1, y + 1))
                    neighbourgs.Add(_grid[x - 1, y + 1]);
                if(_grid.HasIndex(x + 1, y + 1))
                    neighbourgs.Add(_grid[x + 1, y + 1]);
            }
            return neighbourgs;
        }
    }
}