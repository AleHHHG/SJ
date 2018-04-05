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
	/// Strongly-typed collection for the Endereco class.
	/// </summary>
    [Serializable]
	public partial class EnderecoCollection : ActiveList<Endereco, EnderecoCollection>
	{	   
		public EnderecoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>EnderecoCollection</returns>
		public EnderecoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Endereco o = this[i];
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
	/// This is an ActiveRecord class which wraps the enderecos table.
	/// </summary>
	[Serializable]
	public partial class Endereco : ActiveRecord<Endereco>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Endereco()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Endereco(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Endereco(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Endereco(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
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
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("enderecos", TableType.Table, DataService.GetInstance("SJ.DAL"));
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
				
				TableSchema.TableColumn colvarLogradouro = new TableSchema.TableColumn(schema);
				colvarLogradouro.ColumnName = "logradouro";
				colvarLogradouro.DataType = DbType.String;
				colvarLogradouro.MaxLength = 255;
				colvarLogradouro.AutoIncrement = false;
				colvarLogradouro.IsNullable = true;
				colvarLogradouro.IsPrimaryKey = false;
				colvarLogradouro.IsForeignKey = false;
				colvarLogradouro.IsReadOnly = false;
				colvarLogradouro.DefaultSetting = @"";
				colvarLogradouro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLogradouro);
				
				TableSchema.TableColumn colvarNumero = new TableSchema.TableColumn(schema);
				colvarNumero.ColumnName = "numero";
				colvarNumero.DataType = DbType.Int32;
				colvarNumero.MaxLength = 0;
				colvarNumero.AutoIncrement = false;
				colvarNumero.IsNullable = true;
				colvarNumero.IsPrimaryKey = false;
				colvarNumero.IsForeignKey = false;
				colvarNumero.IsReadOnly = false;
				colvarNumero.DefaultSetting = @"";
				colvarNumero.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumero);
				
				TableSchema.TableColumn colvarBairro = new TableSchema.TableColumn(schema);
				colvarBairro.ColumnName = "bairro";
				colvarBairro.DataType = DbType.String;
				colvarBairro.MaxLength = 100;
				colvarBairro.AutoIncrement = false;
				colvarBairro.IsNullable = true;
				colvarBairro.IsPrimaryKey = false;
				colvarBairro.IsForeignKey = false;
				colvarBairro.IsReadOnly = false;
				colvarBairro.DefaultSetting = @"";
				colvarBairro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBairro);
				
				TableSchema.TableColumn colvarCidade = new TableSchema.TableColumn(schema);
				colvarCidade.ColumnName = "cidade";
				colvarCidade.DataType = DbType.String;
				colvarCidade.MaxLength = 150;
				colvarCidade.AutoIncrement = false;
				colvarCidade.IsNullable = true;
				colvarCidade.IsPrimaryKey = false;
				colvarCidade.IsForeignKey = false;
				colvarCidade.IsReadOnly = false;
				colvarCidade.DefaultSetting = @"";
				colvarCidade.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCidade);
				
				TableSchema.TableColumn colvarCep = new TableSchema.TableColumn(schema);
				colvarCep.ColumnName = "cep";
				colvarCep.DataType = DbType.String;
				colvarCep.MaxLength = 9;
				colvarCep.AutoIncrement = false;
				colvarCep.IsNullable = true;
				colvarCep.IsPrimaryKey = false;
				colvarCep.IsForeignKey = false;
				colvarCep.IsReadOnly = false;
				colvarCep.DefaultSetting = @"";
				colvarCep.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCep);
				
				TableSchema.TableColumn colvarUf = new TableSchema.TableColumn(schema);
				colvarUf.ColumnName = "uf";
				colvarUf.DataType = DbType.String;
				colvarUf.MaxLength = 2;
				colvarUf.AutoIncrement = false;
				colvarUf.IsNullable = true;
				colvarUf.IsPrimaryKey = false;
				colvarUf.IsForeignKey = false;
				colvarUf.IsReadOnly = false;
				colvarUf.DefaultSetting = @"";
				colvarUf.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUf);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SJ.DAL"].AddSchema("enderecos",schema);
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
		  
		[XmlAttribute("Logradouro")]
		[Bindable(true)]
		public string Logradouro 
		{
			get { return GetColumnValue<string>(Columns.Logradouro); }
			set { SetColumnValue(Columns.Logradouro, value); }
		}
		  
		[XmlAttribute("Numero")]
		[Bindable(true)]
		public int? Numero 
		{
			get { return GetColumnValue<int?>(Columns.Numero); }
			set { SetColumnValue(Columns.Numero, value); }
		}
		  
		[XmlAttribute("Bairro")]
		[Bindable(true)]
		public string Bairro 
		{
			get { return GetColumnValue<string>(Columns.Bairro); }
			set { SetColumnValue(Columns.Bairro, value); }
		}
		  
		[XmlAttribute("Cidade")]
		[Bindable(true)]
		public string Cidade 
		{
			get { return GetColumnValue<string>(Columns.Cidade); }
			set { SetColumnValue(Columns.Cidade, value); }
		}
		  
		[XmlAttribute("Cep")]
		[Bindable(true)]
		public string Cep 
		{
			get { return GetColumnValue<string>(Columns.Cep); }
			set { SetColumnValue(Columns.Cep, value); }
		}
		  
		[XmlAttribute("Uf")]
		[Bindable(true)]
		public string Uf 
		{
			get { return GetColumnValue<string>(Columns.Uf); }
			set { SetColumnValue(Columns.Uf, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varLogradouro,int? varNumero,string varBairro,string varCidade,string varCep,string varUf)
		{
			Endereco item = new Endereco();
			
			item.Logradouro = varLogradouro;
			
			item.Numero = varNumero;
			
			item.Bairro = varBairro;
			
			item.Cidade = varCidade;
			
			item.Cep = varCep;
			
			item.Uf = varUf;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varLogradouro,int? varNumero,string varBairro,string varCidade,string varCep,string varUf)
		{
			Endereco item = new Endereco();
			
				item.Id = varId;
			
				item.Logradouro = varLogradouro;
			
				item.Numero = varNumero;
			
				item.Bairro = varBairro;
			
				item.Cidade = varCidade;
			
				item.Cep = varCep;
			
				item.Uf = varUf;
			
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
        
        
        
        public static TableSchema.TableColumn LogradouroColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn BairroColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CidadeColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CepColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn UfColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Logradouro = @"logradouro";
			 public static string Numero = @"numero";
			 public static string Bairro = @"bairro";
			 public static string Cidade = @"cidade";
			 public static string Cep = @"cep";
			 public static string Uf = @"uf";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}

