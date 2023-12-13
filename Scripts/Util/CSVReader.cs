using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

public class CSVReader
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char[] TRIM_CHARS = { '\"', '%', ',' };

    public static void Read(string fileName, ref string[] variables, ref string[] headers, ref List<List<string>> list)
    {
        TextAsset data = Resources.Load($"CSV/{fileName}") as TextAsset;

        var temp = Regex.Split(data.text, LINE_SPLIT_RE);
        var lines = temp.Take(temp.Length - 1).ToArray();//csv 파일 가장 마지막 줄(공백)까지 읽어들이는 바람에

        if (lines.Length <= 1)
            return;

        variables = Regex.Split(lines[0], SPLIT_RE).Where(num => !num.Equals("null")).ToArray();
        headers = Regex.Split(lines[2], SPLIT_RE).Where(num => !num.Equals("-")).ToArray();
        if (headers == null)
            return;

        for (int i = 0; i < variables.Length; i++)
        {
            if (variables[i].Equals("int"))
            {
                variables[i] = "Int32";
            }
            else if (variables[i].Equals("float"))
            {
                variables[i] = "Single";
            }
            else if (variables[i].Equals("string"))
            {
                variables[i] = "String";
            }
        }

        for (int i = 3; i < lines.Length; i++)
        {
            List<string> valueList = new List<string>(Regex.Split(lines[i], SPLIT_RE));
            valueList.RemoveAt(1);

            for (int j = 0; j < headers.Length; j++)
            {
                //https://stackoverflow.com/questions/11107536/convert-string-to-type-in-c-sharp
                valueList[j] = valueList[j].TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
            }
            list.Add(valueList);
        }

        return;
    }

    public static Dictionary<string, string> ReadString(string file)
    {
        Dictionary<string, string> list = new Dictionary<string, string>();
        TextAsset data = Resources.Load($"CSV/{file}") as TextAsset;

        var lines = Regex.Split(data.text, LINE_SPLIT_RE);

        if (lines.Length <= 1)
            return null;

        string[] header = Regex.Split(lines[2], SPLIT_RE);//세번째 줄

        if (header == null)
            return null;

        for (int i = 3; i < lines.Length; i++)
        {
            string[] values = Regex.Split(lines[i], SPLIT_RE);//데이터는 세번째 줄부터

            if (values == null)
                return null;

            string key = string.Empty;
            string pairValue = string.Empty;

            for (int j = 0; j < header.Length && j < values.Length; j++)
            {
                if (header[j] == "-" || values[j] == "") continue;

                values[j] = values[j].TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");

                if (header[j] == "index")
                {
                    key = values[j];
                }
                else
                {
                    pairValue = values[j].ToString();
                }
            }
            if (key == string.Empty) continue;
            list.Add(key, pairValue);
        }

        return list;
    }

    public static Dictionary<int, TileData> ReadMap(string file)
    {
        Dictionary<int, TileData> list = new Dictionary<int, TileData>();
        TextAsset data = Resources.Load($"CSV/{file}") as TextAsset;

        var lines = Regex.Split(data.text, LINE_SPLIT_RE);

        if (lines.Length <= 1)
            return null;

        string[] header = Regex.Split(lines[2], SPLIT_RE);//세번째 줄

        if (header == null)
            return null;

        for (int i = 3; i < lines.Length; i++)
        {
            string[] values = Regex.Split(lines[i], SPLIT_RE);//데이터는 세번째 줄부터

            if (values == null)
                return null;

            int key = 0;
            TileData tile = new TileData();
            for (int j = 0; j < header.Length && j < values.Length; j++)
            {
                if (header[j] == "-" || values[j] == "")
                    continue;

                values[j] = values[j].TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                string[] item = Regex.Split(values[j], ",");
                if (header[j] == "index")
                {
                    key = Convert.ToInt32(values[j]);
                }
                else if (j == header.Length - 1)//가장 마지막 칼럼이 타일 데이터
                {
                    int bar = values[j].Count(r => (r == '|'));//col행 row열
                    int plus = values[j].Count(r => (r == '+'));
                    int row = plus + 1;
                    int col = 0;

                    values[j] = values[j].Replace("+", "");
                    values[j] = values[j].Replace("|", "");
                    char[] temp = values[j].ToArray();

                    if (bar > 0 && row > 0)
                    {
                        col = temp.Length / row;
                    }
                    else if (bar == 0 && row > 0)
                    {
                        col = temp.Length;
                    }

                    tile.row = row;
                    tile.col = col;

                    tile.tileData = Array.ConvertAll(temp, new Converter<char, int>(c => Convert.ToInt32(c.ToString())));
                }
            }

            if (key == 0)
                continue;
            list.Add(key, tile);
        }

        return list;
    }
}