using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

    
{
     Vector2 _startPosition;
     Rigidbody2D _rigidbody2D;
     SpriteRenderer _spriteRenderer;
     
    
    //Allows for lauch force and drag distance to be set in the editor 
    [SerializeField] float _launchForce = 1000;
    [SerializeField] float _maxDragDistance = 5;

    //Before game starts get components of rigid body and sprite renderer
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Set the Starting position and allow it to be interactable 
    public void Start()
    {
        _startPosition = _rigidbody2D.position;
        _rigidbody2D.isKinematic = true;
    
    }
    //Set line renderer positions
    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(1, _startPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);

    }
    //Change the sprite color when button is held down
    //Enable Line Renderer when button is held down
    void OnMouseDown()
    {
        _spriteRenderer.color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }
    //Release Player sprite
    //Calculate Direction between new position and starting position
    //Add force to the Direction and Normalize number
    //Make Player sprite uninteractable
    //Disable Line Renderer after launch
    //Change Sprite Color back to origional
    void OnMouseUp()
    {
        var currentPosition = _rigidbody2D.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();

        _rigidbody2D.isKinematic = false;
        _rigidbody2D.AddForce(direction * _launchForce);

        GetComponent<LineRenderer>().enabled = false;

        _spriteRenderer.color = Color.white;
    }
    //Move player sprite to mouse position on drag
    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPosition = mousePosition;

        float distance = Vector2.Distance(desiredPosition, _startPosition);
        if (distance > _maxDragDistance)
        {
            Vector2 direction = desiredPosition - _startPosition;
            direction.Normalize();
            desiredPosition = _startPosition + (direction * _maxDragDistance);
        }
        if (desiredPosition.x > _startPosition.x)
            desiredPosition.x = _startPosition.x;

        _rigidbody2D.position = desiredPosition;
    }

    //Start the ResetAfterDelay Coroutine after collision
     void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());
    }

    //Delay Player reset
    //Reset Player position
    //Make Player sprite interactable
    //Reset player speed to 0

    private IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(2);
        _rigidbody2D.position = _startPosition;
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.velocity = Vector2.zero;
    }
}
