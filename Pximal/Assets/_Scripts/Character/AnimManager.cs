using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        animator.SetTrigger("Run");
    }
    public void Finish()
    {
        animator.SetTrigger("Finish");
    }
    public void Kick()
    {
        if (CharacterState.Instance.States == CharState.Finish)
        {
            int index = Random.Range(0, 3);

            if (index == 0)
            {
                animator.SetTrigger("Kick1");
            }
            else if (index == 1)
            {
                animator.SetTrigger("Kick2");
            }
            else
            {
                animator.SetTrigger("Kick3");
            }
        }
    }
    public void ToIdle()
    {
        animator.SetTrigger("Idle");
    }
}