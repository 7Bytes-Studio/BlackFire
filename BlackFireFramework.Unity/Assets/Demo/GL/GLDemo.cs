 //----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Alan
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
	public sealed class GLDemo : MonoBehaviour 
	{
        private MeshFilter m_MeshFilter = null;
        private MeshRenderer m_MeshRenderer = null;
        private Mesh m_Mesh = null;
        [SerializeField] private List<Vector3> m_Vertices;
        [SerializeField] private int[] m_Triangles;
        [SerializeField] private Vector2[] m_UV;


        private List<Vector3> m_Origin = new List<Vector3>();
        private List<Vector3> m_Update = new List<Vector3>();


        private void Awake()
        {
            m_Mesh = new Mesh();
            m_MeshFilter = GetComponent<MeshFilter>();
            m_MeshRenderer = GetComponent<MeshRenderer>();
            m_MeshFilter.mesh = m_Mesh;

            for (int i = 0; i < 1000; i+=10)
            {
                for (int j = 0; j < 1000; j+=10)
                {
                    m_Origin.Add(new Vector3(i,j,0));
                }
            }


        }

        private void Update()
        {
            
        }


    }
}
