using System;
using System.Collections.Generic;
using System.Text;

namespace Authorization.Core.Interfaces
{
    public interface IRepositoryWrapper
    {
        ITagsRepository Tags { get; }
    }
}
