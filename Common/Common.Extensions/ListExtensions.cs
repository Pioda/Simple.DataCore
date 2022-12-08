namespace Common.Extensions
{
    public static class ListExtensions
    {
        public static Queue<T> AsQueue<T>(this IEnumerable<T> list)
        {
            var queue = new Queue<T>();
            foreach (var item in list)
            {
                queue.Enqueue(item);
            }

            return queue;
        }
    }
}