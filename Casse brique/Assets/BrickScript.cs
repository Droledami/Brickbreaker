using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        Renderer render = gameObject.GetComponent<Renderer>();
        if (collision.collider.name == "Balle")
        {
            Debug.Log("La balle m'a touché UwU");
            render.enabled = false;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
