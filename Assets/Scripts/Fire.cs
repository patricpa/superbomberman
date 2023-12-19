using System.Collections;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //remove fire
        Destroy(gameObject, 0.3f);
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Box>() != null)
        {
            //Fire can't destroy power up just after creation!
            GetComponent<CircleCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Box>().SpawnPowerUp();
            
        }
        
        //No fire elimination
        else if (collision.gameObject.GetComponent<Fire>() != null)
        {
            return;
        }

        //trigger bomb
        else if (collision.gameObject.GetComponent<Bomb>() != null)
        {
            collision.gameObject.GetComponent<Bomb>().Explode();
        }

        

        //remove object with which fire collided
        if (collision.gameObject.tag != "Undestroyable")
        {
            Destroy(collision.gameObject);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate effect
        transform.Rotate(0, 0, -45);
    }
}
