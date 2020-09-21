using EFCore.Domains;
using EFCore.Interfaces;
using EFCore.Repositories;
using EFCore.Utils;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EFCore.Controllers
{

    //Implementa todos os métodos criados no repository
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        // GET
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os produtos no repositório
                var produtos = _produtoRepository.Listar();


                //Verifica se existe produtos, caso não exista retorna NoContent
                if (produtos.Count == 0)
                    return NoContent();

                //Caso exista retorna um Ok e os produtos
                return Ok(new
                {
                    //count contagem 
                    totalCount = produtos.Count,
                    data = produtos
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/produtos, envie um e-mail para email@email.com para reportar"
                });
            }
        }

        // GET
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //Busca o produto no repositório
                Produto produto = _produtoRepository.BuscarPorId(id);

                //Verifica se existe produtos, caso não exista retorna NoFound
                if (produto == null)
                    return NotFound();

                //Caso exista retorna um Ok e os produtos
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //No caso de ocorrer algum erro retorna BadRequest e a mensagem do erro
                return BadRequest(ex.Message);
            }
        }

        // POST
        [HttpPost]
        public IActionResult Post([FromForm]Produto produto)
        {
            try
            {
                //TODO: Adicionar if no PedidoController que vai ser criado dentro do try do POST
                if (produto.Imagem != null)
                {
                    var urlImagem = Upload.Local(produto.Imagem);

                    produto.UrlImagem = urlImagem;

                }
                //Adiciona um produto
                _produtoRepository.Adicionar(produto);

                //Caso ok com os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //No caso de ocorrer algum erro retorna BadRequest e a mensagem do erro
                return BadRequest(ex.Message);
            }

        }

        // PUT 
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                //Edita o produto
                _produtoRepository.Editar(produto);

                //Caso ok com os dados do produto
                return Ok(produto);

            }
            catch (Exception ex)
            {
                //No caso de ocorrer algum erro retorna BadRequest e a mensagem do erro
                return BadRequest(ex.Message);
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //Busca o produto pelo Id
                var produto = _produtoRepository.BuscarPorId(id);

                //Verifica se produto existe
                //Caso não exista retorna NotFound
                if (produto == null)
                    return NotFound();

                //Caso exista remove o produto
                _produtoRepository.Remover(id);

                //Caso ok com os dados do produto
                return Ok(id);
            }
            catch (Exception ex)
            {
                //No caso de ocorrer algum erro retorna BadRequest e a mensagem do erro
                return BadRequest(ex.Message);
            }

        }
    }
}

