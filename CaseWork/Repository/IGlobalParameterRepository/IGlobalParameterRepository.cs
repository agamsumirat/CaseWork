using CaseWork.Model.BodyRequest;

namespace CaseWork.Repository.IGlobalParameterRepository
{
    public interface IGlobalParameterRepository
    {
        void UpdateGlobalParameter(GlobalParameterUpdateRequest BodyRequest);
    }
}
