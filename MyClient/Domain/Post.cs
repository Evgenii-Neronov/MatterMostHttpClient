namespace MyClient.Domain;

using System.Runtime.Serialization;

[DataContract]
public class Post
{

    [DataMember(Name = "id")]
    public string Id { get; set; }

    [DataMember(Name = "create_at")]
    public long CreateAt { get; set; }

    [DataMember(Name = "update_at")]
    public long UpdateAt { get; set; }

    [DataMember(Name = "edit_at")]
    public int EditAt { get; set; }

    [DataMember(Name = "delete_at")]
    public int DeleteAt { get; set; }

    [DataMember(Name = "is_pinned")]
    public bool IsPinned { get; set; }

    [DataMember(Name = "user_id")]
    public string UserId { get; set; }

    [DataMember(Name = "channel_id")]
    public string ChannelId { get; set; }

    [DataMember(Name = "root_id")]
    public string RootId { get; set; }

    [DataMember(Name = "original_id")]
    public string OriginalId { get; set; }

    [DataMember(Name = "message")]
    public string Message { get; set; }

    [DataMember(Name = "type")]
    public string Type { get; set; }

    [DataMember(Name = "hashtags")]
    public string Hashtags { get; set; }

    [DataMember(Name = "pending_post_id")]
    public string PendingPostId { get; set; }

    [DataMember(Name = "reply_count")]
    public int ReplyCount { get; set; }

    [DataMember(Name = "last_reply_at")]
    public int LastReplyAt { get; set; }

    [DataMember(Name = "participants")]
    public object Participants { get; set; }

}