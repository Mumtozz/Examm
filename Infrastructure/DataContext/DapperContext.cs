using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext
{
    private readonly IConfiguration configuration;
    public DapperContext(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }
}
