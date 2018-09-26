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
    /// 实体树。
    /// </summary>
    public partial class EntityTree : MultiwayTree<UserData>
    {
        public EntityTree(UserData userData)
        {
            Root = new EntityTreeNode(userData);
        }


        /// <summary>
        /// 诞生。
        /// </summary>
        internal void Born()
        {

            TraversaType = TraversaType.DepthFirst;
#if VS_EDITOR
            Log.Info("MagicTree Born");
#endif
            Traverse(node => {

                (node as EntityTreeNode).Born();

            });
        }

        /// <summary>
        /// 活动。
        /// </summary>
        internal void Act()
        {
#if VS_EDITOR
            Log.Info(string.Format("{0}   Second Layer Child's Count: {1}", "MagicTree Act", Root.ChildCount));
#endif
            Traverse(node => {

                (node as EntityTreeNode).Act();

            });
        }

        /// <summary>
        /// 灭亡。
        /// </summary>
        internal void Die()
        {
#if VS_EDITOR
            Log.Info("MagicTree Die");
#endif
            Traverse(node => {

                (node as EntityTreeNode).Die();

            });
        }

    }
}
