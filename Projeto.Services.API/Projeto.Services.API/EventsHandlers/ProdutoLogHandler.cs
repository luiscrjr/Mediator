using MediatR;
using Projeto.Services.API.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            });
        }
    }
}
