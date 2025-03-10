﻿//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//// Script for Element GameObject and storage of updated element statistics
//public class ParticleObject : MonoBehaviour
//{

//    LevelManager levelManager;
//    ElementCollisionModel elementCollisionModel;


//    private string owner; //player who shoots the object
//    private int ID; //The id of the element
//    private float damage; //The damage that the object does to a player
//    private float life; //The time that an object remains a projectile
//    private float speed; //The speed of the elementObject
//    private bool isProjectile; //Dictates whether or not an element does damage to a player
//    private Vector2 direction;

//    public void initElement(LevelManager lm, elementData e, bool isP, string o)
//    {
//        levelManager = lm;
//        elementCollisionModel = lm.elementCollisionModel;

//        ID = e.ID;
//        name = e.name;
//        damage = e.damage;
  
//        isProjectile = isP;
//        owner = o;

//        direction = transform.right;
//    }

//    private void Update()
//    {


       
//    }

//    // Gets the element ID
//    public int GetID()
//    {
//        return ID;
//    }

//    public string GetName()
//    {
//        return name;
//    }

//    public string GetOwner()
//    {
//        return owner;
//    }

//    // Gets the projectile state of the element
//    public bool GetIsProjectile()
//    {
//        return isProjectile;
//    }

//    // When an element collides with something else
//    private void OnParticleCollision(Collider2D collision)
//    {
//        // We don't care if we collide with these objects
//        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Untagged" || collision.gameObject.tag == "Walls") return;

//        // This happens when objects are not spawned by the levelGenerator
//        if (elementCollisionModel == null) return;


//        //Debug.Log(tag + " : " + collision.tag);

//        // Get the ID of the element we collided with
//        int ID2 = int.Parse(collision.tag[0].ToString());

//        ElementCollisionModel.CollisionResult cr = elementCollisionModel.HandleInteraction(ID, ID2);

//        int i = 0;
//        foreach (string result in cr.elementResults)
//        {
//            if (result == "Destroy")
//            {
//                // Get environmental effect and then run it
//                // Destroy gameobject
//                if (i == 0) // We are evaluating outcome of THIS element object
//                    Destroy(this.gameObject);
//                else // We are evaluating outcome of COLLISION element object
//                    Destroy(collision.gameObject);
//            }
//            else if (result == "Stop")
//            {
//                direction = Vector2.zero;
//            }
//            else if (result == "Reflect")
//            {
//                direction = -transform.right;
//                owner = null;
//            }
//            i++;
//        }
//    }
//}
