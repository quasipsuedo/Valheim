using System;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
namespace CustomMapDiscovery.Patches
{
    [HarmonyPatch(typeof(Minimap), "UpdateExplore")]
    public static class SetRadius
    {

        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> ILs = instructions.ToList();
            int count = 0;
            for (int i = 0; i < ILs.Count; ++i){

                if (ILs[i].opcode == OpCodes.Ldarg_0)
                {
                    ++count;
                    if (count == 7)
                    {
                        ILs[i].opcode = OpCodes.Nop;
                        ++i;
                        ILs[i].opcode = OpCodes.Nop;
                        ILs[i] = new CodeInstruction(OpCodes.Ldc_R4, 500f);
                        break;
                    }

                    
                }
                   
            }
                    



                


            return ILs.AsEnumerable();
        }
    }
}