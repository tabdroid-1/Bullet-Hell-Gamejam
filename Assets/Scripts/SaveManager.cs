using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using UnityEditor;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public bool[] level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //data persistence between scenes
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadSave();
    }



    [System.Serializable]
    public class SaveData
    {
        public bool[] Level;
    }

    public void Save()
    {
        
        SaveData data = new SaveData();
        data.Level = level;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    

    public void LoadSave()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            level = data.Level;
        }
        
    }

    public void DeleteSave()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            File.Delete(path);
            Refresh();
        }
    }

    public void Refresh()
    {
        // refresh editor view
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}