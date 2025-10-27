using System.Collections;
using UnityEngine;

public class PlayerChaser : MonoBehaviour
{
    [SerializeField] private Transform _spaceCheck;
    [SerializeField] private float _spaceCheckRadius;
    [SerializeField] private LayerMask _playerLayer;

    private float _updateInterval = 0.1f;
    private Transform _player;
    private bool _isPlayerClose;

    public bool IsPlayerClose => _isPlayerClose;

    private void Start()
    {
        StartCoroutine(CheckSpace());
    }

    private void OnDrawGizmosSelected()
    {
        if (_spaceCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_spaceCheck.position, _spaceCheckRadius);
        }
    }

    public float SetDirectionToPlayer(Vector2 currentPosition)
    {
        float direction;

        if (_isPlayerClose && _player != null)
        {
            direction = Mathf.Sign(_player.position.x - currentPosition.x);
            return direction;
        }

        return 0f;
    }

    private IEnumerator CheckSpace()
    {
        var wait = new WaitForSeconds(_updateInterval);

        while (enabled)
        {
            Collider2D playerCollider = Physics2D.OverlapCircle(_spaceCheck.position, _spaceCheckRadius, _playerLayer);

            if (playerCollider != null)
            {
                _isPlayerClose = true;
                _player = playerCollider.transform;
            }
            else
            {
                _isPlayerClose = false;
                _player = null;

            }
            yield return wait;
        }
    }
}
