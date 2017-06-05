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
public class SelecaoIguaria {
	public SelecaoIguaria() {
		_OrmAdapter = new SelecaoIguariaORMAdapter(this);
	}
	
	public static SelecaoIguaria LoadSelecaoIguariaByORMID(int id_visualizacao, Cliente_seleciona_iguaria cliente) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return LoadSelecaoIguariaByORMID(session,id_visualizacao, cliente);
	}
	
	public static SelecaoIguaria LoadSelecaoIguariaByORMID(PersistentSession session,int id_visualizacao, Cliente_seleciona_iguaria cliente) {
		SelecaoIguaria selecaoiguaria = new SelecaoIguaria();
		selecaoiguaria.Id_visualizacao = id_visualizacao;
		selecaoiguaria.Cliente = cliente;
		
		return (SelecaoIguaria) session.Load(typeof(SelecaoIguaria), selecaoiguaria);
	}
	
	public static SelecaoIguaria[] ListSelecaoIguariaByQuery(string condition, string orderBy) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return ListSelecaoIguariaByQuery(session, condition, orderBy);
	}
	
	public static SelecaoIguaria[] ListSelecaoIguariaByQuery(PersistentSession session, string condition, string orderBy) {
		global::System.Text.StringBuilder sb = new global::System.Text.StringBuilder("From SelecaoIguaria as SelecaoIguaria");
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
			SelecaoIguaria[] result = new SelecaoIguaria[list.Count];
			list.CopyTo(result, 0);
			return result;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public static SelecaoIguaria LoadSelecaoIguariaByQuery(string condition, string orderBy) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return LoadSelecaoIguariaByQuery(session, condition, orderBy);
	}
	
	public static SelecaoIguaria LoadSelecaoIguariaByQuery(PersistentSession session, string condition, string orderBy) {
		SelecaoIguaria[] selecaoIguarias = ListSelecaoIguariaByQuery(session, condition, orderBy);
		if (selecaoIguarias != null && selecaoIguarias.Length > 0)
			return selecaoIguarias[0];
		else
			return null;
	}
	
	public static global::System.Collections.IEnumerable IterateSelecaoIguariaByQuery(string condition, string orderBy) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return IterateSelecaoIguariaByQuery(session, condition, orderBy);
	}
	
	public static global::System.Collections.IEnumerable IterateSelecaoIguariaByQuery(PersistentSession session, string condition, string orderBy) {
		global::System.Text.StringBuilder sb = new global::System.Text.StringBuilder("From SelecaoIguaria as SelecaoIguaria");
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
	
	public static SelecaoIguaria LoadSelecaoIguariaByCriteria(SelecaoIguariaCriteria selecaoIguariaCriteria) {
		SelecaoIguaria[] selecaoIguarias = ListSelecaoIguariaByCriteria(selecaoIguariaCriteria);
		if(selecaoIguarias == null || selecaoIguarias.Length == 0) {
			return null;
		}
		return selecaoIguarias[0];
	}
	
	public static SelecaoIguaria[] ListSelecaoIguariaByCriteria(SelecaoIguariaCriteria selecaoIguariaCriteria) {
		return selecaoIguariaCriteria.ListSelecaoIguaria();
	}
	
	public override bool Equals(object obj) {
		if (obj == this)
			return true;
		if (!(obj is SelecaoIguaria))
			return false;
		SelecaoIguaria selecaoiguaria = obj as SelecaoIguaria;
		if (Id_visualizacao != selecaoiguaria.Id_visualizacao)
			return false;
		if (Cliente == null && selecaoiguaria.Cliente != null)
			return false;
		if (!Cliente.Cliente.Equals(selecaoiguaria.Cliente.Cliente))
			return false;
		if (!Cliente.Iguaria.Equals(selecaoiguaria.Cliente.Iguaria))
			return false;
		return true;
	}
	
	public override int GetHashCode() {
		int hashcode = 0;
		hashcode = hashcode + (int) Id_visualizacao;
		if (Cliente != null) {
			hashcode = hashcode + (Cliente.Cliente == null ? 0 : Cliente.Cliente.GetHashCode());
			hashcode = hashcode + (Cliente.Iguaria == null ? 0 : Cliente.Iguaria.GetHashCode());
		}
		return hashcode;
	}
	
	public static SelecaoIguaria CreateSelecaoIguaria() {
		return new SelecaoIguaria();
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
			Cliente_seleciona_iguaria cliente = this.Cliente;
			if(Cliente != null) {
				Cliente.selecaoIguaria.Remove(this);
			}
			this.ORM_Cliente = cliente;
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
			Cliente_seleciona_iguaria cliente = this.Cliente;
			if(Cliente != null) {
				Cliente.selecaoIguaria.Remove(this);
			}
			this.ORM_Cliente = cliente;
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
		if (key == orm.ORMConstants.KEY_SELECAOIGUARIA_CLIENTE) {
			this.__cliente = (Cliente_seleciona_iguaria) owner;
		}
	}
	
	private class SelecaoIguariaORMAdapter : Orm.Util.AbstractORMAdapter {
		private readonly SelecaoIguaria __SelecaoIguaria;
		
		internal SelecaoIguariaORMAdapter(SelecaoIguaria value) {
			__SelecaoIguaria = value;
		}
		
		public override void SetOwner(object owner, int key) {
			__SelecaoIguaria.This_SetOwner(owner, key);
		}
		
	}
	
	internal Orm.Util.ORMAdapter _OrmAdapter;
	
	private int __id_visualizacao;
	
	private Cliente_seleciona_iguaria __cliente;
	
	private DateTime __data_hora_visualizacao;
	
	public int Id_visualizacao {
		set {
			this.__id_visualizacao = value;			
		}
		get {
			return __id_visualizacao;			
		}
	}
	
	public DateTime Data_hora_visualizacao {
		set {
			this.__data_hora_visualizacao = value;			
		}
		get {
			return __data_hora_visualizacao;			
		}
	}
	
	public Cliente_seleciona_iguaria Cliente {
		set {
			if(__cliente!= null) {
				__cliente.selecaoIguaria.Remove(this);
			}
			
			if(value != null) {
				value.selecaoIguaria.Add(this);
			}
		}
		get {
			return __cliente;			
		}
	}
	
	private Cliente_seleciona_iguaria ORM_Cliente {
		set {
			this.__cliente = value;			
		}
		
		get {
			return __cliente;			
		}
	}
	
	public override string ToString() {
		return Convert.ToString(Id_visualizacao) + " "+ ((Cliente == null) ? "" : Convert.ToString(Cliente.Cliente) + " " + Convert.ToString(Cliente.Iguaria));
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
