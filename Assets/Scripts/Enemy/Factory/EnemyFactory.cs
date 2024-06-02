using System;
using UnityEngine;

public class EnemyFactory
{
    private EnemyConfigs _heavyMelly;
    private EnemyConfigs _smallMelly;
    private EnemyConfigs _range;

    public EnemyFactory(EnemyConfigs heavyMelly, EnemyConfigs smallMelly, EnemyConfigs range)
    {
        _heavyMelly = heavyMelly;
        _smallMelly = smallMelly;
        _range = range;
    }

    public EnemyConfigs GetConfig(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.HeavyMelly:
                return _heavyMelly;
            case EnemyType.LiteMelly
                : return _smallMelly;
            case EnemyType.Range
                : return _range;
            default: throw new ArgumentNullException(nameof(type));
        }
    }
}
