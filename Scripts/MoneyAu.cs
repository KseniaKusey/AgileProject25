using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class MoneyAu : MonoBehaviour
{
        public AudioClip сoin_Plus; 

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                AudioSource.PlayClipAtPoint(сoin_Plus, transform.position);
                Destroy(gameObject);
            }
        }
    }
