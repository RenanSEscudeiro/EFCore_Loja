using EFCore.Domains;
using System;
using System.Collections.Generic;

namespace EFCore.Interfaces
{
    public interface IProdutoRepository
        {
            List<Produto> Listar();
            Produto BuscarPorId(Guid id);
            List<Produto> BuscarPorNome(string nome);
            void Adicionar(Produto produto);
            void Editar(Produto produto);
            void Remover(Guid id);
        }
    }

