using NetCoreApis_Mssql_Docker.Database;

namespace NetCoreApis_Mssql_Docker.Repositorys.Impl
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DatabaseContext _db;
        public AuthRepository(DatabaseContext databaseContext)
        {
            _db = databaseContext;
        }
    }
}