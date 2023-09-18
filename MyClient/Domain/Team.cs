namespace MyClient.Domain;

using System.Runtime.Serialization;

[DataContract]
public class Team
{

    [DataMember(Name = "id")]
    public string Id { get; set; }

    [DataMember(Name = "create_at")]
    public long CreateAt { get; set; }

    [DataMember(Name = "update_at")]
    public long UpdateAt { get; set; }

    [DataMember(Name = "delete_at")]
    public int DeleteAt { get; set; }

    [DataMember(Name = "display_name")]
    public string DisplayName { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "description")]
    public string Description { get; set; }

    [DataMember(Name = "email")]
    public string Email { get; set; }

    [DataMember(Name = "type")]
    public string Type { get; set; }

    [DataMember(Name = "company_name")]
    public string CompanyName { get; set; }

    [DataMember(Name = "allowed_domains")]
    public string AllowedDomains { get; set; }

    [DataMember(Name = "invite_id")]
    public string InviteId { get; set; }

    [DataMember(Name = "allow_open_invite")]
    public bool AllowOpenInvite { get; set; }

    [DataMember(Name = "scheme_id")]
    public object SchemeId { get; set; }

    [DataMember(Name = "group_constrained")]
    public object GroupConstrained { get; set; }

    [DataMember(Name = "policy_id")]
    public object PolicyId { get; set; }

    [DataMember(Name = "cloud_limits_archived")]
    public bool CloudLimitsArchived { get; set; }

}