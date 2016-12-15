using System;
using System.Collections.Generic;

namespace Wedding.Domain.Core.ReferenceDatas
{
    public interface IStarterChoiceRepository
    {
        StarterChoice GetById(Guid id);

        IEnumerable<StarterChoice> GetAll();
    }
}