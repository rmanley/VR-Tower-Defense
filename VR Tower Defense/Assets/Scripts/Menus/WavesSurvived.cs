using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesSurvived : MonoBehaviour
{

    public Text WavesNumber;
    private int waves;

    private void Awake()
    {
        waves = WaveSpawner.waveIndex;
    }

    // Update is called once per frame
    void Update()
    {
        WavesNumber.text = waves.ToString();
    }
}
