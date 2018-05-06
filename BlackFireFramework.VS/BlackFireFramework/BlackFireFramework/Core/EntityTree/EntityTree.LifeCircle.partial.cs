//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


namespace BlackFireFramework
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
