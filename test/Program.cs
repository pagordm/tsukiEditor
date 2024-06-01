using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using OdinSerializer;

namespace test
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TsukiSave save = SerializationUtility.DeserializeValue<TsukiSave>(File.ReadAllBytes("C:\\Users\\pablo\\Downloads\\save_new.csave"), DataFormat.Binary);

            Console.WriteLine(save.GetType().ToString());
            displayFields(save);
            foreach(NPCSave npc in save.npcSaves)
            {
                displayFields(npc);
            }
        }
        public static void displayFields(object o)
        {
            Type type = o.GetType();
            FieldInfo[] fields = type.GetFields();
            Console.WriteLine("Fields:");
            foreach (var field in fields)
            {
                //TODO mostrar todos los elementos de una lista
                Console.WriteLine($"{field.Name} ({field.FieldType.Name}) = {field.GetValue(o)}");
                if (field.FieldType.Name.Equals("Double") && field.Name.Contains("OA"))
                {
                    Console.WriteLine($"{field.Name} (DateTime) = {DateTime.FromOADate((double)field.GetValue(o))}");
                }
                /*if (field.FieldType.Name.Contains("List"))
                {
                    foreach (var f in (List<T e>) field.GetValue(o))
                    {
                        displayFields(f);
                    }
                }*/
            }
        }
    }
}
