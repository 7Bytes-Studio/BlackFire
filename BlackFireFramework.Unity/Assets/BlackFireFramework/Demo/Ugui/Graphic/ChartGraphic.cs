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
	public class ChartGraphic : Graphic 
	{
        private RectTransform m_CachedRectTransform = null;
        public RectTransform CachedRectTransform { get { return m_CachedRectTransform ?? (m_CachedRectTransform = GetComponent<RectTransform>());   } }

        [SerializeField] private float m_Width = 5f;
        public float Width { get { return m_Width; } set { m_Width = value; } }

        [SerializeField] private float m_Y = 0f;
        public float Y { get { return m_Y; } set { m_Y = value;  } }

        [SerializeField] private float m_X = 0f;
        public float X { get { return m_X; } set { m_X = value; } }


        private Stack<Vector3> m_OriginPointQueue = new Stack<Vector3>();
        private LinkedList<Vector3> m_LinkedList = new LinkedList<Vector3>();


        protected override void Awake()
        {
            base.Awake();
            Init();
        }

        private void Init()
        {
            if (0==m_OriginPointQueue.Count)
            {
                m_OriginPointQueue.Push(Vector3.zero);
            }
        }



        private Vector3 PointHandler(Vector3 point)
        {
            var x = Mathf.Clamp(point.x, -Mathf.Abs(X), Mathf.Abs(X));
            var y = Mathf.Clamp(point.y, -Mathf.Abs(Y), Mathf.Abs(Y));

            //x = (CachedRectTransform.sizeDelta.x/2) * (x / X);
            //y = (CachedRectTransform.sizeDelta.y/2) * (y / Y);

            //Debug.Log(CachedRectTransform.sizeDelta.x+"  "+ CachedRectTransform.sizeDelta.y+"  "+ point +"   "+ CachedRectTransform.pivot);

            return new Vector3(x,y,point.z);
        }


        public void Push(Vector3 point)
        {
            point = PointHandler(point); 
            var quadPoints = Utility.GL.QuadrangleLine(m_OriginPointQueue.Peek(),point,Width);

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

            m_OriginPointQueue.Push(point);
        }

        public void Pop()
        {
            if (1< m_OriginPointQueue.Count)
                m_OriginPointQueue.Pop();

            if (4<=m_OriginPointQueue.Count)
            {
                for (int i = 0; i < 4; i++)
                {
                    m_LinkedList.RemoveLast();
                }
            }
        }


#if UNITY_EDITOR

        protected override void OnValidate()
        {
            Init();
            base.OnValidate();
        }

#endif

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

        [SerializeField] private float planH;
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
                yield return new WaitForSeconds(0.1f);
                //X += 10f;
                Push(new Vector3(time +=10f, planH, 0f));
            }
        }

    }
}
