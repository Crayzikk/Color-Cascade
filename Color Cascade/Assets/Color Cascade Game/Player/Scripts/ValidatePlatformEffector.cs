using UnityEngine;

public class ValidatePlatformEffector : MonoBehaviour
{
    private string layer = "GroundEffector";
    private PlayerController playerController;

    private void Start() 
    {
        playerController = GetComponentInParent<PlayerController>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == layer)
            playerController.CheckPlatformEffectorWorked();       
    }
}
