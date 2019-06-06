/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IMultilingual.cs
 *  Description  :  Interface for multilingualism.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Common.Multilingualism
{
    /// <summary>
    /// Interface for multilingualism.
    /// </summary>
    public interface IMultilingual
    {
        #region Method
        /// <summary>
        /// Initialize the directory of multilingualism files.
        /// </summary>
        /// <param name="directory">The directory of multilingualism files.</param>
        void Initialize(string directory);

        /// <summary>
        /// Set language by name.
        /// </summary>
        /// <param name="name">Name of language (Config in the LanguageSettings).</param>
        /// <returns>Set language succeed?</returns>
        void SetLanguage(string name);

        /// <summary>
        /// Get a paragraph text of key in language.
        /// </summary>
        /// <param name="key">Key of paragraph text.</param>
        /// <returns>A paragraph text of key in language.</returns>
        string GetParagraph(string key);
        #endregion
    }
}