using MediatR;

namespace EngSoft.EShop.Catalogo.CrossCutting.CQRS
{
    /// <summary>
    /// ComamdHandler vazio que não produz resposta
    /// </summary>
    public interface ICommandHandler<in Command> : ICommandHandler<Command, Unit>
        where Command : ICommand<Unit> {}

    /// <summary>
    /// CommandHandler genérico que permite respostas
    /// </summary>
    /// <typeparam name="Response">Resposta</typeparam>
    public interface ICommandHandler<in Command, Response> : IRequestHandler<Command, Response> 
        where Command : ICommand<Response>
        where Response : notnull {}
}
