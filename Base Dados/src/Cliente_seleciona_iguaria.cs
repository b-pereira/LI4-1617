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
public class Cliente_seleciona_iguaria {
	public Cliente_seleciona_iguaria() {
		_OrmAdapter = new Cliente_seleciona_iguariaORMAdapter(this);
		selecaoIguaria = new SelecaoIguariaSetCollection<Cliente_seleciona_iguaria>(this, _OrmAdapter, orm.ORMConstants.KEY_CLIENTE_SELECIONA_IGUARIA_SELECAOIGUARIA, orm.ORMConstants.KEY_SELECAOIGUARIA_CLIENTE, orm.ORMConstants.KEY_MUL_ONE_TO_MANY);
	}
	
	public static Cliente_seleciona_iguaria LoadCliente_seleciona_iguariaByORMID(Cliente cliente, Iguaria iguaria) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return LoadCliente_seleciona_iguariaByORMID(session,cliente, iguaria);
	}
	
	public static Cliente_seleciona_iguaria LoadCliente_seleciona_iguariaByORMID(PersistentSession session,Cliente cliente, Iguaria iguaria) {
		Cliente_seleciona_iguaria cliente_seleciona_iguaria = new Cliente_seleciona_iguaria();
		cliente_seleciona_iguaria.Cliente = cliente;
		cliente_seleciona_iguaria.Iguaria = iguaria;
		
		return (Cliente_seleciona_iguaria) session.Load(typeof(Cliente_seleciona_iguaria), cliente_seleciona_iguaria);
	}
	
	public static Cliente_seleciona_iguaria[] ListCliente_seleciona_iguariaByQuery(string condition, string orderBy) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return ListCliente_seleciona_iguariaByQuery(session, condition, orderBy);
	}
	
	public static Cliente_seleciona_iguaria[] ListCliente_seleciona_iguariaByQuery(PersistentSession session, string condition, string orderBy) {
		global::System.Text.StringBuilder sb = new global::System.Text.StringBuilder("From Cliente_seleciona_iguaria as Cliente_seleciona_iguaria");
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
			Cliente_seleciona_iguaria[] result = new Cliente_seleciona_iguaria[list.Count];
			list.CopyTo(result, 0);
			return result;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public static Cliente_seleciona_iguaria LoadCliente_seleciona_iguariaByQuery(string condition, string orderBy) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return LoadCliente_seleciona_iguariaByQuery(session, condition, orderBy);
	}
	
	public static Cliente_seleciona_iguaria LoadCliente_seleciona_iguariaByQuery(PersistentSession session, string condition, string orderBy) {
		Cliente_seleciona_iguaria[] cliente_seleciona_iguarias = ListCliente_seleciona_iguariaByQuery(session, condition, orderBy);
		if (cliente_seleciona_iguarias != null && cliente_seleciona_iguarias.Length > 0)
			return cliente_seleciona_iguarias[0];
		else
			return null;
	}
	
	public static global::System.Collections.IEnumerable IterateCliente_seleciona_iguariaByQuery(string condition, string orderBy) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return IterateCliente_seleciona_iguariaByQuery(session, condition, orderBy);
	}
	
	public static global::System.Collections.IEnumerable IterateCliente_seleciona_iguariaByQuery(PersistentSession session, string condition, string orderBy) {
		global::System.Text.StringBuilder sb = new global::System.Text.StringBuilder("From Cliente_seleciona_iguaria as Cliente_seleciona_iguaria");
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
	
	public static Cliente_seleciona_iguaria LoadCliente_seleciona_iguariaByCriteria(Cliente_seleciona_iguariaCriteria cliente_seleciona_iguariaCriteria) {
		Cliente_seleciona_iguaria[] cliente_seleciona_iguarias = ListCliente_seleciona_iguariaByCriteria(cliente_seleciona_iguariaCriteria);
		if(cliente_seleciona_iguarias == null || cliente_seleciona_iguarias.Length == 0) {
			return null;
		}
		return cliente_seleciona_iguarias[0];
	}
	
	public static Cliente_seleciona_iguaria[] ListCliente_seleciona_iguariaByCriteria(Cliente_seleciona_iguariaCriteria cliente_seleciona_iguariaCriteria) {
		return cliente_seleciona_iguariaCriteria.ListCliente_seleciona_iguaria();
	}
	
	public override bool Equals(object obj) {
		if (obj == this)
			return true;
		if (!(obj is Cliente_seleciona_iguaria))
			return false;
		Cliente_seleciona_iguaria cliente_seleciona_iguaria = obj as Cliente_seleciona_iguaria;
		if (Cliente == null && cliente_seleciona_iguaria.Cliente != null)
			return false;
		if (!Cliente.Equals(cliente_seleciona_iguaria.Cliente))
			return false;
		if (Iguaria == null && cliente_seleciona_iguaria.Iguaria != null)
			return false;
		if (!Iguaria.Id_iguaria.Equals(cliente_seleciona_iguaria.Iguaria.Id_iguaria))
			return false;
		if (!Iguaria.Estabelecimento.Equals(cliente_seleciona_iguaria.Iguaria.Estabelecimento))
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
	
	public static Cliente_seleciona_iguaria CreateCliente_seleciona_iguaria() {
		return new Cliente_seleciona_iguaria();
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
				Cliente.cliente_seleciona_iguaria.Remove(this);
			}
			this.ORM_Cliente = cliente;
			Iguaria iguaria = this.Iguaria;
			if(Iguaria != null) {
				Iguaria.cliente_seleciona_iguaria.Remove(this);
			}
			this.ORM_Iguaria = iguaria;
			SelecaoIguaria[] lSelecaoIguarias = selecaoIguaria.ToArray();
			foreach(SelecaoIguaria lSelecaoIguaria in lSelecaoIguarias) {
				lSelecaoIguaria.Cliente = null;
			}
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
				Cliente.cliente_seleciona_iguaria.Remove(this);
			}
			this.ORM_Cliente = cliente;
			Iguaria iguaria = this.Iguaria;
			if(Iguaria != null) {
				Iguaria.cliente_seleciona_iguaria.Remove(this);
			}
			this.ORM_Iguaria = iguaria;
			SelecaoIguaria[] lSelecaoIguarias = selecaoIguaria.ToArray();
			foreach(SelecaoIguaria lSelecaoIguaria in lSelecaoIguarias) {
				lSelecaoIguaria.Cliente = null;
			}
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
	
	private System.Collections.Generic.ISet<T> This_GetSet<T>(int key) {
		if (key == orm.ORMConstants.KEY_CLIENTE_SELECIONA_IGUARIA_SELECAOIGUARIA)
			return (System.Collections.Generic.ISet<T>) __selecaoIguaria;
		return null;
	}
	
	private void This_SetOwner(object owner, int key) {
		if (key == orm.ORMConstants.KEY_CLIENTE_SELECIONA_IGUARIA_CLIENTE) {
			this.__cliente = (Cliente) owner;
		}
		
		else if (key == orm.ORMConstants.KEY_CLIENTE_SELECIONA_IGUARIA_IGUARIA) {
			this.__iguaria = (Iguaria) owner;
		}
	}
	
	private class Cliente_seleciona_iguariaORMAdapter : Orm.Util.AbstractORMAdapter {
		private readonly Cliente_seleciona_iguaria __Cliente_seleciona_iguaria;
		
		internal Cliente_seleciona_iguariaORMAdapter(Cliente_seleciona_iguaria value) {
			__Cliente_seleciona_iguaria = value;
		}
		
		public override System.Collections.Generic.ISet<T> GetSet<T>(int key) {
			return __Cliente_seleciona_iguaria.This_GetSet<T>(key);
		}
		
		public override void SetOwner(object owner, int key) {
			__Cliente_seleciona_iguaria.This_SetOwner(owner, key);
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
	
	private System.Collections.Generic.ISet<SelecaoIguaria> __selecaoIguaria = new System.Collections.Generic.HashSet<SelecaoIguaria>();
	
	public Cliente Cliente {
		set {
			if(__cliente!= null) {
				__cliente.cliente_seleciona_iguaria.Remove(this);
			}
			
			if(value != null) {
				value.cliente_seleciona_iguaria.Add(this);
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
				__iguaria.cliente_seleciona_iguaria.Remove(this);
			}
			
			if(value != null) {
				value.cliente_seleciona_iguaria.Add(this);
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
	
	private System.Collections.Generic.ISet<SelecaoIguaria> ORM_SelecaoIguaria {
		get  {
			return __selecaoIguaria;			
		}
		
		set {
			__selecaoIguaria = value;			
		}
	}
	
	public readonly SelecaoIguariaSetCollection<Cliente_seleciona_iguaria> selecaoIguaria;
	
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
