using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using SubSonic;
using SubSonic.Utilities;
namespace SJ.DAL
{
    /// <summary>
    /// Strongly-typed collection for the Produto class.
    /// </summary>
    [Serializable]
    public partial class ProdutoCollection : ActiveList<Produto, ProdutoCollection>
    {
        public ProdutoCollection() { }

        /// <summary>
        /// Filters an existing collection based on the set criteria. This is an in-memory filter
        /// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ProdutoCollection</returns>
        public ProdutoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Produto o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }


    }
    /// <summary>
    /// This is an ActiveRecord class which wraps the produtos table.
    /// </summary>
    [Serializable]
    public partial class Produto : ActiveRecord<Produto>, IActiveRecord
    {
        #region .ctors and Default Settings

        public Produto()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }

        private void InitSetDefaults() { SetDefaults(); }

        public Produto(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }

        public Produto(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public Produto(string columnName, object columnValue)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByParam(columnName, columnValue);
        }

        protected static void SetSQLProps() { GetTableSchema(); }

        #endregion

        #region Schema and Query Accessor	
        public static Query CreateQuery() { return new Query(Schema); }
        public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                    SetSQLProps();
                return BaseSchema;
            }
        }

        private static void GetTableSchema()
        {
            if (!IsSchemaInitialized)
            {
                //Schema declaration
                TableSchema.Table schema = new TableSchema.Table("produtos", TableType.Table, DataService.GetInstance("SJ.DAL"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"";
                //columns

                TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
                colvarId.ColumnName = "id";
                colvarId.DataType = DbType.Int32;
                colvarId.MaxLength = 0;
                colvarId.AutoIncrement = true;
                colvarId.IsNullable = false;
                colvarId.IsPrimaryKey = true;
                colvarId.IsForeignKey = false;
                colvarId.IsReadOnly = false;
                colvarId.DefaultSetting = @"";
                colvarId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarId);

                TableSchema.TableColumn colvarNome = new TableSchema.TableColumn(schema);
                colvarNome.ColumnName = "nome";
                colvarNome.DataType = DbType.String;
                colvarNome.MaxLength = 150;
                colvarNome.AutoIncrement = false;
                colvarNome.IsNullable = true;
                colvarNome.IsPrimaryKey = false;
                colvarNome.IsForeignKey = false;
                colvarNome.IsReadOnly = false;
                colvarNome.DefaultSetting = @"";
                colvarNome.ForeignKeyTableName = "";
                schema.Columns.Add(colvarNome);

                TableSchema.TableColumn colvarValor = new TableSchema.TableColumn(schema);
                colvarValor.ColumnName = "valor";
                colvarValor.DataType = DbType.Decimal;
                colvarValor.MaxLength = 0;
                colvarValor.AutoIncrement = false;
                colvarValor.IsNullable = true;
                colvarValor.IsPrimaryKey = false;
                colvarValor.IsForeignKey = false;
                colvarValor.IsReadOnly = false;
                colvarValor.DefaultSetting = @"";
                colvarValor.ForeignKeyTableName = "";
                schema.Columns.Add(colvarValor);

                TableSchema.TableColumn colvarTipo = new TableSchema.TableColumn(schema);
                colvarTipo.ColumnName = "tipo";
                colvarTipo.DataType = DbType.String;
                colvarTipo.MaxLength = 1;
                colvarTipo.AutoIncrement = false;
                colvarTipo.IsNullable = true;
                colvarTipo.IsPrimaryKey = false;
                colvarTipo.IsForeignKey = false;
                colvarTipo.IsReadOnly = false;
                colvarTipo.DefaultSetting = @"";
                colvarTipo.ForeignKeyTableName = "";
                schema.Columns.Add(colvarTipo);

                TableSchema.TableColumn colvarAtivo = new TableSchema.TableColumn(schema);
                colvarAtivo.ColumnName = "ativo";
                colvarAtivo.DataType = DbType.Boolean;
                colvarAtivo.MaxLength = 0;
                colvarAtivo.AutoIncrement = false;
                colvarAtivo.IsNullable = true;
                colvarAtivo.IsPrimaryKey = false;
                colvarAtivo.IsForeignKey = false;
                colvarAtivo.IsReadOnly = false;
                colvarAtivo.DefaultSetting = @"";
                colvarAtivo.ForeignKeyTableName = "";
                schema.Columns.Add(colvarAtivo);

                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["SJ.DAL"].AddSchema("produtos", schema);
            }
        }
        #endregion

        #region Props

        [XmlAttribute("Id")]
        [Bindable(true)]
        public int Id
        {
            get { return GetColumnValue<int>(Columns.Id); }
            set { SetColumnValue(Columns.Id, value); }
        }

        [XmlAttribute("Nome")]
        [Bindable(true)]
        public string Nome
        {
            get { return GetColumnValue<string>(Columns.Nome); }
            set { SetColumnValue(Columns.Nome, value); }
        }

        [XmlAttribute("Valor")]
        [Bindable(true)]
        public decimal? Valor
        {
            get { return GetColumnValue<decimal?>(Columns.Valor); }
            set { SetColumnValue(Columns.Valor, value); }
        }

        [XmlAttribute("Tipo")]
        [Bindable(true)]
        public string Tipo
        {
            get { return GetColumnValue<string>(Columns.Tipo); }
            set { SetColumnValue(Columns.Tipo, value); }
        }

        [XmlAttribute("Ativo")]
        [Bindable(true)]
        public bool? Ativo
        {
            get { return GetColumnValue<bool?>(Columns.Ativo); }
            set { SetColumnValue(Columns.Ativo, value); }
        }

        #endregion




        //no foreign key tables defined (0)



        //no ManyToMany tables defined (0)



        #region ObjectDataSource support


        /// <summary>
        /// Inserts a record, can be used with the Object Data Source
        /// </summary>
        public static void Insert(string varNome, decimal? varValor, string varTipo, bool? varAtivo)
        {
            Produto item = new Produto();

            item.Nome = varNome;

            item.Valor = varValor;

            item.Tipo = varTipo;

            item.Ativo = varAtivo;


            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

        /// <summary>
        /// Updates a record, can be used with the Object Data Source
        /// </summary>
        public static void Update(int varId, string varNome, decimal? varValor, string varTipo, bool? varAtivo)
        {
            Produto item = new Produto();

            item.Id = varId;

            item.Nome = varNome;

            item.Valor = varValor;

            item.Tipo = varTipo;

            item.Ativo = varAtivo;

            item.IsNew = false;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        #endregion



        #region Typed Columns


        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }



        public static TableSchema.TableColumn NomeColumn
        {
            get { return Schema.Columns[1]; }
        }



        public static TableSchema.TableColumn ValorColumn
        {
            get { return Schema.Columns[2]; }
        }



        public static TableSchema.TableColumn TipoColumn
        {
            get { return Schema.Columns[3]; }
        }



        public static TableSchema.TableColumn AtivoColumn
        {
            get { return Schema.Columns[4]; }
        }



        #endregion
        #region Columns Struct
        public struct Columns
        {
            public static string Id = @"id";
            public static string Nome = @"nome";
            public static string Valor = @"valor";
            public static string Tipo = @"tipo";
            public static string Ativo = @"ativo";

        }
        #endregion

        #region Update PK Collections

        #endregion

        #region Deep Save

        #endregion
    }
}

