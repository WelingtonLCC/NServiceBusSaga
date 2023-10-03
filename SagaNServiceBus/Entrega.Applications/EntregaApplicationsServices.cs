using Entregas.Applications.DataTransferObjects;
using Entregas.Infra.Repository;

namespace Entregas.Applications;

public class EntregaApplicationsServices : IEntregaApplicationsServices
{
   

    public EntregaApplicationsServices()
    {
        
    }

    public async Task Add(EntregaInputModel? insertValue)
    {
        var InsertPrimaryValue = insertValue;
    }
}
