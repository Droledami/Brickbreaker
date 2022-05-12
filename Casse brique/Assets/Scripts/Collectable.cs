using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public enum TypeDeCollectable
    {
        Elargissement, BalleSup, VieSup, Retrecissement, Ralentissement
    }

    GameManager GameManager;

    private Vector3 changementDeTailleVector;
    public float changementDeTaille;
    public TypeDeCollectable typeDeCollectable;
    public float speed = 0.1f;

    void Update()
    {
        gameObject.transform.Translate(Vector3.down * Time.deltaTime * speed);
        GameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Barre")
        {
            BarreScript barre = collision.GetComponent<BarreScript>();
            switch (this.typeDeCollectable)
            {
                case TypeDeCollectable.Elargissement:
                    Vector3 changementDeTailleVector = new Vector3(changementDeTaille, 0, 0);
                    Debug.Log("Touché Bonus Elargissement!");
                    barre.transform.localScale += changementDeTailleVector;
                    barre.MurDroit -= changementDeTaille / 2;
                    barre.MurGauche += changementDeTaille / 2;
                    break;
                case TypeDeCollectable.BalleSup:
                    //A AJOUTER
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
        }
    }
}
