namespace IronFoundry.Model
{
    public interface IMergeable<T>
    {
        void Merge(T obj);
    }
}