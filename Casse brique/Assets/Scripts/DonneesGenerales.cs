using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DonneesGenerales
{
    public static int NombreDeNiveaux { get; private set; } = 3;

    //Données utilisables à travers le jeu.
    public static int Score;
    public static int Vies = 3;
    public static int MeilleurCombo;
    public static int NiveauActif = 1;
}
