using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private TransitionLevels transitionLevels;

    public static bool levelComplete;
    public static bool transitionComplete;

    private void Start() 
    {
        levelComplete = false;
        transitionComplete = false;    
    }

    private void Update() 
    {
        if(levelComplete && !transitionComplete)
        {
            transitionLevels.SetAnimation(false);
        }
        else if(levelComplete && transitionComplete)
        {
            LevelManager.LoadNextLevel();
        }    
    }
}
