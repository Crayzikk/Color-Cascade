using UnityEngine;

public class SetSkins : MonoBehaviour
{
    public static SkinsCharacters skins;

    private void Start() 
    {
        skins = SkinsCharacters.Base;    
    }
}
