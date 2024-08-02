using UnityEngine;

public class PlatformActionHandler : MonoBehaviour
{
    [SerializeField] private Sprite blueSprite;
    [SerializeField] private Sprite pinkSprite;

    private CharacterJumpDetector characterJumpDetector;
    private SpriteRenderer spriteRenderer;

    private void Start() 
    {
        characterJumpDetector = GetComponent<CharacterJumpDetector>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() 
    {
        if(characterJumpDetector.color == CharacterJumpDetector.CharacterColor.Blue)
        {
            SetColorPlatform("BluePlatform", blueSprite);
        }    
        else if(characterJumpDetector.color == CharacterJumpDetector.CharacterColor.Pink)
        {
            SetColorPlatform("PinkPlatform", pinkSprite);
        }
    }
    
    private void SetColorPlatform(string layerName, Sprite newSprite)
    {
        gameObject.layer = LayerMask.NameToLayer(layerName);
        spriteRenderer.sprite = newSprite;
    }
}
