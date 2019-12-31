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

namespace MGS.Multilingual
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
        public string Current
        {
            set
            {
                if (languages.ContainsKey(value))
                {
                    current = value;
                }
                else
                {
                    LogUtility.LogError("Set current language error: The language {0} is not Initialized.", value);
                }
            }
            get { return current; }
        }

        /// <summary>
        /// Current language name.
        /// </summary>
        private string current;

        /// <summary>
        /// Languages paragraphs dictionary.
        /// </summary>
        private Dictionary<string, Dictionary<string, string>> languages = new Dictionary<string, Dictionary<string, string>>();
        #endregion

        #region Private Method
        /// <summary>
        /// Constructor.
        /// </summary>
        private MultilingualUtility() { }
        #endregion

        #region Public Method
        /// <summary>
        /// Deserialize language paragraphs from local file.
        /// </summary>
        /// <param name="languageFile">File path of language content.</param>
        /// <returns>Deserialize succeed?</returns>
        public bool Deserialize(string languageFile)
        {
            if (!File.Exists(languageFile))
            {
                LogUtility.LogError("Deserialize language error: Can not find the language file at path {0}", languageFile);
                return false;
            }

            var fileLines = FileUtility.ReadAllLines(languageFile, Encoding.Default);
            if (fileLines == null || fileLines.Length == 0)
            {
                LogUtility.LogError("Deserialize language error: Can not read any content in the language file at path {0}", languageFile);
                return false;
            }

            var language = Path.GetFileNameWithoutExtension(languageFile);
            return Deserialize(language, fileLines);
        }

        /// <summary>
        /// Deserialize language paragraphs from paragraph lines.
        /// </summary>
        /// <param name="language">Name of language.</param>
        /// <param name="paragraphLines">Paragraph lines of language.</param>
        /// <returns>Deserialize succeed?</returns>
        public bool Deserialize(string language, string[] paragraphLines)
        {
            if (string.IsNullOrEmpty(language))
            {
                LogUtility.LogError("Deserialize language error: The language name is null or empty.");
                return false;
            }

            if (paragraphLines == null)
            {
                LogUtility.LogError("Deserialize language error: The paragraph lines is null.");
                return false;
            }

            if (languages.ContainsKey(language))
            {
                //Clear origin language content.
                languages[language].Clear();
            }
            else
            {
                languages.Add(language, new Dictionary<string, string>());
            }

            foreach (var line in paragraphLines)
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
                languages[language].Add(contents[0], contents[1]);
            }

            return true;
        }

        /// <summary>
        /// Get all deserialized languages.
        /// </summary>
        /// <returns>All deserialized languages.</returns>
        public string[] GetLanguages()
        {
            var languageArray = new string[languages.Keys.Count];
            languages.Keys.CopyTo(languageArray, 0);
            return languageArray;
        }

        /// <summary>
        /// Get paragraphs of target language.
        /// </summary>
        /// <param name="language">Name of language.</param>
        /// <returns>Paragraphs of target language.</returns>
        public Dictionary<string, string> GetParagraphs(string language)
        {
            if (!languages.ContainsKey(language))
            {
                LogUtility.LogError("Get GetParagraphs error: The language {0} is not Initialized.", language);
                return null;
            }

            return languages[language];
        }

        /// <summary>
        /// Get a paragraph text of key in current language.
        /// </summary>
        /// <param name="key">Key of paragraph text.</param>
        /// <returns>A paragraph text of key in current language.</returns>
        public string GetParagraph(string key)
        {
            return GetParagraph(current, key);
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
                LogUtility.LogError("Get paragraph error: The language {0} is not Initialized.", language);
                return string.Empty;
            }

            if (!languages[language].ContainsKey(key))
            {
                LogUtility.LogError("Get paragraph error: The key {0} can not find in the content of language {1}.", key, language);
                return string.Empty;
            }

            return languages[language][key];
        }

        /// <summary>
        /// Clear paragraphs of languages.
        /// </summary>
        public void ClearLanguages()
        {
            languages.Clear();
            current = string.Empty;
        }
        #endregion
    }
}