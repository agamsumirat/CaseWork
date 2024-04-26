using CaseWork.Model.BodyRequest;
using CaseWork.Repository.IGlobalParameterRepository;
using CaseWork.Utils.DatabaseHelper;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CaseWork.RepositoryImpl
{
    public class GlobalParameterRepository : IGlobalParameterRepository
    {
        private readonly IDbConnection sqlConnection;

        public GlobalParameterRepository(IDbConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public void UpdateGlobalParameter(GlobalParameterUpdateRequest BodyRequest)
        {
            var query = $@"update GlobalParameter set ValueParameter=@ValueParameter where Id=@Id";
            var param = new
            {
                BodyRequest.Id,
                BodyRequest.ValueParameter
            };
            sqlConnection.Execute(query, param);
        }
    }
}
