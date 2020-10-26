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
    static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }
    public UIController m_MenuController;
    public PlayerController_mobileJoystick playerController;
    private LevelManager m_CurrentLoadedLevel;
    private bool m_AdWatchedInThisLevel = false;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        m_MenuController.SetActiveMainMenus();
        playerController.enabled = false;
    }

    public void StartLevel()
    {
        m_AdWatchedInThisLevel = false;
        m_MenuController.StartLevelUI();
        playerController.enabled = true;
        m_CurrentLoadedLevel.StartLevel();
    }

    public void ClearWaveAndProceed()
    {
        ResetHealths();
        m_CurrentLoadedLevel.ClearCurrentWave();
    }
    
    public void ResetHealths()
    {
        IslandManager.Instance.m_IslandHealth.ResetHealth();
        PlayerController_mobileJoystick.Instance.m_PlayersHealth.ResetHealth();
    }

    public void LevelFailed()
    {
        if (!m_AdWatchedInThisLevel)
        {
            m_CurrentLoadedLevel.PauseLevel();
            UIController.Instance.m_InGameUIController.ShowAdsTab();
            m_AdWatchedInThisLevel = true;
        }
        else
        { 
            //stop game stuff
            
            //destroy all active enemies
            m_CurrentLoadedLevel.StopLevel();
            //reset all healths
            ResetHealths();
            //TO DO: remove traps

            //go to main menu and be ready for the next level
            playerController.enabled = false;
            UIController.Instance.SetActiveMainMenus();
        }
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
            JArray typesInWave = (JArray)levelJsonObject["waves"][i]["enemies"];
            Wave newWave = new Wave();
            for (int k = 0; k < typesInWave.Count; k++)
            {
                string type = (string)levelJsonObject["waves"][i]["enemies"][k]["type"];
                int count = (int)levelJsonObject["waves"][i]["enemies"][k]["count"];
                
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
    }

    public void LevelFinsihed()
    {
        m_MenuController.SetActiveMainMenus();
        playerController.enabled = false;
        if(m_CurrentLoadedLevel.id > PlayerPrefs.GetInt("lastUnlockedLevel"))
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
