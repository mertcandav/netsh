using CLI = System.Console;
using CLIColor = System.ConsoleColor;

namespace NetSh.Tools {
    /// <summary>
    /// Console printer of <see cref="NetShell"/>.
    /// </summary>
    public static class Printer {
        /// <summary>
        /// Print object to screen.
        /// </summary>
        /// <param name="obj">Object to print.</param>
        public static void Print(this object obj) {
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
