using UnityEngine;

public class Obsticles : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float deadZone = -15;

    // Update is called once per frame
    void Update()
    {
        ObsticleMove();
        DestroyObsticle();
    }

    private void ObsticleMove()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
    private void DestroyObsticle()
    {
        if(transform.position.x < deadZone)
            Destroy(gameObject);
    }

}
