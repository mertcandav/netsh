#pragma warning disable CS1723

using System;
using ienum = System.Collections.IEnumerable;

namespace NetSh.Extensions {
    /// <summary>
    /// Generic extension functions.
    /// </summary>
    public static class GenericExtensions {
        /// <summary>
        /// Write.
        /// </summary>
        /// <param name="obj">Object to write.</param>
        public static void Write(this object obj) {
            if(obj is ienum && !(obj is string))
                IEnumerable.Write(obj as ienum);
            else
                Console.Write(obj);
        }

        /// <summary>
        /// WriteLine.
        /// </summary>
        /// <param name="obj">Object to write.</param>
        public static void WriteLine(this object obj) {
            if(obj is ienum && !(obj is string))
                IEnumerable.WriteLine(obj as ienum);
            else
                Console.WriteLine(obj);
        }
    }
}