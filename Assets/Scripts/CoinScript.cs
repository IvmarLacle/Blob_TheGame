using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int scoreWorth;
    public AudioClip pickUp;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            Collect();
    }

    private void Collect()
    {
        GameManager.instance.score += scoreWorth;
        AudioSource.PlayClipAtPoint(pickUp, transform.position, 1f);
        Destroy(gameObject);
    }
}
