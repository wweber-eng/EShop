
using EngSoft.EShop.Catalogo.API.Produtos.SelecionarProdutoPorID;

namespace EngSoft.EShop.Catalogo.API.Produtos.ExcluirProduto
{
    public record ExcluirProdutoCommand(Guid Id) : ICommand<ExcluirProdutoResult>;
    public record ExcluirProdutoResult(bool IsSuccess);

    internal class ExcluirProdutoCommandHandler(IDocumentSession session, ILogger<ExcluirProdutoCommandHandler> log) : ICommandHandler<ExcluirProdutoCommand, ExcluirProdutoResult>
    {
        public async Task<ExcluirProdutoResult> Handle(ExcluirProdutoCommand command, CancellationToken cancellationToken)
        {
            log.LogInformation("ExcluirProdutoCommandHandler.  Handler chamado com {@Query}", command);
            var produto = await session.LoadAsync<Produto>(command.Id, cancellationToken);

            if (produto is null)
                throw new ProductNotFoundException();

            session.Delete<Produto>(command.Id);
            await session.SaveChangesAsync(cancellationToken);

            return new ExcluirProdutoResult(true);
        }
    }
}
