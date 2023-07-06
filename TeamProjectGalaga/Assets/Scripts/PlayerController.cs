using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigid = default;
    public float speed = default;
    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();

        //playerRigid = null;

        Debug.Assert(playerRigid != null);

        if (playerRigid == null)
        {
            Debug.LogError("Player 의 RigidBody 컴포넌트를 찾을 수 없습니다.");
        }
        //GFunc.Log("이거 잘 찍힌다.");
    }

    // Update is called once per frame
    void Update()
    {

        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = speed * 2 * xInput;
        float zSpeed = speed * 2 * zInput;




        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigid.velocity = newVelocity;

    }       //Update()

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}           // class PlayerController
