namespace Windows.Core.Forms.Wizard
{
    public interface IDataModelBind
    {
        void BindDataModel(IDataModel dataModel);
        void UnbindDataModel();
    }
}