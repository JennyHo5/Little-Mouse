using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] Slider volumnSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeVolume() {
        AudioListener.volume = volumnSlider.value;
    }
}
