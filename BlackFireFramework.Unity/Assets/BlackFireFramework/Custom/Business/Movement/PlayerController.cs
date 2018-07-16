//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class PlayerController : MonoBehaviour 
	{
        [SerializeField] private float m_MoveSpeed = 30f;
        [SerializeField] private float m_RotaSpeed = 150f;

        public float MoveSpeed { get { return m_MoveSpeed;} set{ m_MoveSpeed = value; } }
        public float RotaSpeed { get { return m_RotaSpeed; } set { m_RotaSpeed = value; } }

        private void Update()
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * m_RotaSpeed;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * m_MoveSpeed;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        }

    }
}
