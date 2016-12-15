using System;
using Wedding.Domain.Core.ReferenceDatas;

namespace Wedding.Domain.Core.Invites
{
    public class CreateMealDdto
    {
        public Guid InviteeId { get; set; }

        public StarterChoice StarterChoice { get; set; }

        public MainChoice MainChoice { get; set; }
        
        public DessertChoice DessertChoice { get; set; }

        public string DietaryRequirements { get; set; }
    }
}