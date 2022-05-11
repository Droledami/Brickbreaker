using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalleScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public Vector2 direction;
    bool isMoving;
    public int speed;
    // Start is called before the first frame update

    void Start()
    {
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isMoving)
        {
            rigidbody2D.velocity = direction * speed;
            isMoving = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Brick")
        {
            Debug.Log("On a touché la brique");
        }

        if (isMoving && collision.collider.name != "Barre")
        {
            direction = -direction * speed;
            rigidbody2D.velocity = direction;
        }
        else if (isMoving && collision.collider.name == "Barre")
        {
            Vector2 positionBarre = new Vector2();
            positionBarre = collision.collider.transform.position;
            if (rigidbody2D.transform.position.x > positionBarre.x)
                direction.x = (rigidbody2D.transform.position.x - positionBarre.x) * speed;
            if (rigidbody2D.transform.position.x < positionBarre.x)
                direction.x = (rigidbody2D.transform.position.x - positionBarre.x) * speed;
            rigidbody2D.velocity = direction;
        }
    }
}
