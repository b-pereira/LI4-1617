/**
 * "Visual Paradigm: DO NOT MODIFY THIS FILE!"
 * 
 * This is an automatic generated file. It will be regenerated every time 
 * you generate persistence class.
 * 
 * Modifying its content may cause the program not work, or your work may lost.
 */

/**
 * Licensee: Universidade do Minho
 * License Type: Academic
 */
using System;
using Orm;
using System.Collections;
using NHibernate;

/// <summary>
/// ORM-Persistable Class
/// </summary>
[Serializable]
public class Cliente_critica_Iguaria {
	public Cliente_critica_Iguaria() {
		_OrmAdapter = new Cliente_critica_IguariaORMAdapter(this);
	}
	
	public static Cliente_critica_Iguaria LoadCliente_critica_IguariaByORMID(Cliente cliente, Iguaria iguaria) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return LoadCliente_critica_IguariaByORMID(session,cliente, iguaria);
	}
	
	public static Cliente_critica_Iguaria LoadCliente_critica_IguariaByORMID(PersistentSession session,Cliente cliente, Iguaria iguaria) {
		Cliente_critica_Iguaria cliente_critica_iguaria = new Cliente_critica_Iguaria();
		cliente_critica_iguaria.Cliente = cliente;
		cliente_critica_iguaria.Iguaria = iguaria;
		
		return (Cliente_critica_Iguaria) session.Load(typeof(Cliente_critica_Iguaria), cliente_critica_iguaria);
	}
	
	public static Cliente_critica_Iguaria[] ListCliente_critica_IguariaByQuery(string condition, string orderBy) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return ListCliente_critica_IguariaByQuery(session, condition, orderBy);
	}
	
	public static Cliente_critica_Iguaria[] ListCliente_critica_IguariaByQuery(PersistentSession session, string condition, string orderBy) {
		global::System.Text.StringBuilder sb = new global::System.Text.StringBuilder("From Cliente_critica_Iguaria as Cliente_critica_Iguaria");
		if (condition != null) {
			sb.Append(" Where ");
			sb.Append(condition);
		}
		if (orderBy != null) {
			sb.Append(" Order By ");
			sb.Append(orderBy);
		}
		IQuery query = session.CreateQuery(sb.ToString());
		try {
			IList list = query.List();
			Cliente_critica_Iguaria[] result = new Cliente_critica_Iguaria[list.Count];
			list.CopyTo(result, 0);
			return result;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public static Cliente_critica_Iguaria LoadCliente_critica_IguariaByQuery(string condition, string orderBy) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return LoadCliente_critica_IguariaByQuery(session, condition, orderBy);
	}
	
	public static Cliente_critica_Iguaria LoadCliente_critica_IguariaByQuery(PersistentSession session, string condition, string orderBy) {
		Cliente_critica_Iguaria[] cliente_critica_Iguarias = ListCliente_critica_IguariaByQuery(session, condition, orderBy);
		if (cliente_critica_Iguarias != null && cliente_critica_Iguarias.Length > 0)
			return cliente_critica_Iguarias[0];
		else
			return null;
	}
	
	public static global::System.Collections.IEnumerable IterateCliente_critica_IguariaByQuery(string condition, string orderBy) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return IterateCliente_critica_IguariaByQuery(session, condition, orderBy);
	}
	
	public static global::System.Collections.IEnumerable IterateCliente_critica_IguariaByQuery(PersistentSession session, string condition, string orderBy) {
		global::System.Text.StringBuilder sb = new global::System.Text.StringBuilder("From Cliente_critica_Iguaria as Cliente_critica_Iguaria");
		if (condition != null) {
			sb.Append(" Where ");
			sb.Append(condition);
		}
		if (orderBy != null) {
			sb.Append(" Order By ");
			sb.Append(orderBy);
		}
		IQuery query = session.CreateQuery(sb.ToString());
		try {
			return query.Enumerable();
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public static Cliente_critica_Iguaria LoadCliente_critica_IguariaByCriteria(Cliente_critica_IguariaCriteria cliente_critica_IguariaCriteria) {
		Cliente_critica_Iguaria[] cliente_critica_Iguarias = ListCliente_critica_IguariaByCriteria(cliente_critica_IguariaCriteria);
		if(cliente_critica_Iguarias == null || cliente_critica_Iguarias.Length == 0) {
			return null;
		}
		return cliente_critica_Iguarias[0];
	}
	
	public static Cliente_critica_Iguaria[] ListCliente_critica_IguariaByCriteria(Cliente_critica_IguariaCriteria cliente_critica_IguariaCriteria) {
		return cliente_critica_IguariaCriteria.ListCliente_critica_Iguaria();
	}
	
	public override bool Equals(object obj) {
		if (obj == this)
			return true;
		if (!(obj is Cliente_critica_Iguaria))
			return false;
		Cliente_critica_Iguaria cliente_critica_iguaria = obj as Cliente_critica_Iguaria;
		if (Cliente == null && cliente_critica_iguaria.Cliente != null)
			return false;
		if (!Cliente.Equals(cliente_critica_iguaria.Cliente))
			return false;
		if (Iguaria == null && cliente_critica_iguaria.Iguaria != null)
			return false;
		if (!Iguaria.Id_iguaria.Equals(cliente_critica_iguaria.Iguaria.Id_iguaria))
			return false;
		if (!Iguaria.Estabelecimento.Equals(cliente_critica_iguaria.Iguaria.Estabelecimento))
			return false;
		return true;
	}
	
	public override int GetHashCode() {
		int hashcode = 0;
		if (Cliente != null) {
			hashcode = hashcode + (int) Cliente.ORMID;
		}
		if (Iguaria != null) {
			hashcode = hashcode + (int) Iguaria.Id_iguaria;
			hashcode = hashcode + (Iguaria.Estabelecimento == null ? 0 : Iguaria.Estabelecimento.GetHashCode());
		}
		return hashcode;
	}
	
	public static Cliente_critica_Iguaria CreateCliente_critica_Iguaria() {
		return new Cliente_critica_Iguaria();
	}
	
	public bool Save() {
		try {
			global::orm.BasedeDadosMMPersistentManager.Instance().SaveObject(this);
			return true;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public bool Delete() {
		try {
			global::orm.BasedeDadosMMPersistentManager.Instance().DeleteObject(this);
			return true;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public bool Refresh() {
		try {
			global::orm.BasedeDadosMMPersistentManager.Instance().GetSession().Refresh(this);
			return true;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public bool DeleteAndDissociate() {
		try {
			Cliente cliente = this.Cliente;
			if(Cliente != null) {
				Cliente.cliente_critica_Iguaria.Remove(this);
			}
			this.ORM_Cliente = cliente;
			Iguaria iguaria = this.Iguaria;
			if(Iguaria != null) {
				Iguaria.cliente_critica_Iguaria.Remove(this);
			}
			this.ORM_Iguaria = iguaria;
			return Delete();
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public bool DeleteAndDissociate(global::Orm.PersistentSession session) {
		try {
			Cliente cliente = this.Cliente;
			if(Cliente != null) {
				Cliente.cliente_critica_Iguaria.Remove(this);
			}
			this.ORM_Cliente = cliente;
			Iguaria iguaria = this.Iguaria;
			if(Iguaria != null) {
				Iguaria.cliente_critica_Iguaria.Remove(this);
			}
			this.ORM_Iguaria = iguaria;
			try {
				session.Delete(this);
				return true;
			}
			catch (Exception) {
				return false;
			}
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	private void This_SetOwner(object owner, int key) {
		if (key == orm.ORMConstants.KEY_CLIENTE_CRITICA_IGUARIA_CLIENTE) {
			this.__cliente = (Cliente) owner;
		}
		
		else if (key == orm.ORMConstants.KEY_CLIENTE_CRITICA_IGUARIA_IGUARIA) {
			this.__iguaria = (Iguaria) owner;
		}
	}
	
	private class Cliente_critica_IguariaORMAdapter : Orm.Util.AbstractORMAdapter {
		private readonly Cliente_critica_Iguaria __Cliente_critica_Iguaria;
		
		internal Cliente_critica_IguariaORMAdapter(Cliente_critica_Iguaria value) {
			__Cliente_critica_Iguaria = value;
		}
		
		public override void SetOwner(object owner, int key) {
			__Cliente_critica_Iguaria.This_SetOwner(owner, key);
		}
		
	}
	
	internal Orm.Util.ORMAdapter _OrmAdapter;
	
	private Cliente __cliente;
	
	private int __clienteId;
	
	public int ClienteId {
		set {
			this.__clienteId = value;			
		}
		get {
			return __clienteId;			
		}
	}
	
	private Iguaria __iguaria;
	
	private string __desc_critica;
	
	private DateTime __data_critica;
	
	private float __rating_igu = 0f;
	
	public string Desc_critica {
		set {
			this.__desc_critica = value;			
		}
		get {
			return __desc_critica;			
		}
	}
	
	public DateTime Data_critica {
		set {
			this.__data_critica = value;			
		}
		get {
			return __data_critica;			
		}
	}
	
	public float Rating_igu {
		set {
			this.__rating_igu = value;			
		}
		get {
			return __rating_igu;			
		}
	}
	
	public Cliente Cliente {
		set {
			if(__cliente!= null) {
				__cliente.cliente_critica_Iguaria.Remove(this);
			}
			
			if(value != null) {
				value.cliente_critica_Iguaria.Add(this);
			}
		}
		get {
			return __cliente;			
		}
	}
	
	private Cliente ORM_Cliente {
		set {
			this.__cliente = value;			
		}
		
		get {
			return __cliente;			
		}
	}
	
	public Iguaria Iguaria {
		set {
			if(__iguaria!= null) {
				__iguaria.cliente_critica_Iguaria.Remove(this);
			}
			
			if(value != null) {
				value.cliente_critica_Iguaria.Add(this);
			}
		}
		get {
			return __iguaria;			
		}
	}
	
	private Iguaria ORM_Iguaria {
		set {
			this.__iguaria = value;			
		}
		
		get {
			return __iguaria;			
		}
	}
	
	public override string ToString() {
		return ((Cliente == null) ? "" : Convert.ToString(Cliente.ORMID)) + " "+ ((Iguaria == null) ? "" : Convert.ToString(Iguaria.Id_iguaria) + " " + Convert.ToString(Iguaria.Estabelecimento));
	}
	
	private bool _saved = false;
	
	public void onSave() {
		_saved=true;
	}
	
	
	public void onLoad() {
		_saved=true;
	}
	
	
	public bool isSaved() {
		return _saved;
	}
	
	
}
