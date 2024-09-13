using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public float maxlife = 100;
    public float life; 

    void Start(){
        life = maxlife;
    }


    public void takedamage(int damage){
        life -= damage;
        if (life < 0)
        {
            Destroy(gameObject);
        }
    }
}
