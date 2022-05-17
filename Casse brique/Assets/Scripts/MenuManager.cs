using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public Canvas MainMenu;
    public Canvas HiScoresMenu;
    public Canvas NiveauMenu;

    public TextMeshProUGUI HiScoresNiveaux;
    public TextMeshProUGUI HiComboNiveaux;

    private void Start()
    {
        SaveSystem.LoadData();
    }
    public void AfficherHiScoresMenu()
    {
        HiScoresNiveaux.text = "";
        HiComboNiveaux.text = "";
        for (int i = 0; i < DonneesGenerales.NombreDeNiveaux; i++)
        {
            HiScoresNiveaux.text += $"Hi Score Niveau {i + 1} : {DonneesGenerales.MeilleurScoreNiveau[i]}\n";
        }
        for (int i = 0; i < DonneesGenerales.NombreDeNiveaux; i++)
        {
            HiComboNiveaux.text += $"Hi Combo Niveau {i + 1} : {DonneesGenerales.MeilleurComboNiveau[i]}\n";
        }
        NiveauMenu.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(false);
        HiScoresMenu.gameObject.SetActive(true);
    }

    public void ResetScores()
    {
        for (int i = 0; i < DonneesGenerales.NombreDeNiveaux; i++)
        {
            DonneesGenerales.MeilleurScoreNiveau[i] = 0;
            DonneesGenerales.MeilleurComboNiveau[i] = 0;
            SaveSystem.SaveData();
        }
        AfficherHiScoresMenu();
    }

    public void AfficherMainMenu()
    {
        NiveauMenu.gameObject.SetActive(false);
        HiScoresMenu.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
    }
    public void LancerNiveau()
    {
        SceneManager.LoadScene("Niveau 1");
    }

    public void AfficherNiveaux()
    {
        NiveauMenu.gameObject.SetActive(true);
        HiScoresMenu.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(false);
    }
    public void Niveau1()
    {
        SceneManager.LoadScene("Niveau 1");
        DonneesGenerales.NiveauActif = 1;
    }
    public void Niveau2()
    {
        SceneManager.LoadScene("Niveau 2");
        DonneesGenerales.NiveauActif = 2;
    }
    public void Niveau3()
    {
        SceneManager.LoadScene("Niveau 3");
        DonneesGenerales.NiveauActif = 3;
    }
}
