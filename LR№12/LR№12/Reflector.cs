using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;
using System.IO;

namespace LR_12
{
    static class Reflector
    {
        public static void OutputInFile(string nameOfAssembly, string nameOfClass)
        {
            Type type;
            if (nameOfAssembly == null)
                type = Type.GetType(nameOfClass, false, true);
            else
            {
                Assembly asm = Assembly.LoadFrom(nameOfAssembly);
                type = asm.GetType(nameOfClass, false, true);
            }

            StreamWriter file = new StreamWriter(@"D:\3_semestr\OOTP\LR№12\File.txt");

            file.WriteLine($"\nName of class: {nameOfClass}");
            file.WriteLine($"\nClass contains: ");

            foreach (MemberInfo mi in type.GetMembers())
            {
                file.WriteLine(mi.DeclaringType + " " + mi.MemberType + " " + mi.Name);
            }

            file.Close();
        }

        public static void GetMethods(string nameOfAssembly, string nameOfClass)
        {
            Type type;
            if (nameOfAssembly == null)
                type = Type.GetType(nameOfClass, false, true);
            else
            {
                Assembly asm = Assembly.LoadFrom(nameOfAssembly);
                type = asm.GetType(nameOfClass, false, true);
            }
            if (!type.GetMethods().Any())
                Console.WriteLine("\nNo methods");
            else
            {
                Console.WriteLine("\nMethods:");
                foreach (MethodInfo method in type.GetMethods())
                {
                    string modificator = "";
                    if (method.IsStatic)
                        modificator += "static ";
                    if (method.IsVirtual)
                        modificator += "virtual ";
                    Console.Write(modificator + method.ReturnType.Name + " " + method.Name + " (");

                    ParameterInfo[] parameters = method.GetParameters();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                        if (i + 1 < parameters.Length)
                            Console.Write(", ");
                    }
                    Console.WriteLine(")");
                }
            }
        }

        public static void GetFieldsAndProperties(string nameOfAssembly, string nameOfClass)
        {
            Type type;
            if (nameOfAssembly == null)
                type = Type.GetType(nameOfClass, false, true);
            else
            {
                Assembly asm = Assembly.LoadFrom(nameOfAssembly);
                type = asm.GetType(nameOfClass, false, true);
            }

            if (!type.GetFields().Any())
                Console.WriteLine("\nNo public fields");
            else
            {
                Console.WriteLine("\nFields:");
                foreach (FieldInfo field in type.GetFields())
                {
                    Console.WriteLine($"{field.FieldType} {field.Name}");
                }
            }

            if (!type.GetProperties().Any())
                Console.WriteLine("\nNo properties");
            else
            {
                Console.WriteLine("\nProperties:");
                foreach (PropertyInfo prop in type.GetProperties())
                {
                    Console.WriteLine($"{prop.PropertyType} {prop.Name}");
                }
            }
        }

        public static void GetInterfaces(string nameOfAssembly, string nameOfClass)
        {
            Type type;
            if (nameOfAssembly == null)
                type = Type.GetType(nameOfClass, false, true);
            else
            {
                Assembly asm = Assembly.LoadFrom(nameOfAssembly);
                type = asm.GetType(nameOfClass, false, true);
            }

            if (!type.GetInterfaces().Any())
                Console.WriteLine("\nNo realized intefaces");
            else
            {
                Console.WriteLine("\nRealized interfaces:");
                foreach (Type i in type.GetInterfaces())
                {
                    Console.WriteLine(i.Name);
                }
            }
        }

        public static void GetMethodsWithParameter(string nameOfAssembly, string nameOfClass, Type parameter)
        {
            Type type;
            if (nameOfAssembly == null)
                type = Type.GetType(nameOfClass, false, true);
            else
            {
                Assembly asm = Assembly.LoadFrom(nameOfAssembly);
                type = asm.GetType(nameOfClass, false, true);
            }

            if (!type.GetMethods().Any())
                Console.WriteLine("\nNo methods");
            else
            {
                Console.WriteLine($"\nMethods which contain parameter with type: " + parameter);
                foreach (MethodInfo method in type.GetMethods())
                {
                    ParameterInfo[] parameters = method.GetParameters();
                    if (parameters.Any(p => p.ParameterType == parameter))
                    {
                        string modificator = "";
                        if (method.IsStatic)
                            modificator += "static ";
                        if (method.IsVirtual)
                            modificator += "virtual ";
                        Console.Write(modificator + method.ReturnType.Name + " " + method.Name + " (");

                        for (int i = 0; i < parameters.Length; i++)
                        {
                            Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                            if (i + 1 < parameters.Length)
                                Console.Write(", ");
                        }
                        Console.WriteLine(")");
                    }
                }
            }
        }

        static public void InvokeMethod(string nameOfAssembly, string nameOfClass, string nameOfMethod)
        {
            Type type;
            if (nameOfAssembly == null)
                type = Type.GetType(nameOfClass, false, true);
            else
            {
                Assembly asm = Assembly.LoadFrom(nameOfAssembly);
                type = asm.GetType(nameOfClass, false, true);
            }

            object obj = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethod(nameOfMethod);
            ParameterInfo[] param = method.GetParameters();

            StreamReader file = new StreamReader(@"D:\3_semestr\OOTP\LR№12\Parameters.txt");
            string[] separators = { " ", nameOfMethod };
            List<object> list = new List<object>();  
            while (!file.EndOfStream)
            {
                string str = file.ReadLine();
                string[] p = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (str.Contains(nameOfMethod))
                { 
                    for (int i = 0; i < p.Length; i++) 
                    {
                        list.Add(Convert.ChangeType(p[i], param[i].ParameterType));
                    }
                }
            }
            file.Close();
            object[] parameters = list.ToArray();
            method.Invoke(obj, parameters);
        }
    }
}
