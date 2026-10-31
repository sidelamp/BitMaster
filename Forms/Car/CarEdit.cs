using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BitMaster.Helpers;

namespace BitMaster.Forms.Car
{
    public partial class CarEdit : Form
    {
        public readonly int carId = -1;

        public CarEdit(int carId) : this()
        {
            this.carId = carId;
        }

        public CarEdit()
        {
            InitializeComponent();

            this.FillTextFields();
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
