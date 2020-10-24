using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public UIController m_MenuController;
    public PlayerController_mobileJoystick playerController;
    public LevelManager m_CurrentLoadedLevel;

    void Start()
    {
        m_MenuController.SetActiveMainMenus();
        playerController.enabled = false;
    }

    public void StartLevel()
    {
        AdsManager.Instance.ShowRewardAd();
        m_MenuController.StartLevelUI();
        playerController.enabled = true;
        m_CurrentLoadedLevel.StartLevel();
        Debug.Log("level ID " + m_CurrentLoadedLevel.id);
    }
    
    public void LoadLevel()
    {
        EventSystem eventSystem = EventSystem.current;
        string buttonNumber = eventSystem.currentSelectedGameObject.gameObject.name;
        LevelManager level = new LevelManager();
        string jsonName = "GameJSONData/level_" + buttonNumber;
        string json = Resources.Load<TextAsset>(jsonName).text;
        JObject levelJsonObject = JObject.Parse(json);
        JArray waves = (JArray)levelJsonObject["waves"];
        level.id = (int)levelJsonObject["id"];
        for (int i = 0; i < waves.Count; i++)
        {
            JArray typesInWave = (JArray)levelJsonObject["waves"][i]["types"];
            Wave newWave = new Wave();
            for (int k = 0; k < typesInWave.Count; k++)
            {
                string type = (string)levelJsonObject["waves"][i]["types"][k]["type"];
                int count = (int)levelJsonObject["waves"][i]["types"][k]["count"];
                
                for (int j = 0; j < count; j++)
                {
                    string path = string.Format(@"Prefabs\enemies\{0}", type);
                    GameObject newEnemy = (GameObject)Resources.Load(path, typeof(GameObject));
                    newWave.enemies.Add(newEnemy.GetComponent<EnemyAI>());
                }
            }
            level.waves.Add(newWave);
        }
        m_CurrentLoadedLevel = level;
        m_CurrentLoadedLevel.OnLevelPassed += LevelFinsihed;
        StartLevel();
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

    public void LevelFinsihed()
    {
        m_MenuController.SetActiveMainMenus();
        playerController.enabled = false;
        PlayerPrefs.SetInt("lastUnlockedLevel", m_CurrentLoadedLevel.id);
        Debug.Log("CONGRATULATIONS! !! Level passed !!");
    }

    public void ResetGameProgress()
    {
        PlayerPrefs.DeleteAll();
    }
}

//[Serializable]
//public class oneType
//{
//    public string type;
//    public int count;
//}

//[Serializable]
//public class oneWave
//{
//    public List<oneType> types = new List<oneType>();
//}

//[Serializable]
//public class oneLevel
//{
//    public List<oneWave> waves = new List<oneWave>();
//}
