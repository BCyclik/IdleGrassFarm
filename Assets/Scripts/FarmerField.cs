using UnityEngine;
using System;

public class FarmerField : MonoBehaviour
{
    // [SerializeField] private Transform area;
    public Item item;
    [SerializeField] private Grass[] grasses;
    [SerializeField] private float maxDelay = 3f;
    [SerializeField] private float minDelay = 0.5f;

    public float GetDelay() => UnityEngine.Random.Range(minDelay, maxDelay);
    
    private void Awake()
    {
        grasses = transform.GetComponentsInChildren<Grass>();
        for(int i = 0; i < grasses.Length; i++)
        {
            grasses[i].controller = this;
        }
    }
}