using AutoMapper;
using Projeto.Services.API.Domain.Produtos.Commands;
using Projeto.Services.API.Domain.Produtos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.API.Profiles
{
    public class ModelToEntity : Profile
    {
        public ModelToEntity()
        {
            CreateMap<ProdutoCreateCommand, ProdutoEntity>()
                .AfterMap((src, dest) => { dest.Id = Guid.NewGuid(); });

            CreateMap<ProdutoUpdateCommand, ProdutoEntity>();
        }
    }
}
