using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BrickScript : MonoBehaviour
{
    private GameManager GameManager;
    public enum TypeDeBrick { Normal, Resistant, Solide, BonusOuMalus }
    public GameObject collectable;
    public TypeDeBrick typeDeBrick;
    public Brick Brick;
    private SpriteRenderer renderer;
    private bool containsCollectable = false;
    public Sprite Hit;
    public Sprite Hit2;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        BalleScript balle = collision.gameObject.GetComponent<BalleScript>();
        if (collision.collider.tag == "Balle")
        {
            this.Brick.pv--;
            switch (this.Brick.pv)
            {
                case 2:
                    //renderer.color = Color.magenta;
                    gameObject.GetComponent<SpriteRenderer>().sprite = Hit; 
                    break;
                case 1:
                    //renderer.color = Color.red;
                    gameObject.GetComponent<SpriteRenderer>().sprite = Hit2;
                    break;
                case 0:
                    GameManager.AjouterScore(this.Brick.points, balle.MultiplicateurLifeTime, 1);
                    if (containsCollectable)
                    {
                        Instantiate(collectable, gameObject.transform.position, Quaternion.identity);
                    }
                    gameObject.SetActive(false);
                    break;
            }
        }
    }
    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        switch (typeDeBrick)
        {
            case TypeDeBrick.Normal:
                this.Brick = new Brick();
                break;
            case TypeDeBrick.Solide:
                this.Brick = new BrickSolide();
                break;
            case TypeDeBrick.Resistant:
                this.Brick = new Brick(2,50);
                break;
            default:
                this.Brick = new Brick();
                containsCollectable = true;
                break;
        }
        this.renderer = gameObject.GetComponent<SpriteRenderer>();
    }
}
