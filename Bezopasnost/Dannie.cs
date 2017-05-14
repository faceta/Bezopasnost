using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bezopasnost
{
    static class Dannie
    {
        public static string Id { get; set; }
        public static string Value { get; set; }
        public static string Ud { get; set; }
        public static int Polzovatel { get; set; }
        public static string login { get; set; }
        public static int KodR { get; set; }

        //--------------------------------------------Для справочников---------------------------------------------
        public static int KodVid { get; set; }
        public static string VidRab { get; set; }

        public static int KodInst { get; set; }
        public static string Instr { get; set; }

        public static int KodTem { get; set; }
        public static string Tem { get; set; }

        public static int KodPodTem { get; set; }
        public static string PodTem { get; set; }

        public static int KodPunkt { get; set; }
        public static string Punkt { get; set; }
        public static string SoderzhP { get; set; }

        public static int KodPodPunkt { get; set; }
        public static string PodPunkt { get; set; }
        public static string SoderzhPP { get; set; }

        public static int KodPrilog { get; set; }
        public static string Prilog { get; set; }
        //-------------------------------------------------------------------------------------------------------------
        public static int KodEk { get; set; }
        public static string DataEk { get; set; }
        public static int Komiss { get; set; }
        //-------------------------------------------------------------------------------------------------------------
        public static int KodRabot { get; set; }
        public static int KodV { get; set; }
        public static string VopP { get; set; }
        public static int KodP2 { get; set; }

    }
}
