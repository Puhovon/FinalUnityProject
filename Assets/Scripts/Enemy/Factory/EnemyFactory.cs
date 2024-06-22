using UnityEngine;

public class EnemyFactory
{
    private GameObject _heavyMelly;
    private GameObject _smallMelly;
    private GameObject _range;

    public EnemyFactory(GameObject heavyMelly, GameObject smallMelly, GameObject range)
    {
        _heavyMelly = heavyMelly;
        _smallMelly = smallMelly;
        _range = range;
    }

    public GameObject Spawn(EnemyType type, Transform transform) => type switch
    {
        EnemyType.Range => GameObject.Instantiate(_range, transform.position, Quaternion.identity),
        EnemyType.HeavyMelly => GameObject.Instantiate(_heavyMelly, transform.position, Quaternion.identity),
        EnemyType.LiteMelly => GameObject.Instantiate(_smallMelly, transform.position, Quaternion.identity),
        _ => null,
    };
}
