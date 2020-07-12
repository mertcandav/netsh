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

namespace NetSh {
    /// <summary>
    /// NetShell, shell tool.
    /// </summary>
    public class NetShell {
        #region Constructors

        /// <summary>
        /// Initialize new instance of <see cref="NetShell"/>
        /// </summary>
        public NetShell() {
            Commands = new List<INetShellCommand>();
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
        /// Add new command to <see cref="Commands"/>
        /// </summary>
        /// <param name="cmd">Command.</param>
        /// <param name="desc">Description of command.</param>
        /// <param name="act">Action of command.</param>
        public void AddCmd(string cmd,string desc,Action act) {
            Commands.Add(new NetShellCommand(cmd,desc,act));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Commands of shell.
        /// </summary>
        public virtual List<INetShellCommand> Commands { get; }

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
