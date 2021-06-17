using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnHazard : MonoBehaviour
{
    [SerializeField] private GameObject proHazard;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnDelay;
    [SerializeField] private bool stopSpawn = false;
    
    
    // Start is called before the first frame update
    void Start() =>
        InvokeRepeating("SpawnProjectile", spawnTime, spawnDelay);
    


    void SpawnProjectile()
    {
        Instantiate(proHazard, transform.position, quaternion.identity);

        if (stopSpawn)
            CancelInvoke("SpawnProjectile");
    }
    

}
