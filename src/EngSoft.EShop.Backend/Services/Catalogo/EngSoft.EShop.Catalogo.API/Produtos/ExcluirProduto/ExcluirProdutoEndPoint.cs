
using EngSoft.EShop.Catalogo.API.Produtos.AtualizarProduto;

namespace EngSoft.EShop.Catalogo.API.Produtos.ExcluirProduto
{
   
    public record ExcluirProdutoRequest(Guid Id);

    public record ExcluirProdutoResponse(bool IsSuccess);



    public class ExcluirProdutoEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/produto/{id}", async (Guid Id, ISender sender) =>
            {
                var result = await sender.Send(new ExcluirProdutoCommand(Id));
                var response = result.Adapt<ExcluirProdutoResponse>();
                return Results.Ok(response);


            })
              .WithName("ExcluirProduto")
              .Produces<ExcluirProdutoResponse>(StatusCodes.Status200OK)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .WithSummary("Excluir Produto")
              .WithDescription("Excluir Produto.");
        }
    }
}
