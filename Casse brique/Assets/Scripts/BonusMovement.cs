using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMovement : MonoBehaviour
{
    public float speed = 0.1f;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
