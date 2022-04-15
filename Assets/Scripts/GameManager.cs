using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public TextMeshProUGUI bloodMeter;

    // Update is called once per frame
    void Update()
    {
        BloodMeter();
    }

    void BloodMeter()
    {
        bloodMeter.text = "Blood: " + Mathf.Round(characterMovement.blood);
    }
}
