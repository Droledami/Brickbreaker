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

    private int multiplicateurLifeTime = 1;
    private float multiplicateurCombo = 1f;
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
        float pointsF = points;
        pointsF = pointsF * multiplicateurLifeTime * multiplicateurCombo;
        score += (int)pointsF;
        ScoreText.text = $"{score}";
    }

    public void UpdateMultiplicateurLifeTime(int lifeTime)
    {
        if (lifeTime >= 10)
        {
            multiplicateurLifeTime = lifeTime / 10;
        }
        else
        {
            multiplicateurLifeTime = 1;
        }
    }

    private void Start()
    {
        ViesText.text = $"Vies : {vies}";
        ScoreText.text = $"{score}";
    }
}
