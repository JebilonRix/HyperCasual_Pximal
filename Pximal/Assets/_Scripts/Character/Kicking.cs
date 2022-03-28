using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kicking : MonoBehaviour
{
    [SerializeField] private Vector3 _finishStandPoint = new Vector3(0, 1.36f, 62);
    [SerializeField] private Collector _collector;
    [SerializeField] private AnimManager _animManager;

    private void Update()
    {
        if (CharacterState.Instance.States == CharState.Finish)
        {
            transform.position = _finishStandPoint;

            if (Input.GetMouseButtonDown(0))
            {
                _animManager.Kick();
                _collector.RemoveBox(true);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Invoke(nameof(Idle), 1f);
            }
        }
    }
    private void Idle()
    {
        _animManager.ToIdle();
    }
}