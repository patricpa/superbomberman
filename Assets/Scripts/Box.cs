using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject[] powerUps;

    public void SpawnPowerUp()
    {
        //15% prob. of spawning a powerup
        if(Random.Range(0f, 1f) > 0.85)
        {
            int randomindex = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[randomindex], transform.position, Quaternion.identity);

        }
    }
    
}
