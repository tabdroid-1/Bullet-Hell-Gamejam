using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]private GameObject canvas;
    [SerializeField]private Player player;
    private bool paused = false;

    [SerializeField]private SaveManager saveManager;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !player.dead)
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    void Pause()
    {
        canvas.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Resume()
    {
        canvas.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void Retry()
    {
        paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void ReturnToMainMenu()
    {
        saveManager.Save();
        SceneManager.LoadScene("MainMenu");
    }
}
