﻿using System.Runtime.InteropServices;

namespace DeepConsole.Native
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
