using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimator : MonoBehaviour
{
    [SerializeField] Animator thisAnimator;
    Vector3 oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        oldPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        SetMovement();
    }

    public virtual void SetMovement()
    {
        if (Vector3.Distance(oldPosition, transform.position) > .1f * Time.deltaTime) 
            thisAnimator.SetBool("Running", true);
        else 
            thisAnimator.SetBool("Running", false);

        oldPosition = transform.position;
    }

    public virtual void AnimateDeath()
    {
        thisAnimator.SetTrigger("Die");
    }

    public virtual void AnimateGotHit()
    {
        thisAnimator.SetTrigger("Got Hit");
    }
    public virtual void AnimateBowAttack()
    {
        thisAnimator.SetTrigger("Bow Attack");
    }
    public virtual void AnimateMeleeAttack()
    {
        thisAnimator.SetTrigger("Melee Attack");
    }
}
