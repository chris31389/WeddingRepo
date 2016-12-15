namespace Wedding.Common.Core
{
    public interface IAggregateMember<T>
    {
        T Parent { get; }
    }
}