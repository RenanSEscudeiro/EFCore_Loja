using EFCore.Domains;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Context
{
    //Context - representa o banco
    //Aqui utilizamos os NuGets do EntityFrameworkCore
    public class PedidoContext : DbContext
    {
        //DbSet coloca algo no db
        
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoItem> PedidosItems { get; set; }


        //Conexão com o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-UTGRE9J\SQLEXPRESS;Initial Catalog=loja;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
