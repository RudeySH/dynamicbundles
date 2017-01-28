﻿using System.Collections.Generic;
using System.Web.Optimization;

namespace DynamicBundles.Test
{
    /// <summary>
    /// Encapsulates the MVC BundleCollection. The difference is that this class
    /// implements IBundleCollection, so it can be replaced by a mock
    /// during unit testing.
    /// </summary>
    internal class TestDynamicBundleCollection : IDynamicBundleCollection
    {
        private readonly Dictionary<string, Bundle> _bundles;

        public TestDynamicBundleCollection(Dictionary<string, Bundle> bundles)
        {
            _bundles = bundles;
        }

        /// <summary>
        /// Returns true if a bundle with the passed in name exists.
        /// </summary>
        public bool Exists(string bundleName)
        {
            return (_bundles.ContainsKey(bundleName));
        }

        /// <summary>
        /// Adds the given Bundle to the bundle collection
        /// </summary>
        public void Add(Bundle bundle)
        {
            _bundles[bundle.Path] = bundle;
        }
    }
}
