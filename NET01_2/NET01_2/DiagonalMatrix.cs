using System;

namespace NET01_2
{
    /// <summary>
    ///     this class create diagonal matrix
    ///     diagonal matrix is matrix where non-diagonal elements are zero
    /// </summary>
    /// <typeparam name="T">
    ///     generic parameters
    /// </typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        ///     This constructor gets size which initializes
        /// </summary>
        /// <param name="size">matrix size</param>
        public DiagonalMatrix(int size) : base(size)
        {
            Data = new T[Size];
        }

        /// <value>get the type of the matrix </value>
        /// <summary>
        ///     this indexer
        /// </summary>
        /// <param name="i">the first indexer</param>
        /// <param name="j">the second indexer</param>
        /// <returns> returns the value of the matrix</returns>
        /// <exception cref="Exception()"> Thrown when i and/or j less than zero or equally Size</exception>
        public override T this[int i, int j]
        {
            get
            {
                Cheсk(i, j);
                if (i == j)
                {
                    return Data[i ];
                }

                return default;
            }
            set
            {
                Cheсk(i, j);
                var oldValue = Data[i];

                if (i != j)
                    throw new ArgumentException("In the diagonal matrix can not be set elements outside the main diagonal.");

                if (!Equals(oldValue, value))
                {
                    Data[i] = value;
                    OnChanged(new MatrixEventArgs<T>(i, j, oldValue, value));
                }
            }
        }
    }
}