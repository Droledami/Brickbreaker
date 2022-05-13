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
    public int ballesEnJeu = 0;


    public int BallesEnJeu
    {
        get { return ballesEnJeu; }
        set
        {
            ballesEnJeu = value;
            if (ballesEnJeu == 0)
                EnleverVie();
        }
    }
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

    public void AjouterScore(int points, int multiplicateurLifeTime, float multiplicateurCombo)
    {
        float pointsF = points;
        pointsF = pointsF * multiplicateurLifeTime * multiplicateurCombo;
        score += (int)pointsF;
        ScoreText.text = $"{score}";
    }

    private void Start()
    {
        ViesText.text = $"Vies : {vies}";
        ScoreText.text = $"{score}";
    }
}
