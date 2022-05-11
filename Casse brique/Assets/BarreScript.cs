using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarreScript : MonoBehaviour
{
    public float speed;
    public float MurGauche;
    public float MurDroit;
    public Rigidbody2D Rigibody;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Bord")
        {
            Debug.Log("On a touché le mur");
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);



        if (transform.position.x < MurGauche)
        {
            transform.position = new Vector2(MurGauche, transform.position.y);
        }
        if (transform.position.x > MurDroit)
        {
            transform.position = new Vector2(MurDroit, transform.position.y);
        }
    }
}
