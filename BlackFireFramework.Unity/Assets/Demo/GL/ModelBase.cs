//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;
using UnityEngine;


namespace Alan
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public abstract class ModelBase : MonoBehaviour 
	{

        private MeshFilter m_MeshFilter = null;
        private MeshRenderer m_MeshRenderer = null;
        private Mesh m_Mesh = null;
        //private List<Face> m_FaceList = new List<Face>();

        protected virtual void Awake()
        {
            m_Mesh = new Mesh();
            m_MeshFilter = GetComponent<MeshFilter>();
            m_MeshRenderer = GetComponent<MeshRenderer>();
            m_MeshFilter.mesh = m_Mesh;
        }

        protected virtual void Update()
        {
            OnPost();
        }

        protected virtual void OnPost()
        {

        }


    }


   
}
