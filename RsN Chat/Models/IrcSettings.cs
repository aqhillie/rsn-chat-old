using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RsN_Chat.Models
{
    // Immutable settings (don't want this being saved in JSON to settings files)
    public static class Env
    {
        public static string Version => Assembly.GetEntryAssembly().GetName().Version.ToString();
    }

    public static class IrcSettings
    {
        public static Dictionary<string, string> Aliases { get; private set; } = new Dictionary<string, string>();

        public static int CmdHistorySize { get; set; } = 10;

        // Set Variables
        public static class Set
        {
            public static bool allow_c1_chars { get; set; } = false; // Whether to filter out chars 128-159 or not
            public static bool autoload_scripts { get; set; } = true; // Whether to auto load scripts
            public static string autoload_dir { get; set; } = "Scripts"; // Directory to autoload scripts from
            private static string _banner = "*** ";
            public static string banner
            {
                get
                {
                    return _banner;
                }
                set
                {
                    _banner = value + " ";
                }
            } // The thing to display before system messages
            public static bool banner_expand { get; set; } = false; // Whether to run banner through the $-expander
            public static bool beep = false; // Whether to allow beeps or eat them (for future IRC use)
            public static string channel_name_width { get; set; } = "auto"; // How wide channel names should be on status bar in pixels or auto
            public static string client_information { get; set; } = "RsN CHaT v" + Env.Version;
            public static bool clock_24hour { get; set; } = false; // Self explanatory
            public static string clock_format { get; set; } = ""; // What Date format to use for clock
            public static string cmdchars { get; set; } = "/"; // What characters are used before a command (ie. /)
            public static bool dcc_auto_send_rejects { get; set; } = true; // for future IRC use
            public static bool dcc_dequote_filenames { get; set; } = true; // for future IRC use - De-urlify filenames offered; this permits filenames with spaces
            public static bool dcc_long_pathnames { get; set; } = true; // for future IRC use - Show the full path, or just the filename, in /dcc list
            public static int flood_after { get; set; } = 10; // How many linesto receive before checking flooding rate
            public static bool flood_ignore { get; set; } = false; // whether to /ignore people flooding you
            public static int flood_rate { get; set; } = 5; // how many lines per second constitutes a flood (numerator)
            public static int flood_rate_per { get; set; } = 0; // how many lines per second constitutes a flood (denominator)
            public static int flood_users { get; set; } = 1; // How many different flooders to check
            public static bool flood_warning { get; set; } = false; // Whether to output a message when getting flooded
            public static bool hide_private_channels { get; set; } = false; // Whether to hide channel name on the status bar
            public static bool indent { get; set; } = true; // whether to indent broken lines
            public static string input_prompt { get; set; } = ""; // What prompt to use in the input line
            public static bool insert_mode { get; set; } = true; // Whether to insert or overwrite the char under the cursor
            public static string load_path { get; set; } = ""; // Where to look for load files
            public static bool log { get; set; } = true; // Whether to write everything output to the global log file
            public static bool log_rewrite { get; set; } = false; // Rewrite stuff before its written to the global logfile
            public static string logfile { get; set; } = "irc.log"; // Name of the log file
            public static bool mirc_bnroken_dcc_resume { get; set; } = false; // For future IRC use - whether or not to use DCC resume
            public static bool no_ctcp_flood { get; set; } = true; // Whether the cliednt should ignore ctcps that come too fast
            public static bool no_fail_disconnect { get; set; } = false; // Whether the client should disconnect from server when writes fail
            public static bool notify { get; set; } = true; // Whether the clienbt should check occasionally for users on Twitch / IRC
            public static int notify_interval { get; set; } = 5; // How often the client should check for notify nicknames
            public static int notify_level { get; set; } = 1; // What the default window notify level should be
            public static bool notify_userhost_automatic { get; set; } = false; // Whether the notify system should ask for userhosts berore telling you a nick is online
            public static char pad_char { get; set; } = ' '; // What char should we use for the $[num]var expandos
            public static string quit_message { get; set; } = "Time wasted on Twitch: "; // What the default quit message should be
            public static string realname { get; set; } = ""; // Real name sent to server
            public static int scroll_lines { get; set; } = 1; // How many lines the display should scroll when new output occurs in a full window (???)
            public static int scrollback { get; set; } = 1000; // How big the default window scrollback size is
            public static bool show_channel_names { get; set; } = true; // Whether to show the channel roster when joining a channel
            public static bool show_numerics { get; set; } = false; // Whether to show the numeric code or banner when getting numeric replies
            public static bool show_status_all { get; set; } = true; // Whether some status expandos show only in current window status or all window status
            public static bool show_who_hopcount { get; set; } = false; // Whether to show the server hopcount in who replies (future IRC use)
        }

        public static string UserName { get; set; } = "UrbanRoseNation";
        public static string UserNick { get; set; } = "UrbanRoseNation";
        public static string UserColor { get; set; } = "Red";
    }
}
