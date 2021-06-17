using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalAudio : MonoBehaviour
{
    public AudioSource aS;

    private void Awake() =>
        aS = GetComponent<AudioSource>();
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            aS.Play();
    }
}
