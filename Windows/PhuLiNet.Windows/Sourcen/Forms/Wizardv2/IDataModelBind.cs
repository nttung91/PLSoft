namespace Windows.Core.Forms.Wizardv2
{
    public interface IDataModelBind
    {
        void BindDataModel(IDataModel dataModel);
        void UnbindDataModel();
    }
}