using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public bool[] level;
    [SerializeField, Range(1, 11)]private int sceneIndex;
    private SaveManager saveManager;
    private int levelIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelIndex = sceneIndex - 2;
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        level = saveManager.level;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneIndex);
            level[levelIndex] = true;
            saveManager.level[levelIndex] = level[levelIndex];
        }
    }
}
