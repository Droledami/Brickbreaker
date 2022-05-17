using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveData.owo";
        FileStream stream = new FileStream(path, FileMode.Create);

        DonneesJoueur data = new DonneesJoueur();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static DonneesJoueur LoadData()
    {
        string path = Application.persistentDataPath + "/saveData.owo";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DonneesJoueur playerData = formatter.Deserialize(stream) as DonneesJoueur;

            for (int i = 0; i < DonneesGenerales.NombreDeNiveaux; i++)
            {
                DonneesGenerales.MeilleurScoreNiveau[i] = playerData.MeilleurScoreNiveau[i];
                DonneesGenerales.MeilleurComboNiveau[i] = playerData.MeilleurComboNiveau[i];
                DonneesGenerales.LevelUnlocked[i] = playerData.LevelUnlocked[i];
            }

            stream.Close();

            return playerData;

        }
        else
        {
            Debug.LogError($"Fichier de sauvegarde non trouvé dans {path}");
            return null;
        }
    }
}
