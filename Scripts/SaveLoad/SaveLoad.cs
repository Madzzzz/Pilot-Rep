using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using System;


public static class SaveLoad
{    
    public static void Save()
    {

        BinaryFormatter binary = new BinaryFormatter();
        FileStream fStream = File.Create(Application.persistentDataPath + "/Hippocampus.Save");
        //Debug.Log(Application.persistentDataPath);
        //alt vi har lyst å lagre fra bubbasave klassen
        BubbaSave saver = new BubbaSave();
        saver.whichLevelLoaded = SceneManager.GetActiveScene().name;
        saver.soundVolume = GameObject.Find("OldGameMusic").GetComponent<StayAlive>().VolSlider.value;
        saver.musicVolume = GameObject.Find("OldGameMusic").GetComponent<StayAlive>().MusicSlider.value;
        saver.PosX = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        saver.PosY = GameObject.FindGameObjectWithTag("Player").transform.position.y;
        saver.PosZ = GameObject.FindGameObjectWithTag("Player").transform.position.z;
        saver.RotX = Camera.main.GetComponent<MouseScript>().rotationX;
        saver.RotY = Camera.main.GetComponent<MouseScript>().rotationY;

        binary.Serialize(fStream, saver);
        fStream.Close();
    }

    public static void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/Hippocampus.Save"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fStream = File.Open(Application.persistentDataPath + "/Hippocampus.Save", FileMode.Open);
            BubbaSave loader = (BubbaSave)binary.Deserialize(fStream);
            fStream.Close();
            
            GameObject.Find("LoadingScreen").GetComponent<LoadingScreen>().loadSave(loader.whichLevelLoaded);
            GameObject.Find("OldBubbaManager").GetComponent<BubbaManager>().GetBubbaInfo(loader.PosX, loader.PosY, loader.PosZ, loader.RotX, loader.RotY);
            GameObject.Find("OldBubbaManager").GetComponent<BubbaManager>().loaded = true;
            GameObject.Find("OldGameMusic").GetComponent<StayAlive>().VolSlider.value = loader.soundVolume;
            GameObject.Find("OldGameMusic").GetComponent<StayAlive>().MusicSlider.value = loader.musicVolume;
        }
    }
}

[System.Serializable]
class BubbaSave : object
{
    //alt vi har lyst å lagre
    public string whichLevelLoaded;

    public float soundVolume;
    public float musicVolume;

    public float PosX;
    public float PosY;
    public float PosZ;
    public float RotX;
    public float RotY;

}