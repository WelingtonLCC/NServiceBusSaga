using Pagamentos.Applications.DataTransferObjects;

namespace Pagamentos.Applications;

public interface IPagamentoApplicationServices
{
    Task Add(PagamentoInputModel? insertValue);
}
