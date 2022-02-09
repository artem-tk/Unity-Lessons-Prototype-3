using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody PlayerRb;
    private Animator PlayerAnim;
    public float JumpForce = 10;
    public float GravityModifier;
    public bool IsOnGround;
    public bool GameOver = false;
    public ParticleSystem ExplosionParticle;
    public ParticleSystem DirtParticle;
    public AudioClip JumpSound;
    public AudioClip CrashSound;
    private AudioSource PlayerAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        Physics.gravity *= GravityModifier;
        PlayerAnim = GetComponent<Animator>();
        PlayerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround && !GameOver)
        {
            PlayerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnGround = false;
            PlayerAnim.SetTrigger("Jump_trig");
            DirtParticle.Stop();
            PlayerAudio.PlayOneShot(JumpSound, 1f);
        }
    }

    private void OnCollisionEnter (Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground") && !GameOver)
        {
            IsOnGround = true;
            DirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver = true;
            Debug.Log("Game over!");
            PlayerAnim.SetBool("Death_b", true);
            PlayerAnim.SetInteger("DeathType_int", 1);
            ExplosionParticle.Play();
            DirtParticle.Stop();
            PlayerAudio.PlayOneShot(CrashSound, 1f);
        }
    }
}
