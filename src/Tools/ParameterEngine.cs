using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace NetSh.Tools {
    /// <summary>
    /// Parameter engine of <see cref="NetShell"/>.
    /// </summary>
    public static class ParameterEngine {
        /// <summary>
        /// Returns namesapce of command.
        /// </summary>
        /// <param name="cmd">Command.</param>
        public static string GetNamespace(this string cmd) {
            int index = cmd.IndexOf(" ");
            if(index != -1)
                cmd = cmd.Substring(0,index);
            return cmd;
        }

        /// <summary>
        /// Returns removed namesapce command.
        /// </summary>
        /// <param name="cmd">Command.</param>
        public static string RemoveNamespace(this string cmd) {
            int index = cmd.IndexOf(" ");
            if(index != -1)
                cmd = cmd.Substring(index+1);
            else
                cmd = string.Empty;
            return cmd;
        }

        /// <summary>
        /// Returns parameter(s) of command.
        /// </summary>
        /// <param name="cmd">Command.</param>
        /// <param name="delimiter">Parameter delimiter.</param>
        public static List<string> GetParameters(this string cmd,string delimiter) {
            return GetParameters(" " + cmd + " ",new Regex($@"{delimiter}\w+(?=({delimiter}|\s+))"));
        }

        /// <summary>
        /// Returns parameter(s) of command.
        /// </summary>
        /// <param name="cmd">Command.</param>
        /// <param name="pattern">Pattern of parameters.</param>
        public static List<string> GetParameters(this string cmd,Regex pattern) {
            MatchCollection matches = pattern.Matches(cmd);
            List<string> args = new List<string>();
            for(int index = 0; index < matches.Count; index++) {
                Match match = matches[index];
                if(!match.Success)
                    continue;
                args.Add(cmd.Substring(match.Index,match.Length).Trim());
            }
            return args;
        }

        /// <summary>
        /// Returns removed parameters command.
        /// </summary>
        /// <param name="cmd">Command.</param>
        /// <param name="delimiter">Parameter delimiter.</param>
        public static string RemoveParameters(this string cmd,string delimiter) {
            return RemoveParameters(" " + cmd + " ",new Regex($@"{delimiter}\w+(?=({delimiter}|\s+))"));
        }

        /// <summary>
        /// Returns removed parameters command.
        /// </summary>
        /// <param name="cmd">Command.</param>
        /// <param name="pattern">Pattern of parameters.</param>
        public static string RemoveParameters(this string cmd,Regex pattern) {
            cmd = pattern.Replace(cmd,string.Empty);
            return cmd.Trim();
        }
    }
}
