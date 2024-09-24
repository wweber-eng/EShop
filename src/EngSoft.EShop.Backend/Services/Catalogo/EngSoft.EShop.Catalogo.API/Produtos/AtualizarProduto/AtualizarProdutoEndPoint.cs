
using EngSoft.EShop.Catalogo.API.Produtos.SelecionarProdutoPorCategoria;

namespace EngSoft.EShop.Catalogo.API.Produtos.AtualizarProduto
{
    public record AtualizarProdutoRequest
     (
        Guid Id,
        string Nome,
        string Descricao,
        List<string> Categoria,
        string ArquivoImagem,
        decimal Preco
     );

    public record AtualizarProdutoResponse(bool IsSuccess);

    public class AtualizarProdutoEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/produto", async (AtualizarProdutoRequest request, ISender sender) =>
            {
                var command = request.Adapt<AtualizarProdutoCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<AtualizarProdutoResponse>();
                return Results.Ok(response);

                
            })
               .WithName("AtualizarProduto")
               .Produces<AtualizarProdutoResponse>(StatusCodes.Status200OK)
               .ProducesProblem(StatusCodes.Status400BadRequest)
               .WithSummary("Atualizar Produto")
               .WithDescription("Atualizar Produto.");
        }
    }
    
}
