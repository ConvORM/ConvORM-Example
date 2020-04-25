using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using ConvORM.Connection.Helpers;
using ConvORMTest.Entities;

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
            var userRegister = new VUserRegister();
            userRegister.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var userEntity = new UserEntity();

            dgvRegisters.DataSource = ConvOrmHelper.ConvertListToDataTable(userEntity.GetAll());
            dgvRegisters.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }
}
