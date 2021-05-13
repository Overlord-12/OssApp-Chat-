using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OssApp_Chat_
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServiceChat" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof(IServerChatCallBack))]
    public interface IServiceChat
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        int Connetct();
        [OperationContract]
        void Dissconect(int id);
        [OperationContract(IsOneWay = true)]
        void SendMessage(string str);
    }

    public interface IServerChatCallBack
    {
        [OperationContract]
        void MsgCallBack(string str);

    }
    
}
