using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] private GameObject PlayerNormal;
    [SerializeField] private GameObject PlayerWave;

    public void ChangePlayerSprite()
    {
        PlayerNormal.SetActive(!PlayerNormal.activeSelf);
        PlayerWave.SetActive(!PlayerWave.activeSelf);
    }
}
