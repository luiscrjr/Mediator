using Projeto.Services.API.Domain.Produtos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.API.Infra
{
    public interface IProdutoRepository
    {
        Task Create(ProdutoEntity entity);
        Task Update(ProdutoEntity entity);
        Task Delete(Guid id);

        Task<List<ProdutoEntity>> GetAll();
        Task<ProdutoEntity> GetById(Guid id);
    }
}
