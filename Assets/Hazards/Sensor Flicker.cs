using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorFlicker : MonoBehaviour
{
    [SerializeField] private GameObject _sensorLight;
    private bool _actionComplete = true; 
    private IEnumerator coroutine;

    private void Start()
    {
        StartCoroutine(ligthflickering());
    }

    private IEnumerator ligthflickering()
    {
        while (true) // Infinite loop
        {
            for (int i=0; i < 7; i++)
            {
                turnLight();
                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(5.0f);
        }
    }
    private void flicker()
    {
        
    }
    private void turnLight()
    {
        _sensorLight.SetActive(!_sensorLight.activeSelf);
    }
}
