using MedStudyBuddy.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedStudyBuddy
{
    public static class DataFileParser
    {
        public static IData GetData(string filepath)
        {
            var lines = ReadFile(filepath);

            // Safe exit
            if (lines == null)
                return null;

            List<string> format = ExtractFormat(lines);
            lines = NormalizeLineBreaks(lines);

            switch (GetType(lines[0]))
            {
                case DataType.TrueFalse:
                    var questions = GetQuestions(lines);

                    return new TrueFalse(questions);
                case DataType.Cards:
                    if (IsDoubleSided(lines[0]))
                    {
                        var cardsFront = GetCardsFront(lines);
                        var cardsBack = GetCardsBack(lines);

                        ApplyFormat(format, cardsFront, cardsBack);

                        return new Cards(cardsFront, cardsBack);
                    }
                    else
                    {
                        return new Cards(lines);
                    }

                default:
                    return null;
            }
        }

        // File Parsers

        private static List<string> ReadFile(string filepath)
        {
            try
            {
                return File.ReadLines(filepath).
                    Where(s => !string.IsNullOrEmpty(s) && !s.StartsWith("//")).
                    ToList<string>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data File Load Error!");
                return null;
            }
        }

        private static List<string> NormalizeLineBreaks(List<string> items)
        {
            return items.Select(s => s.Replace("\\n", "\n")).ToList();
        }

        // Format Parsers #
        private static bool HasFormat(string firstLine) { return firstLine.StartsWith("#"); }

        private static List<string> ExtractFormat(List<string> items)
        {
            List<string> format = null;

            if (HasFormat(items[0]))
            {
                format = items[0].Remove(0, 1).Trim().Split(',').Select(s => s.Trim()).ToList();
                items.RemoveAt(0);
            }

            return format;
        }

        private static void ApplyFormat(List<string> format, List<string> items1, List<string> items2)
        {
            if (format != null)
            {
                foreach (var f in format)
                {
                    var s = f.Trim().Replace("\\n", "\n");

                    if (s.StartsWith("Prefix_A"))
                    {
                        var prefix = s.Substring("Prefix_A =".Length);
                        items1 = ApplyFormatPrefix(items1, prefix);
                    }
                    else if (s.StartsWith("Prefix_B"))
                    {
                        var prefix = s.Substring("Prefix_B =".Length);
                        items2 = ApplyFormatPrefix(items2, prefix);
                    }
                }
            }
        }

        private static List<string> ApplyFormatPrefix(List<string> items, string prefix)
        {
            return items.Select(s => prefix + s).ToList();
        }

        // Data Parsers

        private static DataType GetType(string line)
        {
            if (line.Contains(" ===> "))
                return DataType.TrueFalse;

            return DataType.Cards;
        }

        private static bool IsDoubleSided(string line) { return line.Contains(" = "); }

        private static List<string> GetCardsFront(List<string> lines)
        {
            return lines.Select(s => s.Substring(0, s.IndexOf(" = "))).ToList();
        }

        private static List<string> GetCardsBack(List<string> lines)
        {
            return lines.Select(s => s.Substring(s.IndexOf(" = ") + 3)).ToList();
        }

        private static List<Question> GetQuestions(List<string> lines)
        {
            var questions = new List<Question>();

            for (int i = 0; i < lines.Count; i++)
            {
                try
                {
                    var number = int.Parse(lines[i].Substring(0, lines[i].IndexOf(" ")));
                    var question = lines[i].Substring(lines[i].IndexOf(" ") + 1, lines[i].IndexOf(" ===> ") - lines[i].IndexOf(" ") - 1);
                    var answerString = lines[i].Substring(lines[i].IndexOf(" ===> ") + 6);
                    var answer = false;
                    if (answerString == "FALSE")
                        answer = false;
                    else if (answerString == "TRUE")
                        answer = true;
                    else
                        throw new Exception("File doesn't have correct format for True-False type.");

                    questions.Add(new Question(number, question, answer));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error at line "+ (i+1) +"\n\n" + ex.Message);
                }

            }

            return questions;
        }
    }
}
