using UnityEngine;
using System.Collections;
using System.Threading;

/// <summary>
/// This is to animate something. 
/// </summary>
public class AnimateObject : MonoBehaviour
{
    //Is this object meant to be animating right now?
    public bool animating;

    //Is the coroutine "delayAnimate" running?
    public bool delayRunning = true;

    //The time to wait between animations. 
    public float timeBetweenAnimation;

    //The sprite renderer attached to the object
    private SpriteRenderer spriteRenderer;


    //The sprites. Add more here if you need. 
    public Sprite unAnimated;
    public Sprite animated1;
    public Sprite animated2;

    // Use this for initialization
    void Start()
    {
        //Gets the sprite renderer attached to the same object the script is attached to
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Starts the animating function
        StartCoroutine(delayAnimate());
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// The function to make a timer to delay the animation by some time
    /// </summary>
    IEnumerator delayAnimate()
    {
        while (true)
        {
            if (animating)
            {
                //Calls the animate function
                Animate();
                //Waits some time before going again

            }
            else
            {
                spriteRenderer.sprite = unAnimated;

            }

            yield return new WaitForSeconds(0.5f);

        }
    }

    /// <summary>
    /// The function to change the sprites. 
    /// </summary>
    void Animate()
    {
        //Sees what sprite is active. Add more of these to order if you want more than 2 active animated sprites. 
        if (spriteRenderer.sprite == animated1)
        {
            //Changes the sprite to aniamted2
            spriteRenderer.sprite = animated2;
            print("animated 2");
        }
        else
        {
            //Changes the sprite to animated1
            spriteRenderer.sprite = animated1;
            print("Animated 1");
        }
    }
}

