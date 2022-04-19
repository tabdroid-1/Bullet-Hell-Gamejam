using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadScreen : MonoBehaviour
{
    public Player player;
    [SerializeField] private GameObject deadCanvas;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.dead)
        {
            deadCanvas.SetActive(true);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
