using ConvORM.Connection;
using ConvORM.Connection.Enums;
using ConvORM.Connection.Parameters;
using ConvORM.Exceptions;
using System;
using System.Windows.Forms;

namespace ConvORMTest
{
    public partial class VMain : Form
    {
        private Connection _connection;

        public VMain()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

            try 
            {

                if (ckbUseConnectionFile.Checked)
                    _connection = ConnectionFactory.GetConnection();
                else
                {
                    var connectionParameters = new ConnectionParameters("Default", GetDriverConnection(), txtHost.Text, txtPort.Text, txtUser.Text, txtPassword.Text, txtDatabase.Text);
                    _connection = ConnectionFactory.GetConnection(connectionParameters);
                }

                if (_connection.Connected)
                    lblStatus.Text = "Connected";
                else
                    lblStatus.Text = "Not Connected";
            }
            catch(ConnectionException ex)
            {
                MessageBox.Show("ErrorCode: " + ex.ErrorCode + Environment.NewLine + "Message: " + ex.Message + Environment.NewLine + "Possibles Solutions: " + Environment.NewLine + ex.PossiblesSolutions, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private EConnectionDriverTypes GetDriverConnection()
        {
            switch (cbConectionDrivers.SelectedIndex)
            {
                case 0:
                    return EConnectionDriverTypes.ecdtFirebird;
                case 1:
                    return EConnectionDriverTypes.ecdtMySql;
                case 2:
                    return EConnectionDriverTypes.ecdtPostgreeSQL;
                case 3:
                    return EConnectionDriverTypes.ecdtSQLServer;
                default:
                    return 0;
            }
        }

        private void ckbUseConnectionFile_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbUseConnectionFile.Checked)
            {
                cbConectionDrivers.Enabled = false;
                txtHost.Enabled = false;
                txtPort.Enabled = false;
                txtUser.Enabled = false;
                txtPassword.Enabled = false;
                txtDatabase.Enabled = false;
            }
            else
            {
                cbConectionDrivers.Enabled = true;
                txtHost.Enabled = true;
                txtPort.Enabled = true;
                txtUser.Enabled = true;
                txtPassword.Enabled = true;
                txtDatabase.Enabled = true;
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            var form = new VUserSearch();
            form.ShowDialog();
        }
    }
}
