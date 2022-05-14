using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsPopUpMovement : MonoBehaviour
{
    public float speed;
    private GameManager gameManager;
    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameover)
        {
            gameObject.transform.Translate(Vector2.up * speed * Time.deltaTime);
            Destroy(gameObject, 1f);
        }
        
    }

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        if (gameManager.gameover)
        {
            Destroy(gameObject);
        }
    }
}
