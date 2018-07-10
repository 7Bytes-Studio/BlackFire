//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------



using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class DebuggerResourceGUI : IDebuggerModuleGUI
    {
        public int Priority
        {
            get
            {
                return 5;
            }
        }

        public string ModuleName
        {
            get
            {
                return "Resource";
            }
        }



        public void OnInit(DebuggerManager debuggerManager)
        {
           
        }

        public void OnModuleGUI()
        {
            if (null==BlackFire.Resource) return;

            GUILayout.Box("Ref Count:".HexColor("green"),GUILayout.ExpandWidth(false));

            if(0<BlackFire.Resource.AssetAgencyCount)
                BlackFireGUI.BoxVerticalLayout(()=> {
                    BlackFireGUI.ScrollView("ResourceRefCountScrollView",id=> {

                        BlackFire.Resource.ForeachAssetAgency(current => {
                            var assetAgency = current.Value;
                            BlackFireGUI.HorizontalLayout(() => {
                                BlackFireGUI.DrawItem(
                                    string.Format("Path:{0}   ", assetAgency.AssetPath.HexColor("yellow") ),
                                    string.Format("RefCount:{4}   AcquireCount:{0}   RestoreCount:{1}   Type:{3}   HashCode:{2}", assetAgency.AcquireCount.HexColor("yellow"), assetAgency.RestoreCount.HexColor("yellow"), assetAgency.GetHashCode().ToString().HexColor("yellow"), assetAgency.AssetType.ToString().HexColor("yellow"), assetAgency.RefCount.ToString().HexColor("yellow")));
                            });
                        });

                    },GUILayout.ExpandHeight(false));

                });

        }

        public void OnDestroy()
        {
           
        }
    }
}
