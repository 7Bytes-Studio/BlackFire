//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@gmail.com
//Website: http://www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework
{
    /// <summary>
    /// A callback to the sparrow ioc container when it is built.
    /// </summary>
    /// <param name="sparrowIoC">ISparrowIoC interface.</param>
    /// <returns>Type instance.</returns>
    public delegate object IoCBuildCallback(ISparrowIoC sparrowIoC); 

    public delegate T IoCBuildCallback<T>(ISparrowIoC sparrowIoC);
}