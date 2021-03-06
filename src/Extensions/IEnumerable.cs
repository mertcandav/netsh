﻿using System;
using System.Text;
using ienum = System.Collections.IEnumerable;

namespace NetSh.Extensions {
    /// <summary>
    /// Extension functions for <see cref="ienum"/> samples.
    /// </summary>
    public static class IEnumerable {
        /// <summary>
        /// Prints all items of <see cref="ienum"/>.
        /// </summary>
        /// <param name="collection">Collection to write.</param>
        public static void Print(this ienum collection) {
            Console.Write(collection.GetValue(' '));
        }

        /// <summary>
        /// Prints all items line by line of <see cref="ienum"/>.
        /// </summary>
        /// <param name="collection">Collection to write.</param>
        public static void Println(this ienum collection) {
            Console.Write(collection.GetValue('\n'));
        }

        /// <summary>
        /// Returns <see cref="Console.Write(string)"/> value of <see cref="ienum"/>
        /// </summary>
        /// <param name="collection">Collection.</param>
        /// <param name="sep">Seperator of items.</param>
        public static string GetValue(this ienum collection,char sep) {
            StringBuilder str = new StringBuilder();
            foreach(object item in collection) {
                str.Append(item);
                str.Append(sep);
            }
            //str[str.Length-1] = '\0';
            return str.ToString();
        }
    }
}
