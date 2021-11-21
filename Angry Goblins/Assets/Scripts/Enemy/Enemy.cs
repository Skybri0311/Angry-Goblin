using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Enemy : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particleSystem;
    
    bool _hasDied;

    //When hit start the Die Coroutine
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDieFromCollision(collision))
        {
            StartCoroutine(Die());
        }
    }

    bool ShouldDieFromCollision(Collision2D collision)
    {
        if (_hasDied)
            return false;

        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
            return true;

        if (collision.contacts[0].normal.y < -0.5)
            return true;

        return false;
    }

    //Set the _hasDied bool to true
    //Set the sprite Renderer to the dead sprite sprite
    //Play the Particle animation
    //Add Score point
    //Wait for 1 second
    //Hide the object (dead)
    IEnumerator Die()
    {
        _hasDied = true;
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _particleSystem.Play();
        ScoreManager.instance.AddPoint();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);

    }


}
