using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.API.Domain.Produtos.Commands
{
    public class ProdutoDeleteCommand : IRequest<string>
    {
        public Guid Id { get; set; }
    }
}
