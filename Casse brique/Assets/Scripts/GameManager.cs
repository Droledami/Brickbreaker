using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int vies;
    public int score = 0;
    public TextMeshProUGUI ViesText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI ComboText;
    public TextMeshProUGUI pointsPopUp;

    private Camera cam;

    private int meilleurCombo = 0;
    private int ballesEnJeu = 0;

    public bool gameover;
    public GameObject GameOverPanel;
    public int NumberofBricks;

    public int HiScoreNiveauActif;
    public int HiComboNiveauActif;


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
    public void EnleverVie()
    {
        vies--;
        ViesText.text = $"Vies: {vies}";
        if (vies <= 0)
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
            if (meilleurCombo < 10)//Afin d'éviter un overflow au passage de la dizaine, si on passe à 10, l'espace devant les : sera omis.
            {
                ComboText.text = $"meilleur\ncombo: {combo}";
            }
            else
            {
                ComboText.text = $"meilleur\ncombo:{combo}";
            }
        }
    }

    private void Start()
    {
        HiScoreNiveauActif = DonneesGenerales.MeilleurScoreNiveau[DonneesGenerales.NiveauActif - 1];
        HiComboNiveauActif = DonneesGenerales.MeilleurComboNiveau[DonneesGenerales.NiveauActif - 1];
        Debug.Log(HiScoreNiveauActif);
        Debug.Log(HiComboNiveauActif);
        vies = DonneesGenerales.Vies;
        ViesText.text = $"Vies: {vies}";
        ScoreText.text = $"{score}";
        NumberofBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        gameover = false;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void GameOver()
    {
        gameover = true;
        GameOverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DonneesGenerales.Vies = 3;
    }

    public void LoadNiveauSuivant()
    {
        DonneesGenerales.Vies = vies;
        MettreAJourHiScoreEtHiCombo();
        Debug.Log(DonneesGenerales.Vies);
        if (DonneesGenerales.NiveauActif < DonneesGenerales.NombreDeNiveaux)
        {
            DonneesGenerales.NiveauActif++;
            SceneManager.LoadScene($"Niveau {DonneesGenerales.NiveauActif}");
        }
        else
        {
            SceneManager.LoadScene("MenuPrincipal");
            DonneesGenerales.Vies = 3;
            DonneesGenerales.NiveauActif = 1;
        }
    }

    private void MettreAJourHiScoreEtHiCombo()
    {
        if (DonneesGenerales.MeilleurScoreNiveau[DonneesGenerales.NiveauActif - 1] < score)
        {
            DonneesGenerales.MeilleurScoreNiveau[DonneesGenerales.NiveauActif - 1] = score;
        }
        if (DonneesGenerales.MeilleurComboNiveau[DonneesGenerales.NiveauActif - 1] < meilleurCombo)
        {
            DonneesGenerales.MeilleurComboNiveau[DonneesGenerales.NiveauActif - 1] = meilleurCombo;
        }
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Vous avez quitté le jeu. :(");
    }

    public void UpdtNumberofBrick()
    {
        NumberofBricks--;
        if (NumberofBricks <= 0)
        {
            LoadNiveauSuivant();
        }
    }

    public void AfficherPointsPopUp(Vector2 positionObjet, int points)
    {
        pointsPopUp.text = points.ToString();
        Vector2 positionEcran = cam.WorldToScreenPoint(positionObjet);
        //Debug.Log($"position ecran : {positionEcran} et position objet : {positionObjet}");
        Transform nouveauPointsPopUp = Instantiate(pointsPopUp, positionEcran, Quaternion.identity).transform;
        nouveauPointsPopUp.transform.SetParent(GameObject.FindGameObjectWithTag("UICanvas").transform);
    }

}
