using MediatR;

namespace EngSoft.EShop.Catalogo.CrossCutting.CQRS
{
    /// <summary>
    /// QueryHandler genérico que permite respostas
    /// </summary>
    /// <typeparam name="Response">Resposta</typeparam>
    public interface IQueryHandler<in Query, Response> : IRequestHandler<Query, Response>
        where Query : IQuery<Response>
        where Response : notnull {}
}
