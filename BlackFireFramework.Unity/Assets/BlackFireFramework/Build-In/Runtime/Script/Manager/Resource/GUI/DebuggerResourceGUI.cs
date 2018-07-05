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
                    BlackFire.Resource.ForeachAssetAgency(current=> {
                        var assetAgency = current.Value;
                        BlackFireGUI.HorizontalLayout(() => {
                            GUILayout.Label(string.Format("Path:{0}   HashCode:{1}   Type:{2}   RefCount:{3}", assetAgency.AssetPath.HexColor("yellow"), assetAgency.GetHashCode().ToString().HexColor("yellow"), assetAgency.AssetType.ToString().HexColor("yellow"), assetAgency.RefCount.ToString().HexColor("yellow")));
                        });
                    });
                });

        }

        public void OnDestroy()
        {
           
        }
    }
}
