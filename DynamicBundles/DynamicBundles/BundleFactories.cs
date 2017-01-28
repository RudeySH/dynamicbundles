using System.Collections.Generic;
using System.Web.Optimization;

namespace DynamicBundles
{
    public class BundleFactories
    {
        private readonly Dictionary<string, string[]> _log;

        public BundleFactories()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="log">
        /// A record of all bundle paths and the files in each bundle will be kept here.
        /// </param>
        public BundleFactories(Dictionary<string, string[]> log)
        {
            _log = log;
        }

        /// <summary>
        /// Creates a script bundle with the given path (= name) and files
        /// </summary>
        public ScriptBundle ScriptBundleFactory(string bundleVirtualPath, string[] fileRootRelativePaths)
        {
            return BundleWithPaths(new ScriptBundle(bundleVirtualPath), fileRootRelativePaths);
        }

        /// <summary>
        /// Creates a style bundle with the given path (= name) and files
        /// </summary>
        public StyleBundle StyleBundleFactory(string bundleVirtualPath, string[] fileRootRelativePaths)
        {
            return BundleWithPaths(new StyleBundle(bundleVirtualPath), fileRootRelativePaths, new CssRewriteUrlTransform());
        }

        private T BundleWithPaths<T>(T bundle, string[] fileRootRelativePaths, params IItemTransform[] transforms) where T: Bundle
        {
            for (var i = 0; i < fileRootRelativePaths.Length; i++)
            {
                bundle.Include(fileRootRelativePaths[i], transforms);
            }

            if (_log != null)
            {
                _log[bundle.Path] = fileRootRelativePaths;
            }

            return bundle;
        }
    }
}
