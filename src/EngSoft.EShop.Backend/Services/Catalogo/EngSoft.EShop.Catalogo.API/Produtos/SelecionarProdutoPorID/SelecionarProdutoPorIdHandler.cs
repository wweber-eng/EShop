

namespace EngSoft.EShop.Catalogo.API.Produtos.SelecionarProdutoPorID
{
    public record SelecionarProdutoPorIdQuery(Guid Id) : IQuery<SelecionarProdutoPorIdResult>;

    public record SelecionarProdutoPorIdResult(Produto Produto);
    internal class SelecionarProdutoPorIdQueryHandler(IDocumentSession session, ILogger<SelecionarProdutoPorIdQueryHandler> log) : IQueryHandler<SelecionarProdutoPorIdQuery, SelecionarProdutoPorIdResult>
    {
        public async Task<SelecionarProdutoPorIdResult> Handle(SelecionarProdutoPorIdQuery query, CancellationToken cancellationToken)
        {
            log.LogInformation("SelecionarProdutoPorIdQueryHandler.  Handler chamado com {@Query}", query);
            var produto = await session.LoadAsync<Produto>(query.Id, cancellationToken);

            if (produto is null)
                throw new ProductNotFoundException();


            return new SelecionarProdutoPorIdResult(produto);
        }
    }

}
