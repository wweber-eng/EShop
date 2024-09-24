using Marten.Linq.QueryHandlers;

namespace EngSoft.EShop.Catalogo.API.Produtos.SelecionarProdutoPorCategoria
{
    public record SelecionarProdutoPorCategoriaQuery(string Categoria) : IQuery<SelecionarProdutoPorCategoriaResult>;

    public record SelecionarProdutoPorCategoriaResult(IEnumerable<Produto> Produtos);

    internal class SelecionarProdutoPorCategoriaQueryHandler(IDocumentSession session, ILogger<SelecionarProdutoPorCategoriaQueryHandler> log) : IQueryHandler<SelecionarProdutoPorCategoriaQuery, SelecionarProdutoPorCategoriaResult>
    {
        public async Task<SelecionarProdutoPorCategoriaResult> Handle(SelecionarProdutoPorCategoriaQuery query, CancellationToken cancellationToken)
        {
            log.LogInformation("SelecionarProdutoPorCategoriaQueryHandler.  Handler chamado com {@Query}", query);
            var produtos = await session.Query<Produto>().Where(p => p.Categoria.Contains(query.Categoria)).ToListAsync();
            return new SelecionarProdutoPorCategoriaResult(produtos);
        }
    }
}

