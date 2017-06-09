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
public class SelecaoEstabelecimento {
	public SelecaoEstabelecimento() {
		_OrmAdapter = new SelecaoEstabelecimentoORMAdapter(this);
	}
	
	public static SelecaoEstabelecimento LoadSelecaoEstabelecimentoByORMID(int id_avaliacao, Cliente_seleciona_Estabelecimento estabelecimento) {
		PersistentSession session = BasedeDadosMMPersistentManager.Instance().GetSession();
		return LoadSelecaoEstabelecimentoByORMID(session,id_avaliacao, estabelecimento);
	}
	
	public static SelecaoEstabelecimento LoadSelecaoEstabelecimentoByORMID(PersistentSession session,int id_avaliacao, Cliente_seleciona_Estabelecimento estabelecimento) {
		SelecaoEstabelecimento selecaoestabelecimento = new SelecaoEstabelecimento();
		selecaoestabelecimento.Id_avaliacao = id_avaliacao;
		selecaoestabelecimento.Estabelecimento = estabelecimento;
		
		return (SelecaoEstabelecimento) session.Load(typeof(SelecaoEstabelecimento), selecaoestabelecimento);
	}
	
	public static SelecaoEstabelecimento[] ListSelecaoEstabelecimentoByQuery(string condition, string orderBy) {
		PersistentSession session = BasedeDadosMMPersistentManager.Instance().GetSession();
		return ListSelecaoEstabelecimentoByQuery(session, condition, orderBy);
	}
	
	public static SelecaoEstabelecimento[] ListSelecaoEstabelecimentoByQuery(PersistentSession session, string condition, string orderBy) {
		global::System.Text.StringBuilder sb = new global::System.Text.StringBuilder("From SelecaoEstabelecimento as SelecaoEstabelecimento");
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
			SelecaoEstabelecimento[] result = new SelecaoEstabelecimento[list.Count];
			list.CopyTo(result, 0);
			return result;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public static SelecaoEstabelecimento LoadSelecaoEstabelecimentoByQuery(string condition, string orderBy) {
		PersistentSession session = BasedeDadosMMPersistentManager.Instance().GetSession();
		return LoadSelecaoEstabelecimentoByQuery(session, condition, orderBy);
	}
	
	public static SelecaoEstabelecimento LoadSelecaoEstabelecimentoByQuery(PersistentSession session, string condition, string orderBy) {
		SelecaoEstabelecimento[] selecaoEstabelecimentos = ListSelecaoEstabelecimentoByQuery(session, condition, orderBy);
		if (selecaoEstabelecimentos != null && selecaoEstabelecimentos.Length > 0)
			return selecaoEstabelecimentos[0];
		else
			return null;
	}
	
	public static global::System.Collections.IEnumerable IterateSelecaoEstabelecimentoByQuery(string condition, string orderBy) {
		PersistentSession session = BasedeDadosMMPersistentManager.Instance().GetSession();
		return IterateSelecaoEstabelecimentoByQuery(session, condition, orderBy);
	}
	
	public static global::System.Collections.IEnumerable IterateSelecaoEstabelecimentoByQuery(PersistentSession session, string condition, string orderBy) {
		global::System.Text.StringBuilder sb = new global::System.Text.StringBuilder("From SelecaoEstabelecimento as SelecaoEstabelecimento");
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
	
	public static SelecaoEstabelecimento LoadSelecaoEstabelecimentoByCriteria(SelecaoEstabelecimentoCriteria selecaoEstabelecimentoCriteria) {
		SelecaoEstabelecimento[] selecaoEstabelecimentos = ListSelecaoEstabelecimentoByCriteria(selecaoEstabelecimentoCriteria);
		if(selecaoEstabelecimentos == null || selecaoEstabelecimentos.Length == 0) {
			return null;
		}
		return selecaoEstabelecimentos[0];
	}
	
	public static SelecaoEstabelecimento[] ListSelecaoEstabelecimentoByCriteria(SelecaoEstabelecimentoCriteria selecaoEstabelecimentoCriteria) {
		return selecaoEstabelecimentoCriteria.ListSelecaoEstabelecimento();
	}
	
	public override bool Equals(object obj) {
		if (obj == this)
			return true;
		if (!(obj is SelecaoEstabelecimento))
			return false;
		SelecaoEstabelecimento selecaoestabelecimento = obj as SelecaoEstabelecimento;
		if (Id_avaliacao != selecaoestabelecimento.Id_avaliacao)
			return false;
		if (Estabelecimento == null && selecaoestabelecimento.Estabelecimento != null)
			return false;
		if (!Estabelecimento.Estabelecimento.Equals(selecaoestabelecimento.Estabelecimento.Estabelecimento))
			return false;
		if (!Estabelecimento.Cliente.Equals(selecaoestabelecimento.Estabelecimento.Cliente))
			return false;
		return true;
	}
	
	public override int GetHashCode() {
		int hashcode = 0;
		hashcode = hashcode + (int) Id_avaliacao;
		if (Estabelecimento != null) {
			hashcode = hashcode + (Estabelecimento.Estabelecimento == null ? 0 : Estabelecimento.Estabelecimento.GetHashCode());
			hashcode = hashcode + (Estabelecimento.Cliente == null ? 0 : Estabelecimento.Cliente.GetHashCode());
		}
		return hashcode;
	}
	
	public static SelecaoEstabelecimento CreateSelecaoEstabelecimento() {
		return new SelecaoEstabelecimento();
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
			Cliente_seleciona_Estabelecimento estabelecimento = this.Estabelecimento;
			if(Estabelecimento != null) {
				Estabelecimento.selecaoEstabelecimento.Remove(this);
			}
			this.ORM_Estabelecimento = estabelecimento;
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
			Cliente_seleciona_Estabelecimento estabelecimento = this.Estabelecimento;
			if(Estabelecimento != null) {
				Estabelecimento.selecaoEstabelecimento.Remove(this);
			}
			this.ORM_Estabelecimento = estabelecimento;
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
		if (key == ORMConstants.KEY_SELECAOESTABELECIMENTO_ESTABELECIMENTO) {
			this.__estabelecimento = (Cliente_seleciona_Estabelecimento) owner;
		}
	}
	
	private class SelecaoEstabelecimentoORMAdapter : Orm.Util.AbstractORMAdapter {
		private readonly SelecaoEstabelecimento __SelecaoEstabelecimento;
		
		internal SelecaoEstabelecimentoORMAdapter(SelecaoEstabelecimento value) {
			__SelecaoEstabelecimento = value;
		}
		
		public override void SetOwner(object owner, int key) {
			__SelecaoEstabelecimento.This_SetOwner(owner, key);
		}
		
	}
	
	internal Orm.Util.ORMAdapter _OrmAdapter;
	
	private int __id_avaliacao;
	
	private Cliente_seleciona_Estabelecimento __estabelecimento;
	
	private DateTime __data_hora_selecao;
	
	public virtual int Id_avaliacao {
		set {
			this.__id_avaliacao = value;			
		}
		get {
			return __id_avaliacao;			
		}
	}
	
	public virtual DateTime Data_hora_selecao {
		set {
			this.__data_hora_selecao = value;			
		}
		get {
			return __data_hora_selecao;			
		}
	}
	
	public virtual Cliente_seleciona_Estabelecimento Estabelecimento {
		set {
			if(__estabelecimento!= null) {
				__estabelecimento.selecaoEstabelecimento.Remove(this);
			}
			
			if(value != null) {
				value.selecaoEstabelecimento.Add(this);
			}
		}
		get {
			return __estabelecimento;			
		}
	}
	
	public virtual Cliente_seleciona_Estabelecimento ORM_Estabelecimento {
		set {
			this.__estabelecimento = value;			
		}
		
		get {
			return __estabelecimento;			
		}
	}
	
	public override string ToString() {
		return Convert.ToString(Id_avaliacao) + " "+ ((Estabelecimento == null) ? "" : Convert.ToString(Estabelecimento.Estabelecimento) + " " + Convert.ToString(Estabelecimento.Cliente));
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
