﻿namespace LibGit2Sharp
{
    /// <summary>
    /// Describe the expected tag retrieval behavior
    /// when a fetch operation is being performed.
    /// </summary>
    public enum TagFetchMode
    {
        /// <summary>
        /// Default behavior. Will automatically retrieve tags that
        /// point to objects retrieved during this fetch.
        /// </summary>
        Auto = 0,  // GIT_REMOTE_DOWNLOAD_TAGS_AUTO

        /// <summary>
        /// No tag will be retrieved.
        /// </summary>
        None,  // GIT_REMOTE_DOWNLOAD_TAGS_NONE

        /// <summary>
        /// All tags will be downloaded, but _only_ tags, along with
        /// all the objects these tags are pointing to.
        /// </summary>
        All,   // GIT_REMOTE_DOWNLOAD_TAGS_ALL
    }
}
/* This is extra153 */