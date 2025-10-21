using System.Collections;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _groundLayer;

    private float _updateInterval = 0.1f;
    private bool _isGrounded;
    public bool IsGrounded => _isGrounded;

    private void Start()
    {
        StartCoroutine(CheckGround());
    }

    private void OnDrawGizmosSelected()
    {
        if (_groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
        }
    }

    private IEnumerator CheckGround()
    {
        while (enabled)
        {
            _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);

            yield return new WaitForSeconds(_updateInterval);
        }
    }
}
