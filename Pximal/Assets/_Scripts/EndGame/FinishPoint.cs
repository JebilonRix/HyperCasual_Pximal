using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private string _tag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tag))
        {
            other.GetComponent<AnimManager>().Finish();
            other.GetComponent<CharacterState>().States = CharState.Finish;
        }
    }
}