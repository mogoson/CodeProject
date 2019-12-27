/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MultilingualUtility.cs
 *  Description  :  Utility for multilingualism.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.DesignPattern;
using MGS.Common.IO;
using MGS.Common.Logger;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MGS.Common.Utility
{
    /// <summary>
    /// Utility for multilingualism.
    /// </summary>
    public sealed class MultilingualUtility : Singleton<MultilingualUtility>
    {
        #region Field and Property
        /// <summary>
        /// Separator of paragraph key and value.
        /// </summary>
        public static readonly char[] SEPARATOR = new char[] { '=' };

        /// <summary>
        /// Current language name.
        /// </summary>
        public string Current { private set; get; }

        /// <summary>
        /// Languages content list.
        /// </summary>
        private Dictionary<string, Dictionary<string, string>> languages = new Dictionary<string, Dictionary<string, string>>();

        /// <summary>
        /// The directory of multilingualism files.
        /// </summary>
        private string directory;
        #endregion

        #region Private Method
        /// <summary>
        /// Constructor.
        /// </summary>
        private MultilingualUtility() { }
        #endregion

        #region Public Method
        /// <summary>
        /// Initialize the directory of multilingualism files.
        /// </summary>
        /// <param name="directory">The directory of multilingualism files.</param>
        public void Initialize(string directory)
        {
            this.directory = directory;
        }

        /// <summary>
        /// Set language by name.
        /// </summary>
        /// <param name="name">Name of language.</param>
        /// <returns>Set language succeed?</returns>
        public void SetLanguage(string name)
        {
            if (string.IsNullOrEmpty(directory))
            {
                LogUtility.LogError("Set language error: The directory of multilingualism files is empty.");
                return;
            }

            if (!Directory.Exists(directory))
            {
                LogUtility.LogError("Set language error: Can not find the directory of multilingualism files at path {0}", directory);
                return;
            }

            var languageFile = string.Format("{0}/{1}.txt", directory, name);
            if (!File.Exists(languageFile))
            {
                LogUtility.LogError("Set language error: Can not find the language file at path {0}", languageFile);
                return;
            }

            var fileLines = FileUtility.ReadAllLines(languageFile, Encoding.Default);
            if (fileLines == null || fileLines.Length == 0)
            {
                LogUtility.LogError("Set language error: Can not read any content in the language file at path {0}", languageFile);
                return;
            }

            //Remove origin language content.
            if (languages.ContainsKey(name))
            {
                languages.Remove(name);
            }

            languages.Add(name, new Dictionary<string, string>());
            foreach (var line in fileLines)
            {
                if (string.IsNullOrEmpty(line.Trim()))
                {
                    continue;
                }

                var contents = line.Split(SEPARATOR, 2, System.StringSplitOptions.RemoveEmptyEntries);
                if (contents.Length < 2)
                {
                    continue;
                }
                languages[name].Add(contents[0], contents[1]);
            }
            Current = name;
        }

        /// <summary>
        /// Get a paragraph text of key in language.
        /// </summary>
        /// <param name="key">Key of paragraph text.</param>
        /// <returns>A paragraph text of key in language.</returns>
        public string GetParagraph(string key)
        {
            return GetParagraph(Current, key);
        }

        /// <summary>
        /// Get a paragraph text of key in language.
        /// </summary>
        /// <param name="language">Name of language.</param>
        /// <param name="key">Key of paragraph text.</param>
        /// <returns>A paragraph text of key in language.</returns>
        public string GetParagraph(string language, string key)
        {
            if (!languages.ContainsKey(language))
            {
                LogUtility.LogError("Get paragraph error: The language {0} is not set.", language);
                return string.Empty;
            }

            if (!languages[language].ContainsKey(key))
            {
                LogUtility.LogError("Get paragraph error: The key {0} can not find in the content of language {1}.", key, language);
                return string.Empty;
            }

            return languages[Current][key];
        }
        #endregion
    }
}