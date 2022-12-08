using Microsoft.Data.SqlClient;

namespace Simple.DataCore.SQLIntegration.Adapters
{
    internal interface ISQLConnectionAdapter
    {
        SqlConnection sqlConnection { get; }
    }
}
