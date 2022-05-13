using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public enum TypeDeCollectable
    {
        Elargissement, BalleSup, VieSup, Retrecissement, Ralentissement
    }

    GameManager GameManager;

    public float changementDeTaille;
    public TypeDeCollectable typeDeCollectable;
    public float speed = 0.1f;
    public GameObject BalleBonus;
    public int points;


    void Update()
    {
        gameObject.transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (GameManager.gameover)
        {
            speed = 0;
        }
        if (gameObject.transform.position.y < -5.1f)//Si le collectable arrive sous cette coordonnée il doit être détruit.
        {
            Debug.Log("Collectable perdu!");
                Destroy(gameObject);
        }
    }

    private void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Barre")
        {
            GameManager.AjouterScore(points, 1, 1);
            Vector3 changementDeTailleVector;
            BarreScript barre = collision.GetComponent<BarreScript>();
            switch (this.typeDeCollectable)
            {
                case TypeDeCollectable.Elargissement:
                    changementDeTailleVector = new Vector3(changementDeTaille, 0, 0);
                    Debug.Log("Touché Bonus Elargissement!");
                    barre.transform.localScale += changementDeTailleVector;
                    barre.MurDroit -= changementDeTaille / 2;
                    barre.MurGauche += changementDeTaille / 2;
                    break;
                case TypeDeCollectable.BalleSup:
                        Instantiate(BalleBonus, collision.transform.position + new Vector3(0, 0.2f), Quaternion.identity);
                    break;
                case TypeDeCollectable.VieSup:
                    Debug.Log("Touché Bonus Vie Sup!");
                    GameManager.AjouterVie();
                    break;
                case TypeDeCollectable.Retrecissement:
                    changementDeTailleVector = new Vector3(-changementDeTaille, 0, 0);
                    Debug.Log("Touché Malus Retrecissement!");
                    barre.transform.localScale += changementDeTailleVector;
                    barre.MurDroit += changementDeTaille / 2;
                    barre.MurGauche -= changementDeTaille / 2;
                    break;
                case TypeDeCollectable.Ralentissement:
                    Debug.Log("Touché Malus Ralentissement!");
                    barre.speed -= 1;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
