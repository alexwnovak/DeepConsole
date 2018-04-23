using System.Runtime.InteropServices;

namespace DeepConsole.Core.Interop
{
   [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Unicode )]
   public class CONSOLE_FONT_INFO_EX
   {
      private int cbSize;
      public CONSOLE_FONT_INFO_EX()
      {
         cbSize = Marshal.SizeOf( typeof( CONSOLE_FONT_INFO_EX ) );
      }
      public int FontIndex;
      public short FontWidth;
      public short FontHeight;
      public int FontFamily;
      public int FontWeight;
      [MarshalAs( UnmanagedType.ByValTStr, SizeConst = 32 )]
      public string FaceName;
   }
}
