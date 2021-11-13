using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class CharacterController : MonoBehaviour
{
    Rigidbody2D rb;
    CharacterCharacteristic characteristic;
    CharacterMovement characterMove;
    GameObject character;
    public float rayLen;
    
    void Start()
    {
        rb = gameObject.GetComponent("Rigidbody2D") as Rigidbody2D;
        character = gameObject;
        characteristic = character.GetComponent("CharacterCharacteristic") as CharacterCharacteristic;
        characterMove = character.GetComponent("CharacterMovement") as CharacterMovement;
    }

    void Update()
    {
        characterMove.Move(Input.GetAxis("Horizontal"));
        if(Is_Ground() && Input.GetButtonDown("Vertical"))
        {
            characterMove.Jamp();
        }
        if(Is_ForwardWall())
        {
            characterMove.Climb(Input.GetAxis("Vertical"));
        }
        
    }
    public bool Is_Ground()
    {
        bool is_ground;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, (transform.position.y-transform.localScale.y/2-0.001f)), -Vector2.up * rayLen,rayLen);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y-(transform.localScale.y/2-0.001f)), -Vector2.up * rayLen, Color.yellow);
        if(hit.collider != null && hit.collider.tag == "Ground")
        {
            is_ground = true;
        }
        else
        {
            is_ground = false;
        }
        Debug.Log(is_ground);
        Debug.Log(hit.collider);
        return is_ground;
    }
    public bool Is_ForwardWall()
    {
        bool is_ForwardWall;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2((transform.position.x+(transform.localScale.x)/2+0.001f),transform.position.y), Vector2.right * rayLen, rayLen);
        Debug.DrawRay(new Vector2((transform.position.x+(transform.localScale.x)/2+0.001f),transform.position.y), Vector2.right * rayLen, Color.red);
        if(hit.collider != null && hit.collider.tag == "Ground")
        {
            is_ForwardWall = true;
        }
        else
        {
            is_ForwardWall = false;
        }
        Debug.Log(is_ForwardWall);
        return is_ForwardWall;
    }
}
