//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditorInternal;
using UnityEngine;

namespace Sparrow.Editor
{
    /// <summary>
    /// 日志重定向相关的实用函数。
    /// </summary>
    internal static class LogRedirection
    {
        private static readonly Regex s_LogRegex = new Regex(@" \(at (.+)\:(\d+)\)\r?\n");

        private const string StackTraceContainsString = "BlackFire:LogCallback";
        private const string TargetScriptsFileFullName = "BlackFire.cs";
        private const string CallbackScriptsFileFullName = "Log.cs";

        [OnOpenAsset(0)]
        private static bool OnOpenAsset(int instanceId, int line)
        {
            string selectedStackTrace = GetSelectedStackTrace();

            if (string.IsNullOrEmpty(selectedStackTrace))
            {
                return false;
            }

            if (!selectedStackTrace.Contains(StackTraceContainsString))
            {
                return false;
            }

            Match match = s_LogRegex.Match(selectedStackTrace);
            if (!match.Success)
            {
                return false;
            }

            if (!match.Groups[1].Value.Contains(TargetScriptsFileFullName))
            {
                return false;
            }

            // 跳过第一次匹配的堆栈
            match = match.NextMatch();
            if (!match.Success)
            {
                return false;
            }

            if (match.Groups[1].Value.Contains(CallbackScriptsFileFullName))
            {
                match = match.NextMatch();
                if (!match.Success)
                {
                    return false;
                }
            }
            InternalEditorUtility.OpenFileAtLineExternal(GetCombinePath(Application.dataPath, match.Groups[1].Value.Substring(7)), int.Parse(match.Groups[2].Value));
            return true;
        }

        private static string GetSelectedStackTrace()
        {
            Assembly editorWindowAssembly = typeof(EditorWindow).Assembly;
            if (editorWindowAssembly == null)
            {
                return null;
            }

            System.Type consoleWindowType = editorWindowAssembly.GetType("UnityEditor.ConsoleWindow");
            if (consoleWindowType == null)
            {
                return null;
            }

            FieldInfo consoleWindowFieldInfo = consoleWindowType.GetField("ms_ConsoleWindow", BindingFlags.Static | BindingFlags.NonPublic);
            if (consoleWindowFieldInfo == null)
            {
                return null;
            }

            EditorWindow consoleWindow = consoleWindowFieldInfo.GetValue(null) as EditorWindow;
            if (consoleWindow == null)
            {
                return null;
            }

            if (consoleWindow != EditorWindow.focusedWindow)
            {
                return null;
            }

            FieldInfo activeTextFieldInfo = consoleWindowType.GetField("m_ActiveText", BindingFlags.Instance | BindingFlags.NonPublic);
            if (activeTextFieldInfo == null)
            {
                return null;
            }

            return (string)activeTextFieldInfo.GetValue(consoleWindow);
        }


        private static string GetCombinePath(params string[] path)
        {
            if (path == null || path.Length < 1)
            {
                return null;
            }

            string combinePath = path[0];
            for (int i = 1; i < path.Length; i++)
            {
                combinePath = System.IO.Path.Combine(combinePath, path[i]);
            }

            return GetRegularPath(combinePath);
        }


        private static string GetRegularPath(string path)
        {
            if (path == null)
            {
                return null;
            }

            return path.Replace('\\', '/');
        }

    }
}
