using DG.Tweening;
using UnityEngine;

public class Flag : MonoBehaviour
{
    //We can tell it which screen to show in the inspector
    public GameObject winScreen;

    //Very simple script just listens to see if something touches it and shows a screen
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Here's a slightly more complicated DOTween effect! Visit the Coin script for a more basic example.
        DOTween.Sequence() // This creates a sequence, which is a collection of tweens that can be played sequentially
            .SetLink(gameObject)
            .SetUpdate(true) // This marks the sequence (and its tweens) to ignore Time.timeScale
            .Append(Camera.main.DOOrthoSize(Camera.main.orthographicSize * 0.8f, 1f) // This adds a tween to the sequence that scales the camera down to 0.8x of its original size over 1 second
                .SetEase(Ease.InOutQuad) // Adds a buttery smooth ease to this tween
            )
            .Join(DOTween.To( // `Join()` adds a new tween to be played alongside the previously-added tween to the sequence. `DOTween.To()` creates a custom tween. In this case, we are creating an effect that slows down the game world!
                () => Time.timeScale, // Getter method
                newTimeScale => Time.timeScale = newTimeScale, // Setter method
                0, // End value
                1f) // Duration in seconds
                .SetEase(Ease.Linear)) // I thought this effect might be better with linear time interpolation
            .AppendCallback(() => winScreen?.SetActive(true)); // You could also use the onComplete property instead of AppendCallback
    }
}