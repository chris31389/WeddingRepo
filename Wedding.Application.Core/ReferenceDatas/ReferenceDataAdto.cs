using System;
using Wedding.Domain.Core.ReferenceDatas;

namespace Wedding.Application.Core.ReferenceDatas
{
    public class ReferenceDataAdto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ReferenceDataAdto()
        {
        }

        public ReferenceDataAdto(ReferenceData referenceData)
        {
            Id = referenceData.Id;
            Name = referenceData.Value;
        }
    }
}