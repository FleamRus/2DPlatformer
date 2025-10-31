using UnityEngine;

[System.Serializable]
public class SpawnArea
{
    public Transform AreaCenter;
    public Vector2 Size;
}

public class InterctiveObjectSpawner : MonoBehaviour
{
    [SerializeField] private TouchTracking _objectFeel;
    [SerializeField] private GameObject _coin;
    [SerializeField] private int _spawnCountCoin = 4;
    [SerializeField] private GameObject _medicalKit;
    [SerializeField] private int _spawnCountKit = 2;
    [SerializeField] private SpawnArea[] _spawnArea;

    private void Start()
    {
        SpawnCoin();
        SpawnKit();
    }

    private void OnEnable()
    {
        _objectFeel.ObjectTouched += DeleteInteractiveObject;
    }

    private void OnDisable()
    {
        _objectFeel.ObjectTouched += DeleteInteractiveObject;
    }

    private void OnDrawGizmosSelected()
    {
        if (_spawnArea == null)
            return;

        Gizmos.color = Color.yellow;
        foreach (var area in _spawnArea)
        {
            if (area != null && area.AreaCenter != null)
            {
                Gizmos.DrawWireCube(area.AreaCenter.position, area.Size);
            }
        }
    }

    private void Spawn(GameObject gameObject)
    {
        int beginIndex = 0;
        int symmetricalInsex = 2;

        if (_spawnArea.Length == 0)
            return;

        int areaIndex = Random.Range(beginIndex, _spawnArea.Length);
        SpawnArea area = _spawnArea[areaIndex];

        Vector2 randomPosition = new(
            Random.Range(-area.Size.x / symmetricalInsex, area.Size.x / symmetricalInsex),
            Random.Range(-area.Size.y / symmetricalInsex, area.Size.y / symmetricalInsex));


        Vector2 spawnPosition = (Vector2)area.AreaCenter.position + randomPosition;

        Instantiate(gameObject, spawnPosition, Quaternion.identity);
    }

    private void DeleteInteractiveObject(Collider2D collider)
    {
        if (collider.TryGetComponent(out Coin coin))
        {
            Destroy(coin.gameObject);
        }

        if (collider.TryGetComponent(out MedicalKit kit))
        {
            Destroy(kit.gameObject);
        }
    }

    private void SpawnCoin()
    {
        for (int i = 0; i < _spawnCountCoin; i++)
        {
            Spawn(_coin);
        }
    }

    private void SpawnKit()
    {
        for (int i = 0; i < _spawnCountKit; i++)
        {
            Spawn(_medicalKit);
        }
    }
}
