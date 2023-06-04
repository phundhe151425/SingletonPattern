using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySprite : MonoBehaviour
{
    Score hud;


    void Start()
    {
        hud = GameObject.FindGameObjectWithTag("score").GetComponent<Score>();
    }
    // Update is called once per frame
    void Update()
    {
       
        

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    hud.AddPoints(1);
    //    //ObjectPool.instance.ReturnObjectToPool(gameObject);
    //    pool.ReturnObjectToPool(gameObject);
    //}
}
