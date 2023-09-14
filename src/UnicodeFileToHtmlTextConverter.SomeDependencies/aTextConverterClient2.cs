using TDDMicroExercises.UnicodeFileToHtmlTextConverter.Interfaces;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter.SomeDependencies
{
    public class aTextConverterClient2
    {
        // A class with the only goal of simulating a dependency on UnicodeFileToHtmTextConverter
        // that has impact on the refactoring.


        IUnicodeFileToHtmlTextConverter _textConverter;

        public aTextConverterClient2()
        {
            _textConverter = DependencyResolver.Instance.Resolve<IUnicodeFileToHtmlTextConverter>();

            var html = _textConverter.ConvertToHtml("anotherFilename.txt");
        }

    }
}
