using MediatR;
using Newtonsoft.Json;
using Projeto.Services.API.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Services.API.EventsHandlers
{
    public class ProdutoLogHandler : INotificationHandler<ProdutoActionNotification>
    {
        public Task Handle(ProdutoActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Debug.WriteLine($"O Produto {notification.Produto.Id}, {notification.Produto.Nome} " +
                    $"foi {notification.Action.ToString().ToUpper()}");

                var mail = new MailMessage("cotiexemplo3@gmail.com", "luis.claudio.jr@hotmail.com");
                mail.Subject = $"Produto {notification.Action.ToString().ToUpper()} com sucesso";
                mail.Body = JsonConvert.SerializeObject(notification.Produto, Formatting.Indented);
                mail.IsBodyHtml = true;

                var smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("cotiexemplo3@gmail.com", "@coticoti@");
                smtp.Send(mail);
            });
        }
    }
}
