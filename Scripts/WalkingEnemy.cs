using UnityEngine;

public class WalkingEnemy : Entity
{
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float patrolDistance = 5f; 

    private Vector3 pointA;
    private Vector3 pointB;
    private Vector3 targetPoint;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {

        pointA = transform.position;
        pointB = pointA + Vector3.right * patrolDistance;

        targetPoint = pointB;
        lives = 5;
    }

    private void Update()
    {
        Move();
        UpdateSpriteDirection();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
        {
            targetPoint = (targetPoint == pointA) ? pointB : pointA;
        }
    }

    private void UpdateSpriteDirection()
    {
        sr.flipX = (targetPoint == pointA);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Astronaut.Instance.gameObject)
        {
            Astronaut.Instance.GetDamage();
            lives--;
            Debug.Log("lives_alien" + lives);
        }
        if (lives < 1)
            Die();
    }
}


