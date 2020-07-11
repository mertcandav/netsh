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
        public static void Write(this string str) {
            Console.Write(str);
        }

        /// <summary>
        /// WriteLine.
        /// </summary>
        /// <param name="str"><see cref="string"/> to write.</param>
        public static void WriteLine(this string str) {
            Console.WriteLine(str);
        }

        /// <summary>
        /// Write characters.
        /// </summary>
        /// <param name="str"><see cref="string"/> to write.</param>
        public static void WriteChars(this string str) {
            IEnumerable.Write(str);
        }

        /// <summary>
        /// WriteLine characters.
        /// </summary>
        /// <param name="str"><see cref="string"/> to write.</param>
        public static void WriteLineChars(this string str) {
            IEnumerable.WriteLine(str);
        }
    }
}
