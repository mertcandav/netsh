namespace NetSh {
    /// <summary>
    /// Command for NetShell.
    /// </summary>
    public struct NetShellCommand:INetShellCommand {
        #region Constructors

        /// <summary>
        /// Initialize new instance of <see cref="NetShellCommand"/>
        /// </summary>
        /// <param name="cmd">Command.</param>
        public NetShellCommand(string cmd) {
            Command = cmd;
            Description = string.Empty;
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

        #endregion

        #region Properties

        /// <summary>
        /// Command.
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// Description of command.
        /// </summary>
        public string Description { get; set; }

        #endregion
    }
}
