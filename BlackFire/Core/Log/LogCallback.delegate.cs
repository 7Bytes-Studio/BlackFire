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
    /// 日志回调。
    /// </summary>
    /// <param name="logLevel">日志等级</param>
    /// <param name="message">日志信息。</param>
    public delegate void LogCallback(LogLevel logLevel,object message);
}
