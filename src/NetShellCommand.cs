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

namespace NetSh {
    /// <summary>
    /// Command sample of <see cref="NetShell"/>.
    /// </summary>
    public class NetShellCommand:INetShellCommand {
        #region Constructors

        /// <summary>
        /// Initialize new instance of <see cref="NetShellCommand"/>
        /// </summary>
        /// <param name="cmd">Command.</param>
        public NetShellCommand(string cmd) {
            Command = cmd;
        }

        /// <summary>
        /// Initialize new instance of <see cref="NetShellCommand"/>
        /// </summary>
        /// <param name="cmd">Command.</param>
        /// <param name="desc">Description.</param>
        public NetShellCommand(string cmd,string desc) :
            this(cmd) {
            Description = desc;
        }

        /// <summary>
        /// Initialize new instance of <see cref="NetShellCommand"/>
        /// </summary>
        /// <param name="cmd">Command.</param>
        /// <param name="desc">Description.</param>
        /// <param name="act">Action.</param>
        public NetShellCommand(string cmd,string desc,Action act) :
            this(cmd,desc) {
            Action = act;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Command.
        /// </summary>
        public virtual string Command { get; set; }

        /// <summary>
        /// Description of command.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Action of command.
        /// </summary>
        public virtual Action Action { get; set; }

        #endregion
    }
}
