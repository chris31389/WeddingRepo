using Wedding.Domain.Core.ReferenceDatas;

namespace Wedding.Application.Core.ReferenceDatas
{
    public class ExtendedReferenceDataAdto : ReferenceDataAdto
    {
        public string SecondaryValue { get; set; }

        public ExtendedReferenceDataAdto(ExtendedReferenceData extendedReferenceData) 
            : base(extendedReferenceData)
        {
            SecondaryValue = extendedReferenceData.SecondaryValue;
        }
    }
}