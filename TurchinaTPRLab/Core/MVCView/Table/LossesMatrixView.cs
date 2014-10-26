using System.Windows.Forms;
using DecisionTheory.Core.Error;
using DecisionTheory.Core.MVCController;

namespace DecisionTheory.Core.MVCView.Table
{
    /// <summary>
    /// This concrete view describes a losses matrix table
    /// </summary>
    public class LossesMatrixView : DataMatrixView
    {
        private const string TOKEN = "матрица потерь";
        /// <summary>
        /// Constructor that sets parent control where this view is located and default title
        /// </summary>
        /// <param name="parent">control where this table will be shown</param>
        public LossesMatrixView(Control parent, Controller controller)
            : base(parent, TOKEN)
        {
            var table = getTable();

            table.ReadOnly = false;
            table.AllowUserToAddRows = true;
            table.AllowUserToDeleteRows = true;

            table.CellValueChanged += delegate(object sender, DataGridViewCellEventArgs args)
            {
                var i = args.RowIndex;
                var j = args.ColumnIndex;
                if (i >= 0 && i < table.RowCount && j >= 0 && j < table.ColumnCount)
                {
                    var str = table.Rows[i].Cells[j].Value.ToString();
                    var value = 0.0;
                    if (!double.TryParse(str, out value))
                        throw new ConvertException();
                    getModel().setData(i, j - 1, value);
                    controller.update();
                }
            };
        }
    }
}
