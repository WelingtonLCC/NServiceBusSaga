namespace Pedidos.Applications.Events;

public class PedidoRecebidoEvent : IEvent
{
    public Guid Id { get; set; }

    public PedidoRecebidoEvent()
    {
    }

    public PedidoRecebidoEvent(Guid id)
    {
        this.Id = id;
    }
}
