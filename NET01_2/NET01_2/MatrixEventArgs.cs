using System;

namespace NET01_2
{
    /// <summary>
    ///     a class that supports the string representation of a message
    /// </summary>
    public class MatrixEventArgs<T> : EventArgs
    {
        ///<value>Gets the value of New. </value>
        public T New { get; }

        ///<value>Gets the value of Old. </value>
        public T Old { get; }

        ///<value>Gets the value of I. </value>
        public int I { get; }

        ///<value>Gets the value of J. </value>
        public int J { get; }

        /// <summary>
        ///     The constructor initializes the parameters.
        /// </summary>
        /// <param name="i">The first index</param>
        /// <param name="j">The second Index</param>
        /// <param name="oldValue">Old value</param>
        /// <param name="newValue">New value</param>
        public MatrixEventArgs(int i, int j, T oldValue, T newValue)
        {
            New = newValue;
            Old = oldValue;
            I = i;
            J = j;
        }
    }
}