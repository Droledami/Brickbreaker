using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    private GameManager GameManager;
    public enum TypeDeBrick { Normal, Solide }
    public TypeDeBrick typeDeBrick;
    public Brick Brick;
    private SpriteRenderer renderer;

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
        }
        this.renderer = gameObject.GetComponent<SpriteRenderer>();
    }
}
