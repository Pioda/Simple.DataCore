using System.Dynamic;

using Simple.DataCore.SQLIntegration.Strategies;

namespace Simple.DataCore.SQLIntegration
{
    internal interface ISQLReadStrategy
    {
        IEnumerable<ExpandoObject> Execute(SQLTable table,SQLSelectParam selectParam);
    }
}
