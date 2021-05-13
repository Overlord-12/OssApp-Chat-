using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OssApp_Chat_
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServiceChat" в коде и файле конфигурации.
    public class ServiceChat : IServiceChat
    {
        public int Connetct()
        {
            throw new NotImplementedException();
        }

        public void Dissconect(int id)
        {
            throw new NotImplementedException();
        }

        public void DoWork()
        {
        }

        public void SendMessage(string str)
        {
            throw new NotImplementedException();
        }
    }
}
