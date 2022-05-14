using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DonneesGenerales
{
    public static int NombreDeNiveaux { get; private set; } = 3;

    //Données utilisables à travers le jeu.
    public static int[] ScoreNiveau { get; set; } = new int[NombreDeNiveaux];
    public static int[] MeilleurComboNiveau { get; set; } = new int[NombreDeNiveaux];
    public static int Vies { get; set; } = 3;
    public static int NiveauActif { get; set; } = 1;
}
