using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    public float steerAngle;
    public float enginPower;
    public Vector3 centerOfMass;

    public Rigidbody rb;

    public Vector3 localScale;

    public WheelCollider[] wheels;
    public Transform[] visualWheels;

    public int score = 0;
    public int redLeft = 15;
    public int greednLeft = 30;

    [SerializeField]
    private Text Text_Score;
    [SerializeField]
    private GameObject Text_Win;
    [SerializeField]
    private GameObject Text_Lose;

    void Start()
    {
        rb.centerOfMass = centerOfMass;
        Text_Lose.SetActive(false);
        Text_Win.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < wheels.Length; i++)
        {
            Vector3 pos;
            Quaternion rot;
            wheels[i].GetWorldPose(out pos, out rot);
            visualWheels[i].position = pos;
            visualWheels[i].rotation = rot;
        }

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        wheels[0].motorTorque = v * enginPower;
        wheels[1].motorTorque = v * enginPower;

        wheels[2].steerAngle = h * steerAngle;
        wheels[3].steerAngle = h * steerAngle;

        localScale = transform.localScale;

        Text_Score.text = "Score : " + score.ToString();

        if (score <= -5 || greednLeft == 0)//输了
        {
            Text_Lose.SetActive(true);
        }

        if (score >= 5)//赢
        {
            Text_Win.SetActive(true);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Red")
        {
            score = score - 1;
            redLeft = redLeft - 1;
        }

        if(collision.collider.tag == "Green")
        {
            score = score + 1;
            greednLeft = greednLeft - 1;
        }
    }

}
