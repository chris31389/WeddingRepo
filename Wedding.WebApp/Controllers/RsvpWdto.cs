using System.Collections.Generic;

namespace Wedding.WebApp.Controllers
{
    public class RsvpWdto
    {
        public string Email { get; set; }

        public IEnumerable<IndividualRsvpWdto> IndividualRsvps { get; set; }
    }
}