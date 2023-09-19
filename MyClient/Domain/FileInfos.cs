using System.Runtime.Serialization;

namespace MyClient.Domain;

[DataContract]
public class FileInfos
{
    [DataMember(Name = "file_infos")]
    public FileInfo[] FIs { get; set; }

    [DataMember(Name = "client_ids")]
    public object[] ClientIds { get; set; }
}

[DataContract]
public class FileInfo
{

    [DataMember(Name = "id")]
    public string Id { get; set; }

    [DataMember(Name = "user_id")]
    public string UserId { get; set; }

    [DataMember(Name = "channel_id")]
    public string ChannelId { get; set; }

    [DataMember(Name = "create_at")]
    public long CreateAt { get; set; }

    [DataMember(Name = "update_at")]
    public long UpdateAt { get; set; }

    [DataMember(Name = "delete_at")]
    public int DeleteAt { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "extension")]
    public string Extension { get; set; }

    [DataMember(Name = "size")]
    public int Size { get; set; }

    [DataMember(Name = "mime_type")]
    public string MimeType { get; set; }

    [DataMember(Name = "mini_preview")]
    public object MiniPreview { get; set; }

    [DataMember(Name = "remote_id")]
    public string RemoteId { get; set; }

    [DataMember(Name = "archived")]
    public bool Archived { get; set; }

}