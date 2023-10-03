namespace Pedidos.Applications.Commands;

public class AdicionarPedidoCommands : ICommand
{
    public Guid Id { get; set; }
    public string Cliente { get; set; }

    public AdicionarPedidoCommands()
    {

    }
    public AdicionarPedidoCommands(Guid id, string cliente)
    {
        this.Id = id;
        Cliente = cliente;
    }
}
