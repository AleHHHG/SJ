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
    /// Strongly-typed collection for the Financeiro class.
    /// </summary>
    [Serializable]
    public partial class FinanceiroCollection : ActiveList<Financeiro, FinanceiroCollection>
    {
        public FinanceiroCollection() { }

        /// <summary>
        /// Filters an existing collection based on the set criteria. This is an in-memory filter
        /// Thanks to developingchris for this!
        /// </summary>
        /// <returns>FinanceiroCollection</returns>
        public FinanceiroCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Financeiro o = this[i];
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
    /// This is an ActiveRecord class which wraps the financeiro table.
    /// </summary>
    [Serializable]
    public partial class Financeiro : ActiveRecord<Financeiro>, IActiveRecord
    {
        #region .ctors and Default Settings

        public Financeiro()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }

        private void InitSetDefaults() { SetDefaults(); }

        public Financeiro(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }

        public Financeiro(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public Financeiro(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("financeiro", TableType.Table, DataService.GetInstance("SJ.DAL"));
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

                TableSchema.TableColumn colvarFormaPagamentoId = new TableSchema.TableColumn(schema);
                colvarFormaPagamentoId.ColumnName = "forma_pagamento_id";
                colvarFormaPagamentoId.DataType = DbType.Int32;
                colvarFormaPagamentoId.MaxLength = 0;
                colvarFormaPagamentoId.AutoIncrement = false;
                colvarFormaPagamentoId.IsNullable = false;
                colvarFormaPagamentoId.IsPrimaryKey = false;
                colvarFormaPagamentoId.IsForeignKey = false;
                colvarFormaPagamentoId.IsReadOnly = false;
                colvarFormaPagamentoId.DefaultSetting = @"";
                colvarFormaPagamentoId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarFormaPagamentoId);

                TableSchema.TableColumn colvarUsuarioId = new TableSchema.TableColumn(schema);
                colvarUsuarioId.ColumnName = "usuario_id";
                colvarUsuarioId.DataType = DbType.Int32;
                colvarUsuarioId.MaxLength = 0;
                colvarUsuarioId.AutoIncrement = false;
                colvarUsuarioId.IsNullable = false;
                colvarUsuarioId.IsPrimaryKey = false;
                colvarUsuarioId.IsForeignKey = false;
                colvarUsuarioId.IsReadOnly = false;
                colvarUsuarioId.DefaultSetting = @"";
                colvarUsuarioId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarUsuarioId);

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

                TableSchema.TableColumn colvarDataCadastro = new TableSchema.TableColumn(schema);
                colvarDataCadastro.ColumnName = "data_cadastro";
                colvarDataCadastro.DataType = DbType.DateTime;
                colvarDataCadastro.MaxLength = 0;
                colvarDataCadastro.AutoIncrement = false;
                colvarDataCadastro.IsNullable = true;
                colvarDataCadastro.IsPrimaryKey = false;
                colvarDataCadastro.IsForeignKey = false;
                colvarDataCadastro.IsReadOnly = false;
                colvarDataCadastro.DefaultSetting = @"";
                colvarDataCadastro.ForeignKeyTableName = "";
                schema.Columns.Add(colvarDataCadastro);

                TableSchema.TableColumn colvarTipo = new TableSchema.TableColumn(schema);
                colvarTipo.ColumnName = "tipo";
                colvarTipo.DataType = DbType.Int32;
                colvarTipo.MaxLength = 0;
                colvarTipo.AutoIncrement = false;
                colvarTipo.IsNullable = true;
                colvarTipo.IsPrimaryKey = false;
                colvarTipo.IsForeignKey = false;
                colvarTipo.IsReadOnly = false;
                colvarTipo.DefaultSetting = @"";
                colvarTipo.ForeignKeyTableName = "";
                schema.Columns.Add(colvarTipo);

                TableSchema.TableColumn colvarIdCliente = new TableSchema.TableColumn(schema);
                colvarIdCliente.ColumnName = "id_cliente";
                colvarIdCliente.DataType = DbType.Int32;
                colvarIdCliente.MaxLength = 0;
                colvarIdCliente.AutoIncrement = false;
                colvarIdCliente.IsNullable = true;
                colvarIdCliente.IsPrimaryKey = false;
                colvarIdCliente.IsForeignKey = false;
                colvarIdCliente.IsReadOnly = false;
                colvarIdCliente.DefaultSetting = @"";
                colvarIdCliente.ForeignKeyTableName = "";
                schema.Columns.Add(colvarIdCliente);

                TableSchema.TableColumn colvarOrigem = new TableSchema.TableColumn(schema);
                colvarOrigem.ColumnName = "origem";
                colvarOrigem.DataType = DbType.Int32;
                colvarOrigem.MaxLength = 0;
                colvarOrigem.AutoIncrement = false;
                colvarOrigem.IsNullable = true;
                colvarOrigem.IsPrimaryKey = false;
                colvarOrigem.IsForeignKey = false;
                colvarOrigem.IsReadOnly = false;
                colvarOrigem.DefaultSetting = @"";
                colvarOrigem.ForeignKeyTableName = "";
                schema.Columns.Add(colvarOrigem);

                TableSchema.TableColumn colvarObservacao = new TableSchema.TableColumn(schema);
                colvarObservacao.ColumnName = "observacao";
                colvarObservacao.DataType = DbType.String;
                colvarObservacao.MaxLength = 16777215;
                colvarObservacao.AutoIncrement = false;
                colvarObservacao.IsNullable = true;
                colvarObservacao.IsPrimaryKey = false;
                colvarObservacao.IsForeignKey = false;
                colvarObservacao.IsReadOnly = false;
                colvarObservacao.DefaultSetting = @"";
                colvarObservacao.ForeignKeyTableName = "";
                schema.Columns.Add(colvarObservacao);

                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["SJ.DAL"].AddSchema("financeiro", schema);
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

        [XmlAttribute("FormaPagamentoId")]
        [Bindable(true)]
        public int FormaPagamentoId
        {
            get { return GetColumnValue<int>(Columns.FormaPagamentoId); }
            set { SetColumnValue(Columns.FormaPagamentoId, value); }
        }

        [XmlAttribute("UsuarioId")]
        [Bindable(true)]
        public int UsuarioId
        {
            get { return GetColumnValue<int>(Columns.UsuarioId); }
            set { SetColumnValue(Columns.UsuarioId, value); }
        }

        [XmlAttribute("Valor")]
        [Bindable(true)]
        public decimal? Valor
        {
            get { return GetColumnValue<decimal?>(Columns.Valor); }
            set { SetColumnValue(Columns.Valor, value); }
        }

        [XmlAttribute("DataCadastro")]
        [Bindable(true)]
        public DateTime? DataCadastro
        {
            get { return GetColumnValue<DateTime?>(Columns.DataCadastro); }
            set { SetColumnValue(Columns.DataCadastro, value); }
        }

        [XmlAttribute("Tipo")]
        [Bindable(true)]
        public int? Tipo
        {
            get { return GetColumnValue<int?>(Columns.Tipo); }
            set { SetColumnValue(Columns.Tipo, value); }
        }

        [XmlAttribute("IdCliente")]
        [Bindable(true)]
        public int? IdCliente
        {
            get { return GetColumnValue<int?>(Columns.IdCliente); }
            set { SetColumnValue(Columns.IdCliente, value); }
        }

        [XmlAttribute("Origem")]
        [Bindable(true)]
        public int? Origem
        {
            get { return GetColumnValue<int?>(Columns.Origem); }
            set { SetColumnValue(Columns.Origem, value); }
        }

        [XmlAttribute("Observacao")]
        [Bindable(true)]
        public string Observacao
        {
            get { return GetColumnValue<string>(Columns.Observacao); }
            set { SetColumnValue(Columns.Observacao, value); }
        }

        #endregion




        //no foreign key tables defined (0)



        //no ManyToMany tables defined (0)



        #region ObjectDataSource support


        /// <summary>
        /// Inserts a record, can be used with the Object Data Source
        /// </summary>
        public static void Insert(int varFormaPagamentoId, int varUsuarioId, decimal? varValor, DateTime? varDataCadastro, int? varTipo, int? varIdCliente, int? varOrigem, string varObservacao)
        {
            Financeiro item = new Financeiro();

            item.FormaPagamentoId = varFormaPagamentoId;

            item.UsuarioId = varUsuarioId;

            item.Valor = varValor;

            item.DataCadastro = varDataCadastro;

            item.Tipo = varTipo;

            item.IdCliente = varIdCliente;

            item.Origem = varOrigem;

            item.Observacao = varObservacao;


            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

        /// <summary>
        /// Updates a record, can be used with the Object Data Source
        /// </summary>
        public static void Update(int varId, int varFormaPagamentoId, int varUsuarioId, decimal? varValor, DateTime? varDataCadastro, int? varTipo, int? varIdCliente, int? varOrigem, string varObservacao)
        {
            Financeiro item = new Financeiro();

            item.Id = varId;

            item.FormaPagamentoId = varFormaPagamentoId;

            item.UsuarioId = varUsuarioId;

            item.Valor = varValor;

            item.DataCadastro = varDataCadastro;

            item.Tipo = varTipo;

            item.IdCliente = varIdCliente;

            item.Origem = varOrigem;

            item.Observacao = varObservacao;

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



        public static TableSchema.TableColumn FormaPagamentoIdColumn
        {
            get { return Schema.Columns[1]; }
        }



        public static TableSchema.TableColumn UsuarioIdColumn
        {
            get { return Schema.Columns[2]; }
        }



        public static TableSchema.TableColumn ValorColumn
        {
            get { return Schema.Columns[3]; }
        }



        public static TableSchema.TableColumn DataCadastroColumn
        {
            get { return Schema.Columns[4]; }
        }



        public static TableSchema.TableColumn TipoColumn
        {
            get { return Schema.Columns[5]; }
        }



        public static TableSchema.TableColumn IdClienteColumn
        {
            get { return Schema.Columns[6]; }
        }



        public static TableSchema.TableColumn OrigemColumn
        {
            get { return Schema.Columns[7]; }
        }



        public static TableSchema.TableColumn ObservacaoColumn
        {
            get { return Schema.Columns[8]; }
        }



        #endregion
        #region Columns Struct
        public struct Columns
        {
            public static string Id = @"id";
            public static string FormaPagamentoId = @"forma_pagamento_id";
            public static string UsuarioId = @"usuario_id";
            public static string Valor = @"valor";
            public static string DataCadastro = @"data_cadastro";
            public static string Tipo = @"tipo";
            public static string IdCliente = @"id_cliente";
            public static string Origem = @"origem";
            public static string Observacao = @"observacao";

        }
        #endregion

        #region Update PK Collections

        #endregion

        #region Deep Save

        #endregion
    }
}

