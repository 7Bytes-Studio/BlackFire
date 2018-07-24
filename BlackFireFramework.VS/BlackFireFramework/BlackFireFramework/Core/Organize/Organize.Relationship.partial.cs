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
            public string MemberName { get; internal set; }
            public string[] OwnerGroups { get; internal set; }

            private List<string> OwnerGroupList = new List<string>();

            internal void RecordGroup(string groupName)
            {
                if (!OwnerGroupList.Contains(groupName))
                {
                    OwnerGroupList.Add(groupName);
                }
            }

            internal bool RemoveGroup(string groupName)
            {
                if (OwnerGroupList.Contains(groupName))
                {
                    OwnerGroupList.Remove(groupName);
                    return true;
                }
                return false;
            }

            private static readonly Dictionary<string, Relationship> s_RelationshipDic = new Dictionary<string, Relationship>();



            internal static void RecordRelationship(string memberName,string groupName)
            {
                if (!s_RelationshipDic.ContainsKey(memberName))
                {
                    s_RelationshipDic.Add(memberName,new Relationship());
                }
                s_RelationshipDic[memberName].RecordGroup(groupName);
            }

            internal static Relationship QueryRelationship(string memberName)
            {
                if (s_RelationshipDic.ContainsKey(memberName))
                {
                    return s_RelationshipDic[memberName];
                }
                return null;
            }

            internal static bool RemoveRelationship(string memberName, string groupName)
            {
                if (s_RelationshipDic.ContainsKey(memberName))
                {
                   return s_RelationshipDic[memberName].RemoveGroup(groupName);
                }
                return false;
            }

        }
    }
}
