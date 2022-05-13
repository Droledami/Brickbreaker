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

    public float changementDeTaille;
    public TypeDeCollectable typeDeCollectable;
    public float speed = 0.1f;
    public GameObject BalleBonus;


    void Update()
    {
        gameObject.transform.Translate(Vector3.down * Time.deltaTime * speed);
        GameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Barre")
        {
            Vector3 changementDeTailleVector;
            BarreScript barre = collision.GetComponent<BarreScript>();
            switch (this.typeDeCollectable)
            {
                case TypeDeCollectable.Elargissement:
                    changementDeTailleVector = new Vector3(changementDeTaille, 0, 0);
                    Debug.Log("Touch� Bonus Elargissement!");
                    barre.transform.localScale += changementDeTailleVector;
                    barre.MurDroit -= changementDeTaille / 2;
                    barre.MurGauche += changementDeTaille / 2;
                    break;
                case TypeDeCollectable.BalleSup:
                        Instantiate(BalleBonus, collision.transform.position + new Vector3(0, 0.2f), Quaternion.identity);
                    break;
                case TypeDeCollectable.VieSup:
                    Debug.Log("Touch� Bonus Vie Sup!");
                    GameManager.AjouterVie();
                    break;
                case TypeDeCollectable.Retrecissement:
                    changementDeTailleVector = new Vector3(-changementDeTaille, 0, 0);
                    Debug.Log("Touch� Malus Retrecissement!");
                    barre.transform.localScale += changementDeTailleVector;
                    barre.MurDroit += changementDeTaille / 2;
                    barre.MurGauche -= changementDeTaille / 2;
                    break;
                case TypeDeCollectable.Ralentissement:
                    Debug.Log("Touch� Malus Ralentissement!");
                    barre.speed -= 1;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
