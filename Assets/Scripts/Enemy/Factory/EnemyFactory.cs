using System.IO;
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
    }

    public GameObject Spawn(EnemyType type, Transform transform) => type switch
    {
        EnemyType.Range => _instantiator.InstantiatePrefab(_range, transform.position, Quaternion.identity, null),
        EnemyType.HeavyMelly => _instantiator.InstantiatePrefab(_heavyMelly, transform.position, Quaternion.identity, null),
        EnemyType.LiteMelly => _instantiator.InstantiatePrefab(_smallMelly, transform.position, Quaternion.identity, null),
        _ => null,
    };

    private void Load()
    {
        _heavyMelly = Resources.Load<GameObject>(Path.Combine(PrefabsPath, Heavy));
        _range = Resources.Load<GameObject>(Path.Combine(PrefabsPath, Range));
    }
}
