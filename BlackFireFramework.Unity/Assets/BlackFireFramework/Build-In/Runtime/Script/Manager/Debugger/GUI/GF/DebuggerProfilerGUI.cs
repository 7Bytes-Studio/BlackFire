//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

//From:https://github.com/EllanJiang

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;


namespace BlackFireFramework.Unity
{
    public sealed class DebuggerProfilerGUI : IDebuggerModuleGUI
    {
        private const int MBSize = 1024 * 1024;

        public int Priority
        {
            get
            {
                return 11;
            }
        }

        public string ModuleName
        {
            get
            {
                return "Profiler";
            }
        }


        public void OnInit(DebuggerManager debuggerManager)
        {
            
        }

        public void OnModuleGUI()
        {
            
            GUILayout.Label("<b>Profiler Information</b>");
            GUILayout.BeginVertical("box");
            {
                BlackFireGUI.DrawItem("Supported:", UnityEngine.Profiling.Profiler.supported.ToString());
                BlackFireGUI.DrawItem("Enabled:", UnityEngine.Profiling.Profiler.enabled.ToString());
                BlackFireGUI.DrawItem("Enable Binary Log:", UnityEngine.Profiling.Profiler.enableBinaryLog ? string.Format("True, {0}", UnityEngine.Profiling.Profiler.logFile) : "False");
#if UNITY_5_3 || UNITY_5_4
                    BlackFireGUI.DrawItem("Max Samples Number Per Frame:", Profiler.maxNumberOfSamplesPerFrame.ToString());
#endif
#if UNITY_5_6_OR_NEWER
                BlackFireGUI.DrawItem("Mono Used Size:", string.Format("{0} MB", (Profiler.GetMonoUsedSizeLong() / (float)MBSize).ToString("F3")));
                BlackFireGUI.DrawItem("Mono Heap Size:", string.Format("{0} MB", (Profiler.GetMonoHeapSizeLong() / (float)MBSize).ToString("F3")));
                BlackFireGUI.DrawItem("Used Heap Size:", string.Format("{0} MB", (Profiler.usedHeapSizeLong / (float)MBSize).ToString("F3")));
                BlackFireGUI.DrawItem("Total Allocated Memory:", string.Format("{0} MB", (Profiler.GetTotalAllocatedMemoryLong() / (float)MBSize).ToString("F3")));
                BlackFireGUI.DrawItem("Total Reserved Memory:", string.Format("{0} MB", (Profiler.GetTotalReservedMemoryLong() / (float)MBSize).ToString("F3")));
                BlackFireGUI.DrawItem("Total Unused Reserved Memory:", string.Format("{0} MB", (Profiler.GetTotalUnusedReservedMemoryLong() / (float)MBSize).ToString("F3")));
#else
                    BlackFireGUI.DrawItem("Mono Used Size:", string.Format("{0} MB", (Profiler.GetMonoUsedSize() / (float)MBSize).ToString("F3")));
                    BlackFireGUI.DrawItem("Mono Heap Size:", string.Format("{0} MB", (Profiler.GetMonoHeapSize() / (float)MBSize).ToString("F3")));
                    BlackFireGUI.DrawItem("Used Heap Size:", string.Format("{0} MB", (Profiler.usedHeapSize / (float)MBSize).ToString("F3")));
                    BlackFireGUI.DrawItem("Total Allocated Memory:", string.Format("{0} MB", (Profiler.GetTotalAllocatedMemory() / (float)MBSize).ToString("F3")));
                    BlackFireGUI.DrawItem("Total Reserved Memory:", string.Format("{0} MB", (Profiler.GetTotalReservedMemory() / (float)MBSize).ToString("F3")));
                    BlackFireGUI.DrawItem("Total Unused Reserved Memory:", string.Format("{0} MB", (Profiler.GetTotalUnusedReservedMemory() / (float)MBSize).ToString("F3")));
#endif
#if UNITY_5_5_OR_NEWER
                BlackFireGUI.DrawItem("Temp Allocator Size:", string.Format("{0} MB", (Profiler.GetTempAllocatorSize() / (float)MBSize).ToString("F3")));
#endif
            }
            GUILayout.EndVertical();
        }

        public void OnDestroy()
        {

        }
    }
}
