using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalleScript : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    GameManager GameManager;
    Vector3 offsetFromBarre = new Vector3(0, 0.2f);
    bool isMoving;

    public int speed;
    public Transform BarrePosition;
    // Start is called before the first frame update

    void Start()
    {
        isMoving = false;
        rigidbody2D = GetComponent<Rigidbody2D>();
        GameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)//La balle suit la barre si elle n'est pas encore lancée.
        {
            rigidbody2D.transform.position = BarrePosition.position + offsetFromBarre;
        }
        if(rigidbody2D.position.y < -5.1f)//La balle passe sous la coordonnée 5.1 en Y, alors la balle est hors jeu.
        {
            Debug.Log("Balle perdue!");
            GameManager.EnleverVie();
            rigidbody2D.transform.position = BarrePosition.position + offsetFromBarre;
            isMoving = false;
            rigidbody2D.velocity = Vector2.zero;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isMoving)//La balle est lancée dès qu'on appuie sur la touche haut.
        {
            rigidbody2D.AddForce(Vector2.up * speed);
            isMoving = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Brick")
        {
            Debug.Log("On a touché une brique");
        }

        if (isMoving && collision.collider.name != "Barre")
        {
            
        }
        else if (isMoving && collision.collider.name == "Barre")
        {
            
        }
    }
}
