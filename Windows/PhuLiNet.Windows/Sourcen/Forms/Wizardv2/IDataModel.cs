namespace Windows.Core.Forms.Wizardv2
{
    public interface IDataModel
    {
        void Init();
        void Save();
        void Cancel();
        WizardActions WizardAction { get; }

        /// <summary>
        /// CSLA root object to edit/display in the wizard pages
        /// </summary>
        /// <returns></returns>
        object GetRootObject();

        bool IsValid { get; }
        bool IsDirty { get; }
        object GetIdValue();
    }

    public enum WizardActions
    {
        Saved,
        Cancelled,
        Unknown
    }
}