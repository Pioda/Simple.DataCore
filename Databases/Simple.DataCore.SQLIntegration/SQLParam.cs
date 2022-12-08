namespace Simple.DataCore.SQLIntegration
{
    internal record SQLParam
    {
        public SQLParam(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or empty.", nameof(value));
            }

            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Name} = '{Value}'";
        }

        public string Name { get; private set; }
        public string Value { get; private set; }
    }
}