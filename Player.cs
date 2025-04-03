using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Movements move;
    void Start()
    {
        move = GetComponent<Movements>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
    }

}
