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
    /// Function sample of <see cref="NetShell"/>.
    /// </summary>
    public class NetShellAction {
        private Action action;

        #region Constructors

        /// <summary>
        /// Initialize new instance of <see cref="NetShellAction"/>.
        /// </summary>
        public NetShellAction() {

        }

        /// <summary>
        /// Initialize new instance of <see cref="NetShellAction"/>.
        /// </summary>
        /// <param name="action">Action of function.</param>
        public NetShellAction(Action action) {
            SetAction(action);
        }

        #endregion

        #region Operators

        /// <summary>
        /// Parse implicit <see cref="Action"/> to <see cref="NetShellAction"/>.
        /// </summary>
        /// <param name="func">Action.</param>
        public static implicit operator NetShellAction(Action func) {
            return new NetShellAction(func);
        }

        /// <summary>
        /// Parse implicit <see cref="NetShellAction"/> to <see cref="Action"/>.
        /// </summary>
        /// <param name="func">Action.</param>
        public static implicit operator Action(NetShellAction func) {
            return func.action;
        }

        #endregion

        #region Members

        /// <summary>
        /// Returns action of this <see cref="NetShellAction"/>.
        /// </summary>
        public Action GetAction() {
            return action;
        }

        /// <summary>
        /// Set action of this <see cref="NetShellAction"/>.
        /// </summary>
        /// <param name="action">Action to set.</param>
        public void SetAction(Action action) {
            this.action = action;
        }

        #endregion
    }
}
