//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

//From:https://github.com/EllanJiang

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace BlackFireFramework.Unity
{
    public sealed class DebuggerInfoGUI : IDebuggerModuleGUI
    {
        public int Priority
        {
            get
            {
                return 12;
            }
        }

        public string ModuleName
        {
            get
            {
                return "Info";
            }
        }


        public void OnInit(DebuggerManager debuggerManager)
        {
            
        }

        private string[] m_ToolbarItems = new string[] { "System","Environment","Screen","Graphic","Input","Scene","Path","Time","Quality","WebPlayer" };
        private int m_ToolbarSelectIndex = 0;
        public void OnModuleGUI()
        {
            BlackFireGUI.BoxVerticalLayout(() =>
            {
                BlackFireGUI.ScrollView("InfoToolbarScrollView", id =>
                {

                    BlackFireGUI.HorizontalLayout(() =>
                    {
                        m_ToolbarSelectIndex = GUILayout.Toolbar(m_ToolbarSelectIndex, m_ToolbarItems);
                    });

                },GUILayout.Height(45f));
            });

            this.Invoke(string.Format("Draw{0}Info", m_ToolbarItems[m_ToolbarSelectIndex]));
        }

        public void OnDestroy()
        {

        }


        #region System






        private string GetBatteryLevelString(float batteryLevel)
        {
            if (batteryLevel < 0f)
            {
                return "Unavailable";
            }

            return batteryLevel.ToString("P0");
        }
        private void DrawSystemInfo()
        {
            GUILayout.Label("<b>System Information</b>");
            GUILayout.BeginVertical("box");
            {
                BlackFireGUI.DrawItem("Device Unique ID:", SystemInfo.deviceUniqueIdentifier);
                BlackFireGUI.DrawItem("Device Name:", SystemInfo.deviceName);
                BlackFireGUI.DrawItem("Device Type:", SystemInfo.deviceType.ToString());
                BlackFireGUI.DrawItem("Device Model:", SystemInfo.deviceModel);
                BlackFireGUI.DrawItem("Processor Type:", SystemInfo.processorType);
                BlackFireGUI.DrawItem("Processor Count:", SystemInfo.processorCount.ToString());
                BlackFireGUI.DrawItem("Processor Frequency:", string.Format("{0} MHz", SystemInfo.processorFrequency.ToString()));
                BlackFireGUI.DrawItem("Memory Size:", string.Format("{0} MB", SystemInfo.systemMemorySize.ToString()));
#if UNITY_5_5_OR_NEWER
                BlackFireGUI.DrawItem("Operating System Family:", SystemInfo.operatingSystemFamily.ToString());
#endif
                BlackFireGUI.DrawItem("Operating System:", SystemInfo.operatingSystem);
#if UNITY_5_6_OR_NEWER
                BlackFireGUI.DrawItem("Battery Status:", SystemInfo.batteryStatus.ToString());
                BlackFireGUI.DrawItem("Battery Level:", GetBatteryLevelString(SystemInfo.batteryLevel));
#endif
#if UNITY_5_4_OR_NEWER
                BlackFireGUI.DrawItem("Supports Audio:", SystemInfo.supportsAudio.ToString());
#endif
                BlackFireGUI.DrawItem("Supports Location Service:", SystemInfo.supportsLocationService.ToString());
                BlackFireGUI.DrawItem("Supports Accelerometer:", SystemInfo.supportsAccelerometer.ToString());
                BlackFireGUI.DrawItem("Supports Gyroscope:", SystemInfo.supportsGyroscope.ToString());
                BlackFireGUI.DrawItem("Supports Vibration:", SystemInfo.supportsVibration.ToString());
                BlackFireGUI.DrawItem("Genuine:", Application.genuine.ToString());
                BlackFireGUI.DrawItem("Genuine Check Available:", Application.genuineCheckAvailable.ToString());
            }
            GUILayout.EndVertical();
        }



        #endregion

        #region Environment

        private void DrawEnvironmentInfo()
        {
            GUILayout.Label("<b>Environment Information</b>");
            GUILayout.BeginVertical("box");
            {
                BlackFireGUI.DrawItem("Product Name:", Application.productName);
                BlackFireGUI.DrawItem("Company Name:", Application.companyName);
#if UNITY_5_6_OR_NEWER
                BlackFireGUI.DrawItem("Game Identifier:", Application.identifier);
#else
                    BlackFireGUI.DrawItem("Game Identifier:", Application.bundleIdentifier);
#endif
                BlackFireGUI.DrawItem("Application Version:", Application.version);
                BlackFireGUI.DrawItem("Unity Version:", Application.unityVersion);
                BlackFireGUI.DrawItem("Platform:", Application.platform.ToString());
                BlackFireGUI.DrawItem("System Language:", Application.systemLanguage.ToString());
                BlackFireGUI.DrawItem("Cloud Project Id:", Application.cloudProjectId);
#if UNITY_5_6_OR_NEWER
                BlackFireGUI.DrawItem("Build Guid:", Application.buildGUID);
#endif
                BlackFireGUI.DrawItem("Target Frame Rate:", Application.targetFrameRate.ToString());
                BlackFireGUI.DrawItem("Internet Reachability:", Application.internetReachability.ToString());
                BlackFireGUI.DrawItem("Background Loading Priority:", Application.backgroundLoadingPriority.ToString());
                BlackFireGUI.DrawItem("Is Playing:", Application.isPlaying.ToString());
#if UNITY_5_3 || UNITY_5_4
                    BlackFireGUI.DrawItem("Is Showing Splash Screen:", Application.isShowingSplashScreen.ToString());
#endif
                BlackFireGUI.DrawItem("Run In Background:", Application.runInBackground.ToString());
#if UNITY_5_5_OR_NEWER
                BlackFireGUI.DrawItem("Install Name:", Application.installerName);
#endif
                BlackFireGUI.DrawItem("Install Mode:", Application.installMode.ToString());
                BlackFireGUI.DrawItem("Sandbox Type:", Application.sandboxType.ToString());
                BlackFireGUI.DrawItem("Is Mobile Platform:", Application.isMobilePlatform.ToString());
                BlackFireGUI.DrawItem("Is Console Platform:", Application.isConsolePlatform.ToString());
                BlackFireGUI.DrawItem("Is Editor:", Application.isEditor.ToString());
#if UNITY_5_6_OR_NEWER
                BlackFireGUI.DrawItem("Is Focused:", Application.isFocused.ToString());
#endif
#if UNITY_5_3
                    BlackFireGUI.DrawItem("Stack Trace Log Type:", Application.stackTraceLogType.ToString());
#endif
            }
            GUILayout.EndVertical();
        }

        #endregion

        #region Screen
        private string GetSleepTimeoutDescription(int sleepTimeout)
        {
            if (sleepTimeout == SleepTimeout.NeverSleep)
            {
                return "Never Sleep";
            }

            if (sleepTimeout == SleepTimeout.SystemSetting)
            {
                return "System Setting";
            }

            return sleepTimeout.ToString();
        }

        private string GetResolutionString(Resolution resolution)
        {
            return string.Format("{0} x {1} @ {2}Hz", resolution.width.ToString(), resolution.height.ToString(), resolution.refreshRate.ToString());
        }

        private string[] GetResolutionsStringArray(Resolution[] resolutions)
        {
            string[] resolutionStrings = new string[resolutions.Length];
            for (int i = 0; i < resolutions.Length; i++)
            {
                resolutionStrings[i] = GetResolutionString(resolutions[i]);
            }
            return resolutionStrings;
        }


        private void DrawScreenInfo()
        {
            GUILayout.Label("<b>Screen Information</b>");
            GUILayout.BeginVertical("box");
            {
                BlackFireGUI.DrawItem("Current Resolution", GetResolutionString(Screen.currentResolution));
                BlackFireGUI.DrawItem("Screen Width", string.Format("{0} px", Screen.width.ToString()));
                BlackFireGUI.DrawItem("Screen Height", string.Format("{0} px", Screen.height.ToString()));
                BlackFireGUI.DrawItem("Screen DPI", Screen.dpi.ToString("F2"));
                BlackFireGUI.DrawItem("Screen Orientation", Screen.orientation.ToString());
                BlackFireGUI.DrawItem("Is Full Screen", Screen.fullScreen.ToString());
                BlackFireGUI.DrawItem("Sleep Timeout", GetSleepTimeoutDescription(Screen.sleepTimeout));
                BlackFireGUI.DrawItem("Cursor Visible", Cursor.visible.ToString());
                BlackFireGUI.DrawItem("Cursor Lock State", Cursor.lockState.ToString());
                BlackFireGUI.DrawItem("Auto Landscape Left", Screen.autorotateToLandscapeLeft.ToString());
                BlackFireGUI.DrawItem("Auto Landscape Right", Screen.autorotateToLandscapeRight.ToString());
                BlackFireGUI.DrawItem("Auto Portrait", Screen.autorotateToPortrait.ToString());
                BlackFireGUI.DrawItem("Auto Portrait Upside Down", Screen.autorotateToPortraitUpsideDown.ToString());
                BlackFireGUI.DrawItem("Support Resolutions",string.Empty);
                GUILayout.SelectionGrid(0,GetResolutionsStringArray(Screen.resolutions), 3, new GUIStyle("Label"));
            }
            GUILayout.EndVertical();
        }
#endregion

        #region Graphic
        private string GetShaderLevelString(int shaderLevel)
        {
            return string.Format("Shader Model {0}.{1}", (shaderLevel / 10).ToString(), (shaderLevel % 10).ToString());
        }
        private void DrawGraphicInfo()
        {
            GUILayout.Label("<b>Graphics Information</b>");
            GUILayout.BeginVertical("box");
            {
                BlackFireGUI.DrawItem("Device ID:", SystemInfo.graphicsDeviceID.ToString());
                BlackFireGUI.DrawItem("Device Name:", SystemInfo.graphicsDeviceName);
                BlackFireGUI.DrawItem("Device Vendor ID:", SystemInfo.graphicsDeviceVendorID.ToString());
                BlackFireGUI.DrawItem("Device Vendor:", SystemInfo.graphicsDeviceVendor);
                BlackFireGUI.DrawItem("Device Type:", SystemInfo.graphicsDeviceType.ToString());
                BlackFireGUI.DrawItem("Device Version:", SystemInfo.graphicsDeviceVersion);
                BlackFireGUI.DrawItem("Memory Size:", string.Format("{0} MB", SystemInfo.graphicsMemorySize.ToString()));
                BlackFireGUI.DrawItem("Multi Threaded:", SystemInfo.graphicsMultiThreaded.ToString());
                BlackFireGUI.DrawItem("Shader Level:", GetShaderLevelString(SystemInfo.graphicsShaderLevel));
                BlackFireGUI.DrawItem("NPOT Support:", SystemInfo.npotSupport.ToString());
                BlackFireGUI.DrawItem("Max Texture Size:", SystemInfo.maxTextureSize.ToString());
#if UNITY_5_6_OR_NEWER
                BlackFireGUI.DrawItem("Max Cubemap Size:", SystemInfo.maxCubemapSize.ToString());
#endif
#if UNITY_5_4_OR_NEWER
                BlackFireGUI.DrawItem("Copy Texture Support:", SystemInfo.copyTextureSupport.ToString());
#endif
                BlackFireGUI.DrawItem("Supported Render Target Count:", SystemInfo.supportedRenderTargetCount.ToString());
#if UNITY_5_3 || UNITY_5_4
                    BlackFireGUI.DrawItem("Supports Stencil:", SystemInfo.supportsStencil.ToString());
                    BlackFireGUI.DrawItem("Supports Render Textures:", SystemInfo.supportsRenderTextures.ToString());
#endif
                BlackFireGUI.DrawItem("Supports Sparse Textures:", SystemInfo.supportsSparseTextures.ToString());
                BlackFireGUI.DrawItem("Supports 3D Textures:", SystemInfo.supports3DTextures.ToString());
#if UNITY_5_6_OR_NEWER
                BlackFireGUI.DrawItem("Supports 3D Render Textures:", SystemInfo.supports3DRenderTextures.ToString());
#endif
#if UNITY_5_4_OR_NEWER
                BlackFireGUI.DrawItem("Supports 2D Array Textures:", SystemInfo.supports2DArrayTextures.ToString());
#endif
                BlackFireGUI.DrawItem("Supports Shadows:", SystemInfo.supportsShadows.ToString());
                BlackFireGUI.DrawItem("Supports Raw Shadow Depth Sampling:", SystemInfo.supportsRawShadowDepthSampling.ToString());
                BlackFireGUI.DrawItem("Supports Render To Cubemap:", SystemInfo.supportsRenderToCubemap.ToString());
                BlackFireGUI.DrawItem("Supports Compute Shader:", SystemInfo.supportsComputeShaders.ToString());
                BlackFireGUI.DrawItem("Supports Instancing:", SystemInfo.supportsInstancing.ToString());
                BlackFireGUI.DrawItem("Supports Image Effects:", SystemInfo.supportsImageEffects.ToString());
#if UNITY_5_5_OR_NEWER
                BlackFireGUI.DrawItem("Supports Cubemap Array Textures:", SystemInfo.supportsCubemapArrayTextures.ToString());
#endif
#if UNITY_5_4_OR_NEWER
                BlackFireGUI.DrawItem("Supports Motion Vectors:", SystemInfo.supportsMotionVectors.ToString());
#endif
#if UNITY_5_6_OR_NEWER
                BlackFireGUI.DrawItem("Graphics UV Starts At Top:", SystemInfo.graphicsUVStartsAtTop.ToString());
#endif
#if UNITY_5_5_OR_NEWER
                BlackFireGUI.DrawItem("Uses Reversed ZBuffer:", SystemInfo.usesReversedZBuffer.ToString());
#endif
            }
            GUILayout.EndVertical();
        }

#endregion

        #region Input


        private void DrawInputInfo()
        {

        }
        #endregion

        #region Scene


        private void DrawSceneInfo()
        {
            GUILayout.Label("<b>Scene Information</b>");
            GUILayout.BeginVertical("box");
            {
                BlackFireGUI.DrawItem("Scene Count:", SceneManager.sceneCount.ToString());
                BlackFireGUI.DrawItem("Scene Count In Build Settings:", SceneManager.sceneCountInBuildSettings.ToString());

                Scene activeScene = SceneManager.GetActiveScene();
                BlackFireGUI.DrawItem("Active Scene Name:", activeScene.name);
                BlackFireGUI.DrawItem("Active Scene Path:", activeScene.path);
                BlackFireGUI.DrawItem("Active Scene Build Index:", activeScene.buildIndex.ToString());
                BlackFireGUI.DrawItem("Active Scene Is Dirty:", activeScene.isDirty.ToString());
                BlackFireGUI.DrawItem("Active Scene Is Loaded:", activeScene.isLoaded.ToString());
                BlackFireGUI.DrawItem("Active Scene Root Count:", activeScene.rootCount.ToString());
            }
            GUILayout.EndVertical();
        }

        #endregion

        #region Path
        private void DrawPathInfo()
        {
            GUILayout.Label("<b>Path Information</b>");

            GUILayout.BeginVertical("box");
            {
                BlackFireGUI.ScrollView("InfoToolbarScrollView", id =>
                {
                    BlackFireGUI.DrawItem("Data Path:", Application.dataPath.HexColor("#00CC99"));
                    BlackFireGUI.DrawItem("Persistent Data Path:", Application.persistentDataPath.HexColor("#00CC99"));
                    BlackFireGUI.DrawItem("Streaming Assets Path:", Application.streamingAssetsPath.HexColor("#00CC99"));
                    BlackFireGUI.DrawItem("Temporary Cache Path:", Application.temporaryCachePath.HexColor("#00CC99"));

                }, GUILayout.ExpandHeight(false));



            }
            GUILayout.EndVertical();
        }
        #endregion

        #region Time

        private string GetTimeScaleDescription(float timeScale)
        {
            if (timeScale <= 0f)
            {
                return "Pause";
            }

            if (timeScale < 1f)
            {
                return "Slower";
            }

            if (timeScale > 1f)
            {
                return "Faster";
            }

            return "Normal";
        }

        private void DrawTimeInfo()
        {
            GUILayout.Label("<b>Time Information</b>");
            GUILayout.BeginVertical("box");
            {
                BlackFireGUI.DrawItem("Time Scale", string.Format("{0} [{1}]", Time.timeScale.ToString(), GetTimeScaleDescription(Time.timeScale)));
                BlackFireGUI.DrawItem("Realtime Since Startup", Time.realtimeSinceStartup.ToString());
                BlackFireGUI.DrawItem("Time Since Level Load", Time.timeSinceLevelLoad.ToString());
                BlackFireGUI.DrawItem("Time", Time.time.ToString());
                BlackFireGUI.DrawItem("Fixed Time", Time.fixedTime.ToString());
                BlackFireGUI.DrawItem("Unscaled Time", Time.unscaledTime.ToString());
#if UNITY_5_6_OR_NEWER
                BlackFireGUI.DrawItem("Fixed Unscaled Time", Time.fixedUnscaledTime.ToString());
#endif
                BlackFireGUI.DrawItem("Delta Time", Time.deltaTime.ToString());
                BlackFireGUI.DrawItem("Fixed Delta Time", Time.fixedDeltaTime.ToString());
                BlackFireGUI.DrawItem("Unscaled Delta Time", Time.unscaledDeltaTime.ToString());
#if UNITY_5_6_OR_NEWER
                BlackFireGUI.DrawItem("Fixed Unscaled Delta Time", Time.fixedUnscaledDeltaTime.ToString());
#endif
                BlackFireGUI.DrawItem("Smooth Delta Time", Time.smoothDeltaTime.ToString());
                BlackFireGUI.DrawItem("Maximum Delta Time", Time.maximumDeltaTime.ToString());
#if UNITY_5_5_OR_NEWER
                BlackFireGUI.DrawItem("Maximum Particle Delta Time", Time.maximumParticleDeltaTime.ToString());
#endif
                BlackFireGUI.DrawItem("Frame Count", Time.frameCount.ToString());
                BlackFireGUI.DrawItem("Rendered Frame Count", Time.renderedFrameCount.ToString());
                BlackFireGUI.DrawItem("Capture Frame Rate", Time.captureFramerate.ToString());
#if UNITY_5_6_OR_NEWER
                BlackFireGUI.DrawItem("In Fixed Time Step", Time.inFixedTimeStep.ToString());
#endif
            }
            GUILayout.EndVertical();
        }
        #endregion

        #region Quality
        private void DrawQualityInfo()
        {
            GUILayout.Label("<b>Rendering Information</b>");
            GUILayout.BeginVertical("box");
            {
                BlackFireGUI.DrawItem("Active Color Space:", QualitySettings.activeColorSpace.ToString());
                BlackFireGUI.DrawItem("Desired Color Space:", QualitySettings.desiredColorSpace.ToString());
                BlackFireGUI.DrawItem("Max Queued Frames:", QualitySettings.maxQueuedFrames.ToString());
                BlackFireGUI.DrawItem("Pixel Light Count:", QualitySettings.pixelLightCount.ToString());
                BlackFireGUI.DrawItem("Master Texture Limit:", QualitySettings.masterTextureLimit.ToString());
                BlackFireGUI.DrawItem("Anisotropic Filtering:", QualitySettings.anisotropicFiltering.ToString());
                BlackFireGUI.DrawItem("Anti Aliasing:", QualitySettings.antiAliasing.ToString());
                BlackFireGUI.DrawItem("Realtime Reflection Probes:", QualitySettings.realtimeReflectionProbes.ToString());
                BlackFireGUI.DrawItem("Billboards Face Camera Position:", QualitySettings.billboardsFaceCameraPosition.ToString());
            }
            GUILayout.EndVertical();

            GUILayout.Label("<b>Shadows Information</b>");
            GUILayout.BeginVertical("box");
            {
#if UNITY_5_4_OR_NEWER
                BlackFireGUI.DrawItem("Shadow Resolution:", QualitySettings.shadowResolution.ToString());
#endif
#if UNITY_5_5_OR_NEWER
                BlackFireGUI.DrawItem("Shadow Quality:", QualitySettings.shadows.ToString());
#endif
                BlackFireGUI.DrawItem("Shadow Projection:", QualitySettings.shadowProjection.ToString());
                BlackFireGUI.DrawItem("Shadow Distance:", QualitySettings.shadowDistance.ToString());
                BlackFireGUI.DrawItem("Shadow Near Plane Offset:", QualitySettings.shadowNearPlaneOffset.ToString());
                BlackFireGUI.DrawItem("Shadow Cascades:", QualitySettings.shadowCascades.ToString());
                BlackFireGUI.DrawItem("Shadow Cascade 2 Split:", QualitySettings.shadowCascade2Split.ToString());
                BlackFireGUI.DrawItem("Shadow Cascade 4 Split:", QualitySettings.shadowCascade4Split.ToString());
            }
            GUILayout.EndVertical();

            GUILayout.Label("<b>Other Information</b>");
            GUILayout.BeginVertical("box");
            {
                BlackFireGUI.DrawItem("Blend Weights:", QualitySettings.blendWeights.ToString());
                BlackFireGUI.DrawItem("VSync Count:", QualitySettings.vSyncCount.ToString());
                BlackFireGUI.DrawItem("LOD Bias:", QualitySettings.lodBias.ToString());
                BlackFireGUI.DrawItem("Maximum LOD Level:", QualitySettings.maximumLODLevel.ToString());
                BlackFireGUI.DrawItem("Particle Raycast Budget:", QualitySettings.particleRaycastBudget.ToString());
                BlackFireGUI.DrawItem("Async Upload Time Slice:", string.Format("{0} ms", QualitySettings.asyncUploadTimeSlice.ToString()));
                BlackFireGUI.DrawItem("Async Upload Buffer Size:", string.Format("{0} MB", QualitySettings.asyncUploadBufferSize.ToString()));
#if UNITY_5_5_OR_NEWER
                BlackFireGUI.DrawItem("Soft Particles:", QualitySettings.softParticles.ToString());
#endif
                BlackFireGUI.DrawItem("Soft Vegetation:", QualitySettings.softVegetation.ToString());
            }
            GUILayout.EndVertical();
        }
        #endregion

        #region WebPlayer
        private void DrawWebPlayerInfo()
        {
            GUILayout.Label("<b>Web Player Information</b>");
            GUILayout.BeginVertical("box");
            {
#if !UNITY_2017_2_OR_NEWER
                    BlackFireGUI.DrawItem("Is Web Player:", Application.isWebPlayer.ToString());
#endif
                BlackFireGUI.DrawItem("Absolute URL:", Application.absoluteURL);
#if !UNITY_2017_2_OR_NEWER
                    BlackFireGUI.DrawItem("Source Value:", Application.srcValue);
#endif
                BlackFireGUI.DrawItem("Streamed Bytes:", Application.streamedBytes.ToString());
#if UNITY_5_3 || UNITY_5_4
                    BlackFireGUI.DrawItem("Web Security Enabled:", Application.webSecurityEnabled.ToString());
                    BlackFireGUI.DrawItem("Web Security Host URL:", Application.webSecurityHostUrl.ToString());
#endif
            }
            GUILayout.EndVertical();
        }
        #endregion
        
    }
}
