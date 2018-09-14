//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Linq;
using BlackFireFramework.Unity;
using UnityEngine;

namespace Alan
{
    public sealed class AsynchronousFaceDetectionDemo : MonoBehaviour
    {
        [SerializeField] private Vector2 m_XRange= new Vector2(-5,5);
        [SerializeField] private Vector2 m_YRange= new Vector2(-5,5);
        [SerializeField] private Vector2 m_ZRange= new Vector2(-5,5);
        private void Start()
        {
            BlackFire.Graphics.OnFaceTrack += _OnFaceTrack;

            m_OriginPositon = m_TargetPositon = Camera.main.transform.position;
            m_OriginEulerAngles = m_TargetEulerAngles = Camera.main.transform.localEulerAngles;
        }


        
        private Vector3 m_OriginPositon;
        private Vector3 m_OriginEulerAngles;
        private Vector3 m_TargetPositon;
        private Vector3 m_TargetEulerAngles;
        private void _OnFaceTrack(object sender, FaceTrackerEventArgs args)
        {
            var x = args.Widthpercent * (m_XRange.y - m_XRange.x) + m_XRange.x;
            var y = args.Heightpercent * (m_YRange.y - m_YRange.x) + m_YRange.x;
            var z = args.Deeppercent * (m_ZRange.y - m_ZRange.x) + m_ZRange.x;
            
            m_TargetPositon = new Vector3(m_OriginPositon.x-x,m_OriginPositon.y-y,m_OriginPositon.z+z);
            
            var ex = m_OriginEulerAngles.x - y;
            var ey = m_OriginEulerAngles.y - x;

            ex = ex * 1.5f;
            ey = ey * 1.5f;
            
            m_TargetEulerAngles = new Vector3(ex,ey,m_OriginEulerAngles.z);
        }

        [SerializeField] private float m_Speed=0.1f;
        [SerializeField] private float m_Lerp=0.1f;
        private void Update()
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position,
                m_TargetPositon, m_Lerp);
            Camera.main.transform.rotation =
                Quaternion.Lerp(Camera.main.transform.rotation, Quaternion.Euler(m_TargetEulerAngles),m_Lerp);

        }
    }
}