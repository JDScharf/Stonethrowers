using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowForceBar : MonoBehaviour
{
    public Slider mainSlider;
    private PlayerController playerScript;

    public void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        mainSlider.value = playerScript.throwForceUp;
        //Adds a listener to the main slider and invokes a method when the value changes.
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        Debug.Log(mainSlider.value);
    }

    public void Update()
    {
        mainSlider.value = playerScript.throwForceUp;
        Debug.Log(mainSlider.value);
    }
}

