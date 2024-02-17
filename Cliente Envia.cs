using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ClienteEnvia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string envio = txtBox.Text;

            listBox1.Items.Add(envio);

            Socket socketEnviar = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP);

            IPEndPoint endereco = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9060);

            socketEnviar.SendTo(Encoding.ASCII.GetBytes(envio), endereco);
            socketEnviar.Close();

            txtBox.Clear();

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}