using System.Linq;

namespace ProjetosTeste.Models
{
    public class InicializaDB
    {
        public static void Initialize(ProdutoContexto context)
        {
            context.Database.EnsureCreated();

            // Procura por produtos
            if (context.Produtos.Any())
            {
                return;  // O BD foi alimentado
            }

            var produtos = new Produto[]
            {
                new Produto{Nome="Caneta", Preco=3.99M},
                new Produto{Nome="Borracha", Preco=1.55M},
            };
            foreach (Produto p in produtos)
            {
                context.Produtos.Add(p);
            }
            context.SaveChanges();
        }
    }
}