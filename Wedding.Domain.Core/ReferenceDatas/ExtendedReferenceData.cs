namespace Wedding.Domain.Core.ReferenceDatas
{
    public abstract class ExtendedReferenceData : ReferenceData
    {
        public string SecondaryValue { get; private set; }

        protected ExtendedReferenceData() : base()
        {
        }

        protected ExtendedReferenceData(string value, string secondaryValue) 
            : base(value)
        {
            SecondaryValue = secondaryValue;
        }
    }
}