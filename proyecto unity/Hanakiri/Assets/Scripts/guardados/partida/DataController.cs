using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataController : MonoBehaviour
{
    public GameObject player;
    public string data;
    public SavedData savedData = new SavedData();
    

    private void Awake()
    {
        data = Application.dataPath + "/Gamesaves/gamedata.json";

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ChargeData()
    {
        if(File.Exists(data))
        {
            string loadData = File.ReadAllText(data);
            savedData = JsonUtility.FromJson<SavedData>(loadData);

            player.GetComponent<personaje>().actualLvl = savedData.actualLvl;
            player.GetComponent<personaje>().monedas = savedData.monedas;
            player.GetComponent<personaje>().totalLife = savedData.totalLife;
            player.GetComponent<personaje>().actualLife = savedData.actualLife;


            Debug.Log("Monedas: " + savedData.monedas);
        }
        else
        {
            Debug.Log("El archivo no existe");
        }
    }

    public void SaveData()
    {
        SavedData newData = new SavedData()
        {
            actualLvl = player.GetComponent<personaje>().actualLvl,
            monedas = player.GetComponent<personaje>().monedas,
            totalLife = player.GetComponent<personaje>().totalLife,
            actualLife = player.GetComponent<personaje>().actualLife

        };


        string cadenaJson = JsonUtility.ToJson(newData);
        File.WriteAllText(data, cadenaJson);

        Debug.Log("Archivo guardado");
    }

    public void DeleteData()
    {
        SavedData newData = new SavedData()
        {
            actualLvl = 0,
            monedas = 0,
            totalLife = 3,
            actualLife = 3
        };        


        string cadenaJson = JsonUtility.ToJson(newData);
        File.WriteAllText (data, cadenaJson);

        Debug.Log("Datos borrados");
    }
}
