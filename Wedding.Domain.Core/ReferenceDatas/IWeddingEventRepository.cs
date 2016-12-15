using System;
using System.Collections.Generic;

namespace Wedding.Domain.Core.ReferenceDatas
{
    public interface IWeddingEventRepository
    {
        WeddingEvent GetById(Guid id);
        IEnumerable<WeddingEvent> GetAll();
    }
}