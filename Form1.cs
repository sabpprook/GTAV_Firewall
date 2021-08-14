using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTAV_Firewall
{
    public partial class Form1 : Form
    {
        bool IsServerRunning = false;
        Socket SocketServer;

        public Form1()
        {
            InitializeComponent();
            button_StartServer.ForeColor = Color.SeaGreen;
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            var list = Utils.GetFirewallIP();
            if (list != null)
            {
                listBox_IP.Items.AddRange(list);
                label_Status.Text = "GTAV 防火牆啟用中";
                label_Status.ForeColor = Color.SeaGreen;
            }
            else
            {
                label_Status.Text = "尚未建立 GTAV 防火牆規則";
                label_Status.ForeColor = Color.Red;
            }

            var global_ip = await Task.Run(() => Utils.GetGlobalIPv4());
            label_GlobalIPv4.Text = global_ip;

            var local_ip = Utils.GetLocalIPv4();
            label_LocalIPv4.Text = string.Empty;
            foreach (var ip in local_ip)
            {
                if (global_ip.Contains(ip))
                    continue;

                label_LocalIPv4.Text += ip + ", ";
            }
            if (label_LocalIPv4.Text.Length >= 2)
            {
                label_LocalIPv4.Text = label_LocalIPv4.Text.Substring(0, label_LocalIPv4.Text.Length - 2);
            }

            local_ip = local_ip.SkipWhile(x => x.Contains(global_ip)).ToArray();
            await Task.Run(() => Utils.CreateUPnP(local_ip));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.DeleteUPnP();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            var ip = textBox_IP.Text;
            if (Utils.IPv4toUInt32(ip) != 0)
            {
                if (listBox_IP.Items.Contains(ip))
                    return;
                listBox_IP.Items.Add(ip);
                textBox_IP.Text = string.Empty;
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            var idx = listBox_IP.SelectedIndex;
            if (idx >= 0)
            {
                listBox_IP.Items.RemoveAt(idx--);
            }
            if (idx < 0 && listBox_IP.Items.Count > 0)
            {
                idx = 0;
            }
            listBox_IP.SelectedIndex = idx;
        }

        private void label_GlobalIPv4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_IP.Text = label_GlobalIPv4.Text;
            button_Add.PerformClick();
        }

        private void button_SetFirewall_Click(object sender, EventArgs e)
        {
            if (listBox_IP.Items.Count == 0)
            {
                textBox_IP.Text = label_GlobalIPv4.Text;
                button_Add.PerformClick();
            }
            var item = Utils.GetBlockRange(listBox_IP.Items.Cast<string>().ToArray());
            Utils.SetFirewall(item.block, item.desc);
            label_Status.Text = "GTAV 防火牆啟用中";
            label_Status.ForeColor = Color.SeaGreen;
        }

        private void button_ClearFirewall_Click(object sender, EventArgs e)
        {
            listBox_IP.Items.Clear();
            Utils.ClearFirewall();
            label_Status.Text = "尚未建立 GTAV 防火牆規則";
            label_Status.ForeColor = Color.Red;
        }

        private void button_StartServer_Click(object sender, EventArgs e)
        {
            if (!IsServerRunning)
            {
                SocketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                SocketServer.Bind(new IPEndPoint(IPAddress.Any, 54088));
                SocketServer.Listen(20);
                SocketServer.BeginAccept(new AsyncCallback(AcceptCallback), SocketServer);
                IsServerRunning = true;
                button_StartServer.Text = "停止";
                button_StartServer.ForeColor = Color.Red; 
            }
            else
            {
                IsServerRunning = false;
                button_StartServer.Text = "啟動";
                button_StartServer.ForeColor = Color.SeaGreen;
                SocketServer.Close();
            }
        }

        private async void button_Send_Click(object sender, EventArgs e)
        {
            var address = comboBox_Address.Text;

            if (string.IsNullOrEmpty(address))
                return;

            button_Send.Enabled = false;
            await Task.Run(() =>
            {
                try
                {
                    using (var tc = new TcpClient())
                    {
                        if (tc.ConnectAsync(address, 54088).Wait(3000))
                        {
                            using (var sw = new StreamWriter(tc.GetStream()))
                                sw.Write("hello world!");
                        }
                    }
                }
                catch { }
            });
            button_Send.Enabled = true;
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            if (!IsServerRunning)
                return;

            var socket = (Socket)ar.AsyncState;
            var client = socket.EndAccept(ar);
            socket.BeginAccept(new AsyncCallback(AcceptCallback), socket);
            client.Send(Encoding.UTF8.GetBytes("hello world!"));
            var remoteip = ((IPEndPoint)client.RemoteEndPoint).Address.ToString();
            Invoke(new Action(() =>
            {
                if (listBox_IP.Items.Contains(remoteip))
                    return;
                listBox_IP.Items.Add(remoteip);
                button_SetFirewall.PerformClick();
            }));
        }
    }
}
