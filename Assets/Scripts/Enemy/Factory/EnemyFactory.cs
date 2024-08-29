using System.IO;
using Fusion;
using UnityEngine;
using Zenject;

public class EnemyFactory
{
    private const string PrefabsPath = "Enemies";

    private const string Heavy = "Heavy";
    private const string Range = "Range";
    private const string Lite = "Lite";

    private GameObject _heavyMelly;
    private GameObject _smallMelly;
    private GameObject _range;
    private IInstantiator _instantiator;

    public EnemyFactory(IInstantiator instantiator)
    {
        _instantiator = instantiator;
        Load();
        Debug.LogError($"Heavy: {_heavyMelly is null}");
        Debug.LogError($"Range: {_range is null}");
        Debug.LogError($"Small: {_smallMelly is null}");
    }

    public GameObject Spawn(EnemyType type, Transform transform, NetworkBehaviour b)
    {
        GameObject prefab = type switch
        {
            EnemyType.Range => _range,
            EnemyType.HeavyMelly => _heavyMelly,
            EnemyType.LiteMelly => _smallMelly,
            _ => null,
        };
        return prefab;
    }

    private void Load()
    {
        _heavyMelly = Resources.Load<GameObject>(Path.Combine(PrefabsPath, Heavy));
        _range = Resources.Load<GameObject>(Path.Combine(PrefabsPath, Range));
        _smallMelly = Resources.Load<GameObject>(Path.Combine(PrefabsPath, Lite));
    }
}
