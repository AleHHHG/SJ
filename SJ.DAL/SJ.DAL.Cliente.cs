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
	/// Strongly-typed collection for the Cliente class.
	/// </summary>
    [Serializable]
	public partial class ClienteCollection : ActiveList<Cliente, ClienteCollection>
	{	   
		public ClienteCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ClienteCollection</returns>
		public ClienteCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Cliente o = this[i];
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
	/// This is an ActiveRecord class which wraps the clientes table.
	/// </summary>
	[Serializable]
	public partial class Cliente : ActiveRecord<Cliente>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Cliente()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Cliente(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Cliente(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Cliente(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("clientes", TableType.Table, DataService.GetInstance("SJ.DAL"));
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
				
				TableSchema.TableColumn colvarTelefone = new TableSchema.TableColumn(schema);
				colvarTelefone.ColumnName = "telefone";
				colvarTelefone.DataType = DbType.String;
				colvarTelefone.MaxLength = 20;
				colvarTelefone.AutoIncrement = false;
				colvarTelefone.IsNullable = true;
				colvarTelefone.IsPrimaryKey = false;
				colvarTelefone.IsForeignKey = false;
				colvarTelefone.IsReadOnly = false;
				colvarTelefone.DefaultSetting = @"";
				colvarTelefone.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTelefone);
				
				TableSchema.TableColumn colvarCelular = new TableSchema.TableColumn(schema);
				colvarCelular.ColumnName = "celular";
				colvarCelular.DataType = DbType.String;
				colvarCelular.MaxLength = 20;
				colvarCelular.AutoIncrement = false;
				colvarCelular.IsNullable = true;
				colvarCelular.IsPrimaryKey = false;
				colvarCelular.IsForeignKey = false;
				colvarCelular.IsReadOnly = false;
				colvarCelular.DefaultSetting = @"";
				colvarCelular.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCelular);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SJ.DAL"].AddSchema("clientes",schema);
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
		  
		[XmlAttribute("Telefone")]
		[Bindable(true)]
		public string Telefone 
		{
			get { return GetColumnValue<string>(Columns.Telefone); }
			set { SetColumnValue(Columns.Telefone, value); }
		}
		  
		[XmlAttribute("Celular")]
		[Bindable(true)]
		public string Celular 
		{
			get { return GetColumnValue<string>(Columns.Celular); }
			set { SetColumnValue(Columns.Celular, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNome,string varTelefone,string varCelular)
		{
			Cliente item = new Cliente();
			
			item.Nome = varNome;
			
			item.Telefone = varTelefone;
			
			item.Celular = varCelular;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varNome,string varTelefone,string varCelular)
		{
			Cliente item = new Cliente();
			
				item.Id = varId;
			
				item.Nome = varNome;
			
				item.Telefone = varTelefone;
			
				item.Celular = varCelular;
			
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
        
        
        
        public static TableSchema.TableColumn TelefoneColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CelularColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Nome = @"nome";
			 public static string Telefone = @"telefone";
			 public static string Celular = @"celular";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}

