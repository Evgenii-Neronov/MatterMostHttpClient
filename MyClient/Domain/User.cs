using System.Runtime.Serialization;

namespace MyClient.Domain;

[DataContract]
public class User
{
    [DataMember(Name = "id")]
    public string Id { get; set; }

    [DataMember(Name = "create_at")]
    public long CreateAt { get; set; }

    [DataMember(Name = "update_at")]
    public long UpdateAt { get; set; }

    [DataMember(Name = "delete_at")]
    public long DeleteAt { get; set; }

    [DataMember(Name = "username")]
    public string Username { get; set; }

    [DataMember(Name = "auth_data")]
    public string AuthData { get; set; }

    [DataMember(Name = "auth_service")]
    public string AuthService { get; set; }

    [DataMember(Name = "email")]
    public string Email { get; set; }

    [DataMember(Name = "nickname")]
    public string Nickname { get; set; }

    [DataMember(Name = "first_name")]
    public string FirstName { get; set; }

    [DataMember(Name = "last_name")]
    public string LastName { get; set; }

    [DataMember(Name = "position")]
    public string Position { get; set; }

    [DataMember(Name = "roles")]
    public string Roles { get; set; }

    [DataMember(Name = "props")]
    public Props Props { get; set; }

    [DataMember(Name = "notify_props")]
    public NotifyProps NotifyProps { get; set; }

    [DataMember(Name = "last_password_update")]
    public long LastPasswordUpdate { get; set; }

    [DataMember(Name = "locale")]
    public string Locale { get; set; }

    [DataMember(Name = "timezone")]
    public Timezone Timezone { get; set; }

    [DataMember(Name = "disable_welcome_email")]
    public bool DisableWelcomeEmail { get; set; }
}

[DataContract]
public class Props
{
    [DataMember(Name = "last_search_pointer")]
    public string LastSearchPointer { get; set; }
}

[DataContract]
public class NotifyProps
{
    [DataMember(Name = "channel")]
    public string Channel { get; set; }

    [DataMember(Name = "comments")]
    public string Comments { get; set; }

    [DataMember(Name = "desktop")]
    public string Desktop { get; set; }

    [DataMember(Name = "desktop_sound")]
    public string DesktopSound { get; set; }

    [DataMember(Name = "desktop_threads")]
    public string DesktopThreads { get; set; }

    [DataMember(Name = "email")]
    public string Email { get; set; }

    [DataMember(Name = "email_threads")]
    public string EmailThreads { get; set; }

    [DataMember(Name = "first_name")]
    public string FirstName { get; set; }

    [DataMember(Name = "mention_keys")]
    public string MentionKeys { get; set; }

    [DataMember(Name = "push")]
    public string Push { get; set; }

    [DataMember(Name = "push_status")]
    public string PushStatus { get; set; }

    [DataMember(Name = "push_threads")]
    public string PushThreads { get; set; }
}

[DataContract]
public class Timezone
{
    [DataMember(Name = "automatic_timezone")]
    public string AutomaticTimezone { get; set; }

    [DataMember(Name = "manual_timezone")]
    public string ManualTimezone { get; set; }

    [DataMember(Name = "use_automatic_timezone")]
    public string UseAutomaticTimezone { get; set; }
}