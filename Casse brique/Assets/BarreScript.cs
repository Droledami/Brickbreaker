using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarreScript : MonoBehaviour
{
    public float speed;
    public float MurGauche;
    public float MurDroit;
    public GameManager GameManager;
    
    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
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
