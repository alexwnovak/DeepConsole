using System.Runtime.InteropServices;

namespace DeepConsole.Core.Interop
{
   [StructLayout( LayoutKind.Sequential )]
   public struct CONSOLE_SCREEN_BUFFER_INFO_EX
   {
      public int cbSize;
      public COORD dwSize;
      public COORD dwCursorPosition;
      public ushort wAttributes;
      public SMALL_RECT srWindow;
      public COORD dwMaximumWindowSize;
      public ushort wPopupAttributes;
      public bool bFullscreenSupported;

      [MarshalAs( UnmanagedType.ByValArray, SizeConst = 16 )]
      public COLORREF[] ColorTable;
   }
}
