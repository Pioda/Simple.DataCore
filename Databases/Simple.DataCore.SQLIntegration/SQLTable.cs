namespace Simple.DataCore.SQLIntegration
{
    internal class SQLTable
    {
        public SQLTable(string tableName)
        {
            TableName = tableName;
        }

        public string TableName { get; private set; }

    }
}
