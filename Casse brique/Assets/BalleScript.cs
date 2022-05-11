using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalleScript : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    GameManager GameManager;
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
        if (!isMoving)
        {
            Vector3 offsetFromBarre = new Vector3(0, 0.2f);
            rigidbody2D.transform.position = BarrePosition.position + offsetFromBarre;
        }
        if(rigidbody2D.position.y < -5.1f)
        {
            Debug.Log("Balle perdue!");
            gameObject.SetActive(false);
            GameManager.EnleverVie();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isMoving)
        {
            rigidbody2D.AddForce(Vector2.up * speed);
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
            
        }
        else if (isMoving && collision.collider.name == "Barre")
        {
            
        }
    }
}
