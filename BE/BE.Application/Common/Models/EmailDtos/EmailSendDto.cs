using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Common.Models.EmailDtos
{
    public class EmailSendDto
    {
        public string Subject { get; set; }
        public List<string> Addresses { get; set; }
        public string HtmlContent { get; set; }

        public EmailSendDto(string email, string subject, string htmlContent)
        {
            Subject = subject;
            Addresses = new() { email };
            HtmlContent = htmlContent;
        }
    }
}
