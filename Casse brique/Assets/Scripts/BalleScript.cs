using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

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
    TrailRenderer Trail;

    public float multiplicateurCombo = 1f;
    public int combo=0;
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
        Trail = gameObject.GetComponentInChildren<TrailRenderer>();
        BarrePosition = GameObject.Find("Barre").GetComponent<Transform>();
        if (GameManager.BallesEnJeu == 0)
        {
            derniereBalle = true;
        }
        if (!derniereBalle)//S'il y a déjà une balle en jeu, elle se lance automatiquement depuis la barre.
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
        if (GameManager.gameover)
        {
            rigidbody2D.velocity = Vector2.zero;
        }
        else
        {
            VerifierSiDerniereBalle();
            if (!isMoving)//La balle suit la barre si elle n'est pas encore lancée.
            {
                rigidbody2D.transform.position = BarrePosition.position + offsetFromBarre;
                Trail.emitting = false;
            }
            else
            {
                GestionTempsDeVieEtScore();
            }
            GererBalleHorsJeu();
            LancerBalle();
        }
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
        if (rigidbody2D.position.y < -5.1f)//La balle passe sous la coordonnée 5.1 en Y, alors la balle est hors jeu. On reset les bonus et enleve une vie;
        {
            Trail.emitting = false;
            Trail.Clear();
            if (GameManager.BallesEnJeu > 1)
            {
                derniereBalle = false;
            }
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
        ResetCombo();
    }

    private void LancerBalle()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isMoving)//La balle est lancée dès qu'on appuie sur la touche haut.
        {
            rigidbody2D.AddForce(Vector2.up * speed);
            isMoving = true;
            Trail.emitting = true;
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
            GameManager.AjouterScore(1, multiplicateurLifeTime, multiplicateurCombo);
        }
        if (lifeTime < 1)
        {
            lifeTime = 1;
            UpdateMultiplicateurLifeTime(lifeTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Brick")
        {
            FindObjectOfType<AudioManager>().Play("bruit brique");
            UpdateCombo();
        }

        if (isMoving && collision.collider.tag == "Bord")
        {
            FindObjectOfType<AudioManager>().Play("bruit bord");
        }
        else if (isMoving && collision.collider.name == "Barre")
        {
            FindObjectOfType<AudioManager>().Play("bruit barre");
            ResetCombo();
        }
    }

    private void UpdateCombo()
    {
        combo++;
        GameManager.UpdateMeilleurCombo(combo);
        multiplicateurCombo = ((float)combo + 10f) / 10f;
    }

    private void ResetCombo()
    {
        combo = 0;
        multiplicateurCombo = 1f;
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
