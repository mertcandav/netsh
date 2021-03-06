﻿using System;

namespace NetSh {
    /// <summary>
    /// Interface for commans of <see cref="NetShell"/>.
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

        /// <summary>
        /// Action of command.
        /// </summary>
        Action<INetShellCommand,string> Action { get; set; }

        #endregion
    }
}
