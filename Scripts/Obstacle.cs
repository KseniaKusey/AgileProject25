using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == Astronaut.Instance.gameObject)
        {
            Astronaut.Instance.GetDamage();
        }
    }

}
