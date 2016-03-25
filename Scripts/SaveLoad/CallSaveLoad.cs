using UnityEngine;
using System.Collections;

public class CallSaveLoad : MonoBehaviour {

    public void LoadLevel()
    {
        SaveLoad.Load();
    }

    public void SaveLevel()
    {
        SaveLoad.Save();
    }
}
