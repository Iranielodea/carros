using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carros.Geral
{
    public static class Grade
    {
        public static void Config(DataGridView grid)
        {
            grid.BackgroundColor = Color.Silver;
            grid.AllowUserToAddRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.ReadOnly = true;
            grid.AutoGenerateColumns = false;
            grid.RowsDefaultCellStyle.BackColor = Color.Bisque;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }
    }
}
