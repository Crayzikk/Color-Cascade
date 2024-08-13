using UnityEngine;

public class CharacterSkinLoader : MonoBehaviour
{        
    [SerializeField] private GameObject[] baseSkinCharacters;

    public GameObject[] GetCharacters()
    {
        return baseSkinCharacters;
    }
}
