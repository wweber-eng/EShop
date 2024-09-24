
namespace EngSoft.EShop.Catalogo.API.Produtos.SelecionarProdutos
{
    public record SelecionarProdutoQuery() : IQuery<SelecionarProdutoResult>;
    
    public record SelecionarProdutoResult(IEnumerable<Produto> Produtos);

    internal class SelecionarProdutoQueryHandler(IDocumentSession session, ILogger<SelecionarProdutoQueryHandler> log) : IQueryHandler<SelecionarProdutoQuery, SelecionarProdutoResult>
    {
        public async Task<SelecionarProdutoResult> Handle(SelecionarProdutoQuery query, CancellationToken cancellationToken)
        {
            log.LogInformation("SelecionarProdutoQueryHandler. Handler chamado com {@Query}", query);
            var produtos = await session.Query<Produto>().ToListAsync(cancellationToken);
            return new SelecionarProdutoResult(produtos);

        }
    }
}
