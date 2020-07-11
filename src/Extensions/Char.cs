using System;

namespace NetSh.Extensions {
    /// <summary>
    /// Extension functions for <see cref="char"/> samples.
    /// </summary>
    public static class Char {
        /// <summary>
        /// Write.
        /// </summary>
        /// <param name="ch">Char to write.</param>
        public static void Write(this char ch) {
            Console.Write(ch);
        }

        /// <summary>
        /// WriteLine.
        /// </summary>
        /// <param name="ch">Char to write.</param>
        public static void WriteLine(this char ch) {
            Console.Write(ch);
        }
    }
}