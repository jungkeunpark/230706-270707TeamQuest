using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigid = default;
    public float speed = default;
    public GameObject bulletPrefab = default;
    public float attackTimer = 0;
    public GameManager gameManager = default;

    public float attack_Speed = 0.2f;

    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigid.velocity = newVelocity;
        if (attack_Speed <= attackTimer)
        {
            if (Input.GetKey(KeyCode.Z)==true)
            {

                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                attackTimer = 0;
            }
        }

    }

    public void Die()
    {
        gameManager.EndGame();

        gameObject.SetActive(false);
    }
}