using System;

namespace NetSh.Extensions {
    /// <summary>
    /// Extension functions for <see cref="string"/> samples.
    /// </summary>
    public static class String {
        /// <summary>
        /// Write.
        /// </summary>
        /// <param name="str"><see cref="string"/> to write.</param>
        public static void Print(this string str) {
            Console.Write(str);
        }

        /// <summary>
        /// WriteLine.
        /// </summary>
        /// <param name="str"><see cref="string"/> to write.</param>
        public static void Println(this string str) {
            Console.WriteLine(str);
        }

        /// <summary>
        /// Write characters.
        /// </summary>
        /// <param name="str"><see cref="string"/> to write.</param>
        public static void PrintChars(this string str) {
            IEnumerable.Print(str);
        }

        /// <summary>
        /// WriteLine characters.
        /// </summary>
        /// <param name="str"><see cref="string"/> to write.</param>
        public static void PrintlnChars(this string str) {
            IEnumerable.Println(str);
        }
    }
}
