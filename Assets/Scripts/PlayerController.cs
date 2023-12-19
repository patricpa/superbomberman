using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private int movementcounter = 0;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    public int getMovementCounter()
    {
        return this.movementcounter;
    }

    // Update is called once per frame
    void Update()
    {
        //Input from player
        int x = (int)(Input.GetAxisRaw("Horizontal"));
        int y = (int)(Input.GetAxisRaw("Vertical"));
        
        
        Debug.Log(movementcounter);

        //nodiagonal movement
        if(Mathf.Abs(x) >= Mathf.Abs(y))
        {
            y = 0;
        }

        else if(Mathf.Abs(y) >= Mathf.Abs(x))
        {
            x = 0;
        }

        if((x != 0) || (y != 0))
        {
            ++movementcounter;
        }
        Debug.Log(movementcounter);
        //movement with speed
        Vector2 movement = new Vector2(x, y) * speed;
        
        //set movement
        rb2d.velocity = movement;
    }
}
