using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BrickScript : MonoBehaviour
{
    private GameManager GameManager;
    public enum TypeDeBrick { Normal, Solide, BonusElargissement, BonusVieSup, BonusBalleSup, MalusRetrecissement, MalusRalentissement }
    public GameObject collectable;
    public TypeDeBrick typeDeBrick;
    public Brick Brick;
    private SpriteRenderer renderer;
    private bool containsCollectable = false;

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Balle")
        {
            this.Brick.pv--;
            switch (this.Brick.pv)
            {
                case 2:
                    renderer.color = Color.magenta;
                    break;
                case 1:
                    renderer.color = Color.red;
                    break;
                case 0:
                    GameManager.AjouterScore(this.Brick.points);
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
            case TypeDeBrick.BonusVieSup:
                this.Brick = new Brick();
                containsCollectable = true;
                break;
            default:
                this.Brick = new Brick();
                break;
        }
        this.renderer = gameObject.GetComponent<SpriteRenderer>();
    }
}
