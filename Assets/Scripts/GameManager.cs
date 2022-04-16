using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI bloodMeter;
    public TextMeshProUGUI dashAbleText;
    public TextMeshProUGUI dashLeftText;

    // Update is called once per frame
    void Update()
    {
        BloodMeter();
    }

    void BloodMeter()
    {
        bloodMeter.text = "Blood: " + Mathf.Round(player.blood);
        dashAbleText.text = "Can Dash: " + player.dashable;
        dashLeftText.text = "Dash Left: " + player.dashLeft;
    }
}
