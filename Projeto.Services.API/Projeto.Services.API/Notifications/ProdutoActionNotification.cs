using MediatR;
using Projeto.Services.API.Domain.Produtos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.API.Notifications
{
    public class ProdutoActionNotification : INotification
    {
        public ProdutoEntity Produto { get; set; }
        public ActionNotification Action { get; set; }
    }
}
