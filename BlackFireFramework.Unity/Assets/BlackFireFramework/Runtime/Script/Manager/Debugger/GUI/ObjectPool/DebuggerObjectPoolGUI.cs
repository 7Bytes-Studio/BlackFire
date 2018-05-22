//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework 
{
    public sealed class DebuggerObjectPoolGUI : IDebuggerModuleGUI
    {

        private string m_InputPoolName = string.Empty;

        private int m_SpaceUnit = 2;

        public int Priority
        {
            get
            {
                return 3;
            }
        }

        public string ModuleName { get { return "ObjectPool"; }  }


        public void OnInit(DebuggerManager debuggerManager)
        {
        }

        public void OnModuleGUI()
        {
            BlackFireGUI.VerticalLayout(()=> {

                BlackFireGUI.HorizontalLayout(() => {

                    GUILayout.Box("Object Pool Operations :".HexColor("green"), GUILayout.ExpandWidth(false));

                });

                BlackFireGUI.BoxVerticalLayout(() => {

                    BlackFireGUI.BoxHorizontalLayout(() => {
                        GUILayout.Label("Pool Name : ",GUILayout.ExpandWidth(false));
                        m_InputPoolName = GUILayout.TextField(m_InputPoolName);
                        if (GUILayout.Button("Clear", GUILayout.ExpandWidth(false)))
                        {
                            m_InputPoolName = string.Empty;
                        }
                    }, GUILayout.ExpandHeight(false));

                    BlackFireGUI.BoxHorizontalLayout(() => {

                        GUILayout.Space(m_SpaceUnit);
                        if (GUILayout.Button("RecycleAll", GUILayout.ExpandWidth(false)))
                        {
                            var pool = ObjectPool.GetPool(m_InputPoolName);
                            if (null!=pool)
                            {
                                pool.RecycleAll();
                            }
                        }
                        GUILayout.Space(m_SpaceUnit);
                        if (GUILayout.Button("ReleaseIn", GUILayout.ExpandWidth(false)))
                        {
                            var pool = ObjectPool.GetPool(m_InputPoolName);
                            if (null != pool)
                            {
                                pool.ReleaseIn();
                            }
                        }
                        GUILayout.Space(m_SpaceUnit);
                        if (GUILayout.Button("ReleaseOut", GUILayout.ExpandWidth(false)))
                        {
                            var pool = ObjectPool.GetPool(m_InputPoolName);
                            if (null != pool)
                            {
                                pool.ReleaseOut();
                            }
                        }
                        GUILayout.Space(m_SpaceUnit);
                        if (GUILayout.Button("ReleaseAll", GUILayout.ExpandWidth(false)))
                        {
                            var pool = ObjectPool.GetPool(m_InputPoolName);
                            if (null != pool)
                            {
                                pool.ReleaseAll();
                            }
                        }
                        GUILayout.Space(m_SpaceUnit);
                        if (GUILayout.Button("DestroyPool", GUILayout.ExpandWidth(false)))
                        {
                            ObjectPool.DestroyPool(m_InputPoolName);
                        }
                        GUILayout.Space(m_SpaceUnit);




                    }, GUILayout.ExpandHeight(false));


                }, GUILayout.ExpandHeight(false));


                BlackFireGUI.HorizontalLayout(()=> {

                    GUILayout.Box("Object Pool Info :".HexColor("green"), GUILayout.ExpandWidth(false));

                });

                BlackFireGUI.BoxHorizontalLayout(() => {

                    BlackFireGUI.ScrollView(201,id=> {

                        var pools = ObjectPool.GetPools();
                        for (int i = 0; i < pools.Length; i++)
                        {
                            var bindTypeStr = "{  ";
                            var arr = pools[i].PoolFactoryBinder.GetBindingTypes();
                            for (int j = 0; j < arr.Length; j++)
                            {
                                if (arr.Length - 1 == j)
                                {
                                    bindTypeStr += arr[j].FullName;
                                }
                                else
                                {
                                    bindTypeStr += arr[j].FullName + " , ";
                                }
                            }
                            bindTypeStr += "  }";
                            GUILayout.Toggle(true,string.Format("Name : {0}  Capacity : {1}  Count : {2}  InCount : {3}  OutCount : {4}  ObjectTypes : {5}", pools[i].Name.HexColor("#33CCFF"), pools[i].Capacity.ToString().HexColor("#33CCFF"), pools[i].Count.ToString().HexColor("#33CCFF"), pools[i].InCount.ToString().HexColor("#33CCFF"), pools[i].OutCount.ToString().HexColor("#33CCFF"), bindTypeStr.HexColor("#33CCFF")));
                        }

                    });



                });


            });

        }

        public void OnDestroy()
        {

        }

    }
}
