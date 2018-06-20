//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFireFramework.Unity
{
    public static partial class Utility
    {

        public static class Game
        {

            #region Fps

            private static float s_FpsMeasuringDelta = 1f;
            private static float s_TimePassed = 0.0f;
            private static int s_FrameCount = 0;
            private static float s_FPS = 0.0f;

            public static float Fps()
            {
                s_FrameCount = s_FrameCount + 1;
                s_TimePassed = s_TimePassed + Time.unscaledDeltaTime;

                if (s_TimePassed > s_FpsMeasuringDelta)
                {
                    s_FPS = s_FrameCount / s_TimePassed;

                    s_TimePassed = 0.0f;
                    s_FrameCount = 0;
                }
                return s_FPS;
            }

            #endregion

        }



    }
}
