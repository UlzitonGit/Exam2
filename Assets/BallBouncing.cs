using UnityEngine;

public class BallBouncing : MonoBehaviour
{
    [SerializeField] private Material[] material;
    private MeshRenderer mesh;
    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            mesh.material = material[Random.Range(0, material.Length)];
        }
    }
}
