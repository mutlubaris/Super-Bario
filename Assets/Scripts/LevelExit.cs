using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 0f;

    ScenePersist scenePersist;

    private void Start() 
    {
        scenePersist = FindObjectOfType<ScenePersist>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        scenePersist.hitCheckpoint = false;
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(LevelLoadDelay);

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
