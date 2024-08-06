using UnityEngine;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    public void Play()
    {
        LevelManager.LoadLevel(1);
    }

    public void Skins()
    {

    }

    public void Options()
    {

    }

    public void Quit()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
