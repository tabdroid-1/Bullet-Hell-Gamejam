using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnHover : MonoBehaviour
{
    public Sprite normal;
    public Sprite hover;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }
    private void Update()
    {
        
    }



}
