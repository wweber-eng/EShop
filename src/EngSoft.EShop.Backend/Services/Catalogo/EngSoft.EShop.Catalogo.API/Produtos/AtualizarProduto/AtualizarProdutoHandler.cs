using EngSoft.EShop.Catalogo.API.Produtos.CriarProduto;
using Marten.Linq.SoftDeletes;
using System.Linq.Expressions;

namespace EngSoft.EShop.Catalogo.API.Produtos.AtualizarProduto
{

    public record AtualizarProdutoCommand
    (
        Guid Id,
        string Nome,
        string Descricao,
        List<string> Categoria,
        string ArquivoImagem,
        decimal Preco
    ) : ICommand<AtualizarProdutoResult>;

    public record AtualizarProdutoResult( bool IsSuccess);

    internal class AtualizarProdutoCommandHandler(IDocumentSession session, ILogger<AtualizarProdutoCommandHandler> log) : ICommandHandler<AtualizarProdutoCommand, AtualizarProdutoResult>
    {
        public async Task<AtualizarProdutoResult> Handle(AtualizarProdutoCommand command, CancellationToken cancellationToken)
        {
            log.LogInformation("AtualizarProdutoCommandHandler. Handler foi chamado com {@Command}", command);
            var produto = await session.LoadAsync<Produto>(command.Id, cancellationToken);

            if (produto is null)
            {
                throw new ProductNotFoundException();
            }

            produto.Nome = command.Nome;
            produto.Categoria = command.Categoria;
            produto.Descricao = command.Descricao;
            produto.ArquivoImagem = command.ArquivoImagem;
            produto.Preco = command.Preco;

            session.Update(produto);
            await session.SaveChangesAsync(cancellationToken);

            return new AtualizarProdutoResult(true);

        }
    }
}
