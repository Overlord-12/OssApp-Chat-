using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChatClient.ServieChat;

namespace ChatClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IServiceChatCallback
    {
        bool isConnected = false;
        ServiceChatClient client;
        int ID;
        public MainWindow()
        {
            InitializeComponent();
        }
        void ConnectUser()
        {

            if (!isConnected)
            {
                client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
                ID = client.Connetct(tbName.Text);
                tbName.IsEnabled = false;
                isConnected = true;
                btConnectDisc.Content = "Отключиться";
            }
        }
        void Disconect()
        {
            if (isConnected)
            {
                client.Dissconect(ID);
                tbName.IsEnabled = true;
                isConnected = false;
                btConnectDisc.Content = "Подключиться";
                client = null;
            }
        }
       

        public void MsgCallBack(string str)
        {
            lbChat.Items.Add(str);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Disconect();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             if (isConnected) Disconect();
            if (!isConnected) ConnectUser();
        }

        private void btSend_Click(object sender, RoutedEventArgs e)
        {
            if(TbMessage.Text != string.Empty  && client != null)
            {
                client.SendMessage(TbMessage.Text,ID);
                TbMessage.Text = string.Empty;
            }
        }
    }
}
