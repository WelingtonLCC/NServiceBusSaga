namespace Pedidos.Applications;

public interface IPedidosApplicationServices
{
    Task<List<string>> Add(InsertPrimaryValue? insertValue);
}
