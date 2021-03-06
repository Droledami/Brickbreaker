using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BrickScript : MonoBehaviour
{
    private GameManager GameManager;
    private SpriteRenderer renderer;
    private bool containsCollectable = false;

    public enum TypeDeBrick { Normal, Resistant, Solide, BonusOuMalus }

    public GameObject collectable;
    public TypeDeBrick typeDeBrick;
    public Brick Brick;
    public Sprite Hit;
    public Sprite Hit2;

    public Transform effetDestruction;
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
                    renderer.sprite = Hit; 
                    break;
                case 1:
                    renderer.sprite = Hit2;
                    break;
                case 0://On effectue un ajout de point, un spawn de bonus si la brique en contient un, on met ? jour le nombre de briques restantes puis on d?truit l'objet une fois que les pv sont ? 0;
                    GameManager.AjouterScore(this.Brick.points, balle.MultiplicateurLifeTime, balle.multiplicateurCombo);
                    Transform nouvelEffetDestruction = Instantiate(effetDestruction, gameObject.transform.position,Quaternion.identity);
                    Destroy(nouvelEffetDestruction.gameObject, 3f);
                    GameManager.AfficherPointsPopUp(gameObject.transform.position, Brick.points);
                    if (containsCollectable)
                    {
                        Instantiate(collectable, gameObject.transform.position, Quaternion.identity);
                    }
                    gameObject.SetActive(false);
                    GameManager.UpdtNumberofBrick();
                    Destroy(gameObject);
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
