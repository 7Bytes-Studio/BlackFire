/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

namespace BlackFire
{
    /// <summary>
    /// A callback to the sparrow ioc container when it is built.
    /// </summary>
    /// <param name="sparrowIoC">ISparrowIoC interface.</param>
    /// <returns>Type instance.</returns>
    public delegate object IoCBuildCallback(ISparrowIoC sparrowIoC); 

    public delegate T IoCBuildCallback<T>(ISparrowIoC sparrowIoC);
}