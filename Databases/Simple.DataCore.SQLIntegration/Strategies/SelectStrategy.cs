using System.Dynamic;

using Microsoft.Data.SqlClient;

using Simple.DataCore.SQLIntegration.Adapters;
using Simple.DataCore.SQLIntegration.Factories;

namespace Simple.DataCore.SQLIntegration.Strategies
{
    internal class SelectStrategy : ISQLReadStrategy
    {
        private readonly ISQLConnectionAdapter connection;
        private readonly ISqlCommandFactory cmdFactory;

        public SelectStrategy(ISQLConnectionAdapter connection, ISqlCommandFactory cmdFactory)
        {
            this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
            this.cmdFactory = cmdFactory ?? throw new ArgumentNullException(nameof(cmdFactory));
        }

        public IEnumerable<ExpandoObject> Execute(SQLTable table, SQLSelectParam selectParam)
        {
            List<ExpandoObject> objects = new();
            using (var cmd = cmdFactory.Create(selectParam, connection))
            {
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var obj = new ExpandoObject();
                    for (var i = 0; i < reader.FieldCount; i++)
                    {

                        obj.TryAdd(reader.GetName(i), reader[i]);
                    }
                    objects.Add(obj);
                }
            }
            return objects;
        }
    }
}
