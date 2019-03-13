using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMon_Ani_Test : MonoBehaviour
{
    public float wonderTime;
    public float movementSpeed;

    public const string IDLE = "Idle";
    public const string RUN = "Run";
    public const string ATTACK = "Attack";
    public const string DAMAGE = "Damage";
    public const string DEATH = "Death";

    

    Animation anim;


    GameObject Mushroom;

    //public enum FSMState
    //{
    //    Idle,
    //    Run,
    //    Dead,
    //}

    //void FixedUpdate()
    //{
    //    FSMUpdate();
    //}

    //void FSMUpdate()
    //{
    //    switch (currentState)
    //    {
    //        case FSMState.Run:
    //            UpdateRunState();
    //            break;
    //        case FSMState.Idle:
    //            UpdateIdleState();
    //            break;
    //        case FSMState.Dead:
    //            UpdateDeadState();
    //            break;
    //    }

    //}



    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if (wonderTime > 0)
        {
            transform.transform.Translate(Vector3.forward * movementSpeed);
            wonderTime -= Time.deltaTime;
        }

        else
        {
            wonderTime = Random.Range(1.0f, 5.0f);
            Wonder();
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
            collision.collider.transform.localScale *= 1.1f;
        }
    }
}