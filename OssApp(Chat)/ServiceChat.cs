using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OssApp_Chat_
{
    
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServiceChat" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        List<ServerUser> users = new List<ServerUser>();
        int nextID = 1;
        public int Connetct(string name)
        {
            ServerUser user = new ServerUser()
            {
                Id = nextID,
                Name = name,
                operationContext = OperationContext.Current


            };
            nextID++;
            SendMessage(user.Name + "Подключился", 0);
            users.Add(user);
            return user.Id;
        }

        public void Dissconect(int id)
        {
             foreach(var user in users)
             {
                if (id == user.Id && user != null)
                {
                    users.Remove(user);
                    SendMessage(user.Name +"Отключился",0);
                    break;
                }
             }
        }

        public void DoWork()
        {
        }

        public void SendMessage(string strn, int id)
        {
            foreach(var item in users)
            {
                string answer = DateTime.Now.ToShortTimeString();
                foreach (var user in users)
                {
                    if ( user != null && user.Id == id)
                    {
                        answer += ": " + user.Name + " ";
                    }
                }
                answer += strn;
                item.operationContext.GetCallbackChannel<IServerChatCallBack>().MsgCallBack(answer);
            }
        }
    }
}
