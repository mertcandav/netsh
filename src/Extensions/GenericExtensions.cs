#pragma warning disable CS1723

using System;
using ienum = System.Collections.IEnumerable;

namespace NetSh.Extensions {
    /// <summary>
    /// Extension functions for <see cref="T"/> samples.
    /// </summary>
    /// <typeparam name="T">Type of object.</typeparam>
    public class GenericExtensions<T> {
        /// <summary>
        /// Write.
        /// </summary>
        /// <param name="obj"><see cref="T"/> to write.</param>
        public static void Write(T obj) {
            if(obj is ienum && !(obj is string))
                IEnumerable.Write(obj as ienum);
            else
                Console.Write(obj);
        }

        /// <summary>
        /// WriteLine.
        /// </summary>
        /// <param name="obj"><see cref="T"/> to write.</param>
        public static void WriteLine(T obj) {
            if(obj is ienum && !(obj is string))
                IEnumerable.WriteLine(obj as ienum);
            else
                Console.WriteLine(obj);
        }
    }
}