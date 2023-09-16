using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private string[] _killOnCollisionTags;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Array.Exists(_killOnCollisionTags, element => collision.gameObject.CompareTag(element)))
        {
            Die();
        }
    }

    public static void Die()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    
}
