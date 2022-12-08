using Simple.DataCore.SQLIntegration.Adapters;
using Simple.DataCore.SQLIntegration.Strategies;

namespace Simple.DataCore.SQLIntegration.Factories
{
    internal interface ISqlCommandFactory : IDisposable
    {
        ISqlCommandAdapter Create(SQLSelectParam selectParam, ISQLConnectionAdapter connectionAdapter);
    }
}
