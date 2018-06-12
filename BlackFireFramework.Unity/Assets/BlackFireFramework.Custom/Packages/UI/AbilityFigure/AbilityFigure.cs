using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lyz
{

    public class AbilityFigure : Graphic
    {
        [SerializeField] int dotCount = 0;
        [SerializeField] float R = 100;
        [SerializeField] List<DotProperty> dotProperties = new List<DotProperty>();
        protected void Update()
        {
            CalculateValuePos();
            SetVerticesDirty();
        }
        #region 外部方法
        public void AddDotFunc()
        {
            dotProperties.Add(new DotProperty());
            CalculateAllDotPos();
        }
        public void ChangeDotPropertyData(int index, DotPropertyData dotPropertyData)
        {
            if (index > dotProperties.Count) return;
            dotProperties[index].dotPropertyData = dotPropertyData;
        }
        public void ClearAll()
        {
            dotProperties.Clear();
        }
        #endregion
        #region 内部方法
        private void CalculateValuePos()
        {
            for (int i = 0; i < dotProperties.Count; i++)
            {
                dotProperties[i].valuePos = (Vector3.zero + dotProperties[i].peak) * dotProperties[i].dotPropertyData.Power;
            }
        }
        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
            if (dotProperties.Count < 3) return;
            vh.AddVert(Vector3.zero, color, new Vector2(0, 0));
            for (int i = 0; i < dotProperties.Count; i++)
            {
                vh.AddVert(dotProperties[i].valuePos, color, new Vector2(0f, 0f));
            }
            for (int i = 0; i < dotProperties.Count - 1; i++)
            {
                vh.AddTriangle(0, i + 1, i + 2);
            }
            vh.AddTriangle(0, 1, dotProperties.Count);
        }
        private void CalculateAllDotPos()
        {
            dotProperties[0].peak = new Vector3(R, 0, 0);
            float ang = Mathf.Deg2Rad * (360 / dotProperties.Count);

            for (int i = 0; i < dotProperties.Count; i++)
            {
                if (i == 0) continue;
                dotProperties[i].peak = new Vector3(R * Mathf.Cos(ang * i), R * Mathf.Sin(ang * i), 0);
            }
        }
        #endregion
    }



    [System.Serializable]
    public class DotPropertyData
    {
        public string name;
        [Range(0, 1)]
        [SerializeField] private float power;
        public float Power
        {
            get { return power; }
            set
            {
                if (value > 1)
                    power = 1;
                else
                {
                    power = value;
                }
            }
        }
    }
    [System.Serializable]
    public class DotProperty
    {
        [SerializeField] public Vector3 peak;
        [SerializeField] public Vector3 valuePos;
        public DotPropertyData dotPropertyData = new DotPropertyData();
    }
}