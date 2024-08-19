using UnityEngine;

public class PlayerLose : MonoBehaviour
{
    public static int playerDeathCount = 0;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "BluePlayer" || other.gameObject.tag == "PinkPlayer")
        {
            playerDeathCount++;
            LevelManager.ReloadLevel();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
