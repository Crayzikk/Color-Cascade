using UnityEngine;

public class TransitionLevels : MonoBehaviour
{
    [SerializeField] private Canvas joysicCanvas;
    private Animator animator;

    private void Start() 
    {
        animator = GetComponent<Animator>();
        SetAnimation(true);
        joysicCanvas.sortingOrder = 15;
    }

    public void HideJoystic() => joysicCanvas.sortingOrder = 10;
    public void SetTransitionTrue() => EndLevel.transitionComplete = true;
    public void SetAnimation(bool state) => animator.SetBool("Transition", state);
}
