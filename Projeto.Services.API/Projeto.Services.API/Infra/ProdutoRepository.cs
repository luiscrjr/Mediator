using Projeto.Services.API.Domain.Produtos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.API.Infra
{
    public class ProdutoRepository : IProdutoRepository
    {
        private List<ProdutoEntity> Produtos { get; }

        public ProdutoRepository()
        {
            Produtos = new List<ProdutoEntity>();
        }

        public async Task Create(ProdutoEntity entity)
        {
            await Task.Run(() => Produtos.Add(entity));
        }

        public async Task Update(ProdutoEntity entity)
        {
            int index = Produtos.FindIndex(p => p.Id.Equals(entity.Id));

            if(index > 0)
            {
                await Task.Run(() => Produtos[index] = entity);
            }
        }

        public async Task Delete(Guid id)
        {
            int index = Produtos.FindIndex(p => p.Id.Equals(id));

            if (index > 0)
            await Task.Run(() => Produtos.RemoveAt(index));
        }

        public async Task<List<ProdutoEntity>> GetAll()
        {
            return await Task.FromResult(Produtos);
        }

        public async Task<ProdutoEntity> GetById(Guid id)
        {
            var result = Produtos.FirstOrDefault(p => p.Id.Equals(id));
            return await Task.FromResult(result);
        }
    }
}
