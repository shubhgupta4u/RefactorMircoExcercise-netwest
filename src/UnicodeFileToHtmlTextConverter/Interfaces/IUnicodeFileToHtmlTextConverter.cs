﻿namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter.Interfaces
{
    /// <summary>
    /// Contain implementation to convert unicode text from file to HTML text
    /// </summary>
    public interface IUnicodeFileToHtmlTextConverter
    {
        /// <summary>
        /// Convert unicode text from file to HTML text
        /// </summary>
        /// <param name="fullFilePath">Full unicode file path that need to convert to HTML text</param>
        /// <returns>Converted HTML Text</returns>
        string ConvertToHtml(string fullFilePath);
    }
}
