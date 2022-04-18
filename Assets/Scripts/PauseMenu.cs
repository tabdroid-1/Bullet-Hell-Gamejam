using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]private GameObject canvas;
    private bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.))
        {
            if (paused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }

        
    }

    void Pause()
    {
        canvas.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    void Resume()
    {
        canvas.SetActive(true);
        Time.timeScale = 1f;
        paused = false;
    }
}
