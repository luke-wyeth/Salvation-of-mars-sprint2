﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    private SpringJoint2D cardSpring;

    // Start is called before the first frame update
    //object does not connect becuase it is false at the start
    //Recieve a gameobject with a tag "Backpack"
    void Start()
    {
        cardSpring = GetComponent<SpringJoint2D>();
        cardSpring.enabled = false;
        GameObject BackPack = GameObject.FindWithTag("Backpack");
        cardSpring.connectedBody = BackPack.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //Object should connect when a gameobject with a tag "Player" collides with it
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInfo pi = collision.gameObject.GetComponent<PlayerInfo>();

        if (collision.gameObject.tag == "Player" && !cardSpring.enabled)
        { 
            cardSpring.enabled = true;
            pi.collectedCard = true;
        }
    }
}