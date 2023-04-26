using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace ProjectForPartnerSouth
{
    public partial class FormAddip : Form
    {
        
        public FormAddip()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            PasswordConnectionInfo connectionInfo = new PasswordConnectionInfo(SSH_Connect.IP_ssh_server, SSH_Connect.port_ssh_server, SSH_Connect.ssh_user, SSH_Connect.ssh_password);
            connectionInfo.Timeout = TimeSpan.FromSeconds(30);

            string ipadress = textBox1.Text;
            string bridge = textBox2.Text;

            using (var client = new SshClient(connectionInfo))
            {
                try
                {
                    client.Connect();
                    if (client.IsConnected)
                    {
                        var cmd = client.CreateCommand($"ip address add address={ipadress} interface={bridge}");
                        var asyncExecute = cmd.Execute();
                        MessageBox.Show("IP adress успешно добавлен");
                        this.Close();
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
    }
}
