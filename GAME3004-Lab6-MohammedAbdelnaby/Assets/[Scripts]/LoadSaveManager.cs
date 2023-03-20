using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public class PlayerData
{
    public string PlayerPosition;
    public string PlayerRotation;

    public PlayerData()
    {
        PlayerPosition = "";
        PlayerRotation = "";
    }
}

public class LoadSaveManager : MonoBehaviour
{
    public Transform playerTransform;

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerBehaviour>().transform;
        //LoadData();
    }

    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/PlayerData.dat");
        PlayerData data = new PlayerData();

        data.PlayerPosition = JsonUtility.ToJson(playerTransform.position);
        data.PlayerRotation = JsonUtility.ToJson(playerTransform.localEulerAngles);

        bf.Serialize(file, data);
        file.Close();

        Debug.Log("Saved");
    }

    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath + "/PlayerData.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            var position = JsonUtility.FromJson<Vector3>(data.PlayerPosition);
            var rotation = JsonUtility.FromJson<Vector3>(data.PlayerRotation);
            playerTransform.gameObject.GetComponent<CharacterController>().enabled = false;
            playerTransform.position = JsonUtility.FromJson<Vector3>(data.PlayerPosition);
            playerTransform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
            playerTransform.gameObject.GetComponent<CharacterController>().enabled = true;

            Debug.Log("Loaded");
        }
    }
}
