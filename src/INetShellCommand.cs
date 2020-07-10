namespace NetSh {
    /// <summary>
    /// Interface for NetShell commands.
    /// </summary>
    public interface INetShellCommand {
        #region Properties

        /// <summary>
        /// Command.
        /// </summary>
        string Command { get; set; }

        /// <summary>
        /// Description of command.
        /// </summary>
        string Description { get; set; }

        #endregion
    }
}
