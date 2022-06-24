
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApp_OpenIDConnect_DotNet.Models
{
    public class SociometrySession {
        private readonly int MinimumQuestionLenght = 6;
        private readonly int MinimumQuestionNumbers = 5;
        public List<Member> members = new List<Member>();
        private List<string> questions = new List<string>();

        public async Task ParseMembers(string path)
        {
            var at = File.ReadAllLinesAsync(path);
            var nicks = new HashSet<string>();
            var names = new HashSet<string>();
            var duplicates = new List<Member>();

            foreach (var line in await at){
                var m = Member.Parse(line);

                if (null == m.Name) continue;

                if ( names.Add(m.Name) && 
                     (null==m.Nick || names.Add(m.Nick)) )
                {
                    members.Add(m);
                }
                else 
                {
                    duplicates.Add(m);
                }
            }

            if (duplicates.Count > 0) {
                throw new Exception($"Error processing member list from file: {path}, number of duplicates: {duplicates.Count}");
            }
        }

        public async Task ParseQuestions(string path)
        {
            var at = File.ReadAllLinesAsync(path);

            foreach (var line in await at){
                var l = line.Trim();
                if (l.Length > MinimumQuestionLenght)
                {
                    questions.Add(l);
                }
            }

            if (questions.Count < MinimumQuestionNumbers) {
                throw new Exception($"Error processing question list from file: {path}, number of question should be more than or equal to {MinimumQuestionNumbers}");
            }
        }

    }
}
