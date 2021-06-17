using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMove : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform[] waypoints;

    public AudioClip audioClip;
    private int waypointIndex = 0;
    
    // Start is called before the first frame update
    void Start() =>
        transform.position = waypoints[waypointIndex].transform.position;
    

    // Update is called once per frame
    void Update() =>
        Move();

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex].transform.position)
            waypointIndex += 1;
        
        if (waypointIndex == waypoints.Length)
            waypointIndex = 0;
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Weapon"))
        {
            AudioSource.PlayClipAtPoint(audioClip,transform.position,.4f);
            Destroy(gameObject);
        }
            
    }
}
