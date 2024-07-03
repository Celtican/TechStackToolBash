using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Jumper))]
public class JumpOverTime : MonoBehaviour
{
    [SerializeField] private float timeBetweenJumps = 3;

    public void Start()
    {
        Jumper jumper = GetComponent<Jumper>(); // caching this for later use
        
        DOTween.Sequence() // This creates a new Sequence object, which DOTween registers immediately. A sequence lets us chain together tweens/intervals/callbacks into one object. It's very handy!
            .SetLink(gameObject) // This makes it so that if this game object is destroyed, the tween (or Sequence in this case) is automatically killed. This is very important, and every tween should have this!
            .SetLoops(-1) // This marks this as an infinitely occurring tween/sequence. When it finishes, it restarts.
            
            .AppendInterval(timeBetweenJumps) // This adds a duration of nothing happening to the sequence.
            .AppendCallback(() => jumper.Jump()); // After the interval, we call the Jump() function.
    }
}
