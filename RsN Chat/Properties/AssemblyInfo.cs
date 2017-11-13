using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("RsN Chat")]
[assembly: AssemblyDescription
    (
		"▄▄▄  .▄▄ ·  ▐ ▄      ▄▄·  ▄ .▄ ▄▄▄· ▄▄▄▄▄\r\n" +
        "▀▄ █·▐█ ▀. •█▌▐█    ▐█ ▌▪██▪▐█▐█ ▀█ •██\r\n" +
        "▐▀▀▄ ▄▀▀▀█▄▐█▐▐▌    ██ ▄▄██▀▐█▄█▀▀█  ▐█.▪\r\n" +
        "▐█•█▌▐█▄▪▐███▐█▌    ▐███▌██▌▐▀▐█ ▪▐▌ ▐█▌·\r\n" +
        ".▀  ▀ ▀▀▀▀ ▀▀ █▪    ·▀▀▀ ▀▀▀ · ▀  ▀  ▀▀▀\r\n" +
        "\r\n" +
        "This app is highly inspired by the ircII EPIC IRC client which is the only " +
        "IRC client I would ever use, along with the LiCe script by SrfRoG. This " +
        "client aims to be a quality substitute for ircII EPIC and LiCe.\r\n" +
        "\r\n" +
        "Initially this is going to be a Twitch client and once that functionality " +
        "is completed then I will make it work with regular IRC as well. That " +
        "should be quite simple in comparison.\r\n" +
        "\r\n" +
        "I aim to have full functionality and have as many of the web Twitch " +
        "chat features as possible, including moderation, deleted messages, " +
        "emotes, cheers, raids and anything else they add in the future.\r\n" +
        "\r\n" +
        "Special thanks to the LiCe/IRC crew: SrfRoG, tjh, whitefang, etc.\r\n" +
        "\r\n" +
        "More to come later...\r\n"
    )
]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("RsN Chat")]
[assembly: AssemblyCopyright("Copyright © Urban Alexander 2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

//In order to begin building localizable applications, set 
//<UICulture>CultureYouAreCodingWith</UICulture> in your .csproj file
//inside a <PropertyGroup>.  For example, if you are using US english
//in your source files, set the <UICulture> to en-US.  Then uncomment
//the NeutralResourceLanguage attribute below.  Update the "en-US" in
//the line below to match the UICulture setting in the project file.

//[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]


[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
                                     //(used if a resource is not found in the page, 
                                     // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
                                              //(used if a resource is not found in the page, 
                                              // app, or any theme specific resource dictionaries)
)]


// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("0.1.*")]
[assembly: AssemblyFileVersion("0.1.*")]
