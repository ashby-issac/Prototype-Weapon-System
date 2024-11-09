using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovementComponent : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($" OnCollisionEnter: {other.gameObject.name} ");
        // Destroy(gameObject);
        gameObject.SetActive(false);
    }
}