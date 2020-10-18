using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MenuController m_MenuController;
    public PlayerController_mobileJoystick playerController;
    public LevelManager m_CurrentLoadedLevel;

    void Start()
    {
        m_MenuController.SetActiveMainMenus();
        playerController.enabled = false;
    }

    public void LoadLevel()
    {
        //m_CurrentLoadedLevel
    }

    public void StartLevel()
    {
        AdsManager.Instance.ShowRewardAd();
        m_MenuController.StartLevelUI();
        playerController.enabled = true;
        m_CurrentLoadedLevel.StartLevel();
    }

    public void Awake()
    {

        string json = Resources.Load<TextAsset>("GameJSONData/level1").text;
        oneLevel level = JsonUtility.FromJson<oneLevel>(json);

        //        oneType tempType = new oneType();
        //        tempType.type = "normal";
        //        tempType.count = 3;

        //        oneType tempType2 = new oneType();
        //        tempType2.type = "charger";
        //        tempType2.count = 1;

        //        oneWave tempWave = new oneWave();
        //        tempWave.types.Add(tempType);

        //        oneWave tempWave2 = new oneWave();
        //        tempWave2.types.Add(tempType);
        //        tempWave2.types.Add(tempType2);

        //        oneLevel tempLevel = new oneLevel();
        //        tempLevel.waves.Add(tempWave);
        //        tempLevel.waves.Add(tempWave2);


        //        string path = "Assets/Resources/GameJSONData/level1.json";
        //        string str = JsonUtility.ToJson(tempLevel);
        //        Debug.Log("str : "+str);
        //        using (FileStream fs = new FileStream(path, FileMode.Create))
        //        {
        //            using (StreamWriter writer = new StreamWriter(fs))
        //            {
        //                writer.Write(str);
        //            }
        //        }
        //#if UNITY_EDITOR
        //        UnityEditor.AssetDatabase.Refresh();
        //#endif
        //    }
    }
}
[Serializable]
public class oneType
{
    public string type;
    public int count;
}
[Serializable]
public class oneWave
{
    public List<oneType> types = new List<oneType>();
}

[Serializable]
public class oneLevel
{
    public List<oneWave> waves = new List<oneWave>();
}
