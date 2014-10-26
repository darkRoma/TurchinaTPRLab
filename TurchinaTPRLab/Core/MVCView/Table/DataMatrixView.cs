using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DecisionTheory.Core.MVCView.Table
{
    /// <summary>
    /// This concrete view describes a data matrix table
    /// </summary>
    public class DataMatrixView : TableView
    {
        private string[] columnsId;
        private string[] columnsName;

        /// <summary>
        /// Constructor that sets parent control where this view is located and title
        /// </summary>
        /// <param name="parent">control where this table will be shown</param>
        public DataMatrixView(Control parent, string name) : base(parent, name) { }

        /// <summary>
        /// This method fills columns according to model states count
        /// </summary>
        /// <returns>columns' mapping for ids and names</returns>
        protected override IDictionary<string, string> fillColumns()
        {
            var model = getModel();
            int cols = model.getStatesCount();
            columnsId = new string[cols + 1];
            columnsName = new string[cols + 1];
            columnsId[0] = "decision";
            columnsName[0] = "решение\\состояние";
            for (int i = 1; i <= cols; ++i)
            {
                columnsId[i] = "" + i;
                columnsName[i] = "B" + i;
            }
            return base.fillColumns();
        }

        /// <summary>
        /// This method fills data source row by row according to the data model
        /// </summary>
        /// <param name="source">data source</param>
        protected override void fillData(ref DataTable source)
        {
            var model = getModel();
            var rows = model.getDecisionsCount();
            var cols = model.getStatesCount();


            for (int i = 0; i < rows; ++i)
            {
                var row = source.NewRow();
                row["decision"] = "A" + (i + 1);
                for (int j = 0; j < cols; ++j)
                    row["" + (j + 1)] = model.getData(i, j);
                source.Rows.Add(row);
            }
        }

        /// <summary>
        /// Column's id that represents row header cells
        /// </summary>
        /// 
        protected override string ColumnRowHeaderId
        {
            get { return "decision"; }
        }

        /// <summary>
        /// Columns' ids that are using for data filling
        /// </summary>
        protected override string[] ColumnsId
        {
            get { return columnsId; }
        }

        /// <summary>
        /// Shown columns' names
        /// </summary>
        protected override string[] ColumnsName
        {
            get { return columnsName; }
        }
    }
}
