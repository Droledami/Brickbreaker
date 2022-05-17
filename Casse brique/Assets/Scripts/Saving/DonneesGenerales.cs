using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DonneesGenerales
{
    public static int NombreDeNiveaux { get; private set; } = 10;

    //Données utilisables à travers le jeu.
    public static int[] MeilleurScoreNiveau { get; set; } = new int[NombreDeNiveaux];
    public static int[] MeilleurComboNiveau { get; set; } = new int[NombreDeNiveaux];
    public static bool[] LevelUnlocked { get; set; } = new bool[NombreDeNiveaux];
    public static int Vies { get; set; } = 3;
    public static int NiveauActif { get; set; } = 1;
}
