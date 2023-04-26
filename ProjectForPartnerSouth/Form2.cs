using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace ProjectForPartnerSouth
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void RebootButton_Click(object sender, EventArgs e)
        {
            PasswordConnectionInfo connectionInfo = new PasswordConnectionInfo(SSH_Connect.IP_ssh_server, SSH_Connect.port_ssh_server, SSH_Connect.ssh_user, SSH_Connect.ssh_password);
            connectionInfo.Timeout = TimeSpan.FromSeconds(30);

            using (var client = new SshClient(connectionInfo))
            {
                try
                {
                    client.Connect();
                    if (client.IsConnected)
                    {
                        var cmd = client.CreateCommand("system reboot");
                        var asyncExecute = cmd.Execute();
                        var var = cmd.Result;
                        richTextBox1.Text = cmd.Result;
                        //var result = client.RunCommand("ip address add");
                        //richTextBox1.Text = result.ToString();


                       MessageBox.Show("SSH connection active");
                    }
                    else
                    {
                        MessageBox.Show("SSH connection NOTactive");
                    }
                }
                catch
                {
                    MessageBox.Show("SSH connection NOTactive2");
                }
            }
        }

        private void PrintIPAdress_Click(object sender, EventArgs e)
        {
            PasswordConnectionInfo connectionInfo = new PasswordConnectionInfo(SSH_Connect.IP_ssh_server, SSH_Connect.port_ssh_server, SSH_Connect.ssh_user, SSH_Connect.ssh_password);
            connectionInfo.Timeout = TimeSpan.FromSeconds(30);

            using (var client = new SshClient(connectionInfo))
            {
                try
                {
                    client.Connect();
                    if (client.IsConnected)
                    {
                        var cmd = client.CreateCommand("ip address print");
                        var asyncExecute = cmd.Execute();
                        var var = cmd.Result;
                        richTextBox1.Text = cmd.Result;
                        //var result = client.RunCommand("ip address add");
                        //richTextBox1.Text = result.ToString();


                        MessageBox.Show("SSH connection active");
                    }
                    else
                    {
                        MessageBox.Show("SSH connection NOTactive");
                    }
                }
                catch
                {
                    MessageBox.Show("SSH connection NOTactive2");
                }
            }
        }

        private void AddIPForm_Click(object sender, EventArgs e)
        {
            FormAddip formAddip = new FormAddip();
            formAddip.Show();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SSH_Connect.IP_ssh_server = textBox1.Text;
            SSH_Connect.port_ssh_server = Convert.ToInt32(textBox2.Text);
            SSH_Connect.ssh_user = textBox3.Text;
            SSH_Connect.ssh_password = textBox4.Text;
        }
    }
}
