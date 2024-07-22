using Buisness_Layer.EmailConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Services.NotifyService
{
    public interface INotifyService
    {
        Task<string> Notify(int fillLevel, int dustbinNumber, string address);
    }
}
