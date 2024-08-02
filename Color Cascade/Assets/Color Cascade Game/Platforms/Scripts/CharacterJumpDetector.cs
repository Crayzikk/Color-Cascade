using UnityEngine;

public class CharacterJumpDetector : MonoBehaviour
{
    public enum CharacterColor
    {
        Blue,
        Pink,
        None
    }

    public CharacterColor color; 

    private void Start() 
    {
        color = CharacterColor.None;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {   
        if(color == CharacterColor.None)
        {
            int layermask = other.gameObject.layer;

            if(LayerMask.NameToLayer("BluePlayer") == layermask)
            {
                color = CharacterColor.Blue;
            }    
            else if(LayerMask.NameToLayer("PinkPlayer") == layermask)
            {
                color = CharacterColor.Pink;
            }            
        }

    }
}
