#pragma warning disable CS1723

using CLI = System.Console;
using CLIColor = System.ConsoleColor;
using ienum = System.Collections.IEnumerable;

namespace NetSh.Extensions {
    /// <summary>
    /// Generic extension functions of <see cref="NetShell"/>.
    /// </summary>
    public static class GenericExtensions {
        /// <summary>
        /// Print object to screen.
        /// </summary>
        /// <param name="obj">Object to print.</param>
        public static void Print(this object obj) {
            if(obj is ienum && !(obj is string))
                IEnumerable.Print(obj as ienum);
            else
                CLI.Write(obj);
        }

        /// <summary>
        /// Print object to screen.
        /// </summary>
        /// <param name="obj">Object to print.</param>
        /// <param name="color">Color of print.</param>
        public static void Print(this object obj,CLIColor color) {
            CLIColor rcolor = CLI.ForegroundColor;
            CLI.ForegroundColor = color;
            Print(obj);
            CLI.ForegroundColor = rcolor;
        }

        /// <summary>
        /// Print object and new line to screen.
        /// </summary>
        /// <param name="obj">Object to print.</param>
        public static void Println(this object obj) {
            if(obj is ienum && !(obj is string))
                IEnumerable.Println(obj as ienum);
            else
                CLI.WriteLine(obj);
        }

        /// <summary>
        /// Print object and new line to screen.
        /// </summary>
        /// <param name="obj">Object to print.</param>
        /// <param name="color">Color of print.</param>
        public static void Println(this object obj,CLIColor color) {
            CLIColor rcolor = CLI.ForegroundColor;
            CLI.ForegroundColor = color;
            Println(obj);
            CLI.ForegroundColor = rcolor;
        }
    }
}