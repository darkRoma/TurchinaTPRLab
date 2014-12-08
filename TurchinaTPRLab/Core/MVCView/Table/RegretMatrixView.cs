using System.Windows.Forms;
using DecisionTheory.Core.MVCModel;
using DecisionTheory.Core.Service;

namespace DecisionTheory.Core.MVCView.Table
{
    /// <summary>
    /// This concrete view describes a regret matrix table
    /// </summary>
    public class RegretMatrixView : DataMatrixView
    {
        private const string TOKEN = "Матрица сожалений";

        /// <summary>
        /// Constructor that sets parent control where this view is located and default title
        /// </summary>
        /// <param name="parent">control where this table will be shown</param>
        public RegretMatrixView(Control parent)
            : base(parent, TOKEN) { }

        public override void setModel(Model model)
        {
            var regret = ModelConverter.convert(model);
            base.setModel(regret);
        }
    }
}
