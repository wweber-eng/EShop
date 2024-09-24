using MediatR;

namespace EngSoft.EShop.Catalogo.CrossCutting.CQRS
{
    public interface IQuery<out Response> : IRequest<Response> where Response: notnull
    {}

}
