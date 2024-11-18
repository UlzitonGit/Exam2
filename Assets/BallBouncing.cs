using System;
using UnityEngine;

public class BallBouncing : MonoBehaviour
{
    [SerializeField] private Material[] material;
    [SerializeField] int vel;
    private MeshRenderer mesh;
    Rigidbody rb;
    public bool canChangeMaterial = true;
    float timer;
    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (MathF.Abs(rb.velocity.y) < vel && canChangeMaterial == true)
        {
            timer = 0;
            canChangeMaterial = false;
            ChangeColor();
        }
        if(MathF.Abs(rb.velocity.y) > vel) canChangeMaterial = true;
        if(canChangeMaterial == false) print(timer);
    }
    private void ChangeColor()
    {
        mesh.material = material[UnityEngine.Random.Range(0, material.Length)];
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            ChangeColor();
        }
    }
}
