using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] private string varName;

    private Animator animator;

    private void Start() 
    {
        animator = GetComponent<Animator>();
    }

    public void PlayIddle()
    {
        SetAnimation(0);
    }

    public void PlayWalk()
    {
        SetAnimation(1);
    }

    public void PlayJump()
    {
        SetAnimation(2);
    }

    public void PlayLand()
    {
        SetAnimation(3);
    }

    private void SetAnimation(int state)
    {
        if(animator != null && varName != null)
            animator.SetInteger(varName, state);
    }
}
