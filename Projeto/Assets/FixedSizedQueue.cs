using System.Collections.Concurrent;
using System.Linq;

public class FixedSizedQueue<T>
{
    ConcurrentQueue<T> q = new ConcurrentQueue<T>();
    private object lockObject = new object();

    public int Limit { get; set; }
    public void Enqueue(T obj)
    {
        q.Enqueue(obj);
        lock (lockObject)
        {
            T overflow;
            while (q.Count > Limit && q.TryDequeue(out overflow)) ;
        }
    }

    public T GetElementAt(int i) => q.ElementAt(i);
}