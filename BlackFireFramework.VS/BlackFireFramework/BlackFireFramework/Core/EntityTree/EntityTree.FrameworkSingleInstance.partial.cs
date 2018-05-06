//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


using System;

namespace BlackFireFramework
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
