using UnityEngine;
using UnityEngine.SceneManagement;
 
public class ScenePersist : MonoBehaviour 
{
    public Vector2 playerSpawn;
    [SerializeField] int liveForScene;
    public bool hitCheckpoint = false;
 
    private void Awake() 
    {
        ScenePersist[] SPs = FindObjectsOfType<ScenePersist>();
        liveForScene = SceneManager.GetActiveScene().buildIndex;
        if (SPs.Length > 1 && SPs[0].liveForScene == SPs[1].liveForScene) 
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
 
    private void Start() 
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene loadedScene, LoadSceneMode mode) 
    {
        if (SceneManager.GetActiveScene().buildIndex != liveForScene) 
        {
            Destroy(gameObject);
        }
    }
 
    private void OnDisable() 
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}