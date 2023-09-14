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
        private IFileSystem _fileSystem;
        #endregion
        #region Constructors
        /// <summary>
        /// Return UnicodeFileToHtmlTextConverter Instance
        /// </summary>
        /// <param name="fullFilenameWithPath">Full unicode file path that need to convert to HTML text</param>
        public UnicodeFileToHtmlTextConverter(IFileSystem file)// : this(new FileSystem(), string.Empty)
        {
            this._fileSystem = file;
        }
        #endregion
        #region Public Methods 
        /// <inheritdoc/>
        public string ConvertToHtml(string fullFilePath)
        {
            using (TextReader unicodeFileStream = this._fileSystem.File.OpenText(fullFilePath))
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
