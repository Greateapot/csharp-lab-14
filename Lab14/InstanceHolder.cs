namespace Lab14
{
    /// <summary>
    /// Универсальное решение проблем использования ссылок в анонимных функциях
    /// </summary>
    public class InstanceHolder
    {
        private static InstanceHolder? instance;
        private readonly Dictionary<Type, object> memory = [];

        private static InstanceHolder Instance => instance ??= new InstanceHolder();

        private object this[Type type]
        {
            get => !memory.TryGetValue(type, out object? result) || result == null
                ? throw new ArgumentException($"no stored instance for type {type}")
                : result!;
            set => memory[type] = value;
        }

        public static T Get<T>() => (T)Instance[typeof(T)];
        public static void Set<T>(T value) where T : notnull => Instance[typeof(T)] = value;
    }
}