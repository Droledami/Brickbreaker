using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public Canvas MainMenu;
    public Canvas HiScoresMenu;
    public Canvas NiveauMenu;
    public Canvas NotUnlockedPopUp;

    public Sprite ImageAvailableLevelButton;
    public Sprite ImageLockedLevelButton;

    public TextMeshProUGUI HiScoresNiveaux;
    public TextMeshProUGUI HiComboNiveaux;

    private void Start()
    {
        DonneesGenerales.Vies = 3;
        DonneesGenerales.NiveauActif = 1;
        SaveSystem.LoadData();
        for (int i = 0; i < 3; i++)//Débloque les 3 premiers niveaux
        {
            DonneesGenerales.LevelUnlocked[i] = true;
        }
        Debug.Log($"Niveau 4 débloqué ? {DonneesGenerales.LevelUnlocked[3]}");
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
            if(i > 2)//Fera en sorte de ne pas bloquer les 3 niveaux bloqués par défaut en évitant de les mettre à false.
            DonneesGenerales.LevelUnlocked[i] = false;
        }
        SaveSystem.SaveData();
        AfficherHiScoresMenu();
    }

    public void AfficherMainMenu()
    {
        NiveauMenu.gameObject.SetActive(false);
        HiScoresMenu.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
    }

    public void AfficherNiveaux()
    {
        NiveauMenu.gameObject.SetActive(true);
        HiScoresMenu.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(false);

        GameObject[] boutonsInactifs = GameObject.FindGameObjectsWithTag("BoutonInactifs");
        int indexNiveauBloque = 3;
        foreach (GameObject bouton in boutonsInactifs)
        {
            TextMeshProUGUI boutonText = bouton.GetComponentInChildren<TextMeshProUGUI>();
            if (DonneesGenerales.LevelUnlocked[indexNiveauBloque] == true)
            {
                bouton.GetComponent<Image>().sprite = ImageAvailableLevelButton;
            }
            else
            {
                boutonText.gameObject.SetActive(false);
                bouton.GetComponent<Image>().sprite = ImageLockedLevelButton;
            }
            indexNiveauBloque++;
        }
    }

    public void LoadNiveau(int numeroNiveau)
    {
        if (DonneesGenerales.LevelUnlocked[numeroNiveau - 1] == true)
        {
            DonneesGenerales.NiveauActif = numeroNiveau;
            SceneManager.LoadScene($"Niveau {numeroNiveau}");
        }
        else
        {
            NotUnlockedPopUp.gameObject.SetActive(true);
        }
    }

    public void DismissNotUnlockedPopUp()
    {
        NotUnlockedPopUp.gameObject.SetActive(false);
    }

    public void FermerLeProgramme()
    {
        Application.Quit();
    }
}
