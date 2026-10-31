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
    public partial class EditCar : Form
    {
        public EditCar()
        {
            InitializeComponent();

            btnSave.Image = ImageHelper.Scale(Properties.Resources.SaveIcon, 20, 20);
            btnDelete.Image = ImageHelper.Scale(Properties.Resources.DeleteIcon, 20, 20);
        }
    }
}
