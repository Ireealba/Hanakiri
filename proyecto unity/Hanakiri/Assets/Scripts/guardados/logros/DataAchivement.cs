using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NewBehaviourScript : MonoBehaviour
{

    public string data;
    public SavedAchivement savedData = new SavedAchivement();


    //Obtención de logros
    public GameObject objecto;


    private void Awake()
    {
        data = Application.dataPath + "/Gamesaves/achivements.json";
    }

    public void ChargeData()
    {
        if (File.Exists(data))
        {
            string loadData = File.ReadAllText(data);
            savedData = JsonUtility.FromJson<SavedAchivement>(loadData);

            //TODO : Asignar logros cargados a logros

            
        }
        else
        {
            Debug.Log("El archivo no existe");
        }
    }

    public void SaveData(int index)
    {
        SavedAchivement newData = new SavedAchivement()
        {
            //achivements[index]=true,
            
        };

        string cadenaJson = JsonUtility.ToJson(newData);
        File.WriteAllText(data, cadenaJson);

        Debug.Log("Archivo guardado");
    }

    public void DeleteData()
    {
        SavedAchivement newData = new SavedAchivement()
        {
            //for()
        };

        string cadenaJson = JsonUtility.ToJson(newData);
        File.WriteAllText(data, cadenaJson);

        Debug.Log("Datos borrados");
    }

    public void GetAchivement1()
    {
        //Un asunto emarañado
        if (objecto.name == "Llaves")
        {
            SaveData(1);
        }
    }

    public void GetAchivement2()
    {
        //Efectivamente , soy la morra de los peluches
    }

    public void GetAchivement3()
    {
        //Intocable
    }

    public void GetAchivement4()
    {
        //Dulce comienzo
    }



}
