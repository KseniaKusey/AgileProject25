using UnityEngine;

public class movements : MonoBehaviour
{

    [SerializeField] private float speed = 3f;    
    [SerializeField] private float jumpForce = 15f;    
    private bool isGrounded = false;
    private Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (Mathf.Abs(rb.velocity.y) < 0.005f && Input.GetButtonDown("Jump"))
            Jump();

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        CheckGround();

        
    }
    
    private void Run()
    { 
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;
    }
    
}