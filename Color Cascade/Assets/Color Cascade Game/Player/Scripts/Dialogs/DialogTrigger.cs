using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private string tagPlayer;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == tagPlayer)
        {
            Dialog dialog = other.gameObject.GetComponent<Dialog>();
            dialog.startDialog = true;
            Destroy(gameObject);
        }    
    }    
}
