using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int vies = 3;
    public void EndGame()
    {
        Debug.Log("Le jeu est fini");
    }

    public void EnleverVie()
    {
        vies--;
    }
    
}
