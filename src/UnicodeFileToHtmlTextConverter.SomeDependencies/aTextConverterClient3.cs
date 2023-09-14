using TDDMicroExercises.UnicodeFileToHtmlTextConverter.Interfaces;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter.SomeDependencies
{
    public class aTextConverterClient3
    {
        // A class with the only goal of simulating a dependency on UnicodeFileToHtmTextConverter
        // that has impact on the refactoring.

        public aTextConverterClient3()
        {
            object[] args = { "jetAnotherFilename.txt" };
            dynamic x = DependencyResolver.Instance.Resolve<IUnicodeFileToHtmlTextConverter>();

            string html = x.ConvertToHtml(args[0]);

        }
    }
}
