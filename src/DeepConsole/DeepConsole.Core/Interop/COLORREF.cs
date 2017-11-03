using System.Runtime.InteropServices;

namespace DeepConsole.Core.Interop
{
   [StructLayout( LayoutKind.Sequential )]
   public struct COLORREF
   {
      public byte R;
      public byte G;
      public byte B;
      public byte A;
   }
}
