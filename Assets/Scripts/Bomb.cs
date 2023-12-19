using UnityEngine;
using System.Collections;
using System;

public class Bomb : MonoBehaviour
{
    public GameObject fire;
    public int firePower;
    public float fuse;
    GameController gc;

    Vector3[] directions = new Vector3[] { Vector3.up , Vector3.down, Vector3.left, Vector3.right };

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", fuse);
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

   public void Explode()
    {
        //prevent double explosion
        CancelInvoke("Explode");
        //Create center Fire
        Instantiate(fire, transform.position, Quaternion.identity);

        //create rest of fire
        foreach (var direction in directions)
        {
            SpawnFire(direction);
        }

        //Remove bomb
        Destroy(gameObject);
    }

    private void SpawnFire(Vector3 offset, int fire = 1)
    {
        //calculate fire pos.
        int x = (int)transform.position.x + (int)offset.x * fire;
        int y = (int)transform.position.y + (int)offset.y * fire;

        x = Mathf.Clamp(x, 0, GameController.X - 1);
        y = Mathf.Clamp(y, 0, GameController.Y - 1);


        //Check if space is avaiable for fire spawning
        if (gc.level[x,y] == null && fire < firePower)
        {
            Instantiate(this.fire, transform.position + (offset * fire), Quaternion.identity);

            //recursive call 
            SpawnFire(offset, ++fire);
        }

        else if(fire < firePower)
        {
                //check whether object ist destroyable
                if (gc.level[x, y].tag != "Undestroyable")
                {
                    Instantiate(this.fire, transform.position + (offset * fire), Quaternion.identity);
                    return;
                }
                else
                {
                    return;
                }

            }
        }



    public void OnTriggerExit2D(Collider2D collision)
    {
        //turn on bomb collision when player leaves bomb
        GetComponent<BoxCollider2D>().isTrigger = false;
    }

} 

