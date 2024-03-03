using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Rigidbody2D rb;

    [SerializeField] private GameObject impactEffect;
    [SerializeField] private float randomScale;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * Speed;
    }

    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Instantiate(impactEffect,getRandom(randomScale,hitInfo.transform),Quaternion.identity);
        Destroy(gameObject);
    }
    public Vector2 getRandom(float randomScale,Transform hitInfo)
    {
        float rand1 = UnityEngine.Random.Range(-randomScale, randomScale);
        float rand2 = UnityEngine.Random.Range(-randomScale, randomScale);
        Vector2 pos = new Vector2(hitInfo.position.x + rand1,hitInfo.position.y + rand2);
        return pos;
    }

}
