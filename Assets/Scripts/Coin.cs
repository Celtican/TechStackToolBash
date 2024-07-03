using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip collectionSound;
    [SerializeField, Range(0f, 1f)] private float collectionSoundVolume;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // If the thing touching this coin is not a player, ignore it.
        if (collision.GetComponent<PlayerController>() == null) return;
        
        // Disable this component so it can't be triggered again.
        enabled = false;
        
        if (collectionSound != null)
        {
            // PlayClipAtPoint() creates a new game object, attaches an AudioSource to it, plays the clip, and then destroys the game object.
            // If we just used an AudioSource attached this coin object, then the sound effect would be cut off when the coin is destroyed.
            AudioSource.PlayClipAtPoint(collectionSound, transform.position, collectionSoundVolume);
        }
        
        
        // Here's a basic example DOTween effect. DOTween is awesome! You should use it if you aren't already!
        Tween tween = GetComponent<SpriteRenderer>().DOFade(0, 0.5f) // This creates a new tween that fades the SpriteRenderer's color's alpha value to 0 over 0.5 seconds 
            .SetEase(Ease.OutQuad) // This sets the ease type. For more info on different eases: https://easings.net/
            .SetLink(gameObject); // This is important! This marks the tween to be automatically destroyed when this game object is destroyed.

        tween.onComplete += () => // If you aren't familiar with this syntax, it's called a lambda function.
        {
            Destroy(gameObject);
        };
    }
}