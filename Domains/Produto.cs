using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EFCore.Domains

//Domains - "Classes" das coisas
//Guid - código único de incrementação, segurança do ID, é interessante utilizar na Primary Key
{
    /// <summary>
    /// Classe Produto
    /// </summary>
    public class Produto : BaseDomain
    {
       
        public string Nome { get; set; }

        public float Preco { get; set; }

        //Recebe o arquivo
        [NotMapped]
        [JsonIgnore]
        public IFormFile Imagem { get; set; }

        //url da imagem que vai ser salva localmente
        public string UrlImagem { get; set; }

        //Relacionamento com a tabela PedidoItem 1,N
        public List<PedidoItem> PedidosItens { get; set; }



    }
}