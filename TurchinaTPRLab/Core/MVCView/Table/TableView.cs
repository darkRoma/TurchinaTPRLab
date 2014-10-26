using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DecisionTheory.Core.MVCModel;

namespace DecisionTheory.Core.MVCView.Table
{
    /// <summary>
    /// Abstract View for tables based on component DataGridView, they have title (Label) <br/>
    /// <para>Provides basic API of:</para>
    /// <para>    - data rows filling</para>
    /// <para>    - columns' ids and names setting</para>
    /// <para>        (that will be used while data filling and showing)</para>
    /// <para>    - column's id setting that represents row header cells</para>
    /// </summary>
    public abstract class TableView : View
    {
        private DataGridView table;

        /// <summary>
        /// Constructor that sets parent control and name for a table
        /// </summary>
        /// <param name="parent">control where this table will be shown</param>
        /// <param name="name">name of this table</param>
        public TableView(Control parent, string name)
            : this(parent, name, null) { }
        /// <summary>
        /// Constructor that sets parent control and name for a table and also data model field
        /// </summary>
        /// <param name="parent">control where this table will be shown</param>
        /// <param name="name">name of this table</param>
        /// <param name="model">data model</param>
        public TableView(Control parent, string name, Model model)
            : base(model)
        {
            initialize(parent, name);
        }

        /// <summary>
        /// This method fills table from data model and shows it
        /// </summary>
        protected override void draw()
        {
            var columns = fillColumns();
            var source = new DataTable();

            foreach (string column in columns.Keys)
                source.Columns.Add(column);

            fillData(ref source);
            table.DataSource = source;

            foreach (var pair in columns)
            {
                table.Columns[pair.Key].HeaderText = pair.Value;
                table.Columns[pair.Key].DefaultCellStyle = table.DefaultCellStyle;
                table.Columns[pair.Key].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            var header = ColumnRowHeaderId;
            if (columns.ContainsKey(header))
            {
                table.Columns[header].DefaultCellStyle =
                    table.RowHeadersDefaultCellStyle;
                table.Columns[header].ReadOnly = true;
            }

            table.Refresh();
        }

        /// <summary>
        /// Getter for table field
        /// </summary>
        /// <returns>component that describes a table view</returns>
        protected DataGridView getTable()
        {
            return table;
        }

        /// <summary>
        /// This method fills data source row by row according to the data model
        /// </summary>
        /// <param name="source">data source</param>
        protected abstract void fillData(ref DataTable source);

        /// <summary>
        /// Columns' ids that are using for data filling
        /// </summary>
        protected abstract string[] ColumnsId { get; }

        /// <summary>
        /// Shown columns' names
        /// </summary>
        protected abstract string[] ColumnsName { get; }

        /// <summary>
        /// Column's id that represents row header cells
        /// </summary>
        protected virtual string ColumnRowHeaderId
        {
            get { return ""; }
        }
        
        /// <summary>
        /// This method is using for mapping columns' ids and names
        /// </summary>
        /// <returns>columns' mapping for ids and names</returns>
        protected virtual IDictionary<string,string> fillColumns()
        {
            var columns = new Dictionary<string, string>();
            for (int i = 0; i < ColumnsId.Length; ++i)
                columns.Add(ColumnsId[i], ColumnsName[i]);
            return columns;
        }

        private void initialize(Control parent, string name)
        {
            table = new DataGridView()
            {
                Dock = DockStyle.Fill,
                SelectionMode = DataGridViewSelectionMode.CellSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                RowHeadersVisible = false,
                Visible = true,
                ReadOnly = true,
                MultiSelect = true,
                AllowUserToOrderColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
            };

            var panel = new TableLayoutPanel()
            {
                Visible = true,
                Dock = DockStyle.Fill
            };

            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 90));

            var title = new Label()
            {
                Visible = true,
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Text = name,
                Font = new Font(parent.Font, FontStyle.Bold)
            };

            panel.Controls.Add(title);
            panel.Controls.Add(table);
            parent.Controls.Add(panel);
        }
    }
}