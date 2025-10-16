using UnityEngine;

[ RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    private void Awake()
    {
        Collider2D collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<MoverPlayer>())
        {
            Destroy(gameObject);
        }
    }
}
