//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;

namespace BlackFireFramework
{
    public sealed class BlackFireFormatter : Formatter
    {
        public override SerializationBinder Binder { get; set; }
        public override StreamingContext Context { get; set; }
        public override ISurrogateSelector SurrogateSelector { get; set; }

        public override object Deserialize(Stream serializationStream)
        {
            
            return null;
        }

        public override void Serialize(Stream serializationStream, object graph)
        {
           
        }

        protected override void WriteArray(object obj, string name, Type memberType)
        {
            Debug.LogFormat("{0} {1}", obj, name);
        }

        protected override void WriteBoolean(bool val, string name)
        {
            Debug.LogFormat("{0} {1}", val, name);
        }

        protected override void WriteByte(byte val, string name)
        {
            Debug.LogFormat("{0} {1}", val, name);
        }

        protected override void WriteChar(char val, string name)
        {
            Debug.LogFormat("{0} {1}", val, name);
        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            Debug.LogFormat("{0} {1}", val, name);
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            Debug.LogFormat("{0} {1}", val, name);
        }

        protected override void WriteDouble(double val, string name)
        {
            Debug.LogFormat("{0} {1}", val, name);
        }

        protected override void WriteInt16(short val, string name)
        {
            Debug.LogFormat("{0} {1}", val, name);

        }

        protected override void WriteInt32(int val, string name)
        {
            Debug.LogFormat("{0} {1}",val,name);
        }

        protected override void WriteInt64(long val, string name)
        {
            Debug.LogFormat("{0} {1}", val, name);
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            Debug.LogFormat("{0} {1}", obj, name);
        }

        protected override void WriteSByte(sbyte val, string name)
        {
            Debug.LogFormat("{0} {1}", val, name);
        }

        protected override void WriteSingle(float val, string name)
        {
            Debug.LogFormat("{0} {1}", val, name);
        }

        protected override void WriteTimeSpan(TimeSpan val, string name)
        {
            Debug.LogFormat("{0} {1}", val, name);
        }

        protected override void WriteUInt16(ushort val, string name)
        {
            Debug.LogFormat("{0} {1}", val, name);
        }

        protected override void WriteUInt32(uint val, string name)
        {
            Debug.LogFormat("{0} {1}", val, name);
        }

        protected override void WriteUInt64(ulong val, string name)
        {
            Debug.LogFormat("{0} {1}", val, name);

        }

        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            Debug.LogFormat("{0} {1}", obj, name);
        }
    }
}
