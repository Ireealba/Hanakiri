using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class coleccionablesController : MonoBehaviour
{
    public string data;
    public savedColeccionables savedC = new savedColeccionables();
    public PlushiesController plushiesC;

    private void Awake()
    {
        data = Application.dataPath + "/Gamesaves/coleccionables.json";
        plushiesC = GameObject.FindObjectOfType<PlushiesController>();

    }

    public void ChargeData()
    {
        if (File.Exists(data))
        {
            string loadData = File.ReadAllText(data);
            savedC = JsonUtility.FromJson<savedColeccionables>(loadData);

            for (int i = 0; i < savedC.coleccionables.Length && i < plushiesC.plushies.Length; i++)
            {
                plushiesC.plushies[i].name = savedC.coleccionables[i].name;
                plushiesC.plushies[i].owned = savedC.coleccionables[i].owned;
            }
        }
        else
        {
            Debug.Log("El archivo de coleccionables no existe");
        }
    }

    public void SaveData()
    {
        savedColeccionables newData = new savedColeccionables();

        newData.coleccionables = new Coleccionable[plushiesC.plushies.Length];

        for(int i = 0; i < plushiesC.plushies.Length; i++)
        {
            newData.coleccionables[i] = new Coleccionable()
            {
                name = plushiesC.plushies[i].name,
                owned = plushiesC.plushies[i].owned,
            };
        }

        string jsonData = JsonUtility.ToJson(newData, true);

        File.WriteAllText(data, jsonData);
    }

    public void Deletedata()
    {
        savedColeccionables newData = new savedColeccionables();

        newData.coleccionables = new Coleccionable[10];

        for(int i = 0; i < 10; i++)
        {
            string nameAux;

            switch (i)
            {
                case 0:
                    nameAux = "plushie_alex";
                    break;

                case 1:
                    nameAux = "plushie_ancor";
                    break;

                case 2:
                    nameAux = "plushie_candy";
                    break;

                case 3:
                    nameAux = "plushie_forget";
                    break;

                case 4:
                    nameAux = "plushie_freya";
                    break;

                case 5:
                    nameAux = "plushie_hana";
                    break;

                case 6:
                    nameAux = "plushie_sanse";
                    break;

                case 7:
                    nameAux = "plushie_skull";
                    break;

                case 8:
                    nameAux = "plushie_spider";
                    break;

                case 9:
                    nameAux = "plushie_wachin";
                    break;

                default:
                    nameAux = "";
                    break;

            }

            newData.coleccionables[i] = new Coleccionable()
            {
                name = nameAux,
                owned = false
            };
        }

        string jsonData = JsonUtility.ToJson(newData, true);

        File.WriteAllText(data, jsonData);
    }

}
