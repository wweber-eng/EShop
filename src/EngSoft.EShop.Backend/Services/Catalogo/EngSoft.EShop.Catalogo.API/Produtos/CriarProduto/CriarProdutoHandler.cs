namespace EngSoft.EShop.Catalogo.API.Produtos.CriarProduto
{
    #region Objetos Command e Result

    /// <summary>
    /// Objeto que representa os dados necessários para a criação de um novo produto, onde será passado para o Handler
    /// </summary>
    /// <param name="Nome">Nome do produto</param>
    /// <param name="Descricao">Descrição do produto</param>
    /// <param name="Categoria">Categoria do produto</param>
    /// <param name="ArquivoImagem">Imagem do produto</param>
    /// <param name="Preco">Preço do produto</param>
    public record CriarProdutoCommand
    (
        string Nome,
        string Descricao,
        List<string> Categoria,
        string ArquivoImagem,
        decimal Preco
    ) : ICommand<CriarProdutoResult>;

    /// <summary>
    /// Objeto que representa o resultado da criação do produto
    /// </summary>
    /// <param name="Id">Id do produto</param>
    public record CriarProdutoResult
    (
        Guid Id
    );

    #endregion

    #region Handle

    /// <summary>
    /// Classe orquestradora de produto, ou manipuladora de comandos, que conterá a lógica de negócio
    /// </summary>
    internal class CriarProdutoCommandHandler(IDocumentSession session) : ICommandHandler<CriarProdutoCommand, CriarProdutoResult>
    {
        public async Task<CriarProdutoResult> Handle(CriarProdutoCommand command, CancellationToken cancellationToken)
        {
            // Criar a entidade de produtos do objeto Command
            var produto = new Produto
            {
                Nome = command.Nome,
                Descricao = command.Descricao,
                Categoria = command.Categoria,
                ArquivoImagem = command.ArquivoImagem,
                Preco = command.Preco
            };

            // Salvar no banco de dados
            session.Store(produto);
            await session.SaveChangesAsync(cancellationToken);

            // retornar o resultado CriarProdutoResult
            return new CriarProdutoResult(produto.Id);

        }
    }

    #endregion
}
