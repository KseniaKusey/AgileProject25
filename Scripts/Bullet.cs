using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    //[SerializeField] private int damage = 1;
    [SerializeField] private float lifetime = 2f;
    private Rigidbody2D rb;
    private Vector2 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime); 
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        rb.linearVelocity = direction * speed;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Entity enemy = collision.GetComponent<Entity>();
            if (enemy != null)
            {
                enemy.GetDamage();
            }

            Destroy(gameObject); 
        }
        else if (!collision.CompareTag("Player") && !collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}