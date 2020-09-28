using ConvORM.Connection.Classes;
using ConvORM.Connection.Classes.QueryBuilders;
using ConvORM.Connection.Enums;
using ConvORM.Connection.Helpers;
using ConvORMTest.Entities;
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
            var userRegister = new VUserRegister();
            userRegister.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var userEntity = new UserEntity();

            var queryConditions = new QueryConditionsBuilder();

            if (txtTextToSearch.Text != "")
            {
                queryConditions.AddQueryCondition("name", EConditionTypes.Like, new object[] {"%" + txtTextToSearch.Text + "%"});
            }

            dgvRegisters.DataSource = ConvOrmHelper.ConvertListToDataTable(userEntity.Find(queryConditions));
            dgvRegisters.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void dgvRegisters_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = btnDelete.Enabled = dgvRegisters.SelectedRows.Count > 0;
        }

        private void dgvRegisters_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRegisters.SelectedRows.Count != 0)
            {
                var userEntity = new UserEntity(); 

                var userRegister = new VUserRegister();
                userRegister.User = userEntity.Find((int)dgvRegisters.SelectedRows[0].Cells[0].Value);
                userRegister.ShowDialog();
                btnSearch.PerformClick();
            }                

        }
    }
}
