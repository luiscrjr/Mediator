using MediatR;
using Projeto.Services.API.Domain.Produtos.Commands;
using Projeto.Services.API.Domain.Produtos.Entities;
using Projeto.Services.API.Infra;
using Projeto.Services.API.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Services.API.Domain.Produtos.Handlers
{
    public class ProdutoHandler : 
        IRequestHandler<ProdutoCreateCommand, string>,
        IRequestHandler<ProdutoUpdateCommand, string>,
        IRequestHandler<ProdutoDeleteCommand, string>
    {
        private readonly IMediator mediator;
        private readonly IProdutoRepository repository;

        //construtor com entrada de algumentos para usar injecao de dependencia
        public ProdutoHandler(IMediator mediator, IProdutoRepository repository)
        {
            this.mediator = mediator;
            this.repository = repository;
        }

        public async Task<string> Handle(ProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            var produto = new ProdutoEntity
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Preco = request.Preco,
                Quantidade = request.Quantidade
            };

            await repository.Create(produto);

            await mediator.Publish(new ProdutoActionNotification
            {
                Produto = produto,
                Action = ActionNotification.Criado
            });

            return await Task.FromResult("Produto cadastrado com sucesso.");
        }

        public Task<string> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> Handle(ProdutoDeleteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
