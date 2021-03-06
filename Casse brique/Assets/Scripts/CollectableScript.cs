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
        if (gameObject.transform.position.y < -5.1f)//Si le collectable arrive sous cette coordonn?e il doit ?tre d?truit.
        {
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
                    GameManager.AfficherPointsPopUp(collision.gameObject.transform.position, points);
                    changementDeTailleVector = new Vector3(changementDeTaille, 0, 0);
                    barre.transform.localScale += changementDeTailleVector;
                    barre.MurDroit -= changementDeTaille / 2;
                    barre.MurGauche += changementDeTaille / 2;
                    break;
                case TypeDeCollectable.BalleSup:
                    GameManager.AfficherPointsPopUp(collision.gameObject.transform.position, points);
                    Instantiate(BalleBonus, collision.transform.position + new Vector3(0, 0.2f), Quaternion.identity);
                    break;
                case TypeDeCollectable.VieSup:
                    GameManager.AfficherPointsPopUp(collision.gameObject.transform.position, points);
                    GameManager.AjouterVie();
                    break;
                case TypeDeCollectable.Retrecissement:
                    changementDeTailleVector = new Vector3(-changementDeTaille, 0, 0);
                    barre.transform.localScale += changementDeTailleVector;
                    barre.MurDroit += changementDeTaille / 2;
                    barre.MurGauche -= changementDeTaille / 2;
                    break;
                case TypeDeCollectable.Ralentissement:
                    barre.speed -= 1;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
