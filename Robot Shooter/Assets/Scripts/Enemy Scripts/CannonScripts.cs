 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScripts : MonoBehaviour
{
    private Transform player;
    public GameObject explosion;

    

    void Awake(){
        player = GameObject.Find("Robot").transform;
    }

    void Update(){
        if(player){
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), 2f * Time.deltaTime);
        }
    }

    void Damage(){
        Instantiate (explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnParticleCollision(GameObject target){
        if(target.name == "Muzzle"){
            Damage();
        }
    }
}
