namespace TopluMail
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Threading;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [Serializable, DesignerCategory("code"), XmlSchemaProvider("GetTypedDataSetSchema"), XmlRoot("Ds"), HelpKeyword("vs.data.DataSet"), ToolboxItem(true)]
    public class Ds : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private EktekilerDataTable tableEktekiler;
        private MaillerDataTable tableMailler;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public Ds()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            base.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler schemaChangedHandler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            base.EndInit();
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        protected Ds(SerializationInfo info, StreamingContext context) : base(info, context, false)
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            if (base.IsBinarySerialized(info, context))
            {
                this.InitVars(false);
                CollectionChangeEventHandler schemaChangedHandler1 = new CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += schemaChangedHandler1;
                this.Relations.CollectionChanged += schemaChangedHandler1;
            }
            else
            {
                string strSchema = (string) info.GetValue("XmlSchema", typeof(string));
                if (base.DetermineSchemaSerializationMode(info, context) == System.Data.SchemaSerializationMode.IncludeSchema)
                {
                    DataSet ds = new DataSet();
                    ds.ReadXmlSchema(new XmlTextReader(new StringReader(strSchema)));
                    if (ds.Tables["Mailler"] != null)
                    {
                        base.Tables.Add(new MaillerDataTable(ds.Tables["Mailler"]));
                    }
                    if (ds.Tables["Ektekiler"] != null)
                    {
                        base.Tables.Add(new EktekilerDataTable(ds.Tables["Ektekiler"]));
                    }
                    base.DataSetName = ds.DataSetName;
                    base.Prefix = ds.Prefix;
                    base.Namespace = ds.Namespace;
                    base.Locale = ds.Locale;
                    base.CaseSensitive = ds.CaseSensitive;
                    base.EnforceConstraints = ds.EnforceConstraints;
                    base.Merge(ds, false, MissingSchemaAction.Add);
                    this.InitVars();
                }
                else
                {
                    base.ReadXmlSchema(new XmlTextReader(new StringReader(strSchema)));
                }
                base.GetSerializationData(info, context);
                CollectionChangeEventHandler schemaChangedHandler = new CollectionChangeEventHandler(this.SchemaChanged);
                base.Tables.CollectionChanged += schemaChangedHandler;
                this.Relations.CollectionChanged += schemaChangedHandler;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public override DataSet Clone()
        {
            Ds cln = (Ds) base.Clone();
            cln.InitVars();
            cln.SchemaSerializationMode = this.SchemaSerializationMode;
            return cln;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        protected override XmlSchema GetSchemaSerializable()
        {
            MemoryStream stream = new MemoryStream();
            base.WriteXmlSchema(new XmlTextWriter(stream, null));
            stream.Position = 0L;
            return XmlSchema.Read(new XmlTextReader(stream), null);
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
        {
            Ds ds = new Ds();
            XmlSchemaComplexType type = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny any = new XmlSchemaAny {
                Namespace = ds.Namespace
            };
            sequence.Items.Add(any);
            type.Particle = sequence;
            XmlSchema dsSchema = ds.GetSchemaSerializable();
            if (xs.Contains(dsSchema.TargetNamespace))
            {
                MemoryStream s1 = new MemoryStream();
                MemoryStream s2 = new MemoryStream();
                try
                {
                    XmlSchema schema = null;
                    dsSchema.Write(s1);
                    IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator();
                    while (schemas.MoveNext())
                    {
                        schema = (XmlSchema) schemas.Current;
                        s2.SetLength(0L);
                        schema.Write(s2);
                        if (s1.Length == s2.Length)
                        {
                            s1.Position = 0L;
                            s2.Position = 0L;
                            while ((s1.Position != s1.Length) && (s1.ReadByte() == s2.ReadByte()))
                            {
                            }
                            if (s1.Position == s1.Length)
                            {
                                return type;
                            }
                        }
                    }
                }
                finally
                {
                    if (s1 != null)
                    {
                        s1.Close();
                    }
                    if (s2 != null)
                    {
                        s2.Close();
                    }
                }
            }
            xs.Add(dsSchema);
            return type;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitClass()
        {
            base.DataSetName = "Ds";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/Ds.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableMailler = new MaillerDataTable();
            base.Tables.Add(this.tableMailler);
            this.tableEktekiler = new EktekilerDataTable();
            base.Tables.Add(this.tableEktekiler);
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        protected override void InitializeDerivedDataSet()
        {
            base.BeginInit();
            this.InitClass();
            base.EndInit();
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        internal void InitVars()
        {
            this.InitVars(true);
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        internal void InitVars(bool initTable)
        {
            this.tableMailler = (MaillerDataTable) base.Tables["Mailler"];
            if (initTable && (this.tableMailler != null))
            {
                this.tableMailler.InitVars();
            }
            this.tableEktekiler = (EktekilerDataTable) base.Tables["Ektekiler"];
            if (initTable && (this.tableEktekiler != null))
            {
                this.tableEktekiler.InitVars();
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (base.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet ds = new DataSet();
                ds.ReadXml(reader);
                if (ds.Tables["Mailler"] != null)
                {
                    base.Tables.Add(new MaillerDataTable(ds.Tables["Mailler"]));
                }
                if (ds.Tables["Ektekiler"] != null)
                {
                    base.Tables.Add(new EktekilerDataTable(ds.Tables["Ektekiler"]));
                }
                base.DataSetName = ds.DataSetName;
                base.Prefix = ds.Prefix;
                base.Namespace = ds.Namespace;
                base.Locale = ds.Locale;
                base.CaseSensitive = ds.CaseSensitive;
                base.EnforceConstraints = ds.EnforceConstraints;
                base.Merge(ds, false, MissingSchemaAction.Add);
                this.InitVars();
            }
            else
            {
                base.ReadXml(reader);
                this.InitVars();
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void SchemaChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Remove)
            {
                this.InitVars();
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeEktekiler()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeMailler()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
        public EktekilerDataTable Ektekiler
        {
            get
            {
                return this.tableEktekiler;
            }
        }

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
        public MaillerDataTable Mailler
        {
            get
            {
                return this.tableMailler;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(true)]
        public override System.Data.SchemaSerializationMode SchemaSerializationMode
        {
            get
            {
                return this._schemaSerializationMode;
            }
            set
            {
                this._schemaSerializationMode = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class EktekilerDataTable : DataTable, IEnumerable
        {
            private DataColumn columnboyutu;
            private DataColumn columndosyaAdi;
            private DataColumn columnyolu;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Ds.EktekilerRowChangeEventHandler EktekilerRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Ds.EktekilerRowChangeEventHandler EktekilerRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Ds.EktekilerRowChangeEventHandler EktekilerRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Ds.EktekilerRowChangeEventHandler EktekilerRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public EktekilerDataTable()
            {
                base.TableName = "Ektekiler";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal EktekilerDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected EktekilerDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddEktekilerRow(Ds.EktekilerRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public Ds.EktekilerRow AddEktekilerRow(string dosyaAdi, string yolu, decimal boyutu)
            {
                Ds.EktekilerRow rowEktekilerRow = (Ds.EktekilerRow) base.NewRow();
                rowEktekilerRow.ItemArray = new object[] { dosyaAdi, yolu, boyutu };
                base.Rows.Add(rowEktekilerRow);
                return rowEktekilerRow;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                Ds.EktekilerDataTable cln = (Ds.EktekilerDataTable) base.Clone();
                cln.InitVars();
                return cln;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new Ds.EktekilerDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public virtual IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(Ds.EktekilerRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                Ds ds = new Ds();
                XmlSchemaAny any1 = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any1);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute1 = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = ds.Namespace
                };
                type.Attributes.Add(attribute1);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "EktekilerDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema dsSchema = ds.GetSchemaSerializable();
                if (xs.Contains(dsSchema.TargetNamespace))
                {
                    MemoryStream s1 = new MemoryStream();
                    MemoryStream s2 = new MemoryStream();
                    try
                    {
                        XmlSchema schema = null;
                        dsSchema.Write(s1);
                        IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator();
                        while (schemas.MoveNext())
                        {
                            schema = (XmlSchema) schemas.Current;
                            s2.SetLength(0L);
                            schema.Write(s2);
                            if (s1.Length == s2.Length)
                            {
                                s1.Position = 0L;
                                s2.Position = 0L;
                                while ((s1.Position != s1.Length) && (s1.ReadByte() == s2.ReadByte()))
                                {
                                }
                                if (s1.Position == s1.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (s1 != null)
                        {
                            s1.Close();
                        }
                        if (s2 != null)
                        {
                            s2.Close();
                        }
                    }
                }
                xs.Add(dsSchema);
                return type;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            private void InitClass()
            {
                this.columndosyaAdi = new DataColumn("dosyaAdi", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columndosyaAdi);
                this.columnyolu = new DataColumn("yolu", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnyolu);
                this.columnboyutu = new DataColumn("boyutu", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnboyutu);
                this.columndosyaAdi.Caption = "Dosya Adı";
                this.columnyolu.Caption = "Dosya Yolu";
                this.columnboyutu.Caption = "Boyutu";
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columndosyaAdi = base.Columns["dosyaAdi"];
                this.columnyolu = base.Columns["yolu"];
                this.columnboyutu = base.Columns["boyutu"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public Ds.EktekilerRow NewEktekilerRow()
            {
                return (Ds.EktekilerRow) base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new Ds.EktekilerRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.EktekilerRowChanged != null)
                {
                    this.EktekilerRowChanged(this, new Ds.EktekilerRowChangeEvent((Ds.EktekilerRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.EktekilerRowChanging != null)
                {
                    this.EktekilerRowChanging(this, new Ds.EktekilerRowChangeEvent((Ds.EktekilerRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.EktekilerRowDeleted != null)
                {
                    this.EktekilerRowDeleted(this, new Ds.EktekilerRowChangeEvent((Ds.EktekilerRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.EktekilerRowDeleting != null)
                {
                    this.EktekilerRowDeleting(this, new Ds.EktekilerRowChangeEvent((Ds.EktekilerRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveEktekilerRow(Ds.EktekilerRow row)
            {
                base.Rows.Remove(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn boyutuColumn
            {
                get
                {
                    return this.columnboyutu;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn dosyaAdiColumn
            {
                get
                {
                    return this.columndosyaAdi;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public Ds.EktekilerRow this[int index]
            {
                get
                {
                    return (Ds.EktekilerRow) base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn yoluColumn
            {
                get
                {
                    return this.columnyolu;
                }
            }
        }

        public class EktekilerRow : DataRow
        {
            private Ds.EktekilerDataTable tableEktekiler;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal EktekilerRow(DataRowBuilder rb) : base(rb)
            {
                this.tableEktekiler = (Ds.EktekilerDataTable) base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsboyutuNull()
            {
                return base.IsNull(this.tableEktekiler.boyutuColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsdosyaAdiNull()
            {
                return base.IsNull(this.tableEktekiler.dosyaAdiColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsyoluNull()
            {
                return base.IsNull(this.tableEktekiler.yoluColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetboyutuNull()
            {
                base[this.tableEktekiler.boyutuColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetdosyaAdiNull()
            {
                base[this.tableEktekiler.dosyaAdiColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetyoluNull()
            {
                base[this.tableEktekiler.yoluColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public decimal boyutu
            {
                get
                {
                    decimal CS$1$0000;
                    try
                    {
                        CS$1$0000 = (decimal) base[this.tableEktekiler.boyutuColumn];
                    }
                    catch (InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column 'boyutu' in table 'Ektekiler' is DBNull.", e);
                    }
                    return CS$1$0000;
                }
                set
                {
                    base[this.tableEktekiler.boyutuColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string dosyaAdi
            {
                get
                {
                    string CS$1$0000;
                    try
                    {
                        CS$1$0000 = (string) base[this.tableEktekiler.dosyaAdiColumn];
                    }
                    catch (InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column 'dosyaAdi' in table 'Ektekiler' is DBNull.", e);
                    }
                    return CS$1$0000;
                }
                set
                {
                    base[this.tableEktekiler.dosyaAdiColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string yolu
            {
                get
                {
                    string CS$1$0000;
                    try
                    {
                        CS$1$0000 = (string) base[this.tableEktekiler.yoluColumn];
                    }
                    catch (InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column 'yolu' in table 'Ektekiler' is DBNull.", e);
                    }
                    return CS$1$0000;
                }
                set
                {
                    base[this.tableEktekiler.yoluColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class EktekilerRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private Ds.EktekilerRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public EktekilerRowChangeEvent(Ds.EktekilerRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public Ds.EktekilerRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void EktekilerRowChangeEventHandler(object sender, Ds.EktekilerRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class MaillerDataTable : DataTable, IEnumerable
        {
            private DataColumn columndurum;
            private DataColumn columnmail;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Ds.MaillerRowChangeEventHandler MaillerRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Ds.MaillerRowChangeEventHandler MaillerRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Ds.MaillerRowChangeEventHandler MaillerRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Ds.MaillerRowChangeEventHandler MaillerRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public MaillerDataTable()
            {
                base.TableName = "Mailler";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal MaillerDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected MaillerDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddMaillerRow(Ds.MaillerRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Ds.MaillerRow AddMaillerRow(string mail, byte durum)
            {
                Ds.MaillerRow rowMaillerRow = (Ds.MaillerRow) base.NewRow();
                rowMaillerRow.ItemArray = new object[] { mail, durum };
                base.Rows.Add(rowMaillerRow);
                return rowMaillerRow;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                Ds.MaillerDataTable cln = (Ds.MaillerDataTable) base.Clone();
                cln.InitVars();
                return cln;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new Ds.MaillerDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public virtual IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(Ds.MaillerRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                Ds ds = new Ds();
                XmlSchemaAny any1 = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any1);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute1 = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = ds.Namespace
                };
                type.Attributes.Add(attribute1);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "MaillerDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema dsSchema = ds.GetSchemaSerializable();
                if (xs.Contains(dsSchema.TargetNamespace))
                {
                    MemoryStream s1 = new MemoryStream();
                    MemoryStream s2 = new MemoryStream();
                    try
                    {
                        XmlSchema schema = null;
                        dsSchema.Write(s1);
                        IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator();
                        while (schemas.MoveNext())
                        {
                            schema = (XmlSchema) schemas.Current;
                            s2.SetLength(0L);
                            schema.Write(s2);
                            if (s1.Length == s2.Length)
                            {
                                s1.Position = 0L;
                                s2.Position = 0L;
                                while ((s1.Position != s1.Length) && (s1.ReadByte() == s2.ReadByte()))
                                {
                                }
                                if (s1.Position == s1.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (s1 != null)
                        {
                            s1.Close();
                        }
                        if (s2 != null)
                        {
                            s2.Close();
                        }
                    }
                }
                xs.Add(dsSchema);
                return type;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            private void InitClass()
            {
                this.columnmail = new DataColumn("mail", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnmail);
                this.columndurum = new DataColumn("durum", typeof(byte), null, MappingType.Element);
                base.Columns.Add(this.columndurum);
                this.columnmail.Caption = "Mail Adresi";
                this.columndurum.Caption = "Durumu";
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnmail = base.Columns["mail"];
                this.columndurum = base.Columns["durum"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Ds.MaillerRow NewMaillerRow()
            {
                return (Ds.MaillerRow) base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new Ds.MaillerRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.MaillerRowChanged != null)
                {
                    this.MaillerRowChanged(this, new Ds.MaillerRowChangeEvent((Ds.MaillerRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.MaillerRowChanging != null)
                {
                    this.MaillerRowChanging(this, new Ds.MaillerRowChangeEvent((Ds.MaillerRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.MaillerRowDeleted != null)
                {
                    this.MaillerRowDeleted(this, new Ds.MaillerRowChangeEvent((Ds.MaillerRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.MaillerRowDeleting != null)
                {
                    this.MaillerRowDeleting(this, new Ds.MaillerRowChangeEvent((Ds.MaillerRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveMaillerRow(Ds.MaillerRow row)
            {
                base.Rows.Remove(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn durumColumn
            {
                get
                {
                    return this.columndurum;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Ds.MaillerRow this[int index]
            {
                get
                {
                    return (Ds.MaillerRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn mailColumn
            {
                get
                {
                    return this.columnmail;
                }
            }
        }

        public class MaillerRow : DataRow
        {
            private Ds.MaillerDataTable tableMailler;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal MaillerRow(DataRowBuilder rb) : base(rb)
            {
                this.tableMailler = (Ds.MaillerDataTable) base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsdurumNull()
            {
                return base.IsNull(this.tableMailler.durumColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsmailNull()
            {
                return base.IsNull(this.tableMailler.mailColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetdurumNull()
            {
                base[this.tableMailler.durumColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetmailNull()
            {
                base[this.tableMailler.mailColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public byte durum
            {
                get
                {
                    byte CS$1$0000;
                    try
                    {
                        CS$1$0000 = (byte) base[this.tableMailler.durumColumn];
                    }
                    catch (InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column 'durum' in table 'Mailler' is DBNull.", e);
                    }
                    return CS$1$0000;
                }
                set
                {
                    base[this.tableMailler.durumColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string mail
            {
                get
                {
                    string CS$1$0000;
                    try
                    {
                        CS$1$0000 = (string) base[this.tableMailler.mailColumn];
                    }
                    catch (InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column 'mail' in table 'Mailler' is DBNull.", e);
                    }
                    return CS$1$0000;
                }
                set
                {
                    base[this.tableMailler.mailColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class MaillerRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private Ds.MaillerRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public MaillerRowChangeEvent(Ds.MaillerRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Ds.MaillerRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void MaillerRowChangeEventHandler(object sender, Ds.MaillerRowChangeEvent e);
    }
}

