using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject levelUI;
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject creditsUI;

    public void OpenDevMap()
    {
        SceneManager.LoadScene(1);
    }

    public void ReloadDemo()
    {
        SceneManager.LoadScene(3);
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
    }

    public void Credits()
    {
        levelUI.SetActive(false);
        mainMenuUI.SetActive(false);
        creditsUI.SetActive(true);
    }

    public void Back()
    {
        levelUI.SetActive(false);
        mainMenuUI.SetActive(true);
        creditsUI.SetActive(false);

    }

    public void Level1()
    {
        SceneManager.LoadScene(4);
    }
    public void Level2()
    {
        SceneManager.LoadScene(5);
    }
    public void Level3()
    {
        SceneManager.LoadScene(6);
    }
    public void Level4()
    {
        SceneManager.LoadScene(7);
    }


}
