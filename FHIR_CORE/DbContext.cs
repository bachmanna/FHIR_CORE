using Microsoft.EntityFrameworkCore;

namespace FHIR_CORE
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
    }
}
    
