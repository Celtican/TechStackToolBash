using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Jumper), typeof(GroundDetector))]
public class PlayerController : MonoBehaviour
{
    // Hello programmer person! If you celebrate July 4th, I hope it was/will be a *blast*!
    //
    // Also, cheers to a fantastic Level 3! Personal advice from Dylan: try not to worry about the House Cup
    // too much. It's fun and all, but ultimately you are here to learn and grow! So don't take the cup too seriously.
    //
    // That said, it is still fun, so the first person to post that they found this little message in the
    // #level-3-cohort-7 channel and pings @Dylan! will get 5 House Cup Points! (Prefects are excluded since they got the project early)
    
    private Mover mover;
    private Jumper jumper;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    public void Start()
    {
        mover = GetComponent<Mover>();
        jumper = GetComponent<Jumper>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame, around 60 times a second
    void Update()
    {
        //Listen for key presses and move left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            mover.AccelerateInDirection(new Vector2(-1, 0));
            spriteRenderer.flipX = true;
        }

        //Listen for key presses and move right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            mover.AccelerateInDirection(new Vector2(1, 0));
            spriteRenderer.flipX = false;
        }

        //Listen for key presses and jump
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            jumper.Jump();

            //Play a Jump Sound
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
