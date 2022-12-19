using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private Light sunLight;
    private bool isUp;
    // Start is called before the first frame update
    void Start()
    {
        sunLight = GetComponent<Light>();
        InvokeRepeating(nameof(DayNight), 1f, 1f);
    }

    // Update is called once per frame

    private void DayNight()
    {
        if (sunLight.intensity > 0.98f) isUp = false;
        if (sunLight.intensity < 0.02f) isUp = true;
        sunLight.intensity += (isUp) ? 0.01f: -0.01f;
    }
}
