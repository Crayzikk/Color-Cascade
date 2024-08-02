using System.Collections;
using UnityEngine;

public class PlatformColorChanger : MonoBehaviour
{
    [SerializeField] private Sprite blueSprite;
    [SerializeField] private Sprite pinkSprite;
    [SerializeField] private float interval;

    private string bluePlatform;
    private string pinkPlatform;

    private SpriteRenderer spriteRenderer;

    private void Start() 
    {
        bluePlatform = "BluePlatform";
        pinkPlatform = "PinkPlatform";

        spriteRenderer = GetComponent<SpriteRenderer>();
        SetSprite(blueSprite);
        
        StartCoroutine(ChangeColorNumerator());   
    }

    private IEnumerator ChangeColorNumerator()
    {
        while (true)
        {
            ChangeColor();
            yield return new WaitForSeconds(interval);
        }
    }

    private void ChangeColor()
    {
        SetSprite(CheckSprite(blueSprite) ? pinkSprite : blueSprite);
        SetLayerMask(gameObject.layer == LayerMask.NameToLayer(pinkPlatform) ? bluePlatform : pinkPlatform);
    }

    private bool CheckSprite(Sprite checkSprite) => spriteRenderer.sprite == checkSprite;
    private void SetSprite(Sprite newSprite) => spriteRenderer.sprite = newSprite;
    private void SetLayerMask(string layerMask) => gameObject.layer = LayerMask.NameToLayer(layerMask);
}
