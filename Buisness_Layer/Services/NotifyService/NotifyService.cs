using Buisness_Layer.EmailConfig;
using Buisness_Layer.Services.AreaService;
using Buisness_Layer.Services.EmailService;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Services.NotifyService
{

    public class NotifyService : INotifyService
    {
        private readonly IAreaService _areaService;
        private readonly IEmailSender _emailSender;


        public NotifyService(IAreaService areaService, IEmailSender emailSender)
        {
            _areaService = areaService;
            _emailSender = emailSender;

        }
        public async Task<string> Notify(int fillLevel, int dustbinNumber,string address)
        {
            var areaInspector = await _areaService.GetAreaInspector(address);
            if (string.IsNullOrEmpty(areaInspector))
            {
                return "";
            }
            try
            {
                var message = new Message(new string[] { areaInspector }, "Test email", $"Alert!!! dustbin number {dustbinNumber} is filled by {fillLevel}% in {address} area");
                if (fillLevel >80)
                {
                    _emailSender.SendEmail(message);
                }
                return "Notified";
            }
            catch
            {
                return "";
            }
        }
    }
}
