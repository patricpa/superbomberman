using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int bombs;
    public int firePower;
    public int speed;

    GameController gameController;
    public void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        gameController.level[(int)transform.position.x, (int)transform.position.y] = gameObject;

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        { 
            //get reference of components
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            BombSpawner BombSpawner = collision.gameObject.GetComponent<BombSpawner>();

            //Adjust values
            //There is a max. movement speed
            if((playerController.speed+speed) < 15)
            {
                playerController.speed += speed;
            }
            else playerController.speed = Mathf.Clamp((playerController.speed+speed), 5, 15);
            
            BombSpawner.numberOfBombs += bombs;
            BombSpawner.firePower += firePower;

            Destroy(gameObject);
        }
    }
}
