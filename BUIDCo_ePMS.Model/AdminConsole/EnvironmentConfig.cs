namespace BUIDCO.Domain.AdminConsole
{
    public interface IEnvironmentConfig
    {
        string WWWRootPath { get; set; }
    }
    public class EnvironmentConfig: IEnvironmentConfig
    {
        public EnvironmentConfig(string rootPath)
        {
            WWWRootPath = rootPath;
        }
        public string WWWRootPath { get; set; }
    }
}
