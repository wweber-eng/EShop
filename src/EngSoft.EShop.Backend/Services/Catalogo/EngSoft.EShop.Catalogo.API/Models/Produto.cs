namespace EngSoft.EShop.Catalogo.API.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = default!;
        public string Descricao { get; set; } = default!;
        public List<string> Categoria { get; set; } = [];
        public string ArquivoImagem { get; set; } = default!;
        public decimal Preco { get; set; }

    }
}
