using CaseWork.Model.BodyRequest;
using CaseWork.Repository.IAppointmentRepository;
using CaseWork.Repository.IGlobalParameterRepository;
using CaseWork.RepositoryImpl;
using CaseWork.Service.GlobalParameter;
using CaseWork.Utils.DatabaseHelper;
using Microsoft.Extensions.Configuration;
using System.Transactions;

namespace CaseWork.ServiceImp.GlobalParameter
{
    public class GlobalParameterService : IGlobalParameterService
    {
        private readonly DatabaseHelper databaseHelper;

        public GlobalParameterService(IConfiguration configuration)
        {
            databaseHelper = new(configuration);
        }
        public void updateGlobalParameter(GlobalParameterUpdateRequest BodyRequest)
        {
            using var transaction = new TransactionScope();
            using var sqlConnection = databaseHelper.GetConnection();

            IGlobalParameterRepository globalParameterRepository = new GlobalParameterRepository(sqlConnection);
            globalParameterRepository.UpdateGlobalParameter(BodyRequest);
            transaction.Complete();
        }
    }
}
