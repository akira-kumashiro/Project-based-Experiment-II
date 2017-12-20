using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]

    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        private Rigidbody m_Rigidbody;
        private static int frameNum = 0;

        [SerializeField] private GameObject FirstPersonCamera;   // インスペクターで主観カメラを紐づける
        [SerializeField] private GameObject ThirdPersonCamera;   // インスペクターで第三者視点カメラを紐づける

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            m_Rigidbody = GetComponent<Rigidbody>();
        }


        private void FixedUpdate()
        {
            const float scaleX = 1.0f;
            float scale2 = 0;
            const float scaleY = 1.0f;
            const float minSpeedScale = 0.001f;
            const float minSpeedScaleM = 0.0005f;
            float mousePositionXCenter = 0.0f;
            float mousePositionYCenter = 0.0f;
            // pass the input to the car!
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
            Vector3 mousePosition = Input.mousePosition;

            /*スクリーン中央を(0,0)に*/
            mousePositionXCenter = (mousePosition.x - Screen.width / 2) / Screen.width * scaleX*2;
            mousePositionYCenter = (mousePosition.y - Screen.height / 2) / Screen.height * scaleY*2;

            scale2 = (1 - minSpeedScale) * (float)System.Math.Exp(System.Math.Log((minSpeedScale - minSpeedScaleM) / (1 - minSpeedScale)) / m_Car.m_Topspeed * m_Rigidbody.velocity.magnitude);
            //float h = (float)System.Math.Pow(System.Math.Abs(mousePositionXCenter),2);//(m_Rigidbody.velocity.magnitude/ m_Car.m_Topspeed);
            float h = mousePositionXCenter * scale2;

            /*if (mousePositionXCenter < 0)
                h = -h;

            if (m_Rigidbody.velocity.magnitude < 0)
                h = -h;*/
            Debug.Log("mousePositionXCenter=" + mousePositionXCenter + ",mousePositionYCenter="+mousePositionYCenter+",h=" + h + ",scale2=" + scale2 + "Speed=" + m_Rigidbody.velocity.magnitude);
            //float v = CrossPlatformInputManager.GetAxis("Vertical");
            float v = mousePositionYCenter * scaleY;


            // スペースキーでカメラを切り替える
            if (Input.GetKey(KeyCode.A))
            {
                if (frameNum == 0)
                {// ↓現在のactive状態から反転 
                    FirstPersonCamera.SetActive(!FirstPersonCamera.activeInHierarchy);
                    ThirdPersonCamera.SetActive(!ThirdPersonCamera.activeInHierarchy);
                    frameNum = 20;
                }
                else
                    frameNum--;
            }

            if (Input.GetKeyDown(KeyCode.Q) || (m_Rigidbody.transform.rotation == Quaternion.Euler(180.0f, 0.0f, 0.0f) && m_Rigidbody.velocity.magnitude <= 2))
            {
                m_Rigidbody.transform.position = new Vector3(0.0f, 1.0f, 0.0f);
                m_Rigidbody.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
                m_Rigidbody.transform.Rotate(new Vector3(0.0f, 0.0f, 0.0f));
                m_Rigidbody.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                m_Rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            }
            if (Input.GetKey(KeyCode.N))
            {
                m_Rigidbody.velocity += m_Rigidbody.velocity/System.Math.Abs(m_Rigidbody.velocity.magnitude)*1.0f;
                
            }
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");

            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
