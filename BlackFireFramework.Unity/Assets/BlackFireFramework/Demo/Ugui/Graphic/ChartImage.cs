//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework.Unity 
{
	public class ChartImage : Graphic 
	{
        private RectTransform m_CachedRectTransform = null;
        public RectTransform CachedRectTransform { get { return m_CachedRectTransform ?? (m_CachedRectTransform = GetComponent<RectTransform>());   } }

        [SerializeField] private float m_Width = 5f;
        public float Width { get { return m_Width; } set { m_Width = value; } }

        private float m_Y = 0f;
        public float Y { get { return m_Y; } set { m_Y = value;  } }

        private float m_X = 0f;
        public float X { get { return m_X; } set { m_X = value; } }


        public Stack<Vector3> m_PointQueue = new Stack<Vector3>();
        public LinkedList<Vector3> m_LinkedList = new LinkedList<Vector3>();



        protected override void Awake()
        {
            base.Awake();
            Init();
        }

        private void Init()
        {
            if (0==m_PointQueue.Count)
            {
                m_PointQueue.Push(Vector3.zero);
            }
        }

        public void Push(Vector3 point)
        {
            var quadPoints = Utility.GL.QuadrangleLine(m_PointQueue.Peek(),point,Width);

            if (4 <= m_LinkedList.Count)
            {
                m_LinkedList.AddLast(quadPoints[0]);
                m_LinkedList.AddLast(quadPoints[1]);
                for (int i = 0; i < quadPoints.Length; i++)
                {
                    m_LinkedList.AddLast(quadPoints[i]);
                }
                m_LinkedList.AddLast(quadPoints[2]);
                m_LinkedList.AddLast(quadPoints[3]);
            }
            else
            {
                for (int i = 0; i < quadPoints.Length; i++)
                {
                    m_LinkedList.AddLast(quadPoints[i]);
                }
                m_LinkedList.AddLast(quadPoints[2]);
                m_LinkedList.AddLast(quadPoints[3]);
            }

            m_PointQueue.Push(point);
        }

        public void Pop()
        {
            if (1< m_PointQueue.Count)
                m_PointQueue.Pop();

            if (4<=m_PointQueue.Count)
            {
                for (int i = 0; i < 4; i++)
                {
                    m_LinkedList.RemoveLast();
                }
            }
        }




        protected override void OnValidate()
        {
            Init();
            base.OnValidate();
        }

        protected void Update()
        {
            SetVerticesDirty();
        }


        protected override void OnPopulateMesh(VertexHelper toFill)
        {
            Color32 color = this.color;
            toFill.Clear();

            var current = m_LinkedList.First;
            int i = 0;
            while (null!= current)
            {
                if (i == m_LinkedList.Count - 2) break;

                //Vertex&&UV
                if (0 == i % 2) //四边形顶部顶点
                {
                    toFill.AddVert(current.Value, color,new Vector2((i/2)/(m_LinkedList.Count/2),1f));
                }
                else //四边形底部顶点。
                {
                    toFill.AddVert(current.Value, color, new Vector2(((i-1)/2)/(m_LinkedList.Count/2),0f));
                }

                //Triangle
                if (0==i%4) //构建四边形
                {
                    toFill.AddTriangle(i+1, i,  i+2);
                    toFill.AddTriangle(i+1, i+2,i+3);
                }
                current = current.Next; i++;
            }
        }

        private float time=0f;
        private void OnGUI()
        {
            if (GUILayout.Button("测试"))
            {
                //Push(new Vector3(time+=10, Random.Range(-300f, 300f), 0f));
                //Push(new Vector3(100f,100f,0f));
                //Push(new Vector3(150f,200f,0f));
                StartCoroutine(Test());
            }
        }

        private IEnumerator Test()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.2f);
                Push(new Vector3(time += 10, Random.Range(-150f,150f), 0f));
            }
        }

    }
}
