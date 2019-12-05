using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.API.Domain.Produtos.Commands
{
    public class ProdutoUpdateCommand : IRequest<string>
    {
        public Guid Id { get; set; }
        public string Nome{ get; set; }
        public decimal Preco{ get; set; }
        public int Quantidade{ get; set; }

    }
}
