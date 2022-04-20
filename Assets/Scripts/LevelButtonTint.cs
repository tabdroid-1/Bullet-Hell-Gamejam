using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelButtonTint : MonoBehaviour
{
    public Button level;
    private SaveManager saveManager;
    [SerializeField] private int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        Button();
    }

    void Button()
    {
        if (!saveManager.level[index])
        {
            var colors = GetComponent<Button>().colors;
            colors.normalColor = Color.red;
            GetComponent<Button>().colors = colors;
            level.interactable = false;
        }
        if (saveManager.level[index])
        {
            var colors = GetComponent<Button>().colors;
            colors.normalColor = Color.green;
            GetComponent<Button>().colors = colors;
            level.interactable = true;
        }
    }
}
