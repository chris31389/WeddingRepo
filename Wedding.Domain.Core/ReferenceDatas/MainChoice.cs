namespace Wedding.Domain.Core.ReferenceDatas
{
    public class MainChoice : ExtendedReferenceData
    {
        protected MainChoice() : base()
        {
        }

        public MainChoice(string value, string secondaryValue) 
            : base(value, secondaryValue)
        {
        }
    }
}