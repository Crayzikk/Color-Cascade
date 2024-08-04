using UnityEngine;

public class AllCharactersOnLastPlatform : MonoBehaviour
{
    private bool bluePlayerComplete;
    private bool pinkPlayerComplete;
    private bool verifyRun;

    private void Start() 
    {
        bluePlayerComplete = false;
        pinkPlayerComplete = false;
        verifyRun = false;    
    }

    private void Update() 
    {
        if ((bluePlayerComplete && pinkPlayerComplete) && !verifyRun)
        {
            verifyRun = true;
            Invoke("VerifyCharactersOnPlatform", 0.5f);
        }    
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "BluePlayer")
            bluePlayerComplete = true;
            
        if(other.gameObject.tag == "PinkPlayer")
            pinkPlayerComplete = true;
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.tag == "BluePlayer")
            bluePlayerComplete = false;
            
        if(other.gameObject.tag == "PinkPlayer")
            pinkPlayerComplete = false;
    }

    private void VerifyCharactersOnPlatform()
    {
        if(bluePlayerComplete && pinkPlayerComplete)
        {
            EndLevel.levelComplete = true;
        }
        else
        {
            verifyRun = false;
        }
    }
}
