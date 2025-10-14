using UnityEngine;

public class ObsticleParent : MonoBehaviour
{
    [Header("Spawn Obsticle Create")]
    [SerializeField] private float offset;
    [SerializeField] private GameObject ObsticlePrefab;
    private float time = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateRandomObsticle();
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.SetMinDelay();
        if (time < GameManager.instance.ObstacleSpawnDelay)
        {
            time += Time.deltaTime;
        }
        else
        {
            CreateRandomObsticle();
            time = 0;   
        }
    }
    private void CreateRandomObsticle()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(transform.position.y - offset, transform.position.y + offset), 0);
        Instantiate(ObsticlePrefab, spawnPos, transform.rotation, transform);
    }

    
}
