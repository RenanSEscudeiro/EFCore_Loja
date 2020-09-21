using EFCore.Context;
using EFCore.Domains;
using EFCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        //_ctx é nosso contexto
        private readonly PedidoContext _ctx;

        //Digitar ctor cria um construtor
        public ProdutoRepository()
        {
            _ctx = new PedidoContext();

        }

        //#Region técnica de clean code
        #region Leitura


        /// <summary>
        /// Busca produto pelo id
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns>Lista de produtos</returns>
        public Produto BuscarPorId(Guid id)
        {
            try
            {
                //return _ctx.Produtos.FirstOrDefault(c => c.Id == id);
                return _ctx.Produtos.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        /// <summary>
        /// Busca produto pelo nome
        /// </summary>
        /// <param name="nome">Nome do produto</param>
        /// <returns>Retorna um produto</returns>
        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Produtos.Where(c => c.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Lista os produtos
        /// </summary>
        /// <returns>Retorna uma lista com os produtos cadastrados</returns>
        public List<Produto> Listar()
        {
            try
            {
                return _ctx.Produtos.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Gravação


        /// <summary>
        /// Edita um produto
        /// </summary>
        /// <param name="produto">produto que vai ser editado</param>
        public void Editar(Produto produto)
        {
            try
            {
                //Busca o produto pelo Id
                Produto produtoTemp = BuscarPorId(produto.Id);

                //Mensagem caso o produto não seja encontrado
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //Se encontrar, suas propriedades são alteradas
                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                //Altera o produto no contexto e salva o contexto
                _ctx.Produtos.Update(produtoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Adiciona um novo produto
        /// </summary>
        /// <param name="produto">Objeto do tipo produto</param>
        public void Adicionar(Produto produto)
        {
            try
            {
                //Também poderia adicionar algo utilizando:
                // _ctx.Set<Produto>().Add(produto);
                //_ctx.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Added

                //Esse Produtos vem do dbset
                _ctx.Produtos.Add(produto);

                //Salvando alterações do contexto
                _ctx.SaveChanges();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        public void Remover(Guid id)
        {
            try
            {
                //Busca o produto pelo Id
                Produto produtoTemp = BuscarPorId(id);

                //Mensagem caso o produto não seja encontrado
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //Se encontrar, deleta o produto do DbSet e salva o contexto
                _ctx.Produtos.Remove(produtoTemp);
                _ctx.SaveChanges();

            }

            catch (Exception ex)
            {
            
                throw new Exception(ex.Message);
            }

        }

        #endregion
    }
}
