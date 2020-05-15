using NetCoreApis_Mssql_Docker.Models.Auth;

public interface IAuthService
{
    string Login(Login req);
}