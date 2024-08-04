using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager
{
    public static void LoadNextLevel()
    {
       
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

        if(nextLevel < SceneManager.sceneCountInBuildSettings)
        {
            LevelManager.LoadLevel(nextLevel);
        }
        else
        {
            LevelManager.LoadMenu();
        }
    }
    
    public static void ReloadLevel() => LoadLevel(SceneManager.GetActiveScene().buildIndex);
    public static void LoadLevel(int indexLevel) => SceneManager.LoadScene(indexLevel);
    public static void LoadMenu() => SceneManager.LoadScene("Menu");
}
