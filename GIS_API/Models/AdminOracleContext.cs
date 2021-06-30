
using System.Data.Entity;

namespace GIS_API.Models
{
    public partial class AdminOracleContext : DbContext
    {
        public AdminOracleContext()
            : base("name=AdminOracleContext")
        {
        }
    }

}