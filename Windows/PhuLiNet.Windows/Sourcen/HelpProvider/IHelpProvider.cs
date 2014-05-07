using Windows.Core.BaseForms;

namespace Windows.Core.HelpProvider
{
    public interface IHelpProvider
    {
        void ShowHelp(IHelpOnForm help);
    }
}