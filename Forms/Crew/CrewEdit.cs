using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitMaster.Forms.Crew
{
    public partial class CrewEdit : Form
    {
        public readonly int carId = -1;

        public CrewEdit(int carId) : this()
        {
            this.carId = carId;
        }

        public CrewEdit()
        {
            InitializeComponent();
        }

        private void FillTextFields()
        {
            // read data base and fill all text fields
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // check text fields and write in data base and if successfull close form, else show warning
        }
    }
}
