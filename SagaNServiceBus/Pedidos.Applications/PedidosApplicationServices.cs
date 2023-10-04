namespace Pedidos.Applications;

public class PedidosApplicationServices : IPedidosApplicationServices
{
    private readonly IPedidosRepository _repository;

    public PedidosApplicationServices(IPedidosRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<string>> Add(InsertPrimaryValue? insertValue)
    {
        List<string> processos = new List<string>();

        processos.Add("Processo Iniciado");

        var endPointConfiguration = new EndpointConfiguration("ExemploSaga.Pedidos");

        endPointConfiguration.SendFailedMessagesTo("ExemploSaga.Pedidos.Errors");

        endPointConfiguration.UsePersistence<LearningPersistence>();
        endPointConfiguration.UseSerialization<SystemJsonSerializer>();
        endPointConfiguration.EnableInstallers();

        endPointConfiguration.Sagas();

        var transport = endPointConfiguration.UseTransport<RabbitMQTransport>()
            .UseConventionalRoutingTopology(QueueType.Quorum);
        transport.ConnectionString("host=localhost");

        var endpoint = await Endpoint.Start(endPointConfiguration).ConfigureAwait(false);

        var adicionarPedido = new AdicionarPedidoCommands(Guid.NewGuid(), "Heber");

        await endpoint.SendLocal(adicionarPedido);

        processos.Add("Processo Finalizado SAGA");

        return processos;
    }
}
