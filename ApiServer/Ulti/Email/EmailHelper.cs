using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using ApiServer.Model;

namespace ApiServer.Ulti.Email
{
    public class EmailHelper : IEmailHelper
    {
        private readonly IaeContext _context;
        private readonly SmtpClient _smtpServer;
        private readonly string _source;
        public EmailHelper(IaeContext vdsContext)
        {
            _context = vdsContext;
            _source = "veda.futurisx@gmail.com";
            _smtpServer = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential("veda.futurisx", "veda@FUTURISX#2017"),
                EnableSsl = true
            };
        }
        public async Task Send(string destination, string subject, string body)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(_source)
            };
            mail.To.Clear();
            mail.To.Add(destination);
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = body;
            var userState = "ok";
            _smtpServer.SendAsync(mail, userState);
        }
        public async Task Broadcast(string subject, string body)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(_source)
            };
            mail.To.Clear();
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = body;

            var users = _context.Users;
            foreach (var user in users)
            {
                mail.To.Add(user.Email);
            }


            var userState = "ok";
            _smtpServer.SendAsync(mail, userState);

        }
    }
}
