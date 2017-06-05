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
public class Iguaria {
	public Iguaria() {
		_OrmAdapter = new IguariaORMAdapter(this);
		cliente_critica_Iguaria = new Cliente_critica_IguariaSetCollection<Iguaria>(this, _OrmAdapter, orm.ORMConstants.KEY_IGUARIA_CLIENTE_CRITICA_IGUARIA, orm.ORMConstants.KEY_CLIENTE_CRITICA_IGUARIA_IGUARIA, orm.ORMConstants.KEY_MUL_ONE_TO_MANY);
		cliente_seleciona_iguaria = new Cliente_seleciona_iguariaSetCollection<Iguaria>(this, _OrmAdapter, orm.ORMConstants.KEY_IGUARIA_CLIENTE_SELECIONA_IGUARIA, orm.ORMConstants.KEY_CLIENTE_SELECIONA_IGUARIA_IGUARIA, orm.ORMConstants.KEY_MUL_ONE_TO_MANY);
	}
	
	public static Iguaria LoadIguariaByORMID(int id_iguaria, Estabelecimento estabelecimento) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return LoadIguariaByORMID(session,id_iguaria, estabelecimento);
	}
	
	public static Iguaria LoadIguariaByORMID(PersistentSession session,int id_iguaria, Estabelecimento estabelecimento) {
		Iguaria iguaria = new Iguaria();
		iguaria.Id_iguaria = id_iguaria;
		iguaria.Estabelecimento = estabelecimento;
		
		return (Iguaria) session.Load(typeof(Iguaria), iguaria);
	}
	
	public static Iguaria[] ListIguariaByQuery(string condition, string orderBy) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return ListIguariaByQuery(session, condition, orderBy);
	}
	
	public static Iguaria[] ListIguariaByQuery(PersistentSession session, string condition, string orderBy) {
		global::System.Text.StringBuilder sb = new global::System.Text.StringBuilder("From Iguaria as Iguaria");
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
			Iguaria[] result = new Iguaria[list.Count];
			list.CopyTo(result, 0);
			return result;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public static Iguaria LoadIguariaByQuery(string condition, string orderBy) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return LoadIguariaByQuery(session, condition, orderBy);
	}
	
	public static Iguaria LoadIguariaByQuery(PersistentSession session, string condition, string orderBy) {
		Iguaria[] iguarias = ListIguariaByQuery(session, condition, orderBy);
		if (iguarias != null && iguarias.Length > 0)
			return iguarias[0];
		else
			return null;
	}
	
	public static global::System.Collections.IEnumerable IterateIguariaByQuery(string condition, string orderBy) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return IterateIguariaByQuery(session, condition, orderBy);
	}
	
	public static global::System.Collections.IEnumerable IterateIguariaByQuery(PersistentSession session, string condition, string orderBy) {
		global::System.Text.StringBuilder sb = new global::System.Text.StringBuilder("From Iguaria as Iguaria");
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
	
	public static Iguaria LoadIguariaByCriteria(IguariaCriteria iguariaCriteria) {
		Iguaria[] iguarias = ListIguariaByCriteria(iguariaCriteria);
		if(iguarias == null || iguarias.Length == 0) {
			return null;
		}
		return iguarias[0];
	}
	
	public static Iguaria[] ListIguariaByCriteria(IguariaCriteria iguariaCriteria) {
		return iguariaCriteria.ListIguaria();
	}
	
	public override bool Equals(object obj) {
		if (obj == this)
			return true;
		if (!(obj is Iguaria))
			return false;
		Iguaria iguaria = obj as Iguaria;
		if (Id_iguaria != iguaria.Id_iguaria)
			return false;
		if (Estabelecimento == null && iguaria.Estabelecimento != null)
			return false;
		if (!Estabelecimento.Equals(iguaria.Estabelecimento))
			return false;
		return true;
	}
	
	public override int GetHashCode() {
		int hashcode = 0;
		hashcode = hashcode + (int) Id_iguaria;
		if (Estabelecimento != null) {
			hashcode = hashcode + (int) Estabelecimento.ORMID;
		}
		return hashcode;
	}
	
	public static Iguaria CreateIguaria() {
		return new Iguaria();
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
			Estabelecimento estabelecimento = this.Estabelecimento;
			if(Estabelecimento != null) {
				Estabelecimento.iguaria.Remove(this);
			}
			this.ORM_Estabelecimento = estabelecimento;
			Cliente_critica_Iguaria[] lCliente_critica_Iguarias = cliente_critica_Iguaria.ToArray();
			foreach(Cliente_critica_Iguaria lCliente_critica_Iguaria in lCliente_critica_Iguarias) {
				lCliente_critica_Iguaria.Iguaria = null;
			}
			Cliente_seleciona_iguaria[] lCliente_seleciona_iguarias = cliente_seleciona_iguaria.ToArray();
			foreach(Cliente_seleciona_iguaria lCliente_seleciona_iguaria in lCliente_seleciona_iguarias) {
				lCliente_seleciona_iguaria.Iguaria = null;
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
			Estabelecimento estabelecimento = this.Estabelecimento;
			if(Estabelecimento != null) {
				Estabelecimento.iguaria.Remove(this);
			}
			this.ORM_Estabelecimento = estabelecimento;
			Cliente_critica_Iguaria[] lCliente_critica_Iguarias = cliente_critica_Iguaria.ToArray();
			foreach(Cliente_critica_Iguaria lCliente_critica_Iguaria in lCliente_critica_Iguarias) {
				lCliente_critica_Iguaria.Iguaria = null;
			}
			Cliente_seleciona_iguaria[] lCliente_seleciona_iguarias = cliente_seleciona_iguaria.ToArray();
			foreach(Cliente_seleciona_iguaria lCliente_seleciona_iguaria in lCliente_seleciona_iguarias) {
				lCliente_seleciona_iguaria.Iguaria = null;
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
		if (key == orm.ORMConstants.KEY_IGUARIA_CLIENTE_CRITICA_IGUARIA)
			return (System.Collections.Generic.ISet<T>) __cliente_critica_Iguaria;
		else if (key == orm.ORMConstants.KEY_IGUARIA_CLIENTE_SELECIONA_IGUARIA)
			return (System.Collections.Generic.ISet<T>) __cliente_seleciona_iguaria;
		return null;
	}
	
	private void This_SetOwner(object owner, int key) {
		if (key == orm.ORMConstants.KEY_IGUARIA_ESTABELECIMENTO) {
			this.__estabelecimento = (Estabelecimento) owner;
		}
	}
	
	private class IguariaORMAdapter : Orm.Util.AbstractORMAdapter {
		private readonly Iguaria __Iguaria;
		
		internal IguariaORMAdapter(Iguaria value) {
			__Iguaria = value;
		}
		
		public override System.Collections.Generic.ISet<T> GetSet<T>(int key) {
			return __Iguaria.This_GetSet<T>(key);
		}
		
		public override void SetOwner(object owner, int key) {
			__Iguaria.This_SetOwner(owner, key);
		}
		
	}
	
	internal Orm.Util.ORMAdapter _OrmAdapter;
	
	private int __id_iguaria;
	
	private Estabelecimento __estabelecimento;
	
	private int __estabelecimentoId;
	
	public int EstabelecimentoId {
		set {
			this.__estabelecimentoId = value;			
		}
		get {
			return __estabelecimentoId;			
		}
	}
	
	private string __nome_iguaria;
	
	private int __visual_iguaria = 0;
	
	private float __rating_medio_iguaria = 2f;
	
	private byte[] __fotografia;
	
	private Decimal __preco = new Decimal(0);
	
	private System.Collections.Generic.ISet<Cliente_critica_Iguaria> __cliente_critica_Iguaria = new System.Collections.Generic.HashSet<Cliente_critica_Iguaria>();
	
	private System.Collections.Generic.ISet<Cliente_seleciona_iguaria> __cliente_seleciona_iguaria = new System.Collections.Generic.HashSet<Cliente_seleciona_iguaria>();
	
	public int Id_iguaria {
		set {
			this.__id_iguaria = value;			
		}
		get {
			return __id_iguaria;			
		}
	}
	
	public string Nome_iguaria {
		set {
			this.__nome_iguaria = value;			
		}
		get {
			return __nome_iguaria;			
		}
	}
	
	public int Visual_iguaria {
		set {
			this.__visual_iguaria = value;			
		}
		get {
			return __visual_iguaria;			
		}
	}
	
	public float Rating_medio_iguaria {
		set {
			this.__rating_medio_iguaria = value;			
		}
		get {
			return __rating_medio_iguaria;			
		}
	}
	
	public byte[] Fotografia {
		set {
			this.__fotografia = value;			
		}
		get {
			return __fotografia;			
		}
	}
	
	public Decimal Preco {
		set {
			this.__preco = value;			
		}
		get {
			return __preco;			
		}
	}
	
	public Estabelecimento Estabelecimento {
		set {
			if(__estabelecimento!= null) {
				__estabelecimento.iguaria.Remove(this);
			}
			
			if(value != null) {
				value.iguaria.Add(this);
			}
		}
		get {
			return __estabelecimento;			
		}
	}
	
	private Estabelecimento ORM_Estabelecimento {
		set {
			this.__estabelecimento = value;			
		}
		
		get {
			return __estabelecimento;			
		}
	}
	
	private System.Collections.Generic.ISet<Cliente_critica_Iguaria> ORM_Cliente_critica_Iguaria {
		get  {
			return __cliente_critica_Iguaria;			
		}
		
		set {
			__cliente_critica_Iguaria = value;			
		}
	}
	
	public readonly Cliente_critica_IguariaSetCollection<Iguaria> cliente_critica_Iguaria;
	
	private System.Collections.Generic.ISet<Cliente_seleciona_iguaria> ORM_Cliente_seleciona_iguaria {
		get  {
			return __cliente_seleciona_iguaria;			
		}
		
		set {
			__cliente_seleciona_iguaria = value;			
		}
	}
	
	public readonly Cliente_seleciona_iguariaSetCollection<Iguaria> cliente_seleciona_iguaria;
	
	public override string ToString() {
		return Convert.ToString(Id_iguaria) + " "+ ((Estabelecimento == null) ? "" : Convert.ToString(Estabelecimento.ORMID));
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
