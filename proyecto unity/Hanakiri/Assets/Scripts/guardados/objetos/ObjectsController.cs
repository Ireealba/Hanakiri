using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ObjectsContr : MonoBehaviour
{
    public string data;
    public SavedObject savedObject = new SavedObject();
    public PowerUpController powerUpsController;

    private void Awake()
    {
        data = Application.dataPath + "/Gamesaves/objects.json";
        powerUpsController = GameObject.FindObjectOfType<PowerUpController>();
    }
    public void ChargeDate()
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
                powerUpsController.powerUps[i].active = savedObject.PowerUps[i].active;
                powerUpsController.powerUps[i].time = savedObject.PowerUps[i].time;

            }
        }
        else
        {
            Debug.Log("El archivo no existe");
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
            switch (i)
            {
                case 0:

                    newData.PowerUps[i] = new PowerUp()
                    {
                        name = "Vida Pos",
                        life = 20,
                        speed = 0,
                        jump = 0,
                        attack = 0,
                        active = true,
                        time = 12
                    };
                    break;

                case 1:
                    name = "Vida Neg";
                    newData.PowerUps[i] = new PowerUp()
                    {
                        name = "Vida Pos",
                        life = 20,
                        speed = 0,
                        jump = 0,
                        attack = 0,
                        active = true,
                        time = 12
                    };
                    break;

                case 2:
                    name = "Velocidad Pos";
                    newData.PowerUps[i] = new PowerUp()
                    {
                        name = "Vida Pos",
                        life = 20,
                        speed = 0,
                        jump = 0,
                        attack = 0,
                        active = true,
                        time = 12
                    };
                    break;

                case 3:
                    name = "Velocidad Neg";
                    newData.PowerUps[i] = new PowerUp()
                    {
                        name = "Vida Pos",
                        life = 20,
                        speed = 0,
                        jump = 0,
                        attack = 0,
                        active = true,
                        time = 12
                    };
                    break;

                case 4:
                    name = "Salto Pos";
                    newData.PowerUps[i] = new PowerUp()
                    {
                        name = "Vida Pos",
                        life = 20,
                        speed = 0,
                        jump = 0,
                        attack = 0,
                        active = true,
                        time = 12
                    };
                    break;

                case 5:
                    name = "Salto Neg";
                    newData.PowerUps[i] = new PowerUp()
                    {
                        name = "Vida Pos",
                        life = 20,
                        speed = 0,
                        jump = 0,
                        attack = 0,
                        active = true,
                        time = 12
                    };
                    break;

                case 6:
                    name = "Ataque Pos";
                    newData.PowerUps[i] = new PowerUp()
                    {
                        name = "Vida Pos",
                        life = 20,
                        speed = 0,
                        jump = 0,
                        attack = 0,
                        active = true,
                        time = 12
                    };
                    break;

                case 7:
                    name = "Ataque Neg";
                    newData.PowerUps[i] = new PowerUp()
                    {
                        name = "Vida Pos",
                        life = 20,
                        speed = 0,
                        jump = 0,
                        attack = 0,
                        active = true,
                        time = 12
                    };
                    break;

                case 8:
                    name = "Monedas";
                    newData.PowerUps[i] = new PowerUp()
                    {
                        name = "Vida Pos",
                        life = 20,
                        speed = 0,
                        jump = 0,
                        attack = 0,
                        active = true,
                        time = 12
                    };
                    break;
            }
        }

        string jsonData = JsonUtility.ToJson(newData, true);

        File.WriteAllText(data, jsonData);
    }
}
