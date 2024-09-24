namespace EngSoft.EShop.Catalogo.API.Produtos.SelecionarProdutos
{
    public record SeleciornarProdutoResponse(IEnumerable<Produto> produtos);

    public class SelecionarProdutoEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/produtos", async (ISender sender) =>
            {
                var result = await sender.Send(new SelecionarProdutoQuery());
                var response = result.Adapt<SeleciornarProdutoResponse>();
                return Results.Ok(response);
            })
                .WithName("SelecionarProduto")
                .Produces<SeleciornarProdutoResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Selecionar Produtos")
                .WithDescription("Selecionar Produtos.");
        }
    }
}
