
using EngSoft.EShop.Catalogo.API.Models;
using EngSoft.EShop.Catalogo.API.Produtos.SelecionarProdutos;

namespace EngSoft.EShop.Catalogo.API.Produtos.SelecionarProdutoPorID
{
    public record SeleciornarProdutoPorIdResponse(Produto Produto);

    public class SelecionarProdutoPorIdEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/produto/{id}", async (Guid id,  ISender sender) =>
            {
                var result = await sender.Send(new SelecionarProdutoPorIdQuery(id));
                var response = result.Adapt<SeleciornarProdutoPorIdResponse>();
                return Results.Ok(response);
            })
                .WithName("SelecionarProdutoPorId")
                .Produces<SeleciornarProdutoPorIdResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Selecionar Produto por Id")
                .WithDescription("Selecionar Produto por Id.");
        }
    }
}
