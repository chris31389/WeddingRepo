namespace Wedding.Domain.Core.Tests
{
    public class AggregateMember : Member<object>
    {
        public AggregateMember(object parent) 
            : base(parent)
        {
        }
    }
}