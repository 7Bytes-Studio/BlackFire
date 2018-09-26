/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/


using System;

namespace BlackFire
{
    /// <summary>
    /// 实体树。
    /// </summary>
    public partial class EntityTree : MultiwayTree<UserData>
    {
        private static EntityTree s_FrameworkSingleInstance = null;

        private static EntityTree FrameworkSingleInstance { get { return s_FrameworkSingleInstance ?? (s_FrameworkSingleInstance = Framework.GlobalData["EntityTree"] as EntityTree); } }

        public static object GetEntityInChildren(Type targetType)
        {
            Type entityType = null;
            foreach (var entity in FrameworkSingleInstance)
            {
                //Log.Debug(string.Format("{0}  {1}", entity.GetType(), targetType));
                entityType = entity.GetType();
                if (entityType == targetType || targetType.IsAssignableFrom(entityType))
                {
                    return entity;
                }
            }
            return null;
        }

    }
}
