using System;
using System.Text;
using icoll = System.Collections.ICollection;

namespace NetSh.Extensions {
    /// <summary>
    /// Extension functions for <see cref="icoll"/> samples.
    /// </summary>
    public static class ICollection {
        /// <summary>
        /// Write all items of <see cref="icoll"/>.
        /// </summary>
        /// <param name="collection">Collection to write.</param>
        public static void Write(this icoll collection) {
            Console.Write(collection.GetValue(' '));
        }

        /// <summary>
        /// WriteLine all items of <see cref="icoll"/>.
        /// </summary>
        /// <param name="collection">Collection to write.</param>
        public static void WriteLine(this icoll collection) {
            Console.Write(collection.GetValue('\n'));
        }

        /// <summary>
        /// Returns <see cref="Console.Write(string)"/> value of <see cref="icoll"/>
        /// </summary>
        /// <param name="collection">Collection.</param>
        /// <param name="sep">Seperator of items.</param>
        public static string GetValue(this icoll collection,char sep) {
            StringBuilder str = new StringBuilder();
            foreach(object item in collection) {
                str.Append(item);
                str.Append(sep);
            }
            str[str.Length-1] = '\0';
            return str.ToString();
        }
    }
}
