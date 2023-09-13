using System.IO;
using System.IO.Abstractions;
using System.Text;
using System.Web;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter.Interfaces;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class UnicodeFileToHtmlTextConverter : IUnicodeFileToHtmlTextConverter
    {
        #region Private Members
        private readonly string _fullFilenameWithPath;
        private IFileSystem _fileSystem;
        #endregion
        #region Constructors
        /// <summary>
        /// Return UnicodeFileToHtmlTextConverter Instance
        /// </summary>
        /// <param name="file">IFileSystem Instance</param>
        /// <param name="fullFilenameWithPath">Full unicode file path that need to convert to HTML text</param>
        public UnicodeFileToHtmlTextConverter(IFileSystem file, string fullFilenameWithPath)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
            _fileSystem = file;
        }
        /// <summary>
        /// Return UnicodeFileToHtmlTextConverter Instance
        /// </summary>
        /// <param name="fullFilenameWithPath">Full unicode file path that need to convert to HTML text</param>
        public UnicodeFileToHtmlTextConverter(string fullFilenameWithPath) : this(new FileSystem(), fullFilenameWithPath)
        {
        }
        #endregion
        #region Public Methods 
        /// <inheritdoc/>
        public string ConvertToHtml()
        {
            using (TextReader unicodeFileStream = this._fileSystem.File.OpenText(_fullFilenameWithPath))
            {
                StringBuilder html = new StringBuilder();

                string line = unicodeFileStream.ReadLine();
                while (line != null)
                {
                    html.AppendFormat("{0}<br />", HttpUtility.HtmlEncode(line));
                    line = unicodeFileStream.ReadLine();
                }

                return html.ToString();
            }
        }
        #endregion
        #region IDisposable Methods

        public void Dispose()
        {
            this._fileSystem = null;
        }
        #endregion
    }
}
