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
public class Utilizador {
	public Utilizador() {
	}
	
	public static Utilizador LoadUtilizadorByORMID(string email) {
		PersistentSession session = BasedeDadosMMPersistentManager.Instance().GetSession();
		return LoadUtilizadorByORMID(session,email);
	}
	
	public static Utilizador LoadUtilizadorByORMID(PersistentSession session,string email) {
		return (Utilizador) session.Load(typeof(Utilizador), (String)email);
	}
	
	public static Utilizador[] ListUtilizadorByQuery(string condition, string orderBy) {
		PersistentSession session = BasedeDadosMMPersistentManager.Instance().GetSession();
		return ListUtilizadorByQuery(session, condition, orderBy);
	}
	
	public static Utilizador[] ListUtilizadorByQuery(PersistentSession session, string condition, string orderBy) {
		global::System.Text.StringBuilder sb = new global::System.Text.StringBuilder("From Utilizador as Utilizador");
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
			Utilizador[] result = new Utilizador[list.Count];
			list.CopyTo(result, 0);
			return result;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public static Utilizador LoadUtilizadorByQuery(string condition, string orderBy) {
		PersistentSession session = BasedeDadosMMPersistentManager.Instance().GetSession();
		return LoadUtilizadorByQuery(session, condition, orderBy);
	}
	
	public static Utilizador LoadUtilizadorByQuery(PersistentSession session, string condition, string orderBy) {
		Utilizador[] utilizadors = ListUtilizadorByQuery(session, condition, orderBy);
		if (utilizadors != null && utilizadors.Length > 0)
			return utilizadors[0];
		else
			return null;
	}
	
	public static global::System.Collections.IEnumerable IterateUtilizadorByQuery(string condition, string orderBy) {
		PersistentSession session = BasedeDadosMMPersistentManager.Instance().GetSession();
		return IterateUtilizadorByQuery(session, condition, orderBy);
	}
	
	public static global::System.Collections.IEnumerable IterateUtilizadorByQuery(PersistentSession session, string condition, string orderBy) {
		global::System.Text.StringBuilder sb = new global::System.Text.StringBuilder("From Utilizador as Utilizador");
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
	
	public static Utilizador LoadUtilizadorByCriteria(UtilizadorCriteria utilizadorCriteria) {
		Utilizador[] utilizadors = ListUtilizadorByCriteria(utilizadorCriteria);
		if(utilizadors == null || utilizadors.Length == 0) {
			return null;
		}
		return utilizadors[0];
	}
	
	public static Utilizador[] ListUtilizadorByCriteria(UtilizadorCriteria utilizadorCriteria) {
		return utilizadorCriteria.ListUtilizador();
	}
	
	public static Utilizador CreateUtilizador() {
		return new Utilizador();
	}
	
	public virtual bool Save() {
		try {
			BasedeDadosMMPersistentManager.Instance().SaveObject(this);
			return true;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public virtual bool Delete() {
		try {
			BasedeDadosMMPersistentManager.Instance().DeleteObject(this);
			return true;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public virtual bool Refresh() {
		try {
			BasedeDadosMMPersistentManager.Instance().GetSession().Refresh(this);
			return true;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public virtual bool DeleteAndDissociate() {
		try {
			if(Estabelecimento != null) {
				Estabelecimento.Utilizador = null;
			}
			if(Cliente != null) {
				Cliente.Utilizador = null;
			}
			return Delete();
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public virtual bool DeleteAndDissociate(global::Orm.PersistentSession session) {
		try {
			if(Estabelecimento != null) {
				Estabelecimento.Utilizador = null;
			}
			if(Cliente != null) {
				Cliente.Utilizador = null;
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
	
	private string __email;
	
	private string __password;
	
	private byte __tipo = 0;
	
	private Estabelecimento __estabelecimento;
	
	private Cliente __cliente;
	
	public virtual string Email {
		set {
			this.__email = value;			
		}
		get {
			return __email;			
		}
	}
	
	public virtual string ORMID {
		get {
			return Email;			
		}
	}
	
	public virtual string Password {
		set {
			this.__password = value;			
		}
		get {
			return __password;			
		}
	}
	
	public virtual byte Tipo {
		set {
			this.__tipo = value;			
		}
		get {
			return __tipo;			
		}
	}
	
	public virtual Estabelecimento Estabelecimento {
		set {
			if (this.__estabelecimento != value) {
				Estabelecimento l__estabelecimento = this.__estabelecimento;
				this.__estabelecimento = value;
				if (value != null) {
					__estabelecimento.Utilizador = this;
				}
				if (l__estabelecimento != null && l__estabelecimento.Utilizador == this) {
					l__estabelecimento.Utilizador = null;
				}
			}
		}
		get {
			return __estabelecimento;			
		}
	}
	
	public virtual Cliente Cliente {
		set {
			if (this.__cliente != value) {
				Cliente l__cliente = this.__cliente;
				this.__cliente = value;
				if (value != null) {
					__cliente.Utilizador = this;
				}
				if (l__cliente != null && l__cliente.Utilizador == this) {
					l__cliente.Utilizador = null;
				}
			}
		}
		get {
			return __cliente;			
		}
	}
	
	public override string ToString() {
		return Convert.ToString(Email);
	}
	
	private bool _saved = false;
	
	public virtual void onSave() {
		_saved=true;
	}
	
	
	public virtual void onLoad() {
		_saved=true;
	}
	
	
	public virtual bool isSaved() {
		return _saved;
	}
	
	
}
