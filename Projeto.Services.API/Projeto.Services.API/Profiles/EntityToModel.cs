using AutoMapper;
using Projeto.Services.API.Domain.Produtos.Entities;
using Projeto.Services.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.API.Profiles
{
    public class EntityToModel : Profile
    {
        public EntityToModel()
        {
            CreateMap<ProdutoEntity, ProdutoModel>()
                .AfterMap((src, dest) => dest.Id = src.Id.ToString())
                .AfterMap((src, dest) => dest.Total = (src.Preco * src.Quantidade));
        }
    }
}
