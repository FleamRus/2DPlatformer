using UnityEngine;

public class UIFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        if (_target != null)
        {
            transform.position = _target.position + _offset;
            transform.rotation = Quaternion.identity;
        }
    }
}