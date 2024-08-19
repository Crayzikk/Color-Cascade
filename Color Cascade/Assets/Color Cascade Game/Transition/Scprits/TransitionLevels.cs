using UnityEngine;

public class TransitionLevels : MonoBehaviour
{
    [SerializeField] private Canvas joysicCanvas;
    private Animator animator;

    private void Start() 
    {
        SetSortingJoystic(10);
        animator = GetComponent<Animator>();
        SetAnimation(true);
        Invoke("HideJoystics", 0.5f);
    }

    public void SetSortingJoystic(int value) => joysicCanvas.sortingOrder = value;
    public void SetTransitionTrue() => EndLevel.transitionComplete = true;
    public void SetAnimation(bool state) => animator.SetBool("Transition", state);
    public void HideJoystics() => SetSortingJoystic(15);
}
