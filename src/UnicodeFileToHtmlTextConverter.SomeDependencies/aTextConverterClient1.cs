using TDDMicroExercises.UnicodeFileToHtmlTextConverter.Interfaces;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter.SomeDependencies
{
    public class aTextConverterClient1
    {
        // A class with the only goal of simulating a dependency on UnicodeFileToHtmTextConverter
        // that has impact on the refactoring.

        public aTextConverterClient1()
        {
            var filename = "aFilename.txt";
            var textConverter = DependencyResolver.Instance.Resolve<IUnicodeFileToHtmlTextConverter>();
            var html = textConverter.ConvertToHtml(filename);
        }
    }
}
