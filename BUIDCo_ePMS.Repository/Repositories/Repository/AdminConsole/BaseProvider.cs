using BUIDCO.Repository.AdminConsole.SqlHelper;

namespace BUIDCO.Repository.AdminConsole
{
    public class BaseProvider
    {
        public BaseProvider(IDataBaseHelper dataBaseHelper)
        {
            DataBaseHelper = dataBaseHelper;
        }

        public IDataBaseHelper DataBaseHelper { get; }
    }
}
