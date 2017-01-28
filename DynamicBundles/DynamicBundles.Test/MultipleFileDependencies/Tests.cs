using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicBundles.Test.MultipleFileDependencies
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MultipleFileDependencies()
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
                    "~/Views/Account/AccountDetailsAssets/AccountDetailsAssets.js"
                }
            };

            string[][] expectedStyleFiles =
            {
                new [] {
                    "~/Views/Shared/_LayoutContainer/Site.css",
                    "~/Views/Shared/_Layout/_Layout.css"
                },
                new[] {
                    "~/Views/Shared/DetailsAssets/DetailsAssets.css"
                },
                new[] {
                    "~/Views/Account/AccountDetailsAssets/AccountDetailsAssets.css"
                }
            };

            Tester.Test("MultipleFileDependencies",
                        assetDirs,
                        expectedScriptFiles,
                        expectedStyleFiles);
        }
    }
}
