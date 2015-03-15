/*
Copyright 2015 Nick Bushby

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterDictionaryExceptions
{
    /// <summary>
    /// Sample code for blog post at
    /// http://www.spurioussignals.com/blog/?p=23
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, string> baddies = new CheckedDictionary<string, string>();
            baddies.Add("Dalek", "https://en.wikipedia.org/wiki/Dalek");
            baddies.Add("Cyberman", "https://en.wikipedia.org/wiki/Cyberman");
            baddies.Add("Yeti", "https://en.wikipedia.org/wiki/Yeti_(Doctor_Who)");

            try
            {
                Console.WriteLine(baddies["The Master"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();
        }
    }
}
