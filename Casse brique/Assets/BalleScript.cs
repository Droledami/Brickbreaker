using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalleScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public Vector2 direction;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Brick")
        {
            Debug.Log("On a touché la brique");
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigidbody2D.velocity = direction;
        }
    }
}
