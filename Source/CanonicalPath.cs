﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//You are given an absolute path for a Unix-style file system, which always begins with a slash '/'. Your task is to transform this absolute path into its simplified canonical path.

//The rules of a Unix-style file system are as follows:

//A single period '.' represents the current directory.
//A double period '..' represents the previous/parent directory.
//Multiple consecutive slashes such as '//' and '///' are treated as a single slash '/'.
//Any sequence of periods that does not match the rules above should be treated as a valid directory or file name. For example, '...' and '....' are valid directory or file names.
//The simplified canonical path should follow these rules:

//The path must start with a single slash '/'.
//Directories within the path must be separated by exactly one slash '/'.
//The path must not end with a slash '/', unless it is the root directory.
//The path must not have any single or double periods ('.' and '..') used to denote current or parent directories.
//Return the simplified canonical path.
namespace Solutions
{
    public class CanonicalPath
    {
        public string SimplifyPath(string path)
        {

            Stack<string> stack = new Stack<string>();
            string[] pathArray = path.Split('/');

            foreach (string item in pathArray)
            {
                if (item == "..")
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if (item != "." && item != "")
                {
                    stack.Push(item);
                }
            }

            string[] resultArray = stack.ToArray();
            Array.Reverse(resultArray);
            return "/" + string.Join("/", resultArray);
        }
    }
}