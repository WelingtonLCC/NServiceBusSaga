namespace Pedidos.Applications.Commands;

public class ReservarItensDoPedidoCommand : ICommand
{
    public Guid Id { get; set; }

    public ReservarItensDoPedidoCommand(Guid id)
    {
        this.Id = id;
    }
}
