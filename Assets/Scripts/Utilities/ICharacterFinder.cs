using System.Collections.Generic;
using Assets.Scripts.Abstractions;

namespace Utilities
{
    public interface ICharacterFinder
    {
        IEnumerable<IEntity> Find();
    }
}