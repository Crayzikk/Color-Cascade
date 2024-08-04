using UnityEngine;

public class PlayerLose : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "BluePlayer" || other.gameObject.tag == "PinkPlayer")
        {
            LevelManager.ReloadLevel();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
