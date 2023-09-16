using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorHit : MonoBehaviour
{
        [SerializeField] private PlayerWave playerWave;

        [SerializeField] private Collision2D sensorcollider;


        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Sensor"))
            {
                Debug.Log("Enter!");
                playerWave.changePlayerSensed(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Sensor"))
            {
                Debug.Log("Exit!");
                playerWave.changePlayerSensed(false);
            }
        }
}
