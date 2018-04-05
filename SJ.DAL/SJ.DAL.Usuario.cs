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
	/// Strongly-typed collection for the Usuario class.
	/// </summary>
    [Serializable]
	public partial class UsuarioCollection : ActiveList<Usuario, UsuarioCollection>
	{	   
		public UsuarioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>UsuarioCollection</returns>
		public UsuarioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Usuario o = this[i];
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
	/// This is an ActiveRecord class which wraps the usuarios table.
	/// </summary>
	[Serializable]
	public partial class Usuario : ActiveRecord<Usuario>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Usuario()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Usuario(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Usuario(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Usuario(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("usuarios", TableType.Table, DataService.GetInstance("SJ.DAL"));
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
				colvarNome.MaxLength = 100;
				colvarNome.AutoIncrement = false;
				colvarNome.IsNullable = true;
				colvarNome.IsPrimaryKey = false;
				colvarNome.IsForeignKey = false;
				colvarNome.IsReadOnly = false;
				colvarNome.DefaultSetting = @"";
				colvarNome.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNome);
				
				TableSchema.TableColumn colvarLogin = new TableSchema.TableColumn(schema);
				colvarLogin.ColumnName = "login";
				colvarLogin.DataType = DbType.String;
				colvarLogin.MaxLength = 50;
				colvarLogin.AutoIncrement = false;
				colvarLogin.IsNullable = true;
				colvarLogin.IsPrimaryKey = false;
				colvarLogin.IsForeignKey = false;
				colvarLogin.IsReadOnly = false;
				colvarLogin.DefaultSetting = @"";
				colvarLogin.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLogin);
				
				TableSchema.TableColumn colvarSenha = new TableSchema.TableColumn(schema);
				colvarSenha.ColumnName = "senha";
				colvarSenha.DataType = DbType.String;
				colvarSenha.MaxLength = 150;
				colvarSenha.AutoIncrement = false;
				colvarSenha.IsNullable = true;
				colvarSenha.IsPrimaryKey = false;
				colvarSenha.IsForeignKey = false;
				colvarSenha.IsReadOnly = false;
				colvarSenha.DefaultSetting = @"";
				colvarSenha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSenha);
				
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
				DataService.Providers["SJ.DAL"].AddSchema("usuarios",schema);
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
		  
		[XmlAttribute("Login")]
		[Bindable(true)]
		public string Login 
		{
			get { return GetColumnValue<string>(Columns.Login); }
			set { SetColumnValue(Columns.Login, value); }
		}
		  
		[XmlAttribute("Senha")]
		[Bindable(true)]
		public string Senha 
		{
			get { return GetColumnValue<string>(Columns.Senha); }
			set { SetColumnValue(Columns.Senha, value); }
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
		public static void Insert(string varNome,string varLogin,string varSenha,bool? varAtivo)
		{
			Usuario item = new Usuario();
			
			item.Nome = varNome;
			
			item.Login = varLogin;
			
			item.Senha = varSenha;
			
			item.Ativo = varAtivo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varNome,string varLogin,string varSenha,bool? varAtivo)
		{
			Usuario item = new Usuario();
			
				item.Id = varId;
			
				item.Nome = varNome;
			
				item.Login = varLogin;
			
				item.Senha = varSenha;
			
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
        
        
        
        public static TableSchema.TableColumn LoginColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SenhaColumn
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
			 public static string Login = @"login";
			 public static string Senha = @"senha";
			 public static string Ativo = @"ativo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}

