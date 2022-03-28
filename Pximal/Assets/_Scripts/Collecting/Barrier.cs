using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private string targetTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            var x = other.GetComponentInParent<Collector>();

            x.RemoveBox();          
        }
    }
}