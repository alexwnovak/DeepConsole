using System.Runtime.InteropServices;

namespace DeepConsole.Core.Interop
{
   [StructLayout( LayoutKind.Sequential )]
   public struct COORD
   {
      public short X;
      public short Y;
   }
}
