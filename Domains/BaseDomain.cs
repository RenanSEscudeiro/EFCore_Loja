using System;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domains
{

    /// <summary>
    /// Classe BaseDomain
    /// </summary>
    public abstract class BaseDomain
    {
        //Classe Abstrata, não consegue instanciar, segurança
        //Guid - código único de incrementação, segurança do ID, é interessante utilizar na Primary Key
        //Domains - "Classes" das coisas
        [Key]
        //segurança private, n posso setar
        public Guid Id { get; private set; }

        //dando um new guid gerado aleatoriamente
        public BaseDomain()
        {
            Id = Guid.NewGuid();
        }

        public void setId(Guid id)
        {
            this.Id = id;
        }

    }
}
