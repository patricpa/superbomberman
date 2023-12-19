/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    private Vector2 movementInput;
    private Vector3 direction;

    bool hasmoved;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movementInput.x == 0)
        {
            hasmoved = false;
        }
        else if(movementInput.x != 0 && !hasmoved)
        {
            hasmoved = true;

            GetMovementDirection();
        }
    }

    public void GetMovementDirection()
    {
        if(movementInput.x < 0)
        {
            if(movementInput.y > 0)
            {
                direction = new Vector3(-0.5f, 0.5f);
            }
            else if(movementInput.y < 0)
            {
                direction = new Vector3(-0.5f, -0.5f);
            }
            else
            {
                direction = new Vector3(1, 0, 0);

            }

            transform.position += direction;

        }
    }
}
*/