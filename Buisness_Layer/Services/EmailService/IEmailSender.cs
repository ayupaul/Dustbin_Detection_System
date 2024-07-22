using Buisness_Layer.EmailConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Services.EmailService
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
