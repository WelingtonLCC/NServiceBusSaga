using Pagamentos.Applications.DataTransferObjects;
using Pagamentos.Infra.Repositories;

namespace Pagamentos.Applications;

public class PagamentoApplicationServices : IPagamentoApplicationServices
{
 
    public PagamentoApplicationServices()
    {
        
    }

    public async Task Add(PagamentoInputModel? insertValue)
    {
        var InsertPrimaryValue = insertValue;
    }
}
