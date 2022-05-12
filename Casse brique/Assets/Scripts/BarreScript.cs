using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarreScript : MonoBehaviour
{
    public float speed;
    public float MurGauche;
    public float MurDroit;
    GameManager GameManager; 
    Rigidbody2D Rigidbody;
    Collectable.TypeDeCollectable modificateurActif;
    float tempsModificateur = 0f;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Bord")
        {
            Debug.Log("On a touché le mur");
        }
    }

    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        Rigidbody = GetComponent<Rigidbody2D>();
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
