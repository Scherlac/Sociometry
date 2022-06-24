using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebApp_OpenIDConnect_DotNet.Models
{
    public class Member
    {
        public static Regex regexCSVSplit = new Regex(
            @"(?x:(
                (?<FULL>
                    (^|[,;\t\r\n])\s*
                        ( (?<QUODAT> (?<QUO>[""'])(?<DAT>([^,;\t\r\n]|(?<!\k<QUO>\s*)[,;\t\r\n])*)\k<QUO>) |
                        (?<QUODAT> (?<DAT> [^""',;\s\r\n]* )) )
                        (?=\s*([,;\t\r\n]|$)
                    )
                )
            ) )", 
            RegexOptions.Compiled);

        public Member(string name)
        {
            Name = name;
        }

        public Member(string name, string nick) : this(name)
        {
            Nick = nick;
        }

        public string Name { get; }
        public string Nick { get; }

        public static Member Parse(string line)
        {
            var data = regexCSVSplit.Matches(line).Cast<Match>().
              Select(x => x.Groups["DAT"].Value).ToArray();

            if ((data?.Length ?? 0) == 0) {
                return null;
            }

            var name = data.ElementAtOrDefault(0);
            var nick = data.ElementAtOrDefault(1);

            return new Member(name, nick);

        }
    }
}