using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] CheckpointText checkpointTextPrefab = null;
    CheckpointText checkpointText;
    ScenePersist scenePersist;
    bool hitCheckpoint = false;

    private void Start() 
    {
        scenePersist = FindObjectOfType<ScenePersist>();
        checkpointText = FindObjectOfType<CheckpointText>();
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player") && !hitCheckpoint)
        {
            scenePersist.hitCheckpoint = true; 
            scenePersist.playerSpawn = transform.position;
            Spawn();
            hitCheckpoint = true;
        }
    }

    public void Spawn()
    {
        CheckpointText instance = Instantiate<CheckpointText>(checkpointTextPrefab, transform);
    }
}
