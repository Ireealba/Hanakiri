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
        data = Application.dataPath + "/gamesaves/gamedata.json";

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ChargeData()
    {
        if(File.Exists(data))
        {
            string loadData = File.ReadAllText(data);
            savedData = JsonUtility.FromJson<SavedData>(loadData);

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
}
