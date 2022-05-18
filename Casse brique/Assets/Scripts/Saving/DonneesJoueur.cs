using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DonneesJoueur
{
    public int[] MeilleurScoreNiveau = new int[DonneesGenerales.NombreDeNiveaux];
    public int[] MeilleurComboNiveau = new int[DonneesGenerales.NombreDeNiveaux];
    public bool[] LevelUnlocked = new bool[DonneesGenerales.NombreDeNiveaux];

    public DonneesJoueur()
    {
        for (int i = 0; i < DonneesGenerales.NombreDeNiveaux; i++)
        {
            MeilleurScoreNiveau[i] = DonneesGenerales.MeilleurScoreNiveau[i];
            MeilleurComboNiveau[i] = DonneesGenerales.MeilleurComboNiveau[i];
            LevelUnlocked[i] = DonneesGenerales.LevelUnlocked[i];
        }
    }
}
