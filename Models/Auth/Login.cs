using System.ComponentModel.DataAnnotations;

namespace NetCoreApis_Mssql_Docker.Models.Auth
{
    public class Login
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}