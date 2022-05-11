using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalleScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public Vector2 direction;
    bool isMoving;
    // Start is called before the first frame update


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Brick")
        {
            Debug.Log("On a touché la brique");
        }
    }
	
    void Start()
    {
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isMoving)
        {
            rigidbody2D.velocity = direction;
            isMoving = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isMoving && collision.collider.name != "Barre")
        {
            direction = -direction;
            rigidbody2D.velocity = direction;
        }
        else if(isMoving && collision.collider.name == "Barre")
        {
            Vector2 positionBarre = new Vector2();
            positionBarre = collision.collider.transform.position;
            if(rigidbody2D.transform.position.x > positionBarre.x)
            direction.x = rigidbody2D.transform.position.x - positionBarre.x + 4;
            rigidbody2D.velocity = direction;
        }
    }
}
