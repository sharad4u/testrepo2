﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using LibGit2Sharp.Core;
using LibGit2Sharp.Core.Handles;

namespace LibGit2Sharp
{
    /// <summary>
    /// The collection of <see cref="LibGit2Sharp.IndexReucEntry"/>s in a
    /// <see cref="LibGit2Sharp.Repository"/> index that reflect the
    /// resolved conflicts.
    /// </summary>
    public class IndexReucEntryCollection : IEnumerable<IndexReucEntry>
    {
        private readonly Repository repo;

        /// <summary>
        /// Needed for mocking purposes.
        /// </summary>
        protected IndexReucEntryCollection()
        { }

        internal IndexReucEntryCollection(Repository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Gets the <see cref="IndexReucEntry"/> with the specified relative path.
        /// </summary>
        public virtual IndexReucEntry this[string path]
        {
            get
            {
                Ensure.ArgumentNotNullOrEmptyString(path, "path");

                IndexReucEntrySafeHandle entryHandle = Proxy.git_index_reuc_get_bypath(repo.Index.Handle, path);
                return IndexReucEntry.BuildFromPtr(entryHandle);
            }
        }

        private IndexReucEntry this[int index]
        {
            get
            {
                IndexReucEntrySafeHandle entryHandle = Proxy.git_index_reuc_get_byindex(repo.Index.Handle, (UIntPtr)index);
                return IndexReucEntry.BuildFromPtr(entryHandle);
            }
        }

        #region IEnumerable<IndexReucEntry> Members

        private List<IndexReucEntry> AllIndexReucs()
        {
            var list = new List<IndexReucEntry>();

            int count = Proxy.git_index_reuc_entrycount(repo.Index.Handle);

            for (int i = 0; i < count; i++)
            {
                list.Add(this[i]);
            }

            return list;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/> object that can be used to iterate through the collection.</returns>
        public virtual IEnumerator<IndexReucEntry> GetEnumerator()
        {
            return AllIndexReucs().GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
/* This is extra67 */
