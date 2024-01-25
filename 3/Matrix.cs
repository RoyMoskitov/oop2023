using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testdll;

namespace WindowsFormsAppGame
{
    namespace GameClasses
    {

        public enum CellType { floor = 1, wall = 2, glass = 3, partition = 4, warehouse = 5 };

        public class Cell
        {
            public CellType type = CellType.floor;
            public List<Items.Item> items = new List<Items.Item>();

            public Cell(CellType type = CellType.floor)
            {
                this.type = type;
                //this.items = Items;
            }

            public CellType Type
            {
                get { return type; }
                set { type = value; }
            }

            public List<Items.Item> Items
            {
                get { return items; }
                set
                {
                    items = value;
                }
            }
        }
        /// <summary>
        /// template class defining a matrix using a double array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Matrix<T>
        {
            protected int height;
            protected int width;
            protected T[,] data;
            /// <summary>
            /// Constructor including default one
            /// </summary>
            /// <param name="h"> Matrix height </param>
            /// <param name="w"> Matrix width </param>
            /// <exception cref="ArgumentException"> Throws exception if width or height is less or equals zero </exception>
            public Matrix(int h = 20, int w = 20)
            {
                if (w <= 0)
                {
                    throw new ArgumentException("Width cannot be less than zero.", nameof(width));
                }
                if (h <= 0)
                {
                    throw new ArgumentException("Height cannot be less than zero.", nameof(height));
                }
                data = new T[h, w];
                height = h;
                width = w;
            }
            /// <summary>
            /// Unequality operator 
            /// </summary>
            /// <param name="obj1"> first matrix to compare </param>
            /// <param name="obj2"> second matrux </param>
            /// <returns> False if two matrixes are equal and true otherwise </returns>
            public static bool operator !=(Matrix<T> obj1, Matrix<T> obj2)
            {
                return !(obj1 == obj2);
            }
            /// <summary>
            /// Equality operator 
            /// </summary>
            /// <param name="obj1"> first matrix to compare </param>
            /// <param name="obj2"> second matrux </param>
            /// <returns> True if two matrixes are equal and false otherwise </returns>
            public static bool operator ==(Matrix<T> obj1, Matrix<T> obj2)
            {
                if (!obj1.Equals(obj2))
                {
                    return false;
                }
                return true;
            }
            /// <summary>
            /// Adds an additional column to the right of the matrix
            /// </summary>
            /// <param name="column"> Array that will be added as a matrix column </param>
            /// <exception cref="ArgumentException"> Throws exception if length of the array is not equal to matrix height </exception>
            public void AddCol(T[] column)
            {
                if (column.Length != Height)
                {
                    throw new ArgumentException("Array length must be equal to matrix height.", nameof(column));
                }
                this.Resize(height, width + 1);
                for (int i = 0; i < height; i++)
                {
                    this[i, width - 1] = column[i];
                }
            }
            /// <summary>
            /// Adds an additional row to the bottom of the matrix
            /// </summary>
            /// <param name="row"> Array that will be added as a matrix row </param>
            /// <exception cref="ArgumentException"> Throws exception if length of the array is not equal to matrix width </exception>
            public void AddRow(T[] row)
            {
                if (row.Length != width)
                {
                    throw new ArgumentException("Array length must be equal to matrix width.", nameof(row));
                }
                this.Resize(height + 1, width);
                for (int i = 0; i < width; i++)
                {
                    this[height - 1, i] = row[i];
                }
            }
            /// <summary>
            /// Changes matrix dimensions to user-specified ones
            /// </summary>
            /// <param name="h"> New matrix height </param>
            /// <param name="w"> New matrix width </param>
            /// <exception cref="ArgumentException"> Throws exception if width or height is less or equals zero </exception>
            public void Resize(int h, int w)
            {
                if (w <= 0)
                {
                    throw new ArgumentException("Width cannot be less than zero.", nameof(w));
                }
                if (h <= 0)
                {
                    throw new ArgumentException("Height cannot be less than zero.", nameof(h));
                }
                T[,] res = new T[h, w];
                for (int i = 0; i < Math.Min(height, h); i++)
                {
                    for (int j = 0; j < Math.Min(width, w); j++)
                    {
                        res[i, j] = this[i, j];
                    }
                }
                height = h;
                width = w;
                this.data = res;
            }
            /// <summary>
            /// Compares two matrices and determines whether they are equal
            /// </summary>
            /// <param name="obj"> object to compare to </param>
            /// <returns> True if two matrixes are equal and false otherwise </returns>
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;

                Matrix<T> other = (Matrix<T>)obj;

                if (Width != other.Width || Height != other.Height)
                    return false;

                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        if (!data[i, j].Equals(other.data[i, j]))
                            return false;
                    }
                }

                return true;
            }
            /// <summary>
            /// Calculates the hash code of an object
            /// </summary>
            /// <exception cref="NotImplementedException"> Function is not implemented </exception>
            public override int GetHashCode()
            {
                throw new NotImplementedException();
            }
            /// <summary>
            /// Getter or setter for matrix width
            /// </summary>
            public int Width
            {
                get
                {
                    return width;
                }
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("Width cannot be less than zero.", nameof(value));
                    }
                    width = value;
                }
            }
            /// <summary>
            /// Getter or setter for matrix height 
            /// </summary>
            public int Height
            {
                get
                {
                    return height;
                }
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("Height cannot be less than zero.", nameof(value));
                    }
                    height = value;
                }
            }
            /// <summary>
            /// Getter or setter for matrix double array elements
            /// </summary>
            /// <param name="i"> index for matrix height </param>
            /// <param name="j"> index for matrix width </param>
            /// <returns> double array element </returns>
            public T this[int i, int j]
            {
                get
                {
                    return data[i, j];
                }
                set { data[i, j] = value; }
            }
            /// <summary>
            /// Getter or setter for matrix double array
            /// </summary>
            public T[,] Data
            {
                get
                {
                    return data;
                }
                set
                {
                    data = value;
                }
            }
            /// <summary>
            /// Iterator that goes through all elements of the array starting from zero
            /// </summary>
            /// <returns> Double array element </returns>
            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        yield return data[i, j];
                    }
                }
            }
            /// <summary>
            /// Removes the rightmost column of the matrix
            /// </summary>
            public void DelRow()
            {
                Resize(height - 1, width);
            }
            /// <summary>
            /// Removes the bottom row of the matrix
            /// </summary>
            public void DelCol()
            {
                Resize(height, width - 1);
            }
        }

    }

}
