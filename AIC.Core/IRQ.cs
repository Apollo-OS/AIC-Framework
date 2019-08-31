/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2017, Siaranite Solutions
Copyright (c) 2017, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
//Some code was used in GruntTheDivine's infinity kernel. He gave permission for it to be made public.
namespace AIC.Core
{
    public class IRQ
    {
        public static void SetMask(byte IRQline)
        {
            ushort port;
            byte value;

            if (IRQline < 8)
            {
                port = 0x20 + 1;
            }
            else
            {
                port = 0xA0 + 1;
                IRQline -= 8;
            }
            value = (byte)(IO.PortIO.inb(port) | (1 << IRQline));
            IO.PortIO.outb(port, value);
        }
        public static void ClearMask(byte IRQline)
        {
            ushort port;
            byte value;

            if (IRQline < 8)
            {
                port = 0x20 + 1;
            }
            else
            {
                port = 0xA0 + 1;
                IRQline -= 8;
            }
            value = (byte)(IO.PortIO.inb(port) & ~(1 << IRQline));
            IO.PortIO.outb(port, value);
        }
    }
}
