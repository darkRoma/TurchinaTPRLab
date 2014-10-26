using System.Drawing;
using System.Windows.Forms;
using DecisionTheory.Core.MVCModel;
using DecisionTheory.Core.Service.Criterions;

namespace DecisionTheory.Core.MVCView.Table
{
    /// <summary>
    /// This concrete view describes solution view
    /// </summary>
    public class SolutionView : TableView
    {
        private Solution solution;

        private const string TITLE = "Решение";        

        /// <summary>
        /// Constructor that sets parent control where this view is located and default title
        /// </summary>
        /// <param name="parent">control where this table will be shown</param>
        public SolutionView(Control parent)
            : base(parent, TITLE)
        {

            var menu = new ContextMenuStrip();

            var factory = CriterionFactory.getFactory();
            foreach (var instance in factory)
            {
                var criterion = instance;
                menu.Items.Add(criterion.getName(), null, delegate
                {
                    var model = getModel();
                    solution = criterion.makeDecision(model);
                    update();
                });
            }

            menu.Items.Add("очистить решение", null, delegate
            {
                this.solution = null;
                update();
            });

            var table = getTable();
            table.ContextMenuStrip = menu;
        }

        /// <summary>
        /// This method fills table from data model and shows it
        /// </summary>
        protected override void draw()
        {
            base.draw();
            highlightBestDecision();
        }

        private void highlightBestDecision()
        {
            var table = getTable();
            if (solution != null)
            {
                var id = solution.getBestId();
                table.Rows[id].DefaultCellStyle.BackColor = Color.Green;
                solution = null;
            }
        }

        /// <summary>
        /// This method fills data source row by row according to the data model
        /// </summary>
        /// <param name="source">data source</param>
        protected override void fillData(ref System.Data.DataTable source)
        {
            if (solution != null)
            {
                int id = 0;
                foreach (var item in solution)
                {
                    var row = source.NewRow();
                    row["decision"] = "A" + (id+1);
                    if (solution.isActive(id++))
                        row["value"] = item;
                    else
                        row["value"] = "";
                    source.Rows.Add(row);
                }
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
            get { return "decision@value".Split('@'); }
        }

        /// <summary>
        /// Shown columns' names
        /// </summary>
        protected override string[] ColumnsName
        {
            get { return "решение@значение".Split('@'); }
        }
    }
}
