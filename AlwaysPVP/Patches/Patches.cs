using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace AlwaysPVP.Patches
{
    [HarmonyPatch(typeof(Player), "IsPVPEnabled")]
    public static class IsPVPEnabled
    {
        private static FieldInfo field_Player_m_pvp = AccessTools.Field(typeof(Player), "m_pvp");


        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            int codepoint = -1;
            List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
            

                for (int i = 0; i < codes.Count; ++i)
                {
                            if (codes[i].LoadsField(field_Player_m_pvp))
                            {
                                codepoint = i;
                    codes[i].opcode = OpCodes.Ldc_I4_1;
                                break;
                            }

                }

            if (codepoint == -1)
                throw new System.Exception("No Stamina Sneak Transpiler injection point NOT found!!  Game has most likely updated and broken this mod!");

            return codes.AsEnumerable();
        }
    }
}
