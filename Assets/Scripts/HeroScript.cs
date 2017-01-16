using UnityEngine;
using System.Collections;

/// <summary>
/// This script is for the hero to use only
/// All of it's movement logic and movement animation is here
/// </summary>
public class HeroScript : MonoBehaviour {
    Animator HeroAnimation;
    Rigidbody2D HeroRB; // We will be using the velocity of the character instead!

	// Use this for initialization
	void Start () {
        // Getting the components from the hero
        HeroAnimation = GetComponent<Animator>();
        HeroRB = GetComponent<Rigidbody2D>();
        HeroAnimation.Play("HeroDown"); // We will default the animation to play hero down!
	}
	
    // Using Fixed Update so that the movement call will be consistent and used for physics
    void FixedUpdate()
    {

    }
}
