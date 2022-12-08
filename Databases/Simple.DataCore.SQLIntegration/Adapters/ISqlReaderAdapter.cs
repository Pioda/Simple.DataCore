using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Simple.DataCore.SQLIntegration.Adapters
{
    internal interface ISqlReaderAdapter : IDisposable
    {
        bool Read();
        string GetName(int index);
        int FieldCount { get; }
        object this[int index] { get; }
    }
}
