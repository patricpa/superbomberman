using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bomb;
    public GameObject PlayerController;

    public int firePower = 2;
    public int numberOfBombs = 1;
    public float fuse = 2;
    private int old_movementcounter = -1;

    // Update is called once per frame
    void Update()
    {
        //check if player has moved since he recently  droped a bomb. If not, he cannot deploy another bomb on top of the existing one!
        if(Input.GetButtonDown("Jump") && (numberOfBombs) >= 1  && (old_movementcounter != PlayerController.GetComponent<PlayerController>().getMovementCounter()))
        {
            //Bombs only spawn on grid!
            Vector2 spawnPos = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
            var newBomb = Instantiate(bomb, spawnPos, Quaternion.identity) as GameObject;
            old_movementcounter = PlayerController.GetComponent<PlayerController>().getMovementCounter();
            newBomb.GetComponent<Bomb>().firePower = firePower;
            newBomb.GetComponent<Bomb>().fuse = fuse;
            numberOfBombs--;
            //Get bomb after one second
            Invoke("AddBomb", fuse);
        }
        
    }

    public void AddBomb()
    {
        numberOfBombs++;
    }
}
