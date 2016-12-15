namespace Wedding.Domain.Core.ReferenceDatas
{
    public class DessertChoice : ExtendedReferenceData
    {
        protected DessertChoice() : base()
        {
        }

        public DessertChoice(string value, string secondaryValue) 
            : base(value, secondaryValue)
        {
        }
    }
}