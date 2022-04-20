using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject levelUI;
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject creditsUI;
    [SerializeField] private GameObject contactUI;
    [SerializeField] private GameObject controllsUI;

    private void Update()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    private SaveManager saveManager;
    public void OpenDevMap()
    {
       // SceneManager.LoadScene(1);
    }

    public void ReloadDemo()
    {
       // SceneManager.LoadScene(3);
    }

    public void ExitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void Play()
    {
        levelUI.SetActive(true);
        mainMenuUI.SetActive(false);
        creditsUI.SetActive(false);
        contactUI.SetActive(false);
        controllsUI.SetActive(false);
        saveManager.LoadSave();
    }

    public void Credits()
    {
        levelUI.SetActive(false);
        mainMenuUI.SetActive(false);
        creditsUI.SetActive(true);
        contactUI.SetActive(false);
        controllsUI.SetActive(false);
    }

    public void Back()
    {
        levelUI.SetActive(false);
        mainMenuUI.SetActive(true);
        creditsUI.SetActive(false);
        contactUI.SetActive(false);
        controllsUI.SetActive(false);
    }

    public void Contact()
    {
        levelUI.SetActive(false);
        mainMenuUI.SetActive(false);
        creditsUI.SetActive(false);
        contactUI.SetActive(true);
        controllsUI.SetActive(false);
    }
    public void Controlls()
    {
        levelUI.SetActive(false);
        mainMenuUI.SetActive(false);
        creditsUI.SetActive(false);
        contactUI.SetActive(false);
        controllsUI.SetActive(true);
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        if (saveManager.level[0])
            SceneManager.LoadScene(2);
    }
    public void Level3()
    {
        if (saveManager.level[1])
            SceneManager.LoadScene(3);
    }
    public void Level4()
    {
        if (saveManager.level[2])
            SceneManager.LoadScene(4);
    }
    public void Level5()
    {
        if (saveManager.level[3])
            SceneManager.LoadScene(5);
    }
    public void Level6()
    {
        if (saveManager.level[4])
            SceneManager.LoadScene(6);
    }
    public void Level7()
    {
        if (saveManager.level[5])
            SceneManager.LoadScene(7);
    }
    public void Level8()
    {
        if (saveManager.level[6])
            SceneManager.LoadScene(8);
    }
    public void Level9()
    {
        if (saveManager.level[7])
            SceneManager.LoadScene(9);
    }
    public void Level10()
    {
        if (saveManager.level[8])
            SceneManager.LoadScene(10);
    }

}
