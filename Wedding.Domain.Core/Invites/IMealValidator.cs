namespace Wedding.Domain.Core.Invites
{
    public interface IMealValidator
    {
        bool Validate(bool isAdult, CreateMealDdto createMealDdto);
    }
}