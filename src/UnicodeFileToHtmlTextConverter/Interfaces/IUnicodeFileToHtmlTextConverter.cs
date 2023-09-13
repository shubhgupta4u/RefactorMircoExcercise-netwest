namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter.Interfaces
{
    /// <summary>
    /// Contain implementation to convert unicode text from file to HTML text
    /// </summary>
    public interface IUnicodeFileToHtmlTextConverter
    {
        /// <summary>
        /// Convert unicode text from file to HTML text
        /// </summary>
        /// <returns>Converted HTML Text</returns>
        string ConvertToHtml();
    }
}
