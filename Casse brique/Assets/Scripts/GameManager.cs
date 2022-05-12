using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int vies = 3;
    public int score = 0;
    public TextMeshProUGUI ViesText;
    public TextMeshProUGUI ScoreText;
    public void EndGame()
    {
        Debug.Log("Le jeu est fini");
    }

    public void EnleverVie()
    {
        vies--;
        ViesText.text = $"Vies : {vies}";
    }

    public void AjouterVie()
    {
        vies++;
        ViesText.text = $"Vies : {vies}";
    }

    public void AjouterScore(int points)
    {
        score += points;
        ScoreText.text = $"{score}";
    }

    private void Start()
    {
        ViesText.text = $"Vies : {vies}";
        ScoreText.text = $"{score}";
    }
}
