//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;

namespace BlackFireFramework
{
    public static partial class Organize
    {
        public class Relationship
        {
            public long MemberId { get; internal set; }
            public long[] OwnerGroupIds { get; internal set; }

            private List<long> OwnerGroupIdList = new List<long>();

            internal void RecordGroup(long groupId)
            {
                if (!OwnerGroupIdList.Contains(groupId))
                {
                    OwnerGroupIdList.Add(groupId);
                }
            }

            internal bool RemoveGroup(long groupId)
            {
                if (OwnerGroupIdList.Contains(groupId))
                {
                    OwnerGroupIdList.Remove(groupId);
                    return true;
                }
                return false;
            }

            private static readonly Dictionary<long, Relationship> s_RelationshipDic = new Dictionary<long, Relationship>();



            internal static void RecordRelationship(long memberId,long groupId)
            {
                if (!s_RelationshipDic.ContainsKey(memberId))
                {
                    s_RelationshipDic.Add(memberId, new Relationship());
                }
                s_RelationshipDic[memberId].RecordGroup(groupId);
            }

            internal static Relationship QueryRelationship(long memberId)
            {
                if (s_RelationshipDic.ContainsKey(memberId))
                {
                    return s_RelationshipDic[memberId];
                }
                return null;
            }

            internal static bool RemoveRelationship(long memberId, long groupId)
            {
                if (s_RelationshipDic.ContainsKey(memberId))
                {
                   return s_RelationshipDic[memberId].RemoveGroup(groupId);
                }
                return false;
            }

        }
    }
}
