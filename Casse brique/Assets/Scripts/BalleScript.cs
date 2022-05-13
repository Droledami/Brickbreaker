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
    Transform BarrePosition;
    int multiplicateurLifeTime;

    public int speed;
    public bool derniereBalle;
    public bool IsMoving
    {
        get { return isMoving; }
        set { isMoving = value; }
    }
    // Start is called before the first frame update

    public int MultiplicateurLifeTime
    {
        get { return multiplicateurLifeTime; }
    }
    void Start()
    {
        isMoving = false;
        rigidbody2D = GetComponent<Rigidbody2D>();
        GameManager = FindObjectOfType<GameManager>();
        BarrePosition = GameObject.Find("Barre").GetComponent<Transform>();
        if (GameManager.BallesEnJeu == 0)
        {
            derniereBalle = true;
        }
        if (!derniereBalle)
        {
            rigidbody2D.AddForce(Vector2.up * speed);
            isMoving = true;
            derniereBalle = false;
            GameManager.BallesEnJeu++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        VerifierSiDerniereBalle();
        if (!isMoving)//La balle suit la barre si elle n'est pas encore lanc?e.
        {
            rigidbody2D.transform.position = BarrePosition.position + offsetFromBarre;
        }
        else
        {
            GestionTempsDeVieEtScore();
        }
        GererBalleHorsJeu();
        LancerBalle();
    }

    private void VerifierSiDerniereBalle()
    {
        if (GameManager.BallesEnJeu == 1)
        {
            derniereBalle = true;
        }
        else
        {
            derniereBalle = false;
        }
    }

    private void GererBalleHorsJeu()
    {
        if (rigidbody2D.position.y < -5.1f)//La balle passe sous la coordonn?e 5.1 en Y, alors la balle est hors jeu. On reset les bonus et enleve une vie;
        {
            if (GameManager.BallesEnJeu > 1)
            {
                derniereBalle = false;
            }
            Debug.Log("Balle perdue!");
            GameManager.BallesEnJeu--;
            if (!derniereBalle)
            {
                Destroy(gameObject);
            }
            else if (GameManager.vies > 0)
            {
                RespawnBalle();
            }
        }
    }

    private void RespawnBalle()
    {
        rigidbody2D.transform.position = BarrePosition.position + offsetFromBarre;
        isMoving = false;
        derniereBalle = true;
        rigidbody2D.velocity = Vector2.zero;
        lifeTime = 0;
        second = 0f;
        UpdateMultiplicateurLifeTime(lifeTime);
    }

    private void LancerBalle()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isMoving)//La balle est lanc?e d?s qu'on appuie sur la touche haut.
        {
            rigidbody2D.AddForce(Vector2.up * speed);
            isMoving = true;
            GameManager.BallesEnJeu++;
        }
    }

    private void GestionTempsDeVieEtScore()
    {
        second += Time.deltaTime;
        if (second >= 1)
        {
            lifeTime += 1;
            second--;
            UpdateMultiplicateurLifeTime(lifeTime);
            GameManager.AjouterScore(1, multiplicateurLifeTime, 1);
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

    void UpdateMultiplicateurLifeTime(int lifeTime)
    {
        if (lifeTime >= 10)
        {
            multiplicateurLifeTime = lifeTime / 10;
        }
        else
        {
            multiplicateurLifeTime = 1;
        }
    }
}
