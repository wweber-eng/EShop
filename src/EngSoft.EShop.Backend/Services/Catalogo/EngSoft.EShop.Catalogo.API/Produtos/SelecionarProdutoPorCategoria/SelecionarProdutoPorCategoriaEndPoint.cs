
using EngSoft.EShop.Catalogo.API.Produtos.SelecionarProdutoPorID;

namespace EngSoft.EShop.Catalogo.API.Produtos.SelecionarProdutoPorCategoria
{
    public record SelecionarProdutoPorCategoriaResponse(IEnumerable<Produto> Produtos);

    public class SelecionarProdutoPorCategoriaEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/produtos/categoria/{categoria}", async (string Categoria, ISender sender) =>
            {
                var result = await sender.Send(new SelecionarProdutoPorCategoriaQuery(Categoria));
                var response = result.Adapt<SelecionarProdutoPorCategoriaResponse>();
                return Results.Ok(response);
            })
                .WithName("SelecionarProdutoPorCategoria")
                .Produces<SelecionarProdutoPorCategoriaResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Selecionar Produto por Categoria")
                .WithDescription("Selecionar Produto por Categoria.");
        }
    }
}
