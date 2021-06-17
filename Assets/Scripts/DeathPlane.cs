using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    public AudioClip death;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(death,transform.position, .5f);
            GameManager.instance.Respawn();
        }
            
    }
}
