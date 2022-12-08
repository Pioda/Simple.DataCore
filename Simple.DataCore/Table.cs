using System.Dynamic;

namespace Simple.DataCore
{
    internal class Table : DynamicObject
    {
        public Table(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            }

            Name = name;
        }

        public string Name { get; private set; }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
        {
            return base.TryInvokeMember(binder, args, out result);
        }

    }

}
