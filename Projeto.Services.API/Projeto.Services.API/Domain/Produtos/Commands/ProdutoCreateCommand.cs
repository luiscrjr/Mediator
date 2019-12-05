using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.API.Domain.Produtos.Commands
{
    public class ProdutoCreateCommand : IRequest<string>
    {
        public string Nome{ get; set; }
        public decimal Preco{ get; set; }
        public int Quantidade{ get; set; }

    }
}
