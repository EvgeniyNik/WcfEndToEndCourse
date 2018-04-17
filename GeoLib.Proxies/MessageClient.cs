using GeoLib.Client.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Proxies
{
    public class MessageClient : ClientBase<IMessageService>, IMessageService
    {
        public void ShowMsg(string message)
        {
            Channel.ShowMsg(message);
        }
    }
}
