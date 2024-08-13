using UnityEngine;

public class PlatformButton : MonoBehaviour
{
    [SerializeField] private ColorPlatform colorPlatform;
    [SerializeField] private GameObject gameObjectPlatform;
    [SerializeField] private Sprite blueSprite;
    [SerializeField] private Sprite pinkSprite;
    [SerializeField] private Sprite defaultSprite;

    private SpriteRenderer spriteRenderer;
    private PlatformButtonAnimation platformButtonAnimation;
    private string bluePlatform;
    private string pinkPlatform;
    private string defaultPlatform;

    private void Start() 
    {
        bluePlatform = "BluePlatform";
        pinkPlatform = "PinkPlatform";
        defaultPlatform = "NonePlatform";

        spriteRenderer = gameObjectPlatform.GetComponent<SpriteRenderer>();
        platformButtonAnimation = GetComponentInChildren<PlatformButtonAnimation>();
    }

    private void Update() 
    {
        if(platformButtonAnimation.playerActiveButton)
        {
            platformButtonAnimation.ButtonActive();
            if (colorPlatform == ColorPlatform.Pink)
            {
                SetSpriteRenderer(pinkSprite);
                SetLayerMask(pinkPlatform);
            }
            else
            {
                SetSpriteRenderer(blueSprite);
                SetLayerMask(bluePlatform);
            }
        }
        else
        {
            platformButtonAnimation.ButtonDeactive();
            SetSpriteRenderer(defaultSprite);
            SetLayerMask(defaultPlatform);
        }
    }

    private void SetSpriteRenderer(Sprite newSprite) => spriteRenderer.sprite = newSprite;
    private void SetLayerMask(string layerMask) => gameObjectPlatform.layer = LayerMask.NameToLayer(layerMask);
    
}
