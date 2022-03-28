using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private string targetTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            var x = other.GetComponent<Collector>();

            x.AddBox();

            this.gameObject.SetActive(false);
        }
    }  
}