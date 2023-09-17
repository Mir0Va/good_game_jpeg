using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPoint : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            EndLevel();
        }
    }

    private static void EndLevel()
    {
        SceneManager.LoadScene(0);
    }
}
