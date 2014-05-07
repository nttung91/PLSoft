namespace Windows.Core.BaseForms
{
    public interface IFormLayout
    {
        void ApplyDefaultLayout();
        void ApplySpecialLayout();
        void ApplyLayout();
        bool SpecialLayout { get; set; }
    }
}