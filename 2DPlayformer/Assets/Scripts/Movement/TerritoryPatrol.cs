using UnityEngine;

public class TerritoryPatrol : MonoBehaviour
{
    private float _directionMove;

    public float SetTerritoyPatrol(Transform currentTarget)
    {
        Vector3 direction = (currentTarget.position - transform.position).normalized;
        return _directionMove = Mathf.Sign(direction.x);
    }
}
