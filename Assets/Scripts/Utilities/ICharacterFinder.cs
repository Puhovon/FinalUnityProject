using System.Collections.Generic;
using Abstractions;

namespace Utilities
{
    public interface ICharacterFinder
    {
        IEnumerable<IEntity> Find();
    }
}