using System.Dynamic;

namespace Simple.DataCore
{
    public class Database : DynamicObject
    {
        public static dynamic Open()
        {
            return new Database();
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
        {
            return base.TryInvokeMember(binder, args, out result);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            if (base.TryGetMember(binder, out result)) return true;

            result = new Table(binder.Name);
            return true;
        }
    }

    internal interface IDataProvider
    {
        void RunCommand(ICommand cmd);
        Task RunCommandAsync(ICommand cmd);
    }

    internal abstract class DataProvider : DynamicObject, IDataProvider
    {
        protected string ConnectionString { get; private set; }
        public DataProvider(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void RunCommand(ICommand cmd)
        {
            throw new NotImplementedException();
        }

        public abstract void RunCommandInternal(ICommand cmd);

        public Task RunCommandAsync(ICommand cmd)
        {
            throw new NotImplementedException();
        }
        public abstract Task RunCommandInternalAsync(ICommand cmd);
    }

    internal interface ICommand
    {

    }
}