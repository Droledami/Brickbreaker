using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int vies = 3;
    public int score = 0;
    public TextMeshProUGUI ViesText;
    public TextMeshProUGUI ScoreText;

    private float meilleurCombo = 1f;
    public int ballesEnJeu = 0;

    public bool gameover;
    public GameObject GameOverPanel;
    public int NumberofBricks;


    public int BallesEnJeu
    {
        get { return ballesEnJeu; }
        set
        {
            ballesEnJeu = value;
            if (ballesEnJeu == 0)
            {
                EnleverVie();
            }
        }
    }
    public void EndGame()
    {
        Debug.Log("Le jeu est fini");
    }

    public void EnleverVie()
    {
        vies--;
        ViesText.text = $"Vies: {vies}";
        if (vies <=0)
        {
            vies = 0;
            GameOver();
        }
    }

    public void AjouterVie()
    {
        vies++;
        ViesText.text = $"Vies: {vies}";
    }

    public void AjouterScore(int points, int multiplicateurLifeTime, float multiplicateurCombo)
    {
        float pointsF = points;
        pointsF = pointsF * multiplicateurLifeTime * multiplicateurCombo;
        score += (int)pointsF;
        ScoreText.text = $"{score}";
    }

    public void UpdateMeilleurCombo(int combo)
    {
        if (combo > meilleurCombo)
        {
            meilleurCombo = combo;
        }
    }

    private void Start()
    {
        ViesText.text = $"Vies: {vies}";
        ScoreText.text = $"{score}";
        NumberofBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    public void GameOver()
    {
        gameover = true;
        GameOverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Vous avez quittez le jeu. :(");
    }

    public void UpdtNumberofBrick()
    {
        NumberofBricks--;
        if (NumberofBricks <= 0)
        {
            GameOver(); //A remplacer par les levels
        }
    }

}
