using System.Text;
using System.Net.Sockets;
using System.Net;

namespace ServidorRecebe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReceber_Click(object sender, EventArgs e)
        {
            Socket socketRecebe = new Socket(AddressFamily.InterNetwork,SocketType.Dgram, ProtocolType.IP);
            EndPoint endereco = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9060);

            byte[] data = new byte[1024];
            int qtdbytes;


            socketRecebe.Bind(endereco);
            while (true)
            {
                qtdbytes = socketRecebe.ReceiveFrom(data,ref endereco);
                string mensage = Encoding.ASCII.GetString(data,0,qtdbytes);
                ListBoxServ.Items.Add(mensage);
                ListBoxServ.Refresh();
            }
        }
    }
}