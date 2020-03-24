using System;
using System.Windows.Forms;

namespace ConvORMTest
{
    public partial class VUserSearch : Form
    {
        public VUserSearch()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            VUserRegister userRegister = new VUserRegister();
            userRegister.ShowDialog();
        }
    }
}
