using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Astronaut : Entity
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private int health;
    [SerializeField] private float jumpForce = 5f;

    [Header("Health UI")]
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite aliveHeart;
    [SerializeField] private Sprite deadHeart;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer render;
    private bool isGrounded = false;

    public static Astronaut Instance { get; set; }

    public AudioClip damageSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Awake()
    {
        lives = 5;
        health = lives;
        rb = GetComponent<Rigidbody2D>();
        render = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Instance = this;
    }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    void Update()
    {
        if (isGrounded)
            State = States.idle;
        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
        if (health > lives)
            health = lives;

        UpdateHeartsUI();
        if (transform.position.y < -17f)
            lives -= 5;

    }

    private void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = aliveHeart;
            else
                hearts[i].sprite = deadHeart;

            if (i < lives)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }

    private void Run()
    {
        if (isGrounded) State = States.run;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        render.flipX = dir.x < 0.0f;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] colider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = colider.Length > 1;
        if (!isGrounded) State = States.jump;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.CompareTag("Enemy"))&&(lives <=1))
        {
            GameManager.instance.Lose();
            GetComponent<Astronaut>().enabled = false;
        }
    }

    public override void GetDamage(int damage = 1)
    {
        lives -= 1;
        Debug.Log(lives);
        if (damageSound != null)
        {
            audioSource.PlayOneShot(damageSound);
        }

    }
}

public enum States
{
    idle,
    run,
    jump
}