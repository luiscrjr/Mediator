using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Services.API.Domain.Produtos.Commands;
using Projeto.Services.API.Infra;
using Projeto.Services.API.Models;

namespace Projeto.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        private readonly IProdutoRepository repository;


        //construtor padrão para injeção de dependencia
        public ProdutoController(IMediator mediator, IMapper mapper, IProdutoRepository repository)
        {
            this.mapper = mapper;
            this.mediator = mediator;
            this.repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProdutoCreateCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProdutoCreateCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var command = new ProdutoDeleteCommand { Id = Guid.Parse(id) };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await repository.GetAll();
            return Ok(mapper.Map<List<ProdutoModel>>(response));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await repository.GetById(Guid.Parse(id));
            return Ok(mapper.Map<ProdutoModel>(response));
        }

        
    }
}