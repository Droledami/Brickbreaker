using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public Canvas MainMenu;
    public Canvas HiScoresMenu;

    public TextMeshProUGUI[] HiScoresNiveaux = new TextMeshProUGUI[DonneesGenerales.NombreDeNiveaux];
    public TextMeshProUGUI[] HiComboNiveaux = new TextMeshProUGUI[DonneesGenerales.NombreDeNiveaux];

    public void AfficherHiScoresMenu()
    {
        for (int i = 0; i < HiScoresNiveaux.Length; i++)
        {
            HiScoresNiveaux[i].text = $"Hi Score Niveau {i+1} : {DonneesGenerales.MeilleurScoreNiveau[i]}";
        }
        for (int i = 0; i < HiComboNiveaux.Length; i++)
        {
            HiComboNiveaux[i].text = $"Hi Combo Niveau {i + 1} : {DonneesGenerales.MeilleurComboNiveau[i]}";
        }
        MainMenu.gameObject.SetActive(false);
        HiScoresMenu.gameObject.SetActive(true);
    }

    public void ResetScores()
    {
        for (int i = 0; i < DonneesGenerales.NombreDeNiveaux; i++)
        {
            DonneesGenerales.MeilleurScoreNiveau[i] = 0;
            DonneesGenerales.MeilleurComboNiveau[i] = 0;
        }
        AfficherHiScoresMenu();
    }

    public void AfficherMainMenu()
    {
        HiScoresMenu.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
    }
    public void LancerNiveau()
    {
        SceneManager.LoadScene("Niveau 1");
    }
}
