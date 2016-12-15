using System;
using System.Collections.Generic;

namespace Wedding.Domain.Core.ReferenceDatas
{
    public interface IDessertChoiceRepository
    {
        DessertChoice GetById(Guid id);

        IEnumerable<DessertChoice> GetAll();
    }
}