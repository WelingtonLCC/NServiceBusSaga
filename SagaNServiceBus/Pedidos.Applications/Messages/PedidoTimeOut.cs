namespace Pedidos.Applications.Messages;

public class PedidoTimeOut : IMessage
{
    public Guid Id { get; set; }
}
