using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TriviaGame
{
    class Answers
    {


        public Dictionary<String, String> map;
        public Dictionary<String, String> hap;
        public Dictionary<String, String> sap;

        public List<List<string>> answers = new List<List<string>>();
        


        //public List<List<string>> answersS = new List<List<string>>();
        //public List<List<string>> answersH = new List<List<string>>();




            // Populate the Dictionaries from the text files
        public void TextFileToDictionary()
        {
            map = new Dictionary<string, string>();
            hap = new Dictionary<string, string>();
            sap = new Dictionary<string, string>();

            using StreamReader cs = new StreamReader("QuestionsComputer.txt");
            using StreamReader hs = new StreamReader("QuestionsHistory.txt");
            using StreamReader ss = new StreamReader("QuestionsScience.txt");
            string line;


            // while it reads the file line
            while ((line = cs.ReadLine())!= null)
            {
                string[] mapValue = line.Split("*");
                // add the key and values to dictionary
                // can read next line as the key and value
               map.Add(mapValue[0], mapValue[1]);
                answers.Add( new List<string> { mapValue[1], mapValue[2], mapValue[3], mapValue[4] });
            }

            while ((line = hs.ReadLine()) != null)
            {
                string[] hapValue = line.Split("*");
                // add the key and values to dictionary 
                // can read next line as the key and value
                hap.Add(hapValue[0], hapValue[1]);
                answers.Add(new List<string> { hapValue[1], hapValue[2], hapValue[3], hapValue[4] });
            }

            while ((line = ss.ReadLine()) != null)
            {
                string[] sapValue = line.Split("*");
                // add the key and values to dictionary
                // can read next line as the key and value
                sap.Add(sapValue[0], sapValue[1]);
                answers.Add(new List<string> { sapValue[1], sapValue[2], sapValue[3], sapValue[4] });   
            }

            return;
        }
    }
}