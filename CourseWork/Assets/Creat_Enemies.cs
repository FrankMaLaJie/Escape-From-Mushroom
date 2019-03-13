using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creat_Enemies : MonoBehaviour
{
    public float myTime;
    public float rateTime = 5;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //myTime += Time.deltaTime;
        //if (myTime > rateTime)
        //{



        //    //Vector2 r = Random.insideUnitCircle * 10 ;//原点10m范围内随机生成enemy
        //    //Instantiate(enemy, new Vector3(r.x, 0, r.y), Quaternion.identity);
        //    Vector2 r = Random.insideUnitCircle.normalized * 30; //以玩家为圆心30m范围内生成怪
        //                                                         //  Instantiate(enemy, player.position + new Vector3(r.x, 0, r.y), Quaternion.identity);

        //    //enemy随机方向
        //    Instantiate(enemy, player.position + new Vector3(r.x, 0, r.y), Quaternion.Euler(new Vector3(0, Random.Range(0.0f, 360.0f), 0)));
        //    // Instantiate(enemy);
        //    myTime -= rateTime;
        //}
    }
}
