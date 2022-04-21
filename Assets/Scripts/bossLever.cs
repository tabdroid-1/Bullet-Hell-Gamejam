using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossLever : MonoBehaviour
{
    private Lever lever;
    [SerializeField] private GameObject turrets;
    [SerializeField] private GameObject moveArea;
    // Start is called before the first frame update
    void Start()
    {
        lever = GetComponent<Lever>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lever.flipped)
        {
            Destroy(turrets);
            Destroy(moveArea);
        }
    }
}
