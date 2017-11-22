using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RsN_Chat.Models
{
    // Immutable settings (don't want this being saved in JSON to settings files)
    public static class Env
    {
        public static string Version { get; private set; } = ((AssemblyVersionAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyVersionAttribute), false)).Version;
    }

    public static class IrcSettings
    {
        public static Dictionary<string, string> Aliases { get; set; }

        public static int CmdHistorySize { get; set; } = 10;

        // Set Variables
        public static class Set
        {
            public static bool allow_c1_chars { get; set; } = false; // Whether to filter out chars 128-159 or not
            public static string banner { get; set; } = "***"; // The thing to display before system messages
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

        }

        public static string UserName { get; set; } = "UrbanRoseNation";
        public static string UserNick { get; set; } = "UrbanRoseNation";
        public static string UserColor { get; set; } = "Red";
    }
}
