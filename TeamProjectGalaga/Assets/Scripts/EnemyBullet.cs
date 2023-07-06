using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = default;
    private Rigidbody rigid = default;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * speed;

        //Destroy(gameObject,3.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.Die();
            }
        }
    }

}
