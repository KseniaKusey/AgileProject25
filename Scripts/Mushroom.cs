using UnityEngine;

public class Mushroom : Entity
{
    private void Start()
    {
        lives = 3;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Astronaut.Instance.gameObject)
        {
            Astronaut.Instance.GetDamage();
            lives--;
            Debug.Log("lives" + lives);
        }
        if (lives < 1)
            Die();
    }
}
