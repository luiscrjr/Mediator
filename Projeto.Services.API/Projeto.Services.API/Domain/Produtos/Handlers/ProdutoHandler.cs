using AutoMapper;
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
        private readonly IMapper mapper;
        private readonly IProdutoRepository repository;

        //construtor com entrada de algumentos para usar injecao de dependencia
        public ProdutoHandler(IMediator mediator, IMapper mapper, IProdutoRepository repository)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<string> Handle(ProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            var produto = mapper.Map<ProdutoEntity>(request);
            await repository.Create(produto);

            await mediator.Publish(new ProdutoActionNotification
            {
                Produto = produto,
                Action = ActionNotification.Criado
            });

            return await Task.FromResult("Produto cadastrado com sucesso.");
        }

        public async Task<string> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            var produto = mapper.Map<ProdutoEntity>(request);
            await repository.Update(produto);

            await mediator.Publish(new ProdutoActionNotification
            {
                Produto = produto,
                Action = ActionNotification.Atualizado
            });

            return await Task.FromResult("Produto atualizado com sucesso.");
        }

        public async Task<string> Handle(ProdutoDeleteCommand request, CancellationToken cancellationToken)
        {
            var produto = await repository.GetById(request.Id);
            await repository.Delete(request.Id);

            await mediator.Publish(new ProdutoActionNotification
            {
                Produto = produto,
                Action = ActionNotification.Excluido
            });

            return await Task.FromResult("Produto excluído com sucesso.");
        }
    }
}
