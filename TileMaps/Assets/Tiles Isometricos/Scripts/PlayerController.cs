using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    // Inventario do Jogador
    public InventoryObject inventory;
    public ShopObject shop;
    public GameObject inventoryPanel;
    public bool inventoryShow = false;  

    public GameObject shopPanel;
    public bool shopShow = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            inventory.Load();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(inventoryShow == false)
            {
                inventoryShow = true;
                inventoryPanel.SetActive(true);
            }
            else
            {
                inventoryShow = false;
                inventoryPanel.SetActive(false);
            }
        }
        

    }
    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change 
            * speed * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Loja")
        {
            if (shopShow == false)
            {
                shopShow = true;
                shopPanel.SetActive(true);
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Loja")
        {
            if (shopShow == true)
            {
                shopShow = false;
                shopPanel.SetActive(false);
            }
        }
    }
    
    private void OnApplicationQuit()
    {
        inventory.Container.Clear(); 
    }

}
