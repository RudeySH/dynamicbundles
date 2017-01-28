using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;

namespace DynamicBundles
{
    public class NuspecFile
    {
#region classes

        /// <remarks/>
        [XmlTypeAttribute(AnonymousType = true)]
        [XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class package
        {

            private packageMetadata metadataField;

            private packageFile[] filesField;

            /// <remarks/>
            public packageMetadata metadata
            {
                get
                {
                    return metadataField;
                }
                set
                {
                    metadataField = value;
                }
            }

            /// <remarks/>
            [XmlArrayItemAttribute("file", IsNullable = false)]
            public packageFile[] files
            {
                get
                {
                    return filesField;
                }
                set
                {
                    filesField = value;
                }
            }
        }

        /// <remarks/>
        [XmlTypeAttribute(AnonymousType = true)]
        public partial class packageMetadata
        {

            private string idField;

            private string versionField;

            private string titleField;

            private string authorsField;

            private string ownersField;

            private string projectUrlField;

            private string iconUrlField;

            private bool requireLicenseAcceptanceField;

            private string descriptionField;

            private string copyrightField;

            private string tagsField;

            private packageMetadataDependency[] dependenciesField;

            /// <remarks/>
            public string id
            {
                get
                {
                    return idField;
                }
                set
                {
                    idField = value;
                }
            }

            /// <remarks/>
            public string version
            {
                get
                {
                    return versionField;
                }
                set
                {
                    versionField = value;
                }
            }

            /// <remarks/>
            public string title
            {
                get
                {
                    return titleField;
                }
                set
                {
                    titleField = value;
                }
            }

            /// <remarks/>
            public string authors
            {
                get
                {
                    return authorsField;
                }
                set
                {
                    authorsField = value;
                }
            }

            /// <remarks/>
            public string owners
            {
                get
                {
                    return ownersField;
                }
                set
                {
                    ownersField = value;
                }
            }

            /// <remarks/>
            public string projectUrl
            {
                get
                {
                    return projectUrlField;
                }
                set
                {
                    projectUrlField = value;
                }
            }

            /// <remarks/>
            public string iconUrl
            {
                get
                {
                    return iconUrlField;
                }
                set
                {
                    iconUrlField = value;
                }
            }

            /// <remarks/>
            public bool requireLicenseAcceptance
            {
                get
                {
                    return requireLicenseAcceptanceField;
                }
                set
                {
                    requireLicenseAcceptanceField = value;
                }
            }

            /// <remarks/>
            public string description
            {
                get
                {
                    return descriptionField;
                }
                set
                {
                    descriptionField = value;
                }
            }

            /// <remarks/>
            public string copyright
            {
                get
                {
                    return copyrightField;
                }
                set
                {
                    copyrightField = value;
                }
            }

            /// <remarks/>
            public string tags
            {
                get
                {
                    return tagsField;
                }
                set
                {
                    tagsField = value;
                }
            }

            /// <remarks/>
            [XmlArrayItemAttribute("dependency", IsNullable = false)]
            public packageMetadataDependency[] dependencies
            {
                get
                {
                    return dependenciesField;
                }
                set
                {
                    dependenciesField = value;
                }
            }
        }

        /// <remarks/>
        [XmlTypeAttribute(AnonymousType = true)]
        public partial class packageMetadataDependency
        {

            private string idField;

            private string versionField;

            /// <remarks/>
            [XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return idField;
                }
                set
                {
                    idField = value;
                }
            }

            /// <remarks/>
            [XmlAttributeAttribute()]
            public string version
            {
                get
                {
                    return versionField;
                }
                set
                {
                    versionField = value;
                }
            }
        }

        /// <remarks/>
        [XmlTypeAttribute(AnonymousType = true)]
        public partial class packageFile
        {

            private string srcField;

            private string targetField;

            /// <remarks/>
            [XmlAttributeAttribute()]
            public string src
            {
                get
                {
                    return srcField;
                }
                set
                {
                    srcField = value;
                }
            }

            /// <remarks/>
            [XmlAttributeAttribute()]
            public string target
            {
                get
                {
                    return targetField;
                }
                set
                {
                    targetField = value;
                }
            }
        }
#endregion

        private readonly package _package;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="absolutePath">
        /// Absolute path of the Nuspec file.
        /// </param>
        public NuspecFile(string absolutePath)
        {
            using (TextReader reader = new StreamReader(absolutePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(package));
                _package = (package)serializer.Deserialize(reader);
            }
        }

        public static bool IsNuspecFile(string absolutePath)
        {
            string extension = Path.GetExtension(absolutePath);
            return (string.CompareOrdinal(extension, ".nuspec") == 0);
        }

        /// <summary>
        /// Returns the ids of the dependencies in the nuspec file.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> DependencyIds
        {
            get
            {
                if ((_package.metadata == null) || (_package.metadata.dependencies == null)) { return new List<string>(); }

                return _package.metadata.dependencies.Select(d => d.id);
            }
        }
    }
}
