using System;
using System.Text;

namespace NET01_2
{
    /// <summary>
    ///     This class create square matrix use indexer
    /// </summary>
    /// <typeparam>
    ///     <name>T</name>
    /// </typeparam>
    /// <typeparam name="T">generic parametr</typeparam>
    public class SquareMatrix<T>
    {
        /// <summary>
        ///     this array, where the array elements are stored
        /// </summary>
        protected T[] Data;
        
        /// <summary>
        ///     create event Changed
        /// </summary>
        public event EventHandler<MatrixEventArgs<T>> Changed;

        /// <summary>
        ///     gets the size of the matrix
        /// </summary>
        public int Size { get; }

        /// <summary>
        ///     this indexer
        /// </summary>
        /// <param name="i">the first indexer</param>
        /// <param name="j">the second indexer</param>
        /// <returns> returns the value of the matrix</returns>
        /// <exception cref="Exception()"> Thrown when i and/or j less than zero or equally Size</exception>
        public virtual T this[int i, int j]
        {
            get
            {
                Cheсk(i, j);
                return  Data[i * Size + j];
            } 
            set
            {
                Cheсk(i, j);
                var oldValue = Data[i * Size + j];
                if (!Equals(oldValue, value))
                {
                    Data[i * Size + j] = value;
                    OnChanged(new MatrixEventArgs<T>(i, j, oldValue, value));
                }
            }
        }

        /// <summary>
        ///     This constructor gets  size and array which initializes
        /// </summary>
        /// <param name="size">matrix size</param>
        public SquareMatrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("The size of the matrix can not be negative.");
            }
            Size = size;
            Data = new T[Size * Size];
        }

        /// <summary>
        ///     The method checks the output beyond the matrix
        /// </summary>
        /// <param name="i">The index of the row </param>
        /// <param name="j">The index of the column </param>
        public void Cheсk(int i, int j)
        {
            if (i > Size || j > Size)
            {
                throw new IndexOutOfRangeException("Going beyond the matrix!");
            }

            if (i < 0 || j < 0)
            {
                throw new IndexOutOfRangeException("Matrix size can't be less than 0!");
            }
        }

        /// <summary>
        ///     override methods for matrix output
        /// </summary>
        /// <returns>text consisting of matrix elements</returns>
        public override string ToString()
        {
            var result = new StringBuilder();
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    result.Append($"{this[i, j],-10}");
                }

                result.AppendLine();
            }

            return result.ToString();
        }

        /// <summary>
        ///     virtual method for passing information to class
        /// </summary>
        /// ///
        /// <param name="value">MatrixEventArgs</param>
        protected virtual void OnChanged(MatrixEventArgs<T> value)
        {
            Changed?.Invoke(this, value);
        }
    }
}