using System;
using System.Collections.Generic;

namespace Wedding.Domain.Core.ReferenceDatas
{
    public interface IMainChoiceRepository
    {
        MainChoice GetById(Guid id);

        IEnumerable<MainChoice> GetAll();
    }
}