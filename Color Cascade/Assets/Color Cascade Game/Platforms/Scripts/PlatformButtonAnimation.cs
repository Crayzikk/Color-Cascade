using UnityEngine;

public class PlatformButtonAnimation : MonoBehaviour
{
    public bool playerActiveButton;

    private Animator animator;
    private bool buttonPressed;
    private string tagPlayerPressed;

    private void Start() 
    {
        buttonPressed = false;
        playerActiveButton = false;
        animator = GetComponentInParent<Animator>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if((other.gameObject.tag == "BluePlayer" || other.gameObject.tag == "PinkPlayer") && !buttonPressed)
        {
            buttonPressed = true;
            playerActiveButton = true;
            tagPlayerPressed = other.gameObject.tag;
        }          
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == tagPlayerPressed && buttonPressed)
        {
            buttonPressed = false;
            playerActiveButton = false;
            tagPlayerPressed = "";
        }         
    }

    public void ButtonActive()
    {
        animator.SetBool("ButtonActive", true);
    }

    public void ButtonDeactive()
    {
        animator.SetBool("ButtonActive", false);
    }
}
