namespace Print
{
    using System;

    internal enum DeviceCapabilities : ushort
    {
        BINADJUST = 0x13,
        BINNAMES = 12,
        BINS = 6,
        COLLATE = 0x16,
        COLORDEVICE = 0x20,
        COPIES = 0x12,
        DATATYPE_PRODUCED = 0x15,
        DRIVER = 11,
        DUPLEX = 7,
        EMF_COMPLIANT = 20,
        ENUMRESOLUTIONS = 13,
        EXTRA = 9,
        FIELDS = 1,
        FILEDEPENDENCIES = 14,
        MANUFACTURER = 0x17,
        MAXEXTENT = 5,
        MEDIAREADY = 0x1d,
        MEDIATYPENAMES = 0x22,
        MEDIATYPES = 0x23,
        MINEXTENT = 4,
        MODEL = 0x18,
        NUP = 0x21,
        ORIENTATION = 0x11,
        PAPERNAMES = 0x10,
        PAPERS = 2,
        PAPERSIZE = 3,
        PERSONALITY = 0x19,
        PRINTERMEM = 0x1c,
        PRINTRATE = 0x1a,
        PRINTRATEPPM = 0x1f,
        PRINTRATEUNIT = 0x1b,
        SIZE = 8,
        STAPLE = 30,
        TRUETYPE = 15,
        VERSION = 10
    }
}

