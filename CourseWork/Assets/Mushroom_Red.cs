using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mushroom_Red : MonoBehaviour
{
    public float wonderTime;
    public float movementSpeed;

    public const string IDLE = "Idle";
    public const string RUN = "Run";
    public const string ATTACK = "Attack";
    public const string DAMAGE = "Damage";
    public const string DEATH = "Death";

    public const int STATE_STAND = 0;
    public const int STATE_WALK = 1;
    public const int STATE_RUN = 2;

    private int NowState;
    public GameObject Player;
    public const int AI_THINK_TIME = 2;
    public const int AI_ATTACT_DISTANCE = 50;
    private float LastThinkTime;

    Animation anim;


    GameObject Mushroom;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        //if (wonderTime > 0)
        //{
        //    transform.transform.Translate(Vector3.forward * movementSpeed);
        //    wonderTime -= Time.deltaTime;
        //}

        //else
        //{
        //    wonderTime = Random.Range(1.0f, 5.0f);
        //    Wonder();
        //}

        if (Vector3.Distance(transform.position, Player.transform.position) < AI_ATTACT_DISTANCE)
        {
            //敌人开始奔跑
            this.GetComponent<Animation>().Play("Run");
            //敌人进入奔跑状态
            NowState = STATE_RUN;
            //使敌人面向角色
            transform.LookAt(Player.transform);
            //向玩家靠近
            transform.Translate(Vector3.forward * Time.deltaTime * 10);
        }
        else
        {
            //当当前时间与上一次思考时间的差值大于怪物的思考时间时怪物开始思考
            if (Time.time - LastThinkTime > AI_THINK_TIME)
            {
                //开始思考
                LastThinkTime = Time.time;
                //获取0-3之间的随机数字
                int Rnd = Random.Range(0, 2);
                //根据随机数值为怪物赋予不同的状态行为
                switch (Rnd)
                {
                    case 0:
                        //站立状态
                        this.GetComponent<Animation>().Play("Idle");
                        NowState = STATE_STAND;
                        break;

                    case 1:
                        //行走状态
                        //使怪物旋转以完成行走动作
                        Quaternion mRotation = Quaternion.Euler(0, Random.Range(1, 5) * 90, 0);
                        transform.rotation = Quaternion.Slerp(transform.rotation, mRotation, Time.deltaTime * 1000);
                        //播放动画
                        this.GetComponent<Animation>().Play("Run");
                        //改变位置
                        transform.Translate(Vector3.forward * Time.deltaTime * 8);
                        NowState = STATE_WALK;
                        break;

                    case 2:
                        //奔跑状态
                        this.GetComponent<Animation>().Play("Run");
                        transform.Translate(Vector3.forward * Time.deltaTime * 10);
                        NowState = STATE_RUN;
                        break;
                }
            }
        }

    }

    void Wonder()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }

    public void IdleAni()
    {
        anim.CrossFade(IDLE);
    }

    public void RunAni()
    {
        anim.CrossFade(RUN);
    }

    public void AttackAni()
    {
        anim.CrossFade(ATTACK);
    }

    public void DamageAni()
    {
        anim.CrossFade(DAMAGE);
    }

    public void DeathAni()
    {
        anim.CrossFade(DEATH);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {

            anim.Play(DEATH);
            Destroy(this.gameObject);
            collision.collider.transform.localScale *= 0.9f;
        }
    }

}