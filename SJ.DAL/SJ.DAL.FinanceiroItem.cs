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
    /// Strongly-typed collection for the FinanceiroItem class.
    /// </summary>
    [Serializable]
    public partial class FinanceiroItemCollection : ActiveList<FinanceiroItem, FinanceiroItemCollection>
    {
        public FinanceiroItemCollection() { }

        /// <summary>
        /// Filters an existing collection based on the set criteria. This is an in-memory filter
        /// Thanks to developingchris for this!
        /// </summary>
        /// <returns>FinanceiroItemCollection</returns>
        public FinanceiroItemCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                FinanceiroItem o = this[i];
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
    /// This is an ActiveRecord class which wraps the financeiro_items table.
    /// </summary>
    [Serializable]
    public partial class FinanceiroItem : ActiveRecord<FinanceiroItem>, IActiveRecord
    {
        #region .ctors and Default Settings

        public FinanceiroItem()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }

        private void InitSetDefaults() { SetDefaults(); }

        public FinanceiroItem(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }

        public FinanceiroItem(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public FinanceiroItem(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("financeiro_items", TableType.Table, DataService.GetInstance("SJ.DAL"));
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

                TableSchema.TableColumn colvarFinanceiroId = new TableSchema.TableColumn(schema);
                colvarFinanceiroId.ColumnName = "financeiro_id";
                colvarFinanceiroId.DataType = DbType.Int32;
                colvarFinanceiroId.MaxLength = 0;
                colvarFinanceiroId.AutoIncrement = false;
                colvarFinanceiroId.IsNullable = false;
                colvarFinanceiroId.IsPrimaryKey = false;
                colvarFinanceiroId.IsForeignKey = false;
                colvarFinanceiroId.IsReadOnly = false;
                colvarFinanceiroId.DefaultSetting = @"";
                colvarFinanceiroId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarFinanceiroId);

                TableSchema.TableColumn colvarAbrangenciaId = new TableSchema.TableColumn(schema);
                colvarAbrangenciaId.ColumnName = "abrangencia_id";
                colvarAbrangenciaId.DataType = DbType.Int32;
                colvarAbrangenciaId.MaxLength = 0;
                colvarAbrangenciaId.AutoIncrement = false;
                colvarAbrangenciaId.IsNullable = false;
                colvarAbrangenciaId.IsPrimaryKey = false;
                colvarAbrangenciaId.IsForeignKey = false;
                colvarAbrangenciaId.IsReadOnly = false;
                colvarAbrangenciaId.DefaultSetting = @"";
                colvarAbrangenciaId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarAbrangenciaId);

                TableSchema.TableColumn colvarIdAbrangencia = new TableSchema.TableColumn(schema);
                colvarIdAbrangencia.ColumnName = "id_abrangencia";
                colvarIdAbrangencia.DataType = DbType.Int32;
                colvarIdAbrangencia.MaxLength = 0;
                colvarIdAbrangencia.AutoIncrement = false;
                colvarIdAbrangencia.IsNullable = true;
                colvarIdAbrangencia.IsPrimaryKey = false;
                colvarIdAbrangencia.IsForeignKey = false;
                colvarIdAbrangencia.IsReadOnly = false;
                colvarIdAbrangencia.DefaultSetting = @"";
                colvarIdAbrangencia.ForeignKeyTableName = "";
                schema.Columns.Add(colvarIdAbrangencia);

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

                TableSchema.TableColumn colvarQuantidade = new TableSchema.TableColumn(schema);
                colvarQuantidade.ColumnName = "quantidade";
                colvarQuantidade.DataType = DbType.Int32;
                colvarQuantidade.MaxLength = 0;
                colvarQuantidade.AutoIncrement = false;
                colvarQuantidade.IsNullable = true;
                colvarQuantidade.IsPrimaryKey = false;
                colvarQuantidade.IsForeignKey = false;
                colvarQuantidade.IsReadOnly = false;
                colvarQuantidade.DefaultSetting = @"";
                colvarQuantidade.ForeignKeyTableName = "";
                schema.Columns.Add(colvarQuantidade);

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
                DataService.Providers["SJ.DAL"].AddSchema("financeiro_items", schema);
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

        [XmlAttribute("FinanceiroId")]
        [Bindable(true)]
        public int FinanceiroId
        {
            get { return GetColumnValue<int>(Columns.FinanceiroId); }
            set { SetColumnValue(Columns.FinanceiroId, value); }
        }

        [XmlAttribute("AbrangenciaId")]
        [Bindable(true)]
        public int AbrangenciaId
        {
            get { return GetColumnValue<int>(Columns.AbrangenciaId); }
            set { SetColumnValue(Columns.AbrangenciaId, value); }
        }

        [XmlAttribute("IdAbrangencia")]
        [Bindable(true)]
        public int? IdAbrangencia
        {
            get { return GetColumnValue<int?>(Columns.IdAbrangencia); }
            set { SetColumnValue(Columns.IdAbrangencia, value); }
        }

        [XmlAttribute("Valor")]
        [Bindable(true)]
        public decimal? Valor
        {
            get { return GetColumnValue<decimal?>(Columns.Valor); }
            set { SetColumnValue(Columns.Valor, value); }
        }

        [XmlAttribute("Quantidade")]
        [Bindable(true)]
        public int? Quantidade
        {
            get { return GetColumnValue<int?>(Columns.Quantidade); }
            set { SetColumnValue(Columns.Quantidade, value); }
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
        public static void Insert(int varFinanceiroId, int varAbrangenciaId, int? varIdAbrangencia, decimal? varValor, int? varQuantidade, string varObservacao)
        {
            FinanceiroItem item = new FinanceiroItem();

            item.FinanceiroId = varFinanceiroId;

            item.AbrangenciaId = varAbrangenciaId;

            item.IdAbrangencia = varIdAbrangencia;

            item.Valor = varValor;

            item.Quantidade = varQuantidade;

            item.Observacao = varObservacao;


            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

        /// <summary>
        /// Updates a record, can be used with the Object Data Source
        /// </summary>
        public static void Update(int varId, int varFinanceiroId, int varAbrangenciaId, int? varIdAbrangencia, decimal? varValor, int? varQuantidade, string varObservacao)
        {
            FinanceiroItem item = new FinanceiroItem();

            item.Id = varId;

            item.FinanceiroId = varFinanceiroId;

            item.AbrangenciaId = varAbrangenciaId;

            item.IdAbrangencia = varIdAbrangencia;

            item.Valor = varValor;

            item.Quantidade = varQuantidade;

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



        public static TableSchema.TableColumn FinanceiroIdColumn
        {
            get { return Schema.Columns[1]; }
        }



        public static TableSchema.TableColumn AbrangenciaIdColumn
        {
            get { return Schema.Columns[2]; }
        }



        public static TableSchema.TableColumn IdAbrangenciaColumn
        {
            get { return Schema.Columns[3]; }
        }



        public static TableSchema.TableColumn ValorColumn
        {
            get { return Schema.Columns[4]; }
        }



        public static TableSchema.TableColumn QuantidadeColumn
        {
            get { return Schema.Columns[5]; }
        }



        public static TableSchema.TableColumn ObservacaoColumn
        {
            get { return Schema.Columns[6]; }
        }



        #endregion
        #region Columns Struct
        public struct Columns
        {
            public static string Id = @"id";
            public static string FinanceiroId = @"financeiro_id";
            public static string AbrangenciaId = @"abrangencia_id";
            public static string IdAbrangencia = @"id_abrangencia";
            public static string Valor = @"valor";
            public static string Quantidade = @"quantidade";
            public static string Observacao = @"observacao";

        }
        #endregion

        #region Update PK Collections

        #endregion

        #region Deep Save

        #endregion
    }
}

