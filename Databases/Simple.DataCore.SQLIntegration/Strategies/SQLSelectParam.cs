using System.Text;

using Common.Extensions;

namespace Simple.DataCore.SQLIntegration.Strategies
{
    internal record SQLSelectParam
    {
        public SQLSelectParam(IReadOnlyList<string> selects, IReadOnlyList<SQLParam> paramList)
        {
            Selects = selects;
            ParamList = paramList;
        }

        public IReadOnlyList<string> Selects { get; private set; }
        public IReadOnlyList<SQLParam> ParamList { get; private set; }

        public string GetSqlSelectStatement()
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");

            var selectQueue = Selects.AsQueue();
            while (selectQueue.TryDequeue(out var s))
            {
                if (!string.IsNullOrEmpty(selectQueue.Peek()))
                    builder.Append($"{s} ");
                else
                    builder.Append($"{s}, ");
            }

            builder.Append("WHERE ");

            var paramQueue = ParamList.AsQueue();
            while(paramQueue.TryDequeue(out var p))
            {
                if (paramQueue.Peek == null)
                    builder.Append(p);
                else
                    builder.Append($"{p} AND ");
            }

            return builder.ToString();
        }

        public static implicit operator string (SQLSelectParam sqlSelectParam) => sqlSelectParam.GetSqlSelectStatement();
    }
}
