namespace Wedding.Domain.Core.ReferenceDatas
{
    public class StarterChoice : ExtendedReferenceData
    {
        protected StarterChoice() : base()
        {
        }

        public StarterChoice(string value, string secondaryValue) 
            : base(value, secondaryValue)
        {
        }
    }
}