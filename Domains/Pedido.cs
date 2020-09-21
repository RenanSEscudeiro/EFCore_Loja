using System;
using System.Collections.Generic;

namespace EFCore.Domains
{
    /// <summary>
    /// Classe Pedido
    /// </summary>
    public class Pedido : BaseDomain
    //Guid - código único de incrementação, segurança do ID, é interessante utilizar na Primary Key
    //Domains - "Classes" das coisas
    {
       

        public string Status { get; set; }

        public DateTime OrderDate { get; set; }

        //Relacionamento com a tabela PedidoItem 1 pra N
        public List<PedidoItem> PedidosItens { get; set; }

        public Pedido()
        {
            PedidosItens = new List<PedidoItem>();
        }


    }
}
