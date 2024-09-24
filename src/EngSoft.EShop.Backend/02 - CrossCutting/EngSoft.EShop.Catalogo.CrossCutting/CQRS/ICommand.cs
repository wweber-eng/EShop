using MediatR;

namespace EngSoft.EShop.Catalogo.CrossCutting.CQRS
{
    /// <summary>
    /// Comando vazio que não porduz resposta
    /// </summary>
    public interface ICommand : ICommand<Unit>
    {}

    /// <summary>
    /// Comando genérico que permite respostas
    /// </summary>
    /// <typeparam name="Response">Resposta</typeparam>
    public interface ICommand<out Response> : IRequest<Response>
    {}
}
