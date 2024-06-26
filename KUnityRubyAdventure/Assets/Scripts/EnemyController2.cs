using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController2 : MonoBehaviour
{
    public float speed;
    [SerializeField] ScoreScript scoreScript;
    public bool vertical;
    public float changeTime = 3.0f;
    public AudioClip fixClip;
    public AudioClip hitClip;

    public ParticleSystem SmokeEffect;
    AudioSource audioSource;


#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    Rigidbody2D rigidbody2D;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    float timer;
    int direction = 1;
    bool broken = true;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //remember ! inverse the test, so if broken is true !broken will be false and return won�t be executed.
        
        if (!broken)
        {
            
            return;
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        
    }

    void FixedUpdate()
    {
        //remember ! inverse the test, so if broken is true !broken will be false and return won�t be executed.
        if (!broken)
        {
            
            return;
        }

        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }

        rigidbody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
            PlaySound(hitClip);
        }
    }

    //Public because we want to call it from elsewhere like the projectile script
    public void Fix()
    {
        
        scoreScript.ChangeScore();
        broken = false;
        rigidbody2D.simulated = false;
        //optional if you added the fixed animation
        animator.SetTrigger("Fixed");
        PlaySound(fixClip);
        SmokeEffect.Stop();
        

    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

}