using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    private int score = 0;

    [SerializeField]
    private TMP_Text textMeshPro;

    private void Start()
    {
        textMeshPro.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            score++;
            Destroy(collision.gameObject);
            textMeshPro.text = score.ToString();
        }
        else if(collision.gameObject.tag == "Diamonds")
        {
            score += 3;
            Destroy(collision.gameObject);
            textMeshPro.text = score.ToString();
        }
    }
}