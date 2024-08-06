using System.IO;
using Assets.Scripts.Enemy;
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

    public GameObject Spawn(EnemyType type, Transform transform, Transform[] patrollingPoints)
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
        
        
        
        var obj = _instantiator.InstantiatePrefab(prefab, transform.position, Quaternion.identity, null);
        obj.GetComponent<Transformer>().Construct(patrollingPoints);
        return obj;
    }

    private void Load()
    {
        _heavyMelly = Resources.Load<GameObject>(Path.Combine(PrefabsPath, Heavy));
        _range = Resources.Load<GameObject>(Path.Combine(PrefabsPath, Range));
    }
}
