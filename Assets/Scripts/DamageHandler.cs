using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler: MonoBehaviour {

   public int health = 1;
   public float invulnPeriod = 0;     
   float invulnTimer = 0;
   int correctlayer;
   float invulnAnimTimer=0;

   SpriteRenderer spriteRend;
  void Start() {
      correctlayer = gameObject.layer;

//Only get the renderer on the parent object. Doesnt work for children i.e. "Enemy01".
      spriteRend = GetComponent<SpriteRenderer>();

      if(spriteRend == null) {
          spriteRend = GetComponent<SpriteRenderer>();

        if(spriteRend==null){
          Debug.LogError("Object '"+gameObject.name+"' has no sprite renderer.");
      } 
    }
   }


    void OnTriggerEnter2D(){
        health-- ;
        if(invulnPeriod > 0){
        invulnTimer = invulnPeriod;
        gameObject.layer = 10;
     }
  
    }
    void Update(){

       if(invulnTimer > 0){
        invulnTimer -= Time.deltaTime;

        if(invulnTimer <= 0){
            gameObject.layer = correctlayer;
            if(spriteRend != null){
                spriteRend.enabled = true;
            }
        }
        else{
            if(spriteRend != null){
                spriteRend.enabled = !spriteRend.enabled;
            }
        }
       }

        if(health <= 0){
            Die();       
        }
    }
    void Die(){
        Destroy(gameObject);
    }
}
