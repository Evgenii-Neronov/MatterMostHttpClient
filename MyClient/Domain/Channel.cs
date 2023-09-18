using System.Runtime.Serialization;

namespace MyClient.Domain;

[DataContract]
public class Channel
{

    [DataMember(Name = "id")]
    public string Id { get; set; }

    [DataMember(Name = "create_at")]
    public long CreateAt { get; set; }

    [DataMember(Name = "update_at")]
    public long UpdateAt { get; set; }

    [DataMember(Name = "delete_at")]
    public int DeleteAt { get; set; }

    [DataMember(Name = "team_id")]
    public string TeamId { get; set; }

    [DataMember(Name = "type")]
    public string Type { get; set; }

    [DataMember(Name = "display_name")]
    public string DisplayName { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "header")]
    public string Header { get; set; }

    [DataMember(Name = "purpose")]
    public string Purpose { get; set; }

    [DataMember(Name = "last_post_at")]
    public long LastPostAt { get; set; }

    [DataMember(Name = "total_msg_count")]
    public int TotalMessageCount { get; set; }

    [DataMember(Name = "extra_update_at")]
    public int ExtraUpdateAt { get; set; }

    [DataMember(Name = "creator_id")]
    public string CreatorId { get; set; }

    [DataMember(Name = "scheme_id")]
    public object SchemeId { get; set; }

    [DataMember(Name = "props")]
    public object Props { get; set; }

    [DataMember(Name = "group_constrained")]
    public object GroupConstrained { get; set; }

    [DataMember(Name = "shared")]
    public bool? Shared { get; set; }

    [DataMember(Name = "total_msg_count_root")]
    public int TotalRootMessageCount { get; set; }

    [DataMember(Name = "policy_id")]
    public object PolicyId { get; set; }

    [DataMember(Name = "last_root_post_at")]
    public long LastRootPostAt { get; set; }

}
