using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitMaster.Forms
{
    public partial class CarList : Form
    {
        public CarList()
        {
            InitializeComponent();
        }

        private void SaveCarListButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
