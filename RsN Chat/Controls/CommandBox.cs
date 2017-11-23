using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using RsN_Chat.Models;
using System.Windows;
using RsN_Chat.Classes;
using System.Diagnostics;

namespace RsN_Chat.Controls
{
    public class CommandBox : TextBox
    {

        private string _textBuffer = "";
        private int _historyPosition = 0;
        private List<string> History { get; set; }

        public Channel Channel
        {
            get { return (Channel)GetValue(ChannelProperty); }
            set { SetValue(ChannelProperty, value); }
        }

        public static readonly DependencyProperty ChannelProperty =
            DependencyProperty.RegisterAttached("Channel", typeof(Channel), typeof(CommandBox), new PropertyMetadata(null));

        public CommandBox()
        {
            History = new List<string>();
        }

        private void AddHistory(string text)
        {
            History.Add(text);
            if (History.Count > IrcSettings.CmdHistorySize)
            {
                History.RemoveAt(0);
            }
            _historyPosition = History.Count;
        }

        // Only supports moving either +1 or -1
        private string MoveHistoryByOne(int x)
        {
            x = (x > 0) ? 1 : -1;
            int newPos = _historyPosition + x;
            if (newPos < 0)
            {
                _historyPosition = History.Count - 1;
            }
            else if (newPos > History.Count - 1)
            {
                _historyPosition = 0;
            }
            else
            {
                _historyPosition += x;
            }

            Console.WriteLine(_historyPosition);
            return History[_historyPosition];
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            //Console.WriteLine(e.Key);
            switch(e.Key)
            {
                case Key.Up:
                    if (_historyPosition == 0)
                    {
                        Text = _textBuffer;
                        _historyPosition = History.Count;
                    } else
                    {
                        Text = MoveHistoryByOne(-1);
                    }
                    this.CaretIndex = Text.Length;
                    return;
                case Key.Down:
                    if (_historyPosition == History.Count -1)
                    {
                        Text = _textBuffer;
                        _historyPosition = -1;
                    }
                    else
                    {
                        Text = MoveHistoryByOne(1);
                    }
                    this.CaretIndex = Text.Length;
                    return;
                case Key.Return:
                    string cmd = Text;
                    AddHistory(Text);
                    Text = "";
                    _textBuffer = "";
                    ProcessUserCommand(cmd);
                    return;
            }

            base.OnPreviewKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            switch(e.Key)
            {
                case Key.Up:
                case Key.Down:
                case Key.Enter:
                    return;
            }

            _textBuffer = Text;
        }

        private void ProcessUserCommand(string cmd)
        {
            try
            {
                if (cmd[0].ToString() == IrcSettings.Set.cmdchars)
                {
                    string cmdString = cmd.Substring(1);
                    List<string> args = cmdString.Split(' ').ToList();
                    string command = args.First();
                    args.RemoveAt(0);
                    PerformCommand(command, args);
                }
                else
                {
                    Channel.AddChatLine(Channel.MyUser, "Public", cmd);
                }
            } catch(TypeInitializationException ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private void PerformCommand(string command, List<string> args)
        {
            if (command[0].ToString() == IrcSettings.Set.cmdchars)
            { // Check for double // command to skip alias processing
                command = command.Substring(1);
            }
            else
            { // Process aliases first and replace command and args appropriately
                foreach (var alias in IrcSettings.Aliases.ToArray())
                {
                    if (command.ToUpper() == alias.Key)
                    {
                        List<string> alias_args = alias.Value.Split(' ').ToList();
                        command = alias_args[0];
                        alias_args.RemoveAt(0);
                        if (alias_args.Count == 0)
                        {
                            alias_args.AddRange(args);
                            args = alias_args;
                        }
                        else
                        {
                            args = Expand.DollarArgs(alias_args, args);
                        }
                    }
                }
            }

            List<string> command_output = new List<string>();
            command_output = Commands.ProcessCommand(command, args);

            if (command_output.Count > 0)
            {
                Channel.EchoList(command_output);
            }

        }
    }
}
