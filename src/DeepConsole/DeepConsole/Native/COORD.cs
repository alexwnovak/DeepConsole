using System.Runtime.InteropServices;

namespace DeepConsole.Native
{
   [StructLayout( LayoutKind.Sequential )]
   public struct COORD
   {
      public short X;
      public short Y;
   }
}
