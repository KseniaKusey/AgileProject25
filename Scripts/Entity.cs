using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
public class Entity : MonoBehaviour
{
    protected int lives;
    public int Lives => lives;
    
     void Start()
    {

    }
    public virtual void GetDamage(int damage = 1)
    {
        lives -= damage;
        if (lives == 0)
            Die();
    }
    public virtual void Die()
    {
        Destroy(this.gameObject);
        
    }
}
