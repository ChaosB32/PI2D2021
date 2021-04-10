using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
    PlayerController character;
    Rigidbody2D rgbd2D;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    private void Awake()
    {
        character = GetComponent<PlayerController>();
        rgbd2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }
    private void UseTool()
    {
        Vector2 position = rgbd2D.position * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach(Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if(hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }
}
