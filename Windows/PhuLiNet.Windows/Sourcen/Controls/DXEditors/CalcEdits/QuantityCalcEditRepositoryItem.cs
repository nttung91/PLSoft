using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;

namespace Windows.Core.Controls.DXEditors.CalcEdits
{
    [ToolboxItem(false)]
    //The attribute that points to the registration method
    [UserRepositoryItem("RegisterQuantityCalcEdit")]
    public class QuantityCalcEditRepositoryItem : RepositoryItemCalcEdit
    {
        #region Custom Properties

        private string _defaultUnitOfMeasure = "STK";
        private int _defaultDecimalDigits = 3;

        [Browsable(true)]
        public string DefaultUnitOfMeasure
        {
            get { return _defaultUnitOfMeasure; }
            set { _defaultUnitOfMeasure = value; }
        }

        [Browsable(true)]
        public int DefaultDecimalDigits
        {
            get { return _defaultDecimalDigits; }
            set { _defaultDecimalDigits = value; }
        }

        #endregion

        //The static constructor which calls the registration method
        static QuantityCalcEditRepositoryItem()
        {
            RegisterQuantityCalcEdit();
        }

        //Initialize new properties
        public QuantityCalcEditRepositoryItem()
        {
        }

        //The unique name for the custom editor
        public const string CustomEditName = "QuantityCalcEdit";

        //Return the unique name
        public override string EditorTypeName
        {
            get { return CustomEditName; }
        }

        //Register the editor
        public static void RegisterQuantityCalcEdit()
        {
            //Icon representing the editor within a container editor's Designer
            var bitmap =
                new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("Windows.Core.ManorIcon.bmp"));

            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName,
                typeof (QuantityCalcEdit), typeof (QuantityCalcEditRepositoryItem),
                typeof (CalcEditViewInfo), new ButtonEditPainter(), true, bitmap));
        }

        //Override the Assign method
        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                var source = item as QuantityCalcEditRepositoryItem;
                if (source == null) return;
                _defaultUnitOfMeasure = source.DefaultUnitOfMeasure;
                _defaultDecimalDigits = source.DefaultDecimalDigits;
            }
            finally
            {
                EndUpdate();
            }
        }
    }
}