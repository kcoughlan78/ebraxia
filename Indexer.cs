using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Indexer : MonoBehaviour
{
    public GameObject[] levels;
    private LevelManager levelManager;
    private int MaxLevel;
    private LevelIndex levelIndex;
    private Button LevelBtn;

    void Awake()
    {
        MaxLevel = PlayerPrefMgt.GetLevelKey();
    }

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelIndex = GameObject.FindObjectOfType<LevelIndex>();
        levels = GameObject.FindGameObjectsWithTag("LevelBtn");
        findMax();
        Debug.Log("no. of levels " + levels.Length);        
    }

    void Update()
    {

        Debug.Log("max level is " + MaxLevel);
        for (int i = 0; i < levels.Length; i++)
        {
            if (levels[i].GetComponent<LevelIndex>().LevelIndexNo <= MaxLevel)
            {
                levels[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                levels[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    void findMax()
    {
        if (MaxLevel < 2)
        {
            PlayerPrefMgt.SetLevelKey(2);
            MaxLevel = PlayerPrefMgt.GetLevelKey();
        } else
        {
            MaxLevel = PlayerPrefMgt.GetLevelKey();
        }
    }
}
