using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveAreaScript : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();


        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            animator.SetTrigger("Level1");
        }
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            animator.SetTrigger("Level2");
        }
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            StartCoroutine(Level3());
        }
        if (SceneManager.GetActiveScene().name == "Level 4")
        {
            animator.SetTrigger("Level4");
        }
        if (SceneManager.GetActiveScene().name == "Level 5")
        {
            animator.SetTrigger("Level5");
        }
        if (SceneManager.GetActiveScene().name == "Level 6")
        {
            animator.SetTrigger("Level6");
        }
        if (SceneManager.GetActiveScene().name == "Level 7")
        {
            animator.SetTrigger("Level7");
        }
        if (SceneManager.GetActiveScene().name == "Level 8")
        {
            animator.SetTrigger("Level8");
        }
        if (SceneManager.GetActiveScene().name == "Level 9")
        {
            animator.SetTrigger("Level9");
        }
        if (SceneManager.GetActiveScene().name == "Level 10")
        {
            animator.SetTrigger("Level10");
        }

    }

    IEnumerator Level3()
    {
        yield return new WaitForSeconds(10);
        animator.SetTrigger("Level3");
    }
}
