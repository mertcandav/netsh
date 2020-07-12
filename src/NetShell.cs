#region license

//Copyright(c) 2020 Mertcan Davulcu
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetSh {
    /// <summary>
    /// NetShell, shell tool.
    /// </summary>
    public class NetShell {
        private bool exit = default;

        #region Constructors

        /// <summary>
        /// Initialize new instance of <see cref="NetShell"/>
        /// </summary>
        public NetShell() {
            Commands = new List<INetShellCommand>(new[] {
                new NetShellCommand("help","Show help.",() => Help(24)),
                new NetShellCommand("exit","Exit from shell.",Exit)
            });
        }

        /// <summary>
        /// Initialize new instance of <see cref="NetShell"/>
        /// </summary>
        /// <param name="commands">Commands.</param>
        public NetShell(params INetShellCommand[] commands) :
            this() {
            Commands.AddRange(commands);
        }

        /// <summary>
        /// Initialize new instance of <see cref="NetShell"/>
        /// </summary>
        /// <param name="commands">Commands.</param>
        public NetShell(IEnumerable<INetShellCommand> commands) :
            this() {
            Commands.AddRange(commands);
        }

        #endregion

        #region Events

#pragma warning disable CS1591

        /// <summary>
        /// This happens before command processing.
        /// </summary>
        public event EventHandler<NetShellCancelEventArgs> CommandProcess;
        protected virtual void OnCommandProcess(NetShellCancelEventArgs args) {
            CommandProcess?.Invoke(this,args);
            if(!args.Cancel) {
                args.Cmd.Action.Invoke();
                OnCommandProcessed(new NetShellEventArgs(args.Cmd));
            }
        }

        /// <summary>
        /// This happens after command processed.
        /// </summary>
        public event EventHandler<NetShellEventArgs> CommandProcessed;
        protected virtual void OnCommandProcessed(NetShellEventArgs args) {
            CommandProcessed?.Invoke(this,args);
        }

#pragma warning restore CS1591

        #endregion

        #region Members

        /// <summary>
        /// Show help.
        /// </summary>
        /// <param name="spacecount">Whitespace count of between commands and descriptions.</param>
        public virtual void Help(int spacecount) {
            string GetWS(int count) {
                StringBuilder str = new StringBuilder();
                for(int index = 0; index < count; index++)
                    str.Append(" ");
                return str.ToString();
            }

            int maxlen = Commands.Max(x => x.Command.Length);
            maxlen = maxlen > spacecount ? maxlen + spacecount : spacecount;
            StringBuilder strb = new StringBuilder();
            for(int index = 0; index < Commands.Count; index++) {
                INetShellCommand x = Commands[index];
                strb.Append($"{x.Command}{GetWS(maxlen-x.Command.Length)}{x.Description}");
                if(index < Commands.Count-1)
                    strb.AppendLine();
            };
            Console.WriteLine(strb.ToString());
        }

        /// <summary>
        /// Exit from shell on next command.
        /// </summary>
        public virtual void Exit() {
            exit = true;
        }

        /// <summary>
        /// Returns user input by shell settings.
        /// </summary>
        public virtual string GetInput() {
            Console.Write(Prompt);
            string input = Console.ReadLine();
            if(IgnoreWhiteSpace)
                input = input.Trim();
            return input;
        }

        /// <summary>
        /// Returns matched commands by shell settings.
        /// </summary>
        /// <param name="cmd">Command sample.</param>
        public IEnumerable<INetShellCommand> GetCommands(string cmd) {
            cmd = IgnoreWhiteSpace ? cmd.Trim() : cmd;
            return
                IgnoreCase ?
                     Commands.Where(x => x.Command.ToLower() == cmd.ToLower()) :
                     Commands.Where(x => x.Command == cmd);
        }

        /// <summary>
        /// Add new command to <see cref="Commands"/>
        /// </summary>
        /// <param name="cmd">Command.</param>
        /// <param name="desc">Description of command.</param>
        /// <param name="act">Action of command.</param>
        public virtual void AddCmd(string cmd,string desc,Action act) {
            Commands.Add(new NetShellCommand(cmd,desc,act));
        }

        /// <summary>
        /// Start command loop.
        /// </summary>
        public virtual void Loop() {
            exit = false;
            do {
                PostCmd();
            } while(!exit);
        }

        /// <summary>
        /// Run a command shell entry.
        /// </summary>
        public virtual void PostCmd() {
            string input = GetInput();
            IEnumerable<INetShellCommand> commands = GetCommands(input);
            if(commands.Count() <= 0) {
                Console.WriteLine($"'{input}' not found command!");
                return;
            }
            OnCommandProcess(new NetShellCancelEventArgs(commands.First()));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Commands of shell.
        /// </summary>
        public virtual List<INetShellCommand> Commands { get; }

        /// <summary>
        /// Prompt input.
        /// </summary>
        public virtual string Prompt { get; set; } = "$";

        /// <summary>
        /// Ignore whitespace at start and end on commands.
        /// </summary>
        public virtual bool IgnoreWhiteSpace { get; set; } = true;

        /// <summary>
        /// Ignore case on commands.
        /// </summary>
        public virtual bool IgnoreCase { get; set; } = default;

        #endregion
    }

    #region EventArgs

    /// <summary>
    /// Event arguments for <see cref="NetShell"/>.
    /// </summary>
    public class NetShellEventArgs:EventArgs {
        #region Constructors

        /// <summary>
        /// Initialize new instance of <see cref="NetShellEventArgs"/>
        /// </summary>
        /// <param name="cmd"><see cref="INetShellCommand"/> of event.</param>
        public NetShellEventArgs(INetShellCommand cmd) {
            Cmd = cmd;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Command of event.
        /// </summary>
        public virtual INetShellCommand Cmd { get; protected set; }

        #endregion
    }

    /// <summary>
    /// Cancel event arguments for <see cref="NetShell"/>.
    /// </summary>
    public class NetShellCancelEventArgs:EventArgs {
        #region Constructors

        /// <summary>
        /// Initialize new instance of <see cref="NetShellCancelEventArgs"/>
        /// </summary>
        /// <param name="cmd"><see cref="INetShellCommand"/> of event.</param>
        public NetShellCancelEventArgs(INetShellCommand cmd) {
            Cmd = cmd;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Command of event.
        /// </summary>
        public virtual INetShellCommand Cmd { get; set; }

        /// <summary>
        /// Cancel state of process.
        /// </summary>
        public virtual bool Cancel { get; set; }

        #endregion
    }

    #endregion
}
