using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    // Variables for laser movement
    [SerializeField] private float projectileSpeed;
    public Rigidbody2D rbProjectile;
    
    void Update()
    {
        rbProjectile.velocity = transform.right * projectileSpeed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
            Destroy(gameObject);
    }
}
