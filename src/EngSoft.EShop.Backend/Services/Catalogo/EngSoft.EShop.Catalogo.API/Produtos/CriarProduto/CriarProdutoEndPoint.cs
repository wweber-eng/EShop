namespace EngSoft.EShop.Catalogo.API.Produtos.CriarProduto
{
    public record CriarProdutoRequest
    (
        string Nome,
        string Descricao,
        List<string> Categoria,
        string ArquivoImagem,
        decimal Preco
    );

    public record CriarProdutoResponse(Guid Id);

    public class CriarProdutoEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/produtos", async (CriarProdutoRequest request, ISender sender) =>
            {
                var command = request.Adapt<CriarProdutoCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CriarProdutoResponse>();
                return Results.Created($"/produtos/{response.Id}", response);
            })
                .WithName("CriarProduto")
                .Produces<CriarProdutoResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithDescription("Produto criado com sucesso!");
        }
    }
}
