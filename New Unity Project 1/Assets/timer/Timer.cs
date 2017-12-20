using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //GameObject car = GameObject.Find("Car");
    Rigidbody m_Rigidbody;
    //private car.Rigidbody m_Rigidbody;

    float countTime = 0;
    // Use this for initialization
    void Start()
    {
        m_Rigidbody = GameObject.Find("Car").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float fps = 1f / Time.deltaTime;
        countTime += Time.deltaTime; //スタートしてからの秒数を格納
        float speed = m_Rigidbody.velocity.magnitude;
        GetComponent<Text>().text = countTime.ToString("F3") + "[sec]\n" + speed.ToString("F3")+"[km/h]\n"+fps.ToString("F3"); //小数2桁にして表示
        
        /*GetComponent<Text>().text += "\n";
        GetComponent<Text>().text += ;*/
    }
}