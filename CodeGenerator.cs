using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LLVMSharp;
using LLVMSharp.Interop;

namespace EvaCompiler
{
    internal class CodeGenerator
    {
        public CodeGenerator()
        {
            ModuleInit();
        }

        public void exec(string program)
        {
            _module.PrintToFile(Path.Combine(Directory.GetCurrentDirectory(), "output3.ll"));
            Console.WriteLine(_module.PrintToString());
        }

        /**
         * Context
         *
         * Owns and manages the core "global" data of LLVM's core
         * infrastructure, including the type and constant unique tables.
         */
        private LLVMContextRef _context;

        /**
         * Module
         *
         * A Module instance is used to store all the information related to an
         * LLVM module. Modules are the top level container of all other LLVM
         * Intermediate Representation (IR) objects. Each module directly contains a
         * list of global variables, a list of functions, a list of libraries (or
         * other modules) this module depends on, a symbol table, and various data
         * about the target's characteristics.
         *
         * A module maintains a GlobalList object that is used to hold all
         * constant references to global variables in the module. When a global
         * variable is destroyed, it should have no entries in the GlobalList.
         */
        private LLVMModuleRef _module;

        /**
         * Builder
         *
         * Provides uniform API for creating instructions and inserting them
         * into a basic block: either at the end of a BasicBlock, or at a
         * specific iterator location in a block.
         */
        private LLVMBuilderRef _builder;

        private void ModuleInit()
        {
            _module = LLVMModuleRef.CreateWithName("EvaCompiler");
            _context = _module.Context;
            _builder = _context.CreateBuilder();
        }
    }
}
