using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public GameObject _lantern, _blackView, _greenView;
    public Light lantern;
    public bool lightOn, flashOn;
    private float time;
    public List<float> intensities, ranges;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            lightOn = !lightOn;
           
            if(lightOn == true)
            {
                _lantern.SetActive(true);
                _blackView.SetActive(false);
                _greenView.SetActive(true);
            }           
            if(lightOn == false)
            {
                _lantern.SetActive(false);
                _blackView.SetActive(true);
                _greenView.SetActive(false);
            }
        }
        if(Input.GetKeyDown(KeyCode.Mouse0) && lightOn == true && flashOn == true)
        {
            FlashLight();
        }
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        if (time <= 1.5f)
        {
            LanterIntensity(0);
        }
        if (time <= 0 && flashOn == false)
        {
            flashOn = true;
        }
    }
    private void LanterIntensity(int i)
    {
        lantern.intensity = intensities[i];
        lantern.range = ranges[i];
    }

    private void FlashLight()
    {
        SoundManager.Instance.PlayeSound("Flash", false);
        time = 2f;
        flashOn = false;
        LanterIntensity(1);
    }
}
