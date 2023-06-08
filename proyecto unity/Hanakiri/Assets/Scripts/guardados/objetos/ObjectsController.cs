using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ObjectsController : MonoBehaviour
{
    public string data;
    public SavedObject savedObject = new SavedObject();
    public PowerUpController powerUpsController;

    private void Awake()
    {
        data = Application.dataPath + "/Gamesaves/objects.json";
        powerUpsController = GameObject.FindObjectOfType<PowerUpController>();
    }
    public void ChargeData()
    {
        if(File.Exists(data))
        {
            string loadData = File.ReadAllText(data);
            savedObject = JsonUtility.FromJson<SavedObject>(loadData);

            for(int i = 0; i < savedObject.PowerUps.Length; i++)
            {
                powerUpsController.powerUps[i].name = savedObject.PowerUps[i].name;
                powerUpsController.powerUps[i].life = savedObject.PowerUps[i].life;
                powerUpsController.powerUps[i].speed = savedObject.PowerUps[i].speed;
                powerUpsController.powerUps[i].jump = savedObject.PowerUps[i].jump;
                powerUpsController.powerUps[i].attack = savedObject.PowerUps[i].attack;
                powerUpsController.powerUps[i].monedas = savedObject.PowerUps[i].monedas;
                powerUpsController.powerUps[i].active = savedObject.PowerUps[i].active;
                powerUpsController.powerUps[i].time = savedObject.PowerUps[i].time;

            }
        }
        else
        {
            Debug.Log("El archivo de objetos no existe");
        }
    }

    public void SaveData()
    {
        SavedObject newData = new SavedObject();

        newData.PowerUps = new PowerUp[powerUpsController.powerUps.Length];

        for(int i = 0; i < powerUpsController.powerUps.Length; i++)
        {
            newData.PowerUps[i] = new PowerUp()
            {
                name = powerUpsController.powerUps[i].name,
                life = powerUpsController.powerUps[i].life,
                speed = powerUpsController.powerUps[i].speed,
                jump = powerUpsController.powerUps[i].jump,
                attack = powerUpsController.powerUps[i].attack,
                monedas = powerUpsController.powerUps[i].monedas,
                active = powerUpsController.powerUps[i].active,
                time = powerUpsController.powerUps[i].time,
            };
        }

        string jsonData = JsonUtility.ToJson(newData, true);

        File.WriteAllText(data, jsonData);
          
    }

    public void DeleteData()
    {
        SavedObject newData = new SavedObject();

        newData.PowerUps = new PowerUp[9];

        for(int i = 0; i < 9; i++)
        {
            string nameAux;
            int lifeAux;
            int speedAux;
            int jumpAux;
            int attackAux;
            int monedasAux;

            switch (i)
            {
                case 0:

                    nameAux = "Vida Pos";
                    lifeAux = 1;
                    speedAux = 0;
                    jumpAux = 0;
                    attackAux = 0;
                    monedasAux = 0;

                    break;

                case 1:

                    nameAux = "Vida Neg";
                    lifeAux = -1;
                    speedAux = 0;
                    jumpAux = 0;
                    attackAux = 20;
                    monedasAux = 0;

                    break;

                case 2:

                    nameAux = "Velocidad Pos";
                    lifeAux = 0;
                    speedAux = 20;
                    jumpAux = 0;
                    attackAux = 0;
                    monedasAux = 0;

                    break;

                case 3:
 
                    nameAux = "Velocidad Neg";
                    lifeAux = 0;
                    speedAux = -20;
                    jumpAux = 0;
                    attackAux = 20;
                    monedasAux = 0;

                    break;

                case 4:

                    nameAux = "Salto Pos";
                    lifeAux = 0;
                    speedAux = 0;
                    jumpAux = 20;
                    attackAux = 0;
                    monedasAux = 0;

                    break;

                case 5:

                    nameAux = "Salto Neg";
                    lifeAux = 1;
                    speedAux = 0;
                    jumpAux = -20;
                    attackAux = 0;
                    monedasAux = 0;

                    break;

                case 6:

                    nameAux = "Ataque Pos";
                    lifeAux = 0;
                    speedAux = 0;
                    jumpAux = 0;
                    attackAux = 20;
                    monedasAux = 0;

                    break;

                case 7:

                    nameAux = "Ataque Neg";
                    lifeAux = 1;
                    speedAux = 0;
                    jumpAux = 0;
                    attackAux = -20;
                    monedasAux = 0;

                    break;

                case 8:
 
                    nameAux = "Monedas";
                    lifeAux = 0;
                    speedAux = 0;
                    jumpAux = 0;
                    attackAux = 0;
                    monedasAux = 10;

                    break;

                default:
                    
                    nameAux = "";
                    lifeAux = 0;
                    speedAux = 0;
                    jumpAux = 0;
                    attackAux = 0;
                    monedasAux = 0;

                    break;
                    
            }

            newData.PowerUps[i] = new PowerUp()
            {
                name = nameAux,
                life = lifeAux,
                speed = speedAux,
                jump = jumpAux,
                attack = attackAux,
                monedas = monedasAux,
                active = false,
                time = 12
            };

        }

        string jsonData = JsonUtility.ToJson(newData, true);

        File.WriteAllText(data, jsonData);
    }
}
