﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public ProjectileType self;
    public float maxActiveTime = 5f;
    public GameObject target;   

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.localScale *= self.size;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = self.sprite;
        this.gameObject.GetComponent<SpriteRenderer>().color = self.color;
        StartCoroutine("ActiveTime");
    }

    // Update is called once per frame
    void Update()
    {
 
        if (target != null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position,target.transform.position, self.speed * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyManager>() != null)
        {
            collision.GetComponent<EnemyManager>().ProjectileHit(self.damage);
            Destroy(this.gameObject);
        }
    }

    IEnumerator ActiveTime()
    {
        yield return new WaitForSeconds(maxActiveTime);

        Destroy(this.gameObject);
    }
}


