using System;

namespace Wedding.Domain.Core.ReferenceDatas
{
    public abstract class ReferenceData : Entity
    {
        public string Value { get; private set; }
         
        protected ReferenceData()
        {
        }

        protected ReferenceData(string value)
        {
            Id = Guid.NewGuid();
            Value = value;
        }
    }
}