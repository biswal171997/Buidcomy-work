using System.Collections.Generic;
using System.Threading.Tasks;
using BUIDCO.Domain.AdminConsole.Function_Master;

namespace BUIDCO.Repository.Contract.Contract.AdminConsole.Function_Master
{
    public interface IFuncServiceProvider
    {
        int ActiveFunction(FunctionMaster objFunctionMaster);
        int AddFunction(FunctionMaster objFunctionMaster);
        int EditFunction(FunctionMaster objFunctionMaster);
        IList<FunctionMaster> GetAllFunction(FunctionMaster objFunctionMaster);
        int DeleteFuncImage(string actionCode, int funcId);
        IList<FunctionMaster> GetFunctionId(string userId);
        string GetFunctionData(int intFuncId);
        Task<FunctionModel> GetFunction();
        IList<FunctionMaster> GetFunctionDetails(FunctionMaster objFunctionMaster);
    }
}