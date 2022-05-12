using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalleScript : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    GameManager GameManager;
    Vector3 offsetFromBarre = new Vector3(0, 0.2f);
    bool isMoving;
    int lifeTime;
    float second = 0f;

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
        else
        {
            second += Time.deltaTime;
            if (second >= 1)
            {
                lifeTime += 1;
                second--;
                GameManager.UpdateMultiplicateurLifeTime(lifeTime);
                GameManager.AjouterScore(1);
            }
        }
        if (rigidbody2D.position.y < -5.1f)//La balle passe sous la coordonnée 5.1 en Y, alors la balle est hors jeu. On reset les bonus et enleve une vie;
        {
            Debug.Log("Balle perdue!");
            GameManager.EnleverVie();
            rigidbody2D.transform.position = BarrePosition.position + offsetFromBarre;
            isMoving = false;
            rigidbody2D.velocity = Vector2.zero;
            lifeTime = 0;
            second = 0f;
            GameManager.UpdateMultiplicateurLifeTime(lifeTime);
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
