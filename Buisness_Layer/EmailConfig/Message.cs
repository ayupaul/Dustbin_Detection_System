using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.EmailConfig
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();

            // Assuming 'to' is an IEnumerable of email addresses
            foreach (var email in to)
            {
                // Split the email address into name and address parts
                var parts = email.Split('@');
                var name = parts[0]; // Taking the part before '@' as the name
                var address = email; // The full email address

                // Add a new MailboxAddress with both name and address
                To.Add(new MailboxAddress(name, address));
            }
            Subject = subject;
            Content = content;
        }
    }

}
