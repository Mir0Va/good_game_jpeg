using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorHit : MonoBehaviour
{
        [SerializeField] private PlayerWave playerWave;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Sensor"))
            {
                playerWave.changePlayerSensed(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Sensor"))
            {
                playerWave.changePlayerSensed(false);
            }
        }
}
