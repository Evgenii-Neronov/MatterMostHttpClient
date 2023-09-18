using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClient.Domain;

public class MyUser
{
    public string id { get; set; }
    //public string create_at { get; set; }
    /*
    public string update_at { get; set; }
    public string delete_at { get; set; }
    public string username { get; set; }
    public string auth_data { get; set; }
    public string auth_service { get; set; }
    public string email { get; set; }
    public string nickname { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string position { get; set; }
    public string roles { get; set; }
    public Props props { get; set; }
    public Notify_Props notify_props { get; set; }
    public long last_password_update { get; set; }
    public string locale { get; set; }
    public Timezone timezone { get; set; }
    public bool disable_welcome_email { get; set; }
    */
}

public class Props
{
    public string last_search_pointer { get; set; }
}

public class Notify_Props
{
    public string channel { get; set; }
    public string comments { get; set; }
    public string desktop { get; set; }
    public string desktop_sound { get; set; }
    public string desktop_threads { get; set; }
    public string email { get; set; }
    public string email_threads { get; set; }
    public string first_name { get; set; }
    public string mention_keys { get; set; }
    public string push { get; set; }
    public string push_status { get; set; }
    public string push_threads { get; set; }
}

public class Timezone
{
    public string automaticTimezone { get; set; }
    public string manualTimezone { get; set; }
    public string useAutomaticTimezone { get; set; }
}
