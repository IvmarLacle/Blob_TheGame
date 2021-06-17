using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAudio : MonoBehaviour
{
  public AudioClip audioClip;
  
  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Player"))
        AudioSource.PlayClipAtPoint(audioClip, transform.position, 1f);
  }
}
