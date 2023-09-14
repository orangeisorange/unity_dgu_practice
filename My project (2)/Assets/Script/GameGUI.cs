using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGUI : MonoBehaviour
{
    public Text guiMeter;
    public static int meter;
    public float timePrev;

    // Start is called before the first frame update
    void Start()
    {
        meter = 0;
        timePrev = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timePrev > 1.0f)
        {
            timePrev = Time.time;
            meter++;
        }
        guiMeter.text = meter + "m";
    }
}
