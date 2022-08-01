﻿using System;
using System.Reflection;
using System.Reflection;
using System.Threading;
using System.Reflection.Emit;

namespace AssemblyMaking
{
    public class AssemblyMake
    {
        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public static void MakeAssembly(AssemblyName myAssemblyName, string fileName)
        {
            // Get the assembly builder from the application domain associated with the current thread.
            AssemblyBuilder myAssemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.RunAndSave);
            // Create a dynamic module in the assembly.
            ModuleBuilder myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("MyModule", fileName);
            // Create a type in the module.
            TypeBuilder myTypeBuilder = myModuleBuilder.DefineType("MyType");
            // Create a method called 'Main'.
            MethodBuilder myMethodBuilder = myTypeBuilder.DefineMethod("Main", MethodAttributes.Public | MethodAttributes.HideBySig |
               MethodAttributes.Static, typeof(void), null);
            // Get the Intermediate Language generator for the method.
            ILGenerator myILGenerator = myMethodBuilder.GetILGenerator();
            // Use the utility method to generate the IL instructions that print a string to the console.
            myILGenerator.EmitWriteLine("Hello World!");
            // Generate the 'ret' IL instruction.
            myILGenerator.Emit(OpCodes.Ret);
            // End the creation of the type.
            myTypeBuilder.CreateType();
            // Set the method with name 'Main' as the entry point in the assembly.
            myAssemblyBuilder.SetEntryPoint(myMethodBuilder);
            myAssemblyBuilder.Save(fileName);
        }

        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public static string AssemblyPrint()
        {
            string AssemblyVersion = "";

            // Get all the assemblies currently loaded in the application domain.
            Assembly[] myAssemblies = Thread.GetDomain().GetAssemblies();

            // Get the dynamic assembly named 'MyAssembly'.
            Assembly myAssembly = null;
            for (int i = 0; i < myAssemblies.Length; i++)
            {
                if (String.Compare(myAssemblies[i].GetName().Name, "MyAssembly") == 0)
                    myAssembly = myAssemblies[i];
            }
            if (myAssembly != null)
            {
                AssemblyVersion += myAssembly;
            }
            return AssemblyVersion;
        }


        public static string AssemblyVersion()
        {
            string v = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            return v;
        }

        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/
    }
}
