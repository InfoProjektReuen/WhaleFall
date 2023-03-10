using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpriteAnimator : MonoBehaviour
{
    public event EventHandler OnAnimationLoopedFirstTime;
    public event EventHandler OnAnimationLooped;
    [SerializeField] private Sprite[] frameArray;
    int currentFrame;
    private float timer;
    private float frameRate = .1f;
    private SpriteRenderer spriteRenderer;
    private bool loop = false;
    //private bool isPlaying = true;
    private int loopCounter = 0;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= frameRate)
        {
            timer -= frameRate;
            currentFrame = (currentFrame + 1) % frameArray.Length;
            if (!loop && currentFrame == 0)
            {
                //StopPlaying();
            }
            else
            {
                spriteRenderer.sprite = frameArray[currentFrame];
            }
            if (currentFrame == 0)
            {
                loopCounter++;

                if (loopCounter == 1)
                {
                    if (OnAnimationLoopedFirstTime != null) { OnAnimationLoopedFirstTime(this, EventArgs.Empty); }
                }

                else if (OnAnimationLooped != null) { OnAnimationLooped(this, EventArgs.Empty); }
            }

        }
    }

    //private void StopPlaying()
    //{
        //isPlaying = false;
    //}
}
