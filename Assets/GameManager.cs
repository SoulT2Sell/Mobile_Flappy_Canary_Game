using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score = 0;
    public int Score
    { 
        get 
        {
            return score;
        } 
    }
    [SerializeField] private float obsticleSpawnDelay = 2;
    public float ObstacleSpawnDelay
    {
        get
        {  
            return obsticleSpawnDelay; 
        }
    }

    private readonly float minDelay = 2;

    private void Awake()
    {
        if(instance == null)    
            instance = this;
        else
            Destroy(instance);
    }
    public void SetMinDelay()
    {
        if (obsticleSpawnDelay < minDelay)
            obsticleSpawnDelay = minDelay;
    }
    public void RediusSpawnDelay() => obsticleSpawnDelay -= 0.5f;
    public void AddScore() => score++; 
    
}
