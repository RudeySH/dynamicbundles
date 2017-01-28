using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicBundles.Test.DependenciesInController
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DependenciesInController()
        {
            string[] assetDirs =
            new [] {
                "~/Views/Account/Details",
                "~/Views/Shared/_Layout",
                "~/Views/Shared/_LayoutContainer"
            };

            string[][] expectedScriptFiles =
            {
                new[] {
                    "~/Views/Shared/_LayoutContainer/jquery-1.8.2.js"
                },
                new[] {
                    "~/Views/Account/AccountDetailsAssets.js"
                }
            };

            string[][] expectedStyleFiles =
            {
                new [] {
                    "~/Views/Shared/_LayoutContainer/Site.css",
                    "~/Views/Shared/_Layout/_Layout.css"
                },
                new[] {
                    "~/Views/Account/AccountDetailsAssets.css"
                }
            };

            Tester.Test("DependenciesInController",
                        assetDirs,
                        expectedScriptFiles,
                        expectedStyleFiles);
        }
    }
}
