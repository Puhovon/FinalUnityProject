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
    }

    public GameObject Spawn(EnemyType type, Transform transform)
    {
        GameObject prefab = type switch
        {
            EnemyType.Range => _range,
            EnemyType.HeavyMelly => _heavyMelly,
            EnemyType.LiteMelly => _smallMelly,
            _ => null,
        };

        if (prefab == null)
        {
            Debug.LogError("Enemy prefab is null");
            return null;
        }
        
        if (prefab.GetComponent<NetworkObject>() == null)
        {
            Debug.LogError($"Prefab {prefab.name} does not have a NetworkObject component.");
            return null;
        }
        return _instantiator.InstantiatePrefab(prefab, transform.position, Quaternion.identity, null);
    }

    private void Load()
    {
        _heavyMelly = Resources.Load<GameObject>(Path.Combine(PrefabsPath, Heavy));
        _range = Resources.Load<GameObject>(Path.Combine(PrefabsPath, Range));
    }
}
