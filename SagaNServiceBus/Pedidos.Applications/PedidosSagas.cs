using Pedidos.Applications.Commands;
using Pedidos.Applications.Events;
using Pedidos.Applications.Messages;

namespace Pedidos.Applications;

public class PedidosSagas : Saga<PedidoSagaData>,
    IAmStartedByMessages<AdicionarPedidoCommands>,
    IHandleMessages<PedidoRecebidoEvent>,
    IHandleTimeouts<PedidoTimeOut>,
    IHandleMessages<ReservarItensDoPedidoCommand>
{
    public Task Handle(AdicionarPedidoCommands message, IMessageHandlerContext context)
    {
        _ = RequestTimeout<PedidoTimeOut>(context, TimeSpan.FromMilliseconds(5000));

        return context.Publish(new PedidoRecebidoEvent(message.Id));
    }

    public Task Handle(PedidoRecebidoEvent message, IMessageHandlerContext context)
    {
        return context.SendLocal(new ReservarItensDoPedidoCommand(message.Id));
    }

    public Task Handle(ReservarItensDoPedidoCommand message, IMessageHandlerContext context)
    {
        this.MarkAsComplete();

        return Task.CompletedTask;
    }

    public Task Timeout(PedidoTimeOut state, IMessageHandlerContext context)
    {
        MarkAsComplete();

        return Task.CompletedTask;
    }

    protected override void ConfigureHowToFindSaga(SagaPropertyMapper<PedidoSagaData> mapper)
    {
        mapper.ConfigureMapping<AdicionarPedidoCommands>(message => message.Id).ToSaga(saga => saga.PedidoId);
        mapper.ConfigureMapping<PedidoRecebidoEvent>(message => message.Id).ToSaga(saga => saga.PedidoId);
        mapper.ConfigureMapping<ReservarItensDoPedidoCommand>(message => message.Id).ToSaga(saga => saga.PedidoId);
    }
}
