using UnityEngine;

public class InterctiveObjectSpawner : MonoBehaviour
{
    [SerializeField] private ObjectFeel _objectFeel;
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform[] _coinSpawnPonts;

    private void Start()
    {
        SpawnCoin();
    }

    private void OnEnable()
    {
        _objectFeel.ObjectTouched += DeleteCoin;
    }

    private void OnDisable()
    {
        _objectFeel.ObjectTouched += DeleteCoin;
    }

    private void SpawnCoin()
    {
        for (int i = 0; i < _coinSpawnPonts.Length; i++)
        {
            Instantiate(_coin, _coinSpawnPonts[i]);
        }
    }

    private void DeleteCoin(Collider2D collider)
    {
        if (collider.TryGetComponent(out Coin coin))
        {
            Destroy(coin.gameObject);
        }
    }
}
