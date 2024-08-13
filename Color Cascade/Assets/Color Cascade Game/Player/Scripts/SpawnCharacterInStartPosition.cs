using UnityEngine;

public class SpawnCharacterInStartPosition : MonoBehaviour
{
    // Точки спавну персонажів, де індекс: 0 - синій персонаж, 1 - рожевий персонаж.
    [SerializeField] private Transform[] positionSpawn;
    [SerializeField] private CharacterSkinLoader characterSkinLoader;

    private GameObject[] characters;

    private void Start() 
    {
        // Получаємо префаби скінів персонажів, де індекс: 0 - синій персонаж, 1 - рожевий персонаж.
        characters = characterSkinLoader.GetCharacters();    

        for (int i = 0; i < positionSpawn.Length; i++)
        {
            Instantiate(characters[i], positionSpawn[i].position, Quaternion.identity);
        }
    }
}
