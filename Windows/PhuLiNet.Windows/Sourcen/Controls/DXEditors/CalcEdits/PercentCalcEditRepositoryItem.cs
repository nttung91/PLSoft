using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;

namespace Windows.Core.Controls.DXEditors.CalcEdits
{
    [ToolboxItem(true)]
    //The attribute that points to the registration method
    [UserRepositoryItem("RegisterPercentCalcEdit")]
    public class PercentCalcEditRepositoryItem : RepositoryItemCalcEdit
    {
        #region Custom Properties

        private int _defaultDecimalDigits = 2;

        [Browsable(true)]
        public int DefaultDecimalDigits
        {
            get { return _defaultDecimalDigits; }
            set { _defaultDecimalDigits = value; }
        }

        [Browsable(true)]
        public string DefaultSuffix { get; set; }

        #endregion

        //The static constructor which calls the registration method
        static PercentCalcEditRepositoryItem()
        {
            RegisterPercentCalcEdit();
        }

        //The unique name for the custom editor
        public const string CustomEditName = "PercentCalcEdit";

        //Return the unique name
        public override string EditorTypeName
        {
            get { return CustomEditName; }
        }

        //Register the editor
        public static void RegisterPercentCalcEdit()
        {
            //Icon representing the editor within a container editor's Designer
            var bitmap =
                new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("Windows.Core.ManorIcon.bmp"));

            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName,
                typeof (PercentCalcEdit), typeof (PercentCalcEditRepositoryItem),
                typeof (CalcEditViewInfo), new ButtonEditPainter(), true, bitmap));
        }

        //Override the Assign method
        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                var source = item as PercentCalcEditRepositoryItem;
                if (source == null) return;
                _defaultDecimalDigits = source.DefaultDecimalDigits;
            }
            finally
            {
                EndUpdate();
            }
        }
    }
}