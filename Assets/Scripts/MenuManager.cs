using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string userName;

    public MainManager mainManager;
    public int currentHigh;
    public string recordHolder;

    // Start is called before the first frame update
    void Start()
    {
        LoadScore();
        Debug.Log(recordHolder + currentHigh);

    }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public int m_Points;
        public string userName;

    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            currentHigh = data.m_Points;
            recordHolder = data.userName;
        }
    }

}
